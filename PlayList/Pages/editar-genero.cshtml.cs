using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PlayList.DTO;
using PlayList.NEGOCIO;

namespace PlayList.Pages
{
    public class editar_generoModel : PageModel
    {
        private readonly IGeneroNegocio _generoNegocio;

        public editar_generoModel(IGeneroNegocio generoNegocio)
        {
            _generoNegocio = generoNegocio;
        }
        [BindProperty]
        public int Id { get; set; }
        [BindProperty]
        public string Nombre { get; set; }
        public void OnGet(int id)
        {
            var generoDTO = _generoNegocio.ObtenerGeneroPorId(id);
            Nombre = generoDTO.NombreGenero;
            Id = id;
        }

        public IActionResult OnPost()
        {
            if(ModelState.IsValid)
            {
                var genero = new GeneroDTO { IDGenero= Id, NombreGenero = Nombre };
                _generoNegocio.ActualizarGenero(genero);
                return RedirectToPage("./generos");
            }

            return Page();
        }
    }
}
