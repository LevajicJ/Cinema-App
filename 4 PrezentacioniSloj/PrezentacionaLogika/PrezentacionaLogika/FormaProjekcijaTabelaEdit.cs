using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using KlasePodataka;

namespace PrezentacionaLogika
{
    public class FormaProjekcijaTabelaEdit
    {
        /* CRC karta - Class Responsibility Collaboration:  */
        //-----------------------------------------------------
        /* ODGOVORNOST: Prikaz podataka prilikom izmene projekcije  */
        /* ZAVISNOST U ODNOSU NA DRUGE KLASE: Klase iz projekta KlasePodataka - klasa ProjekcijaDB*/

        //atributi
        private string _stringKonekcije;

        //konstruktor
        public FormaProjekcijaTabelaEdit(string noviStringKonekcije)
        {
            _stringKonekcije = noviStringKonekcije;
        }

        //javne metode
        //Metoda za prikaz podataka u gridu pozivom metode DajSveProjekcije ili DajProjekcijePoDatumu u zavisnosti od vrednosti filtera
        public DataSet DajPodatkeZaGrid(string filter)
        {
            DataSet podaciDataSet = new DataSet();
            ProjekcijaDB projekcijaDB = new ProjekcijaDB(_stringKonekcije);
            if(filter.Equals(""))
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
