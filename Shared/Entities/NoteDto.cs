namespace DogtrekkingCzShared.Entities
{
    public class NoteDto
    {
        public DateTimeOffset Time { get; set; } = DateTimeOffset.Now;

        public string Text { get; set; } = string.Empty;
    }
}
