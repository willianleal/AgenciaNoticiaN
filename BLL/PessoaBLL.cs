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

        public bool inserir(Pessoa dados)
        {
            try
            {
                return dal.inserir(dados);
            }
            catch
            {
                return false;
            }
        }

        public bool alterar(Pessoa dados, int codPessoa)
        {
            try
            {
                return dal.alterar(dados, codPessoa);
            }
            catch
            {
                return false;
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
