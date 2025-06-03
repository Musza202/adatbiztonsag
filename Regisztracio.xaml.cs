using Org.BouncyCastle.Bcpg.Sig;
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
            if (pass!=passujra)
            {
                MessageBox.Show("Nem eggyezik a két jelszó!", "Eltérő adat!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!emailcim.Contains("@") || !emailcim.Contains("."))
            {
                MessageBox.Show("Az emailcím nem megfelelő!", "Hibás adat!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                using (var con = new MySql.Data.MySqlClient.MySqlConnection(App.ConnString))
                {
                    con.Open();
                    string sql = "SELECT count(*) from felhasznalo where felhasznalo=@fnev or email=@emil";
                    var check = new MySql.Data.MySqlClient.MySqlCommand(sql, con);
                    check.Parameters.AddWithValue("@fnev", nev);
                    check.Parameters.AddWithValue("@emil", emailcim);
                    int count = Convert.ToInt32(check.ExecuteScalar());
                    if (count > 0)
                    {
                        MessageBox.Show("Van ilyen felhasználó név", "Létező adat!", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    sql = "INSERT INTO felhasznalo (felhasznalo, jelszo, email) VALUES (@fnev, @jelszo, @emil)";
                    MessageBox.Show("Sikeres regisztráció!", "Sikeres adatbevitel!", MessageBoxButton.OK, MessageBoxImage.Information);


                }
                    
            }
            catch(Exception ex)
            {
                MessageBox.Show("Hiba az adatbázis frissítése során:\n" + ex.Message, "Adatbázis hiba!",MessageBoxButton.OK,MessageBoxImage.Error);
            }

        }
    }
}
