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
    public partial class CadSecoes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["nomeSession"] == null)
            //{
            //    Response.Redirect("~/SessionOut.aspx");
            //}
            //else
            if (!IsPostBack)
            {
                popularGerente();
                
                Session["codSecao"] = Request.QueryString["key"] == null ? null : Util.decriptUrl(Request.QueryString["key"].ToString());

                if (Session["codSecao"] != null)
                {
                    //carrega dados da pessoa
                    popularSecao(int.Parse(Session["codSecao"].ToString()));
                    //popularPessoa(int.Parse(Session["codPessoa"].ToString()));
                }
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

        protected void popularSecao(int codSecao)
        {
            List<Secao> secao = new List<Secao>();
            SecaoBLL bll = new SecaoBLL();

            secao = bll.listar(codSecao);

            txtNome.Text = secao[0].nome;
            ddlGerente.SelectedValue = secao[0].codPessoa_Gerente.ToString();
            //ddlFuncao.SelectedValue = pessoa[0].funcao;
            

            //protected void popularNiveisEnsino()
            //{
            //    NiveisEnsinoBLL listaNiveisEnsino = new NiveisEnsinoBLL();
            //    ddlCodNivel.Items.Clear();
            //    ddlCodNivel.DataSource = listaNiveisEnsino.Listar(" and CodNivel <> 5 ");
            //    ddlCodNivel.DataTextField = "Nivel";
            //    ddlCodNivel.DataValueField = "CodNivel";
            //    ddlCodNivel.Items.Add(new ListItem("Selecione", ""));
            //    ddlCodNivel.DataBind();
            //}
        }

        protected void popularGerente()
        {
            PessoaBLL listaPessoa = new PessoaBLL();
            ddlGerente.Items.Clear();

            ddlGerente.DataSource = listaPessoa.listar();
            ddlGerente.DataTextField = "nome";
            ddlGerente.DataValueField = "codPessoa";
            ddlGerente.Items.Add(new ListItem("Selecione", ""));
            ddlGerente.DataBind();
        }

        protected void lkGravar_Click(object sender, EventArgs e)
        {
            Secao dados = new Secao();
            SecaoBLL bll = new SecaoBLL();

            dados.nome              = txtNome.Text;
            dados.codPessoa_Gerente = ddlGerente.SelectedValue == "" ? -1 : int.Parse(ddlGerente.SelectedValue);
            dados.dataCadastro      = DateTime.Now;

            //Inserindo
            if (Session["codSecao"] == null)
            {
                if (bll.inserir(dados))
                    Response.Redirect("Secoes.aspx");
                else
                    showMessageBox("Erro ao cadastrar seção!");
            }
            else //Alterando
            {
                if (bll.alterar(dados, int.Parse(Session["codSecao"].ToString())))
                    Response.Redirect("Secoes.aspx");
                else
                    showMessageBox("Erro ao alterar seção!");
            }
        }
    }
}