using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace TaxiDataProvider.EntitiesAdoNet
{

    [Table(Name = "Passengers")]
    public class Passenger
    {
        private int _id;

        [Column(IsPrimaryKey = true, IsDbGenerated = true, Name = "Id", Storage = "_id")]
        public int Id
        {
            get { return this._id; }
            private set { this._id = value;  }
        }

        private string _name;

        [Column(Name = "Name", Storage = "_name")]
        public string Name
        {
            get { return this._name; }
            set { this._name = value; }

        }

        private string _phoneNumber;

        [Column (Name = "Phone", Storage = "_phoneNumber" )]
        public string PhoneNumber
        {
            get { return this._phoneNumber; }
            set { this._phoneNumber = value; }
        }
    }
}
