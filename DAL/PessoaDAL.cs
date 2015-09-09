using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using POCO;

namespace DAL
{
    public class PessoaDAL
    {
        public bool inserir(Pessoa dados)
        {
            SqlConnection conexao = new SqlConnection(Conexao.StringDeConexao);

            string SQL = "INSERT INTO Pessoa(nome, funcao, ddd, telefone, email, ativo, dataCadastro, senha, administrador) VALUES(@nome, @funcao, @ddd, @telefone, @email, @ativo, @dataCadastro, @senha, @administrador)";

            SqlCommand comando = new SqlCommand(SQL, conexao);
            //comando.Parameters.AddWithValue("@codPessoa", codPessoa);
            comando.Parameters.AddWithValue("@nome", dados.nome);
            comando.Parameters.AddWithValue("@funcao", dados.funcao);
            comando.Parameters.AddWithValue("@ddd", dados.ddd);
            comando.Parameters.AddWithValue("@telefone", dados.telefone);
            comando.Parameters.AddWithValue("@email", dados.email);
            comando.Parameters.AddWithValue("@ativo", dados.ativo);
            comando.Parameters.AddWithValue("@dataCadastro", dados.dataCadastro);
            comando.Parameters.AddWithValue("@senha", dados.senha);
            comando.Parameters.AddWithValue("@administrador", dados.administrador);

            foreach (SqlParameter Parameter in comando.Parameters)
            {
                if (Parameter.Value == null)
                {
                    Parameter.Value = DBNull.Value;
                }
                else if (String.IsNullOrEmpty(Parameter.Value.ToString()))
                {
                    Parameter.Value = DBNull.Value;
                }
            }

            try
            {
                conexao.Open();
                comando.ExecuteNonQuery();

                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                conexao.Close();
            }            
        }

        public bool alterar(Pessoa dados, int codPessoa)
        {
            SqlConnection conexao = new SqlConnection(Conexao.StringDeConexao);

            string SQL = "UPDATE Pessoa SET nome=@nome, funcao=@funcao, ddd=@ddd, telefone=@telefone, email=@email, ativo=@ativo, senha=@senha WHERE codPessoa=@codPessoa";

            SqlCommand comando = new SqlCommand(SQL, conexao);
            comando.Parameters.AddWithValue("@codPessoa", codPessoa);
            comando.Parameters.AddWithValue("@nome", dados.nome);
            comando.Parameters.AddWithValue("@funcao", dados.funcao);
            comando.Parameters.AddWithValue("@ddd", dados.ddd);
            comando.Parameters.AddWithValue("@telefone", dados.telefone);
            comando.Parameters.AddWithValue("@email", dados.email);
            comando.Parameters.AddWithValue("@ativo", dados.ativo);
            //comando.Parameters.AddWithValue("@dataCadastro", dados.dataCadastro);
            comando.Parameters.AddWithValue("@senha", dados.senha);

            foreach (SqlParameter Parameter in comando.Parameters)
            {
                if (Parameter.Value == null)
                {
                    Parameter.Value = DBNull.Value;
                }
                else if (String.IsNullOrEmpty(Parameter.Value.ToString()))
                {
                    Parameter.Value = DBNull.Value;
                }
            }

            try
            {
                conexao.Open();
                comando.ExecuteNonQuery();

                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                conexao.Close();
            }
        }

        public bool deletar(int codPessoa)
        {
            SqlConnection conexao = new SqlConnection(Conexao.StringDeConexao);

            string SQL = "DELETE FROM Pessoa WHERE codPessoa=@codPessoa";

            SqlCommand comando = new SqlCommand(SQL, conexao);
            comando.Parameters.AddWithValue("@codPessoa", codPessoa);

            foreach (SqlParameter Parameter in comando.Parameters)
            {
                if (Parameter.Value == null)
                {
                    Parameter.Value = DBNull.Value;
                }
                else if (String.IsNullOrEmpty(Parameter.Value.ToString()))
                {
                    Parameter.Value = DBNull.Value;
                }
            }

            try
            {
                conexao.Open();
                comando.ExecuteNonQuery();

                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                conexao.Close();
            }
        }

