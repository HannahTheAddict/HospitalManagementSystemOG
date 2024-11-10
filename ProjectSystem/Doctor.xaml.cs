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

namespace ProjectSystem
{
    /// <summary>
    /// Interaction logic for Doctor.xaml
    /// </summary>
    public partial class Doctor : Page
    {
        Hospital_2Entities he2 = new Hospital_2Entities();

        public Doctor()
        {
            InitializeComponent();
            DGlist.ItemsSource = he2.Doctors.ToList();

        }



        private void Add_Button(object sender, RoutedEventArgs e)
        {
            Doctor doctor = new Doctor();
            //doctor.doctor_id =int.Parse(ID_txt.Text);
            doctor.names = N_txt.Text;
            doctor.specialty = SP_txt.Text;
            doctor.available_time = DateTime.Parse(Avb_txt.Text);
            doctor.Number = CON_txt.Text;
            he2.Doctors.Add(doctor);
            he2.SaveChanges();
        }

        private void update_Button(object sender, RoutedEventArgs e)
        {
            Doctor doc = new Doctor();
            int id = int.Parse(ID_txt.Text);
            doc = he2.Doctors.First(x => x.doctor_id == id);
            doc.names = N_txt.Text;
            doc.specialty = SP_txt.Text;
            doc.Number = CON_txt.Text;
            doc.available_time = DateTime.Parse(Avb_txt.Text);
            he2.Doctors.AddOrUpdate(doc);
            he2.SaveChanges();
        }

        private void Refersh_Button(object sender, RoutedEventArgs e)
        {
            DGlist.ItemsSource = he2.Doctors.ToList();

        }

        private void Delete_Button(object sender, RoutedEventArgs e)
        {
            Doctor doct = new Doctor();
            int ID = int.Parse(ID_txt.Text);
            doct = he2.Doctors.Remove(he2.Doctors.First(x => x.doctor_id == ID));
            he2.SaveChanges();
        }
    }
}
