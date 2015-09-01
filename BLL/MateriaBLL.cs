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

        public bool inserir(int codMateria, int codPessoa_Jornalista, int codPessoa_Revisor, int codPessoa_Publicador, string nome, string materiaEscrita, 
            int codSecao, string status, DateTime dataCadastro, DateTime dataAtualizacao)
        {
            try
            {
                return dal.inserir(codMateria, codPessoa_Jornalista, codPessoa_Revisor, codPessoa_Publicador, nome, materiaEscrita, codSecao, status, dataCadastro, dataAtualizacao);
            }
            catch
            {
                return false;
            }
        }

        public bool alterar(int codMateria, int codPessoa_Jornalista, int codPessoa_Revisor, int codPessoa_Publicador, string nome, string materiaEscrita, 
            int codSecao, string status, DateTime dataCadastro, DateTime dataAtualizacao)
        {
            try
            {
                return dal.alterar(codMateria, codPessoa_Jornalista, codPessoa_Revisor, codPessoa_Publicador, nome, materiaEscrita, codSecao, status, dataCadastro, dataAtualizacao);
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
    }
}
