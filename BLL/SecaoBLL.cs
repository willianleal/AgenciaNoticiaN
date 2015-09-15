using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using POCO;

namespace BLL
{
    public class SecaoBLL
    {
        private SecaoDAL dal = null;

        public SecaoBLL()
        {
            dal = new SecaoDAL();
        }

        public string inserir(Secao dados)
        {
            try
            {
                if (dados.nome.Equals(""))
                {
                    return "Informe o nome da seção.";
                }
                else
                if (dados.codPessoa_Gerente.Equals(-1))
                {
                    return "Informe o gerente da seção.";
                }
                else
                if (!Util.somenteLetras(dados.nome))
                {
                    return "O nome deve possuir apenas letras.";
                }
                else
                if (dal.inserir(dados))
                {
                    return "";
                }
                else
                {
                    return "Erro ao cadastrar seção.";
                }
            }
            catch
            {
                return "Falha ao gravar dados: Entre em contato com o administrador.";
            }
            

            //try
            //{
            //    return dao.inserir(dados);
            //}
            //catch
            //{
            //    return false;
            //}
        }

        public string alterar(Secao dados, int codSecao)
        {
            try
            {
                if (dados.nome.Equals(""))
                {
                    return "Informe o nome da seção.";
                }
                else
                if (dados.codPessoa_Gerente.Equals(-1))
                {
                    return "Informe o gerente da seção.";
                }
                else
                if (!Util.somenteLetras(dados.nome))
                {
                    return "O nome deve possuir apenas letras.";
                }
                else
                if (dal.alterar(dados, codSecao))
                {
                    return "";
                }
                else
                {
                    return "Erro ao editar seção.";
                }
            }
            catch
            {
                return "Falha ao gravar dados: Entre em contato com o administrador.";
            }
            
            //try
            //{
            //    return dal.alterar(dados, codSecao);
            //}
            //catch
            //{
            //    return false;
            //}
        }

        public bool deletar(int codSecao)
        {
            try
            {
                return dal.deletar(codSecao);
            }
            catch
            {
                return false;
            }
        }

        public List<Secao> listar(int codSecao)
        {
            try
            {
                return dal.listar(codSecao);
            }
            catch
            {
                return null;
            }
        }

        public List<Secao> listar()
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
    }
}
