using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.Models.ViewModels;

namespace Vidly.Controllers
{
    public class MovieController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MovieController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Movie
        public async Task<ViewResult> Index()
        {
            var movies = await _context.Movies.Include(m => m.Genre).ToListAsync();
            return View(movies);
        }

        public async Task<ViewResult> Details(int id)
        {
            var movie = await _context.Movies.Include(m => m.Genre).SingleOrDefaultAsync(x => x.Id == id);
            return View(movie);
        }

        public async Task<ViewResult> MovieForm()
        {
            var genres = await _context.Genres.ToListAsync();
            MovieFormViewModel viewModel = new MovieFormViewModel()
            {
                Genres = genres,
                IsEditMode = false,
                Movie = new Movie()
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(MovieFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Genres = _context.Genres.ToList();
                return View("MovieForm", viewModel);
            }

            var movie = viewModel.Movie;

            if (movie.Id == 0)
            {
                movie.AddedDate = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(x => x.Id == movie.Id);
                movieInDb.Title = movie.Title;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.NumberOfStock = movie.NumberOfStock;
                movieInDb.GenreID = movie.GenreID;
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Edit(int id)
        {
            var movie = await _context.Movies.Include(c => c.Genre).SingleOrDefaultAsync(x => x.Id == id);
            if (movie == null)
                return HttpNotFound();

            var viewModel = new MovieFormViewModel
            {
                Movie = movie,
                Genres = _context.Genres.ToList(),
                IsEditMode = true
            };

            return View("MovieForm", viewModel);
        }
    }
}