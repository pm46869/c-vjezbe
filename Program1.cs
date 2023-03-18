using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Vjezba1
{
    class Program
    {
        static bool digitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }


        enum Spol
        {
            Musko,
            Zensko
        }
        struct Pacijent
        {
            public string OIB;
            public string MBO;
            public string Ime;
            public DateTime DatumRod;
            public Spol spol;
            public string dijagnoza;
        }
        static void zadatak()
        {
            List<Pacijent> Pacijenti = new List<Pacijent>();
            while (true)
            {
                Spol spol;
                Console.WriteLine("Upisi 1 za dodat novog pacijenti, 2 za izmjenu postojeceg pacijenta i bilo sta drugo za ispis svih pacijenata");
                string izbor = Console.ReadLine();
                if (izbor == "1")
                {
                    Console.WriteLine("Upisati OIB pacijenta:");
                    string oib = Console.ReadLine();
                    while (oib.Length != 11 || digitsOnly(oib) == false)
                    {
                        Console.WriteLine("Neisparavn OIB, ponovite:");
                        oib = Console.ReadLine();
                    }

                    Console.WriteLine("Upisati MBO pacijenta:");
                    string mbo = Console.ReadLine();
                    while (mbo.Length != 9 || digitsOnly(oib) == false)
                    {
                        Console.WriteLine("Neisparavn MBO, ponovite:");
                        mbo = Console.ReadLine();

                    }

                    Console.WriteLine("Upisati ime i prezime pacijenta:");
                    string ime = Console.ReadLine();

                    Console.WriteLine("Upisati datum rodenja pacijenta(mm/dd/gggg):");
                    string input = Console.ReadLine();
                    DateTime datum;
                    while (true)
                    {
                        if (DateTime.TryParse(input, out DateTime date))
                        {
                            datum = DateTime.Parse(input);
                            if (datum < DateTime.Now)
                            {
                                break;
                            }
                            Console.WriteLine("Unijeli ste datum u buducnosti, ponovite: ");
                            input = Console.ReadLine();

                        }
                        else
                        {
                            Console.WriteLine("Krivi format datuma, ponovni upis(mm/dd/gggg)");
                            input = Console.ReadLine();
                        }
                    }

                    Console.WriteLine("Unesite 1 za musko, 2 za zensko:");
                    string izborSpola = Console.ReadLine();
                    while (true)
                    {
                        if (izborSpola == "1")
                        {
                            spol = Spol.Musko;
                            break;
                        }
                        if (izborSpola == "2")
                        {
                            spol = Spol.Zensko;
                            break;
                        }
                        Console.WriteLine("Krivi izbor(1 za musko, 2 za zensko):");
                        izborSpola = Console.ReadLine();
                    }


                    Console.WriteLine("Upisati dijagnozu pacijenta:");
                    string dijagnoza = Console.ReadLine();

                    Pacijent account = new Pacijent { OIB = oib, MBO = mbo, Ime = ime, DatumRod = datum, spol = spol, dijagnoza = dijagnoza };
                    Pacijenti.Add(account);

                }
                if (izbor == "2")
                {
                    Console.WriteLine("Izaberite OIB pacijenta kojeg zelite promjeniti");
                    string provOib = Console.ReadLine();
                    bool found = false;
                    while (!found)
                    {
                        for(int i = 0; i<Pacijenti.Count;i++)
                        {
                            if (Pacijenti[i].OIB == provOib)
                            {
                                found = true;
                                Console.WriteLine("Upisi 1 za izmjenu OIB-a, 2 za MBO, 3 za ime i prezime, 4 za datum rodenja, 5 za spol, 6  za dijagnozu, i bilo sta drugo sa povratak");
                                string a = Console.ReadLine();
                                if (a == "1")
                                {
                                    Console.WriteLine("Upisati OIB pacijenta:");
                                    string oib = Console.ReadLine();
                                    while (oib.Length != 11 || digitsOnly(oib) == false)
                                    {
                                        Console.WriteLine("Neisparavn OIB, ponovite:");
                                        oib = Console.ReadLine();
                                    }
                                    Pacijent p = Pacijenti[i];
                                    p.OIB = oib;
                                    Pacijenti[i] = p;

                                }
                                if (a == "2")
                                {
                                    Console.WriteLine("Upisati MBO pacijenta:");
                                    string mbo = Console.ReadLine();
                                    while (mbo.Length != 9 || digitsOnly(mbo) == false)
                                    {
                                        Console.WriteLine("Neisparavn MBO, ponovite:");
                                        mbo = Console.ReadLine();
                                    }
                                    Pacijent p = Pacijenti[i];
                                    p.MBO = mbo;
                                    Pacijenti[i] = p;
                                }
                                if (a == "3")
                                {
                                    Console.WriteLine("Upisati ime i prezime pacijenta:");
                                    string ime = Console.ReadLine();
                                    Pacijent p = Pacijenti[i];
                                    p.Ime = ime;
                                    Pacijenti[i] = p;
                                }
                                if (a == "4")
                                {
                                    Console.WriteLine("Upisati datum rodenja pacijenta(mm/dd/gggg):");
                                    string input = Console.ReadLine();
                                    DateTime datum;
                                    while (true)
                                    {
                                        if (DateTime.TryParse(input, out DateTime date))
                                        {
                                            datum = DateTime.Parse(input);
                                            if (datum < DateTime.Now)
                                            {
                                                break;
                                            }
                                            Console.WriteLine("Unijeli ste datum u buducnosti, ponovite: ");
                                            input = Console.ReadLine();

                                        }
                                        else
                                        {
                                            Console.WriteLine("Krivi format datuma, ponovni upis(mm/dd/gggg)");
                                            input = Console.ReadLine();
                                        }
                                    }
                                    Pacijent p = Pacijenti[i];
                                    p.DatumRod = datum;
                                    Pacijenti[i] = p;
                                }
                                if (a == "5")
                                {
                                    Console.WriteLine("Unesite 1 za musko, 2 za zensko:");
                                    string izborSpola = Console.ReadLine();
                                    while (true)
                                    {
                                        if (izborSpola == "1")
                                        {
                                            Pacijent p = Pacijenti[i];
                                            p.spol = Spol.Musko;
                                            Pacijenti[i] = p;
                                            break;
                                        }
                                        if (izborSpola == "2")
                                        {
                                            Pacijent p = Pacijenti[i];
                                            p.spol = Spol.Zensko;
                                            Pacijenti[i] = p;
                                        }
                                        Console.WriteLine("Krivi izbor(1 za musko, 2 za zensko):");
                                        izborSpola = Console.ReadLine();
                                    }
                                }
                                if (a == "6")
                                {
                                    Console.WriteLine("Upisati dijagnozu pacijenta:");
                                    string dijagnoza = Console.ReadLine();
                                    Pacijent p = Pacijenti[i];
                                    p.dijagnoza = dijagnoza;
                                    Pacijenti[i] = p;
                                }
                                else { break; }
                            }
                            else {
                                Console.WriteLine("Ne postoji pacijent sa tim OIB-om, ponovite:");
                                provOib = Console.ReadLine();
                            }
                        }
                    }

                }
                else
                {
                    foreach (Pacijent p in Pacijenti)
                    {
                        Console.WriteLine("OIB: " + p.OIB);
                        Console.WriteLine("MBO: " + p.MBO);
                        Console.WriteLine("Ime i prezime: " + p.Ime);
                        Console.WriteLine("Datum rodenja: " + p.DatumRod);
                        Console.WriteLine("Spol: " + p.spol.ToString());
                        Console.WriteLine("Dijagnoze: " + p.dijagnoza);
                    }
                    Console.WriteLine("Pritisnite Enter za izlaz");
                    Console.ReadLine();
                }
            }
        }
        static void Main(string[] args)
        {
            zadatak();
        }
    }
}
