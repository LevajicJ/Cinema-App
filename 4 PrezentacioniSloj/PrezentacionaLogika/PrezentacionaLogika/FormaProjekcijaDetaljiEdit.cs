using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KlasePodataka;

namespace PrezentacionaLogika
{
    public class FormaProjekcijaDetaljiEdit
    {
        /* CRC karta - Class Responsibility Collaboration:  */
        //-----------------------------------------------------
        /* ODGOVORNOST: Preuzimanje vrednosti sa forme za izmenu podataka o projekciji  */
        /* ZAVISNOST U ODNOSU NA DRUGE KLASE: Klase projekta KlasePodataka - klasa Projekcija i ProjekcijaDB*/

        //atributi
        private string _stringKonekcije;
        private ProjekcijaDB _projekcijaDB;

        private Projekcija _preuzetaProjekcija;
        private Projekcija _izmenjenaProjekcija;

        //atributi za preuzetu projekciju
        private int _idProjekcijePreuzeto;
        private int _brojSalePreuzeto;
        private string _datumPreuzeto;
        private string _vremePreuzeto;
        private string _filmPreuzeto;

        //atributi za izmenjenu projekciju
        private int _idProjekcijeIzmenjeno;
        private int _brojSaleIzmenjeno;
        private string _datumIzmenjeno;
        private string _vremeIzmenjeno;
        private string _filmIzmenjeno;

        //property
        public int IdProjekcijePreuzeto
        {
            get { return _idProjekcijePreuzeto; }
            set { _idProjekcijePreuzeto = value; }
        }

        public int BrojSalePreuzeto
        {
            get { return _brojSalePreuzeto; }
            set { _brojSalePreuzeto = value; }
        }

        public string DatumPreuzeto
        {
            get { return _datumPreuzeto; }
            set { _datumPreuzeto = value; }
        }

        public string VremePreuzeto
        {
            get { return _vremePreuzeto; }
            set { _vremePreuzeto = value; }
        }

        public String FilmPreuzeto
        {
            get { return _filmPreuzeto; }
            set { _filmPreuzeto = value; }
        }

        public int IdProjekcijeIzmenjeno
        {
            get { return _idProjekcijeIzmenjeno; }
            set { _idProjekcijeIzmenjeno = value; }
        }

        public int BrojSaleIzmenjeno
        {
            get { return _brojSaleIzmenjeno; }
            set { _brojSaleIzmenjeno = value; }
        }

        public string DatumIzmenjeno
        {
            get { return _datumIzmenjeno; }
            set { _datumIzmenjeno = value; }
        }

        public string VremeIzmenjeno
        {
            get { return _vremeIzmenjeno; }
            set { _vremeIzmenjeno = value; }
        }

        public String FilmIzmenjeno
        {
            get { return _filmIzmenjeno; }
            set { _filmIzmenjeno = value; }
        }


        //konstruktor 
        public FormaProjekcijaDetaljiEdit(string noviStringKonekcije)
        {
            _stringKonekcije = noviStringKonekcije;
            _projekcijaDB = new ProjekcijaDB(_stringKonekcije);
        }

        //javne metode
        //Metoda za brisanje projekcije pozivom metode ObrisiProjekciju
        public bool ObrisiProjekciju()
        {
            bool uspehBrisanja = false;
            uspehBrisanja = _projekcijaDB.ObrisiProjekciju(_idProjekcijePreuzeto);
            return uspehBrisanja;
        }

        //Metoda za preuzimanje vrednosti za izmenu projekcije pozivom metode IzmeniProjekciju
        public bool IzmeniProjekciju()
        {
            bool uspehIzmene = false;
            _preuzetaProjekcija = new Projekcija();
            _izmenjenaProjekcija = new Projekcija();

            _preuzetaProjekcija.IdProjekcije = _idProjekcijePreuzeto;
            _preuzetaProjekcija.BrojSale = _brojSalePreuzeto;
            _preuzetaProjekcija.Datum = _datumPreuzeto;
            _preuzetaProjekcija.Vreme = _vremePreuzeto;
            _preuzetaProjekcija.IdFilma = Convert.ToInt32(_filmPreuzeto);

            _izmenjenaProjekcija.IdProjekcije = _idProjekcijeIzmenjeno;
            _izmenjenaProjekcija.BrojSale = _brojSaleIzmenjeno;
            _izmenjenaProjekcija.Datum = _datumIzmenjeno;
            _izmenjenaProjekcija.Vreme = _vremeIzmenjeno;
            _izmenjenaProjekcija.IdFilma = Convert.ToInt32(_projekcijaDB.DajIdZaFilm( _filmIzmenjeno));

            bool vecPostojiProjekcijaZaTermin = false;
            vecPostojiProjekcijaZaTermin = _projekcijaDB.ProveriIzmenuProjekcije(_izmenjenaProjekcija);
            if (!vecPostojiProjekcijaZaTermin)
            {
                uspehIzmene = _projekcijaDB.IzmeniProjekciju(_preuzetaProjekcija, _izmenjenaProjekcija);
            }
            else
            {
                uspehIzmene = false;
            }

            


            return uspehIzmene;
        }
    }
}
