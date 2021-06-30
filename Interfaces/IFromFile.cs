using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaWPFrsomierg.Interfaces
{
    public interface IFromFile<T>
    {
        T FromXml(string filepath);
    }
}
