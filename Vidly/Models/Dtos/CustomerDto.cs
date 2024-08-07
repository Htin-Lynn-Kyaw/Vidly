﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public bool IsSubscribed { get; set; }

        //[Min18YearsMember]
        public DateTime? BirthDate { get; set; }

        [Required]
        public byte MembershipTypeID { get; set; }
    }
}