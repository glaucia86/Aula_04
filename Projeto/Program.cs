using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Persistence;
using DAL.Model;
using Projeto.Input;

namespace Projeto
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Leitura l   = new Leitura();
                Pessoa p    = new Pessoa();
                
                p.Nome  = l.ObterNome();
                p.Email = l.ObterEmail();

                PessoaDAL d = new PessoaDAL();

                d.Gravar(p);
                Console.WriteLine("Dados Gravados com Sucesso!!!!");

                //Listando todos os dados da tabela:
                foreach (Pessoa pes in d.ListarTodos())
                {
                    Console.WriteLine("\n");
                    Console.Write("\nCódigo............: " + pes.IdPessoa);
                    Console.Write("\nNome..............: " + pes.Nome);
                    Console.Write("\nEmail.............: " + pes.Email);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro....: " + e.Message);
            }

            Console.ReadKey();
        }
    }
}
