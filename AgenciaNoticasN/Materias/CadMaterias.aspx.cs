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
            if (Session["email"] == null)
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
            sJavaScript += "document.location.href='Home.aspx';";
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

            dados.codPessoa_Jornalista = pessoaBll.getPessoaEmail(Session["email"].ToString());
            dados.nome           = txtNome.Text;
            dados.codSecao       = ddlSecao.SelectedValue == "" ? -1 : int.Parse(ddlSecao.SelectedValue);
            dados.status         = "Proposta";
            dados.dataCadastro   = DateTime.Now;
            dados.materiaEscrita = txtMateriaEscrita.Text;

            //Inserindo
            if (Session["codMateria"] == null)
            {
                if (bll.inserir(dados))
                    Response.Redirect("Materias.aspx");
                else
                    showMessageBox("Erro ao cadastrar seção!");
            }
            else //Alterando
            {
                if (bll.alterar(dados, int.Parse(Session["codMateria"].ToString())))
                    Response.Redirect("Materias.aspx");
                else
                    showMessageBox("Erro ao alterar seção!");
            }
        }
    }
}