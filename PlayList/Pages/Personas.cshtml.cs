using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PlayList.NEGOCIO;

namespace PlayList.Pages
{
    public class PersonasModel : PageModel
    {
        public string Saludo1 { get; set; }
        public string Saludo2 { get; set; }
        public void OnGet()
        {
            //Instanciamos objetos de la clase persona
            var persona1 = new Persona();
            persona1.Nombre = "Juan";
            persona1.Altura = 1.7f;
            persona1.Peso = 70;
            persona1.Edad = 27;
            var persona2 = new Persona { Nombre = "Maria", Altura = 1.5f, Edad = 22, Peso = 55 };
            var saludoPersona1 = persona1.Presentarse();
            var saludoPersona2 = persona2.Presentarse();
            Saludo1 = saludoPersona1;
            Saludo2 = saludoPersona2;
        }
    }
}
