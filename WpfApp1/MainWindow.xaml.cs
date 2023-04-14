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
using System.IO;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        internal class Tanulo
        {
            public string Nev { get; set; }
            public string Osztaly { get; set;}
            public char Nem { get; set; }
            public double Atlag { get; set; }

            public Tanulo(string sor)
            {
                string[] resz = sor.Split(';');
                Nev = resz[0];
                Osztaly = resz[1];
                Nem = Convert.ToChar(resz[2]);
                Atlag = Convert.ToDouble(resz[3]);
            }
        }
    
             List<Tanulo> adatok;
        public MainWindow()
        {
            InitializeComponent();
            adatok=new List<Tanulo>();
            foreach (var item in File.ReadAllLines("d:\\Downloads\\WpfApp1\\bin\\naplo.txt", Encoding.UTF8))
            {
                adatok.Add(new Tanulo(item));
            }
            dgSzovegek.ItemsSource = adatok;
        }

        private void btn_letszam_click(object sender, RoutedEventArgs e)
        {
            int letszam = 0;
            string osztaly = txtMelyikOsztaly.Text;
            foreach (var item in adatok)
            {
                if (item.Osztaly == osztaly)
                {
                    letszam++;
                }
            }

            lbOsztalyLetszam.Content = letszam;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            double atlag = 0;

            foreach (var item in adatok)
            {
                atlag += Convert.ToInt16(item.Atlag);
            }

            lbAtlag.Content = atlag / adatok.Count();
        }

        private void btnKitunok_Click(object sender, RoutedEventArgs e)
        {
            List<string> lista = new List<string>();

            foreach (var item in adatok)
            {
                if (item.Atlag == 5)
                {
                    lista.Add(item.Nev);
                }
            }

            lsbKitunok.Items.Clear();
            lsbKitunok.ItemsSource = lista;
        }
    }
}
