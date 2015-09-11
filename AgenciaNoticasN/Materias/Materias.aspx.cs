using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace AgenciaNoticasN.Admin
{
    public partial class MinhasMaterias : System.Web.UI.Page
    {
        MateriaBLL materiaBll = new MateriaBLL();
        PessoaBLL pessoaBll = new PessoaBLL();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["email"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            else
            if (!IsPostBack)
            {
                popularMateria();
            }
        }

        protected void popularMateria()
        {
            //Pega o código da pessoa logada
            int codPessoa = int.Parse(Session["CodPessoaLogada"].ToString());

            //Pega a função da pessoa logada
            string funcao = pessoaBll.getFuncaoPessoa(codPessoa);

            if (funcao.Equals("Jornalista"))
                gdvMateria.DataSource = materiaBll.listarMateriaJornalista(codPessoa);
            else
                if (funcao.Equals("Revisor"))
                    gdvMateria.DataSource = materiaBll.listarMateriaRevisor(codPessoa);
                //else
                //    if (funcao.Equals("Publicador"))
                //        gdvMateria.DataSource = materiaBll.listarMateriaPessoa(0, 0, codPessoa, 0);
                //    else
                //        if (funcao.Equals("Gerente"))
                //            gdvMateria.DataSource = materiaBll.listarMateriaPessoa(0, 0, 0, codPessoa);

            gdvMateria.DataBind();
        }

        protected void lbDeletar_Click(object sender, EventArgs e)
        {
            LinkButton id = (LinkButton)sender;
            string[] commandArgs = id.CommandArgument.ToString().Split(new char[] { ',' });//0=codMateria

            int codMateria = int.Parse(commandArgs[0]);

            int codPessoa = int.Parse(Session["CodPessoaLogada"].ToString());

            if (pessoaBll.getFuncaoPessoa(codPessoa).Equals("Jornalista"))
                materiaBll.deletar(codMateria);
            else
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "msg('Somente jornalistas possuem permissão para deletar matérias.');", true);

            popularMateria();
        }

        protected void lbAlterar_Click(object sender, EventArgs e)
        {
            LinkButton id = (LinkButton)sender;
            string[] commandArgs = id.CommandArgument.ToString().Split(new char[] { ',' });//0=codMateria

            int codMateria = int.Parse(commandArgs[0]);

            int codPessoa = int.Parse(Session["CodPessoaLogada"].ToString());

            if (pessoaBll.getFuncaoPessoa(codPessoa).Equals("Jornalista"))
                Response.Redirect("CadMaterias.aspx?key=" + Util.criptUrl(codMateria.ToString()));
            else
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "msg('Somente jornalistas possuem permissão para alterar matérias.');", true);
        }

        protected void lkNovo_Click(object sender, EventArgs e)
        {
            int codPessoa = int.Parse(Session["CodPessoaLogada"].ToString());

            if (pessoaBll.getFuncaoPessoa(codPessoa).Equals("Jornalista"))
                Response.Redirect("CadMaterias.aspx");
            else
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "msg('Somente jornalistas possuem permissão para cadastrar matérias.');", true);
        }

        protected void lbRevisar_Click(object sender, EventArgs e)
        {
            LinkButton id = (LinkButton)sender;
            string[] commandArgs = id.CommandArgument.ToString().Split(new char[] { ',' });//0=codMateria

            int codMateria = int.Parse(commandArgs[0]);
            string status = commandArgs[1];
            string revisao = commandArgs[2];

            int codPessoa = int.Parse(Session["CodPessoaLogada"].ToString());
            string funcaoPessoaLogada = pessoaBll.getFuncaoPessoa(codPessoa);

            if (status.Equals("Revisao"))
            {
                if (funcaoPessoaLogada.Equals("Jornalista") && revisao.Equals("R"))
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "msg('A matéria está sendo revisada pelo Revisor, aguarde ela ser liberada.');", true);
                else
                    if (funcaoPessoaLogada.Equals("Revisor") && revisao.Equals("J"))
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "msg('A matéria está sendo revisada pelo Jornalista, aguarde ela ser liberada.');", true);
                    else
                        if (funcaoPessoaLogada.Equals("Revisor") && revisao.Equals("R"))
                            Response.Redirect("RevisaoMateria.aspx?key=" + Util.criptUrl(codMateria.ToString()));
                        else
                            if (funcaoPessoaLogada.Equals("Jornalista") && revisao.Equals("J"))
                                Response.Redirect("RevisaoMateria.aspx?key=" + Util.criptUrl(codMateria.ToString()));
                            else
                                if (!funcaoPessoaLogada.Equals("Jornalista") || !funcaoPessoaLogada.Equals("Revisor"))
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "msg('Somente jornalistas e Revisores podem revisar matérias.');", true);
            }
            else
            if (status.Equals("Proposta"))
            {
                if (funcaoPessoaLogada.Equals("Revisor"))
                    Response.Redirect("RevisaoMateria.aspx?key=" + Util.criptUrl(codMateria.ToString()));
                else
                    if (funcaoPessoaLogada.Equals("Jornalista"))
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "msg('Antes da sua revisão a matéria precisa ser revisada por um Revisor.');", true);
                    else
                        if (!funcaoPessoaLogada.Equals("Jornalista") || !funcaoPessoaLogada.Equals("Revisor"))
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "msg('Somente jornalistas e Revisores podem revisar matérias.');", true);
            }
        }

    }
}