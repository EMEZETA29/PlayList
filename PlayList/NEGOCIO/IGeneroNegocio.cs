using PlayList.DATOS;
using PlayList.DTO;

namespace PlayList.NEGOCIO
{
    public interface IGeneroNegocio
    {
        List<GeneroDTO> ObtenerGeneros();
        void CrearGenero(GeneroDTO generoDTO);
        GeneroDTO ObtenerGeneroPorId(int id);
        void ActualizarGenero(GeneroDTO generoDTO);
        void EliminarGenero(int id);
    }
}
