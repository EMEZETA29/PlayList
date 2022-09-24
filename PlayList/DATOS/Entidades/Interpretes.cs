namespace PlayList.DATOS.Entidades
{
    public class Interpretes
    {
        public int IDInterprete { get; set; }
        public string NombreInterprete { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string Pais { get; set; }
        public string ImagenUrl { get; set; }
        public int GeneroID { get; set; }
        public string Genero { get; set; } 
    }
}
