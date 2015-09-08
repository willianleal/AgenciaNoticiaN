using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace AgenciaNoticasN.Materias
{
    public partial class Secoes : System.Web.UI.Page
    {
        SecaoBLL secaoBll = new SecaoBLL();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            popularSecao();
        }

        protected void popularSecao()
        {
            //int codSecao = int.Parse(Session["CodSecao"].ToString());

            gdvSecoes.DataSource = secaoBll.listar();
            gdvSecoes.DataBind();
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

        protected void lkNovo_Click(object sender, EventArgs e)
        {
            Response.Redirect("CadSecoes.aspx");
        }

        protected void lbAlterar_Click(object sender, EventArgs e)
        {
            LinkButton id = (LinkButton)sender;
            string[] commandArgs = id.CommandArgument.ToString().Split(new char[] { ',' });//0=codSecao

            int codSecao = int.Parse(commandArgs[0]);

            Response.Redirect("CadSecao.aspx?key=" + Util.criptUrl(codSecao.ToString()));
        }

        protected void lbDeletar_Click(object sender, EventArgs e)
        {
            LinkButton id = (LinkButton)sender;
            string[] commandArgs = id.CommandArgument.ToString().Split(new char[] { ',' });//0=codSecao

            int codSecao = int.Parse(commandArgs[0]);

            secaoBll.deletar(codSecao);
            gdvSecoes.DataBind();
        }
    }
}