using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PrezentacionaLogika;


namespace KorisnickiInterfejs
{
    public partial class FilmUnos : System.Web.UI.Page
    {
        /* CRC karta - Class Responsibility Collaboration:  */
        //-----------------------------------------------------
        /* ODGOVORNOST: Forma za unos podataka o filmovima  */
        /* ZAVISNOST U ODNOSU NA DRUGE KLASE: Klase projekta PrezentacionaLogika (FormaFilmUnos)*/

        FormaFilmUnos unosFilma;
        //Kod koji se izvrsava prilikom ucitavanja stranice
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["KorisnikImePrezime"] == null)
            {
                Response.Redirect("Default.aspx");
            }
            else
            {
                unosFilma = new FormaFilmUnos(ConfigurationManager.ConnectionStrings["NasaKonekcija"].ToString());
                if (!IsPostBack)
                {
                    
                }
            }
            

        }

        //Kod koji se izvrsava nakon klika na dugme za snimanje podataka
        protected void btnSnimi_Click(object sender, EventArgs e)
        {
            /*KlasePodataka.FilmDB filmDB = new KlasePodataka.FilmDB(ConfigurationManager.ConnectionStrings["NasaKonekcija"].ToString());
            KlasePodataka.Film film = new KlasePodataka.Film();*/
            
            DateTime date = Calendar1.SelectedDate.Date;
            unosFilma.NazivFilma = NazivFilmatxb.Text;
            unosFilma.OriginalniNazivFilma = OriginalniNazivtxb.Text;
            unosFilma.Reditelj = Rediteljtxb.Text;
            unosFilma.Zanr = ZanrTxb.Text;
            unosFilma.Trajanje = Convert.ToInt32(TrajanjeTxb.Text);
            unosFilma.Uloge = UlogeTxb.Text;
            string preuzetiDatum = date.Year.ToString() + "-" + date.Month.ToString() + "-" + date.Day.ToString();
            unosFilma.PocetakPrikazivanja = preuzetiDatum;
            unosFilma.Opis = OpisTxb.Text;

            
            //provera popunjenosti polja
            bool svePopunjeno = unosFilma.DaLiJeSvePopunjeno();

            //provera jedinstvenosti zapisa
            bool jedinstvenZapis = unosFilma.DaLiJeJedinstvenZapis();

            //Poruka o statusu dodavanja novog filma
            if(svePopunjeno)
            {
                if (jedinstvenZapis)
                {
                    unosFilma.SnimiPodatke();
                    lblStatus.Text = "Snimljeno";
                }
                else
                {
                    lblStatus.Text = "Podaci o filmu vec postoje u bazi";
                }

            }
            else
            {
                lblStatus.Text = "Nisu popunjena sva polja";
            }
        }

        //Kod koji se izvrsava nakon klika na dugme za odustajanje
        protected void btnOdustani_Click(object sender, EventArgs e)
        {
            Response.Redirect("WelcomeAdmin.aspx");
        }
    }
}