<%@ Page Title="" Language="C#" MasterPageFile="~/Materias/MasterPage.master" AutoEventWireup="true" CodeBehind="RevisaoMateria.aspx.cs" Inherits="AgenciaNoticasN.Materias.RevisaoMateria" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    
    <div class="row">
        <div class="col-md-12 form-group">
            <asp:HyperLink NavigateUrl="~/Materias/Materias.aspx" runat="server" ID="hpVoltar" ><span class="glyphicon glyphicon-chevron-left"></span> &nbsp; voltar </asp:HyperLink>
            <h2>Revisão de matérias</h2> 
        </div>

        <div class="col-md-4 form-group">
            <label class="control-label">Status:</label>
            <asp:Label ID="lblStatus" runat="server" Text="lblStatus" CssClass="control-label"></asp:Label>  
        </div>

        <div class="col-md-4 form-group">
            <label class="control-label">Jornalista:</label>
            <asp:Label ID="lblJornalista" runat="server" Text="lblJornalista" CssClass="control-label"></asp:Label>   
        </div>

        <div class="col-md-4 form-group">
            <label class="control-label">Revisor:</label>
            <asp:Label ID="lblRevisor" runat="server" Text="" CssClass="control-label"></asp:Label>
            
            <asp:LinkButton ID="lkPegar" runat="server" Text="Pegar matéria" CssClass="btn btn-success pull-right" Visible="false" OnClick="lkPegar_Click"></asp:LinkButton>  
        </div>

        <asp:Panel ID="pnDados" runat="server" Enabled="false">
        <div class="col-md-12 form-group">
            <label class="control-label">Seção:</label>
            <%--<asp:Label ID="lblSecao" runat="server" Text="lblSecao" CssClass="control-label"></asp:Label> --%>    
            
            <asp:DropDownList ID="ddlSecao" runat="server" CssClass="form-control" AutoPostBack="True" AppendDataBoundItems="True" Enabled="false">
                <asp:ListItem Selected="True" Value="">Selecione</asp:ListItem>
            </asp:DropDownList>
        </div>  

        <div class="col-md-12 form-group">
            <label class="control-label">Título:</label>    
            
            <asp:TextBox ID="txtNome" runat="server" CssClass="form-control" MaxLength="50" placeholder="Título da matéria"></asp:TextBox>
        </div>

        <div class="col-md-12 form-group">
            <%--<label class="control-label">Matéria:</label>--%>
            
            <asp:TextBox ID="txtMateriaEscrita" runat="server" CssClass="form-control" TextMode="MultiLine" Columns="120" Rows="6" placeholder="Texto da matéria"></asp:TextBox>
            
            <ajaxToolkit:HtmlEditorExtender ID="txtMateriaEscrita_HtmlEditorExtender" runat="server" BehaviorID="txtMateriaEscrita_HtmlEditorExtender" TargetControlID="txtMateriaEscrita" >
            </ajaxToolkit:HtmlEditorExtender>
        </div>
        <%--</asp:Panel>--%>

        <%--    Comentário   --%>
        <%--<asp:Panel ID="pnComentario" runat="server" Enabled="false">--%>

        <div class="col-md-12 form-group">
            <label class="control-label">Envio:</label>    
            
            <asp:TextBox ID="txtDescricao" runat="server" CssClass="form-control" MaxLength="50" placeholder="Escreva uma descrição para o envio. Ex: Envio inicial, Revisão final..."></asp:TextBox>
        </div>

        <div class="col-md-12 form-group">
            <label class="control-label">Comentário:</label>
            
            <asp:TextBox ID="txtComentario" runat="server" CssClass="form-control" TextMode="MultiLine" Columns="120" Rows="3" placeholder="Escreva um comentário sobre a revisão feita."></asp:TextBox>
        </div>
            
        <div class="col-md-12 form-group">
            <label class="control-label">Parecer após revisão:</label>
            <asp:RadioButtonList ID="rdlSituacao" runat="server" RepeatLayout="flow" RepeatDirection="Horizontal" CssClass="btn-group" ><%--data-toggle="buttons"--%>
                <asp:ListItem class="btn btn-default" Text="Aprovar" Value="A"/><%--Aprovar</asp:ListItem>--%>
                <asp:ListItem class="btn btn-default" Text="Rejeitar" Value="R"/><%--Aprovar</asp:ListItem>--%>
            </asp:RadioButtonList>

            <label class="control-label">Houve alteração:</label>
            <asp:RadioButtonList ID="rdlAlteracao" runat="server" RepeatLayout="flow" RepeatDirection="Horizontal" CssClass="btn-group" ><%--data-toggle="buttons"--%>
                <asp:ListItem class="btn btn-default" Text="Sim" Value="S"/><%--Aprovar</asp:ListItem>--%>
                <asp:ListItem class="btn btn-default" Text="Não" Value="N"/><%--Aprovar</asp:ListItem>--%>
            </asp:RadioButtonList>

            <asp:LinkButton ID="lkGravar" runat="server" Text="Enviar Revisão" CssClass="btn btn-primary pull-right" OnClick="lkGravar_Click"></asp:LinkButton>
        </div>

        <div class="col-md-12 form-group">
            <h4><asp:Label ID="lblMensagemErro" runat="server" Text="" CssClass="label label-danger"></asp:Label></h4>
        </div>

        <div class="col-md-12 form-group">
            <label class="control-label">Comentários...</label>    
            
            <asp:DataList ID="dtlComentarios" CssClass="table table-hover" runat="server">
                <ItemTemplate>
                    <div class="panel panel-info">
                        <div class="panel-heading">
                            <h3 class="panel-title">
                                <asp:Label ID="lblPessoa" runat="server" CssClass="control-label" Text='<%# Eval("Pessoa") + " - " + Eval("Funcao") + " - " + Eval("dataCadastro") %>'></asp:Label>
                            </h3>
                        </div>
                        <div class="panel-body">
                            <label class="control-label"><%# Eval("titulo") %></label>
                            <%--<asp:Label ID="lblTitulo" runat="server" CssClass="control-label" Text='<%# Eval("titulo") %>'></asp:Label>--%>
                            <br />
                            <asp:Label ID="lblComentario" runat="server" CssClass="control-label" Text='<%# Eval("comentario") %>'></asp:Label>
                        </div>
                    </div>    
                </ItemTemplate>
            </asp:DataList>
        </div>
            
        </asp:Panel>  
    </div>
    <%--<div class="row">
        <div class="col-md-2 form-group pull-right">
            <asp:LinkButton ID="lkGravar" runat="server" Text="Enviar Revisão" CssClass="btn btn-primary pull-right" OnClick="lkGravar_Click"></asp:LinkButton>
        </div>
    </div>--%>
</asp:Content>
