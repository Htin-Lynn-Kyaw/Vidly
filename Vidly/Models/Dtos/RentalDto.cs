using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models.Dtos
{
    public class RentalDto
    {
        public int customerID { get; set; }
        public List<int> moviesID { get; set; }
    }
}