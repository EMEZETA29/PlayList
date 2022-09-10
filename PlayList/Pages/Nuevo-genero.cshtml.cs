using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PlayList.DTO;
using PlayList.NEGOCIO;
using System.ComponentModel.DataAnnotations;

namespace PlayList.Pages
{
    public class Nuevo_generoModel : PageModel
    {
        private readonly IGeneroNegocio _generoNegocio;

        public Nuevo_generoModel(IGeneroNegocio generoNegocio)
        {
            _generoNegocio = generoNegocio;
        }
        [BindProperty]
        [Required(ErrorMessage ="Debe agregar un estilo de musica")]
        public string Nombre { get; set; }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            if(ModelState.IsValid)
            {
                var generoDTO = new GeneroDTO { NombreGenero = Nombre };
                _generoNegocio.CrearGenero(generoDTO);
                return RedirectToPage("./generos");
            }
            
            return Page();
        }
    }
}
