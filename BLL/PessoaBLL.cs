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
        private PessoaDAL dao = null;

        public PessoaBLL()
        {
            dao = new PessoaDAL();
        }

        public List<Pessoa> Listar(int codPessoa)
        {
            try
            {
                return dao.Listar(codPessoa);
            }
            catch
            {
                return null;
            }
        }
        
        public string validarLogin(string email, string senha)
        {
            if (email.Equals("") || senha.Equals(""))
            {
                return "Preencha todos os campos";
            }
            else
            {
                string senhaCript = Util.GetMD5Hash(senha);
                return dao.validarAcesso(email, senhaCript);
            }
        }

    }
}
