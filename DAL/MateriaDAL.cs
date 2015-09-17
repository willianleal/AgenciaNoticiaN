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
        public bool inserir(Materia dados)
        {
            SqlConnection conexao = new SqlConnection(Conexao.StringDeConexao);

            string SQL = @"INSERT INTO Materia(codPessoa_Jornalista, nome, materiaEscrita, codSecao, status, dataCadastro) 
                            VALUES(@codPessoa_Jornalista, @nome, @materiaEscrita, @codSecao, @status, @dataCadastro)";

            SqlCommand comando = new SqlCommand(SQL, conexao);
            comando.Parameters.AddWithValue("@codPessoa_Jornalista", dados.codPessoa_Jornalista);
            comando.Parameters.AddWithValue("@codPessoa_Revisor", dados.codPessoa_Revisor);
            comando.Parameters.AddWithValue("@codPessoa_Publicador", dados.codPessoa_Publicador);
            comando.Parameters.AddWithValue("@nome", dados.nome);
            comando.Parameters.AddWithValue("@materiaEscrita", dados.materiaEscrita);
            comando.Parameters.AddWithValue("@codSecao", dados.codSecao);
            comando.Parameters.AddWithValue("@status", dados.status);
            comando.Parameters.AddWithValue("@dataCadastro", dados.dataCadastro);
            //comando.Parameters.AddWithValue("@dataAtualizacao", dados.dataAtualizacao);

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

        public bool alterar(Materia dados, int codMateria)
        {
            SqlConnection conexao = new SqlConnection(Conexao.StringDeConexao);

            string SQL = @"UPDATE Materia SET codPessoa_Jornalista=@codPessoa_Jornalista, codPessoa_Revisor=@codPessoa_Revisor, codPessoa_Publicador=@codPessoa_Publicador, 
                            nome=@nome, materiaEscrita=@materiaEscrita, codSecao=@codSecao, status=@status, dataCadastro=@dataCadastro, dataAtualizacao=@dataAtualizacao WHERE codMateria=@codMateria";

            SqlCommand comando = new SqlCommand(SQL, conexao);
            comando.Parameters.AddWithValue("@codMateria", dados.codMateria);
            comando.Parameters.AddWithValue("@codPessoa_Jornalista", dados.codPessoa_Jornalista);
            comando.Parameters.AddWithValue("@codPessoa_Revisor", dados.codPessoa_Revisor);
            comando.Parameters.AddWithValue("@codPessoa_Publicador", dados.codPessoa_Publicador);
            comando.Parameters.AddWithValue("@nome", dados.nome);
            comando.Parameters.AddWithValue("@materiaEscrita", dados.materiaEscrita);
            comando.Parameters.AddWithValue("@codSecao", dados.codSecao);
            comando.Parameters.AddWithValue("@status", dados.status);
            comando.Parameters.AddWithValue("@dataCadastro", dados.dataCadastro);
            comando.Parameters.AddWithValue("@dataAtualizacao", dados.dataAtualizacao);

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

            //string SQL = "SELECT codMateria, codPessoa_Jornalista, codPessoa_Revisor, codPessoa_Publicador, nome, materiaEscrita, codSecao, status, dataCadastro, dataAtualizacao FROM Materia WHERE codMateria=@codMateria";

            string SQL = @"SELECT 
                            codMateria, codPessoa_Jornalista, codPessoa_Revisor, codPessoa_Publicador, 
                            m.nome, materiaEscrita, m.codSecao, status, m.dataCadastro, dataAtualizacao,
                            pj.nome as Jornalista, pr.nome as Revisor, pp.nome as Publicador, p.nome as Gerente, revisao 
                           FROM Materia m
                           INNER JOIN Pessoa pj ON pj.codPessoa=m.codPessoa_Jornalista
                           LEFT JOIN Pessoa pr ON pr.codPessoa=m.codPessoa_Revisor
                           LEFT JOIN Pessoa pp ON pp.codPessoa=m.codPessoa_Publicador
                           INNER JOIN Secao s ON s.codSecao=m.codSecao
                           INNER JOIN Pessoa p ON p.codPessoa=s.codPessoa_Gerente
                           WHERE codMateria=@codMateria";
            
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
                    dadosMateria.codPessoa_Revisor = resultado["codPessoa_Revisor"] is DBNull ? 0 : (int)resultado["codPessoa_Revisor"];
                    dadosMateria.codPessoa_Publicador = resultado["codPessoa_Publicador"] is DBNull ? 0 : (int)resultado["codPessoa_Publicador"];
                    dadosMateria.nome = resultado["nome"].ToString();
                    dadosMateria.materiaEscrita = resultado["materiaEscrita"].ToString();
                    dadosMateria.codSecao = (int)resultado["codSecao"];
                    dadosMateria.status = resultado["status"].ToString();
                    dadosMateria.dataCadastro = (DateTime)resultado["dataCadastro"];
                    dadosMateria.dataAtualizacao = resultado["dataAtualizacao"] is DBNull ? DateTime.MinValue : (DateTime)resultado["dataAtualizacao"];
                    dadosMateria.Jornalista = resultado["Jornalista"].ToString();
                    dadosMateria.Revisor = resultado["Revisor"].ToString();
                    dadosMateria.Publicador = resultado["Publicador"].ToString();
                    dadosMateria.Gerente = resultado["Gerente"].ToString();
                    dadosMateria.revisao = resultado["revisao"].ToString();
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

        public List<Materia> listarMateriaPessoa(int codPessoa_Jornalista, int codPessoa_Revisor, int codPessoa_Publicador, int codPessoa_Gerente)
        {
            List<Materia> materia = new List<Materia>();

            SqlConnection conexao = new SqlConnection(Conexao.StringDeConexao);

            string SQL = @"SELECT 
                            codMateria, codPessoa_Jornalista, codPessoa_Revisor, codPessoa_Publicador, 
                            m.nome, materiaEscrita, m.codSecao, status, m.dataCadastro, dataAtualizacao,
                            pj.nome as Jornalista, pr.nome as Revisor, pp.nome as Publicador, p.nome as Gerente 
                           FROM Materia m
                           INNER JOIN Pessoa pj ON pj.codPessoa=m.codPessoa_Jornalista
                           LEFT JOIN Pessoa pr ON pr.codPessoa=m.codPessoa_Revisor
                           LEFT JOIN Pessoa pp ON pp.codPessoa=m.codPessoa_Publicador
                           INNER JOIN Secao s ON s.codSecao=m.codSecao
                           INNER JOIN Pessoa p ON p.codPessoa=s.codPessoa_Gerente
                           WHERE codPessoa_Jornalista = @codPessoa_Jornalista OR codPessoa_Revisor = @codPessoa_Revisor OR codPessoa_Publicador = @codPessoa_Publicador OR s.codPessoa_Gerente = @codPessoa_Gerente";

            SqlCommand comando = new SqlCommand(SQL, conexao);
            comando.Parameters.AddWithValue("@codPessoa_Jornalista", codPessoa_Jornalista);
            comando.Parameters.AddWithValue("@codPessoa_Revisor", codPessoa_Revisor);
            comando.Parameters.AddWithValue("@codPessoa_Publicador", codPessoa_Publicador);
            comando.Parameters.AddWithValue("@codPessoa_Gerente", codPessoa_Gerente);

            try
            {
                conexao.Open();
                SqlDataReader resultado = comando.ExecuteReader();

                while (resultado.Read())
                {
                    Materia dadosMateria = new Materia();

                    dadosMateria.codMateria = (int)resultado["codMateria"];
                    dadosMateria.codPessoa_Jornalista = (int)resultado["codPessoa_Jornalista"];
                    dadosMateria.codPessoa_Revisor = resultado["codPessoa_Revisor"] is DBNull ? 0 : (int)resultado["codPessoa_Revisor"];
                    dadosMateria.codPessoa_Publicador = resultado["codPessoa_Publicador"] is DBNull ? 0 : (int)resultado["codPessoa_Publicador"];
                    dadosMateria.nome = resultado["nome"].ToString();
                    dadosMateria.materiaEscrita = resultado["materiaEscrita"].ToString();
                    dadosMateria.codSecao = (int)resultado["codSecao"];
                    dadosMateria.status = resultado["status"].ToString();
                    dadosMateria.dataCadastro = (DateTime)resultado["dataCadastro"];
                    dadosMateria.dataAtualizacao = resultado["dataAtualizacao"] is DBNull ? DateTime.MinValue : (DateTime)resultado["dataAtualizacao"];
                    dadosMateria.Jornalista = resultado["Jornalista"].ToString();
                    dadosMateria.Revisor = resultado["Revisor"].ToString();
                    dadosMateria.Publicador = resultado["Publicador"].ToString();
                    dadosMateria.Gerente = resultado["Gerente"].ToString();
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

        public List<Materia> listarMateriaJornalista(int codPessoa_Jornalista)
        {
            List<Materia> materia = new List<Materia>();

            SqlConnection conexao = new SqlConnection(Conexao.StringDeConexao);

            string SQL = @"SELECT 
                            codMateria, codPessoa_Jornalista, codPessoa_Revisor, codPessoa_Publicador, 
                            m.nome, materiaEscrita, m.codSecao, status, m.dataCadastro, dataAtualizacao,
                            pj.nome as Jornalista, pr.nome as Revisor, pp.nome as Publicador, p.nome as Gerente, revisao 
                           FROM Materia m
                           INNER JOIN Pessoa pj ON pj.codPessoa=m.codPessoa_Jornalista
                           LEFT JOIN Pessoa pr ON pr.codPessoa=m.codPessoa_Revisor
                           LEFT JOIN Pessoa pp ON pp.codPessoa=m.codPessoa_Publicador
                           INNER JOIN Secao s ON s.codSecao=m.codSecao
                           INNER JOIN Pessoa p ON p.codPessoa=s.codPessoa_Gerente
                           WHERE (codPessoa_Jornalista = @codPessoa_Jornalista AND status='Proposta') OR (codPessoa_Jornalista = @codPessoa_Jornalista AND status='Revisao')";

            SqlCommand comando = new SqlCommand(SQL, conexao);
            comando.Parameters.AddWithValue("@codPessoa_Jornalista", codPessoa_Jornalista);
          
            try
            {
                conexao.Open();
                SqlDataReader resultado = comando.ExecuteReader();

                while (resultado.Read())
                {
                    Materia dadosMateria = new Materia();

                    dadosMateria.codMateria = (int)resultado["codMateria"];
                    dadosMateria.codPessoa_Jornalista = (int)resultado["codPessoa_Jornalista"];
                    dadosMateria.codPessoa_Revisor = resultado["codPessoa_Revisor"] is DBNull ? 0 : (int)resultado["codPessoa_Revisor"];
                    dadosMateria.codPessoa_Publicador = resultado["codPessoa_Publicador"] is DBNull ? 0 : (int)resultado["codPessoa_Publicador"];
                    dadosMateria.nome = resultado["nome"].ToString();
                    dadosMateria.materiaEscrita = resultado["materiaEscrita"].ToString();
                    dadosMateria.codSecao = (int)resultado["codSecao"];
                    dadosMateria.status = resultado["status"].ToString();
                    dadosMateria.dataCadastro = (DateTime)resultado["dataCadastro"];
                    dadosMateria.dataAtualizacao = resultado["dataAtualizacao"] is DBNull ? DateTime.MinValue : (DateTime)resultado["dataAtualizacao"];
                    dadosMateria.Jornalista = resultado["Jornalista"].ToString();
                    dadosMateria.Revisor = resultado["Revisor"].ToString();
                    dadosMateria.Publicador = resultado["Publicador"].ToString();
                    dadosMateria.Gerente = resultado["Gerente"].ToString();
                    dadosMateria.revisao = resultado["revisao"].ToString();
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

        public List<Materia> listarMateriaRevisor(int codPessoa_Revisor)
        {
            List<Materia> materia = new List<Materia>();

            SqlConnection conexao = new SqlConnection(Conexao.StringDeConexao);

            string SQL = @"SELECT 
                            codMateria, codPessoa_Jornalista, codPessoa_Revisor, codPessoa_Publicador, 
                            m.nome, materiaEscrita, m.codSecao, status, m.dataCadastro, dataAtualizacao,
                            pj.nome as Jornalista, pr.nome as Revisor, pp.nome as Publicador, p.nome as Gerente, revisao 
                           FROM Materia m
                           INNER JOIN Pessoa pj ON pj.codPessoa=m.codPessoa_Jornalista
                           LEFT JOIN Pessoa pr ON pr.codPessoa=m.codPessoa_Revisor
                           LEFT JOIN Pessoa pp ON pp.codPessoa=m.codPessoa_Publicador
                           INNER JOIN Secao s ON s.codSecao=m.codSecao
                           INNER JOIN Pessoa p ON p.codPessoa=s.codPessoa_Gerente
                           WHERE (codPessoa_Revisor IS NULL AND status='Proposta') OR
                                 (codPessoa_Revisor = @codPessoa_Revisor AND status='Revisao')";

            SqlCommand comando = new SqlCommand(SQL, conexao);
            comando.Parameters.AddWithValue("@codPessoa_Revisor", codPessoa_Revisor);

            try
            {
                conexao.Open();
                SqlDataReader resultado = comando.ExecuteReader();

                while (resultado.Read())
                {
                    Materia dadosMateria = new Materia();

                    dadosMateria.codMateria = (int)resultado["codMateria"];
                    dadosMateria.codPessoa_Jornalista = (int)resultado["codPessoa_Jornalista"];
                    dadosMateria.codPessoa_Revisor = resultado["codPessoa_Revisor"] is DBNull ? 0 : (int)resultado["codPessoa_Revisor"];
                    dadosMateria.codPessoa_Publicador = resultado["codPessoa_Publicador"] is DBNull ? 0 : (int)resultado["codPessoa_Publicador"];
                    dadosMateria.nome = resultado["nome"].ToString();
                    dadosMateria.materiaEscrita = resultado["materiaEscrita"].ToString();
                    dadosMateria.codSecao = (int)resultado["codSecao"];
                    dadosMateria.status = resultado["status"].ToString();
                    dadosMateria.dataCadastro = (DateTime)resultado["dataCadastro"];
                    dadosMateria.dataAtualizacao = resultado["dataAtualizacao"] is DBNull ? DateTime.MinValue : (DateTime)resultado["dataAtualizacao"];
                    dadosMateria.Jornalista = resultado["Jornalista"].ToString();
                    dadosMateria.Revisor = resultado["Revisor"].ToString();
                    dadosMateria.Publicador = resultado["Publicador"].ToString();
                    dadosMateria.Gerente = resultado["Gerente"].ToString();
                    dadosMateria.revisao = resultado["revisao"].ToString();
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

        public bool inserirRevisao(Materia dados, int codMateria)
        {
            SqlConnection conexao = new SqlConnection(Conexao.StringDeConexao);

            string SQL = @"UPDATE Materia SET nome=@nome, materiaEscrita=@materiaEscrita, status=@status, dataAtualizacao=@dataAtualizacao, revisao=@revisao, 
                            parecerJornalista=@parecerJornalista, parecerRevisor=@parecerRevisor, alteracaoJornalista=@alteracaoJornalista, alteracaoRevisor=@alteracaoRevisor
                            WHERE codMateria=@codMateria";

            SqlCommand comando = new SqlCommand(SQL, conexao);
            comando.Parameters.AddWithValue("@codMateria", codMateria);
            comando.Parameters.AddWithValue("@nome", dados.nome);
            comando.Parameters.AddWithValue("@materiaEscrita", dados.materiaEscrita);
            comando.Parameters.AddWithValue("@status", dados.status);
            comando.Parameters.AddWithValue("@dataAtualizacao", dados.dataAtualizacao);
            comando.Parameters.AddWithValue("@revisao", dados.revisao);
            comando.Parameters.AddWithValue("@parecerJornalista", dados.parecerJornalista);
            comando.Parameters.AddWithValue("@parecerRevisor", dados.parecerRevisor);
            comando.Parameters.AddWithValue("@alteracaoJornalista", dados.alteracaoJornalista);
            comando.Parameters.AddWithValue("@alteracaoRevisor", dados.alteracaoRevisor);

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

        public bool inserirRevisorMateria(Materia dados, int codMateria)
        {
            SqlConnection conexao = new SqlConnection(Conexao.StringDeConexao);

            string SQL = @"UPDATE Materia SET codPessoa_Revisor=@codPessoa_Revisor, revisao=@revisao, status=@status WHERE codMateria=@codMateria";

            SqlCommand comando = new SqlCommand(SQL, conexao);
            comando.Parameters.AddWithValue("@codMateria", codMateria);
            comando.Parameters.AddWithValue("@codPessoa_Revisor", dados.codPessoa_Revisor);
            comando.Parameters.AddWithValue("@revisao", dados.revisao);
            comando.Parameters.AddWithValue("@status", dados.status);

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
    }
}
