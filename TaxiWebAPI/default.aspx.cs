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

            int id = 1;
            var car1 = repo.GetCar(id);

            Response.Write("Car with id " + id.ToString() + " " + car1.Brand + " " + car1.Model + " " + car1.Number + "<br />");
            id = 2;
            car1 = repo.GetCar(id);
            Response.Write("Car with id " + id.ToString() + " " + car1.Brand + " " + car1.Model + " " + car1.Number + "<br />");

        }
    }
}