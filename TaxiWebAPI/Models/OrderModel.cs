using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using TaxiDataProvider.EntitiesLinq2Sql;
using Utils;

namespace TaxiWebAPI.Models
{
    public class OrderModel : IDisposable
    {
        public OrderModel()
        {

        }

        public OrderModel(Order o)
        {
            if (!Assert.IsNull(o))
            {
                Id = o.Id;
                Address = o.Address;
                Location = o.Location;
                DateAndTime = o.DateAndTime;
                PassengerId = o.PassengerId;
                Passenger = new PassengerModel(o.Passenger);
            }
        }

        public int Id { get; private set; }


        public string Address { get; set; }

        public string Location { get; set; }

        public DateTime DateAndTime { get; set; }

        //foreign key
        public int PassengerId { get; }

        public PassengerModel Passenger { get; set; }

        public void Dispose()
        {
        }

    }
}