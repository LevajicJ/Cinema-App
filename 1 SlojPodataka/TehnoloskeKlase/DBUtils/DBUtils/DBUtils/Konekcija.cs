using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DBUtils
{
    public class Konekcija
    {
        /* CRC karta - Class Responsibility Collaboration:  */
        //-----------------------------------------------------
        /* ODGOVORNOST: Konekcija na celinu baze podataka, SQL server tipa  */
        /* ZAVISNOST U ODNOSU NA DRUGE KLASE: Standardna klasa iz SqlClient - SqlConnection*/

        #region ATRIBUTI
        private SqlConnection _konekcija;
        private string _putanjaBaze;
        private string _nazivBaze;
        private string _nazivDBMSInstance;
        private string _stringKonekcije;
        #endregion

        #region KONSTRUKTOR
        public Konekcija(string nazivDBMSInstanceParametar, string putanjaBazeParametar, string nazivBazeParametar)
        {
            _putanjaBaze = putanjaBazeParametar;
            _nazivBaze = nazivBazeParametar;
            _nazivDBMSInstance = nazivDBMSInstanceParametar;
            _stringKonekcije = "";
        }

        public Konekcija(string noviStringKonekcijeParametar)
        // overload metoda - konstruktor koji prima kompletan string konekcije
        {

            _putanjaBaze = "";
            _nazivBaze = "";
            _nazivDBMSInstance = "";
            _stringKonekcije = noviStringKonekcijeParametar;
        }
        #endregion

        #region PRIVATNE METODE
        private string DajStringKonekcije()
        {
            // NAMENA: Formira string konekcije iz komponenti, 
            //na 2 nacina - ako je baza podataka vec ukljucena u DBMS ili sa fajlom baze koji se dinamicki povezuje za DBMS
            string stringKonekcije; // lokalna promenljiva u ovoj metodi
            if (_stringKonekcije.Length.Equals(0) || _stringKonekcije == null)
            {
                // ako kompletan string vec nije dat kroz konstruktor
                if (_putanjaBaze.Length.Equals(0) || _putanjaBaze == null)
                {
                    stringKonekcije = "Data Source=" + _nazivDBMSInstance + " ;Initial Catalog=" + _nazivBaze + ";Integrated Security=True";
                }
                else
                {
                    stringKonekcije = "Data Source=.\\" + _nazivDBMSInstance + ";AttachDbFilename=" + _putanjaBaze + "\\" + _nazivBaze + ";Integrated Security=True;Connect Timeout=30;User Instance=True";
                }
            }
            else
            {
                // AKO IMAMO VEC DAT GOTOV STRING KONEKCIJE
                stringKonekcije = _stringKonekcije;
            }
            return stringKonekcije;
        }
        #endregion

        #region JAVNE METODE
        public bool OtvoriKonekciju()
        // NAMENA: Otvara konekciju ka bazi podataka
        {
            bool uspeh;
            _konekcija = new SqlConnection();
            _konekcija.ConnectionString = this.DajStringKonekcije(); // pisemo this, iako je prihvatljivo da se pise bez toga, zbog citljivosti

            try
            {
                _konekcija.Open();
                uspeh = true;
            }
            catch
            {
                uspeh = false;
            }
            return uspeh;
        }

        public SqlConnection DajKonekciju()
        // NAMENA: Vraca objekat tipa SqlConnection iz vrednosti privatnog atributa (kao GET metoda)
        {
            return _konekcija;
        }

        public void ZatvoriKonekciju()
        // NAMENA: Zatvara konekciju ka bazi podataka
        {
            _konekcija.Close();
            _konekcija.Dispose();
        }

        #endregion
    }
}
