using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient; //ADO.NET

namespace DAL.Persistence
{
    public class Conexao
    {
        protected SqlConnection Con; //Abrir a conexão
        protected SqlCommand Cmd; //Para realizar os comandos de SQL/T-SQL
        protected SqlDataReader Dr; //Para realizar a leitura das queries/consultas

        //Método para Abrir Conexão:
        public void AbrirConexao()
        {
            try
            {
                Con = new SqlConnection("Data Source=PCGLAUCIA;Integrated Security=True"); //Connection String
                Con.Open();
            }
            catch 
            {
                throw; 
            }
        }

        //Método para Fechar Conexao:
        public void FecharConexao()
        {
            try
            {
                if(Con != null)
                    Con.Close();
            }
            catch
            {
                throw;
            }
        }
    }
}
