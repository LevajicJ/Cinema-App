using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using KlasePodataka;

namespace PrezentacionaLogika
{
    public class FormaLogin
    {
        /* CRC karta - Class Responsibility Collaboration:  */
        //-----------------------------------------------------
        /* ODGOVORNOST: Preuzimanje vrednosti iz polja prilikom prijavljivanja korisnika  */
        /* ZAVISNOST U ODNOSU NA DRUGE KLASE: Klase projekta KlasePodataka - KorisnikDB*/

        //atributi
        private string _stringKonekcije;
        private string _korisnickoIme;
        private string _sifra;

        //property
        public string KorisnickoIme
        {
            get { return _korisnickoIme; }
            set { _korisnickoIme = value; }
        }

        public string Sifra
        {
            get { return _sifra; }
            set { _sifra = value; }
        }

        //konstruktor
        public FormaLogin(string noviStringKonekcije)
        {
            _stringKonekcije = noviStringKonekcije;
        }

        //javne metode
        //Metoda koja sluzi za proveru da li je korisnik vazeci pozivom metode DajKorisnikaPoKorisnickomImeniISifri
        public bool VazeciKorisnik()
        {
            bool vazeci = false;

            KorisnikDB korisnik = new KorisnikDB(_stringKonekcije);
            DataSet podaciDataSet = korisnik.DajKorisnikaPoKorisnickomImenuISifri(_korisnickoIme, _sifra);

            if(podaciDataSet.Tables[0].Rows.Count > 0)
            {
                vazeci = true;
            }
            else
            {
                vazeci = false;
            }

            return vazeci;
        }

        //Metoda za citanje imena i prezimena prijavljenog korisnika pozivom metode DajKorisnikaPoKorisnickomImenuISifri
        public string DajImePrezimeKorisnika()
        {
            string imePrezime = "";

            KorisnikDB korisnik = new KorisnikDB(_stringKonekcije);
            DataSet podaciDataSet = korisnik.DajKorisnikaPoKorisnickomImenuISifri(_korisnickoIme, _sifra);

            if(podaciDataSet.Tables[0].Rows.Count > 0)
            {
                imePrezime = podaciDataSet.Tables[0].Rows[0].ItemArray[2].ToString() + " " + podaciDataSet.Tables[0].Rows[0].ItemArray[1].ToString();
            }

            return imePrezime;
        }
    }
}
