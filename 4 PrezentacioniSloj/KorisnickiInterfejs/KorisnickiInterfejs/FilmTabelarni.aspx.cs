using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KlasePodataka;
using PrezentacionaLogika;

namespace KorisnickiInterfejs
{
    public partial class FilmTabelarni : System.Web.UI.Page
    {
        /* CRC karta - Class Responsibility Collaboration:  */
        //-----------------------------------------------------
        /* ODGOVORNOST: Prikaz tabelarnog prikaza filmova sa opcijom za filtriranje  */
        /* ZAVISNOST U ODNOSU NA DRUGE KLASE: Klase projekta PrezentacionaLogika (FormaFilmTabelaEdit) i KlasePodataka(ProjekcijaDB)*/

        private void NapuniGrid(DataSet ds)
        {
            // povezivanje grida sa datasetom
            gvSpisakFilmova.DataSource = ds.Tables[0];
            gvSpisakFilmova.DataBind();
        }

        //Kod koji se izvrsava nakon ucitavanja stranice
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["KorisnikImePrezime"] == null)
            {
                Response.Redirect("Default.aspx");
            }
            else
            {
                ProjekcijaDB projekcija = new ProjekcijaDB(ConfigurationManager.ConnectionStrings["NasaKonekcija"].ToString());
                projekcija.ObrisiFilmProjekcijuNakonIstekaPeriodaPrikazivanja();
                if (!IsPostBack)
                {
                    //onda
                }
            }
            
        }

        //Prikaz filtriranih podataka o filmovima
        protected void btnFiltriraj_Click(object sender, EventArgs e)
        {
            FormaFilmTabelaEdit podaciZaGrid = new FormaFilmTabelaEdit(ConfigurationManager.ConnectionStrings["NasaKonekcija"].ToString());
            NapuniGrid(podaciZaGrid.DajPodatkeZaGrid(Filtertxb.Text));
            //KlasePodataka.FilmDB filmDB = new KlasePodataka.FilmDB(ConfigurationManager.ConnectionStrings["NasaKonekcija"].ToString());
            //NapuniGrid(filmDB.DajFilmovePoZanru(Filtertxb.Text));
        }

        //Prikaz svih podataka o filmovima
        protected void btnSvi_Click(object sender, EventArgs e)
        {
            FormaFilmTabelaEdit podaciZaGrid = new FormaFilmTabelaEdit(ConfigurationManager.ConnectionStrings["NasaKonekcija"].ToString());
            NapuniGrid(podaciZaGrid.DajPodatkeZaGrid(""));
            /*KlasePodataka.FilmDB filmDB = new KlasePodataka.FilmDB(ConfigurationManager.ConnectionStrings["NasaKonekcija"].ToString());
            NapuniGrid(filmDB.DajSveFilmove());*/
        }
    }
}