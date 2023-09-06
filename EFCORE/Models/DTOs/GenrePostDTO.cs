using System.ComponentModel.DataAnnotations;

namespace EFCORE.Models.DTOs
{
    public class GenrePostDTO
    {
        [StringLength(maximumLength:150)]
        public string name { get; set; }
    }
}
