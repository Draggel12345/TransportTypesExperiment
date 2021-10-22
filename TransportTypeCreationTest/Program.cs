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
            CarServiceImpl carService = new();
            BoatServiceImpl boatService = new();

            //Creating object one, two, three for testing service-methods.
            Car carOne = carService.Create("Car", "Fiat", "Red");
            Car carTwo = carService.Create("Car", "Opel", "Yellow");
            Car carThree = carService.Create("Car", "Saab", "Green");

            Boat boatOne = boatService.Create("Boat", "Unknown", "White");
            Boat boatTwo = boatService.Create("Boat", "Unknown", "Pink");
            Boat boatThree = boatService.Create("Boat", "Unknown", "White-Orange");

            //Adding new object directly from service.
            carService.Create("Car", "Volvo", "Black");
            boatService.Create("Boat", "Unknown", "Black-Red");


            WriteLine("\tTesting findAll:");
            List<Car> toPrintCars = carService.FindAll();

            foreach (Car c in toPrintCars)
            {
                WriteLine($"- {c}");
            }

            WriteLine("");

            List<Boat> toPrintBoats = boatService.FindAll();

            foreach (Boat b in toPrintBoats)
            {
                WriteLine($"- {b}");
            }

            WriteLine($"\n\tTesting Car FindById: \n- {carService.FindById(carTwo.CarId)}");
            WriteLine($"\n\tTesting Boat FindById: \n- {boatService.FindById(boatThree.BoatId)}");

            //Create two new objects and assigning each with carOne/boatOne-ID and changing the car color from red to blue & boat color from white to orange.
            Car carOneUpdated = new("Car", "Fiat", "Blue");
            carOneUpdated.CarId = carOne.CarId;

            Boat boatOneUpdated = new("Boat", "Unknown", "Orange");
            boatOneUpdated.BoatId = boatOne.BoatId;

            WriteLine("\n\tTesting Update & Delete:");
            carService.Update(carOneUpdated);
            carService.Delete(carThree.CarId);
            boatService.Update(boatOneUpdated);
            boatService.Delete(boatTwo.BoatId);

            foreach (Car c in toPrintCars)
            {
                WriteLine($"- {c}");
            }

            WriteLine("");

            foreach (Boat b in toPrintBoats)
            {
                WriteLine($"- {b}");
            }

            ReadKey();
        }
    }
}
