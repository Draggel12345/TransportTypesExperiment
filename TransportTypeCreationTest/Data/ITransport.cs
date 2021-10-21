using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportTypeCreationTest.Data
{
    interface ITransport<T>
    {
        T Save(T o);
        void Remove(int id);
        T FindById(int id);
        List<T> FindAll();
    }
}
