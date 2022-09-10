namespace PlayList.NEGOCIO
{
    public class Persona
    {
        //Constructor de la clase

        //public Persona(string nombre)
        //{
        //    Nombre = nombre;

        //}

        //Atributos
        public string Nombre { get; set; }
        public float Altura { get; set; }
        public int Edad { get; set; }
        public int Peso { get; set; }

        //Metodos
        public string Presentarse()
        {
            string saludo = "Hola mi nombre es: " + Nombre;
            return saludo;
        }
    }
}
