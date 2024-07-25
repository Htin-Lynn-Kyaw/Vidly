using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;
using Vidly.Models.Dtos;

namespace Vidly.Controllers.API
{
    [Authorize]
    public class NewRentalController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public NewRentalController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult CreateNewRental(RentalDto rentalDto)
        {
            var customer = _context.Customers.Single(x => x.Id == rentalDto.customerID);
            var movies = _context.Movies.Where(x => rentalDto.moviesID.Contains(x.Id));

            foreach (var movie in movies)
            {
                if (movie.AvailableStock == 0) return BadRequest(movie.Title + " is not available!");

                movie.AvailableStock--;

                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    RentalDate = DateTime.Now,
                };
                _context.Rentals.Add(rental);
            }
            _context.SaveChanges();

            return Ok(rentalDto);
        }
    }
}
