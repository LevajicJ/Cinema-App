using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using KlasePodataka;
using PoslovnaLogika;

namespace PrezentacionaLogika
{
    public class FormaProjekcijaUnos
    {
        /* CRC karta - Class Responsibility Collaboration:  */
        //-----------------------------------------------------
        /* ODGOVORNOST: Preuzimanje podataka sa forme za unso projekcija  */
        /* ZAVISNOST U ODNOSU NA DRUGE KLASE: Klase projekta KlasePodataka (klasa Projekcija, FilmDB) i web servis (WebServiceBioskop)*/

        //atributi
        private string _stringKonekcije;
        private int _brojSale;
        private string _datum;
        private string _vreme;
        private string _nazivFilma;
        private Projekcija _projekcija = new Projekcija();
        

        public int BrojSale
        {
            get { return _brojSale; }
            set { _brojSale = value; }
        }

        public string Datum
        {
            get { return _datum; }
            set { _datum = value; }
        }

        public string Vreme
        {
            get { return _vreme; }
            set { _vreme = value; }
        }

        public string NazivFilma
        {
            get { return _nazivFilma; }
            set { _nazivFilma = value; }
        }

        //konstruktor
        public FormaProjekcijaUnos(string noviStringKonekcije)
        {
            _stringKonekcije = noviStringKonekcije;
        }

        //javne metode
        //Metoda za prikaz filmova u combo box-u pozivom metode DajSveFilmove
        public DataSet DajFilmoveZaCombo()
        {
            DataSet podaciDataSet = new DataSet();
            FilmDB filmDB = new FilmDB(_stringKonekcije);
            podaciDataSet =  filmDB.DajSveFilmove();

            return podaciDataSet;
        }

        //Metoda za prikaz sala u combo box-u pozivom metode DajSveSale
        public DataSet DajPodatkeZaComboSale()
        {
            DataSet podaciDataSet = new DataSet();
         
            WSBioskop.WebServiceBioskop servis = new WSBioskop.WebServiceBioskop();
            podaciDataSet =  servis.DajSveSale();

            return podaciDataSet;
        }

        //Metoda za prikaz termina projekcija u combo box-u pozivom metode DajSveTermine
        public DataSet DajPodatkeZaComboTermini()
        {
            DataSet podaciDataSet = new DataSet();

            WSBioskop.WebServiceBioskop servis = new WSBioskop.WebServiceBioskop();
            podaciDataSet = servis.DajSveTermine();

            return podaciDataSet;
        }

        //Metoda za proveru popunjenosti svih polja u formi za unos
        public bool DaLiJeSvePopunjeno()
        {
            bool svePopunjeno = false;

            if(_nazivFilma.Length > 0 && _brojSale.Equals(1) || _brojSale.Equals(2) && _datum.Length > 0 &&  _vreme.Length > 0)
            {
                if(_nazivFilma.Equals("Izaberite...") || _brojSale.Equals("Izaberite...") || _vreme.Equals("Izaberite..."))
                {
                    svePopunjeno = false;
                }
                else
                {
                    svePopunjeno = true;
                }
                
            }
            else
            {
                svePopunjeno = false;
            }

            return svePopunjeno;
        }

        //Metoda za proveru jedinstvenosti zapisa pozivom metode DajProjekcijePremaDatumuSaliVremenu
        public bool DaLiJeJedinstvenZapis()
        {
            bool jedinstvenZapis = false;

            DataSet podaciDataSet = new DataSet();
            ProjekcijaDB projekcijaDB = new ProjekcijaDB(_stringKonekcije);
            _projekcija.IdFilma = projekcijaDB.DajIdZaFilm(_nazivFilma);
            //_projekcija.Film.NazivFilma = _nazivFilma.ToString();
            _projekcija.BrojSale = _brojSale;
            _projekcija.Datum = _datum;
            _projekcija.Vreme = _vreme;
            podaciDataSet = projekcijaDB.DajProjekcijePremaDatumuSaliVremenu(_projekcija);

            if(podaciDataSet.Tables[0].Rows.Count == 0)
            {
                jedinstvenZapis = true;
            }
            else
            {
                jedinstvenZapis = false;
            }

            return jedinstvenZapis;
        }

        //Metoda za snimanje podataka preuzetih iz forme pozivom metode SnimiNovuProjekciju
        public bool SnimiPodatke()
        {
            bool uspehSnimanja = false;

            ProjekcijaDB projekcijaDB = new ProjekcijaDB(_stringKonekcije);
            string naziv;
            Projekcija novaProjekcija = new Projekcija();
            novaProjekcija.BrojSale = _brojSale;
            novaProjekcija.Datum = _datum;
            novaProjekcija.IdFilma = projekcijaDB.DajIdZaFilm(_nazivFilma);
            novaProjekcija.Vreme = _vreme;

            uspehSnimanja = projekcijaDB.SnimiNovuProjekciju(novaProjekcija);

            return uspehSnimanja;
        }

    }
}


