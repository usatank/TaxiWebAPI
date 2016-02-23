using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaxiWebAPI.Models
{
    public class DriverModel
    {
        public DriverModel()
        {

        }

        public int Id { get; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string HomeAddress { get; set; }

    }
}