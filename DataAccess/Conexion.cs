using System;
using System.Collections.Generic;
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

        // Métodos para Áreas
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

        public void AddArea(Area area)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "INSERT INTO area (idArea, nombreArea) VALUES (@idArea, @nombreArea)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@idArea", area.IdArea);
                    command.Parameters.AddWithValue("@nombreArea", area.NombreArea);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateArea(Area area)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "UPDATE area SET nombreArea = @nombreArea WHERE idArea = @idArea";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@idArea", area.IdArea);
                    command.Parameters.AddWithValue("@nombreArea", area.NombreArea);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteArea(int idArea)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "DELETE FROM area WHERE idArea = @idArea";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@idArea", idArea);
                    command.ExecuteNonQuery();
                }
            }
        }

        // Métodos para Dependencias
        public List<Dependencia> ObtenerDependencias()
        {
            var dependencias = new List<Dependencia>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "SELECT idDependencia, nombreDependencia FROM dependencia";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var dependencia = new Dependencia
                            {
                                IdDependencia = reader.GetInt32(0), // Índice basado en SELECT (idDependencia es la columna 0)
                                NombreDependencia = reader.GetString(1) // nombreDependencia es la columna 1
                            };
                            dependencias.Add(dependencia);
                        }
                    }
                }
            }

            return dependencias;
        }

        public void AddDependencia(Dependencia dependencia)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "INSERT INTO dependencia (idDependencia, nombreDependencia) VALUES (@idDependencia, @nombreDependencia)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@idDependencia", dependencia.IdDependencia);
                    command.Parameters.AddWithValue("@nombreDependencia", dependencia.NombreDependencia);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateDependencia(Dependencia dependencia)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "UPDATE dependencia SET nombreDependencia = @nombreDependencia WHERE idDependencia = @idDependencia";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@idDependencia", dependencia.IdDependencia);
                    command.Parameters.AddWithValue("@nombreDependencia", dependencia.NombreDependencia);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteDependencia(int idDependencia)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "DELETE FROM dependencia WHERE idDependencia = @idDependencia";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@idDependencia", idDependencia);
                    command.ExecuteNonQuery();
                }
            }
        }
    }

    // Clases auxiliares para las entidades
    public class Area
    {
        public int IdArea { get; set; }
        public string NombreArea { get; set; }
    }

    public class Dependencia
    {
        public int IdDependencia { get; set; }
        public string NombreDependencia { get; set; }
    }
}
