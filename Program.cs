using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Vjezba2
{
    class Program
    {   
        //provjere
        public static bool provHit(string hit)
        {
            if (hit == "da")
            {
                return true;
            }
            else if (hit == "ne")
            {
                return false;
            }
            else
            {
                Console.WriteLine("Krivi odabir, upišite da ili ne");
                hit = Console.ReadLine();
                provHit(hit);
            }
            return false; //daje error ako ne stavim
        }
        public static string provVal(string val)
        {
            if (val.Length != 3)
            {
                Console.WriteLine("Kriva valuta, upišite ponovno:");
                val = Console.ReadLine();
                provVal(val);
            }
            val = val.ToUpper();
            return val;
        }
        public static string provMod(string mod)
        {
            if (Char.IsDigit(mod[0]) == false || Char.IsDigit(mod[1]) == false || Char.IsUpper(mod[2]) == false || Char.IsUpper(mod[3]) == false)
            {
                Console.WriteLine("Krivi model, upišite ponovno:");
                mod = Console.ReadLine();
                provMod(mod);
            }
            return mod;
        }
        public static string provPoz(string poz)
        {
            if(poz.Length > 22)
            {
                Console.WriteLine("Poziv na broj mora imati maksimalno 22 znamenke, unesite ponovno:");
                poz = Console.ReadLine();
                provPoz(poz);
            }
            return poz;
        }
        public static string provSif(string sif)
        {
            if (sif.Length != 4)
            {
                Console.WriteLine("Kriva sifra namjene, upišite ponovno(4 slova):");
                sif = Console.ReadLine();
                provSif(sif);
            }
            sif = sif.ToUpper();
            return sif;
        }
        public static string provIb(string iban)
        {
            bool test = true;
            if (iban.Length != 21)
            {
                test = false;
            }
            if (Char.IsLetter(iban[0]) == false || Char.IsLetter(iban[1]) == false)
            {
                test = false;
            }
            for (int i = 2; i < 21; i++)
            {
                if (Char.IsDigit(iban[i]) == false)
                {
                    test = false;
                }
            }
            if(test == false)
            {
                Console.WriteLine("Krivi IBAN, unesite ponovno:");
                iban = Console.ReadLine();
                provIb(iban);
            }
            return iban;


        }
        public static DateTime provDat(int dan, int mjesec, int godina)
        {
            bool test = true;
            if(mjesec < 1 || dan > 12)
            {
                test = false;
            }
            if(dan < 1 || dan > 31)
            {
                test = false;
            }
            if(godina < 1950 ||godina > 2022)
            {
                test = false;
            }
            if(test == false)
            {
                Console.WriteLine("Neispravan datum, upišite ponovno:");
                dan = Convert.ToInt32(Console.ReadLine());
                mjesec = Convert.ToInt32(Console.ReadLine());
                godina = Convert.ToInt32(Console.ReadLine());
                provDat(dan, mjesec, godina);
            }

            DateTime date = new DateTime(godina, mjesec, dan);
            return date;
        }
        public static double provIzn(string iznos)
        {
            bool test = true;
            if (iznos.Contains('.')){
                string[] provjera = iznos.Split('.');
                for (int i = 0; i < provjera[0].Length; i++)
                {
                    if (Char.IsDigit(provjera[0][i])==false)
                    {
                        test = false;
                    }
                }
                for (int i = 0; i < provjera[1].Length; i++)
                {
                    if (Char.IsDigit(provjera[1][i])==false)
                    {
                        test = false;
                    }
                }
            }
            else
            {
                for (int i = 0; i < iznos.Length; i++)
                {
                    if (Char.IsDigit(iznos[i])==false)
                    {
                        test = false;
                    }
                }
            }
            if(test == false)
            {
                Console.WriteLine("Krivi format iznosa, upišite ponovno:");
                iznos = Console.ReadLine();
                provIzn(iznos);
            }

            double novi = Convert.ToDouble(iznos);

            return novi;
        }

        public static void Unos(List<Uplatnica> u)
        {
            Console.WriteLine("Ime Platitelja");
            string imeplat = Console.ReadLine();

            Console.WriteLine("Adresa Platitelja");
            string adrplat = Console.ReadLine();

            Console.WriteLine("Ime Primatelja");
            string imeprim = Console.ReadLine();

            Console.WriteLine("Adresa Primatelja");
            string adrprim = Console.ReadLine();

            Console.WriteLine("Hitno(da/ne):");
            string hit = Console.ReadLine();
            bool hitno = provHit(hit);

            Console.WriteLine("Valuta:");
            string val = provVal(Console.ReadLine());

            Console.WriteLine("Iznos;");
            double iznos = provIzn(Console.ReadLine());

            Console.WriteLine("Model:");
            string model = provMod(Console.ReadLine());

            Console.WriteLine("Poziv na broj platitelja:");
            string pozivPlat = provPoz(Console.ReadLine());

            Console.WriteLine("Poziv na broj primatelja:");
            string pozivPrim = provPoz(Console.ReadLine());

            Console.WriteLine("Šifra namjene:");
            string sifra = provSif(Console.ReadLine());

            Console.WriteLine("Opis plaćanja:");
            string opis = Console.ReadLine();

            Console.WriteLine("IBAN:");
            string iban = provIb(Console.ReadLine());

            Console.WriteLine("Unesite datum(dan, mjesec, pa godina):");
            int dan = Convert.ToInt32(Console.ReadLine());
            int mjesec = Convert.ToInt32(Console.ReadLine());
            int godina = Convert.ToInt32(Console.ReadLine());
            DateTime datum = provDat(dan, mjesec, godina);

            u.Add(new Uplatnica(imeplat, adrplat, imeprim, adrprim, hitno, val, iznos, model, pozivPlat, pozivPrim, sifra, opis, iban, datum));

        }

        static void Main(string[] args)
        {
            var u = new List<Uplatnica>();
            int a = 1;
            while(a == 1 || a == 2)
            {
                Console.WriteLine("Upišite 1 za unos nove uplatnice, 2 za ispis svih uplatnica, ili bilo šta drugo za prekid programa");
                a = Convert.ToInt32(Console.ReadLine());
                if(a == 1)
                {
                    Unos(u);
                }
                if (a == 2)
                {
                    foreach(Uplatnica upl in u)
                    {
                        upl.printanje();
                    }
                }

            }





        }
    }
}
