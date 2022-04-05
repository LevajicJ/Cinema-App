using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KlasePodataka
{
    public class ProjekcijaLista
    {
        /* CRC karta - Class Responsibility Collaboration:  */
        //-----------------------------------------------------
        /* ODGOVORNOST: Kreiranje liste objekata tipa Projekcija  */
        /* ZAVISNOST U ODNOSU NA DRUGE KLASE: Klasa Projekcija*/

        //atributi
        private List<Projekcija> _listaProjekcija;

        //property
        public List<Projekcija> ListaProjekcija
        {
            get
            {
                return _listaProjekcija;
            }
            set
            {
                if (this._listaProjekcija != value)
                    this._listaProjekcija = value;
            }
        }

        //konsktruktor
        public ProjekcijaLista()
        {
            _listaProjekcija = new List<Projekcija>();
        }

        //javne metode
        //Metoda za dodavanje novog elementa u listu
        public void DodajElementListe(Projekcija novaProjekcija)
        {
            _listaProjekcija.Add(novaProjekcija);
        }

        //Metoda za brisanje elementa iz liste
        public void ObrisiElementListe(Projekcija projekcijaZaBrisanje)
        {
            _listaProjekcija.Remove(projekcijaZaBrisanje);             
        }

        //Metoda za brisanje elementa iz liste na odredjenoj poziciji
        public void ObrisiElementNaPoziciji(int pozicija)
        {
            _listaProjekcija.RemoveAt(pozicija);
        }

        //Metoda za izmenu elementa liste
        public void IzmeniElementListe(Projekcija staraProjekcija, Projekcija novaProjekcija)
        {
            int indeksStareProjekcije = 0;
            indeksStareProjekcije = _listaProjekcija.IndexOf(novaProjekcija);
            _listaProjekcija.RemoveAt(indeksStareProjekcije);
            _listaProjekcija.Insert(indeksStareProjekcije, novaProjekcija);
        }

    }
}
