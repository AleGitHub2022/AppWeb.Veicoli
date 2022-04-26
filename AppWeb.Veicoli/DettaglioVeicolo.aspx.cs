using AppWeb.Veicoli.Controls;
using AppWeb.Veicoli.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeicoliBusiness.Manager;
using VeicoliBusiness.Models;

namespace AppWeb.Veicoli
{
    public partial class DettaglioVeicolo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                return;
            }

            int Id = int.Parse(Request.QueryString["Id"]);
            SetVeicolo(Id);
        }
        public void SetVeicolo(int Id)
        {

            var veicoliManager = new VeicoliManager(Settings.Default.ConnectionString);

            Session["id"] = Id;
            var veicoloModel = veicoliManager.GetVeicolo(Id);
            
            List<MarcaModel> listMarca = veicoliManager.GetListMarche();
            DropDownMarca.DataSource = listMarca;
            DropDownMarca.DataTextField = "Marca";
            DropDownMarca.DataValueField = "Id";
            DropDownMarca.DataBind();
            DropDownMarca.Items.Insert(0, new ListItem("Seleziona", "-1"));

            List<AlimentazioneModel> listTipoAlimentazione = veicoliManager.GetListTipoAlimentazione();
            DropDownAlimentazione.DataSource = listTipoAlimentazione;
            DropDownAlimentazione.DataTextField = "Alimentazione";
            DropDownAlimentazione.DataValueField = "Id";
            DropDownAlimentazione.DataBind();
            DropDownAlimentazione.Items.Insert(0, new ListItem("Seleziona", "-1"));

            txtMarca.Text = veicoloModel.Marca;
            txtModello.Text = veicoloModel.Modello;
            txtAlimentazione.Text = veicoloModel.Alimentazione;
            txtTarga.Text = veicoloModel.Targa;
            txtData.Text = veicoloModel.Immatricolazione?.ToString("d");

            if (veicoloModel.Noleggiato == "Si")
            {
                txtNoleggio.Text = "Noleggiato";
                txtNominativo.Text = veicoloModel.Nominativo;
            }

            else
            {
                txtNoleggio.Text = "Disponibile";
                txtNominativo.Text = "";

            }

            txtNote.Text = veicoloModel.Note;

        }


        protected void DropDownMarca_TextChanged(object sender, EventArgs e)
        {
                       
            txtMarca.Text = DropDownMarca.SelectedItem.Text ;
        }

        protected void DropDownAlimentazione_TextChanged(object sender, EventArgs e)
        {
            txtAlimentazione.Text = DropDownAlimentazione.SelectedItem.Text;
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

        protected void Calendar_SelectionChanged(object sender, EventArgs e)
        {
            txtData.Text = Calendar.SelectedDate.ToShortDateString();
            Calendar.Visible = false;
        }

        
    protected void Indietro_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(Session["Id"]);
            var veicoliList = (List<VeicoliModel>)Session["ListaVeicoli"];
            int indexAttuale = 0;
            foreach (var item in veicoliList)
            {
                if (item.Id == ID)
                {
                    indexAttuale = veicoliList.IndexOf(item);
                    break;
                }
            }
           
            var indexVeicoloPrecedente = indexAttuale - 1;
            if (indexVeicoloPrecedente == -1)
            {
                var veicoloAttuale = veicoliList[indexAttuale];
                SetVeicolo(veicoloAttuale.Id);
                Indietro.Enabled = false;
            }

            else
            {
                var veicoloPrecedente = veicoliList[indexVeicoloPrecedente];
                Avanti.Enabled = true;
                Indietro.Enabled = true;
                if (indexVeicoloPrecedente == 0)
                {
                    Indietro.Enabled = false;

                }
                else
                {
                    Indietro.Enabled = true;

                }

                SetVeicolo(veicoloPrecedente.Id);
            }
        }

        protected void Avanti_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(Session["Id"]);
            var veicoliList = (List<VeicoliModel>)Session["ListaVeicoli"];
            int indexAttuale = 0;
            foreach (var item in veicoliList)
            {
               
                if (item.Id == ID)
                {
                    indexAttuale = veicoliList.IndexOf(item);
                    break;
                }



            }

            var indexVeicoloSuccessivo = indexAttuale + 1;
            if (indexAttuale == veicoliList.Count - 1)
            {
                var veicoloAttuale = veicoliList[indexAttuale];
                SetVeicolo(veicoloAttuale.Id);
                Avanti.Enabled = false;
            }
            else
            {
                var veicoloSuccessivo = veicoliList[indexVeicoloSuccessivo];

                Avanti.Enabled = true;
                Indietro.Enabled = true;
                if (indexVeicoloSuccessivo == veicoliList.Count - 1)
                {
                    Avanti.Enabled = false;

                }
                else
                {
                    Avanti.Enabled = true;

                }
                SetVeicolo(veicoloSuccessivo.Id);
            }
        }

        
        protected void Modifica_Click(object sender, EventArgs e)
        {

           

            var veicoliManager = new VeicoliManager(Settings.Default.ConnectionString);
            var sessionID = Session["id"].ToString();
            var Id = Convert.ToInt32(sessionID);
            var veicolo = veicoliManager.GetVeicolo(Id);
            veicolo.Id = Id;
            if (int.Parse(DropDownMarca.SelectedValue)==-1)
            {
                veicolo.IdMarca = veicolo.IdMarca; 
            }
            else 
            {
                veicolo.IdMarca = int.Parse(DropDownMarca.SelectedValue);
            }
            if (int.Parse(DropDownAlimentazione.SelectedValue)==-1)
            {
                veicolo.IdTipoAlimentazione = veicolo.IdTipoAlimentazione;
            }
            else
            {
                veicolo.IdTipoAlimentazione = int.Parse(DropDownAlimentazione.SelectedValue);
            }
           
            DateTime date;
            if (DateTime.TryParse(txtData.Text, out date))
            {
                veicolo.Immatricolazione = date;
            }
            if (txtTarga.Text.Length < 7)
            {
                InfoControl.SetMessage(Veicoli.Controls.InfoControl.TipoMessaggio.Danger, "Attenzione inserire un numero di targa valido");
                return;
            }
            else
            {
                veicolo.Targa = txtTarga.Text.ToUpper();
            }
            if (string.IsNullOrWhiteSpace(txtModello.Text))
            {
                InfoControl.SetMessage(Veicoli.Controls.InfoControl.TipoMessaggio.Danger, "Attenzione inserire un modello veicolo");
                return;
            }
            else
            {
                veicolo.Modello = txtModello.Text.ToUpper();
            }
                       
            veicolo.Note = txtNote.Text;

            veicoliManager.UpdateVeicolo(veicolo);

            InfoControl.SetMessage(Veicoli.Controls.InfoControl.TipoMessaggio.Success, "Informazioni veicolo aggiornate");

                   
            
        }

        protected void Elimina_Click(object sender, EventArgs e)
        {
            
            var veicoliManager = new VeicoliManager(Settings.Default.ConnectionString);
            var sessionID = Session["id"].ToString();
            var Id = Convert.ToInt32(sessionID);
            var veicolo = veicoliManager.GetVeicolo(Id);
            if(veicolo.Noleggiato=="Si")
            {
                InfoControl.SetMessage(Veicoli.Controls.InfoControl.TipoMessaggio.Danger, "Impossibile eliminare il veicolo selezionato poichè attualmente noleggiato ");
                return;
            }


            else
            {
                veicoliManager.DeleteVeicolo(Id);
               
                InfoControl.SetMessage(Veicoli.Controls.InfoControl.TipoMessaggio.Success, "Veicolo rimosso correttamente");
               
                Response.Redirect("RicercaVeicolo.aspx");
            }

           
        }

        protected void BtnNoleggio_Click(object sender, EventArgs e)
        {
           
            if (txtNoleggio.Text=="Disponibile")
            {
                Response.Redirect("ApplicaNoleggio.aspx");
            }
            else
            {
                Response.Redirect("RitiroNoleggio.aspx");
            }
        }
    }
}