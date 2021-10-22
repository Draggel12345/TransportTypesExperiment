using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportTypeCreationTest.Data;
using TransportTypeCreationTest.Entitys;

namespace TransportTypeCreationTest.Service
{
    class CarServiceImpl : ITransportService<Car>
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

        public Car Create(string model, string color)
        {
            Car tmp = new(model, color);
            return carDao.Save(tmp);
        }

        public Car Update(Car o)
        {
            Car toUpdate = carDao.FindById(o.CarId);
            toUpdate.CarModel = o.CarModel;
            toUpdate.CarColor = o.CarColor;

            carDao.Save(toUpdate);
            return o;
        }

        public void Delete(int id)
        {
            Car toRemove = FindById(id);
            carDao.Remove(toRemove.CarId);
        }
    }
}
