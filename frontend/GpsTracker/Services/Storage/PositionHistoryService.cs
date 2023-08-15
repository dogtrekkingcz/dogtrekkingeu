using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;

namespace GpsTracker.Services.Storage;

public class PositionHistoryService
{
    SQLiteAsyncConnection Database;

    public PositionHistoryService()
    {
    }

    async Task Init()
    {
        if (Database is not null)
            return;

        Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        var result = await Database.CreateTableAsync<PositionDto>();
    }
    
    public async Task<List<PositionDto>> GetItemsAsync()
    {
        await Init();
        
        return await Database.Table<PositionDto>().ToListAsync();
    }

    public async Task<List<PositionDto>> GetItemsNotSynchronizedAsync()
    {
        await Init();

        return await Database.Table<PositionDto>().Where(t => t.TimeOfSynchronizationWithServer == null).ToListAsync();
    }

    public async Task<PositionDto> GetItemAsync(int id)
    {
        await Init();
        
        return await Database.Table<PositionDto>().Where(i => i.Id == id).FirstOrDefaultAsync();
    }

    public async Task<int> SaveItemAsync(PositionDto item)
    {
        await Init();
        
        if (item.Id != 0)
            return await Database.UpdateAsync(item);
        else
            return await Database.InsertAsync(item);
    }

    public async Task<int> DeleteItemAsync(PositionDto item)
    {
        await Init();
        
        return await Database.DeleteAsync(item);
    }

    public sealed record PositionDto
    {
        public Int64 Id { get; set; } = 0;

        public Guid ActionId { get; set; } = Guid.Empty;
        
        public DateTimeOffset? TimeOfSynchronizationWithServer { get; set; } = null;
        
        public double Latitude { get; set; } = double.NaN;

        public double Longitude { get; set; } = double.NaN;

        public double Altitude { get; set; } = double.NaN;

        public double Accuracy { get; set; } = double.NaN;

        public DateTimeOffset Time { get; set; } = DateTimeOffset.MinValue;
    }
}