using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TaxiDataProvider;

namespace TaxiWebAPI.Controllers
{
    public abstract class BaseApiController : ApiController
    {
        private ITaxiDataRepository _repository;


    }
}
