using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using POCO;

namespace AgenciaNoticasN.Materias
{
    public partial class PublicarMateria : System.Web.UI.Page
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
                }
            }
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

            lblStatus.Text = materia[0].status;
            lblJornalista.Text = materia[0].Jornalista;
            lblRevisor.Text = materia[0].Revisor;
            ddlSecao.SelectedValue = materia[0].codSecao.ToString();
            txtNome.Text = materia[0].nome;
            txtMateriaEscrita.Text = materia[0].materiaEscrita;

            //Parecer do Revisor
            if (materia[0].parecerRevisor.Equals("A"))
                lblParecerRevisor.Text = "Parecer do Revisor: Aprovado";
            else
                if (materia[0].parecerRevisor.Equals("R"))
                    lblParecerRevisor.Text = "Parecer do Revisor: Rejeitado";
                else
                    lblParecerRevisor.Visible = false;

            //Alteração do Revisor
            if (materia[0].alteracaoRevisor.Equals("S"))
                lblParecerRevisor.Text += " com alteração";
            else
                if (materia[0].alteracaoRevisor.Equals("N"))
                    lblParecerRevisor.Text += " sem alteração";
                else
                    lblParecerRevisor.Visible = false;

            ///////////////////////////////////////////////////

            //Parecer do Jornalista
            if (materia[0].parecerJornalista.Equals("A"))
                lblParecerJornalista.Text = "Parecer do Jornalista: Aprovado";
            else
                if (materia[0].parecerJornalista.Equals("R"))
                    lblParecerJornalista.Text = "Parecer do Jornalista: Rejeitado";
                else
                    lblParecerJornalista.Visible = false;

            //Alteração
            if (materia[0].alteracaoJornalista.Equals("S"))
                lblParecerJornalista.Text += " com alteração";
            else
                if (materia[0].alteracaoJornalista.Equals("N"))
                    lblParecerJornalista.Text += " sem alteração";
                else
                    lblParecerJornalista.Visible = false;
        }

        protected void lkPublicar_Click(object sender, EventArgs e)
        {
            MateriaBLL materiaBll = new MateriaBLL();

            int codMateria = int.Parse(Session["codMateria"].ToString());

            int codPessoa = int.Parse(Session["CodPessoaLogada"].ToString());

            if (materiaBll.publicarMateria(codMateria, codPessoa))
            {
                Response.Redirect("Materias.aspx");
            }
            else
            {
                lblMensagemErro.Text = "Erro ao publicar matéria.";
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "msg('Erro ao publicar matéria.');", true);
            }
        }
    }
}