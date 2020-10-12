using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBA_Project1.ViewModel
{
    public interface IViewModel<T>
        where T : class, new()
    {
        void SaveNew(string newName);
        void Update(string newName);
        void GetData();
        void Get(T obj);

    }
}
