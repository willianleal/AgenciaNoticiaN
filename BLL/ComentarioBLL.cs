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

        public bool inserir(Comentario dados)
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
