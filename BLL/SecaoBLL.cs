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
        private SecaoDAL dao = null;

        public SecaoBLL()
        {
            dao = new SecaoDAL();
        }

        public bool inserir(int codSecao, string nome, int codPessoa_Gerente, DateTime dataCadastro)
        {
            try
            {
                return dao.inserir(codSecao, nome, codPessoa_Gerente, dataCadastro);
            }
            catch
            {
                return false;
            }
        }

        public bool inserir(Secao dados)
        {
            try
            {
                return dao.inserir(dados);
            }
            catch
            {
                return false;
            }
        }

        public bool alterar(int codSecao, string nome, int codPessoa_Gerente, DateTime dataCadastro)
        {
            try
            {
                return dao.alterar(codSecao, nome, codPessoa_Gerente, dataCadastro);
            }
            catch
            {
                return false;
            }
        }

        public bool alterar(Secao dados, int codSecao)
        {
            try
            {
                return dao.alterar(dados, codSecao);
            }
            catch
            {
                return false;
            }
        }

        public bool deletar(int codSecao)
        {
            try
            {
                return dao.deletar(codSecao);
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
                return dao.listar(codSecao);
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
                return dao.listar();
            }
            catch
            {
                return null;
            }
        }
    }
}
