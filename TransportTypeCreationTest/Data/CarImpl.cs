using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportTypeCreationTest.Entitys;

namespace TransportTypeCreationTest.Data
{
    class CarImpl : ITransport<Car>
    {
        private readonly List<Car> cars = new();
        Car ITransport<Car>.Save(Car o)
        {
            if (o == null)
            {
                Console.WriteLine($"Could not save {o}.");
            }
            if (!cars.Contains(o))
            {
                cars.Add(o);
            }
            return o;
        }
        void ITransport<Car>.Remove(int id)
        {
            for (int i = 0; i < cars.Count; i++)
            {
                if (cars[i].CarId == id)
                {
                    cars.Remove(cars[i]);
                }
            }
        }

        Car ITransport<Car>.FindById(int id)
        {
            foreach (Car c in cars)
            {
                if (c.CarId.Equals(id))
                {
                    return c;
                }
            }
            return null;
        }

        List<Car> ITransport<Car>.FindAll()
        {
            return cars;
        }
    }
}
