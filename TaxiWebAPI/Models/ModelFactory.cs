using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaxiDataProvider;
using System.Net.Http;
using TaxiDataProvider.EntitiesAdoNet;

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
            return new CarModel()
            {
                Brand = car.Brand,
                Model = car.Model,
                Number = car.Number
            
            };
        }

        public DriverModel Create(Driver driver)
        {
            return new DriverModel()
            {
                FirstName = driver.FirstName,
                HomeAddress = driver.HomeAddress,
                LastName = driver.LastName,
                PhoneNumber = driver.PhoneNumber
            
            };
        }

        public OrderModel Create(Order order)
        {
            return new OrderModel()
            {
                Address = order.Address,
                DateAndTime = order.DateAndTime,
                Location = order.Location,
                Passenger = Create(order.Passenger)
            };

        }

        public PassengerModel Create(Passenger passenger)
        {
            return new PassengerModel()
            {
                Name = passenger.Name,
                PhoneNumber = passenger.PhoneNumber
            };
        }
    }
}