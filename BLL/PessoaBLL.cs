using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using POCO;

namespace BLL
{
    public class PessoaBLL
    {
        private PessoaDAL dal = null;

        public PessoaBLL()
        {
            dal = new PessoaDAL();
        }

        public string inserir(Pessoa dados)
        {
            try
            {
                if (dados.nome.Equals(""))
                {
                    return "Informe o nome da pessoa.";
                }
                else
                if (dados.funcao.Equals(-1))
                {
                    return "Informe a função da pessoa.";
                }
                else
                if (dados.ddd.Equals(""))
                {
                    return "Informe o DDD.";
                }
                else
                if (dados.telefone.Equals(""))
                {
                    return "Informe o telefone.";
                }
                else
                if (dados.email.Equals(""))
                {
                    return "Informe o email.";
                }
                else
                if (dados.senha.Equals(""))
                {
                    return "Informe a senha.";
                }
                else
                if (!Util.somenteNumeros(dados.ddd))
                {
                    return "O DDD deve possuir apenas números.";
                }
                else
                if (!Util.somenteNumeros(dados.telefone))
                {
                    return "O Telefone deve possuir apenas números.";
                }
                else
                if (!Util.somenteLetras(dados.nome))
                {
                    return "O nome deve possuir apenas letras.";
                }
                else
                if (!dal.getPessoaEmail(dados.email).ToString().Equals("0"))
                {
                    return "O email informado já está cadastrado para outra pessoa.";
                }
                else
                if (dal.inserir(dados))
                {
                    return "";
                }
                else
                {
                    return "Erro ao cadastrar pessoa.";
                }
            }
            catch
            {
                return "Falha ao gravar dados: Entre em contato com o administrador.";
            }
        }

        public string alterar(Pessoa dados, int codPessoa)
        {
            try
            {
                if (dados.nome.Equals(""))
                {
                    return "Informe o nome da pessoa.";
                }
                else
                if (dados.funcao.Equals(-1))
                {
                    return "Informe a função da pessoa.";
                }
                else
                if (dados.ddd.Equals(""))
                {
                    return "Informe o DDD.";
                }
                else
                if (dados.telefone.Equals(""))
                {
                    return "Informe o telefone.";
                }
                else
                if (dados.email.Equals(""))
                {
                    return "Informe o email.";
                }
                else
                if (!Util.somenteNumeros(dados.ddd))
                {
                    return "O DDD deve possuir apenas números.";
                }
                else
                if (!Util.somenteNumeros(dados.telefone))
                {
                    return "O Telefone deve possuir apenas números.";
                }
                else
                if (!Util.somenteLetras(dados.nome))
                {
                    return "O nome deve possuir apenas letras.";
                }                
                else
                if (dal.alterar(dados, codPessoa))
                {
                    return "";
                }
                else
                {
                    return "Erro ao editar pessoa!";
                }
            }
            catch
            {
                return "Falha ao gravar dados: Entre em contato com o administrador.";
            }
        }

        public bool deletar(int codPessoa)
        {
            try
            {
                return dal.deletar(codPessoa);
            }
            catch
            {
                return false;
            }
        }

        public List<Pessoa> listar()
        {
            try
            {
                return dal.listar();
            }
            catch
            {
                return null;
            }
        }

        public List<Pessoa> listar(int codPessoa)
        {
            try
            {
                return dal.listar(codPessoa);
            }
            catch
            {
                return null;
            }
        }

        public string validarLogin(string email, string senha, bool admin)
        {
            if (email.Equals("") || senha.Equals(""))
            {
                return "Preencha todos os campos";
            }
            else
            {
                string senhaCript = Util.GetMD5Hash(senha);
                return dal.validarAcesso(email, senhaCript, admin);
            }
        }

        public int getPessoaEmail(string email)
        {
            try
            {
                return dal.getPessoaEmail(email);
            }
            catch
            {
                return -1;
            }
        }

        public string getFuncaoPessoa(int codPessoa)
        {
            try
            {
                return dal.getFuncaoPessoa(codPessoa);
            }
            catch
            {
                return "Erro ao procurar pessoa";
            }
        }

    }
}
