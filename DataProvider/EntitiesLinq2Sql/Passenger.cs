using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace TaxiDataProvider.EntitiesLinq2Sql
{

    [Table(Name = "Passengers")]
    public class Passenger : IDisposable
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

        //for testing purposes
        public Passenger()
        {          
        }

        public Passenger(int passengerId)
        {
            Id = passengerId;
        }

        public bool Equals(Passenger passenger2)
        {
            if (passenger2 == null)
                return false;

            return (this.Id == passenger2.Id &&
                    this.Name == passenger2.Name &&
                    this.PhoneNumber == passenger2.PhoneNumber);
        }

        public void Dispose()
        {
            //for testing purposes
        }
    }
}
