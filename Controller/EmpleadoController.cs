using Microsoft.Win32;
using PruebaWPF;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace PruebaWPF
{
    public class EmpleadoController
    {
        MainWindow empleadoWindow1;
        SaveFileDialog saveFileDialog;
        OpenFileDialog openFileDialog;
        private MainWindow empleadoWindow;

       /* public EmpleadoController(MainWindow window)
        {
            empleadoWindow1 = window;
            saveFileDialog = new SaveFileDialog();
            openFileDialog = new OpenFileDialog();
        }*/

        public EmpleadoController(MainWindow Window)
        {
            this.empleadoWindow =Window;
        }

        public void EmpleadoEventHandler(object sender, RoutedEventArgs e)
        {
            Button B = (Button)sender;
           
            switch (B.Name)
            {
                case "BtnGuardar":
                    try
                    {
                        SaveData();
                   
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("Error: " + ex.ToString());
                    }
                    break;
                case "BtnAbrir":
               
                    try
                    {
                        OpenFile();

                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("Error: " + ex.ToString());
                    }
                    break;
                case "BtnAñadir":

                    try
                    {
                        addData();
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("Error: " + ex.ToString());
                    }
                    break;
            }
        }

        private void addData()
        {
            empleadoWindow.addData();
        }

        private void OpenFile()
        {
            openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Xml File (*.xml)|*.xml";
            if (openFileDialog.ShowDialog() == true)
            {
                Empleado b = new Empleado();
               empleadoWindow.SetData(b.FromXml(openFileDialog.FileName));
            }
        }

        private void SaveData()
        {
            saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Xml File (*.xml)|*.xml";
            if (saveFileDialog.ShowDialog() == true)
            {
                Empleado empleado = new Empleado();
                ObservableCollection<Empleado> lstEmpleado = empleadoWindow.getData();
                empleado.ToXml(saveFileDialog.FileName,lstEmpleado);
            }
        }

       
    }
}
