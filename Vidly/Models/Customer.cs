﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public bool IsSubscribed { get; set; }

        [Display(Name = "Date of Birth")]
        [Min18YearsMember]
        public DateTime? BirthDate { get; set; }


        public MembershipType MembershipType { get; set; }
        [Display(Name = "Membership Type")]
        [Required]
        public byte MembershipTypeID { get; set; }
    }
}