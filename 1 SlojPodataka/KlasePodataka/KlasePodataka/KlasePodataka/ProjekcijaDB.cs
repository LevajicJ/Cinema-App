using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace KlasePodataka
{
    public class ProjekcijaDB
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
            get { return _stringKonekcije; }
        }

        //konstruktor
        public ProjekcijaDB(string NoviStringKonekcije)
        {
            _stringKonekcije = NoviStringKonekcije;
        }

        //Metoda za prikaz svih projekcija iz baze podataka pozivom uskadistene procedure DajSveProjekcijeSaJoin
        public DataSet DajSveProjekcije()
        {
            DataSet podaciDataSet = new DataSet();

            SqlConnection veza = new SqlConnection(_stringKonekcije);
            veza.Open();
            SqlCommand komanda = new SqlCommand("DajSveProjekcijeSaJoin", veza);
            komanda.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = komanda;
            dataAdapter.Fill(podaciDataSet);
            veza.Close();
            veza.Dispose();

            return podaciDataSet;
        }

        //Metoda za izdvajanje projekcija iz baze podataka na osnovu prosledjenog datuma pozivom uskladistene procedure DajProjekcijePoDatumu
        public DataSet DajProjekcijePoDatumu(string datum)
        {
            DataSet podaciDataSet = new DataSet();

            SqlConnection veza = new SqlConnection(_stringKonekcije);
            veza.Open();
            SqlCommand komanda = new SqlCommand("DajProjekcijePoDatumu", veza);
            komanda.CommandType = CommandType.StoredProcedure;
            komanda.Parameters.Add("@DatumProjekcije", SqlDbType.Date).Value = datum;
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = komanda;
            dataAdapter.Fill(podaciDataSet);
            veza.Close();
            veza.Dispose();

            return podaciDataSet;
        }

        //Metoda za proveru da li postoji podatak u bazi sa istim vrednostima za datum, salu i vreme pozivom uskladistene procedure DajProjekcijuPremaDatumuSaliVremenu
        public DataSet DajProjekcijePremaDatumuSaliVremenu(Projekcija proveraProjekcije)
        {
            DataSet podaciDataSet = new DataSet();

            SqlConnection veza = new SqlConnection(_stringKonekcije);
            veza.Open();
            SqlCommand komanda = new SqlCommand("DajProjekcijuPremaDatumuSaliVremenu", veza);
            komanda.CommandType = CommandType.StoredProcedure;
            komanda.Parameters.Add("@Datum", SqlDbType.Date).Value = proveraProjekcije.Datum;
            komanda.Parameters.Add("@BrojSale", SqlDbType.Int).Value = proveraProjekcije.BrojSale;
            komanda.Parameters.Add("@Vreme", SqlDbType.NVarChar).Value = proveraProjekcije.Vreme;
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = komanda;
            dataAdapter.Fill(podaciDataSet);
            veza.Close();
            veza.Dispose();

            return podaciDataSet;
        }

        //Metoda za prikaz ID-a prosledjenog naziva filma iz baze podataka pozivom uskladistene procedure DajIdPremaNazivuFilma
        public int DajIdZaFilm(string nazivFilma)
        {
            int idFilma;

            DataSet podaciDataSet = new DataSet();

            SqlConnection veza = new SqlConnection(_stringKonekcije);
            veza.Open();
            SqlCommand komanda = new SqlCommand("DajIdPremaNazivuFilma", veza);
            komanda.CommandType = CommandType.StoredProcedure;
            komanda.Parameters.Add("@NazivFilma", SqlDbType.NVarChar).Value = nazivFilma;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = komanda;
            da.Fill(podaciDataSet);
            veza.Close();
            veza.Dispose();
            idFilma = Convert.ToInt32(podaciDataSet.Tables[0].Rows[0].ItemArray[0].ToString());
            return idFilma;




        }

        //Metoda za prikaz naziva filma na osnovu prosledjenog ID-a iz baze podataka pozivom uskladistene procedure DajNazivFilmaPoId
        public string DajNazivFilmaPoId(int idFilma)
        {
            string nazivFilma;

            DataSet podaciDataSet = new DataSet();

            SqlConnection veza = new SqlConnection(_stringKonekcije);
            veza.Open();
            SqlCommand komanda = new SqlCommand("DajNazivFilmaPoId", veza);
            komanda.CommandType = CommandType.StoredProcedure;
            komanda.Parameters.Add("@IdFilma", SqlDbType.NVarChar).Value = idFilma;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = komanda;
            da.Fill(podaciDataSet);
            veza.Close();
            veza.Dispose();

            nazivFilma = podaciDataSet.Tables[0].Rows[0].ItemArray[0].ToString();
            return nazivFilma;

        }

        //Metoda za prikaz podataka o projekciji na osnovu prosledjenog ID-a iz baze podataka pozivom uskladistene procedure DajProjekcijuPoId
        public DataSet DajProjekcijuPoId(int idProjekcije)
        {
            DataSet podaciDataSet = new DataSet();

            SqlConnection veza = new SqlConnection(_stringKonekcije);
            veza.Open();
            SqlCommand komanda = new SqlCommand("DajProjekcijuPoId", veza);
            komanda.CommandType = CommandType.StoredProcedure;
            komanda.Parameters.Add("@IdProjekcije", SqlDbType.Int).Value = idProjekcije;
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = komanda;
            dataAdapter.Fill(podaciDataSet);
            veza.Close();
            veza.Dispose();

            return podaciDataSet;
        }

        //Metoda za proveru izmenjene projekcije u bazi podataka pozivom uskladistene procedure DajProjekcijuPremaDatumuSaliVremenu
        public bool ProveriIzmenuProjekcije(Projekcija proveraProjekcije)
        {
            DataSet podaciDataSet = new DataSet();
            int brojSlogova = 0;
            SqlConnection veza = new SqlConnection(_stringKonekcije);
            veza.Open();
            SqlCommand komanda = new SqlCommand("DajProjekcijuPremaDatumuSaliVremenu", veza);
            komanda.CommandType = CommandType.StoredProcedure;
            komanda.Parameters.Add("@Datum", SqlDbType.Date).Value = proveraProjekcije.Datum;
            komanda.Parameters.Add("@BrojSale", SqlDbType.Int).Value = proveraProjekcije.BrojSale;
            komanda.Parameters.Add("@Vreme", SqlDbType.NVarChar).Value = proveraProjekcije.Vreme;
            brojSlogova = komanda.ExecuteNonQuery();

            veza.Close();
            veza.Dispose();

            return (brojSlogova > 0);
        }

        //Metoda za unos podataka o projekciji u bazu podataka upotrebom uskladistene procedure DodajNovuProjekciju
        public bool SnimiNovuProjekciju(Projekcija novaProjekcija)
        {
            int brojSlogova = 0;

            SqlConnection veza = new SqlConnection(_stringKonekcije);
            veza.Open();

            SqlCommand komanda = new SqlCommand("DodajNovuProjekciju", veza);
            komanda.CommandType = CommandType.StoredProcedure;
            komanda.Parameters.Add("@BrojSale", SqlDbType.Int).Value = novaProjekcija.BrojSale;
            komanda.Parameters.Add("@Datum", SqlDbType.Date).Value = novaProjekcija.Datum;
            komanda.Parameters.Add("@Vreme", SqlDbType.NVarChar).Value = novaProjekcija.Vreme;
            komanda.Parameters.Add("@IDFilma", SqlDbType.Int).Value = novaProjekcija.IdFilma;

            brojSlogova = komanda.ExecuteNonQuery();
            veza.Close();
            veza.Dispose();

            return (brojSlogova > 0);

        }

        //Metoda za brisanje projekcije na osnovu ID-a iz baze podataka pozivom uskladistene procedure ObrisiProjekciju
        public bool ObrisiProjekciju(int idProjekcijeZaBrisanje)
        {
            int brojSlogova = 0;

            SqlConnection veza = new SqlConnection(_stringKonekcije);
            veza.Open();

            SqlCommand komanda = new SqlCommand("ObrisiProjekciju", veza);
            komanda.CommandType = CommandType.StoredProcedure;
            komanda.Parameters.Add("@IdProjekcije", SqlDbType.Int).Value = idProjekcijeZaBrisanje;
            brojSlogova = komanda.ExecuteNonQuery();
            veza.Close();
            veza.Dispose();

            return (brojSlogova > 0);
        }

        //Metoda za brisanje filma i termina projekcije nakon isteka perioda prikazivanja pozivom uskladistene procedure ObrisiFilmNakonIstekaPeriodaPrikazivanja
        public bool ObrisiFilmProjekcijuNakonIstekaPeriodaPrikazivanja()
        {
            int brojSlogova = 0;

            SqlConnection veza = new SqlConnection(_stringKonekcije);
            veza.Open();

            SqlCommand komanda = new SqlCommand("ObrisiFilmNakonIstekaPeriodaPrikazivanja", veza);
            komanda.CommandType = CommandType.StoredProcedure;
            brojSlogova = komanda.ExecuteNonQuery();
            veza.Close();
            veza.Dispose();

            return (brojSlogova > 0);

        }

        //Metoda za izmenu projekcije pozivom uskladistene procedure IzmeniProjekciju
        public bool IzmeniProjekciju(Projekcija staraProjekcija, Projekcija novaProjekcija)
        {
            int brojSlogova = 0;

            SqlConnection veza = new SqlConnection(_stringKonekcije);
            veza.Open();

            SqlCommand komanda = new SqlCommand("IzmeniProjekciju", veza);
            komanda.CommandType = CommandType.StoredProcedure;
            komanda.Parameters.Add("@StariIdProjekcije", SqlDbType.Int).Value = staraProjekcija.IdProjekcije;
            komanda.Parameters.Add("@BrojSale", SqlDbType.Int).Value = novaProjekcija.BrojSale;
            komanda.Parameters.Add("@Datum", SqlDbType.Date).Value = novaProjekcija.Datum;
            komanda.Parameters.Add("@Vreme", SqlDbType.NVarChar).Value = novaProjekcija.Vreme;
            komanda.Parameters.Add("@IdFilma", SqlDbType.Int).Value = novaProjekcija.IdFilma;
            brojSlogova = komanda.ExecuteNonQuery();
            veza.Close();
            veza.Dispose();

            return (brojSlogova > 0);

        }

    }
}
