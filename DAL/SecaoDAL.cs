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
    public class SecaoDAL
    {
        public bool inserir(int codSecao, string nome, int codPessoa_Gerente, DateTime dataCadastro)
        {
            SqlConnection conexao = new SqlConnection(Conexao.StringDeConexao);

            string SQL = "INSERT INTO Secao(nome, codPessoa_Gerente, dataCadastro) VALUES(@nome, @codPessoa_Gerente, @dataCadastro)";

            SqlCommand comando = new SqlCommand(SQL, conexao);
            comando.Parameters.AddWithValue("@nome", nome);
            comando.Parameters.AddWithValue("@codPessoa_Gerente", codPessoa_Gerente);
            comando.Parameters.AddWithValue("@dataCadastro", dataCadastro);

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

        public bool alterar(int codSecao, string nome, int codPessoa_Gerente, DateTime dataCadastro)
        {
            SqlConnection conexao = new SqlConnection(Conexao.StringDeConexao);

            string SQL = "UPDATE Secao SET nome=@nome, codPessoa_Gerente=@codPessoa_Gerente WHERE codSecao=@codSecao";

            SqlCommand comando = new SqlCommand(SQL, conexao);
            comando.Parameters.AddWithValue("@nome", nome);
            comando.Parameters.AddWithValue("@codPessoa_Gerente", codPessoa_Gerente);
            comando.Parameters.AddWithValue("@dataCadastro", dataCadastro);

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

        public bool deletar(int codSecao)
        {
            SqlConnection conexao = new SqlConnection(Conexao.StringDeConexao);

            string SQL = "DELETE FROM Secao WHERE codSecao=@codSecao";

            SqlCommand comando = new SqlCommand(SQL, conexao);
            comando.Parameters.AddWithValue("@codSecao", codSecao);

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

        public List<Secao> listar(int codSecao)
        {
            List<Secao> secao = new List<Secao>();

            SqlConnection conexao = new SqlConnection(Conexao.StringDeConexao);

            string SQL = "SELECT codSecao, nome, codPessoa_Gerente, dataCadastro FROM Secao WHERE codSecao=@codSecao";

            SqlCommand comando = new SqlCommand(SQL, conexao);
            comando.Parameters.AddWithValue("@codSecao", codSecao);

            try
            {
                conexao.Open();
                SqlDataReader resultado = comando.ExecuteReader();

                while (resultado.Read())
                {
                    Secao dadosSecao = new Secao();

                    dadosSecao.codSecao = (int)resultado["codSecao"];
                    dadosSecao.nome = resultado["nome"].ToString();
                    dadosSecao.codPessoa_Gerente = (int)resultado["codPessoa_Gerente"];
                    dadosSecao.dataCadastro = (DateTime)resultado["dataCadastro"];

                    secao.Add(dadosSecao);
                }

                return secao;
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
    }
}
