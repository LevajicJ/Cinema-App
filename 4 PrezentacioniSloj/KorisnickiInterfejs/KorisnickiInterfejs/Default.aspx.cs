using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KorisnickiInterfejs
{
    public partial class _Default : System.Web.UI.Page
    {
        /* CRC karta - Class Responsibility Collaboration:  */
        //-----------------------------------------------------
        /* ODGOVORNOST: Stranica koja se prva ucitava prilikom pokretanja apliakcije i prikazuje poruku o uspehu konekcije sa bazom podataka */
        /* ZAVISNOST U ODNOSU NA DRUGE KLASE: -*/
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Global.uspehKonekcije)
            {
                lblStatusKonekcije.Text = "USPESNO REALIZOVANA KONEKCIJA!"; 
            }
            else
            {
                lblStatusKonekcije.Text = "NEUSPESNA KONEKCIJA!"; 
            }
        }
    }
}
