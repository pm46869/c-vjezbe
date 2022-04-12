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

        List<Coek> coeci = new List<Coek>();
        //dugmici
        private void Spremi_Click(object sender, RoutedEventArgs e)
        {

            string imeAdd = ImeTxt.Text.ToString();
            provjera(imeAdd);
            string prezimeAdd = PrezimeTxt.Text.ToString();
            provjera(prezimeAdd);
            string oibAdd = OIBtxt.Text.ToString();
            oibProvjera(oibAdd);
            DateTime datumAdd = datumProvjera();
            bool spolAdd = provjeraSpolaHehe();

            coeci.Add(Coek.noviCoek(imeAdd, prezimeAdd, oibAdd, datumAdd, spolAdd));


        }

        private void Ocisti_Click(object sender, RoutedEventArgs e)
        {
            ImeTxt.Text = "";
            PrezimeTxt.Text = "";
            OIBtxt.Text = "";
            DateTxt.SelectedDate = null;
            M.IsChecked = false;
            Z.IsChecked = false;
        }


        //provjere
        private bool provjeraSpolaHehe()
        {
            if(M.IsChecked == true)
            {
                return true;
            }
            if(Z.IsChecked == true)
            {
                return false;
            }
            else throw new Exception("Nije izabran spol");
        }
        private void provjera(string tekst)
        {
            if(tekst == "")
            {
                throw new Exception("Niste upisali ime/prezime");
            }
        }
        private void oibProvjera(string oibpr)
        {
            bool test = true;
            if (oibpr.Length != 11)
            {
                throw new Exception("Neispravan OIB");
            }
            for (int i = 0; i < 11; i++)
            {
                if (char.IsDigit(oibpr[i]) == false)
                {
                    throw new Exception("Neispravan OIB");
                }
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

        private void Pronadi_Click(object sender, RoutedEventArgs e)
        {

            foreach(Coek covjeculjak in coeci)
            {
                if (OIBtxt.Text.ToString() == covjeculjak.getOib())
                {
                    ImeTxt.Text = covjeculjak.getIme();
                    PrezimeTxt.Text = covjeculjak.getPrezime();
                    OIBtxt.Text = covjeculjak.getOib();
                    DateTxt.SelectedDate = covjeculjak.getDatum();
                    if(covjeculjak.getSpol() == true)
                    {
                        M.IsChecked = true;
                    }
                    else
                    {
                        Z.IsChecked = true;
                    }
                    return;
                }
            }
            MessageBox.Show("Ne postoji osoba sa tim OIBom");
        }
    }
}
