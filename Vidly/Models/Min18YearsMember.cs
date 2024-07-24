using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;

namespace Vidly.Models
{
    public class Min18YearsMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = validationContext.ObjectInstance as Customer;

            if(customer.MembershipTypeID == 1 || customer.MembershipTypeID == 0) // Avoid magic numbers
                return ValidationResult.Success;

            if (customer.BirthDate == null)
                return new ValidationResult("Date of birth is required!");

            return (DateTime.Now.Year - customer.BirthDate.Value.Year) >= 18 
                   ? ValidationResult.Success 
                   : new ValidationResult("Customer should be at least 18 years old of age!");

        }
    }
}