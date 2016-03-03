using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaxiDataProvider;
using System.Net.Http;
using TaxiDataProvider.EntitiesLinq2Sql;

namespace TaxiWebAPI.Models
{
    public class ModelFactory
    {
        private ITaxiDataRepository _repository;

        public ModelFactory(HttpRequestMessage request, ITaxiDataRepository repository)
        {
            _repository = repository;

        }

        public CarModel Create(Car car)
        {
            if (car == null)
                return null;

            return new CarModel(car);

        }

        public DriverModel Create(Driver driver)
        {
            if (driver == null)
                return null;

            return new DriverModel(driver);
        }

        public OrderModel Create(Order order)
        {
            if (order == null)
                return null;

            return new OrderModel(order);

        }

        public PassengerModel Create(Passenger passenger)
        {
            if (passenger == null)
                return null;

            return new PassengerModel(passenger);
        }

        public DriverInCarModel Create (DriverInCar dIC)
        {
            if (dIC == null)
                return null;

            return new DriverInCarModel(dIC);
        }
    }
}