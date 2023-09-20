using Microsoft.AspNetCore.Mvc;
using MVCProject.Data;
using MVCProject.Model;
using MVCProject.Services;

namespace MVCProject.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieService movieService;

        public MovieController(IMovieService movieService )
        {
            this.movieService = movieService;
        }

        [HttpGet] 
        public IActionResult Index()
        {
            var movies = movieService.GetAllMovies();
            return View(movies);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return View(movie);
            }

            movieService.AddMovie(movie);

            return RedirectToAction("Index", "Movie");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var employee = movieService.GetMovie(id);
            return View(employee);
        }
        [HttpPost]
        public IActionResult Edit(Movie model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            movieService.UpdateMovie(model);

            return RedirectToAction("Index", "Movie");
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            movieService.DeleteMovie(id);
            return RedirectToAction("Index", "Movie");
        }
    }
}