using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Rental
    {
        public int Id { get; set; }
        public DateTime? ReturnDate { get; set; }
        public DateTime RentalDate { get; set; }

        [Required]
        public int CustomerID { get; set; }
        public Customer Customer { get; set; }
        [Required]
        public int MovieID { get; set; }
        public Movie Movie { get; set; }
    }
}