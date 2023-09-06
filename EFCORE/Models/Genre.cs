using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EFCORE.Models
{
    public class Genre
    {
        //[Key]
        public int GenreId { get; set; }
        //[StringLength(maximumLength:150)]
        public string Name { get; set; } = null!;

        public HashSet<Movie> Movies { get; set; }= new HashSet<Movie>();
    }
}
