<%@ Page Title="" Language="C#" MasterPageFile="~/Materias/MasterPage.master" AutoEventWireup="true" CodeBehind="CadPessoas.aspx.cs" Inherits="AgenciaNoticasN.Materias.CadPessoas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        
        <div class="col-md-12">
            <h2>Cadastro de pessoas</h2>
        </div>
        
        <div class="col-md-12 form-group">
            <label class="control-label">Nome:</label>    
            
            <asp:TextBox ID="txtNome" runat="server" CssClass="form-control" MaxLength="50"></asp:TextBox>
        </div>

         <div class="col-md-12 form-group">
            <label class="control-label">Função:</label>    
            
            <asp:DropDownList ID="ddlFuncao" runat="server" CssClass="form-control" AutoPostBack="True">
                    <asp:ListItem Selected="True" Value="">Selecione</asp:ListItem>
                    <asp:ListItem Value="Jornalista">Jornalista</asp:ListItem>
                    <asp:ListItem Value="Revisor">Revisor</asp:ListItem>
                    <asp:ListItem Value="Gerente">Gerente</asp:ListItem>
                    <asp:ListItem Value="Publicador">Publicador</asp:ListItem>
            </asp:DropDownList>
        </div>    

        <div class="col-md-12 form-group">
            <label class="control-label">DDD:</label>    
            
            <asp:TextBox ID="txtDdd" runat="server" CssClass="form-control" MaxLength="2"></asp:TextBox>
        </div>
        
        <div class="col-md-12 form-group">
            <label class="control-label">Telefone:</label>    
            
            <asp:TextBox ID="txtTelefone" runat="server" CssClass="form-control" MaxLength="9"></asp:TextBox>
        </div>
        
        <div class="col-md-12 form-group">
            <label class="control-label">Email:</label>    
            
            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" MaxLength="50"></asp:TextBox>
        </div>

        <div class="col-md-12 form-group">
            <%--<asp:CheckBox ID="chkAtivo" runat="server" Text="Ativo" CssClass="checkbox" />--%>
            <label class="control-label">Ativo:</label>

            <asp:CheckBox CssClass="checkbox checkbox-inline" ID="chkAtivo" AutoPostBack="true" runat="server" />

<%--            <p><label class="control-label"> </label> <asp:Label ID="lbInicioVisualizarLocal" runat="server" CssClass="control-label" ></asp:Label> </p>
            <asp:CheckBox CssClass="checkbox checkbox-inline pull-left margR_20" ID="chkDataAlterar" AutoPostBack="true" OnCheckedChanged="chkDataAlterar_Check" runat="server" Text="Alterar/Inserir Data de Inicio" />--%>
        </div>

        <div class="col-md-12 form-group">
            <label class="control-label">Senha:</label>    
            
            <asp:TextBox ID="txtSenha" runat="server" CssClass="form-control" MaxLength="50" TextMode="Password"></asp:TextBox>
        </div>
  
    </div>
    <div class="row">
        <div class="col-md-2 form-group pull-right">
            <asp:LinkButton ID="lkGravar" runat="server" Text="Gravar" CssClass="btn btn-primary" OnClick="lkGravar_Click"></asp:LinkButton>
        </div>
    </div>
</asp:Content>
