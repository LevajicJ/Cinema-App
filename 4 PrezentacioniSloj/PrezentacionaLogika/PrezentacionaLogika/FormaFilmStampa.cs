using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using KlasePodataka;

namespace PrezentacionaLogika
{
    public class FormaFilmStampa
    {
        /* CRC karta - Class Responsibility Collaboration:  */
        //-----------------------------------------------------
        /* ODGOVORNOST: Prikaz podataka prilikom stampe  */
        /* ZAVISNOST U ODNOSU NA DRUGE KLASE: Klase projekta KlasePodataka - FilmDB*/

        //atributi
        private string _stringKonekcije;

        //konstruktor
        public FormaFilmStampa(string noviStringKonekcije)
        {
            _stringKonekcije = noviStringKonekcije;
        }

        //javne metode
        //Metoda za prikaz podataka u gridu - na osnovu prosledjenog filtera vrsi poziv metoda DajSveFilmova ili DajFilmovePoZanru
        public DataSet DajPodatkeZaGrid(string filter)
        {
            DataSet podaciDataSet = new DataSet();
            FilmDB _filmDB = new FilmDB(_stringKonekcije);

            if (filter.Equals(""))
            {
                podaciDataSet = _filmDB.DajSveFilmove();
            }
            else
            {
                podaciDataSet = _filmDB.DajFilmovePoZanru(filter);
            }

            return podaciDataSet;
        }
    }
}
