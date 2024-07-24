using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }
        public DateTime AddedDate { get; set; }

        [Display(Name = "Number of stock")]
        [Range(1, 20)]
        public int NumberOfStock { get; set; } = 0;

        public Genre Genre { get; set; }
        [Required, Display(Name = "Genre")]
        public byte GenreID { get; set; }
    }
}