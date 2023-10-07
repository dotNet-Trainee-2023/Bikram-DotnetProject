using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieAppAPI.Data;
using MovieAppAPI.Dto;
using MovieAppAPI.Services;

namespace MovieAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : Controller
    {

        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        
        [HttpGet("GetAllMovie")]
        public async Task<IActionResult> Index()
        {
            var moviesDto = await _movieService.GetAllMoviesAsync();
            return Ok(moviesDto);
        }

        [Authorize(Roles = "Admin")]
        //[Authorize]
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromForm] MovieCreateDto movieDto)
        {
            await _movieService.AddMovieAsync(movieDto);
            return Ok();
        }


        [HttpGet("GetById")]
        public async Task<IActionResult> GetMovieById(int id)
        {
            var movieDto = await _movieService.GetMovieAsync(id);
            return Ok(movieDto);
        }

        [HttpPost("Edit")]
        public async Task<IActionResult> Edit( MovieDto movieDto)
        {
           
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _movieService.UpdateMovieAsync(movieDto);
            return Ok();
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            await _movieService.DeleteMovieAsync(id);
            return Ok();
        }
    }
}
      
       

            

