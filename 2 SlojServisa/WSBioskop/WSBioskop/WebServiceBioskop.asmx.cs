using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WSBioskop
{
    /// <summary>
    /// Summary description for WebServiceBioskop
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebServiceBioskop : System.Web.Services.WebService
    {
        /* CRC karta - Class Responsibility Collaboration:  */
        //-----------------------------------------------------
        /* ODGOVORNOST: Citanje podataka iz XML dokumenata  */
        /* ZAVISNOST U ODNOSU NA DRUGE KLASE: */

        //Metoda za citanje svih vrednosti iz dokumenta Sala.XML
        [WebMethod]
        public DataSet DajSveSale()
        {
            DataSet dsZvanja = new DataSet();
            dsZvanja.ReadXml(Server.MapPath("~/") + "XML/Sala.XML");

            return dsZvanja;
        }

        //Metoda za citanje svih vrednosti iz dokumenta SpisakTermina.XML
        [WebMethod]
        public DataSet DajSveTermine()
        {
            DataSet dsZvanja = new DataSet();
            dsZvanja.ReadXml(Server.MapPath("~/") + "XML/SpisakTermina.XML");

            return dsZvanja;
        }

    }
}
