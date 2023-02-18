using System.Threading;
using System.Threading.Tasks;
using Storage.Interfaces.Options;
using Storage.Interfaces.Services;

namespace Storage.Services;

internal class InitializeService : IInitializeService
{
    private readonly StorageOptions _options;
    
    public InitializeService(StorageOptions options)
    {
        _options = options;
    }

    public async Task InitializeAsync(CancellationToken cancellationToken)
    {
        
    }
}