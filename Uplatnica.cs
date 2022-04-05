using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vjezba2
{
    class Uplatnica
    {
        private string platIme;
        private string platAdr;
        private string primIme;
        private string primAdr;
        private bool hitno;
        private string valuta;
        private double iznos;
        private string model;
        private string pozivPlat;
        private string pozivPrim;
        private string sifra;
        private string opis;
        private string iban;
        private DateTime datum;

        //konstr
        public Uplatnica(string platIme, string platAdr, string primIme, string primAdr, bool hitno, string valuta, double iznos, string model, string pozivPlat, string pozivPrim, string sifra, string opis, string iban, DateTime datum)
        {
            this.platIme = platIme;
            this.platAdr = platAdr;
            this.primIme = primIme;
            this.primAdr = primAdr;
            this.hitno = hitno;
            this.valuta = valuta;
            this.iznos = iznos;
            this.model = model;
            this.pozivPlat = pozivPlat;
            this.pozivPrim = pozivPrim;
            this.sifra = sifra;
            this.opis = opis;
            this.iban = iban;
            this.datum = datum;
        }

        public void printanje()
        {
            Console.WriteLine("Ime platitelja:" + this.platIme);
            Console.WriteLine("Adresa platitelja:" +this.platAdr);
            Console.WriteLine("Ime primatelja:"+this.primIme);
            Console.WriteLine("Adresa primatelja:"+this.primAdr);
            if(hitno == true)
            {
                Console.WriteLine("Hitno: da");
            }
            else {
                Console.WriteLine("Hitno: ne");
            }
            Console.WriteLine("Valuta:"+this.valuta);
            Console.WriteLine("Iznos:"+this.iznos);
            Console.WriteLine("Model:"+this.model);
            Console.WriteLine("Poziv na broj platitelja:"+this.pozivPlat);
            Console.WriteLine("Poziv na broj primatelja:"+this.pozivPrim);
            Console.WriteLine("Šifra"+this.sifra);
            Console.WriteLine("Opis plaćanja:"+this.opis);
            Console.WriteLine("IBAN:"+this.iban);
            Console.WriteLine("Datum:"+this.datum);

        }

    }

}
