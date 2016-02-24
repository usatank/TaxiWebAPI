using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TaxiDataProvider;
using TaxiDataProvider.EntitiesAdoNet;
using System.Data.Linq;

namespace TaxiWebAPI
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AdoNetTaxiDataRepository repo = new AdoNetTaxiDataRepository();
            //repo.AddCar(new Car { Brand = "Kia", Model = "Cerato", Number = "AA0802AH" });
            
            var cars = repo.GetAllCars();
            foreach (Car car in cars)
            {
                Response.Write("Car: " + car.Id + " " + car.Brand + " " + car.Model + " " + car.Number + "<br />");
            }
            
        }
    }
}