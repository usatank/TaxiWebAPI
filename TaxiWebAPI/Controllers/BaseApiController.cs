using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TaxiDataProvider;
using TaxiWebAPI.Models;

namespace TaxiWebAPI.Controllers
{
    public abstract class BaseApiController : ApiController
    {
        private ITaxiDataRepository _repository;
        private ModelFactory _modelFactory;

        protected ITaxiDataRepository Repository
        {
            get { return _repository; }
        }

        public BaseApiController(ITaxiDataRepository repo)
        {
            _repository = repo;
        }

        protected ModelFactory ModelFactory
        {
            get
            {
                if (_modelFactory == null)
                {
                    _modelFactory = new ModelFactory(this.Request, Repository);
                }
                return _modelFactory;
            }
        }
    }
}
