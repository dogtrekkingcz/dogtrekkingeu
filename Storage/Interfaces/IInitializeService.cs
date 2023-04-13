namespace Storage.Interfaces;

public interface IInitializeService
{
    public Task InitializeAsync(CancellationToken cancellationToken);
}