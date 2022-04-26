using System;
using System.Activities.Statements;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veicoli.Business.Models;
using Veicoli.Business.Properties;
using VeicoliBusiness.Models;

namespace VeicoliBusiness.Manager
{
    public class VeicoliManager
    {
        
        public VeicoliManager(string connectionString)
        {
            this.ConnectionString = connectionString;
        }
        public string ConnectionString { get; set; }
        public bool InsertVeicoliDB(VeicoliModel veicoliModel)
        {
            bool isInserito = false;
            var sb = new StringBuilder();
            sb.AppendLine("INSERT INTO[dbo].[BA_Veicoli]");
            sb.AppendLine("([IdMarca]");
            sb.AppendLine(",[Modello]");
            sb.AppendLine(",[Targa]");
            sb.AppendLine(",[Immatricolazione]");
            sb.AppendLine(",[IdAlimentazione]");
            sb.AppendLine(",[Noleggiato]");
            sb.AppendLine(",[Note])");
            sb.AppendLine("VALUES");
            sb.AppendLine("(@IdMarca");
            sb.AppendLine(",@Modello");
            sb.AppendLine(",@Targa");
            sb.AppendLine(",@Immatricolazione");
            sb.AppendLine(",@IdAlimentazione");
            sb.AppendLine(",@Noleggiato");
            sb.AppendLine(",@Note)");


            using (SqlConnection connection = new SqlConnection(Settings.Default.ConnectionString))
            {
                connection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(sb.ToString(), connection))
                {
                    if (veicoliModel.IdMarca > 0)
                    {
                        sqlCommand.Parameters.AddWithValue("@IdMarca", veicoliModel.IdMarca);
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@IdMarca", DBNull.Value);
                    }
                    if (string.IsNullOrEmpty(veicoliModel.Modello))
                    {
                        sqlCommand.Parameters.AddWithValue("@Modello", DBNull.Value);
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@Modello", veicoliModel.Modello);
                    }
                    if (string.IsNullOrEmpty(veicoliModel.Targa))
                    {
                        sqlCommand.Parameters.AddWithValue("@Targa", DBNull.Value);
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@Targa", veicoliModel.Targa);
                    }
                    if (veicoliModel.Immatricolazione.HasValue)
                    {

                        sqlCommand.Parameters.AddWithValue("@Immatricolazione", veicoliModel.Immatricolazione);
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@Immatricolazione", DBNull.Value);
                    }
                    if (veicoliModel.IdTipoAlimentazione > 0)
                    {
                        sqlCommand.Parameters.AddWithValue("@IdAlimentazione", veicoliModel.IdTipoAlimentazione);

                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@IdAlimentazione", DBNull.Value);
                    }
                    if (string.IsNullOrEmpty(veicoliModel.Noleggiato))
                    {
                        sqlCommand.Parameters.AddWithValue("@Noleggiato", DBNull.Value);
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@Noleggiato", veicoliModel.Noleggiato);
                    }
                    if (string.IsNullOrEmpty(veicoliModel.Note))
                    {
                        sqlCommand.Parameters.AddWithValue("@Note", DBNull.Value);
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@Note", veicoliModel.Note);
                    }


                    var numInsertRow = sqlCommand.ExecuteNonQuery();
                }

            }

