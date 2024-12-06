using System.Text.Json.Serialization;

namespace BlogApi.Services.DTO;

public sealed class TagDTO
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("name")]
    public string? Name { get; set; }
    //[JsonPropertyName("posts")]
    //public IEnumerable<PostDTO> Posts { get; set; } = [];
}
