using Back_End_App.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Configuration;
using System.Data;

namespace Back_End_App.Controller
{
    public class dbController
    {
        private readonly MyDBContext _context;
        private readonly IConfiguration config;
        private string ConnectionString;
        private string newConnection = @"Data Source = EDRE11; Initial Catalog = CLIENTES; Integrated Security = True";
        ResponseCodeModel response = new ResponseCodeModel();
        public dbController(MyDBContext context)
        {
            _context = context;
            ConnectionString = config.GetConnectionString("SQLConnection");
        }
        public List<Clientes> Clientes { get; set; }
        List<Pagos> pagos = new List<Pagos>();
        List<Ajuste> ajustes = new List<Ajuste>();
        public async Task<ResponseCodeModel> ClientesList()
        {
            try
            {
                if (!string.IsNullOrEmpty(ConnectionString))
                {
                    newConnection = ConnectionString;
                }
                string query = "SELECT * FROM Cliente";
                using (SqlConnection con = new SqlConnection(newConnection))
                {
                    await con.OpenAsync();
                    using (SqlCommand command = new SqlCommand(query))
                    {
                        command.CommandTimeout = 300;
                        command.CommandType = CommandType.Text;
                        command.Connection = con;

                        using(SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            if (reader.HasRows)
                            {
                                Clientes = new List<Clientes>();
                                while (await reader.ReadAsync())
                                {
                                    Clientes.Add(new Models.Clientes()
                                    {
                                        Id = (!reader.IsDBNull(0)) ? reader.GetInt32(0) : 0,
                                        Name = (!reader.IsDBNull(1)) ? reader.GetString(1) : String.Empty,
                                        Phone =(!reader.IsDBNull(2)) ? reader.GetInt64(2) : 0,
                                        Email = (!reader.IsDBNull(3)) ? reader.GetString(3) : String.Empty,
                                        Age = (!reader.IsDBNull(4)) ? reader.GetInt32(4) : 0,
                                        MontoSolicitud = (!reader.IsDBNull(5)) ? double.Parse(reader.GetSqlMoney(5).ToString()): 0,
                                        Estatus = reader.GetString(6),
                                        Aprobacion = reader.GetString(7),
                                        FechaAlta = (!reader.IsDBNull(8)) ? reader.GetDateTime(8) : DateTime.MinValue,
                                    });
                                }
                            }
                        }
                    }
                }
                response = new ResponseCodeModel()
                {
                    Success = true,
                    objectResponse = Clientes
                };
                return response;
            } 
            catch (Exception e)
            {
                return response = new ResponseCodeModel()
                {
                    Error = e.Message+" \n"+e.StackTrace,
                    Success = false,
                };
            }
        }
        public async Task<ResponseCodeModel> AjustesList()
        {
            try
            {
                if (!string.IsNullOrEmpty(ConnectionString))
                {
                    newConnection = ConnectionString;
                }
               
                string query = "SELECT * FROM Ajustes";
                using (SqlConnection con = new SqlConnection(newConnection))
                {
                    await con.OpenAsync();
                    using (SqlCommand command = new SqlCommand(query))
                    {
                        command.CommandTimeout = 300;
                        command.CommandType = CommandType.Text;
                        command.Connection = con;

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            if (reader.HasRows)
                            {
                                while (await reader.ReadAsync())
                                {
                                    ajustes.Add(new Models.Ajuste()
                                    {
                                        AjusteId = (!reader.IsDBNull(0)) ? reader.GetInt32(0) : 0,
                                        ClienteId = (!reader.IsDBNull(1)) ? reader.GetInt32(1) : 0,
                                        MontoTotal = (!reader.IsDBNull(2)) ? double.Parse(reader.GetSqlMoney(2).ToString()) : 0,
                                        Adeudo = (!reader.IsDBNull(3)) ? double.Parse(reader.GetSqlMoney(3).ToString()) : 0,
                                    });
                                }
                                
                            }
                        }
                    }
                }
                return response = new ResponseCodeModel()
                {
                    objectResponse = ajustes,
                    Success = true,
                };
            }
            catch (Exception e)
            {
                return response = new ResponseCodeModel()
                {
                    Error = $"Excepción en: {e.Message}",
                    Success = false,
                };
            }
        }
        public async Task<ResponseCodeModel> PagosList()
        {
            try
            {
                if (!string.IsNullOrEmpty(ConnectionString))
                {
                    newConnection = ConnectionString;
                }
                
                string query = "SELECT * FROM Pagos";
                using (SqlConnection con = new SqlConnection(newConnection))
                {
                    await con.OpenAsync();
                    using (SqlCommand command = new SqlCommand(query))
                    {
                        command.CommandTimeout = 300;
                        command.CommandType = CommandType.Text;
                        command.Connection = con;

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            if (reader.HasRows)
                            {
                                while (await reader.ReadAsync())
                                {
                                    pagos.Add(new Models.Pagos()
                                    {
                                        Id = (!reader.IsDBNull(0)) ? reader.GetInt32(0) : 0,
                                        Aplicado = (!reader.IsDBNull(1)) ? reader.GetInt32(1) : 0,
                                        MontoPagado = (!reader.IsDBNull(2)) ? double.Parse(reader.GetSqlMoney(2).ToString()) : 0,
                                        FechaPago = (!reader.IsDBNull(3)) ? reader.GetDateTime(3) : DateTime.MinValue,
                                    });
                                }

                            }
                        }
                    }
                }
                return response = new ResponseCodeModel()
                {
                    objectResponse = pagos,
                    Success = true,
                };
            }
            catch (Exception e)
            {
                return response = new ResponseCodeModel()
                {
                    Error = $"Excepción en: {e.Message}",
                    Success = false,
                };
            }
        }
        //public async Task<ResponseCodeModel> ActualizarMontoTotal()
        //{
        //    //me quede en el punto 4
        //}
    }
}
