using System;
using static System.Console;
using System.Collections.Generic;
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

            //Creating objects for testing service-methods.
            Car carOne = new("Car", "Fiat", "Red");
            Car carTwo = new("Car", "Opel", "Yellow");
            Car carThree = new("Car", "Saab", "Green");

            Boat boatOne = new("Boat", "Unknown", "White");
            Boat boatTwo = new("Boat", "Unknown", "Pink");
            Boat boatThree = new("Boat", "Unknown", "White-Orange");

            carService.Create(carOne);
            carService.Create(carTwo);
            carService.Create(carThree);

            boatService.Create(boatOne);
            boatService.Create(boatTwo);
            boatService.Create(boatThree);

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

            //Testing FindById
            WriteLine($"\n\tTesting Car FindById: \n- {carService.FindById(carTwo.CarId)}");
            WriteLine($"\n\tTesting Boat FindById: \n- {boatService.FindById(boatThree.BoatId)}");

            //Create two new objects and assigning each with carOne/boatOne-ID and changing the car color from red to blue & boat color from white to orange.
            Car updatedCar = new(carOne.CarId,"Car", "Fiat", "Blue");

            Boat updatedBoat = new(boatOne.BoatId,"Boat", "Unknown", "Orange");

            WriteLine("\n\tTesting Update & Delete:");
            carService.Update(updatedCar);
            carService.Delete(carThree.CarId);
            boatService.Update(updatedBoat);
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
