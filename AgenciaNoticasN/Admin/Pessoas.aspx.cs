using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using POCO;

namespace AgenciaNoticasN.Admin
{
    public partial class Pessoas : System.Web.UI.Page
    {
        PessoaBLL pessoaBll = new PessoaBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["email"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            else
            if (!IsPostBack)
            {
                popularPessoa();
            } 
        }

        protected void showMessageBox(string message)
        {
            string sJavaScript = "<script language=javascript>\n";
            sJavaScript += "alert('" + message + "');";
            sJavaScript += "document.location.href='Home.aspx';";
            sJavaScript += "\n";
            sJavaScript += "</script>";
            ClientScript.RegisterStartupScript(typeof(string), "MessageBox", sJavaScript);
        }

        protected void popularPessoa()
        {
            gdvPessoa.DataSource = pessoaBll.listar();
            gdvPessoa.DataBind();
        }

        protected void lkNovo_Click(object sender, EventArgs e)
        {
            Response.Redirect("CadPessoas.aspx");
        }

        protected void lbAlterar_Click(object sender, EventArgs e)
        {
            LinkButton id = (LinkButton)sender;
            string[] commandArgs = id.CommandArgument.ToString().Split(new char[] { ',' });//0=codPessoa

            int codPessoa = int.Parse(commandArgs[0]);
            
            Response.Redirect("CadPessoas.aspx?key=" + Util.criptUrl(codPessoa.ToString()));
        }

        protected void lbDeletar_Click(object sender, EventArgs e)
        {
            LinkButton id = (LinkButton)sender;
            string[] commandArgs = id.CommandArgument.ToString().Split(new char[] { ',' });//0=codPessoa

            int codPessoa = int.Parse(commandArgs[0]);

            pessoaBll.deletar(codPessoa);

            popularPessoa();
        }
    }
}