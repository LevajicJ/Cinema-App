using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KlasePodataka;

namespace PrezentacionaLogika
{
    public class FormaFilmDetaljiEdit
    {
        /* CRC karta - Class Responsibility Collaboration:  */
        //-----------------------------------------------------
        /* ODGOVORNOST: Preuzimanje vrednosti sa korisnickog interfejsa i izmena */
        /* ZAVISNOST U ODNOSU NA DRUGE KLASE: Projekat KlasePodataka - klasa Film i FilmDB*/

        //atributi
        private string _stringKonekcije;
        private FilmDB _filmDB;
        private Film _preuzetFilm;
        private Film _izmenjenFilm;

        //atributi preuzetog filma
        private int _idPreuzetogFilma;
        private string _nazivPreuzetogFilma;
        private string _originalniNazivPreuzetogFilma;
        private string _rediteljPreuzetogFilma;
        private string _zanrPreuzetogFilma;
        private int _trajanjePreuzetogFilma;
        private string _ulogePreuzetogFilma;
        private string _pocetakPrikazivanjaPreuzetogFilma;
        private string _opisPreuzetogFilma;

        //atributi izmenjenog filma
        private int _idIzmenjenogFilma;
        private string _nazivIzmenjenogFilma;
        private string _originalniNazivIzmenjenogFilma;
        private string _rediteljIzmenjenogFilma;
        private string _zanrIzmenjenogFilma;
        private int _trajanjeIzmenjenogFilma;
        private string _ulogeIzmenjenogFilma;
        private string _pocetakPrikazivanjaIzmenjenogFilma;
        private string _opisIzmenjenogFilma;


        //property
        public int IdPreuzetogFilma
        {
            get { return _idPreuzetogFilma; }
            set { _idPreuzetogFilma = value; }
        }

        public string NazivPreuzetogFilma
        {
            get { return _nazivPreuzetogFilma; }
            set { _nazivPreuzetogFilma = value; }
        }

        public string OriginalniNazivPreuzetogFilma
        {
            get { return _originalniNazivPreuzetogFilma; }
            set { _originalniNazivPreuzetogFilma = value; }
        }

        public string RediteljPreuzetogFilma
        {
            get { return _rediteljPreuzetogFilma; }
            set { _rediteljPreuzetogFilma = value; }
        }

        public string ZanrPreuzetogFilma
        {
            get { return _zanrPreuzetogFilma; }
            set { _zanrPreuzetogFilma = value; }
        }

        public int TrajanjePreuzetogFilma
        {
            get { return _trajanjePreuzetogFilma; }
            set { _trajanjePreuzetogFilma = value; }
        }

        public string UlogePreuzetogFilma
        {
            get { return _ulogePreuzetogFilma; }
            set { _ulogePreuzetogFilma = value; }
        }

        public string PocetakPrikazivanjaPreuzetogFilma
        {
            get { return _pocetakPrikazivanjaPreuzetogFilma; }
            set { _pocetakPrikazivanjaPreuzetogFilma = value; }
        }

        public string OpisPreuzetogFilma
        {
            get { return _opisPreuzetogFilma; }
            set { _opisPreuzetogFilma = value; }
        }

        public int IdIzmenjenogFilma
        {
            get { return _idIzmenjenogFilma; }
            set { _idIzmenjenogFilma = value; }
        }

        public string NazivIzmenjenogFilma
        {
            get { return _nazivIzmenjenogFilma; }
            set { _nazivIzmenjenogFilma = value; }
        }

        public string OriginalniNazivIzmenjenogFilma
        {
            get { return _originalniNazivIzmenjenogFilma; }
            set { _originalniNazivIzmenjenogFilma = value; }
        }

        public string RediteljIzmenjenogFilma
        {
            get { return _rediteljIzmenjenogFilma; }
            set { _rediteljIzmenjenogFilma = value; }
        }

        public string ZanrIzmenjenogFilma
        {
            get { return _zanrIzmenjenogFilma; }
            set { _zanrIzmenjenogFilma = value; }
        }

        public int TrajanjeIzmenjenogFilma
        {
            get { return _trajanjeIzmenjenogFilma; }
            set { _trajanjeIzmenjenogFilma = value; }
        }

        public string UlogeIzmenjenogFilma
        {
            get { return _ulogeIzmenjenogFilma; }
            set { _ulogeIzmenjenogFilma = value; }
        }

        public string PocetakPrikazivanjaIzmenjenogFilma
        {
            get { return _pocetakPrikazivanjaIzmenjenogFilma; }
            set { _pocetakPrikazivanjaIzmenjenogFilma = value; }
        }

        public string OpisIzmenjenogFilma
        {
            get { return _opisIzmenjenogFilma; }
            set { _opisIzmenjenogFilma = value; }
        }


        //konstruktor
        public FormaFilmDetaljiEdit(string noviStringKonekcije)
        {
            _stringKonekcije = noviStringKonekcije;
            _filmDB = new FilmDB(_stringKonekcije);
        }


        //javne metode
        //Metoda koja sluzi za brisanje filma, pozivom metode ObrisiFilm iz klase FilmDB
        public bool ObrisiFilm()
        {
            bool uspehBrisanja = false;
            uspehBrisanja = _filmDB.ObrisiFilm(_nazivPreuzetogFilma);

            return uspehBrisanja;
        }

        //Metoda koja sluzi za preuzimanje vrednosti prilikom izmene filma i njihovo prosledjivanje pozivom metode IzmeniFilm iz klase FilmDB
        public bool IzmeniFilm()
        {
            bool uspehIzmene = false;
            _preuzetFilm = new Film();
            _izmenjenFilm = new Film();

            _preuzetFilm.NazivFilma = _nazivPreuzetogFilma;
            _preuzetFilm.IdFilma = _idPreuzetogFilma;
            _preuzetFilm.OriginalniNazivFilma = _originalniNazivPreuzetogFilma;
            _preuzetFilm.Reditelj = _rediteljPreuzetogFilma;
            _preuzetFilm.Zanr = _zanrPreuzetogFilma;
            _preuzetFilm.Trajanje = _trajanjePreuzetogFilma;
            _preuzetFilm.Uloge = _ulogePreuzetogFilma;
            _preuzetFilm.PocetakPrikazivanja = _pocetakPrikazivanjaPreuzetogFilma;
            _preuzetFilm.Opis = _opisPreuzetogFilma;


            _izmenjenFilm.NazivFilma = _nazivIzmenjenogFilma;
            _izmenjenFilm.IdFilma = _idIzmenjenogFilma;
            _izmenjenFilm.OriginalniNazivFilma = _originalniNazivIzmenjenogFilma;
            _izmenjenFilm.Reditelj = _rediteljIzmenjenogFilma;
            _izmenjenFilm.Zanr = _zanrIzmenjenogFilma;
            _izmenjenFilm.Trajanje = _trajanjeIzmenjenogFilma;
            _izmenjenFilm.Uloge = _ulogeIzmenjenogFilma;
            _izmenjenFilm.PocetakPrikazivanja = _pocetakPrikazivanjaIzmenjenogFilma;
            _izmenjenFilm.Opis = _opisIzmenjenogFilma;

            uspehIzmene = _filmDB.IzmeniFilm(_preuzetFilm, _izmenjenFilm);

            return uspehIzmene;
        }

    }
}
