namespace BlogApi.Services.DTO
{
    public class AddPostRequest
    {
        public string? Author { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }

        public List<int> TagIds { get; set; } = [];
    }
}
