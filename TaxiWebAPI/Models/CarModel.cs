namespace TaxiWebAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using TaxiDataProvider.EntitiesLinq2Sql;
    using Utils;

    public partial class CarModel : IDisposable
    {
        public CarModel()
        {
                
        }

        public CarModel(Car c)
        {
            if (!Assert.IsNull(c))   
            {
                Id = c.Id;
                Brand = c.Brand;
                Model = c.Model;
                Number = c.Number;
            }

        }
                
        public int Id { get; private set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public string Number { get; set; }

        public void Dispose()
        {
        }
    }
}
