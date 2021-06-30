using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PruebaWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        EmpleadoController ec;
        static ObservableCollection<Empleado> empleados = new ObservableCollection<Empleado> ();
        public MainWindow()
        {
            InitializeComponent();
            TablaDatos.ItemsSource = empleados;
            PopulaLista();
            SetController();
        }


        public ObservableCollection<Empleado> getData()
        {
            return empleados;   
        }

        protected void SetController()
        {
            ec = new EmpleadoController(this);
            this.BtnGuardar.Click += new RoutedEventHandler(ec.EmpleadoEventHandler);
            this.BtnAñadir.Click += new RoutedEventHandler(ec.EmpleadoEventHandler);
            this.BtnAbrir.Click += new RoutedEventHandler(ec.EmpleadoEventHandler);

        }

        public void addData()
        {
            if (verifyCodeEmail())
            {
            empleados.Add(new Empleado(BoxCodigo.Text, BoxUsername.Text, BoxEmail.Text));

            }
            else
            {
                MessageBox.Show("El código y el correo no deben repetirse");
            }
        }

        internal void SetData(ObservableCollection<Empleado> lists)
        {
            empleados = null;
            empleados = lists;
            TablaDatos.ItemsSource = null;
            TablaDatos.ItemsSource = empleados;
        }

        public void PopulaLista()
        {
           /* empleados.Add(new Empleado("1456-2712D","Humberto Hernandez","hhernandez@yahoo.com"));
            empleados.Add(new Empleado("0124-1011A","Ruth Jarquin","rjarquin@gmail.com"));
            empleados.Add(new Empleado("2255-4780S","Marcos Bermudez","mbermudez12@outlook.com"));*/
        }



        private bool verifyCodeEmail()
        {
            bool flag = true;
            if (empleados.Count > 0)
            {
                for (int i = 0; i < empleados.Count; i++)
                {


                    if (empleados[i].Codigo.Equals(BoxCodigo.Text) || empleados[i].Correo.Equals(BoxEmail.Text))
                    {
                        flag = false;
                        break;
                    }
                    else
                    {
                        flag = true;
                    }
                }
            }
            return flag;
        }
    }
}
