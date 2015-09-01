using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace AgenciaNoticasN.Materias
{
    public partial class MinhasMaterias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            popularMateria();
        }

        protected void popularMateria()
        {
            PessoaBLL listaPessoa = new PessoaBLL();

            gdvMateria.DataSource = listaPessoa.listar(1);
            gdvMateria.DataBind();
        }
    }
}