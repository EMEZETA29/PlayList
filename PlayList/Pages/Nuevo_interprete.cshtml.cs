using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PlayList.DTO;
using PlayList.NEGOCIO;

namespace PlayList.Pages
{
    public class Nuevo_interpreteModel : PageModel
    {
        private readonly IInterpreteNegocio _interpreteNegocio;

        public Nuevo_interpreteModel(IInterpreteNegocio interpreteNegocio)
        {
            _interpreteNegocio = interpreteNegocio;
        }
        public SelectList Generos { get; set; }
        [BindProperty]
        public InterpreteParaGuardarDTO Interprete { get; set; }
        public void OnGet()
        {
            Generos = _interpreteNegocio.ObtenerGenerosLista();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _interpreteNegocio.CrearInterprete(Interprete);
                return RedirectToPage("./interpretes");
            }
            Generos = _interpreteNegocio.ObtenerGenerosLista();
            return Page();
        }
    }
}
