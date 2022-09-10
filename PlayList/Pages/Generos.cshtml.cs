using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PlayList.DTO;
using PlayList.NEGOCIO;

namespace PlayList.Pages
{
    public class GenerosModel : PageModel
    {
        public List<GeneroDTO> Generos { get; set; }

        private readonly IGeneroNegocio _generoNegocio;

        public GenerosModel(IGeneroNegocio generoNegocio)
        {
            _generoNegocio = generoNegocio;
        }
        
        public void OnGet()
        {
            Generos = _generoNegocio.ObtenerGeneros();
        }
    }
}
