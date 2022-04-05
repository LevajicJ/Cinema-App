using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KlasePodataka;

namespace PoslovnaLogika
{
    public class PoslovnaPravila
    {
        /* CRC karta - Class Responsibility Collaboration:  */
        //-----------------------------------------------------
        /* ODGOVORNOST: Sprovodjenje poslovnog pravila   */
        /* ZAVISNOST U ODNOSU NA DRUGE KLASE: Klase iz projekta KlasePodataka */

        //atributi
        private string _stringKonekcije;

        //property
        public string StringKonekcije
        {
            get { return _stringKonekcije; }
        }

        //konstruktor
        public PoslovnaPravila(string noviStringkonekcije)
        {
            _stringKonekcije = noviStringkonekcije;
        }

        //public metode

        //Ova metoda brise film i sve projekcije tog filma iz baze
        //nakon isteka perioda prikazivanja
        public bool ObrisiFilmProjekcijuNakonIstekaRoka()
        {
            ProjekcijaDB projekcija = new ProjekcijaDB(_stringKonekcije);
            bool uspeh = false;
            uspeh = projekcija.ObrisiFilmProjekcijuNakonIstekaPeriodaPrikazivanja();
            return uspeh;
        }


    }
}
