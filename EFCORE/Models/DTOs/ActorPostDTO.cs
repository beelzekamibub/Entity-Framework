using System.ComponentModel.DataAnnotations;

namespace EFCORE.Models.DTOs
{
    public class ActorPostDTO
    {
        [StringLength(maximumLength:150)]
        public string Name { get; set; } = null!;
        public decimal Fortune { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
