using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KlasePodataka;
using System.Data;

namespace PrezentacionaLogika
{
    public class FormaProjekcijaStampa
    {
        /* CRC karta - Class Responsibility Collaboration:  */
        //-----------------------------------------------------
        /* ODGOVORNOST: Prikaz podataka prilikom stampe */
        /* ZAVISNOST U ODNOSU NA DRUGE KLASE: Klase projekta KlasePodataka - klasa ProjekcijeDB*/

        //atributi
        private string _stringKonekcije;

        //konstruktor
        public FormaProjekcijaStampa(string noviStringKonekcije)
        {
            _stringKonekcije = noviStringKonekcije;
        }

        //javne metode
        // Metoda za prikaz podataka prilikom stampe na osnovu vrednosti filtera pozivom metoda DajSveProjekcije i DajProjekcijePoDatumu
        public DataSet DajPodatkeZaGrid(string filter)
        {
            DataSet podaciDataSet = new DataSet();
            ProjekcijaDB projekcijaDB = new ProjekcijaDB(_stringKonekcije);

            if (filter.Equals(""))
            {
                podaciDataSet = projekcijaDB.DajSveProjekcije();
            }
            else
            {
                podaciDataSet = projekcijaDB.DajProjekcijePoDatumu(filter);
            }

            return podaciDataSet;
        }
    }
}
