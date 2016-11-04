using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vildy.Dtos;
using Vildy.Models;

namespace Vildy.Controllers.API
{
    public class MoviesController : ApiController
    {


		private ApplicationDbContext _context;

		public MoviesController()
		{
			_context = new ApplicationDbContext();

		}

		//GET api/movies 
		public IHttpActionResult GetMovies()
		{

			return Ok(_context.Movies.ToList().Select(Mapper.Map<Movie, MovieDto>));
		}

		//GET api/movies/1
		public IHttpActionResult GetMovie(int movieID)
		{
			var movie = _context.Movies.SingleOrDefault(x => x.Id == movieID);

			if (movie == null)
				return NotFound();

			return Ok(Mapper.Map<Movie, MovieDto>(movie));
		}

		//POST api/movies
		[HttpPost]
		public IHttpActionResult CreateMovie(MovieDto movieDto)
		{

			if (!ModelState.IsValid)
				return BadRequest();

			var movie = Mapper.Map<MovieDto, Movie>(movieDto);
			_context.Movies.Add(movie);
			_context.SaveChanges();

			movieDto.Id = movie.Id;

			return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
		}

		//PUT api/movies/1
		[HttpPut]
		public IHttpActionResult UpdateMovie(int movieID, MovieDto movieDto)
		{

			if (!ModelState.IsValid)
				return BadRequest();			
	
			var movieInDB = _context.Movies.SingleOrDefault(x => x.Id == movieID);

			if (movieInDB == null)
				return NotFound();				

			Mapper.Map(movieDto, movieInDB);

			_context.SaveChanges();

			return Ok();
		}

		//DELETE api/movies/1
		[HttpDelete]
		public IHttpActionResult DeleteMovie(int movieID)
		{
			var movieInDB = _context.Movies.SingleOrDefault(x => x.Id == movieID);

			if (movieInDB == null)
				return BadRequest();

			_context.Movies.Remove(movieInDB);

			_context.SaveChanges();

			return Ok();
		}
	}
}
