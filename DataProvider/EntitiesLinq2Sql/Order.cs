using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace TaxiDataProvider.EntitiesLinq2Sql
{
    [Table(Name = "Orders")]
    public class Order : IDisposable
    {
        private int _id;
        [Column(IsPrimaryKey = true, IsDbGenerated = true, Name = "Id", Storage = "_id")]
        public int Id
        {
            get { return this._id; }
            private set { this._id = value;  }
        }

        private string _address;        
        [Column(Name = "Address", Storage = "_address")]    
        public string Address
        {
            get { return this._address; }
            set { this._address = value; }
        }

        private string _location;
        [Column(Name = "Location", Storage = "_location")]
        public string Location
        {
            get { return this._location; }
            set { this._location = value; }
        }

        private DateTime _dateAndTime;
        [Column(Name = "DateAndTime", Storage = "_dateAndTime")]
        public DateTime DateAndTime
        {
            get { return this._dateAndTime; }
            set { this._dateAndTime = value; }
        }

        //foreign key
        private int _passengerId;
        [Column(Name = "PassengerId", Storage = "_passengerId")]
        public int PassengerId
        {
            get { return this._passengerId; }
            set { this._passengerId = value; }
        }


        //check - whether it is necessary?
        //public Passenger Passenger { get; set; }
        
            //for testing purposes
        public Order()
        {
            Id = 1;
        }

        public bool Equals(Order order2)
        {
            return (this.Id == order2.Id &&
                    this.DateAndTime.ToShortDateString()  == order2.DateAndTime.ToShortDateString() &&
                    this.DateAndTime.ToShortTimeString() == order2.DateAndTime.ToShortTimeString() &&
                    this.Location == order2.Location &&
                    this.Address == order2.Address &&
                    this.PassengerId == order2.PassengerId);
        }

        public void Dispose()
        {
            //for testing purposes
        }
    }
}
