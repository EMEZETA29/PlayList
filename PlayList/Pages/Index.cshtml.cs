using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PlayList.DTO;
using PlayList.NEGOCIO;

namespace PlayList.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IInterpreteNegocio _interpreteNegocio;

        public IndexModel(ILogger<IndexModel> logger, IInterpreteNegocio interpreteNegocio)
        {
            _logger = logger;
            _interpreteNegocio = interpreteNegocio;
        }

        public List<InterpreteParaGuardarDTO> Interpretes { get; set; }

        public void OnGet()
        {
            Interpretes = _interpreteNegocio.ObternerTodosIndex();
        }
    }
}