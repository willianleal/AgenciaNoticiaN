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
            int codMateria = int.Parse(id.CommandArgument.ToString());

            materiaBll.deletar(codMateria);
        }

        protected void lbAlterar_Click(object sender, EventArgs e)
        {
            LinkButton id = (LinkButton)sender;
            int codMateria = int.Parse(id.CommandArgument.ToString());

            //materiaBll.alterar(codMateria);
        }
    }
}