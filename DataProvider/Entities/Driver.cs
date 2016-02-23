using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiDataProvider.Entities
{
    public class Driver
    {
        public int Id { get; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string HomeAddress { get; set; }
    }
}
