using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PrezentacionaLogika;
using KlasePodataka;

namespace KorisnickiInterfejs
{
    public partial class FilmDetaljiEdit : System.Web.UI.Page
    {
        /* CRC karta - Class Responsibility Collaboration:  */
        //-----------------------------------------------------
        /* ODGOVORNOST: Komunikacija sa bazom podataka pozivanjem uskladištenih procedura  */
        /* ZAVISNOST U ODNOSU NA DRUGE KLASE: Klase prezentacione logike (FormaFilmDetaljiEdit), i klasa podataka (FilmDB)*/

        //atributi
        private string _nazivFilma;
        FormaFilmDetaljiEdit formaDetaljiEdit;
        FilmDB filmDB;
        DataSet podaciDataSet;

        //Metoda koja postavlja vrednosti o filmu koji se menja u polja za unos
        private void PrikaziPodatke(FormaFilmDetaljiEdit formaFilmDetaljiEdit)
        {
            NazivFilmatxb.Text = formaFilmDetaljiEdit.NazivPreuzetogFilma;
            OriginalniNazivtxb.Text = formaFilmDetaljiEdit.OriginalniNazivPreuzetogFilma;
            Rediteljtxb.Text = formaFilmDetaljiEdit.RediteljPreuzetogFilma;
            ZanrTxb.Text = formaFilmDetaljiEdit.ZanrPreuzetogFilma;
            TrajanjeTxb.Text = formaFilmDetaljiEdit.TrajanjePreuzetogFilma.ToString();
            UlogeTxb.Text = formaFilmDetaljiEdit.UlogePreuzetogFilma;
            Calendar1.SelectedDate = Convert.ToDateTime(formaFilmDetaljiEdit.PocetakPrikazivanjaPreuzetogFilma);
            OpisTxb.Text = formaFilmDetaljiEdit.OpisPreuzetogFilma;
        }

        //Metoda za brisanje vrednosti iz polja za unos
        private void IsprazniKontrole()
        {
            NazivFilmatxb.Text = "";
            OriginalniNazivtxb.Text = "";
            Rediteljtxb.Text = "";
            ZanrTxb.Text = "";
            TrajanjeTxb.Text = "";
            UlogeTxb.Text = "";
            OpisTxb.Text = "";
        }

        //Metoda za aktiviranje kontrola
        private void AktivirajKontrole()
        {
            NazivFilmatxb.Enabled = true;
            OriginalniNazivtxb.Enabled = true;
            Rediteljtxb.Enabled = true;
            ZanrTxb.Enabled = true;
            TrajanjeTxb.Enabled = true;
            UlogeTxb.Enabled = true;
            OpisTxb.Enabled = true;
            Calendar1.Enabled = true;
        }

        //Metoda za deaktiviranje kontrola
        private void DeaktivirajKontrole()
        {
            NazivFilmatxb.Enabled = false;
            OriginalniNazivtxb.Enabled = false;
            Rediteljtxb.Enabled = false;
            ZanrTxb.Enabled = false;
            TrajanjeTxb.Enabled = false;
            UlogeTxb.Enabled = false;
            OpisTxb.Enabled = false;
            Calendar1.Enabled = false;
        }

        //konstruktor
        public FilmDetaljiEdit()
        {
            filmDB = new FilmDB(ConfigurationManager.ConnectionStrings["NasaKonekcija"].ConnectionString);
        }

        //Metoda za ucitavanje stranice
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["KorisnikImePrezime"] == null)
            {
                Response.Redirect("Default.aspx");
            }
            else
            {
                formaDetaljiEdit = new FormaFilmDetaljiEdit(ConfigurationManager.ConnectionStrings["NasaKonekcija"].ConnectionString);
                _nazivFilma = Request.QueryString["NazivFilma"].ToString();
                podaciDataSet = new DataSet();
                podaciDataSet = filmDB.DajFilmPoNazivu(_nazivFilma);
                formaDetaljiEdit.IdPreuzetogFilma = Convert.ToInt32(podaciDataSet.Tables[0].Rows[0].ItemArray[0].ToString());
                formaDetaljiEdit.NazivPreuzetogFilma = podaciDataSet.Tables[0].Rows[0].ItemArray[1].ToString();
                formaDetaljiEdit.OriginalniNazivPreuzetogFilma = podaciDataSet.Tables[0].Rows[0].ItemArray[2].ToString();
                formaDetaljiEdit.RediteljPreuzetogFilma = podaciDataSet.Tables[0].Rows[0].ItemArray[3].ToString();
                formaDetaljiEdit.ZanrPreuzetogFilma = podaciDataSet.Tables[0].Rows[0].ItemArray[4].ToString();
                formaDetaljiEdit.TrajanjePreuzetogFilma = Convert.ToInt32(podaciDataSet.Tables[0].Rows[0].ItemArray[5].ToString());
                formaDetaljiEdit.UlogePreuzetogFilma = podaciDataSet.Tables[0].Rows[0].ItemArray[6].ToString();
                formaDetaljiEdit.PocetakPrikazivanjaPreuzetogFilma = podaciDataSet.Tables[0].Rows[0].ItemArray[7].ToString();
                formaDetaljiEdit.OpisPreuzetogFilma = podaciDataSet.Tables[0].Rows[0].ItemArray[8].ToString();

                if (!IsPostBack)
                {
                    PrikaziPodatke(formaDetaljiEdit);
                }
            }

           
        }

        //Kod koji se izvrsava nakon klika na dugme za izmenu
        protected void btnIzmeni_Click(object sender, EventArgs e)
        {
            //preuzimanje vrednosti
            formaDetaljiEdit.NazivIzmenjenogFilma = NazivFilmatxb.Text;
            formaDetaljiEdit.OriginalniNazivIzmenjenogFilma = OriginalniNazivtxb.Text;
            formaDetaljiEdit.RediteljIzmenjenogFilma = Rediteljtxb.Text;
            formaDetaljiEdit.ZanrIzmenjenogFilma = ZanrTxb.Text;
            formaDetaljiEdit.TrajanjeIzmenjenogFilma = Convert.ToInt32(TrajanjeTxb.Text);
            formaDetaljiEdit.UlogeIzmenjenogFilma = UlogeTxb.Text;
            formaDetaljiEdit.OpisIzmenjenogFilma = OpisTxb.Text;
            DateTime date = Calendar1.SelectedDate.Date;
            string preuzetiDatum = date.Year.ToString() + "-" + date.Month.ToString() + "-" + date.Day.ToString();
            formaDetaljiEdit.PocetakPrikazivanjaIzmenjenogFilma = preuzetiDatum;

            bool uspehIzmene = formaDetaljiEdit.IzmeniFilm();
            //prikaz poruke u zavisnosti od uspeha izmene
            if (uspehIzmene)
            {
                lblStatus.Text = "Uspesno izmenjen zapis";
                IsprazniKontrole();
            }
            else
            {
                lblStatus.Text = "Zapis nije izmenjen";
            }
            DeaktivirajKontrole();

        }

        //Kod koji se izvrsava nakon klika na dugme obrisi
        protected void btnOdustani_Click(object sender, EventArgs e)
        {
            formaDetaljiEdit.NazivPreuzetogFilma = NazivFilmatxb.Text;
            bool uspehBrisanja = formaDetaljiEdit.ObrisiFilm();

            //prikaz poruke u zavisnosti od uspeha brisanja
            if (uspehBrisanja)
            {
                lblStatus.Text = "Uspesno obrisan zapis!";
                IsprazniKontrole();
            }
            else
            {
                lblStatus.Text = "Zapis nije obrisan";
            }
        }
    }
}