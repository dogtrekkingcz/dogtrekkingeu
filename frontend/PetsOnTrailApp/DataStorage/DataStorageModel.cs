namespace PetsOnTrailApp.DataStorage;

public sealed record DataStorageModel<T> where T : class
{
    public Guid Id { get; init; }

    public DateTime Created { get; init; }

    public T Data { get; init; }
}