        public List<Pessoa> listar()
        {
            List<Pessoa> pessoas = new List<Pessoa>();

            SqlConnection conexao = new SqlConnection(Conexao.StringDeConexao);

            string SQL = "SELECT codPessoa, nome, funcao, ddd, telefone, email, ativo, dataCadastro, senha FROM Pessoa";
            //string SQL = "SELECT codPessoa, nome, funcao, ddd, telefone, email, ativo, dataCadastro, senha FROM Pessoa WHERE codPessoa=@codPessoa";

            SqlCommand comando = new SqlCommand(SQL, conexao);
            //comando.Parameters.AddWithValue("@codPessoa", codPessoa);

            try
            {
                conexao.Open();
                SqlDataReader resultado = comando.ExecuteReader();

                while (resultado.Read())
                {
                    Pessoa dadosPessoa = new Pessoa();

                    dadosPessoa.codPessoa = (int)resultado["codPessoa"];
                    dadosPessoa.nome = resultado["nome"].ToString();
                    dadosPessoa.funcao = resultado["funcao"].ToString();
                    dadosPessoa.email = resultado["email"].ToString();
                    dadosPessoa.dataCadastro = (DateTime)resultado["dataCadastro"];

                    pessoas.Add(dadosPessoa);   
                }

                return pessoas; 
            }
            catch
            {
                return null;
            }
            finally
            {
                conexao.Close();
            }            
        }

        public List<Pessoa> listar(int codPessoa)
        {
            List<Pessoa> pessoas = new List<Pessoa>();

            SqlConnection conexao = new SqlConnection(Conexao.StringDeConexao);

            string SQL = "SELECT codPessoa, nome, funcao, ddd, telefone, email, ativo, dataCadastro, senha FROM Pessoa WHERE codPessoa=@codPessoa";

            SqlCommand comando = new SqlCommand(SQL, conexao);
            comando.Parameters.AddWithValue("@codPessoa", codPessoa);

            try
            {
                conexao.Open();
                SqlDataReader resultado = comando.ExecuteReader();

                while (resultado.Read())
                {
                    Pessoa dadosPessoa = new Pessoa();

                    dadosPessoa.codPessoa = (int)resultado["codPessoa"];
                    dadosPessoa.nome = resultado["nome"].ToString();
                    dadosPessoa.funcao = resultado["funcao"].ToString();
                    dadosPessoa.ddd = resultado["ddd"].ToString();
                    dadosPessoa.telefone = resultado["telefone"].ToString();
                    dadosPessoa.email = resultado["email"].ToString();
                    dadosPessoa.ativo = (bool)resultado["ativo"];
                    dadosPessoa.dataCadastro = (DateTime)resultado["dataCadastro"];
                    dadosPessoa.senha = resultado["senha"].ToString();
                    pessoas.Add(dadosPessoa);
                }

                return pessoas;
            }
            catch
            {
                return null;
            }
            finally
            {
                conexao.Close();
            }
        }

        public string validarAcesso(string email, string senhaCript, bool admin)
        {
            SqlConnection conexao = new SqlConnection(Conexao.StringDeConexao);

            string SQL = "";
            
            if (admin)
                SQL = "select email, senha from Pessoa where email=@email and administrador=1";
            else
                SQL = "select email, senha from Pessoa where email=@email";

            SqlCommand comando = new SqlCommand(SQL, conexao);
            
            comando.Parameters.AddWithValue("@email", email);
            
            try
            {
                conexao.Open();
                SqlDataReader resultado = comando.ExecuteReader();
                if (resultado.Read())
                {
                    Pessoa p = new Pessoa();
                    p.senha = resultado["senha"].ToString();
                    if (p.senha.Equals(senhaCript))
                    {
                        return "";
                    }
                    else
                    {
                        return "Senha inválida";
                    }
                }
                else
                {
                    return "Usuário não encontrado, entre em contato com o administrador do sistema.";
                }
            }
            catch
            {
                return "Erro";
            }
            finally
            {
                conexao.Close();
            }
        }

        public int getPessoaEmail(string email)
        {
            SqlConnection conexao = new SqlConnection(Conexao.StringDeConexao);
            string SQL = "select codPessoa from Pessoa where email=@email";
            SqlCommand comando = new SqlCommand(SQL, conexao);

            comando.Parameters.AddWithValue("@email", email);

            try
            {
                conexao.Open();
                SqlDataReader resultado = comando.ExecuteReader();
                if (resultado.Read())
                {
                    Pessoa p = new Pessoa();
                    p.codPessoa = (int)resultado["codPessoa"];

                    return p.codPessoa;
                }
                else
                {
                    return 0;
                }
            }
            catch
            {
                return -1;
            }
            finally
            {
                conexao.Close();
            }

        }

    }
}
