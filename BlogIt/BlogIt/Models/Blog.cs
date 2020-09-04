using BlogIt.Enum;
using System;
using System.ComponentModel.DataAnnotations;

namespace BlogIt.Models
{
    public class Blog
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Tilte { get; set; }
        [Required]
        public Tags Tag { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string Description { get; set; }
        public int UserId { get; set; }
    }
}
