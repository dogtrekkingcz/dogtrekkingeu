using Storage.Entities.Migrations;

namespace Storage.Interfaces;

public interface IMigrationsRepositoryService
{
    Task<CreateMigrationInternalStorageResponse> CreateMigrationAsync(CreateMigrationInternalStorageRequest request, CancellationToken cancellationToken);

    Task<GetMigrationInternalStorageResponse> GetAsync(Guid id, CancellationToken cancellationToken);

    Task DeleteMigrationAsync(Guid id, CancellationToken cancellationToken);
}