using PlayList.DATOS.Entidades;

namespace PlayList.DATOS.Repositorios
{
    public interface IInterpreteRepositorio
    {
        void ActualizarInterprete(Interpretes interprete);
        void CrearInterprete(Interpretes interprete);
        void EliminarInterprete(int id);
        Interpretes ObtenerPorId(int id);
        List<Interpretes> ObtenerTodos();
    }
}
