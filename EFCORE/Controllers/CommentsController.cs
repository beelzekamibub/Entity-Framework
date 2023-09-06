using AutoMapper;
using EFCORE.Data;
using EFCORE.Models;
using EFCORE.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EFCORE.Controllers
{
    [Route("api/movies/{movieId:int}/comments")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public CommentsController(ApplicationDbContext context,IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> Post(int movieId,CommentPostDTO commentDTO)
        {
            Comment comment = mapper.Map<Comment>(commentDTO);
            comment.MovieId= movieId;
            context.Comments.Add(comment);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
