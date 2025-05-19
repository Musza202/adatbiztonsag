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
using System.Windows.Shapes;

namespace ugyfel
{
    /// <summary>
    /// Interaction logic for Regisztracio.xaml
    /// </summary>
    public partial class Regisztracio : Window
    {
        public Regisztracio()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string nev = felhasznalonev.Text;
            string pass = jelszo.Password;
            string passujra = jelszoujra.Password;
            string emailcim = email.Text;

            if(string.IsNullOrEmpty(nev) || string.IsNullOrEmpty(pass))
            {
                MessageBox.Show("Töltsön ki minden mezőt!", "Hiányzó adat!" ,MessageBoxButton.OK,MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrEmpty())
            {

            }
        }
    }
}
