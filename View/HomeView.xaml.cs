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
    /// Lógica de interacción para HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
        //
        public static Frame StaticMainFrame;
      //  private Frame MainFrame;

       

        public HomeView()
        {
            InitializeComponent();
          //  StaticMainFrame = MainFrame;
            
             Refresh();
         
        }
              

            // carga de datos
        private void Refresh()
        {

            List<PersonViewModel1> lst = new List<PersonViewModel1>();
            using (Model.wpfcrudEntities3 db1 = new Model.wpfcrudEntities3())
            {
                lst = (from d in db1.turno
                       select new PersonViewModel1
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
                var oPerson = db1.turno.Find(Id);

                db1.turno.Remove(oPerson);
                db1.SaveChanges();
            }

            Refresh();
        }

        }
    //
     public class PersonViewModel1
    {
        public int Id { get; set; }
        public string Cliente { get; set; }
        public string Fecha { get; set; }
        
        public string Servicio{ get; set; }
        
       
    }

    //
    }

