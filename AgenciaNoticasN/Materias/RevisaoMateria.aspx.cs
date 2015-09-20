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
    public partial class RevisaoMateria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["email"] == null)
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
            txtNome.Text = materia[0].nome;
            txtMateriaEscrita.Text = materia[0].materiaEscrita;
            lblStatus.Text = materia[0].status;
            lblJornalista.Text = materia[0].Jornalista;
            lblRevisor.Text = materia[0].Revisor;

            Session["parecerRevisor"]   = materia[0].parecerRevisor == null ? "" : materia[0].parecerRevisor;
            Session["alteracaoRevisor"] = materia[0].alteracaoRevisor == null ? "" : materia[0].alteracaoRevisor;

            Session["parecerJornalista"]   = materia[0].parecerJornalista == null ? "" : materia[0].parecerJornalista;
            Session["alteracaoJornalista"] = materia[0].alteracaoJornalista == null ? "" : materia[0].alteracaoJornalista;

            Session["revisao"] = materia[0].revisao == null ? "" : materia[0].revisao;

            //Revisão do Jornalista
            if (materia[0].revisao.Equals("J"))
            {
                //Parecer do Revisor
                if (materia[0].parecerRevisor.Equals("A"))
                    lblParecer.Text = "Parecer Revisor: Aprovado";
                else
                    if (materia[0].parecerRevisor.Equals("R"))
                        lblParecer.Text = "Parecer Revisor: Rejeitado";
                    else
                        lblParecer.Visible = false;

                //Alteração
                if (materia[0].alteracaoRevisor.Equals("S"))
                    lblAlteracao.Text = "Houve Alteração: Sim";
                else
                    if (materia[0].alteracaoRevisor.Equals("N"))
                        lblAlteracao.Text = "Houve Alteração: Não";
                    else
                        lblAlteracao.Visible = false;
            }
            else
            //Revisão do Revisor
            if (materia[0].revisao.Equals("R"))
            {
                //Parecer do Revisor
                if (materia[0].parecerJornalista.Equals("A"))
                    lblParecer.Text = "Parecer Jornalista: Aprovado";
                else
                    if (materia[0].parecerJornalista.Equals("R"))
                        lblParecer.Text = "Parecer Jornalista: Rejeitado";
                    else
                        lblParecer.Visible = false;

                //Alteração
                if (materia[0].alteracaoJornalista.Equals("S"))
                    lblAlteracao.Text = "Houve Alteração: Sim";
                else
                    if (materia[0].alteracaoJornalista.Equals("N"))
                        lblAlteracao.Text = "Houve Alteração: Não";
                    else
                        lblAlteracao.Visible = false;
            }
            else
            {
                lblParecer.Visible   = false;
                lblAlteracao.Visible = false;
            }
        }

        protected void lkGravar_Click(object sender, EventArgs e)
        {
            lblMensagemErro.Text = "";
            
            Materia dados = new Materia();
            Comentario comentario = new Comentario();

            MateriaBLL bll = new MateriaBLL();
            ComentarioBLL comentarioBll = new ComentarioBLL();

            if (rdlAlteracao.SelectedValue.Equals(""))
            {
                lblMensagemErro.Text = "Indique se a matéria será alterada.";
                rdlAlteracao.Focus();
            }
            else
            if (rdlSituacao.SelectedValue.Equals(""))
            {
                lblMensagemErro.Text = "Indique a situação da matéria após a alteração/revisão";
                rdlSituacao.Focus();
            }
            else 
            { 
                //Dados da Matéria revisada
                //Se for revisão do Jornalista ou do Revisor e o status estiver como Aprovado as informações serão salvas
                if ((Session["revisao"].ToString().Equals("R") || Session["revisao"].ToString().Equals("J")) && rdlSituacao.SelectedValue.Equals("A"))
                {
                    dados.nome = txtNome.Text;
                    dados.materiaEscrita = txtMateriaEscrita.Text;
                }
                
                dados.status = Session["status"] == null ? "" : Session["status"].ToString();
                dados.dataAtualizacao = DateTime.Now;

                //Indica se a revisão é do Jornalista ou do Revisor
                if (Session["revisao"].ToString().Equals("J") || Session["revisao"].ToString().Equals(""))
                {
                    dados.parecerJornalista = rdlSituacao.SelectedValue;
                    dados.alteracaoJornalista = rdlAlteracao.SelectedValue;

                    //A revisão volta para o revisor
                    dados.revisao = "R";
                }
                else if (Session["revisao"].ToString().Equals("R"))
                {
                    dados.parecerRevisor = rdlSituacao.SelectedValue;
                    dados.alteracaoRevisor = rdlAlteracao.SelectedValue;

                    //A revisão volta para o jornalista
                    dados.revisao = "J";
                }

                //Dados do comentario
                comentario.codMateria   = int.Parse(Session["codMateria"].ToString());
                comentario.codPessoa    = int.Parse(Session["CodPessoaLogada"].ToString());
                comentario.titulo       = txtDescricao.Text;
                comentario.comentario   = txtComentario.Text;
                comentario.dataCadastro = DateTime.Now;

                txtDescricao.Text = "";
                txtComentario.Text = "";

                string resposta = bll.inserirRevisao(dados, comentario, int.Parse(Session["codMateria"].ToString()));

                if (resposta.Equals(""))
                    Response.Redirect("Materias.aspx");
                else
                    lblMensagemErro.Text = resposta;
            }
        }

        protected void popularComentarios(int codMateria)
        {
            ComentarioBLL comentarioBll = new ComentarioBLL();

            dtlComentarios.DataSource = comentarioBll.listarComentarioMateria(codMateria);
            dtlComentarios.DataBind();
        }

        protected void rdlAlteracao_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblMensagemErro.Text = "";

            if (rdlAlteracao.SelectedValue.Equals("S") && (rdlSituacao.SelectedValue.Equals("A") || rdlSituacao.SelectedValue.Equals("")))
            {
                pnDados.Enabled = true;
                txtMateriaEscrita_HtmlEditorExtender.Enabled = true;
            }    
            else
            if (rdlAlteracao.SelectedValue.Equals("S") && rdlSituacao.SelectedValue.Equals("R"))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "msg('Não é permitido fazer alterações em matérias rejeitadas. Caso você tenha feito alterações elas não serão salvas');", true);
                rdlAlteracao.SelectedValue = "N";
                pnDados.Enabled = false;
                txtMateriaEscrita_HtmlEditorExtender.Enabled = false;
            }
            else
            if (rdlAlteracao.SelectedValue.Equals("N"))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "msg('Não será permitido alterar a matéria. Caso você tenha feito alterações elas não serão salvas');", true);
                pnDados.Enabled = false;
                txtMateriaEscrita_HtmlEditorExtender.Enabled = false;
            }

            verificaStatus();
        }

        protected void rdlSituacao_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblMensagemErro.Text = "";

            if (rdlAlteracao.SelectedValue.Equals("S") && (rdlSituacao.SelectedValue.Equals("A") || rdlSituacao.SelectedValue.Equals("")))
            {
                pnDados.Enabled = true;
                txtMateriaEscrita_HtmlEditorExtender.Enabled = true;
            }    
            else
            if (rdlAlteracao.SelectedValue.Equals("S") && rdlSituacao.SelectedValue.Equals("R"))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "msg('Não é permitido fazer alterações em matérias rejeitadas. Caso você tenha feito alterações elas não serão salvas');", true);
                rdlAlteracao.SelectedValue = "N";
                pnDados.Enabled = false;
                txtMateriaEscrita_HtmlEditorExtender.Enabled = true;
            }
            else
            if (rdlAlteracao.SelectedValue.Equals("N"))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "msg('Não será permitido alterar a matéria. Caso você tenha feito alterações elas não serão salvas');", true);
                pnDados.Enabled = false;
                txtMateriaEscrita_HtmlEditorExtender.Enabled = true;
            }

            verificaStatus();
        }

        protected void verificaStatus()
        {
            //Revisão do Jornalista
            if (Session["revisao"].ToString().Equals("J"))
            {
                //Verifica as aprovações
                if (Session["parecerRevisor"].ToString().Equals("A") && rdlSituacao.SelectedValue.Equals("A") && rdlAlteracao.SelectedValue.Equals("S"))
                {
                    Session["status"] = "Revisao";
                    lkGravar.Text = "Enviar para Revisão";
                }
                else
                if (Session["parecerRevisor"].ToString().Equals("A") && rdlSituacao.SelectedValue.Equals("A") && rdlAlteracao.SelectedValue.Equals("N"))
                {
                    Session["status"] = "Aprovada";
                    lkGravar.Text = "Enviar para Publicação";
                }
                else
                if (Session["parecerRevisor"].ToString().Equals("A") && rdlSituacao.SelectedValue.Equals("R"))
                {
                    Session["status"] = "Revisao";
                    lkGravar.Text = "Enviar para Revisão";
                }
                //Verifica as Reprovações
                else 
                if (Session["parecerRevisor"].ToString().Equals("R") && rdlSituacao.SelectedValue.Equals("R"))
                {
                    Session["status"] = "Arquivada";
                    lkGravar.Text = "Arquivar Matéria";
                }
                else
                if (Session["parecerRevisor"].ToString().Equals("R") && rdlSituacao.SelectedValue.Equals("A") && rdlAlteracao.SelectedValue.Equals("S"))
                {
                    Session["status"] = "Revisao";
                    lkGravar.Text = "Enviar para Revisão";
                }
                else
                if (Session["parecerRevisor"].ToString().Equals("R") && rdlSituacao.SelectedValue.Equals("A") && rdlAlteracao.SelectedValue.Equals("N"))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "msg('Você deve alterar a matéria para submetê-la à uma nova revisão.');", true);
                    lkGravar.Enabled = false;
                }
            }
            //Revisão do Revisor
            else
            if (Session["revisao"].ToString().Equals("R"))
            {
                //Verifica as aprovações
                if (Session["parecerJornalista"].ToString().Equals("A") && rdlSituacao.SelectedValue.Equals("A") && rdlAlteracao.SelectedValue.Equals("S"))
                {
                    Session["status"] = "Revisao";
                    lkGravar.Text = "Enviar para Revisão";
                }
                else
                if (Session["parecerJornalista"].ToString().Equals("A") && rdlSituacao.SelectedValue.Equals("A") && rdlAlteracao.SelectedValue.Equals("N"))
                {
                    Session["status"] = "Aprovada";
                    lkGravar.Text = "Enviar para Publicação";
                }
                else
                if (Session["parecerJornalista"].ToString().Equals("A") && rdlSituacao.SelectedValue.Equals("R"))
                {
                    Session["status"] = "Revisao";
                    lkGravar.Text = "Enviar para Revisão";
                }
                //Verifica as Reprovações
                else
                if (Session["parecerJornalista"].ToString().Equals("R") && rdlSituacao.SelectedValue.Equals("R"))
                {
                    Session["status"] = "Arquivada";
                    lkGravar.Text = "Arquivar Matéria";
                }
                else
                if (Session["parecerJornalista"].ToString().Equals("R") && rdlSituacao.SelectedValue.Equals("A") && rdlAlteracao.SelectedValue.Equals("S"))
                {
                    Session["status"] = "Revisao";
                    lkGravar.Text = "Enviar para Revisão";
                }
                else
                if (Session["parecerJornalista"].ToString().Equals("R") && rdlSituacao.SelectedValue.Equals("A") && rdlAlteracao.SelectedValue.Equals("N"))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "msg('Você deve alterar a matéria para submetê-la à uma nova revisão.');", true);
                    lkGravar.Enabled = false;
                }
                //Faz a primeira revisão. Neste momento ainda não existe parecer do jornalista
                if (Session["parecerJornalista"].ToString().Equals(""))
                {
                    Session["status"] = "Revisao";
                    lkGravar.Text = "Enviar para Revisão";
                }
            }      
        }

    }
}