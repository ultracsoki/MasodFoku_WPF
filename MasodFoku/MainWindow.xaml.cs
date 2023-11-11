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

namespace MasodFoku
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static double A = 0;
        static double B = 0;
        static double C = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void buttonSzamol_Click(object sender, RoutedEventArgs e)
        {
            double diszkriminans = 0;
            try
            {
                if (tbA.Text == "" || tbB.Text == "" || tbC.Text == "")
                {
                    MessageBox.Show("Minden mező kitöltése kötelező!");
                    throw new Exception();
                }
                try
                {
                    Convert.ToInt32(tbA.Text);
                    Convert.ToInt32(tbB.Text);
                    Convert.ToInt32(tbC.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Csak számot adhat meg!");
                }
                A = Convert.ToInt32(tbA.Text);
                B = Convert.ToInt32(tbB.Text);
                C = Convert.ToInt32(tbC.Text);
                diszkriminans = (Math.Pow(B, 2) - 4 * A * C);
                if (diszkriminans < 0)
                {
                    MessageBox.Show("Nem oldható meg a valós számok halmazán");
                    throw new Exception();
                }
            }
            catch (Exception)
            {
                tbA.Text = "";
                tbB.Text = "";
                tbC.Text = "";
            }
            if (diszkriminans == 0)
            {
                double eredmeny = (-B) / A ;
                labelEredmeny1.Content = "x1 = x2 = " + Math.Round(eredmeny,2);
                labelEredmeny2.Content = "";
            }
            else
            {
                double eredmeny1 = ((-B) + Math.Sqrt(diszkriminans)) / A;
                double eredmeny2 = ((-B) - Math.Sqrt(diszkriminans)) / A;
                labelEredmeny1.Content = "x1 = " + eredmeny1;
                labelEredmeny2.Content = "x2 = " + eredmeny2;
            }
        }
    }
}
