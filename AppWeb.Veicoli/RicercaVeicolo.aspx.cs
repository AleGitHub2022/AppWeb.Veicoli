using AppWeb.Veicoli.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeicoliBusiness.Manager;
using VeicoliBusiness.Models;

namespace AppWebVeicoli
{
    public partial class RicercaVeicolo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                return;
            }
            var veicoliManager = new VeicoliManager(Settings.Default.ConnectionString);
            List<MarcaModel> listMarca = veicoliManager.GetListMarche();
            DropDownMarca.DataSource = listMarca;
            DropDownMarca.DataTextField = "Marca";
            DropDownMarca.DataValueField = "Id";
            DropDownMarca.DataBind();
            DropDownMarca.Items.Insert(0, new ListItem("Seleziona", "-1"));
        }

        protected void btnRicerca_Click(object sender, EventArgs e)
        {
            var veicolo = new RicercaVeicoloModel();
            veicolo.IdMarca = int.Parse(DropDownMarca.SelectedValue);
            veicolo.Modello = txtModello.Text.ToUpper();
            veicolo.Targa = txtTarga.Text.ToUpper();

            if (!string.IsNullOrEmpty(txtDataFrom.Text))
            {
                DateTime date;
                DateTime.TryParse(txtDataFrom.Text, out date);
                veicolo.ImmatricolazioneDa = date;
            }
            else
            {
                veicolo.ImmatricolazioneDa = DateTime.Parse("01/01/1753");
            }
            if (!string.IsNullOrEmpty(txtDataTo.Text))
            {
                DateTime dateTo;
                DateTime.TryParse(txtDataTo.Text, out dateTo);
                veicolo.ImmatricolazioneA = dateTo;
            }
            else
            {
                veicolo.ImmatricolazioneA = DateTime.MaxValue;
            }
            if (IsNoleggiato.Checked)
            {
                var noleggiato = "Si";
                veicolo.Noleggiato = noleggiato;
            }
            else if (Disponibile.Checked)
            {
                var disponibile = "No";
                veicolo.Noleggiato = disponibile;
            }
            var veicoloManager = new VeicoliManager(Settings.Default.ConnectionString);
            var veicoliModelList = veicoloManager.RicercaVeicoli(veicolo);
            Session["ListaVeicoli"] = veicoliModelList;
            gvVeicolo.DataSource = veicoliModelList;
            gvVeicolo.DataBind();

            if (veicoliModelList.Count == 0)
            {
                InfoControl.SetMessage(AppWeb.Veicoli.Controls.InfoControl.TipoMessaggio.Danger, "Attenzione non sono stati trovati veicoli con i criteri di ricerca inseriti ");
            }
            else
            {
                InfoControl.SetMessage(AppWeb.Veicoli.Controls.InfoControl.TipoMessaggio.Success, $"Ricerca completata , veicoli trovati tramite i criteri di ricerca inseriti : {veicoliModelList.Count()}");
            }
             
            if(gvVeicolo.Visible==false)
            {
                gvVeicolo.Visible = true;
            }
           

        }

       

        protected void ImageButtonCalendar_Click(object sender, ImageClickEventArgs e)
        {
            if (CalendarFrom.Visible == false)
            {
                CalendarFrom.Visible = true;
            }
            else
            {
                CalendarFrom.Visible = false;
            }
        }

        protected void ImageButtonClear_Click(object sender, ImageClickEventArgs e)
        {
            txtDataFrom.Text = string.Empty;
        }

        

        protected void CalendarBtn_Click(object sender, ImageClickEventArgs e)
        {
            if (CalendarTo.Visible == false)
            {
                CalendarTo.Visible = true;
            }
            else
            {
                CalendarTo.Visible = false;
            }
        }

        protected void clearCalendar_Click(object sender, ImageClickEventArgs e)
        {
            txtDataTo.Text = string.Empty;
        }

        protected void CalendarFrom_SelectionChanged(object sender, EventArgs e)
        {
            txtDataFrom.Text = CalendarFrom.SelectedDate.ToShortDateString();
            
            CalendarFrom.Visible = false;
        }

        
        protected void CalendarTo_SelectionChanged1(object sender, EventArgs e)
        {
            txtDataTo.Text = CalendarTo.SelectedDate.ToShortDateString();
            CalendarTo.Visible = false;
        }

        protected void Azzera_Click(object sender, EventArgs e)
        {
            if (gvVeicolo.Visible == true)
            {
                gvVeicolo.Visible = false;
            }
            DropDownMarca.ClearSelection();
            txtModello.Text = "";
            txtTarga.Text = "";
            IsNoleggiato.Checked = false;
            Disponibile.Checked = false;
            txtDataFrom.Text = "";
            txtDataTo.Text = "";
        }

        protected void gvVeicolo_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = 0;
            if (e.CommandName == "Dettaglio")
            {
                index = Convert.ToInt32(e.CommandArgument);
                var Id= gvVeicolo.DataKeys[index]["Id"].ToString();
                Response.Redirect("DettaglioVeicolo.aspx?Id=" + Id);
            }              
        }
    }
}

