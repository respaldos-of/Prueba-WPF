using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace PruebaWPF
{
    public class Empleado
    {
        public string Codigo { get; set; }
        public string Correo { get; set; }
        public string Nombre { get; set; }
        

        public Empleado(string codigo, string nombre, string correo)
        {
            Correo = correo;
            Nombre = nombre;
            Codigo = codigo;
        }

        public Empleado()
        {
        }


        public ObservableCollection<Empleado> FromXml(string filepath)
        {
            ObservableCollection<Empleado> empleado = new ObservableCollection<Empleado>();
            return XmlSerialization.ReadFromXmlFile<ObservableCollection<Empleado>>(filepath, empleado) ;

        }
        public void ToXml(string filepath, ObservableCollection<Empleado> lstEmpleados)
        {
            XmlSerialization.WriteToXmlFile(filepath,lstEmpleados);
        }
    }
}
