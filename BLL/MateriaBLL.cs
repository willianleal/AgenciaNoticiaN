﻿using System;
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

        public string inserir(Materia dados)
        {
            try
            {
                if (dados.codSecao.Equals(-1))
                {
                    return "Informe a seção em que a matéria será publicada.";
                }
                else
                if (dados.nome.Equals(""))
                {
                    return "Informe o nome da matéria.";
                }
                else
                if (dados.materiaEscrita.Equals(""))
                {
                    return "Digite/Escreva a matéria.";
                }
                else
                if (!Util.somenteLetras(dados.nome))
                {
                    return "O nome da matéria deve possuir apenas letras.";
                }
                else
                if (dal.inserir(dados))
                {
                    return "";
                }
                else
                {
                    return "Erro ao cadastrar matéria.";
                }
            }
            catch
            {
                return "Falha ao gravar dados: Entre em contato com o administrador.";
            }
            
            //try
            //{
            //    return dal.inserir(dados);
            //}
            //catch
            //{
            //    return false;
            //}
        }

        public string alterar(Materia dados, int codMateria)
        {
            try
            {
                if (dados.codSecao.Equals(-1))
                {
                    return "Informe a seção em que a matéria será publicada.";
                }
                else
                if (dados.nome.Equals(""))
                {
                    return "Informe o nome da matéria.";
                }
                else
                if (dados.materiaEscrita.Equals(""))
                {
                    return "Digite/Escreva a matéria.";
                }
                else
                if (!Util.somenteLetras(dados.nome))
                {
                    return "O nome da matéria deve possuir apenas letras.";
                }
                else
                if (dal.alterar(dados, codMateria))
                {
                    return "";
                }
                else
                {
                    return "Erro ao editar matéria.";
                }
            }
            catch
            {
                return "Falha ao gravar dados: Entre em contato com o administrador.";
            }
            
            //try
            //{
            //    return dal.alterar(dados, codMateria);
            //}
            //catch
            //{
            //    return false;
            //}
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

        public bool inserirRevisao(Materia dados, int codMateria)
        {
            try
            {
                return dal.inserirRevisao(dados, codMateria);
            }
            catch
            {
                return false;
            }
        }

        public bool inserirRevisorMateria(Materia dados, int codMateria)
        {
            try
            {
                return dal.inserirRevisorMateria(dados, codMateria);
            }
            catch
            {
                return false;
            }
        }
    }
}
