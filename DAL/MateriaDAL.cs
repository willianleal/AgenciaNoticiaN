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
    public class MateriaDAL
    {
        public bool inserir(int codMateria, int codPessoa_Jornalista, int codPessoa_Revisor, int codPessoa_Publicador, string nome, string materiaEscrita, int codSecao,
            string status, DateTime dataCadastro, DateTime dataAtualizacao)
        {
            SqlConnection conexao = new SqlConnection(Conexao.StringDeConexao);

            string SQL = @"INSERT INTO Materia(codPessoa_Jornalista, codPessoa_Revisor, codPessoa_Publicador, nome, materiaEscrita, codSecao, status, dataCadastro, dataAtualizacao) 
                            VALUES(@codMateria, @codPessoa_Jornalista, @codPessoa_Revisor, @codPessoa_Publicador, @nome, @materiaEscrita, @codSecao, @status, @dataCadastro, @dataAtualizacao)";

            SqlCommand comando = new SqlCommand(SQL, conexao);
            comando.Parameters.AddWithValue("@codPessoa_Jornalista", codPessoa_Jornalista);
            comando.Parameters.AddWithValue("@codPessoa_Revisor", codPessoa_Revisor);
            comando.Parameters.AddWithValue("@codPessoa_Publicador", codPessoa_Publicador);
            comando.Parameters.AddWithValue("@nome", nome);
            comando.Parameters.AddWithValue("@materiaEscrita", materiaEscrita);
            comando.Parameters.AddWithValue("@codSecao", codSecao);
            comando.Parameters.AddWithValue("@status", status);
            comando.Parameters.AddWithValue("@dataCadastro", dataCadastro);
            comando.Parameters.AddWithValue("@dataAtualizacao", dataAtualizacao);

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

        public bool alterar(int codMateria, int codPessoa_Jornalista, int codPessoa_Revisor, int codPessoa_Publicador, string nome, string materiaEscrita, int codSecao,
            string status, DateTime dataCadastro, DateTime dataAtualizacao)
        {
            SqlConnection conexao = new SqlConnection(Conexao.StringDeConexao);

            string SQL = @"UPDATE Materia SET codPessoa_Jornalista=@codPessoa_Jornalista, codPessoa_Revisor=@codPessoa_Revisor, codPessoa_Publicador=@codPessoa_Publicador, 
                            nome=@nome, materiaEscrita=@materiaEscrita, codSecao=@codSecao, status=@status, dataCadastro=@dataCadastro, dataAtualizacao=@dataAtualizacao WHERE codMateria=@codMateria";

            SqlCommand comando = new SqlCommand(SQL, conexao);
            comando.Parameters.AddWithValue("@codPessoa_Jornalista", codPessoa_Jornalista);
            comando.Parameters.AddWithValue("@codPessoa_Revisor", codPessoa_Revisor);
            comando.Parameters.AddWithValue("@codPessoa_Publicador", codPessoa_Publicador);
            comando.Parameters.AddWithValue("@nome", nome);
            comando.Parameters.AddWithValue("@materiaEscrita", materiaEscrita);
            comando.Parameters.AddWithValue("@codSecao", codSecao);
            comando.Parameters.AddWithValue("@status", status);
            comando.Parameters.AddWithValue("@dataCadastro", dataCadastro);
            comando.Parameters.AddWithValue("@dataAtualizacao", dataAtualizacao);

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

        public bool deletar(int codMateria)
        {
            SqlConnection conexao = new SqlConnection(Conexao.StringDeConexao);

            string SQL = @"DELETE FROM Materia WHERE codMateria=@codMateria";

            SqlCommand comando = new SqlCommand(SQL, conexao);
            comando.Parameters.AddWithValue("@codMateria", codMateria);

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

        public List<Materia> listar(int codMateria)
        {
            List<Materia> materia = new List<Materia>();

            SqlConnection conexao = new SqlConnection(Conexao.StringDeConexao);

            string SQL = "SELECT codMateria, codPessoa_Jornalista, codPessoa_Revisor, codPessoa_Publicador, nome, materiaEscrita, codSecao, status, dataCadastro, dataAtualizacao FROM Materia WHERE codMateria=@codMateria";

            SqlCommand comando = new SqlCommand(SQL, conexao);
            comando.Parameters.AddWithValue("@codMateria", codMateria);

            try
            {
                conexao.Open();
                SqlDataReader resultado = comando.ExecuteReader();

                while (resultado.Read())
                {
                    Materia dadosMateria = new Materia();

                    dadosMateria.codMateria = (int)resultado["codMateria"];
                    dadosMateria.codPessoa_Jornalista = (int)resultado["codPessoa_Jornalista"];
                    dadosMateria.codPessoa_Revisor = (int)resultado["codPessoa_Revisor"];
                    dadosMateria.codPessoa_Publicador = (int)resultado["codPessoa_Publicador"];
                    dadosMateria.nome = resultado["nome"].ToString();
                    dadosMateria.materiaEscrita = resultado["materiaEscrita"].ToString();
                    dadosMateria.codSecao = (int)resultado["codSecao"];
                    dadosMateria.status = resultado["status"].ToString();
                    dadosMateria.dataCadastro = (DateTime)resultado["dataCadastro"];
                    dadosMateria.dataAtualizacao = (DateTime)resultado["dataAtualizacao"];
                    materia.Add(dadosMateria);
                }

                return materia;
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
