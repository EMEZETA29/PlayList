using PlayList.DATOS.Repositorios;
using System.Data.SqlClient;

namespace PlayList.DATOS
{
    public class GeneroRepositorio : IGeneroRepositorio
    {
        private readonly IConfiguration _configuration;

        public GeneroRepositorio(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public List<Genero> ObtenerTodas()
        {
            var listaGeneros = new List<Genero>();
            using SqlConnection sql = new SqlConnection(_configuration.GetConnectionString("conexionPorDefecto"));
            using SqlCommand cmd = new SqlCommand("sp_obtener_generos", sql);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            sql.Open();
            using(var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    var nuevoGenero = new Genero { IDGenero = (int)reader["IDGenero"], NombreGenero = reader["NombreGenero"].ToString() };
                    listaGeneros.Add(nuevoGenero);
                }
            }

            return listaGeneros;
        }

        public void CrearGenero(Genero genero)
        {
            using SqlConnection sql = new SqlConnection(_configuration.GetConnectionString("conexionPorDefecto"));
            using SqlCommand cmd = new SqlCommand("sp_insertar_genero", sql);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@nombre", genero.NombreGenero));
            sql.Open();
            cmd.ExecuteNonQuery();
        }

        public Genero ObtenerPorId(int id)
        {
            var genero = new Genero();
            using SqlConnection sql = new SqlConnection(_configuration.GetConnectionString("conexionPorDefecto"));
            using SqlCommand cmd = new SqlCommand("sp_obtener_genero_por_id", sql);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@id", id));
            sql.Open();
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    var nuevoGenero = new Genero { IDGenero = (int)reader["IDGenero"], NombreGenero = reader["NombreGenero"].ToString() };
                    genero = nuevoGenero;
                }
            }

            return genero;
        }

        public void ActualizarGenero(Genero genero)
        {
            using SqlConnection sql = new SqlConnection(_configuration.GetConnectionString("conexionPorDefecto"));
            using SqlCommand cmd = new SqlCommand("sp_actualiza_genero", sql);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@id", genero.IDGenero));
            cmd.Parameters.Add(new SqlParameter("@nombre", genero.NombreGenero));
            sql.Open();
            cmd.ExecuteNonQuery();
        }
        public void EliminarGenero(int id)
        {
            using SqlConnection sql = new SqlConnection(_configuration.GetConnectionString("conexionPorDefecto"));
            using SqlCommand cmd = new SqlCommand("sp_eliminar_genero", sql);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@id", id));
            sql.Open();
            cmd.ExecuteNonQuery();
        }
    }
}
