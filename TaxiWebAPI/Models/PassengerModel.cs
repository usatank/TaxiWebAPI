using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using TaxiDataProvider.EntitiesLinq2Sql;
using Utils;

namespace TaxiWebAPI.Models
{
    public class PassengerModel : IDisposable
    {
        public PassengerModel()
        {
            
        }

        public PassengerModel(Passenger p)
        {
            if (!Assert.IsNull(p))
            {
                Id = p.Id;
                Name = p.Name;
                PhoneNumber = p.PhoneNumber;
            }
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public void Dispose()
        {
        }
    }
}