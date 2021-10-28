using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportTypeCreationTest.Data;
using TransportTypeCreationTest.Entitys;

namespace TransportTypeCreationTest.Service
{
    class CarServiceImpl : EntityFactory, ITransportService<Car>
    {
        private readonly ITransport<Car> carDao = new CarImpl();

        public Car FindById(int id)
        {
            Car toFind = carDao.FindById(id);
            if (toFind.Equals(null))
            {
                Console.WriteLine($"Car with ID {id} dosen't exist.");
            }
            return toFind;
        }

        public List<Car> FindAll()
        {
            List<Car> temp = carDao.FindAll();
            if (!temp.Any())
            {
                Console.WriteLine("The list of cars is empty.");
            }
            return temp;
        }

        public Car Create(Car car)
        {
            Car temp = CreateCar(car.CarId, car.CarType, car.CarModel, car.CarColor);
            return carDao.Save(temp);
        }

        public Car Update(Car car)
        {
            Car toUpdate = carDao.FindById(car.CarId);

            toUpdate.CarModel = car.CarModel;
            toUpdate.CarColor = car.CarColor;

            carDao.Save(toUpdate);
            return car;
        }

        public void Delete(int id)
        {
            Car toRemove = FindById(id);
            carDao.Remove(toRemove.CarId);
        }
    }
}
