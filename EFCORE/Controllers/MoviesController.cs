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

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Movie>> GetById(int id)
        {
            var Movie =await context.Movies
                .Include(x=>x.Comments)
                .Include(x=>x.Genres)
                .Include(x=>x.MoviesActors.OrderBy(x=>x.Order))
                    .ThenInclude(x=>x.Actor)     
                .FirstOrDefaultAsync(x=> x.Id== id);
            if (Movie is null)
            {
                return NotFound();
            }
            else return Movie;
        }
        
        [HttpGet("select/{id:int}")]
        public async Task<ActionResult> GetByIdSelect(int id)
        {
            var Movie =await context.Movies
                .Select(mov => new { 
                    Id= mov.Id,
                    Title=mov.Title,
                    Genres = mov.Genres.Select(g=>g.Name).ToList(),
                    Actors = mov.MoviesActors.OrderBy(ma=>ma.Order).Select(ma=> new { 
                        Id=ma.ActorId,
                        Name= ma.Actor.Name,
                        Character =ma.Character
                    }),
                    CommentsQuantity=mov.Comments.Count()
                })   
                .FirstOrDefaultAsync(x=> x.Id== id);
            if (Movie is null)
            {
                return NotFound();
            }
            else return Ok(Movie);
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
        [HttpDelete("{id:int}/newwaytodelete")]
        public async Task<ActionResult> Delete(int id)
        {
            var AlteredRows = await context.Movies.Where(x => x.Id == id).ExecuteDeleteAsync();
            //this returns the number of rows that were deleted in the database
            if (AlteredRows == 0) return NotFound();
            return Ok();
        }
    }
}
