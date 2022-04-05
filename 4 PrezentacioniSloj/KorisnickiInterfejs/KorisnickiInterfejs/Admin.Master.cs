using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KorisnickiInterfejs
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        /* CRC karta - Class Responsibility Collaboration:  */
        //-----------------------------------------------------
        /* ODGOVORNOST: Prikaz menija za admina  */
        /* ZAVISNOST U ODNOSU NA DRUGE KLASE: -*/

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //Prilikom klika na drugme odjavi se zavrsava se pokrenuta sesija i vrsi se preusmeravanje na stranicu Default
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session.Remove("KorisnikImePrezime");
            Response.Redirect("Default.aspx");
        }
    }
}