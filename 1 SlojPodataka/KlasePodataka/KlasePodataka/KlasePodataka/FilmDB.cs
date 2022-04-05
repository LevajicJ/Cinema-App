using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace KlasePodataka
{
    public class FilmDB
    {
        /* CRC karta - Class Responsibility Collaboration:  */
        //-----------------------------------------------------
        /* ODGOVORNOST: Komunikacija sa bazom podataka pozivanjem uskladištenih procedura  */
        /* ZAVISNOST U ODNOSU NA DRUGE KLASE: Standardne klase iz SqlClient - SqlConnection, SqlCommand, SqlDataAdapter*/
        
        //atributi
        private string _stringKonekcije;

        //property
        public string StringKonekcije
        {
            get
            {
                return _stringKonekcije;
            }
        }

        //konstruktor
        public FilmDB(string noviStringKonekcije)
        {
            _stringKonekcije = noviStringKonekcije;
        }

        //javne metode

        //Metoda za izdvajanje svih filmova iz baze pozivom uskladistene procedure DajSveFilmove
        public DataSet DajSveFilmove()
        {
            DataSet podaciDataSet = new DataSet();

            SqlConnection veza = new SqlConnection(_stringKonekcije);
            veza.Open();
            SqlCommand komanda = new SqlCommand("DajSveFilmove", veza);
            komanda.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = komanda;
            dataAdapter.Fill(podaciDataSet);
            veza.Close();
            veza.Dispose();

            return podaciDataSet;
        }

        //Metoda za izdvajanje filmova po odredjenom zanru iz baze pozivom uskladistene procedure DajFilmPoZanru
        public DataSet DajFilmovePoZanru(string zanr)
        {

            DataSet podaciDataSet = new DataSet();

            SqlConnection veza = new SqlConnection(_stringKonekcije);
            veza.Open();
            SqlCommand komanda = new SqlCommand("DajFilmPoZanru", veza);
            komanda.CommandType = CommandType.StoredProcedure;
            komanda.Parameters.Add("@ZanrFilma", SqlDbType.NVarChar).Value = zanr;
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = komanda;
            dataAdapter.Fill(podaciDataSet);
            veza.Close();
            veza.Dispose();

            return podaciDataSet;

        }

        //Metoda za izdvajanje filma po nazivu iz baze podataka pozivom uskladistene procedure DajFilmPoNazivu
        public DataSet DajFilmPoNazivu(string nazivFilma)
        {
            DataSet podaciDataSet = new DataSet();

            SqlConnection veza = new SqlConnection(_stringKonekcije);
            veza.Open();
            SqlCommand komanda = new SqlCommand("DajFilmPoNazivu", veza);
            komanda.CommandType = CommandType.StoredProcedure;
            komanda.Parameters.Add("@NazivFilma", SqlDbType.NVarChar).Value = nazivFilma;
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = komanda;
            dataAdapter.Fill(podaciDataSet);
            veza.Close();
            veza.Dispose();

            return podaciDataSet;
        }

        //Metoda za dodavanje novog filma u bazu podataka pozivom uskradistene procedure DodajNoviFilm
        public bool DodajNoviFilm(Film noviFilm)
        {
            int brojSlogova = 0;

            SqlConnection veza = new SqlConnection(_stringKonekcije);
            veza.Open();

            SqlCommand komanda = new SqlCommand("DodajNoviFilm", veza);
            komanda.CommandType = CommandType.StoredProcedure;
            komanda.Parameters.Add("@NazivFilma", SqlDbType.NVarChar).Value = noviFilm.NazivFilma;
            komanda.Parameters.Add("@OriginalniNaziv", SqlDbType.NVarChar).Value = noviFilm.OriginalniNazivFilma;
            komanda.Parameters.Add("@Reditelj", SqlDbType.NVarChar).Value = noviFilm.Reditelj;
            komanda.Parameters.Add("@Zanr", SqlDbType.NVarChar).Value = noviFilm.Zanr;
            komanda.Parameters.Add("@Trajanje", SqlDbType.Int).Value = noviFilm.Trajanje;
            komanda.Parameters.Add("@Uloge", SqlDbType.NVarChar).Value = noviFilm.Uloge;
            komanda.Parameters.Add("@PocetakPrikazivanja", SqlDbType.Date).Value = noviFilm.PocetakPrikazivanja;
            komanda.Parameters.Add("@Opis", SqlDbType.NVarChar).Value = noviFilm.Opis;

            brojSlogova = komanda.ExecuteNonQuery();
            veza.Close();
            veza.Dispose();

            return (brojSlogova > 0);
        }

        //Metoda za brisanje filma iz baze podataka na osnovu naziva pozivom uskladistene procedure ObrisiFilm
        public bool ObrisiFilm(string nazivFilmaZaBrisanje)
        {
            int brojSlogova = 0;

            SqlConnection veza = new SqlConnection(_stringKonekcije);
            veza.Open();

            SqlCommand komanda = new SqlCommand("ObrisiFilm", veza);
            komanda.CommandType = CommandType.StoredProcedure;
            komanda.Parameters.Add("@NazivFilma", SqlDbType.NVarChar).Value = nazivFilmaZaBrisanje;
            brojSlogova = komanda.ExecuteNonQuery();
            veza.Close();
            veza.Dispose();

            return (brojSlogova > 0);
        }

        //Metoda za izmenu filma u bazi podataka pozivom uskradistene procedure IzmeniFilm
        public bool IzmeniFilm(Film stariFilm, Film noviFilm)
        {
            int brojSlogova = 0;

            SqlConnection veza = new SqlConnection(_stringKonekcije);
            veza.Open();

            SqlCommand komanda = new SqlCommand("IzmeniFilm", veza);
            komanda.CommandType = CommandType.StoredProcedure;

            komanda.Parameters.Add("@StariId", SqlDbType.Int).Value = stariFilm.IdFilma;
            komanda.Parameters.Add("@NazivFilma", SqlDbType.NVarChar).Value = noviFilm.NazivFilma;
            komanda.Parameters.Add("@OriginalniNaziv", SqlDbType.NVarChar).Value = noviFilm.OriginalniNazivFilma;
            komanda.Parameters.Add("@Reditelj", SqlDbType.NVarChar).Value = noviFilm.Reditelj;
            komanda.Parameters.Add("@Zanr", SqlDbType.NVarChar).Value = noviFilm.Zanr;
            komanda.Parameters.Add("@Trajanje", SqlDbType.Int).Value = noviFilm.Trajanje;
            komanda.Parameters.Add("@Uloge", SqlDbType.NVarChar).Value = noviFilm.Uloge;
            komanda.Parameters.Add("@PocetakPrikazivanja", SqlDbType.Date).Value = noviFilm.PocetakPrikazivanja;
            komanda.Parameters.Add("@Opis", SqlDbType.NVarChar).Value = noviFilm.Opis;
            brojSlogova = komanda.ExecuteNonQuery();
            veza.Close();
            veza.Dispose();

            return (brojSlogova > 0);

        }


    }
}
