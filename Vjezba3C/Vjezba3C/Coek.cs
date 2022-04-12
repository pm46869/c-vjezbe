using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vjezba3C
{
    class Coek
    {
        private string ime;
        private string prezime;
        private string oib;
        private DateTime datum;
        private bool spol;

        public static Coek noviCoek(string ime, string prezime, string oib, DateTime datum, bool spol)
        {
            Coek novi = new Coek();
            novi.ime = ime;
            novi.prezime = prezime;
            novi.oib = oib;
            novi.datum = datum;
            novi.spol = spol;

            return novi;
        }

        public string getOib()
        {
            return this.oib;
        }
        public string getIme()
        {
            return this.ime;
        }
        public string getPrezime()
        {
            return this.prezime;
        }
        public DateTime getDatum()
        {
            return this.datum;
        }
        public bool getSpol()
        {
            return this.spol;
        }


    }
}
