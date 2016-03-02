using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TaxiDataProvider;
using TaxiDataProvider.EntitiesLinq2Sql;

namespace TaxiWebAPI.Controllers
{
    [RoutePrefix("data/drivers")]
    public class DriversController : BaseApiController
    {
        public DriversController(ITaxiDataRepository repository) : base(repository)
        {

        }

        [Route("", Name = "Drivers")]
        public IEnumerable<Driver> Get()
        {
            return Repository.GetAllDrivers();
        }

        [Route("{driverid}", Name = "Driver")]
        public Driver Get(int driverid)
        {
            return Repository.GetDriver(driverid);
        }
    }
}
