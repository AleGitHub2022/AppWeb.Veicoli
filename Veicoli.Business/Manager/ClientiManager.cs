using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veicoli.Business.Models;
using VeicoliBusiness.Models;

namespace Veicoli.Business.Manager
{
    public class ClientiManager
    {
        public string ConnectionString { get; set; }
        public ClientiManager(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        public void DeleteCliente(int Id)
        {
            var sb = new StringBuilder();
            sb.AppendLine("DELETE");
            sb.AppendLine("FROM");
            sb.AppendLine("[dbo].[BA_Clienti]");
            sb.AppendLine("WHERE [IdVeicoloNoleggiato]=@Id");
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
        public PersonaModel GetAnagraficaCliente(VeicoliModel veicolo)
        {
            
            var cliente = new PersonaModel();

            var sb = new StringBuilder();
            sb.AppendLine("SELECT");
            sb.AppendLine("\t[Nome]");
            sb.AppendLine("\t,[Cognome]");
            sb.AppendLine("\t,[DataDiNascita]");
            sb.AppendLine("\t,[Residenza]");
            sb.AppendLine("\t,[Provincia]");
            sb.AppendLine("\t,[Comune]");
            sb.AppendLine("\t,[Telefono]");
            sb.AppendLine("FROM[dbo].[BA_Clienti]");
            sb.AppendLine("WHERE[IdVeicoloNoleggiato]=@Id");

            var dataSet = new DataSet();
            using (SqlConnection connection = new SqlConnection(Settings.Default.ConnectionString))
            {
                connection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(sb.ToString()))
                {

                    sqlCommand.Parameters.AddWithValue("@Id", veicolo.Id);


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

                        cliente.Nome = row.Field<string>("Nome");
                        cliente.Cognome = row.Field<string>("Cognome");
                        cliente.DataDiNascita = row.Field<DateTime>("DataDiNascita");
                        cliente.Residenza = row.Field<string>("Residenza");
                        cliente.Provincia = row.Field<string>("Provincia");
                        cliente.Comune = row.Field<string>("Comune");
                        cliente.Telefono = row.Field<string>("Telefono");

                    }

                }

                return cliente;


            }

        }
        public bool InsertClientiDB(PersonaModel  personaModel,int id)
        {
            bool isInserito = false;
            var sb = new StringBuilder();
            sb.AppendLine("INSERT INTO[dbo].[BA_Clienti]");
            sb.AppendLine("\t (");
            sb.AppendLine("\t [IdVeicoloNoleggiato]");
            sb.AppendLine("\t ,[Nome]");
            sb.AppendLine("\t,[Cognome]");
            sb.AppendLine("\t,[DataDiNascita]");
            sb.AppendLine("\t,[Comune]");
            sb.AppendLine("\t,[Provincia]");
            sb.AppendLine("\t,[Residenza]");
            sb.AppendLine("\t,[Telefono]");
            sb.AppendLine("\t )");
            sb.AppendLine("VALUES");
            sb.AppendLine("\t (");
            sb.AppendLine("\t @IdVeicoloNoleggiato");
            sb.AppendLine("\t ,@Nome");
            sb.AppendLine("\t,@Cognome");
            sb.AppendLine("\t,@DataDiNascita");
            sb.AppendLine("\t,@Comune");
            sb.AppendLine("\t,@Provincia");
            sb.AppendLine("\t,@Residenza");
            sb.AppendLine("\t,@Telefono");
            sb.AppendLine("\t )");


            using (SqlConnection connection = new SqlConnection(Settings.Default.ConnectionString))
            {
                connection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(sb.ToString(), connection))
                {

                    if (id>0)
                    {
                        sqlCommand.Parameters.AddWithValue("@IdVeicoloNoleggiato", id);
                    }
                    
                    if (string.IsNullOrEmpty(personaModel.Nome))
                    {
                        sqlCommand.Parameters.AddWithValue("@Nome", DBNull.Value);
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@Nome", personaModel.Nome);
                    }
                    if (string.IsNullOrEmpty(personaModel.Cognome))
                    {
                        sqlCommand.Parameters.AddWithValue("@Cognome", DBNull.Value);
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@Cognome", personaModel.Cognome);
                    }
                    if (string.IsNullOrEmpty(personaModel.Comune))
                    {
                        sqlCommand.Parameters.AddWithValue("@Comune", DBNull.Value);
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@Comune", personaModel.Comune);
                    }
                    if (personaModel.DataDiNascita.HasValue)
                    {

                        sqlCommand.Parameters.AddWithValue("@DataDiNascita", personaModel.DataDiNascita);
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@DataDiNascita", DBNull.Value);
                    }
                    if (string.IsNullOrEmpty(personaModel.Provincia))
                    {
                        
                        sqlCommand.Parameters.AddWithValue("@Provincia", DBNull.Value);
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@Provincia", personaModel.Provincia);
                    }
                    if (string.IsNullOrEmpty(personaModel.Residenza))
                    {
                        sqlCommand.Parameters.AddWithValue("@Residenza", DBNull.Value);
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@Residenza", personaModel.Residenza);
                    }
                    if (string.IsNullOrEmpty(personaModel.Telefono))
                    {
                        sqlCommand.Parameters.AddWithValue("@Telefono", DBNull.Value);
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@Telefono", personaModel.Telefono);
                    }


                    var numInsertRow = sqlCommand.ExecuteNonQuery();
                }

            }

            return isInserito;

        }
    }
}

