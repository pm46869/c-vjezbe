using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vjezba1
{
    class Program
    { 
        static string toHex(double nekiDouble)
        {
            string str= nekiDouble.ToString();
            Console.WriteLine(str);
            string hexa;
            if (str.Contains(',') == true) {
                string[] parts = str.Split(',');
                int prvi = int.Parse(parts[0]);
                int drugi = int.Parse(parts[1]);
                string h1 = prvi.ToString("X");
                string h2 = drugi.ToString("X");
                hexa = h1 + ',' + h2;
            }
            else
            {
                int prvi = int.Parse(str);
                hexa = prvi.ToString("X1");
            }
            return hexa;
           
        }
        static void zad1()
        {
            string a = Console.ReadLine();
            string b = Console.ReadLine();
            double aDub = double.Parse(a);
            double bDub = double.Parse(b);
            double rez = aDub / bDub;
            string rezCur = rez.ToString("C");
            int rezInt = (int)rez;
            string rezSci = rez.ToString("E");
            string rezFix = rez.ToString("F3");
            string rezGen = rez.ToString("G");
            string rezNum = rez.ToString("N");
            string rezHex = toHex(rez);

            Console.WriteLine("Rezultat u Currency: " + rezCur);
            Console.WriteLine("Rezultat u Integer: " + rezInt);
            Console.WriteLine("Rezultat u Scientific: " + rezSci);
            Console.WriteLine("Rezultat u Fixed-point: " + rezFix);
            Console.WriteLine("Rezultat u General: " + rezGen);
            Console.WriteLine("Rezultat u Number: " + rezNum);
            Console.WriteLine("Rezultat u Hexadecimal: " + rezHex);

            System.Threading.Thread.Sleep(50000);
        }
        static void zad2()
        {
            int a = 5;
            long b = 9223372036854775807;

            try
            {
                checked
                {
                    Console.WriteLine(a + b);
                }
            }
            catch (OverflowException e)
            {
                Console.WriteLine(e.Message); 
            }


            System.Threading.Thread.Sleep(50000);

        }
        enum Vrsta
        {
            Stednja,
            Tekuci,
            Ziro
        }
        struct BankAccount
        {
            public string brojRacuna;
            public double iznos;
            public Vrsta vrstaRacuna;
        }
        static void zad3()
        {
            List<BankAccount> Akaunti = new List<BankAccount>();
            while (true)
            {
                Console.WriteLine("Upisi 1 za dodat novi acc, bilo šta drugo za ispisati sve accove");
                int izbor = Int32.Parse(Console.ReadLine());
                if (izbor == 1)
                {
                    Vrsta vrsta;

                    Console.WriteLine("Upisati broj računa");
                    string broj = Console.ReadLine();

                    Console.WriteLine("Upisati iznos");
                    double iznos = double.Parse(Console.ReadLine());

                    Console.WriteLine("Upisi 1 Stedni racun, 2 za Tekuci, i bilo sta drugo za Ziro");
                    int izborVrste = int.Parse(Console.ReadLine());
                    if (izborVrste == 1) { vrsta = Vrsta.Stednja; }
                    else if (izborVrste == 2) { vrsta = Vrsta.Tekuci; }
                    else { vrsta = Vrsta.Ziro; }

                    BankAccount account = new BankAccount { brojRacuna = broj, iznos = iznos, vrstaRacuna = vrsta };
                    Akaunti.Add(account);

                }
                else
                {
                    foreach (BankAccount b in Akaunti)
                    {
                        Console.WriteLine("Broj računa: " + b.brojRacuna);
                        Console.WriteLine("Iznos: " + b.iznos);
                        Console.WriteLine("Vrsta računa: " + b.vrstaRacuna.ToString());
                    }
                    Console.WriteLine("Pritisnite Enter za izlaz");
                    Console.ReadLine();
                }
            }
        }
        static void Main(string[] args)
        {
            //zad1();
            //zad2();
            zad3();
        }
    }
}
