using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDAL : ICarDal
    {
        List<Car> _carList;

        public InMemoryProductDAL()
        {
            _carList = new List<Car> { 
            new Car{Id=1, BrandId=1, ColorId=1, ModelYear="2018", DailyPrice=125000, Description="SUV"},
            new Car{Id=2, BrandId=1, ColorId=2, ModelYear="2020", DailyPrice=225000, Description="Sedan"},
            new Car{Id=3, BrandId=2, ColorId=2, ModelYear="2016", DailyPrice=85000, Description="Hatchback"},
            new Car{Id=4, BrandId=2, ColorId=1, ModelYear="2015", DailyPrice=65000, Description="Klasik Araba"},
            new Car{Id=5, BrandId=3, ColorId=3, ModelYear="2021", DailyPrice=225000, Description="CrossCountry"}
            };
        }

        public List<Car> GetAll()
        {
            return _carList;
        }        
        
        public void Add(Car car)
        {
            _carList.Add(car);
        }

        public List<Car> GetById(int id)
        {
            return _carList.Where(c => c.BrandId == id).ToList();

            //List<Car> tmpCarList = null;
            //foreach (var car in _carList)
            //{
            //    if (car.Id == id)
            //    {
            //        tmpCarList.Add(car);
            //    }
            //}
            //return tmpCarList;

        }

        public void Delete(Car car)
        {
            Car carToDelete = _carList.SingleOrDefault(c => c.Id == car.Id);

            _carList.Remove(carToDelete);
        }

        public void Update(Car car)
        {
            Car carToUpdate = _carList.SingleOrDefault(c => car.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;
        }
    }
}
