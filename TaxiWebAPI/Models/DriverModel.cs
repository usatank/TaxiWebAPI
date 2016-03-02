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

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string HomeAddress { get; set; }

    }
}