using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration.UserSecrets;
using PlayList.DATOS.Entidades;
using System.Data.SqlClient;

namespace PlayList.DATOS.Repositorios
{
    public class InterpreteRepositorio : IInterpreteRepositorio
    {
        private readonly IConfiguration _configuration;

        public InterpreteRepositorio(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<Interpretes> ObtenerTodos()
        {
            var listaInterpretes = new List<Interpretes>();
            using SqlConnection sql = new SqlConnection(_configuration.GetConnectionString("conexionPorDefecto"));
            using SqlCommand cmd = new SqlCommand("sp_obtener_interpretes", sql);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            sql.Open();
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    var nuevoInterprete = new Interpretes
                    {
                        IDInterprete = (int)reader["IDInterprete"],
                        NombreInterprete = reader["NombreInterprete"].ToString(),
                        FechaNacimiento= reader["FechaNacimiento"]== DBNull.Value ? null : (DateTime)reader["FechaNacimiento"],
                        Pais = reader["Pais"].ToString(),
                        ImagenUrl = reader["ImagenUrl"].ToString(),
                        Genero = reader["Genero"].ToString()
                    };
                    listaInterpretes.Add(nuevoInterprete);
                    
                }
            }

            return listaInterpretes;
        }

        public void CrearInterprete(Interpretes interprete)
        {
            using SqlConnection sql = new SqlConnection(_configuration.GetConnectionString("conexionPorDefecto"));
            using SqlCommand cmd = new SqlCommand("sp_insertar_interprete", sql);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@NombreInterprete", interprete.NombreInterprete));
            cmd.Parameters.Add(new SqlParameter("@FechaNacimiento", interprete.FechaNacimiento == null ? DBNull.Value : interprete.FechaNacimiento));
            cmd.Parameters.Add(new SqlParameter("@Pais", interprete.Pais == null ? DBNull.Value : interprete.Pais));
            cmd.Parameters.Add(new SqlParameter("@ImagenUrl", interprete.ImagenUrl == null ? DBNull.Value : interprete.ImagenUrl ));
            cmd.Parameters.Add(new SqlParameter("@GeneroID", interprete.GeneroID));
            sql.Open();
            cmd.ExecuteNonQuery();
        }

        public Interpretes ObtenerPorId(int id)
        {
            var interprete = new Interpretes();
            using SqlConnection sql = new SqlConnection(_configuration.GetConnectionString("conexionPorDefecto"));
            using SqlCommand cmd = new SqlCommand("sp_obtener_interpretes_por_id", sql);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@id", id));
            sql.Open();
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    var nuevoInterprete = new Interpretes
                    {
                        IDInterprete = (int)reader["IDInterprete"],
                        NombreInterprete = reader["NombreInterprete"].ToString(),
                        FechaNacimiento = reader["FechaNacimiento"] == DBNull.Value ? null :  Convert.ToDateTime(reader["FechaNacimiento"]),
                        Pais = reader["Pais"].ToString(),
                        ImagenUrl = reader["ImagenUrl"].ToString(),
                        GeneroID = (int)reader["GeneroID"]
                    };
                    interprete = nuevoInterprete;
                }
            }

            return interprete;

        }

        public void ActualizarInterprete(Interpretes interprete)
        {
            using SqlConnection sql = new SqlConnection(_configuration.GetConnectionString("conexionPorDefecto"));
            using SqlCommand cmd = new SqlCommand("sp_actualiza_interprete", sql);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@IDInterprete", interprete.IDInterprete));
            cmd.Parameters.Add(new SqlParameter("@NombreInterprete", interprete.NombreInterprete));
            cmd.Parameters.Add(new SqlParameter("@FechaNacimiento", interprete.FechaNacimiento == null ? DBNull.Value : interprete.FechaNacimiento));
            cmd.Parameters.Add(new SqlParameter("@Pais", interprete.Pais == null ? DBNull.Value : interprete.Pais));
            cmd.Parameters.Add(new SqlParameter("@ImagenUrl", interprete.ImagenUrl == null ? DBNull.Value : interprete.ImagenUrl));
            cmd.Parameters.Add(new SqlParameter("@GeneroID", interprete.GeneroID));
            sql.Open();
            cmd.ExecuteNonQuery();
        }

        public void EliminarInterprete(int id)
        {
            using SqlConnection sql = new SqlConnection(_configuration.GetConnectionString("conexionPorDefecto"));
            using SqlCommand cmd = new SqlCommand("sp_eliminar_interprete", sql);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@id", id));
            sql.Open();
            cmd.ExecuteNonQuery();
        }
    }
}
