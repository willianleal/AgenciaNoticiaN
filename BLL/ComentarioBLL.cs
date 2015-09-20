using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using POCO;

namespace BLL
{
    public class ComentarioBLL
    {
        private ComentarioDAL dal = null;

        public ComentarioBLL()
        {
            dal = new ComentarioDAL();
        }

        public string inserir(Comentario dados)
        {
            try
            {
                if (dados.titulo.Equals(""))
                {
                    return "Informe o título do comentário.";
                }
                else
                if (dados.comentario.Equals(""))
                {
                    return "Digite/Escreva o comentário.";
                }
                else
                if (dal.inserir(dados))
                {
                    return "";
                }
                else
                {
                    return "Erro ao gravar o comentário.";
                }
            }
            catch
            {
                return "Falha ao gravar dados: Entre em contato com o administrador.";
            }
        }

        public List<Comentario> listarComentarioMateria(int codMateria)
        {
            try
            {
                return dal.listarComentarioMateria(codMateria);
            }
            catch
            {
                return null;
            }
        }
    }
}
