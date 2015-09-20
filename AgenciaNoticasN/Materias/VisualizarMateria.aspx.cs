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
    public partial class VisualizarMateria : System.Web.UI.Page
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
                        popularComentarios(int.Parse(Session["codMateria"].ToString()));
                    }
                }
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
                lblParecerRevisor.Text = "Parecer Revisor: Aprovado";
            else
                if (materia[0].parecerRevisor.Equals("R"))
                    lblParecerRevisor.Text = "Parecer Revisor: Rejeitado";
                else
                    lblParecerRevisor.Visible = false;

            //Alteração do Revisor
            if (materia[0].alteracaoRevisor.Equals("S"))
                lblAlteracaoRevisor.Text = "Houve Alteração: Sim";
            else
                if (materia[0].alteracaoRevisor.Equals("N"))
                    lblAlteracaoRevisor.Text = "Houve Alteração: Não";
                else
                    lblAlteracaoRevisor.Visible = false;

            ///////////////////////////////////////////////////

            //Parecer do Jornalista
            if (materia[0].parecerJornalista.Equals("A"))
                lblParecerJornalista.Text = "Parecer Jornalista: Aprovado";
            else
                if (materia[0].parecerJornalista.Equals("R"))
                    lblParecerJornalista.Text = "Parecer Jornalista: Rejeitado";
                else
                    lblParecerJornalista.Visible = false;

            //Alteração
            if (materia[0].alteracaoJornalista.Equals("S"))
                lblAlteracaoJornalista.Text = "Houve Alteração: Sim";
            else
                if (materia[0].alteracaoJornalista.Equals("N"))
                    lblAlteracaoJornalista.Text = "Houve Alteração: Não";
                else
                    lblAlteracaoJornalista.Visible = false;
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

        protected void popularComentarios(int codMateria)
        {
            ComentarioBLL comentarioBll = new ComentarioBLL();

            dtlComentarios.DataSource = comentarioBll.listarComentarioMateria(codMateria);
            dtlComentarios.DataBind();
        }

        protected void lkInserirComentario_Click(object sender, EventArgs e)
        {
            lblMensagemErro.Text = "";
            
            Comentario comentario = new Comentario();
            ComentarioBLL comentarioBll = new ComentarioBLL();

            //Dados do comentario
            comentario.codMateria = int.Parse(Session["codMateria"].ToString());
            comentario.codPessoa = int.Parse(Session["CodPessoaLogada"].ToString());
            comentario.titulo = txtDescricao.Text;
            comentario.comentario = txtComentario.Text;
            comentario.dataCadastro = DateTime.Now;

            string resposta = comentarioBll.inserir(comentario);

            if (resposta.Equals(""))
                popularComentarios(int.Parse(Session["codMateria"].ToString()));
            else
                lblMensagemErro.Text = resposta;

        }

    }
}