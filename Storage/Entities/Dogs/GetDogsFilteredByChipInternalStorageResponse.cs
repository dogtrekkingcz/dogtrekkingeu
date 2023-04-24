using DogtrekkingCzShared.Entities;

namespace Storage.Entities.Dogs
{
    public sealed record GetDogsFilteredByChipInternalStorageResponse
    {
        public IList<DogDto> Dogs { get; set; } = new List<DogDto>();
    }
}
