using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportTypeCreationTest.Data;
using TransportTypeCreationTest.Entitys;

namespace TransportTypeCreationTest.Service
{
    class BoatServiceImpl : EntityFactory, ITransportService<Boat>
    {
        private readonly ITransport<Boat> boatDao = new BoatImpl();

        public Boat Create(Boat boat)
        {
            Boat temp = CreateBoat(boat.BoatId, boat.BoatType, boat.BoatModel, boat.BoatColor);
            return boatDao.Save(temp);
        }

        public void Delete(int id)
        {
            Boat toRemove = boatDao.FindById(id);
            boatDao.Remove(toRemove.BoatId);
        }

        public List<Boat> FindAll()
        {
            List<Boat> temp = boatDao.FindAll();
            if (!temp.Any())
            {
                Console.WriteLine("The list of boats is empty.");
            }
            return temp;
        }

        public Boat FindById(int id)
        {
            Boat toFind = boatDao.FindById(id);
            if (toFind.Equals(null))
            {
                Console.WriteLine($"Boat with ID {id} dosen't exist.");
            }
            return toFind;
        }

        public Boat Update(Boat boat)
        {
            Boat toUpdate = boatDao.FindById(boat.BoatId);
            toUpdate.BoatModel = boat.BoatModel;
            toUpdate.BoatColor = boat.BoatColor;

            boatDao.Save(toUpdate);
            return boat;
        }
    }
}
