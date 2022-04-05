using KlasePodataka;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PrezentacionaLogika;

namespace KorisnickiInterfejs
{
    public partial class FilmTabelaEdit : System.Web.UI.Page
    {
        /* CRC karta - Class Responsibility Collaboration:  */
        //-----------------------------------------------------
        /* ODGOVORNOST: Prikaz tabelarnog prikaza filmova i opcije odabira filma za izmenu ili brisanje  */
        /* ZAVISNOST U ODNOSU NA DRUGE KLASE: Klase projekta PrezentacionaLogika (FormaFilmTabelaEdit) i KlasePodataka(ProjekcijaDB)*/

        private void NapuniGrid(DataSet ds)
        {
            // povezivanje grida sa datasetom
            gvSpisakFilmovaEdit.DataSource = ds.Tables[0];
            gvSpisakFilmovaEdit.DataBind();
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
                if (!IsPostBack)
                {
                    ProjekcijaDB projekcija = new ProjekcijaDB(ConfigurationManager.ConnectionStrings["NasaKonekcija"].ToString());
                    projekcija.ObrisiFilmProjekcijuNakonIstekaPeriodaPrikazivanja();
                    FormaFilmTabelaEdit formaFilmTabelaEdit = new FormaFilmTabelaEdit(ConfigurationManager.ConnectionStrings["NasaKonekcija"].ToString());
                    NapuniGrid(formaFilmTabelaEdit.DajPodatkeZaGrid(""));
                }
            }
            
        }

        //Preusmeravanje na stranicu nakon izbora filma za izmenu
        protected void gvSpisakFilmovaEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect("FilmDetaljiEdit.aspx?NazivFilma=" + gvSpisakFilmovaEdit.Rows[gvSpisakFilmovaEdit.SelectedIndex].Cells[1].Text);
        }
    }
}