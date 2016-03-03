using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TaxiDataProvider;
using TaxiDataProvider.EntitiesLinq2Sql;
using TaxiWebAPI.Models;

namespace TaxiWebAPI.Controllers
{
    [RoutePrefix("data/drivers")]
    public class DriversController : BaseApiController
    {
        public DriversController(ITaxiDataRepository repository) : base(repository)
        {

        }

        [Route("", Name = "Drivers")]
        public IEnumerable<DriverModel> Get()
        {
            var query = Repository.GetAllDrivers();
            var result = query.Select(d => ModelFactory.Create(d));

            return result;

        }

        [Route("{driverid}", Name = "Driver")]
        public DriverModel Get(int driverid)
        {
            return ModelFactory.Create(Repository.GetDriver(driverid));
        }
    }
}
