using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiDataProvider.Entities
{
    public class Order
    {
        public int Id { get; }


        public string Address { get; set; }

        public string Location { get; set; }
               
        public DateTime DateAndTime { get; set; }

        //foreign key
        public int PassengerId { get; }

        public Passenger Passenger { get; set; }
    }
}
