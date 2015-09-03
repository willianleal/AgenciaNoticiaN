using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AgenciaNoticasN.Materias
{
    public partial class CadPessoas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Session["codEncomenda"] = Request.QueryString["key"] == null ? null : ConsulplanUtil.decriptUrl(Request.QueryString["key"].ToString());

                //if (Session["codEncomenda"] != null
                //{
                //    //carrega dados da pessoa
                //    popularPessoa();
                //}
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
            //Função para carregar pessoasEncomendaQuestaoBLL listaEncomenda = new EncomendaQuestaoBLL();

            /*List<EncomendaQuestao> encomenda = new List<EncomendaQuestao>();
            encomenda = listaEncomenda.getEncomendaUsuario(codEncomenda, codUsuario);

            //Pega os dados da encomenda e carrega na tela
            ddlEmpresa.SelectedValue = encomenda[0].CodEmpresa.ToString();
            ddlProcesso.SelectedValue = encomenda[0].CodProcesso.ToString();
            txtDescricao.Text = encomenda[0].Descricao;
            ddlArea.SelectedValue = encomenda[0].CodArea.ToString();

            if (encomenda[0].QtdRespostas.ToString().Equals("4") || encomenda[0].QtdRespostas.ToString().Equals("5"))
            {
                lblQtdResp.Visible = false;
                txtQtdResp.Visible = false;
                txtQtdResp.Text = encomenda[0].QtdRespostas.ToString();
                ddlQtdResp.Items.FindByText(encomenda[0].QtdRespostas.ToString()).Selected = true;
            }
            else
            {
                lblQtdResp.Visible = true;
                txtQtdResp.Visible = true;
                txtQtdResp.Text = encomenda[0].QtdRespostas.ToString();
                ddlQtdResp.SelectedIndex = 3;
            }

            ddlNivelEscolaridade.SelectedValue = encomenda[0].CodNivel.ToString();
            ddlProfessor.SelectedValue = encomenda[0].CpfProfessor.ToString();
            txtQtdQuestao.Text = encomenda[0].QtdQuestoes.ToString();
            txtValor.Text = encomenda[0].ValorQuestao.ToString();
            txtDataEntrega.Text = encomenda[0].DataEntrega.ToString();
            txtObservacao.Text = encomenda[0].ObservacoesPedag;
            txtConteudo.Text = encomenda[0].ConteudoProgramatico;

            //Armazena o codArquivo da encomenda
            Session["codArquivo"] = encomenda[0].CodArquivo.ToString();*/
        }
    }
}