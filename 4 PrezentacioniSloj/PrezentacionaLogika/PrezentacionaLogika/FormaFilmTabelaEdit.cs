using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using KlasePodataka;

namespace PrezentacionaLogika
{
    public class FormaFilmTabelaEdit
    {
        /* CRC karta - Class Responsibility Collaboration:  */
        //-----------------------------------------------------
        /* ODGOVORNOST: Prikaz podataka prilikom izmene podataka   */
        /* ZAVISNOST U ODNOSU NA DRUGE KLASE: Klase projekta KlasePodataka - klasa FilmDB*/

        //atributi
        private string _stringKonekcije;

        //konstruktor
        public FormaFilmTabelaEdit(string noviStringKonekcije)
        {
            _stringKonekcije = noviStringKonekcije;
        }

        //Metoda za prikaz podataka za izmenu u grid-u pozivom odgovarajuce metode na osnovu prosledjenog filtera
        public DataSet DajPodatkeZaGrid(string filter)
        {
            DataSet podaciDataSet = new DataSet();
            FilmDB filmDB = new FilmDB(_stringKonekcije);
            if (filter.Equals(""))
            {
                podaciDataSet = filmDB.DajSveFilmove();
            }
            else
            {
                podaciDataSet = filmDB.DajFilmovePoZanru(filter);
            }
            ProjekcijaDB projekcija = new ProjekcijaDB(_stringKonekcije);
            projekcija.ObrisiFilmProjekcijuNakonIstekaPeriodaPrikazivanja();


            return podaciDataSet;
        }

    }

}
