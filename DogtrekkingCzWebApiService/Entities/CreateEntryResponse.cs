namespace DogtrekkingCzWebApiService.Entities;

public sealed record CreateEntryResponse
{
    public Guid Id { get; init; }
    
    public CreateEntryResponse(DogtrekkingCz.Entries.Interface.Entities.CreateEntryResponse response)
    {
        Id = response.Id;
    }
}