﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BlogApi.Models
{
    public class Tag 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Name { get; set; }
        public ICollection<Post> Posts { get; set; } = new List<Post>();

        [JsonIgnore]

        public bool IsDeleted { get; set; }
    }
}
