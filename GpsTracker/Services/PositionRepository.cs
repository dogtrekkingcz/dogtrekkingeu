namespace GpsTracker.Services;

internal class PositionRepository : IPositionRepository
{
    private List<IPositionRepository.PositionDto> History { get; set; } = new();
    
    public async Task DeleteAllCurrentDataAsync()
    {
        History.Clear();
    }

    public async Task AddAsync(IPositionRepository.PositionDto position)
    {
        History.Add(position);
    }
}