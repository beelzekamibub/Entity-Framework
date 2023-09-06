using AutoMapper;
using EFCORE.Data;
using EFCORE.Models;
using EFCORE.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

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
    }
}
