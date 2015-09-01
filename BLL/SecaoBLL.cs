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
    }
}
