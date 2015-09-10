using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using POCO;

namespace BLL
{
    public class MateriaBLL
    {
        private MateriaDAL dal = null;

        public MateriaBLL()
        {
            dal = new MateriaDAL();
        }

        public bool inserir(Materia dados)
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

        public bool alterar(Materia dados, int codMateria)
        {
            try
            {
                return dal.alterar(dados, codMateria);
            }
            catch
            {
                return false;
            }
        }

        public bool deletar(int codMateria)
        {
            try
            {
                return dal.deletar(codMateria);
            }
            catch
            {
                return false;
            }
        }

        public List<Materia> listar(int codMateria)
        {
            try
            {
                return dal.listar(codMateria);
            }
            catch
            {
                return null;
            }
        }

        public List<Materia> listarMateriaPessoa(int codPessoa_Jornalista, int codPessoa_Revisor, int codPessoa_Publicador, int codPessoa_Gerente)
        {
            try
            {
                return dal.listarMateriaPessoa(codPessoa_Jornalista, codPessoa_Revisor, codPessoa_Publicador, codPessoa_Gerente);
            }
            catch
            {
                return null;
            }
        }

        public List<Materia> listarMateriaJornalista(int codPessoa_Jornalista)
        {
            try
            {
                return dal.listarMateriaJornalista(codPessoa_Jornalista);
            }
            catch
            {
                return null;
            }
        }

        public List<Materia> listarMateriaRevisor(int codPessoa_Revisor)
        {
            try
            {
                return dal.listarMateriaRevisor(codPessoa_Revisor);
            }
            catch
            {
                return null;
            }
        }
    }
}
