using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using KlasePodataka;

namespace PrezentacionaLogika
{
    public class FormaFilmUnos
    {
        /* CRC karta - Class Responsibility Collaboration:  */
        //-----------------------------------------------------
        /* ODGOVORNOST: Preuzimanje podataka sa forme za unos filmova  */
        /* ZAVISNOST U ODNOSU NA DRUGE KLASE: Klase iz projekta KlasePodataka - klasa FilmDB*/

        //atributi
        private string _stringKonekcije;
        private string _nazivFilma;
        private string _originalniNazivFilma;
        private string _reditelj;
        private string _zanr;
        private int _trajanje;
        private string _uloge;
        private string _pocetakPrikazivanja;
        private string _opis;

        //property
        public string NazivFilma
        {
            get { return _nazivFilma; }
            set { _nazivFilma = value; }
        }

        public string OriginalniNazivFilma
        {
            get { return _originalniNazivFilma; }
            set { _originalniNazivFilma = value; }
        }

        public string Reditelj
        {
            get { return _reditelj; }
            set { _reditelj = value; }
        }

        public string Zanr
        {
            get { return _zanr; }
            set { _zanr = value; }
        }

        public int Trajanje
        {
            get { return _trajanje; }
            set { _trajanje = value; }
        }

        public string Uloge
        {
            get { return _uloge; }
            set { _uloge = value; }
        }

        public string PocetakPrikazivanja
        {
            get { return _pocetakPrikazivanja; }
            set { _pocetakPrikazivanja = value; }
        }

        public string Opis
        {
            get { return _opis; }
            set { _opis = value; }
        }

        //konstruktor
        public FormaFilmUnos(string noviStringKonekcije)
        {
            _stringKonekcije = noviStringKonekcije;
        }

        //public metode
        //Metoda koja sluzi za projevu da li su unesene vrednosti u sva polja
        public bool DaLiJeSvePopunjeno()
        {
            bool svePopunjeno = false;

            if((_nazivFilma.Length > 0) && (_originalniNazivFilma.Length > 0) && (_reditelj.Length > 0) && (_zanr.Length > 0) && (_trajanje!= 0)  && (_uloge.Length > 0) && (_pocetakPrikazivanja.Length > 0) && (_opis.Length > 0))
            {
                svePopunjeno = true;
            }
            else
            {
                svePopunjeno = false;
            }

            return svePopunjeno;
        }

        //Metoda koja sluzi za proveru da li je jedinstven zapis pozivom metode DajFilmPoNazivu
        public bool DaLiJeJedinstvenZapis()
        {
            bool jedinstvenZapis = false;
            DataSet podaciDataSet = new DataSet();
            FilmDB filmDB = new FilmDB(_stringKonekcije);
            podaciDataSet = filmDB.DajFilmPoNazivu(_nazivFilma);

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

        //Metoda koja sluzi za preuzimanje vrednosti prilikom snimanja podataka pozivom metode DodajNoviFilm
        public bool SnimiPodatke()
        {
            bool uspehSnimanja = false;

            FilmDB filmDB = new FilmDB(_stringKonekcije);

            Film noviFilm = new Film();
            noviFilm.NazivFilma = _nazivFilma;
            noviFilm.OriginalniNazivFilma = _originalniNazivFilma;
            noviFilm.Reditelj = _reditelj;
            noviFilm.Zanr = _zanr;
            noviFilm.Trajanje = _trajanje;
            noviFilm.Uloge = _uloge;
            noviFilm.PocetakPrikazivanja = _pocetakPrikazivanja;
            noviFilm.Opis = _opis;

            uspehSnimanja = filmDB.DodajNoviFilm(noviFilm);

            return uspehSnimanja;
        }
    }
}
