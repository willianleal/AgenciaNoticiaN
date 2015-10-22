using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using POCO;

namespace AgenciaNoticasN
{
    public partial class Default1 : System.Web.UI.Page
    {
        MateriaBLL materiaBll = new MateriaBLL();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            MateriaBLL bll = new MateriaBLL();

            dtlMateria.DataSource = bll.listarMateriaPublicada();
            dtlMateria.DataBind();
        }

        protected void popularMateria(string dataAnterior="", string dataAtual="", int top=0)
        {
            //Pega a função da pessoa logada
            //string funcao = pessoaBll.getFuncaoPessoa(codPessoa);

            //if (funcao.Equals("Jornalista"))
            //{
            //    dtlMateria.DataSource = materiaBll.listarMateriaJornalista(codPessoa, dataAnterior, dataAtual, top);
            //}
            //else
            //if (funcao.Equals("Revisor"))
            //{
            //    dtlMateria.DataSource = materiaBll.listarMateriaRevisor(codPessoa, dataAnterior, dataAtual, top);
            //}
            //else
            //if (funcao.Equals("Publicador"))
            //{
            //    dtlMateria.DataSource = materiaBll.listarMateriaPublicador(codPessoa, dataAnterior, dataAtual, top);
            //}
            //else
            //if (funcao.Equals("Gerente"))
            //{
            //    dtlMateria.DataSource = materiaBll.listarMateriaGerente(codPessoa, dataAnterior, dataAtual, top);
            //}

            dtlMateria.DataSource = materiaBll.filtrarMateriaPublicada(dataAnterior, dataAtual, top);
            dtlMateria.DataBind();
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            DateTime dataAtual = DateTime.Now;
            
            DateTime dataAnterior;

            if (ddlFiltrar.SelectedValue.Equals("1")) //Última semana
            {
                dataAnterior = dataAtual.AddDays(-7);

                popularMateria(dataAnterior.ToShortDateString(), dataAtual.ToShortDateString());
            }
            else
            if (ddlFiltrar.SelectedValue.Equals("2")) //Último mês
            { 
                dataAnterior = dataAtual.AddMonths(-1);

                popularMateria(dataAnterior.ToShortDateString(), dataAtual.ToShortDateString());
            }
            else
            if (ddlFiltrar.SelectedValue.Equals("3")) //Último ano
            { 
                dataAnterior = dataAtual.AddYears(-1);

                popularMateria(dataAnterior.ToShortDateString(), dataAtual.ToShortDateString());
            }
            else
            if (ddlFiltrar.SelectedValue.Equals("4")) //Top 15
            {
                popularMateria("", "", 15);
            }
            else
            if (ddlFiltrar.SelectedValue.Equals("5")) //Top 30
            {
                popularMateria("", "", 30);
            }
        }
    }
}