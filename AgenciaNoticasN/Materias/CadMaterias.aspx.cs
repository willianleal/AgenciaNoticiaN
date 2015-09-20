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
    public partial class CadMaterias : System.Web.UI.Page
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
                popularSecoes();

                Session["codMateria"] = Request.QueryString["key"] == null ? null : Util.decriptUrl(Request.QueryString["key"].ToString());

                if (Session["codMateria"] != null)
                {
                    //carrega dados da pessoa
                    popularMateria(int.Parse(Session["codMateria"].ToString()));

                    pnDados.Visible = true;
                }
            }
        }

        protected void showMessageBox(string message)
        {
            string sJavaScript = "<script language=javascript>\n";
            sJavaScript += "alert('" + message + "');";
            sJavaScript += "document.location.href='CadMaterias.aspx';";
            sJavaScript += "\n";
            sJavaScript += "</script>";
            ClientScript.RegisterStartupScript(typeof(string), "MessageBox", sJavaScript);
        }

        protected void popularSecoes()
        {
            SecaoBLL listaSecao = new SecaoBLL();
            ddlSecao.Items.Clear();

            ddlSecao.DataSource = listaSecao.listar();
            ddlSecao.DataTextField = "nome";
            ddlSecao.DataValueField = "codSecao";
            ddlSecao.Items.Add(new ListItem("Selecione", ""));
            ddlSecao.DataBind();
        }

        protected void popularMateria(int codMateria)
        {
            List<Materia> materia = new List<Materia>();
            MateriaBLL bll = new MateriaBLL();

            materia = bll.listar(codMateria);

            ddlSecao.SelectedValue = materia[0].codSecao.ToString();
            txtNome.Text           = materia[0].nome;
            txtMateriaEscrita.Text = materia[0].materiaEscrita;
            lblStatus.Text         = materia[0].status;
            lblJornalista.Text     = materia[0].Jornalista;
        }

        protected void lkGravar_Click(object sender, EventArgs e)
        {
            Materia dados = new Materia();
            MateriaBLL bll = new MateriaBLL();
            PessoaBLL pessoaBll = new PessoaBLL();
            
            dados.codPessoa_Jornalista = int.Parse(Session["CodPessoaLogada"].ToString());
            dados.nome                 = txtNome.Text;
            dados.codSecao             = ddlSecao.SelectedValue == "" ? -1 : int.Parse(ddlSecao.SelectedValue);
            dados.status               = "Proposta";
            dados.materiaEscrita       = txtMateriaEscrita.Text;

            string resposta;
            
            //Inserindo
            if (Session["codMateria"] == null)
            {
                dados.dataCadastro = DateTime.Now;
                
                resposta = bll.inserir(dados);
                
                if (resposta.Equals(""))
                    Response.Redirect("Materias.aspx");
                else
                    lblMensagemErro.Text = resposta;
                    //showMessageBox("Erro ao cadastrar seção!");
            }
            else //Alterando
            {
                dados.dataAtualizacao = DateTime.Now;

                resposta = bll.alterar(dados, int.Parse(Session["codMateria"].ToString()));
                
                if (resposta.Equals(""))
                    Response.Redirect("Materias.aspx");
                else
                    lblMensagemErro.Text = resposta;
                    //showMessageBox("Erro ao alterar seção!");
            }
        }
    }
}