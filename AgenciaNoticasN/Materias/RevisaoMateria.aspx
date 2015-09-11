<%@ Page Title="" Language="C#" MasterPageFile="~/Materias/MasterPage.master" AutoEventWireup="true" CodeBehind="RevisaoMateria.aspx.cs" Inherits="AgenciaNoticasN.Materias.RevisaoMateria" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    
    <div class="row">
        <div class="col-md-12 form-group">
            <h2>Revisão de matérias</h2> 
        </div>

        <div class="col-md-12 form-group">
            <label class="control-label">Status:</label>
            <asp:Label ID="lblStatus" runat="server" Text="lblStatus" CssClass="control-label"></asp:Label>
            
            <asp:LinkButton ID="lkPegar" runat="server" Text="Pegar matéria" CssClass="btn btn-success pull-right" Visible="false" OnClick="lkPegar_Click"></asp:LinkButton>  
        </div>

        <div class="col-md-12 form-group">
            <label class="control-label">Jornalista:</label>
            <asp:Label ID="lblJornalista" runat="server" Text="lblJornalista" CssClass="control-label"></asp:Label>  
        </div>

        <div class="col-md-12 form-group">
            <label class="control-label">Revisor:</label>
            <asp:Label ID="lblRevisor" runat="server" Text="" CssClass="control-label"></asp:Label>  
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
            <label class="control-label">Nome:</label>    
            
            <asp:TextBox ID="txtNome" runat="server" CssClass="form-control" MaxLength="50"></asp:TextBox>
        </div>

        <div class="col-md-12 form-group">
            <%--<label class="control-label">Matéria:</label>--%>
            
            <asp:TextBox ID="txtMateriaEscrita" runat="server" CssClass="form-control" TextMode="MultiLine" Columns="120" Rows="10"></asp:TextBox>
            
            <ajaxToolkit:HtmlEditorExtender ID="TextBox1_HtmlEditorExtender" runat="server" BehaviorID="txtMateriaEscrita_HtmlEditorExtender" TargetControlID="txtMateriaEscrita">
            </ajaxToolkit:HtmlEditorExtender>
        </div>
        <div class="col-md-2 form-group pull-right">
            <asp:LinkButton ID="lkGravar" runat="server" Text="Enviar Revisão" CssClass="btn btn-primary pull-right" OnClick="lkGravar_Click"></asp:LinkButton>
        </div>
        </asp:Panel>  
    </div>
    <%--<div class="row">
        <div class="col-md-2 form-group pull-right">
            <asp:LinkButton ID="lkGravar" runat="server" Text="Enviar Revisão" CssClass="btn btn-primary pull-right" OnClick="lkGravar_Click"></asp:LinkButton>
        </div>
    </div>--%>
</asp:Content>
