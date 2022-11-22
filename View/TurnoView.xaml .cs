


using System;
using System.Collections.Generic;
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
using Veterinaria.Model;

namespace Veterinaria.View
{
    /// <summary>
    /// Lógica de interacción para CustomerView.xaml
    /// </summary>
    public partial class TurnoView : UserControl
    {
        public static Frame StaticMainFrame;
      

        public TurnoView()
        {
            InitializeComponent();
            Refresh();
         
        }
              

            // carga de datos
        private void Refresh()
        {

            List<PersonViewModel> lst = new List<PersonViewModel>();
            using (Model.wpfcrudEntities3 db1 = new Model.wpfcrudEntities3())
            {
                lst = (from d in db.turno
                       select new PersonViewModel
                       {
                           Id = d.id,
                          Cliente = d.cliente,
                           Fecha = d.fecha,
                           Servicio = d.servicio,
                           


                       }).ToList();


            }

            DG.ItemsSource = lst;
        }

        // inicio botones eliminar 
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int Id = (int)((Button)sender).CommandParameter;

            using (Model.wpfcrudEntities3 db1 = new Model.wpfcrudEntities3())
            {
                var oPerson = db.turno.Find(Id);

                db.turno.Remove(oPerson);
                db.SaveChanges();
            }

            Refresh();
        }

        private void Button_Editar(object sender, RoutedEventArgs e)
        {

           // int Id = (int)((Button)sender).CommandParameter;

          //  Formulario pFormulario = new Formulario(Id);

          //  MainWindow.StaticMainFrame.Content = pFormulario;

            // MainWindow.StaticMainFrame.Content = pFormulario;
            // Command="{Binding  ShowSettingsViewCommand}"
        }
        //fin

    }

    public class PersonViewModel
    {
        public int Id { get; set; }
        public string Cliente { get; set; }
        public string Fecha { get; set; }
        
        public string Servicio{ get; set; }
        
       
    }
}

