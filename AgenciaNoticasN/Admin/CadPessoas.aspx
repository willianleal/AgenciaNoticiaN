<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="True" CodeBehind="CadPessoas.aspx.cs" Inherits="AgenciaNoticasN.Admin.CadPessoas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <div class="row">
        <div class="col-md-12">
            <asp:HyperLink NavigateUrl="~/Admin/Pessoas.aspx" runat="server" ID="hpVoltar" ><span class="glyphicon glyphicon-chevron-left"></span> &nbsp; voltar </asp:HyperLink>
            <h2>Cadastro de pessoas</h2>
        </div>
        
        <div class="col-md-12 form-group">
            <label class="control-label">Nome:</label>    
            
            <asp:TextBox ID="txtNome" runat="server" CssClass="form-control" MaxLength="50" ></asp:TextBox>
        </div>

         <div class="col-md-12 form-group">
            <label class="control-label">Função:</label>    
            
            <asp:DropDownList ID="ddlFuncao" runat="server" CssClass="form-control">
                    <asp:ListItem Selected="True" Value="">Selecione</asp:ListItem>
                    <asp:ListItem Value="Jornalista">Jornalista</asp:ListItem>
                    <asp:ListItem Value="Revisor">Revisor</asp:ListItem>
                    <asp:ListItem Value="Gerente">Gerente</asp:ListItem>
                    <asp:ListItem Value="Publicador">Publicador</asp:ListItem>
            </asp:DropDownList>
        </div>    

        <div class="col-md-12 form-group">
            <label class="control-label">DDD:</label>    
            
            <asp:TextBox ID="txtDdd" runat="server" CssClass="form-control" MaxLength="2" ></asp:TextBox>
        </div>
        
        <div class="col-md-12 form-group">
            <label class="control-label">Telefone:</label>    
            
            <asp:TextBox ID="txtTelefone" runat="server" CssClass="form-control" MaxLength="9" ></asp:TextBox>
        </div>
        
        <div class="col-md-12 form-group">
            <%--<label class="control-label">Ativo:</label>--%>

            <asp:CheckBox Text="Ativo" CssClass="checkbox checkbox-inline pull-left" ID="chkAtivo" runat="server" />
        </div>

        <div class="col-md-12 form-group">
            <asp:CheckBox Text="Administrador" CssClass="checkbox checkbox-inline pull-left" ID="chkAdmin" runat="server" />
        </div>

        <div class="col-md-12 form-group">
            <label class="control-label">Email:</label>    
            
            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" MaxLength="50"></asp:TextBox>
        </div>

        <asp:Panel ID="pnSenha" runat="server">
            <div class="col-md-12 form-group">
                <label class="control-label">Senha:</label>    
            
                <asp:TextBox ID="txtSenha" runat="server" CssClass="form-control" MaxLength="50" TextMode="Password"></asp:TextBox>
            </div>
        </asp:Panel> 
    </div>
    <div class="row">
        <div class="col-md-10 form-group">
            <h4><asp:Label ID="lblMensagemErro" runat="server" Text="" CssClass="label label-danger"></asp:Label></h4>
        </div>

        <div class="col-md-2 form-group">
            <asp:LinkButton ID="lkGravar" runat="server" Text="Gravar" CssClass="btn btn-primary pull-right" OnClick="lkGravar_Click"></asp:LinkButton>
        </div>
    </div>
</asp:Content>
