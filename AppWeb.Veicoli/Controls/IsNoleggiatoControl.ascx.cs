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
    public partial class IsNoleggiatoControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void IsDisponibile()
        {

            var veicoliManager = new VeicoliManager(Settings.Default.ConnectionString);
            var sessionID = Session["id"].ToString();
            var Id = Convert.ToInt32(sessionID);
            var veicolo = veicoliManager.GetVeicolo(Id);
            txtMarca.Text=veicolo.Marca;
            txtModello.Text=veicolo.Modello;
            txtTarga.Text= veicolo.Targa;
            
        }


        private bool IsFormValido()
        {

            if (string.IsNullOrEmpty(txtNome.Text))
            {
                InfoControl.SetMessage(Veicoli.Controls.InfoControl.TipoMessaggio.Danger, "Attenzione inserire un nome cliente per registrare il noleggio");
                return false;
            }

            if (string.IsNullOrEmpty(txtCognome.Text))
            {
                InfoControl.SetMessage(Veicoli.Controls.InfoControl.TipoMessaggio.Danger, "Attenzione inserire un cognome cliente per registrare il noleggio");
                return false;
            }

            if (txtDataNascita.Text != DateTime.Parse(txtDataNascita.Text).ToString("d"))
            {
                InfoControl.SetMessage(Veicoli.Controls.InfoControl.TipoMessaggio.Danger, "Attenzione inserire data di nascita in formato esteso(dd/mm/yyyy)");
                return false;
            }


            if (string.IsNullOrEmpty(txtComune.Text))
            {
                InfoControl.SetMessage(Veicoli.Controls.InfoControl.TipoMessaggio.Danger, "Attenzione inserire un Comune");
                return false;
            }
            if (string.IsNullOrEmpty(txtProvincia.Text))
            {
                InfoControl.SetMessage(Veicoli.Controls.InfoControl.TipoMessaggio.Danger, "Attenzione inserire una Provincia");
                return false;
            }
            if (string.IsNullOrEmpty(txtResidenza.Text))
            {
                InfoControl.SetMessage(Veicoli.Controls.InfoControl.TipoMessaggio.Danger, "Attenzione inserire una Residenza");
                return false;
            }
            if (txtTelefono.Text.Length<10 )
            {
                InfoControl.SetMessage(Veicoli.Controls.InfoControl.TipoMessaggio.Danger, "Attenzione inserire numero di telefono valido per registrare il noleggio");
                return false;
            }
            if (txtTelefono.Text.Length > 10)
            {
                InfoControl.SetMessage(Veicoli.Controls.InfoControl.TipoMessaggio.Danger, "Attenzione inserire numero di telefono valido per registrare il noleggio");
                return false;
            }


                return true;
        }

        protected void btnInserisci_Click(object sender, EventArgs e)
        {
            if (!IsFormValido())
            {
              
                return;
            }
            var veicoliManager = new VeicoliManager(Settings.Default.ConnectionString);
            var clientiManager = new ClientiManager(Settings.Default.ConnectionString);
            var sessionID = Session["id"].ToString();
            var Id = Convert.ToInt32(sessionID);
            var veicolo = new VeicoliModel();
            veicolo.Id = Id;
            var personaModel = new PersonaModel();
            personaModel.Nome = txtNome.Text.ToUpper();
            personaModel.Cognome = txtCognome.Text.ToUpper();
            DateTime date;
            DateTime.TryParse(txtDataNascita.Text,out date);
            personaModel.DataDiNascita = date;
            personaModel.Comune = txtComune.Text.ToUpper();
            personaModel.Provincia = txtProvincia.Text;
            personaModel.Residenza = txtResidenza.Text;
            personaModel.Telefono = txtTelefono.Text;
            bool isNoleggiato = veicoliManager.UpdateNoleggio(veicolo, personaModel);
            clientiManager.InsertClientiDB(personaModel,veicolo.Id);

            if(isNoleggiato==false)
            {
                Response.Redirect("RicercaVeicolo.aspx");
            }
           
        }

        protected void Calendar_SelectionChanged(object sender, EventArgs e)
        {
            txtDataNascita.Text = Calendar.SelectedDate.ToShortDateString();
            Calendar.Visible = false;
        }

        protected void ImageButtonClear_Click(object sender, ImageClickEventArgs e)
        {
            txtDataNascita.Text = string.Empty;
        }

        protected void ImageButtonCalendar_Click(object sender, ImageClickEventArgs e)
        {
            if (Calendar.Visible == false)
            {
                Calendar.Visible = true;

            }
            else
            {
                Calendar.Visible = false;
            }
        }
    }
}