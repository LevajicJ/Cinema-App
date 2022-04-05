using KlasePodataka;
using PrezentacionaLogika;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KorisnickiInterfejs
{
    public partial class FilmTabelarniNeregistrovani : System.Web.UI.Page
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

        //Kod koji se izvrsava prilikom ucitavanja stranice
        protected void Page_Load(object sender, EventArgs e)
        {
            ProjekcijaDB projekcija = new ProjekcijaDB(ConfigurationManager.ConnectionStrings["NasaKonekcija"].ToString());
            projekcija.ObrisiFilmProjekcijuNakonIstekaPeriodaPrikazivanja();
        }

        //Prikaz filtriranih podataka o filmovima
        protected void btnFiltriraj_Click(object sender, EventArgs e)
        {
            FormaFilmTabelaEdit podaciZaGrid = new FormaFilmTabelaEdit(ConfigurationManager.ConnectionStrings["NasaKonekcija"].ToString());
            NapuniGrid(podaciZaGrid.DajPodatkeZaGrid(Filtertxb.Text));
        }

        //Prikaz svih podataka o filmovima
        protected void btnSvi_Click(object sender, EventArgs e)
        {
            FormaFilmTabelaEdit podaciZaGrid = new FormaFilmTabelaEdit(ConfigurationManager.ConnectionStrings["NasaKonekcija"].ToString());
            NapuniGrid(podaciZaGrid.DajPodatkeZaGrid(""));
        }
    }
}