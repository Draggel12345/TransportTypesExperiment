using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportTypeCreationTest.Entitys
{
    abstract class EntityFactory
    {
        protected static Car CreateCar(int id, string type, string model, string color) => new(id, type, model, color);

        protected static Boat CreateBoat(int id, string type, string model, string color) => new(id, type, model, color);
    }
}
