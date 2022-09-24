using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PlayList.DTO;
using PlayList.NEGOCIO;

namespace PlayList.Pages
{
    public class InterpretesModel : PageModel
    {
        private readonly IInterpreteNegocio _interpreteNegocio;

        public InterpretesModel(IInterpreteNegocio interpreteNegocio)
        {
            _interpreteNegocio = interpreteNegocio;
        }
        public List<InterpreteDTO> Interpretes { get; set; }
        public void OnGet()
        {
            Interpretes = _interpreteNegocio.ObtenerTodos();
        }
    }
}
