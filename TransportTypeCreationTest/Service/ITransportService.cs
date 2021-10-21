using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportTypeCreationTest.Service
{
    interface ITransportService<T>
    {
        T FindById(int id);
        List<T> FindAll();
        T Create(string model, string color);
        T Update(T o);
        void Delete(int id);
    }
}
