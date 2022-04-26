using AppWeb.Veicoli.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeicoliBusiness.Manager;

namespace AppWeb.Veicoli
{
    public partial class ListaVeicoliDisponibili : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            VeicoliManager veicoloManager = new VeicoliManager(Settings.Default.ConnectionString);
            var veicoliModelList = veicoloManager.GetVeicoliDisponibili();

            gvVeicoli.DataSource = veicoliModelList;
            gvVeicoli.DataBind();
        }
    }
}