using System.Threading;
using System.Threading.Tasks;
using Storage.Interfaces;
using Storage.Options;

namespace Storage.Services;

internal class InitializeService : IInitializeService
{
    private readonly StorageOptions _options;
    
    public InitializeService(StorageOptions options)
    {
        _options = options;
    }

    public Task InitializeAsync(CancellationToken cancellationToken)
    {
        return null;
    }
}