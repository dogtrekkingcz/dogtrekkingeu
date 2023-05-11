namespace DogsOnTrailWebApiService.Entities
{
    public sealed record ActionDetailResponse
    {
        private Guid _id { get; init; }

        public Guid Id { get { return _id; } }

        public ActionDetailResponse(Guid newGuid)
        {
            _id = newGuid;
        }
    }
}
