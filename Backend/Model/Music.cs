using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Backend.Model
{
    public class Music
    {
        public Guid Id { get; set; }
        
        [Required]
        public String Name { get; set; }

        [Required]
        public int Duration { get; set; }

        [JsonIgnore]
        public Album Album { get; set; }
        

    }
    
}