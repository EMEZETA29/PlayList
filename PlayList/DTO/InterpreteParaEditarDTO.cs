using System.ComponentModel.DataAnnotations;

namespace PlayList.DTO
{
    public class InterpreteParaEditarDTO
    {
        public int IDInterprete { get; set; }
        [Required(ErrorMessage = "Debe ingresar nombre")]
        public string NombreInterprete { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string? Pais { get; set; }
        public string? ImagenUrl { get; set; }
        [Required(ErrorMessage = "Debe seleccionar un genero")]
        public int? GeneroID { get; set; }
    }
}
