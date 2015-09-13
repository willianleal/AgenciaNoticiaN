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
                        popularComentarios(int.Parse(Session["codMateria"].ToString()));

                        if (lblRevisor.Text.Equals(""))
                        {
                            lblRevisor.Text = "Não definido";
                            lkPegar.Visible = true;
                        }
                        else
                        {
                            lkPegar.Visible = false;
                            pnDados.Enabled = true;
                        }
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
        }

        protected void lkGravar_Click(object sender, EventArgs e)
        {
            Materia dados = new Materia();
            Comentario comentario = new Comentario();

            MateriaBLL bll = new MateriaBLL();
            ComentarioBLL comentarioBll = new ComentarioBLL();
            
            //Dados da Matéria revisada
            dados.nome = txtNome.Text;
            dados.materiaEscrita = txtMateriaEscrita.Text;
            dados.status = "Revisao";
            dados.dataAtualizacao = DateTime.Now;         
            //A revisão passa a ser do jornalista
            dados.revisao = "J";

            //Dados do comentario
            comentario.codMateria   = int.Parse(Session["codMateria"].ToString());
            comentario.codPessoa    = int.Parse(Session["CodPessoaLogada"].ToString());
            comentario.titulo       = txtDescricao.Text;
            comentario.comentario   = txtComentario.Text;
            comentario.dataCadastro = DateTime.Now;  

            if (bll.inserirRevisao(dados, int.Parse(Session["codMateria"].ToString())) && (comentarioBll.inserir(comentario)))
                Response.Redirect("Materias.aspx");
            else
                showMessageBox("Erro ao gravar a revisão!");
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

        protected void lkPegar_Click(object sender, EventArgs e)
        {
            Materia dados = new Materia();
            MateriaBLL bll = new MateriaBLL();

            dados.codPessoa_Revisor = int.Parse(Session["CodPessoaLogada"].ToString());
            //A revisão passa a ser do revisor
            dados.revisao = "R";
            dados.status = "Revisao";
            
            if (bll.inserirRevisorMateria(dados, int.Parse(Session["codMateria"].ToString())))
            {
                pnDados.Enabled = true;
                popularMateria(int.Parse(Session["codMateria"].ToString()));
                lkPegar.Visible = false;
            }   
            else
            {
                showMessageBox("Erro ao gravar a revisão!");
            }       
        }

        protected void popularComentarios(int codMateria)
        {
            ComentarioBLL comentarioBll = new ComentarioBLL();

            dtlComentarios.DataSource = comentarioBll.listarComentarioMateria(codMateria);
            dtlComentarios.DataBind();
        }
    }
}