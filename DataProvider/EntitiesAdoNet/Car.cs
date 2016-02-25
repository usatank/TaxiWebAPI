using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace TaxiDataProvider.EntitiesAdoNet
{
    [Table (Name = "Cars")]
    public class Car
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


    }
}
