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
    public partial class CadPessoas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CodPessoaLogada"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            else
            if (!IsPostBack)
            {
                Session["codPessoa"] = Request.QueryString["key"] == null ? null : Util.decriptUrl(Request.QueryString["key"].ToString());

                if (Session["codPessoa"] != null)
                {
                    //carrega dados da pessoa
                    popularPessoa(int.Parse(Session["codPessoa"].ToString()));
                }
            }
        }

        protected void showMessageBox(string message)
        {
            string sJavaScript = "<script language=javascript>\n";
            sJavaScript += "alert('" + message + "');";
            sJavaScript += "document.location.href='CadPessoas.aspx';";
            sJavaScript += "\n";
            sJavaScript += "</script>";
            ClientScript.RegisterStartupScript(typeof(string), "MessageBox", sJavaScript);
        }

        protected void popularPessoa(int codPessoa)
        {
            List<Pessoa> pessoa = new List<Pessoa>();
            PessoaBLL bll = new PessoaBLL();

            pessoa = bll.listar(codPessoa);

            txtNome.Text            = pessoa[0].nome;
            ddlFuncao.SelectedValue = pessoa[0].funcao;
            txtDdd.Text             = pessoa[0].ddd;
            txtTelefone.Text        = pessoa[0].telefone;
            txtEmail.Text           = pessoa[0].email;
            chkAtivo.Checked        = pessoa[0].ativo;
            txtSenha.Text           = pessoa[0].senha.ToString();
            txtSenha.DataBind();
        }

        protected void lkGravar_Click(object sender, EventArgs e)
        {
            Pessoa dados = new Pessoa();
            PessoaBLL bll = new PessoaBLL();

            dados.nome         = txtNome.Text;
            dados.funcao       = ddlFuncao.SelectedValue.ToString();
            dados.ddd          = txtDdd.Text;
            dados.telefone     = txtTelefone.Text;
            dados.email        = txtEmail.Text;
            dados.ativo        = chkAtivo.Checked;
            dados.dataCadastro = DateTime.Now;
            dados.senha        = Util.GetMD5Hash(txtSenha.Text);

            string resposta;
            
            //Inserindo
            if (Session["codPessoa"] == null)
            {
                resposta = bll.inserir(dados);
                
                if (resposta.Equals(""))
                    Response.Redirect("Pessoas.aspx");
                else
                   showMessageBox(resposta);
            }
            else //Alterando
            {
                resposta = bll.alterar(dados, int.Parse(Session["codPessoa"].ToString()));
                
                if (resposta.Equals(""))
                    Response.Redirect("Pessoas.aspx");
                else
                    showMessageBox(resposta);
            }
        }
    }
}