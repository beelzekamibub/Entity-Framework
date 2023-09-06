using System.ComponentModel.DataAnnotations;

namespace EFCORE.Models.DTOs
{
    public class MoviePostDTO
    {
        [StringLength(maximumLength: 150)]
        public string Title { get; set; } = null!;
        public bool InTheaters { get; set; }
        public DateTime ReleaseDate { get; set; }
        public List<int> GenresId { get; set; }=new List<int>();
        public List<MovieActorPostDTO> MoviesActors { get; set; }=new List<MovieActorPostDTO>();
    }

    public class MovieActorPostDTO
    {
        public int ActorId { get; set; }
        public string Character { get; set; } = null!;
    }
}