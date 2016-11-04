using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vildy.Models;
using Vildy.ViewModels;

namespace Vildy.Controllers
{
	public class MoviesController : Controller
	{

		ApplicationDbContext _context;
		public MoviesController()
		{
			_context = new ApplicationDbContext();
		}


		public ActionResult Index()
		{
			var movies = _context.Movies.Include(c => c.MovieGenreType).ToList();
			return View(movies);
		}

		public ActionResult Create()
		{

			var movieGenreTypes = _context.MovieGenreTypes.ToList();
			var newMovieViewModel = new MovieFormViewModel();
			newMovieViewModel.MovieGenreTypes = movieGenreTypes;


			return View("MovieForm", newMovieViewModel);
		}

		public ActionResult Edit(int id)
		{
			var movie = _context.Movies.Include(c => c.MovieGenreType).SingleOrDefault(c => c.Id == id);
			if (movie == null)
				return HttpNotFound();

			var viewModel = new MovieFormViewModel(movie)
			{
			
				MovieGenreTypes = _context.MovieGenreTypes.ToList()
			};

			return View("MovieForm", viewModel);
		}

		public ActionResult Details(int id)
		{
			var movie = _context.Movies.Include(c => c.MovieGenreType).SingleOrDefault(c => c.Id == id);
			if (movie == null)
				return HttpNotFound();

			return View(movie);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Save(Movie movie)
		{
			if(!ModelState.IsValid)
			{

				var viewModel = new MovieFormViewModel(movie)
				{
					MovieGenreTypes = _context.MovieGenreTypes.ToList()
				};
				return View("MovieForm", viewModel);
			}
	
			if (movie.Id == 0)
				_context.Movies.Add(movie);
			else
			{
				var movieInDB = _context.Movies.Single(c => c.Id == movie.Id);
				movieInDB.InStock = movie.InStock;
				movieInDB.MovieGenreTypeID = movie.MovieGenreTypeID;
				movieInDB.Name = movie.Name;
				movieInDB.ReleaseDate = movie.ReleaseDate;
				movieInDB.DateAdded = movie.DateAdded;

			}

			_context.SaveChanges();

			return RedirectToAction("Index", "Movies");

		}
	}
}