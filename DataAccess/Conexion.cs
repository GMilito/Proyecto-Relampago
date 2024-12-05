using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace DataAccess
{
    public class Conexion
    {
        private readonly string _connectionString;

        public Conexion(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public List<Area> ObtenerAreas()
        {
            var areas = new List<Area>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "SELECT idArea, nombreArea FROM area";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var area = new Area
                            {
                                IdArea = reader.GetInt32(0), // Índice basado en SELECT (idArea es la columna 0)
                                NombreArea = reader.GetString(1) // nombreArea es la columna 1
                            };
                            areas.Add(area);
                        }
                    }
                }
            }

            return areas;
        }
        


    }
}



public class Area
{
    public int IdArea { get; set; }
    public string NombreArea { get; set; }
}