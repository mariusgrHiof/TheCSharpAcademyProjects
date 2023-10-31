using Microsoft.AspNetCore.Mvc;
using Movies.Models;

namespace Movies.Controllers
{
    public class MoviesController : Controller
    {
        public IActionResult Index()
        {
            List<Movie> movies = new List<Movie>()
            {
            new Movie
            {
                Id = 1,
                Title = "Rocky 4",
                Year = 1985,
                Genre = "Drama",
                DurationInMinutes = 90
            },
             new Movie
            {
                Id = 2,
                Title = "Rocky 3",
                Year = 1983,
                Genre = "Drama",
                DurationInMinutes = 75
            }
        };
            return View(movies);
        }
    }
}
