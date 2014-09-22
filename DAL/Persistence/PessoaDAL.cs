using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DAL.Model;


namespace DAL.Persistence
{
    public class PessoaDAL : Conexao
    {
        //Método Insert na tabela Pessoa:
        public void Gravar(Pessoa p)
        {
            try
            {
                AbrirConexao();
                Cmd = new SqlCommand("insert into Pessoa(Nome,Email) values(@v1, @v2)", Con);

                Cmd.Parameters.AddWithValue("@v1", p.Nome);
                Cmd.Parameters.AddWithValue("@v2", p.Email);

                Cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {

                throw new Exception("Erro ao gravar.....: " + e.Message);
            }
            finally
            {
                FecharConexao();
            }
        }

        //Método Update na tabela Pessoa:
        public void Atualizar(Pessoa p)
        {
            try
            {
                AbrirConexao();
                Cmd = new SqlCommand("update Pessoa set Nome=@nome, Email=@email where IdPessoa=@idpessoa", Con);

                Cmd.Parameters.AddWithValue("@nome", p.Nome);
                Cmd.Parameters.AddWithValue("@email", p.Email);
                Cmd.Parameters.AddWithValue("@idpessoa", p.IdPessoa);

                Cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao atualizar......: " + e.Message);
            }
            finally
            {
                FecharConexao();
            }
        }

        //Método Delete na tabela Pessoa:
        public void Excluir(int IdPessoa)
        {
            try
            {
                AbrirConexao();
                Cmd = new SqlCommand("delete from Pessoa where IdPessoa=@idpessoa", Con);

                Cmd.Parameters.AddWithValue("@idpessoa", IdPessoa);

                Cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao excluir......: " + e.Message);
            }
            finally
            {
                FecharConexao();
            }
        }

        //Método para listar pelo Id: (Chave Primária):
        public List<Pessoa> ObterId(int IdPessoa)
        {
            try
            {
                AbrirConexao();
                Cmd = new SqlCommand("select * from Pessoa where IdPessoa=@idpessoa", Con);
                Cmd.Parameters.AddWithValue("idpessoa", IdPessoa);
                Dr = Cmd.ExecuteReader();

                List<Pessoa> lista = new List<Pessoa>();

                while (Dr.Read())
                {
                    Pessoa p = new Pessoa();

                    p.IdPessoa  = Convert.ToInt32(Dr["IdPessoa"]);
                    p.Nome      = Convert.ToString(Dr["Nome"]);
                    p.Email     = Convert.ToString(Dr["Email"]);

                    lista.Add(p);
                }

                return lista;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao obter pelo id.....: " + e.Message);
            }
            finally
            {
                FecharConexao();
            }
        }

        //Método para listar todas as informações contidas no BD:
        public List<Pessoa> ListarTodos()
        {
            try
            {
                AbrirConexao();
                Cmd = new SqlCommand("select * from Pessoa", Con);
                Dr = Cmd.ExecuteReader();

                List<Pessoa> lista = new List<Pessoa>();

                while (Dr.Read())
                {
                    Pessoa p = new Pessoa();

                    p.Nome  = Convert.ToString(Dr["Nome"]);
                    p.Email = Convert.ToString(Dr["Email"]);

                    lista.Add(p);
                }

                return lista;
            }
            catch(Exception e)
            {
                throw new Exception("Erro ao listar todos.....: " + e.Message );
            }
            finally
            {
                FecharConexao();
            }
        }
    }
}
