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
        MateriaBLL materiaBll = new MateriaBLL();
        PessoaBLL pessoaBll = new PessoaBLL();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["CodPessoa"] = pessoaBll.getPessoaEmail(Session["email"].ToString());
            popularMateria();
        }

        protected void popularMateria()
        {
            int codPessoa = int.Parse(Session["CodPessoa"].ToString());

            gdvMateria.DataSource = materiaBll.listarMateriaPessoa(codPessoa, 0, 0, 0);
            gdvMateria.DataBind();
        }

        protected void lbDeletar_Click(object sender, EventArgs e)
        {
            LinkButton id = (LinkButton)sender;
            string[] commandArgs = id.CommandArgument.ToString().Split(new char[] { ',' });//0=codMateria

            int codMateria = int.Parse(commandArgs[0]);

            materiaBll.deletar(codMateria);
            gdvMateria.DataBind();
        }

        protected void lbAlterar_Click(object sender, EventArgs e)
        {
            LinkButton id = (LinkButton)sender;
            string[] commandArgs = id.CommandArgument.ToString().Split(new char[] { ',' });//0=codMateria

            int codMateria = int.Parse(commandArgs[0]);

            Response.Redirect("CadMateria.aspx?key=" + Util.criptUrl(codMateria.ToString()));
        }

        protected void lkNovo_Click(object sender, EventArgs e)
        {
            Response.Redirect("CadMaterias.aspx");
        }
    }
}