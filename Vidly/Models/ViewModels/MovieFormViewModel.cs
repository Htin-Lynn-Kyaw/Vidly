using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models.ViewModels
{
    public class MovieFormViewModel
    {
        public Movie Movie { get; set; }
        public List<Genre> Genres { get; set; }
        public bool IsEditMode { get; set; }
    }
}