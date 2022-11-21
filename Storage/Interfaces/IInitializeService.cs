using System.Threading;
using System.Threading.Tasks;
using Storage.Interfaces.Options;

namespace Storage.Interfaces.Services;

public interface IInitializeService
{
    public Task InitializeAsync(CancellationToken cancellationToken);
}