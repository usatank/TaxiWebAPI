﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace TaxiDataProvider.EntitiesLinq2Sql
{
    [Table (Name = "Cars")]
    public class Car : IDisposable
    {        
        private int _id;

        [Column(IsPrimaryKey = true, IsDbGenerated = true, Name = "Id", Storage = "_id")]
        public int Id
        {
            get { return this._id;  }
            private set { this._id = value;  }
        }

        private string _brand;

        [Column (Name = "Brand", Storage = "_brand")]
        public string Brand
        {
            get { return this._brand; }
            set { this._brand = value; }
        }

        private string _model;

        [Column (Name = "Model", Storage = "_model")]
        public string Model
        {
            get { return this._model; }
            set { this._model = value; }
        }

        private string _number;

        [Column(Name = "Number", Storage = "_number")]
        public string Number
        {
            get { return this._number; }
            set { this._number = value; }
        }

        public Car()
        {
            
        }

        public Car(int idValue)
        {
            Id = idValue;
        }

        public bool Equals(Car car2)
        {
            if (car2 == null)
                return false;

            return (this.Id == car2.Id &&
                    this.Brand == car2.Brand &&
                    this.Model == car2.Model &&
                    this.Number == car2.Number);
        }

        public void Dispose()
        {
            //for testing purposes
        }


    }
}
