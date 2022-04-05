using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KlasePodataka
{
    public class Film
    {
        /* CRC karta - Class Responsibility Collaboration:  */
        //-----------------------------------------------------
        /* ODGOVORNOST: Kreiranje objekata klase  */
        /* ZAVISNOST U ODNOSU NA DRUGE KLASE: ne postoji*/

        //atributi
        private int _idFilma;
        private string _nazivFilma;
        private string _originalniNazivFilma;
        private string _reditelj;
        private string _zanr;
        private int _trajanje;
        private string _uloge;
        private string _pocetakPrikazivanja;
        private string _opis;

        //property
        public int IdFilma
        {
            get { return _idFilma; }
            set { _idFilma = value; }
        }

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
    }
}
