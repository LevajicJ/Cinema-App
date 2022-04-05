using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KlasePodataka
{
    public class FilmLista
    {
        /* CRC karta - Class Responsibility Collaboration:  */
        //-----------------------------------------------------
        /* ODGOVORNOST: Kreiranje liste objekata tipa klase Film  */
        /* ZAVISNOST U ODNOSU NA DRUGE KLASE: Klasa Film*/

        //atributi
        private List<Film> _listaFilmova;

        //property
        public List<Film> ListaFilmova
        {
            get
            {
                return _listaFilmova;
            }
            set
            {
                if (this._listaFilmova != value)
                    this._listaFilmova = value;
            }
        }

        //konstruktor
        public FilmLista()
        {
            _listaFilmova = new List<Film>();
        }

        //javne metode
        //Metoda za dodavanje elementa u listu
        public void DodajElementListe(Film filmObjekat)
        {
            _listaFilmova.Add(filmObjekat);
        }

        //Metoda za brisanje elementa liste
        public void ObrisiElementListe(Film filmObjekatZaBrisanje)
        {
            _listaFilmova.Remove(filmObjekatZaBrisanje);
        }

        //Metoda za brisanje elementa liste na odredjenoj poziciji
        public void ObrisiElementNaPoziciji(int pozicija)
        {
            _listaFilmova.RemoveAt(pozicija);
        }

        //Metoda za izmenu elementa liste
        public void IzmeniElementListe(Film stariFilm, Film noviFilm)
        {
            int indeksStarogFilma = 0;
            indeksStarogFilma = _listaFilmova.IndexOf(noviFilm);
            _listaFilmova.RemoveAt(indeksStarogFilma);
            _listaFilmova.Insert(indeksStarogFilma, noviFilm);
        }

    }
}
