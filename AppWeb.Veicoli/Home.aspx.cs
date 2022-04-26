using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppWeb.Veicoli
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

       
        protected void Inserisci_Click(object sender, EventArgs e)
        {
            Response.Redirect("InserisciVeicolo.aspx");
        }
        protected void ricerca_Click(object sender, EventArgs e)
        {
            Response.Redirect("RicercaVeicolo.aspx");
        }

        protected void disponibili_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListaVeicoliDisponibili.aspx");
        }

        protected void noleggiati_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListaVeicoliNoleggiati.aspx");
        }
    }
}