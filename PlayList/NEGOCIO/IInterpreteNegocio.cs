using Microsoft.AspNetCore.Mvc.Rendering;
using PlayList.DTO;

namespace PlayList.NEGOCIO
{
    public interface IInterpreteNegocio
    {
        void ActualizarInterprete(InterpreteParaEditarDTO interpreteParaEditarDTO);
        void CrearInterprete(InterpreteParaGuardarDTO interpreteParaGuardarDTO);
        void EliminarInterprete(int id);
        SelectList ObtenerGenerosLista();
        InterpreteParaEditarDTO ObtenerInterpretePorId(int id);
        List<InterpreteDTO> ObtenerTodos();
        List<InterpreteParaGuardarDTO> ObternerTodosIndex();
    }
}