            return isInserito;

        }
        public List<VeicoliModel> RicercaVeicoli(RicercaVeicoloModel ricercaVeicolo)
        {
            var veicoliList = new List<VeicoliModel>();
            var sb = new StringBuilder();
            sb.AppendLine("SELECT");
            sb.AppendLine("\t[BA_Veicoli].[Id]");
            sb.AppendLine("\t,[Marca]");
            sb.AppendLine("\t,[Modello]");
            sb.AppendLine("\t,[Targa]");
            sb.AppendLine("\t,[Immatricolazione]");
            sb.AppendLine("\t,[Noleggiato]");
            sb.AppendLine("FROM[dbo].[BA_Veicoli]");
            sb.AppendLine("\t inner join BA_Marca");
            sb.AppendLine("\t on BA_Veicoli.IdMarca = BA_Marca.Id ");
            sb.AppendLine("where 1=1");
           


            if (ricercaVeicolo.IdMarca > 0)
            {
                sb.AppendLine("And IdMarca=@IdMarca");
            }
            if (!string.IsNullOrEmpty(ricercaVeicolo.Marca))
            {
                sb.AppendLine("And Marca=@Marca");
            }
            if (!string.IsNullOrEmpty(ricercaVeicolo.Modello))
            {
                sb.AppendLine("And Modello like @Modello");
            }

            if (!string.IsNullOrEmpty(ricercaVeicolo.Targa))
            {
                sb.AppendLine("And Targa like @Targa");
            }

            if (ricercaVeicolo.ImmatricolazioneDa.HasValue)
            {
                sb.AppendLine("and Immatricolazione between @ImmatricolazioneDa");
            }
            if (ricercaVeicolo.ImmatricolazioneA.HasValue)
            {
                sb.AppendLine("And @ImmatricolazioneA");
            }

            if (!string.IsNullOrEmpty(ricercaVeicolo.Noleggiato))
            {
                sb.AppendLine("And Noleggiato=@Noleggiato");
            }

                  sb.AppendLine("order by [Marca] Asc");
            var dataSet = new DataSet();
            using (SqlConnection connection = new SqlConnection(Settings.Default.ConnectionString))
            {
                connection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(sb.ToString()))
                {


                    if (ricercaVeicolo.IdMarca > 0)
                    {
                        sqlCommand.Parameters.AddWithValue("@IdMarca", ricercaVeicolo.IdMarca);
                    }

                    if (!string.IsNullOrEmpty(ricercaVeicolo.Marca))
                    {
                        sqlCommand.Parameters.AddWithValue("@Marca", ricercaVeicolo.Marca);
                    }
                    if (!string.IsNullOrEmpty(ricercaVeicolo.Modello))
                    {
                        sqlCommand.Parameters.AddWithValue("@Modello", $"{ricercaVeicolo.Modello}%");
                    }

                    if (!string.IsNullOrEmpty(ricercaVeicolo.Targa))
                    {
                        sqlCommand.Parameters.AddWithValue("@Targa", $"{ricercaVeicolo.Targa}%");

                    }

                    if (ricercaVeicolo.ImmatricolazioneDa.HasValue)
                    {
                        sqlCommand.Parameters.AddWithValue("@ImmatricolazioneDa", ricercaVeicolo.ImmatricolazioneDa);
                    }
                    if (ricercaVeicolo.ImmatricolazioneA.HasValue)
                    {
                        sqlCommand.Parameters.AddWithValue("@ImmatricolazioneA", ricercaVeicolo.ImmatricolazioneA);
                    }
                    if (!string.IsNullOrEmpty(ricercaVeicolo.Noleggiato))
                    {
                        sqlCommand.Parameters.AddWithValue("@Noleggiato", ricercaVeicolo.Noleggiato);
                    }
                    using (var sqlDataAdapter = new SqlDataAdapter(sqlCommand))
                    {
                        sqlDataAdapter.SelectCommand = sqlCommand;
                        sqlDataAdapter.SelectCommand.Connection = connection;
                        sqlDataAdapter.Fill(dataSet);

                        var dataTable = dataSet.Tables[0];
                        foreach (DataRow row in dataTable.Rows)
                        {
                            var veicoloModel = new VeicoliModel();
                            veicoloModel.Id = row.Field<int>("Id");
                            veicoloModel.Marca = row.Field<string>("Marca");
                            veicoloModel.Modello = row.Field<string>("Modello");
                            veicoloModel.Immatricolazione = row.Field<DateTime?>("Immatricolazione");
                            veicoloModel.Noleggiato = row.Field<string>("Noleggiato");
                            veicoliList.Add(veicoloModel);
                        }
                    }
                }
            }
            return veicoliList;
        }
        public VeicoliModel GetVeicolo(int Id)
        {

            var veicolomodel = new VeicoliModel();

            var sb = new StringBuilder();
            sb.AppendLine("SELECT");
            sb.AppendLine("\t[BA_Veicoli].[Id]");
            sb.AppendLine("\t,[IdMarca]");
            sb.AppendLine("\t,[Marca]");
            sb.AppendLine("\t,[Modello]");
            sb.AppendLine("\t,[Targa]");
            sb.AppendLine("\t,[Immatricolazione]");
            sb.AppendLine("\t,[IdAlimentazione]");
            sb.AppendLine("\t,[Alimentazione]");
            sb.AppendLine("\t,[Noleggiato]");
            sb.AppendLine("\t,[Nominativo]");
            sb.AppendLine("\t,[Note]");
            sb.AppendLine("FROM[dbo].[BA_Veicoli]");
            sb.AppendLine("\t INNER JOIN BA_Marca");
            sb.AppendLine("\t on BA_Veicoli.IdMarca = BA_Marca.Id ");
            sb.AppendLine("\t INNER JOIN BA_Alimentazione");
            sb.AppendLine("\t on BA_Veicoli.IdAlimentazione = BA_Alimentazione.Id ");
            sb.AppendLine("WHERE BA_Veicoli.[Id]=@Id");

            var dataSet = new DataSet();
            using (SqlConnection connection = new SqlConnection(Settings.Default.ConnectionString))
            {
                connection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(sb.ToString()))
                {

                    sqlCommand.Parameters.AddWithValue("@Id", Id);


                    using (var sqlDataAdapter = new SqlDataAdapter(sqlCommand))
                    {
                        sqlDataAdapter.SelectCommand = sqlCommand;
                        sqlDataAdapter.SelectCommand.Connection = connection;
                        sqlDataAdapter.Fill(dataSet);
                        var dataTable = dataSet.Tables[0];
                        if (dataTable.Rows.Count == 0)
                        {
                            return null;
                        }

                        DataRow row = dataTable.Rows[0];
                        veicolomodel.Id = row.Field<int>("Id");
                        veicolomodel.IdTipoAlimentazione = row.Field<int>("IdAlimentazione");
                        veicolomodel.Marca = row.Field<string>("Marca");
                        veicolomodel.IdMarca = row.Field<int>("IdMarca");
                        veicolomodel.Alimentazione = row.Field<string>("Alimentazione");
                        veicolomodel.Modello = row.Field<string>("Modello");
                        veicolomodel.Targa = row.Field<string>("Targa");
                        veicolomodel.Immatricolazione = row.Field<DateTime>("Immatricolazione");
                        veicolomodel.Noleggiato = row.Field<string>("Noleggiato");
                        veicolomodel.Nominativo = row.Field<string>("Nominativo");
                        veicolomodel.Note = row.Field<string>("Note");

                    }

                }

                return veicolomodel;


            }

        }

        public void DeleteVeicolo(int Id)
        {
            var sb = new StringBuilder();
            sb.AppendLine("DELETE");
            sb.AppendLine("FROM");
            sb.AppendLine("[dbo].[BA_Veicoli]");
            sb.AppendLine("WHERE [Id]=@Id");
            using (SqlConnection connection = new SqlConnection(Settings.Default.ConnectionString))
            {
                connection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(sb.ToString(), connection))
                {
                    sqlCommand.Parameters.AddWithValue("@Id", Id);

                    var delete = sqlCommand.ExecuteNonQuery();
                }
            }

        }
        public void UpdateVeicolo(VeicoliModel veicoliModel)
        {


            var sb = new StringBuilder();
            sb.AppendLine("UPDATE");
            sb.AppendLine("[dbo].[BA_Veicoli]");
            sb.AppendLine("SET");
            sb.AppendLine("\t[IdMarca]=@IdMarca");
            sb.AppendLine("\t,[Modello]=@Modello");
            sb.AppendLine("\t,[Targa]=@Targa");
            sb.AppendLine("\t,[Immatricolazione]=@Immatricolazione");
            sb.AppendLine("\t,[IdAlimentazione]=@IdAlimentazione");
            sb.AppendLine("\t,[Note]=@Note");
            sb.AppendLine("WHERE [Id]=@Id");

            var dataSet = new DataSet();
            using (SqlConnection connection = new SqlConnection(Settings.Default.ConnectionString))
            {
                connection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(sb.ToString(), connection))
                {


                    sqlCommand.Parameters.AddWithValue("@Id", veicoliModel.Id);

                    if (veicoliModel.IdMarca > 0)
                    {
                        sqlCommand.Parameters.AddWithValue("@IdMarca", veicoliModel.IdMarca);
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@IdMarca", DBNull.Value);
                    }

                    if (!string.IsNullOrEmpty(veicoliModel.Modello))
                    {
                        sqlCommand.Parameters.AddWithValue("@Modello", veicoliModel.Modello);
                    }

                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@Modello", DBNull.Value);
                    }
                    if (!string.IsNullOrEmpty(veicoliModel.Targa))
                    {
                        sqlCommand.Parameters.AddWithValue("@Targa", veicoliModel.Targa);
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@Targa", DBNull.Value);
                    }
                    if (veicoliModel.Immatricolazione.HasValue)
                    {
                        sqlCommand.Parameters.AddWithValue("@Immatricolazione", veicoliModel.Immatricolazione);
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@Immatricolazione", DBNull.Value);
                    }
                    if (veicoliModel.IdTipoAlimentazione > 0)
                    {
                        sqlCommand.Parameters.AddWithValue("@IdAlimentazione", veicoliModel.IdTipoAlimentazione);
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@IdAlimentazione", DBNull.Value);
                    }
                    if (!string.IsNullOrEmpty(veicoliModel.Note))
                    {
                        sqlCommand.Parameters.AddWithValue("@Note", veicoliModel.Note);
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@Note", DBNull.Value);
                    }

                    var Update = sqlCommand.ExecuteNonQuery();


                }
            }


        }
        public bool UpdateNoleggio(VeicoliModel veicoliModel, PersonaModel persona)
        {
            bool isNoleggiato = false;
            var sb = new StringBuilder();
            sb.AppendLine("UPDATE");
            sb.AppendLine("[dbo].[BA_Veicoli]");
            sb.AppendLine("SET");
            sb.AppendLine("\t[Noleggiato]=@Noleggiato");
            sb.AppendLine("\t,[Nominativo]=@Nominativo");

            sb.AppendLine("WHERE [Id]=@Id");
            using (SqlConnection connection = new SqlConnection(Settings.Default.ConnectionString))
            {
                connection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(sb.ToString(), connection))
                {


                    sqlCommand.Parameters.AddWithValue("@Id", veicoliModel.Id);

                    //sqlCommand.Parameters.AddWithValue("@IdClienti", persona.Id);

                    sqlCommand.Parameters.AddWithValue("@Noleggiato", "Si");


                    if (string.IsNullOrEmpty(veicoliModel.Nominativo))
                    {
                        sqlCommand.Parameters.AddWithValue("@Nominativo", $"{persona.Nome}" + " " + $"{persona.Cognome}");
                    }

                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@Nominativo", DBNull.Value);
                    }


                    var Update = sqlCommand.ExecuteNonQuery();
                }
            }
            return isNoleggiato;
        }
        public bool EndNoleggio(VeicoliModel veicoliModel)
        {
            bool isNoleggiato = false;
            var sb = new StringBuilder();
            sb.AppendLine("UPDATE");
            sb.AppendLine("[dbo].[BA_Veicoli]");
            sb.AppendLine("SET");
            sb.AppendLine("\t[Noleggiato]=@Noleggiato");
            sb.AppendLine("\t,[Nominativo]=@Nominativo");

            sb.AppendLine("WHERE [Id]=@Id");
            using (SqlConnection connection = new SqlConnection(Settings.Default.ConnectionString))
            {
                connection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(sb.ToString(), connection))
                {


                    sqlCommand.Parameters.AddWithValue("@Id", veicoliModel.Id);

                    

                    sqlCommand.Parameters.AddWithValue("@Noleggiato", "No");

                    sqlCommand.Parameters.AddWithValue("@Nominativo", DBNull.Value);
                    

                    var Update = sqlCommand.ExecuteNonQuery();
                }
            }
            return isNoleggiato;
        }
    
        
        public List<MarcaModel> GetListMarche()
        {
            var listMarche = new List<MarcaModel>();

            var sb = new StringBuilder();
            sb.AppendLine("SELECT");
            sb.AppendLine("\t[Id]");
            sb.AppendLine("\t,[Marca]");
            sb.AppendLine("FROM[dbo].[BA_Marca]");
            sb.AppendLine("order by [Marca] Asc");
            var dataSet = new DataSet();
            using (SqlConnection connection = new SqlConnection(Settings.Default.ConnectionString))
            {
                connection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(sb.ToString()))
                {
                    using (var sqlDataAdapter = new SqlDataAdapter(sqlCommand))
                    {
                        sqlDataAdapter.SelectCommand = sqlCommand;
                        sqlDataAdapter.SelectCommand.Connection = connection;
                        sqlDataAdapter.Fill(dataSet);

                        var dataTable = dataSet.Tables[0];
                        foreach (DataRow row in dataTable.Rows)
                        {
                            var marca = new MarcaModel();
                            marca.Id = row.Field<int>("Id");
                            marca.Marca = row.Field<string>("Marca");

                            listMarche.Add(marca);
                        }


                        return listMarche;
                    }
                }
            }
        }
        public List<AlimentazioneModel> GetListTipoAlimentazione()
        {
            var listTipoAlimentazione = new List<AlimentazioneModel>();

            var sb = new StringBuilder();
            sb.AppendLine("SELECT");
            sb.AppendLine("\t[Id]");
            sb.AppendLine("\t,[Alimentazione]");
            sb.AppendLine("FROM[dbo].[BA_Alimentazione]");
            var dataSet = new DataSet();
            using (SqlConnection connection = new SqlConnection(Settings.Default.ConnectionString))
            {
                connection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(sb.ToString()))
                {
                    using (var sqlDataAdapter = new SqlDataAdapter(sqlCommand))
                    {
                        sqlDataAdapter.SelectCommand = sqlCommand;
                        sqlDataAdapter.SelectCommand.Connection = connection;
                        sqlDataAdapter.Fill(dataSet);

                        var dataTable = dataSet.Tables[0];
                        foreach (DataRow row in dataTable.Rows)
                        {
                            var tipoAlimentazione = new AlimentazioneModel();
                            tipoAlimentazione.Id = row.Field<int>("Id");
                            tipoAlimentazione.Alimentazione = row.Field<string>("Alimentazione");

                            listTipoAlimentazione.Add(tipoAlimentazione);
                        }


                        return listTipoAlimentazione;
                    }
                }
            }
        }
        public string ControlloTarga(VeicoliModel veicoliModel)
        {
            var Targa = "";

            var sb = new StringBuilder();
            sb.AppendLine("SELECT");
            sb.AppendLine("\t[Targa]");
            sb.AppendLine("FROM[dbo].[BA_Veicoli]");
            sb.AppendLine("Where Targa LIKE @Targa");


            var dataSet = new DataSet();
            using (SqlConnection connection = new SqlConnection(Settings.Default.ConnectionString))
            {
                connection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(sb.ToString()))
                {

                    if (!string.IsNullOrEmpty(veicoliModel.Targa))
                    {
                        sqlCommand.Parameters.AddWithValue("@Targa", $"{veicoliModel.Targa}");
                    }
                    using (var sqlDataAdapter = new SqlDataAdapter(sqlCommand))
                    {
                        sqlDataAdapter.SelectCommand = sqlCommand;
                        sqlDataAdapter.SelectCommand.Connection = connection;
                        sqlDataAdapter.Fill(dataSet);

                        var dataTable = dataSet.Tables[0];
                        foreach (DataRow row in dataTable.Rows)
                        {
                            var veicoloModel = new VeicoliModel();
                            veicoloModel.Targa = row.Field<string>("Targa");
                            Targa = veicoliModel.Targa;
                        }
                    }
                }
            }
            return Targa;
        }

        public List<VeicoliModel> GetVeicoliDisponibili()

        {
            var veicoliList = new List<VeicoliModel>();
            var sb = new StringBuilder();
            sb.AppendLine("SELECT");
            sb.AppendLine("\t[Marca]");
            sb.AppendLine("\t,[Modello]");
            sb.AppendLine("\t,[Targa]");
            sb.AppendLine("\t,[Alimentazione]");
            sb.AppendLine("\t,[Immatricolazione]");
            sb.AppendLine("FROM[dbo].[BA_Veicoli]");
            sb.AppendLine("\t inner join BA_Marca");
            sb.AppendLine("\t on BA_Veicoli.IdMarca = BA_Marca.Id ");
            sb.AppendLine("\t inner join BA_Alimentazione");
            sb.AppendLine("\t on BA_Veicoli.IdAlimentazione = BA_Alimentazione.Id ");
            sb.AppendLine("where [Noleggiato]=@Noleggiato");
            sb.AppendLine("order by [Marca] Asc");

            var dataSet = new DataSet();
            using (SqlConnection connection = new SqlConnection(Settings.Default.ConnectionString))
            {
                connection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(sb.ToString()))
                {

                    sqlCommand.Parameters.AddWithValue("@Noleggiato", "No");

                    using (var sqlDataAdapter = new SqlDataAdapter(sqlCommand))
                    {
                        sqlDataAdapter.SelectCommand = sqlCommand;
                        sqlDataAdapter.SelectCommand.Connection = connection;
                        sqlDataAdapter.Fill(dataSet);

                        var dataTable = dataSet.Tables[0];
                        foreach (DataRow row in dataTable.Rows)
                        {
                            var veicoloModel = new VeicoliModel();

                            veicoloModel.Marca = row.Field<string>("Marca");
                            veicoloModel.Modello = row.Field<string>("Modello");
                            veicoloModel.Targa = row.Field<string>("Targa");
                            veicoloModel.Alimentazione = row.Field<string>("Alimentazione");
                            veicoloModel.Immatricolazione = row.Field<DateTime?>("Immatricolazione");

                            veicoliList.Add(veicoloModel);
                        }
                    }
                }
            }


            return veicoliList;
        }

        public List<VeicoliModel> GetVeicoliNoleggiati()

        {
            var veicoliList = new List<VeicoliModel>();
            var sb = new StringBuilder();
            sb.AppendLine("SELECT");
            sb.AppendLine("\t[Marca]");
            sb.AppendLine("\t,[Modello]");
            sb.AppendLine("\t,[Targa]");
            sb.AppendLine("\t,[Alimentazione]");
            sb.AppendLine("\t,[Immatricolazione]");
            sb.AppendLine("\t,[Nominativo]");
            sb.AppendLine("FROM[dbo].[BA_Veicoli]");
            sb.AppendLine("\t inner join BA_Marca");
            sb.AppendLine("\t on BA_Veicoli.IdMarca = BA_Marca.Id ");
            sb.AppendLine("\t inner join BA_Alimentazione");
            sb.AppendLine("\t on BA_Veicoli.IdAlimentazione = BA_Alimentazione.Id ");
            sb.AppendLine("where [Noleggiato]=@Noleggiato");
            sb.AppendLine("order by [Marca] Asc");

            var dataSet = new DataSet();
            using (SqlConnection connection = new SqlConnection(Settings.Default.ConnectionString))
            {
                connection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(sb.ToString()))
                {

                    sqlCommand.Parameters.AddWithValue("@Noleggiato", "Si");

                    using (var sqlDataAdapter = new SqlDataAdapter(sqlCommand))
                    {
                        sqlDataAdapter.SelectCommand = sqlCommand;
                        sqlDataAdapter.SelectCommand.Connection = connection;
                        sqlDataAdapter.Fill(dataSet);

                        var dataTable = dataSet.Tables[0];
                        foreach (DataRow row in dataTable.Rows)
                        {
                            var veicoloModel = new VeicoliModel();

                            veicoloModel.Marca = row.Field<string>("Marca");
                            veicoloModel.Modello = row.Field<string>("Modello");
                            veicoloModel.Targa = row.Field<string>("Targa");
                            veicoloModel.Alimentazione = row.Field<string>("Alimentazione");
                            veicoloModel.Immatricolazione = row.Field<DateTime?>("Immatricolazione");
                            veicoloModel.Nominativo = row.Field<string>("Nominativo");

                            veicoliList.Add(veicoloModel);
                        }
                    }
                }
            }


            return veicoliList;
        }

    }
            
    
}
        



