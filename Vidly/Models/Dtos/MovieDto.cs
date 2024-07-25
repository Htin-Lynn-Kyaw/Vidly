using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }
        public DateTime AddedDate { get; set; }

        [Range(1, 20)]
        public int NumberOfStock { get; set; } = 0;

        [Required]
        public byte GenreID { get; set; }
    }
}