using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Google.Type;
using Protos.Checkpoints.AddCheckpoint;
using SharedLib.Extensions;
using SQLite;

namespace GpsTracker.Services.Storage;

public class PositionHistoryService
{
    SQLiteAsyncConnection Database;

    public PositionHistoryService()
    {
        ServiceHelper.OnLocationChanged += OnPositionChangedHandler;
    }

    async Task Init()
    {
        if (Database is not null)
            return;

        Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);

        var result = await Database.CreateTableAsync<PositionDto>();
    }

    public async Task CleanHistoryAsync()
    {
        await Init();

        await Database.DeleteAllAsync<PositionDto>();
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

    private async void OnPositionChangedHandler(Location location)
    {
        await SaveItemAsync(new PositionHistoryService.PositionDto()
        {
            Latitude = location.Latitude,
            Longitude = location.Longitude,
            Altitude = location.Altitude ?? double.NaN,
            Accuracy = location.Accuracy ?? double.NaN,
            Time = location.Timestamp,
            Id = 0,
            ActionId = Guid.Parse(ServiceHelper.CurrentSelectedActionId),
            Note = ServiceHelper.CurrentNote,
            Course = location.Course ?? double.NaN,
            ActivityId = Guid.Parse(ServiceHelper.CurrentSelectedActivityId)
        });
    }
    
    public async Task<int> SaveItemAsync(PositionDto item)
    {
        await Init();

        var ret = 0;
        
        if (item.Id != 0)
            ret = await Database.UpdateAsync(item);
        else
            ret = await Database.InsertAsync(item);

        return ret;
    }

    public async Task<int> DeleteItemAsync(PositionDto item)
    {
        await Init();
        
        return await Database.DeleteAsync(item);
    }

    public sealed record PositionDto
    {
        [PrimaryKey, AutoIncrement]
        [Column("Id")]
        public Int64 Id { get; set; } = 0;

        public Guid ActivityId { get; set; } = Guid.Empty;

        public Guid ActionId { get; set; } = Guid.Empty;
        
        public DateTimeOffset? TimeOfSynchronizationWithServer { get; set; } = null;
        
        public double Latitude { get; set; } = double.NaN;

        public double Longitude { get; set; } = double.NaN;

        public double Altitude { get; set; } = double.NaN;

        public double Accuracy { get; set; } = double.NaN;

        public double Course { get; set; } = double.NaN;

        public string Note { get; set; } = string.Empty;

        public DateTimeOffset Time { get; set; } = DateTimeOffset.MinValue;
    }
}