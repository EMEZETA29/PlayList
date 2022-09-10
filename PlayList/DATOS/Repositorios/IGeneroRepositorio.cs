namespace PlayList.DATOS.Repositorios
{
    public interface IGeneroRepositorio
    {
        List<Genero> ObtenerTodas();
        void CrearGenero(Genero genero);
        Genero ObtenerPorId(int id);
        void ActualizarGenero(Genero genero);
        void EliminarGenero(int id);
    }
}
