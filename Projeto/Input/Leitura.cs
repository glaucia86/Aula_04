using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Projeto.Input
{
    public class Leitura
    {
        public int ObterIdPessoa()
        {
            try
            {
                Console.Write("Informe o Código.......: ");
                return Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine("\tErro.....: " + e.Message);
                return ObterIdPessoa();
            }
        }

        public string ObterNome()
        {
            try
            {
                Console.Write("Informe o Nome.......:");
                return Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("\tErro....: " + e.Message);
                return ObterNome();
            }
        }

        public string ObterEmail()
        {
            try
            {
                Console.Write("Informe o Email.....: ");
                string email = Console.ReadLine();

                Regex reg = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

                if (reg.IsMatch(email))
                {
                    return email;
                }
                else {
                    Console.WriteLine("Email inválido!!!!");
                }
            }
            catch (Exception e)
            {
                Console.Write("\tErro....: " + e.Message);
                return ObterEmail();
            }
            return ObterEmail();
        }
    }
}
