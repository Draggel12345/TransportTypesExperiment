using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportTypeCreationTest.Entitys
{
    class Car
    {
        private static int idCounter = 0;
        private int _carId;
        private string _carModel;
        private string _carColor;
        public int CarId { get { return _carId; } set { _carId = value; } }
        public string CarModel { get { return _carModel; } set { _carModel = value; } }
        public string CarColor { get { return _carColor; } set { _carColor = value; } }

        public Car(string model, string color) => (CarId, CarModel, CarColor) = (++idCounter, model, color);

        public override string ToString()
        {
            return $"Id: {CarId}. Model: {CarModel}. Color: {CarColor}.";
        }
    }
}
