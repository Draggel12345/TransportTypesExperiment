using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportTypeCreationTest.Entitys
{
    class Boat
    {
        private static int idCounter = 0;
        private int _boatId;
        private string _boatType;
        private string _boatModel;
        private string _boatColor;
        public int BoatId { get { return _boatId; } private set { _boatId = value; } }
        public string BoatType { get { return _boatType; } set { _boatType = value; } }
        public string BoatModel { get { return _boatModel; } set { _boatModel = value; } }
        public string BoatColor { get { return _boatColor; } set { _boatColor = value; } }
        public Boat(string type, string model, string color) => (BoatId, BoatType, BoatModel, BoatColor) = (++idCounter, type, model, color);
        public Boat(int id, string type, string model, string color) => (BoatId, BoatType, BoatModel, BoatColor) = (id, type, model, color);

        public override string ToString()
        {
            return $"Id: {BoatId}. Type: {BoatType}. Model: {BoatModel}. Color: {BoatColor}.";
        }
    }
}
