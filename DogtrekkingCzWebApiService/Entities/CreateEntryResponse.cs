namespace DogtrekkingCzWebApiService.Entities;

public sealed record CreateEntryResponse
{
    public string Id { get; init; }
    
    public CreateEntryResponse(DogtrekkingCz.Entries.Interface.Entities.CreateEntryResponse response)
    {
        Id = response.Id;
    }
}