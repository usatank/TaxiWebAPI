using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TaxiWebAPI.Models
{
    public class OrderModel
    {
        public int Id { get; }


        public string Address { get; set; }

        public string Location { get; set; }

        public DateTime DateAndTime { get; set; }

        //foreign key
        public int PassengerId { get; }

        public PassengerModel Passenger { get; set; }


    }
}