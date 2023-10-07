using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieAppAPI.Dto;
using MovieAppAPI.Services;

namespace MovieAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet("GetAllComment")]
        public async Task<IActionResult> Index()
        {
            var commentDto = await _commentService.GetAllCommentAsync();
            return Ok(commentDto);

        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromForm] CommentCreateDto commentDto)
            {
            await _commentService.AddCommentAsync(commentDto);
            return Ok();
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetMovieById(int Commentid)
        {
            var commentDto = await _commentService.GetCommentAsync(Commentid);
            return Ok(commentDto);
        }
        [HttpPost("Edit")]
        public async Task<IActionResult> Edit(CommentDto commentDto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _commentService.UpdateCommentAsync(commentDto);
            return Ok();
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int Commentid)
        {
            await _commentService.DeleteCommentAsync(Commentid);
            return Ok();
        }

    }
}
