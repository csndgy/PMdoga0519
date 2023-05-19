using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class Szeleromu
    {
        string helyszin;
        int egysegekSzama;
        int teljesitmeny;
        int kezdetiEv;
        public Szeleromu(string helyszin, int egysegekSzama, int teljesitmeny, int kezdetiEv)
        {
            Helyszin = helyszin;
            EgysegekSzama = egysegekSzama;
            Teljesitmeny = teljesitmeny;
            KezdetiEv = kezdetiEv;
        }
        public string Helyszin { get; set; }
        public int EgysegekSzama { get; set; }
        public int Teljesitmeny { get; set; }
        public int KezdetiEv { get; set; }

        public char EromuKateg()
        {
            if (Teljesitmeny >= 1000)
            {
                return 'A';
            }
            else if (Teljesitmeny > 500 && Teljesitmeny < 1000)
            {
                return 'B';
            }
            else
            {
                return 'C';
            }
        }


    }
}
    

