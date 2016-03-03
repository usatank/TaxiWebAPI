using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TaxiDataProvider.EntitiesLinq2Sql;
using Utils;

namespace TaxiWebAPI.Models
{
    public class DriverModel : IDisposable
    {
        public DriverModel()
        {
            
        }

        public DriverModel(Driver d)
        {
            if (!Assert.IsNull(d))
            {
                Id = d.Id;
                FirstName = d.FirstName;
                LastName = d.LastName;
                PhoneNumber = d.PhoneNumber;
                HomeAddress = d.HomeAddress;
            }
        }

        public int Id { get; private set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string HomeAddress { get; set; }

        public void Dispose()
        {
        }
    }
}