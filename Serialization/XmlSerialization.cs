using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Collections.ObjectModel;

namespace PruebaWPF
{
    public static class XmlSerialization
    {
        public static void WriteToXmlFile<T>(string filePath, T ObjectToWrite, bool append = false) where T:new()
        {
            TextWriter wt = null;
            try
            {
                var serializer = new XmlSerializer(typeof(T));
                wt = new StreamWriter(filePath, append);
                serializer.Serialize(wt,ObjectToWrite);
            }
            finally
            {
                if (wt != null)
                    wt.Close();
            }
        }

        public static T ReadFromXmlFile<T>(string filePath, ObservableCollection<Empleado> empleado) where T : new()
        {
            TextReader rd = null;
            try
            {
                var serializer = new XmlSerializer(typeof(T));
                rd = new StreamReader(filePath);
                return (T)serializer.Deserialize(rd);
            }
            finally
            {
                if (rd != null)
                    rd.Close();
            }
        }

    }
}
