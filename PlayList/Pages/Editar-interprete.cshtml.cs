using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PlayList.DATOS;
using PlayList.DTO;
using PlayList.NEGOCIO;

namespace PlayList.Pages
{
    public class Editar_interpreteModel : PageModel
    {
        private readonly IInterpreteNegocio _interpreteNegocio;

        public Editar_interpreteModel(IInterpreteNegocio interpreteNegocio)
        {
            _interpreteNegocio = interpreteNegocio;
        }
        [BindProperty]
        public InterpreteParaEditarDTO Interprete { get; set; }
        [BindProperty]
        public int Id { get; set; }
        public SelectList Generos { get; set; }
        public void OnGet(int id)
        {
            Id = id;
            var interpreteParaEditarDTO = _interpreteNegocio.ObtenerInterpretePorId(id);
            Interprete = interpreteParaEditarDTO;
            Generos = _interpreteNegocio.ObtenerGenerosLista();
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                var interprete = new InterpreteParaEditarDTO 
                    { 
                    NombreInterprete = Interprete.NombreInterprete,
                    FechaNacimiento = Interprete.FechaNacimiento,
                    Pais= Interprete.Pais,
                    GeneroID = Interprete.GeneroID,
                    ImagenUrl = Interprete.ImagenUrl 
                    };
                interprete.IDInterprete = Id;
                _interpreteNegocio.ActualizarInterprete(interprete);
                return RedirectToPage("./Interpretes");
            }

            return Page();
        }
    }
}


