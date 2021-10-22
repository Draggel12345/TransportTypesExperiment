using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportTypeCreationTest.Data;
using TransportTypeCreationTest.Entitys;

namespace TransportTypeCreationTest.Service
{
    class BoatServiceImpl : ITransportService<Boat>
    {
        private readonly ITransport<Boat> boatDao = new BoatImpl();
        public Boat Create(string type, string model, string color)
        {
            Boat temp = new(type, model, color);
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

        public Boat Update(Boat o)
        {
            Boat toUpdate = boatDao.FindById(o.BoatId);
            toUpdate.BoatModel = o.BoatModel;
            toUpdate.BoatColor = o.BoatColor;

            boatDao.Save(toUpdate);
            return o;
        }
    }
}
