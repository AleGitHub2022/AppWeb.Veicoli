
using AppWeb.Veicoli.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeicoliBusiness.Manager;
using VeicoliBusiness.Models;

namespace AppWeb.Veicoli
{
    public partial class InserisciVeicolo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                return;
            }
            
            var veicoliManager = new VeicoliManager(Settings.Default.ConnectionString);
            List<AlimentazioneModel> listTipoAlimentazione = veicoliManager.GetListTipoAlimentazione();
            List<MarcaModel> listMarca = veicoliManager.GetListMarche() ;
            DropDownAlimentazione.DataSource = listTipoAlimentazione;
            DropDownAlimentazione.DataTextField = "Alimentazione";
            DropDownAlimentazione.DataValueField = "Id";
            DropDownAlimentazione.DataBind();
            DropDownAlimentazione.Items.Insert(0, new ListItem("Seleziona", "-1"));

            DropDownMarca.DataSource = listMarca;
            DropDownMarca.DataTextField = "Marca";
            DropDownMarca.DataValueField = "Id";
            DropDownMarca.DataBind();
            DropDownMarca.Items.Insert(0, new ListItem("Seleziona", "-1"));
                       
        }



        protected void Calendar_SelectionChanged(object sender, EventArgs e)
        {
            txtData.Text = Calendar.SelectedDate.ToShortDateString();
            Calendar.Visible = false;
        }
        
        protected void ImageButtonCalendar_Click(object sender, ImageClickEventArgs e)
        {
            if(Calendar.Visible == false)
            {
                Calendar.Visible = true; 

            }
            else
            {
                Calendar.Visible = false;
            }
        }
        protected void ImageButtonClear_Click(object sender, ImageClickEventArgs e)
        {
            txtData.Text = string.Empty;
         
        }

        private bool IsFormValido()
        {
           
            int valErrore = -1;
            if (valErrore == int.Parse(DropDownAlimentazione.SelectedValue))
            {
                
                return false;
            }
                        
            if (string.IsNullOrWhiteSpace(txtModello.Text))
            {
               
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTarga.Text))
            {
               
                return false;
            }
          
            
            if (string.IsNullOrEmpty(txtData.Text))
            {
                return false;
            }
           
            if (valErrore == int.Parse(DropDownMarca.SelectedValue))
            {
                
                return false;
            }


            return true;
        }
        protected void btnInserisci_Click(object sender, EventArgs e)
        {
           
            if (!IsFormValido())
            {
                InfoControl.SetMessage(Veicoli.Controls.InfoControl.TipoMessaggio.Danger, "Attenzione riempire tutti i campi per registrare il veicolo");
                return;
            }

            var veicoliModel = new VeicoliModel();
            var veicoliManager = new VeicoliManager(Settings.Default.ConnectionString);
            veicoliModel.IdMarca = int.Parse(DropDownMarca.SelectedValue);
            veicoliModel.Modello = txtModello.Text.ToUpper();
            veicoliModel.Targa = txtTarga.Text.ToUpper();
            veicoliModel.Immatricolazione = Calendar.SelectedDate;
            if (veicoliModel.Immatricolazione == DateTime.Parse("01/01/0001 00:00:00"))
            {
                veicoliModel.Immatricolazione= DateTime.Parse(txtData.Text);
            }
            
            veicoliModel.IdTipoAlimentazione = int.Parse(DropDownAlimentazione.SelectedValue);
            var noleggiato = "No";
            veicoliModel.Noleggiato = noleggiato;
            veicoliModel.Note = txtNote.Text;
            string controlloTarga = veicoliManager.ControlloTarga(veicoliModel);

            if (controlloTarga == txtTarga.Text.ToUpper())
            {
                InfoControl.SetMessage(Veicoli.Controls.InfoControl.TipoMessaggio.Danger, "Attenzione Targa già presente in archivio");

                return;
            }
            bool isVeicoloinserito = veicoliManager.InsertVeicoliDB(veicoliModel);

          InfoControl.SetMessage(Veicoli.Controls.InfoControl.TipoMessaggio.Success, "Veicolo registrato correttamente");
            
            
            if (isVeicoloinserito==false)
            {
                
                
                DropDownAlimentazione.ClearSelection();
                DropDownMarca.ClearSelection();
                txtModello.Text = "";
                txtTarga.Text = "";
                txtData.Text = "";
                txtNote.Text = "";
            }
            
        }

        
    }
}
