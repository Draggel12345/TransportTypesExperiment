using System;
using static System.Console;
using System.Collections.Generic;
using TransportTypeCreationTest.Data;
using TransportTypeCreationTest.Entitys;
using TransportTypeCreationTest.Service;

namespace TransportTypeCreationTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Run();
        }

        public static void Run()
        {
            CarServiceImpl service = new();

            Car one = service.Create("Fiat", "Red");
            Car two = service.Create("Opel", "Yellow");
            Car three = service.Create("Saab", "Green");

            WriteLine("\tTesting findAll:");
            List<Car> toPrint = service.FindAll();
            
            foreach (Car c in toPrint)
            {
                WriteLine($"- {c}");
            }

            WriteLine($"\n\tTesting FindById: \n- {service.FindById(two.CarId)}");

            Car oneUpdated = new("Fiat", "Blue");
            oneUpdated.CarId = one.CarId;

            WriteLine("\n\tTesting Update&Delete:");
            service.Update(oneUpdated);
            service.Delete(three.CarId);

            foreach (Car c in toPrint)
            {
                WriteLine($"- {c}");
            }

            ReadKey();
        }
    }
}
