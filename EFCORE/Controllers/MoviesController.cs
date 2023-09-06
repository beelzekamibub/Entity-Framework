using AutoMapper;
using EFCORE.Data;
using EFCORE.Models;
using EFCORE.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCORE.Controllers
{
    [Route("api/movies")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public MoviesController(ApplicationDbContext context,IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> Post(MoviePostDTO moviedto)
        {
            var movie = mapper.Map<Movie>(moviedto);
            if(movie.Genres is not null)
            {
                //change the state of the genres we are receiving by telling EF core that these correspond to the ones in the genres table
                foreach(var genre in movie.Genres)
                {
                    context.Entry(genre).State=EntityState.Unchanged;
                }
                
            }

            if(movie.MoviesActors is not null)
            {
                for(int i = 0; i < movie.MoviesActors.Count; i++)
                {
                    movie.MoviesActors[i].Order = i + 1;
                }
            }
            context.Movies.Add(movie);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
