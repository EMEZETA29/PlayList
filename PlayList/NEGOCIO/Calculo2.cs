namespace PlayList.NEGOCIO
{
    public class Calculo2 : ICalculo
    {
        public int Operacion(int num1, int num2)
        {
            var resultado = num1 * num2;
            return resultado;
        }
    }
}
