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
    public class ComentarioDAL
    {
        public bool inserir(Comentario dados)
        {
            SqlConnection conexao = new SqlConnection(Conexao.StringDeConexao);

            string SQL = @"INSERT INTO Comentario(codMateria, codPessoa, titulo, comentario, dataCadastro) 
                               VALUES(@codMateria, @codPessoa, @titulo, @comentario, @dataCadastro)";

            SqlCommand comando = new SqlCommand(SQL, conexao);
            //comando.Parameters.AddWithValue("@codComentario", dados.codComentario);
            comando.Parameters.AddWithValue("@codMateria", dados.codMateria);
            comando.Parameters.AddWithValue("@codPessoa", dados.codPessoa);
            comando.Parameters.AddWithValue("@titulo", dados.titulo);
            comando.Parameters.AddWithValue("@comentario", dados.comentario);
            comando.Parameters.AddWithValue("@dataCadastro", dados.dataCadastro);

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

        public List<Comentario> listarComentarioMateria(int codMateria)
        {
            List<Comentario> comentario = new List<Comentario>();

            SqlConnection conexao = new SqlConnection(Conexao.StringDeConexao);

            string SQL = @"SELECT 
                            codComentario, codMateria, c.codPessoa, p.nome, p.funcao, titulo, comentario, c.dataCadastro 
                           FROM Comentario c
                           INNER JOIN Pessoa p on p.codPessoa=c.codPessoa
                           WHERE codMateria=@codMateria
                           ORDER BY dataCadastro DESC";

            SqlCommand comando = new SqlCommand(SQL, conexao);
            comando.Parameters.AddWithValue("@codMateria", codMateria);

            try
            {
                conexao.Open();
                SqlDataReader resultado = comando.ExecuteReader();

                while (resultado.Read())
                {
                    Comentario dadosComentario = new Comentario();

                    dadosComentario.codComentario = (int)resultado["codComentario"];
                    dadosComentario.codMateria    = (int)resultado["codMateria"];
                    dadosComentario.codPessoa     = (int)resultado["codPessoa"];
                    dadosComentario.titulo        = resultado["titulo"].ToString();
                    dadosComentario.comentario    = resultado["comentario"].ToString();
                    dadosComentario.dataCadastro  = (DateTime)resultado["dataCadastro"];
                    dadosComentario.Pessoa        = resultado["nome"].ToString();
                    dadosComentario.Funcao        = resultado["funcao"].ToString();
                    comentario.Add(dadosComentario);
                }

                return comentario;
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
