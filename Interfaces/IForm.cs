using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaWPFrsomierg.Interfaces
{
    public interface IForm<T>
    {
        void SetData(T data);
        T SetData();
    }
}
