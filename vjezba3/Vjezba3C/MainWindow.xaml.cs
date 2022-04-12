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

namespace Vjezba3C
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {

            InitializeComponent();
        }

        List<Uplatnica> uplatnice = new List<Uplatnica>();
        //dugmici
        private void Spremi_Click(object sender, RoutedEventArgs e)
        {
            string imePrimAdd = PrimTxt.Text.ToString();
            provjeraTeksta(imePrimAdd);
            string imePlatAdd = PlatTxt.Text.ToString();
            provjeraTeksta(imePlatAdd);
            string adrPlatAdd = AdrPlatTxt.Text.ToString();
            provjeraTeksta(adrPlatAdd);
            string adrPrimAdd = AdrPrimTxt.Text.ToString();
            provjeraTeksta(adrPrimAdd);
            bool hitnoAdd;
            if (Hitno.IsChecked == false)
            {
                hitnoAdd = false;
            }
            else { hitnoAdd = true; }
            DateTime datumAdd = datumProvjera();
            string valutaAdd = "popravi ovo";//valuta
            string iznosAdd = IznosTxt.Text.ToString();
            provjeraIznosa(iznosAdd);
            string modelAdd = ModelTxt.Text.ToString();
            provjeraModela(modelAdd);
            string pozivPlatAdd = PozivPlatTxt.Text.ToString();
            provjeraPoziva(pozivPlatAdd);
            string pozivPrimAdd = PozivPrimTxt.Text.ToString();
            provjeraPoziva(pozivPrimAdd);
            string sifraAdd = SifraTxt.Text.ToString();
            provjeraSifre(sifraAdd);
            string ibanAdd = ibanTxt.Text.ToString();
            provjeraIbana(ibanAdd);
            string opisAdd = OpisTxt.Text.ToString();
            provjeraTeksta(opisAdd);

            uplatnice.Add(Uplatnica.AddUpl(imePlatAdd, adrPlatAdd, imePrimAdd, adrPrimAdd, hitnoAdd, valutaAdd, iznosAdd, modelAdd, pozivPlatAdd, pozivPrimAdd, sifraAdd, opisAdd, ibanAdd, datumAdd));

        }

        private void Ocisti_Click(object sender, RoutedEventArgs e)
        {
            PrimTxt.Text = "";
            PlatTxt.Text = "";
            AdrPlatTxt.Text = "";
            AdrPrimTxt.Text = "";
            Hitno.IsChecked = false;
            DateTxt.SelectedDate = null;
            //valuta
            IznosTxt.Text = "";
            ModelTxt.Text = "HR";
            PozivPlatTxt.Text = "";
            PozivPrimTxt.Text = "";
            SifraTxt.Text = "";
            ibanTxt.Text = "";
            OpisTxt.Text = "";
        }

        private void Pronadi_Click(object sender, RoutedEventArgs e)
        {
            foreach (Uplatnica uplat in uplatnice)
            {
                if (ibanTxt.Text.ToString() == uplat.getIban())
                {
                    PrimTxt.Text = uplat.getImePrim();
                    PlatTxt.Text = uplat.getImePlat();
                    AdrPlatTxt.Text = uplat.getAdrPlat();
                    AdrPrimTxt.Text = uplat.getAdrPrim();
                    if (uplat.getHitno() == true)
                    {
                        Hitno.IsChecked = true;
                    }
                    else { Hitno.IsChecked = false; }
                    DateTxt.SelectedDate = uplat.getDatum();
                    //valuta
                    IznosTxt.Text = uplat.getIznos();
                    ModelTxt.Text = uplat.getModel();
                    PozivPlatTxt.Text = uplat.getPozivPlat();
                    PozivPrimTxt.Text = uplat.getPozivPrim();
                    SifraTxt.Text = uplat.getSifra();
                    ibanTxt.Text = uplat.getIban();
                    OpisTxt.Text = uplat.getOpis();

                }
            }
            MessageBox.Show("Ne postoji uplatnica sa ovim IBANom");
        }

        //provjere
        private void provjeraIbana(string iban)
        {
            if (iban.Length != 21)
            {
                throw new Exception("neispravan IBAN");

            }
            if (Char.IsLetter(iban[0]) == false || Char.IsLetter(iban[1]) == false)
            {
                throw new Exception("neispravan IBAN");

            }
            for (int i = 2; i < 21; i++)
            {
                if (Char.IsDigit(iban[i]) == false)
                {
                    throw new Exception("neispravan IBAN");

                }
            }

        }
        private void provjeraSifre(string sif)
        {
            if (sif.Length != 4)
            {
                throw new Exception("neispravna sifra");
            }

            for (int i = 0; i < 4; i++)
            {
                if (char.IsLetter(sif[i]) == false)
                {
                    throw new Exception("neispravna sifra");
                }
            }
        }
        private void provjeraPoziva(string poz)
        {
            if (poz.Length > 22)
            {
                throw new Exception("neispravan poziv na broj");
            }
        }
        private void provjeraModela(string mod)
        {
            if (Char.IsDigit(mod[0]) == false || Char.IsDigit(mod[1]) == false || Char.IsUpper(mod[2]) == false || Char.IsUpper(mod[3]) == false)
            {
                throw new Exception("neispravan model");
            }
        }
        private void provjeraTeksta(string tekst)
        {
            if (tekst == "")
            {
                throw new Exception("Jedno ili više od polja su prazna");
            }
        }

        private DateTime datumProvjera()
        {
            if (DateTxt.SelectedDate == null)
            {
                throw new Exception("Datum nije izabran");
            }
            else
            {
                return DateTxt.SelectedDate.Value;
            }
        }
        private void provjeraIznosa(string iznos)
        {
            if (iznos.Contains('.'))
            {
                string[] provjera = iznos.Split('.');
                for (int i = 0; i < provjera[0].Length; i++)
                {
                    if (Char.IsDigit(provjera[0][i]) == false)
                    {
                        throw new Exception("Iznos neispravan");
                    }
                }
                for (int i = 0; i < provjera[1].Length; i++)
                {
                    if (Char.IsDigit(provjera[1][i]) == false)
                    {
                        throw new Exception("Iznos neispravan");
                    }
                }
            }
            else
            {
                for (int i = 0; i < iznos.Length; i++)
                {
                    if (Char.IsDigit(iznos[i]) == false)
                    {
                        throw new Exception("Iznos neispravan");
                    }
                }
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
