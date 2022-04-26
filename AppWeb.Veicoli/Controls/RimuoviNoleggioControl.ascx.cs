using AppWeb.Veicoli.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Veicoli.Business.Manager;
using Veicoli.Business.Models;
using VeicoliBusiness.Manager;
using VeicoliBusiness.Models;

namespace AppWeb.Veicoli.Controls
{
    public partial class RimuoviNoleggioControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        public void IsRimosso()
        {

            var veicoliManager = new VeicoliManager(Settings.Default.ConnectionString);
            var sessionID = Session["id"].ToString();
            var Id = Convert.ToInt32(sessionID);
            var veicolo = veicoliManager.GetVeicolo(Id);
            
            txtMarca.Text = veicolo.Marca;
            txtModello.Text = veicolo.Modello;
            txtTarga.Text = veicolo.Targa;
            var clientiManager =new ClientiManager(Settings.Default.ConnectionString);
            
            var cliente = clientiManager.GetAnagraficaCliente(veicolo);
            
            txtNome.Text = cliente.Nome;
            txtCognome.Text = cliente.Cognome;
            txtDataNascita.Text = cliente.DataDiNascita?.ToString("d");
            txtResidenza.Text = cliente.Residenza;
            txtProvincia.Text = cliente.Provincia;
            txtComune.Text = cliente.Comune;
            txtTelefono.Text = cliente.Telefono;
           
        }

        protected void btnTermina_Click(object sender, EventArgs e)
        {
            var veicoliManager = new VeicoliManager(Settings.Default.ConnectionString);
            var clientiManager = new ClientiManager(Settings.Default.ConnectionString);
            var sessionID = Session["id"].ToString();
            var Id = Convert.ToInt32(sessionID);
            var veicolo = new VeicoliModel();
            veicolo.Id = Id;
            bool isNoleggiato = veicoliManager.EndNoleggio(veicolo);

            clientiManager.DeleteCliente(veicolo.Id);

            if (isNoleggiato == false)
            {
                Response.Redirect("RicercaVeicolo.aspx");
            }
        }
    }
}