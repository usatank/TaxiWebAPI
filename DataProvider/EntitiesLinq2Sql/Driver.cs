using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace TaxiDataProvider.EntitiesLinq2Sql
{
    [Table(Name = "Drivers")]
    public class Driver : IDisposable
    {
        private int _id;

        [Column(IsPrimaryKey = true, IsDbGenerated = true, Name = "Id", Storage = "_id")]
        public int Id
        {
            get { return this._id;  }
            private set { this._id = value; }
        }

        private string _firstName;

        [Column(Name = "FirstName", Storage = "_firstName")]
        public string FirstName
        {
            get { return this._firstName; }
            set { this._firstName = value; }
        }


        private string _lastName;

        [Column(Name = "LastName", Storage = "_lastName")]
        public string LastName
        { get { return this._lastName; }
          set { this._lastName = value; }
        }

        private string _phoneNumber;

        [Column(Name = "PhoneNumber", Storage = "_phoneNumber")]
        public string PhoneNumber
        {
            get { return this._phoneNumber; }
            set { this._phoneNumber = value; }
        }

        private string _homeAddress;
        [Column(Name = "HomeAddress", Storage = "_homeAddress")]
        public string HomeAddress
        {
            get { return this._homeAddress; }
            set { this._homeAddress = value;  }
        }

        //for testing purposes
        public Driver()
        {
            Id = 1;
        }

        public void Dispose()
        {
            //for testing purposes
        }
    }
}
