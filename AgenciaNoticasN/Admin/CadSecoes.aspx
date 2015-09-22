<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="True" CodeBehind="CadSecoes.aspx.cs" Inherits="AgenciaNoticasN.Admin.CadSecoes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        
        <div class="col-md-12">
            <asp:HyperLink NavigateUrl="~/Admin/Secoes.aspx" runat="server" ID="hpVoltar" ><span class="glyphicon glyphicon-chevron-left"></span> &nbsp; voltar </asp:HyperLink>
            <div class="page-header">
                <h2>Cadastro de seções</h2>    
            </div>
        </div>
        
        <div class="col-md-12 form-group">
            <label class="control-label">Nome:</label>    
            
            <asp:TextBox ID="txtNome" runat="server" CssClass="form-control" MaxLength="50"></asp:TextBox>
        </div>

         <div class="col-md-12 form-group">
            <label class="control-label">Gerente:</label>    
            
            <asp:DropDownList ID="ddlGerente" runat="server" CssClass="form-control" AutoPostBack="True" AppendDataBoundItems="True">
                    <asp:ListItem Selected="True" Value="">Selecione</asp:ListItem>
            </asp:DropDownList>
        </div>    
  
    </div>
    <div class="row">
        <div class="col-md-10 form-group">
            <h4><asp:Label ID="lblMensagemErro" runat="server" Text="" CssClass="label label-danger"></asp:Label></h4>
        </div>

        <div class="col-md-2 form-group pull-right">
            <asp:LinkButton ID="lkGravar" runat="server" Text="Gravar" CssClass="btn btn-primary pull-right" OnClick="lkGravar_Click"></asp:LinkButton>
        </div>
    </div>
</asp:Content>
