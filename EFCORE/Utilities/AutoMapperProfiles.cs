using AutoMapper;
using EFCORE.Models;
using EFCORE.Models.DTOs;

namespace EFCORE.Utilities
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<GenrePostDTO, Genre>();
            CreateMap<Genre, GenrePostDTO>();

            CreateMap<ActorPostDTO, Actor>();
            CreateMap<Actor, ActorPostDTO>();

            CreateMap<CommentPostDTO, Comment>();
            CreateMap<Comment, CommentPostDTO>();

            CreateMap<Movie, MoviePostDTO>();
            CreateMap<MoviePostDTO, Movie>()
                .ForMember(dest => dest.Genres,
                opt => opt.MapFrom(src => src.GenresId.Select(id => new Genre() { GenreId = id })));

            CreateMap<MovieActorPostDTO, MovieActor>();
            CreateMap<MovieActor, MovieActorPostDTO>();
        }
    }
}
