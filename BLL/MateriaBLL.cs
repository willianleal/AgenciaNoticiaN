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

        public List<Materia> listarMateriaJornalista(int codPessoa_Jornalista, string dataAnterior="", string dataAtual="", int top=0)
        {
            try
            {
                return dal.listarMateriaJornalista(codPessoa_Jornalista, dataAnterior, dataAtual, top);
            }
            catch
            {
                return null;
            }
        }

        public List<Materia> listarMateriaRevisor(int codPessoa_Revisor, string dataAnterior = "", string dataAtual = "", int top = 0)
        {
            try
            {
                return dal.listarMateriaRevisor(codPessoa_Revisor, dataAnterior, dataAtual, top);
            }
            catch
            {
                return null;
            }
        }

        public List<Materia> listarMateriaPublicador(int codPessoa_Publicador, string dataAnterior = "", string dataAtual = "", int top = 0)
        {
            try
            {
                return dal.listarMateriaPublicador(codPessoa_Publicador, dataAnterior, dataAtual, top);
            }
            catch
            {
                return null;
            }
        }

        public List<Materia> listarMateriaGerente(int codPessoa_Gerente, string dataAnterior = "", string dataAtual = "", int top = 0)
        {
            try
            {
                return dal.listarMateriaGerente(codPessoa_Gerente, dataAnterior, dataAtual, top);
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
    }
}
