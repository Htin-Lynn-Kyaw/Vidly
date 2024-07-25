using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;
using Vidly.Models.Dtos;

namespace Vidly.Controllers.API
{
    [Authorize(Roles = SystemRoles.ADMIN)]
    public class MovieController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public MovieController()
        {
            _context = new ApplicationDbContext();
        }

        public IHttpActionResult GetMovies(string query = null)
        {
            var movieQuery = _context.Movies
                .Include(x => x.Genre)
                .Where(x => x.AvailableStock > 0);

            if (!string.IsNullOrEmpty(query))
            {
                movieQuery = movieQuery.Where(x => x.Title.Contains(query));
            }

            var movieDto = movieQuery.ToList().Select(Mapper.Map<Movie, MovieDto>);
            return Ok(movieDto);
        }

        public IHttpActionResult GetMovieById(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movie == null) return NotFound();

            return Ok(Mapper.Map<Movie, MovieDto>(movie));
        }

        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid) return BadRequest();

            var movie = Mapper.Map<MovieDto, Movie>(movieDto);

            _context.Movies.Add(movie);
            _context.SaveChanges();

            movieDto.Id = movie.Id;

            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
        }

        [HttpPut]
        public IHttpActionResult UpdateMovie(int Id, MovieDto movieDto)
        {
            if (!ModelState.IsValid) return BadRequest();
            
            var movie = _context.Movies.SingleOrDefault(x => x.Id == Id);

            if (movie == null) return NotFound();

            Mapper.Map(movieDto, movie);

            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteMovie(int Id)
        {
            var movieInDB = _context.Movies.SingleOrDefault(x => x.Id == Id);

            if (movieInDB == null) return NotFound();

            _context.Movies.Remove(movieInDB);
            _context.SaveChanges();

            return Ok();
        }
    }
}
