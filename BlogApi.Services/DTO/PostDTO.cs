using BlogApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BlogApi.Services.DTO
{
    public sealed class PostDTO
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("author")]
        public string? Author { get; set; }
        [JsonPropertyName("title")]
        public string? Title { get; set; }
        [JsonPropertyName("content")]
        public string? Content { get; set; }

        [JsonPropertyName("tags")]
        public ICollection<TagDTO> Tags { get; set; } 

    }
}
