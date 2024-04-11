using MapsterMapper;
using Storage.Entities.Entries;
using Storage.Entities.Migrations;
using Storage.Extensions;
using Storage.Interfaces;
using Storage.Models;

namespace Storage.Services.Repositories.Migrations;

internal sealed class MigrationsRepositoryService : IMigrationsRepositoryService
{
    private readonly IMapper _mapper;
    private readonly IStorageService<MigrationRecord> _migrationsStorageService;
    
    public MigrationsRepositoryService(IMapper mapper, IStorageService<MigrationRecord> migrationsStorageService)
    {
        _mapper = mapper;
        _migrationsStorageService = migrationsStorageService;
    }
    
    public async Task<CreateMigrationInternalStorageResponse> CreateMigrationAsync(CreateMigrationInternalStorageRequest request, CancellationToken cancellationToken)
    {
        var migrationRecord = _mapper.Map<MigrationRecord>(request);
        
        var createdMigration = await _migrationsStorageService.AddAsync(migrationRecord, cancellationToken);
        
        return new CreateMigrationInternalStorageResponse { Id = createdMigration.Id };
    }

    public async Task<GetMigrationInternalStorageResponse> GetAsync(string id, CancellationToken cancellationToken)
    {
        var migration = await _migrationsStorageService.GetAsync(id, cancellationToken);
        if (migration is null)
        {
            return null;
        }

        return _mapper.Map<GetMigrationInternalStorageResponse>(migration);
    }

    public async Task DeleteMigrationAsync(string id, CancellationToken cancellationToken)
    {
        await _migrationsStorageService.DeleteAsync(id, cancellationToken);
    }
}