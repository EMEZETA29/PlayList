using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PlayList.NEGOCIO;

namespace PlayList.Pages
{
    public class Eliminar_interpreteModel : PageModel
    {
        private readonly IInterpreteNegocio _interpreteNegocio;

        public Eliminar_interpreteModel(IInterpreteNegocio interpreteNegocio)
        {
            _interpreteNegocio = interpreteNegocio;
        }
        [BindProperty]
        public int Id { get; set; }
        public void OnGet(int id)
        {
            Id = id;
        }

        public IActionResult OnPost()
        {
            _interpreteNegocio.EliminarInterprete(Id);
            return RedirectToPage("./Interpretes");
        }
    }
}
