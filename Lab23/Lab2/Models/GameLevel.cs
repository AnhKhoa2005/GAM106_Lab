using System.ComponentModel.DataAnnotations;

namespace Lab2.Models
{
    public class GameLevel
    {
        [Key]
        public int LevelId { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
    }
}
