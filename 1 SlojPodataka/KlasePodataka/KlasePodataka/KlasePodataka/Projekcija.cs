using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KlasePodataka
{
    public class Projekcija
    {

        /* CRC karta - Class Responsibility Collaboration:  */
        //-----------------------------------------------------
        /* ODGOVORNOST: Kreiranje objekata klase  */
        /* ZAVISNOST U ODNOSU NA DRUGE KLASE: ne postoji*/

        //atributi
        private int _idProjekcije;
        private int _brojSale;
        private string _datum;
        private string _vreme;
        //private Film _film;
        private int _idFilma;

        //property
        public int IdProjekcije
        {
            get { return _idProjekcije; }
            set { _idProjekcije = value; }
        }

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


        public int IdFilma
        {
            get { return _idFilma; }
            set { _idFilma = value; }
        }

    }
}
