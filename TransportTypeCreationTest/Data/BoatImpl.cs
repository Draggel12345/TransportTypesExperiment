using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportTypeCreationTest.Entitys;

namespace TransportTypeCreationTest.Data
{
    class BoatImpl : ITransport<Boat>
    {
        private readonly List<Boat> boats = new();
        List<Boat> ITransport<Boat>.FindAll()
        {
            return boats;
        }

        Boat ITransport<Boat>.FindById(int id)
        {
            foreach (Boat b in boats)
            {
                if (b.BoatId == id)
                {
                    return b;
                }
            }
            return null;
        }

        void ITransport<Boat>.Remove(int id)
        {
            for (int i = 0; i < boats.Count; i++)
            {
                if (boats[i].BoatId == id)
                {
                    boats.Remove(boats[i]);
                }
            }
        }

        Boat ITransport<Boat>.Save(Boat o)
        {
            if (o == null)
            {
                Console.WriteLine($"Could not save {o}");
            }
            if (!boats.Contains(o))
            {
                boats.Add(o);
            }
            return o;
        }
    }
}
