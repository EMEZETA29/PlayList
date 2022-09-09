using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PlayList.NEGOCIO;

namespace PlayList.Pages
{
    public class TestModel : PageModel
    {
        private readonly ICalculo _calculo;

        public TestModel(ICalculo calculo)
        {
            _calculo = calculo;
        }
        [BindProperty]
        public int Numero1 { get; set; }
        [BindProperty]
        public int Numero2 { get; set; }
        [BindProperty]
        public int Resultado { get; set; }
        public void OnGet()
        {
            //this.Numero1 = 123;
            //this.Numero2 = 321;
        }

        public void Onpost()
        {
            
            var resultado = _calculo.Operacion(this.Numero1, this.Numero2);
        }
    }
}
