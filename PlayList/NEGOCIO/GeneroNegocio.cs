using PlayList.DATOS;
using PlayList.DATOS.Repositorios;
using PlayList.DTO;

namespace PlayList.NEGOCIO
{
    public class GeneroNegocio : IGeneroNegocio
    {
        private readonly IGeneroRepositorio _generoRepositorio;

        public GeneroNegocio(IGeneroRepositorio generoRepositorio)
        {
            _generoRepositorio = generoRepositorio;
        }
        public List<GeneroDTO> ObtenerGeneros()
        {
            var listaGenerosDTO = new List<GeneroDTO>();
            var listaGeneroEntidades = _generoRepositorio.ObtenerTodas();
            foreach (var genero in listaGeneroEntidades)
            {
                var generoDTO = new GeneroDTO { IDGenero = genero.IDGenero, NombreGenero = genero.NombreGenero };
                listaGenerosDTO.Add(generoDTO);
            }

            return listaGenerosDTO;
        }

        public void CrearGenero(GeneroDTO generoDTO)
        {
            var genero = new Genero { NombreGenero = generoDTO.NombreGenero };
            _generoRepositorio.CrearGenero(genero);
        }

        public GeneroDTO ObtenerGeneroPorId(int id)
        {
            var genero = _generoRepositorio.ObtenerPorId(id);
            var generoDTO = new GeneroDTO { IDGenero = genero.IDGenero, NombreGenero = genero.NombreGenero };
            return generoDTO;
        }

        public void ActualizarGenero(GeneroDTO generoDTO)
        {
            var genero = new Genero { IDGenero = generoDTO.IDGenero, NombreGenero = generoDTO.NombreGenero };
            _generoRepositorio.ActualizarGenero(genero);
        }

        public void EliminarGenero(int id)
        {
            _generoRepositorio.EliminarGenero(id);
        }
    }
}