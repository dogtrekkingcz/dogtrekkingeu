namespace Storage.Entities.Pets
{
    public sealed record GetPetsFilteredByChipInternalStorageRequest
    {
        public string Chip { get; set; } = string.Empty;
    }
}
