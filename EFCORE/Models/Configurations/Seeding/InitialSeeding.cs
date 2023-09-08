using Microsoft.EntityFrameworkCore;

namespace EFCORE.Models.Configurations.Seeding
{
    public class InitialSeeding
    {
        public static void seed(ModelBuilder modelBuilder)
        {
            var samlueljackson = new Actor()
            {
                Id=2,
                Name="Samuel L Jackson",
                DateOfBirth=new DateTime(1948,12,21),
                Fortune=123456753
            };

            var roberdowneyjr = new Actor()
            {
                Id = 3,
                Name = "robert downey jr",
                DateOfBirth = new DateTime(1965, 12, 21),
                Fortune = 123456753
            };

            modelBuilder.Entity<Actor>().HasData(samlueljackson, roberdowneyjr);

            var avengers = new Movie()
            {
                Id = 2,
                Title = "Avengers Endgame",
                ReleaseDate = new DateTime(2019,4,22)
            };

            modelBuilder.Entity<Movie>().HasData(avengers);

            var comment = new Comment()
            {
                MovieId = 2,
                Recommend=true,
                Content="Very good",
                Id=2
            };
            modelBuilder.Entity<Comment>().HasData(comment);

            var tableName = "GenreMovie";
            var genreIdProp = "GenresGenreId";
            var movieIdProp = "MoviesId";

            var scifi = 5;
            var animation = 6;

            modelBuilder.Entity(tableName).HasData(
                new Dictionary<string, object>
                {
                    [genreIdProp]=scifi,
                    [movieIdProp]=avengers.Id
                }
            );

            var samuelavengers = new MovieActor()
            {
                ActorId = samlueljackson.Id,
                MovieId = avengers.Id,
                Order = 2,
                Character = "nick fury"
            };

            modelBuilder.Entity<MovieActor>().HasData(samuelavengers);  
        }
    }
}
