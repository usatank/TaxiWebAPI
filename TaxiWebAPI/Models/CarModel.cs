namespace TaxiWebAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CarModel
    {         
        public int Id { get; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public string Number { get; set; }
    }
}
