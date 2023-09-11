using AutoMapper;
using EFCORE.Data;
using EFCORE.Models;
using EFCORE.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCORE.Controllers
{
    [Route("api/genres")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GenresController(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpGet("getallgenre")]
        public async Task<ActionResult<IEnumerable<Genre>>> GetAllGenre()
        {
            return await _dbContext.Genres.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Post(GenrePostDTO genrePostDTO)
        {
            _dbContext.Genres.Add(_mapper.Map<Genre>(genrePostDTO));
            await _dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPost("multiple")]
        public async Task<ActionResult> Post(GenrePostDTO[] genrePostDTO)
        {
            _dbContext.Genres.AddRange(_mapper.Map<Genre[]>(genrePostDTO));
            await _dbContext.SaveChangesAsync();
            return Ok();
        }
        [HttpPut("{id:int}/name2")]
        public async Task<ActionResult> Put(int id)
        {
            var genre = await _dbContext.Genres.FirstOrDefaultAsync(x => x.GenreId == id);
            if (genre == null) { return NotFound(); }
            genre.Name += "2";
            await _dbContext.SaveChangesAsync();
            return Ok(); 
        }

        [HttpDelete("{id:int}/newwaytodelete")]
        public async Task<ActionResult> Delete(int id)
        {
            var AlteredRows = await _dbContext.Genres.Where(x => x.GenreId == id).ExecuteDeleteAsync();
            //this returns the number of rows that were deleted in the database
            if(AlteredRows==0) return NotFound();
            return Ok();
        }
    }
}
