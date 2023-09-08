using AutoMapper;
using EFCORE.Data;
using EFCORE.Models;
using EFCORE.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCORE.Controllers
{
    [Route("api/actors")]
    [ApiController]
    public class ActorsController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public ActorsController(ApplicationDbContext dbContext,IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        [HttpPost]
        public async Task<ActionResult> Post(ActorPostDTO actorDTO)
        {
            dbContext.Actors.Add(mapper.Map<Actor>(actorDTO));
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("getactorsbyname")]
        public async Task<ActionResult<IEnumerable<Actor>>> GetActorsByName(string name)
        {
            return await dbContext.Actors.Where(e=>e.Name==name).ToListAsync();
        }

        [HttpGet("getallactors")]
        public async Task<ActionResult<IEnumerable<Actor>>> GetAllGenre()
        {
            return await dbContext.Actors.ToListAsync();
        }
    }
}
