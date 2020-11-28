using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace kutyak
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader NevOlvas = new StreamReader("KutyaNevek.csv", Encoding.Default);
            string NevFejlec = NevOlvas.ReadLine();
            List<Nev> KutyaNevek = new List<Nev>();
            while (!NevOlvas.EndOfStream)
            {
                string Sor = NevOlvas.ReadLine();
                string[] SorElemek = Sor.Split(';');
                KutyaNevek.Add(new Nev(Convert.ToInt32(SorElemek[0]), SorElemek[1]));
            }
            NevOlvas.Close();

            Console.WriteLine("3. feladat: Kutyaneve száma: " + KutyaNevek.Count);

            StreamReader FajtaOlvas = new StreamReader("KutyaFajtak.csv", Encoding.Default);
            string FajtaFejlec = FajtaOlvas.ReadLine();
            List<Fajta> KutyaFajtak = new List<Fajta>();
            while (!FajtaOlvas.EndOfStream)
            {
                string Sor = FajtaOlvas.ReadLine();
                string[] SorElemek = Sor.Split(';');
                KutyaFajtak.Add(new Fajta(Convert.ToInt32(SorElemek[0]), SorElemek[1], SorElemek[2]));
            }
            FajtaOlvas.Close();

            StreamReader KutyaOlvas = new StreamReader("Kutyak.csv", Encoding.Default);
            string KutyaFejlec = KutyaOlvas.ReadLine();
            List<Kutya> Kutyak = new List<Kutya>();
            while (!KutyaOlvas.EndOfStream)
            {
                string Sor = KutyaOlvas.ReadLine();
                string[] SorElemek = Sor.Split(';');
                Kutyak.Add(new Kutya(Convert.ToInt32(SorElemek[0]), Convert.ToInt32(SorElemek[1]), Convert.ToInt32(SorElemek[2]), Convert.ToInt32(SorElemek[3]), SorElemek[4]));
            }
            KutyaOlvas.Close();

            double OsszEletkor = 0;
            for (int i = 0; i < Kutyak.Count; i++)
            {
                OsszEletkor += Kutyak[i].Eletkor;
            }
            Console.WriteLine($"6. feladat: Kutyák átlag életkora: {Math.Round(OsszEletkor / Kutyak.Count, 2)}");
        }
             class Nev
        {
            public int Azonosito;
            public string KutyaNev;
            public Nev(int Azonosito, string KutyaNev)
            {
                this.Azonosito = Azonosito;
                this.KutyaNev = KutyaNev;
            }
        }
        class Fajta
        {
            public int Azonosito;
            public string Nev;
            public string EredetiNev;
            public Fajta(int Azonosito, string Nev, string EredetiNev)
            {
                this.Azonosito = Azonosito;
                this.Nev = Nev;
                this.EredetiNev = EredetiNev;
            }
        }
        class Kutya
        {
            public int Azonosito;
            public int FajtaID;
            public int NevID;
            public int Eletkor;
            public string Vizsgalat;
            public Kutya(int Azonosito, int FajtaID, int NevID, int Eletkor, string Vizsgalat)
            {
                this.Azonosito = Azonosito;
                this.FajtaID = FajtaID;
                this.NevID = NevID;
                this.Eletkor = Eletkor;
                this.Vizsgalat = Vizsgalat;
            }
        }
    }
}
