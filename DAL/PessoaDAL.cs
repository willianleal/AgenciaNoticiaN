﻿using System;
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
        public bool inserir(int codPessoa, string nome, string funcao, string ddd, string telefone, string email, bool ativo, DateTime dataCadastro, string senha)
        {
            SqlConnection conexao = new SqlConnection(Conexao.StringDeConexao);

            string SQL = "INSERT INTO Pessoa(nome, funcao, ddd, telefone, email, ativo, dataCadastro, senha) VALUES(@nome, @funcao, @ddd, @telefone, @email, @ativo, @dataCadastro, @senha)";
            
            SqlCommand comando = new SqlCommand(SQL, conexao);
            //comando.Parameters.AddWithValue("@codPessoa", codPessoa);
            comando.Parameters.AddWithValue("@nome", nome);
            comando.Parameters.AddWithValue("@funcao", funcao);
            comando.Parameters.AddWithValue("@ddd", ddd);
            comando.Parameters.AddWithValue("@telefone", telefone);
            comando.Parameters.AddWithValue("@email", email);
            comando.Parameters.AddWithValue("@ativo", ativo);
            comando.Parameters.AddWithValue("@dataCadastro", dataCadastro);
            comando.Parameters.AddWithValue("@senha", senha);

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

        public List<Pessoa> Listar(int codPessoa)
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
                    dadosPessoa.email = resultado["email"].ToString();

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

        public string validarAcesso(string email, string senhaCript)
        {
            SqlConnection conexao = new SqlConnection(Conexao.StringDeConexao);
            string SQL = "select email, senha from Pessoa where email=@email";
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

    }
}