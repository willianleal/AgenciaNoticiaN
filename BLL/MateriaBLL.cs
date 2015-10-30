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
                //else
                //if (!Util.somenteLetras(dados.nome))
                //{
                //    return "O nome da matéria deve possuir apenas letras.";
                //}
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
                //else
                //if (!Util.somenteLetras(dados.nome))
                //{
                //    return "O nome da matéria deve possuir apenas letras.";
                //}
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

        public List<Materia> listarMateriaPublicador(int codPessoa_Publicador)
        {
            try
            {
                return dal.listarMateriaPublicador(codPessoa_Publicador);
            }
            catch
            {
                return null;
            }
        }

        public List<Materia> listarMateriaGerente(int codPessoa_Gerente)
        {
            try
            {
                return dal.listarMateriaGerente(codPessoa_Gerente);
            }
            catch
            {
                return null;
            }
        }

        public string inserirRevisao(Materia dadosMateria, Comentario dadosComentario, int codMateria)
        {
            try
            {
                //Matéria
                if (dadosMateria.nome.Equals(""))
                {
                    return "Informe o nome da matéria.";
                }
                else
                if (dadosMateria.materiaEscrita.Equals(""))
                {
                    return "Digite/Escreva a matéria.";
                }
                //else
                //if (!Util.somenteLetras(dadosMateria.nome))
                //{
                //    return "O nome da matéria deve possuir apenas letras.";
                //}
                else //Comentário
                if (dadosComentario.titulo.Equals(""))
                {
                    return "Informe uma descrição para o envio.";
                }
                else
                if (dadosComentario.comentario.Equals(""))
                {
                    return "Escreva um comentário sobre a revisão feita.";
                }
                else
                if (dal.inserirRevisao(dadosMateria, dadosComentario, codMateria))
                {
                    return "";
                }
                else
                {
                    return "Erro ao gravar a revisão.";
                }
            }
            catch
            {
                return "Falha ao gravar dados: Entre em contato com o administrador.";
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

        public bool enviarMateria(int codMateria)
        {
            try
            {
                return dal.enviarMateria(codMateria);
            }
            catch
            {
                return false;
            }
        }

        public bool publicarMateria(int codMateria, int codPessoa_Publicador)
        {
            try
            {
                return dal.publicarMateria(codMateria, codPessoa_Publicador);
            }
            catch
            {
                return false;
            }
        }

        public List<Materia> listarMateriaPublicada()
        {
            try
            {
                return dal.listarMateriaPublicada();
            }
            catch
            {
                return null;
            }
        }

        public List<Materia> filtrarMateriaPublicada(string dataAnterior = "", string dataAtual = "", int top=0)
        {
            try
            {
                return dal.filtrarMateriaPublicada(dataAnterior, dataAtual, top);
            }
            catch
            {
                return null;
            }
        }

        public List<Materia> filtrarMateria(int codPessoa_Jornalista, int codPessoa_Revisor, int codPessoa_Publicador, int codPessoa_Gerente, string dataAnterior = "", string dataAtual = "", int top = 0)
        //public List<Materia> listarMateriaJornalista(int codPessoa_Jornalista, string dataAnterior = "", string dataAtual = "", int top = 0)
        {
            try
            {
                return dal.filtrarMateria(codPessoa_Jornalista, codPessoa_Revisor, codPessoa_Publicador, codPessoa_Gerente, dataAnterior, dataAtual, top);
            }
            catch
            {
                return null;
            }
        }
    }
}
