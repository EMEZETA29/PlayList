using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PlayList.NEGOCIO;

namespace PlayList.Pages
{
    public class EliminarGeneroModel : PageModel
    {
        private readonly IGeneroNegocio _generoNegocio;

        public EliminarGeneroModel(IGeneroNegocio generoNegocio)
        {
            _generoNegocio = generoNegocio;
        }
        [BindProperty]
        public int Id { get; set; }
        public void OnGet(int id)
        {
            Id = id;
        }
        public IActionResult OnPost()
        {
            _generoNegocio.EliminarGenero(Id);
            return RedirectToPage("./generos");
        }
    }
}
