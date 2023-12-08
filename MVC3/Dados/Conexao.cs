namespace MVC3.Dados
{
    public class Conexao
    {
        public static string conecta()
        {
            string conecta = @"server=localhost;uid=root;pwd=1234561;database=mvcrud";

            return conecta;
        }
    }
}
