using System;
using System.Collections.Generic;
using System.IO;
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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Szeleromu> szeleromuvek = new List<Szeleromu>();
        public MainWindow()
        {
            InitializeComponent();
            SiratosKiiratos();
        }
        string[] adatok = File.ReadAllLines("szeleromu.txt");
        private void SiratosKiiratos()
        {
            string[] sorok = File.ReadAllLines("szeleromu.txt");
            foreach (string sor in sorok)
            {
                string[] adatok = sor.Split(';');
                string helyszin = adatok[0];
                int egységekSzama = int.Parse(adatok[1]);
                int teljesitmeny = int.Parse(adatok[2]);
                int kezdetiEv = int.Parse(adatok[3]);

                Szeleromu szeleromu = new Szeleromu(helyszin, egységekSzama, teljesitmeny, kezdetiEv);
                szeleromuvek.Add(szeleromu);
            }
            dgHihetetlen.ItemsSource = szeleromuvek;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int osszeszamolas = szeleromuvek.Count();
            MessageBox.Show($"Összesen {osszeszamolas} szélerőmű adat található az állományban.");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Végül sikerült simán beolvasva de túl jól nézett ki így a felület hogy kiszedjem :))");
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string telepules = tbHelyszin.Text;
            var szeltel = szeleromuvek.Where(x => x.Helyszin == telepules).ToList();
            int ossz = szeltel.Count();
            lbMiujsag.ItemsSource = szeltel.Select(x => new { Teljesitmeny = x.Teljesitmeny, EgysegekSzama = x.EgysegekSzama }).ToList();
            lbAdatok.Content = $"Összesen {ossz} szélerőmű van a listában.";

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            double atlag2010 = szeleromuvek.Where(x => x.KezdetiEv == 2010).Average(x => x.Teljesitmeny);
            MessageBox.Show($"2010 átlagos teljesítménye: {Math.Round(atlag2010, 2)} W");

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            var legnagyobbtelj = szeleromuvek.OrderByDescending(x => x.Teljesitmeny).FirstOrDefault();
            MessageBox.Show($"Legnagyobb teljesítményű erőmű: {legnagyobbtelj.Helyszin}, {legnagyobbtelj.Teljesitmeny} W, {legnagyobbtelj.KezdetiEv}");
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            var jelentesesdi = szeleromuvek.Select(s => $"{s.Helyszin},{s.EgysegekSzama},{s.Teljesitmeny},{s.EromuKateg()}");
            File.WriteAllLines("jelentes.txt", jelentesesdi);
            MessageBox.Show("Elkészülődött minden végre: D:D:D:DD:D:D:D.");
        }
    }
}
