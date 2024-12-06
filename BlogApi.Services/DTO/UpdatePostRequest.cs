namespace BlogApi.Services.DTO
{
    public class UpdatePostRequest
    {
        public string? Author { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public List<int>? TagIds { get; set; } = new List<int>();
    }
}
