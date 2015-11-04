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
            //MateriaBLL bll = new MateriaBLL();

            //dtlMateria.DataSource = bll.listarMateriaPublicada();
            //dtlMateria.DataBind();
            popularMateria();
        }

        protected void popularMateria()
        {
            MateriaBLL bll = new MateriaBLL();
            
            dtlMateria.DataSource = bll.listarMateriaPublicada();
            dtlMateria.DataBind();
        }

        protected void filtrarMateria(string dataAnterior="", string dataAtual="", int top=0)
        {
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

                filtrarMateria(dataAnterior.ToShortDateString(), dataAtual.ToShortDateString());
            }
            else
            if (ddlFiltrar.SelectedValue.Equals("2")) //Último mês
            { 
                dataAnterior = dataAtual.AddMonths(-1);

                filtrarMateria(dataAnterior.ToShortDateString(), dataAtual.ToShortDateString());
            }
            else
            if (ddlFiltrar.SelectedValue.Equals("3")) //Último ano
            { 
                dataAnterior = dataAtual.AddYears(-1);

                filtrarMateria(dataAnterior.ToShortDateString(), dataAtual.ToShortDateString());
            }
            else
            if (ddlFiltrar.SelectedValue.Equals("4")) //Top 15
            {
                filtrarMateria("", "", 15);
            }
            else
            if (ddlFiltrar.SelectedValue.Equals("5")) //Top 60
            {
                filtrarMateria("", "", 60);
            }
        }
    }
}