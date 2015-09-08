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
        private MateriaDAL dao = null;

        public MateriaBLL()
        {
            dao = new MateriaDAL();
        }

        public bool inserir(int codMateria, int codPessoa_Jornalista, int codPessoa_Revisor, int codPessoa_Publicador, string nome, string materiaEscrita, 
            int codSecao, string status, DateTime dataCadastro, DateTime dataAtualizacao)
        {
            try
            {
                return dao.inserir(codMateria, codPessoa_Jornalista, codPessoa_Revisor, codPessoa_Publicador, nome, materiaEscrita, codSecao, status, dataCadastro, dataAtualizacao);
            }
            catch
            {
                return false;
            }
        }

        public bool inserir(Materia dados)
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

        public bool alterar(int codMateria, int codPessoa_Jornalista, int codPessoa_Revisor, int codPessoa_Publicador, string nome, string materiaEscrita, 
            int codSecao, string status, DateTime dataCadastro, DateTime dataAtualizacao)
        {
            try
            {
                return dao.alterar(codMateria, codPessoa_Jornalista, codPessoa_Revisor, codPessoa_Publicador, nome, materiaEscrita, codSecao, status, dataCadastro, dataAtualizacao);
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
                return dao.alterar(dados, codMateria);
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
                return dao.deletar(codMateria);
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
                return dao.listar(codMateria);
            }
            catch
            {
                return null;
            }
        }

        public List<Materia> listarMateriaPessoa(int codPessoa_Jornalista, int codPessoa_Revisor, int codPessoa_Publicador, int codSecao)
        {
            try
            {
                return dao.listarMateriaPessoa(codPessoa_Jornalista, codPessoa_Revisor, codPessoa_Publicador, codSecao);
            }
            catch
            {
                return null;
            }
        }
    }
}
