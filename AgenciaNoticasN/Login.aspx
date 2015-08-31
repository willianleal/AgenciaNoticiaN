<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="AgenciaNoticasN.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-sm-4 col-md-4 col-lg-4" style="margin-top: 2%;">
    <div class="login">
    <asp:Login ID="Login1" runat="server" DisplayRememberMe="False" LoginButtonText="Entrar" PasswordLabelText="Senha:"
        PasswordRequiredErrorMessage="Senha é requerida" TitleText="Login" UserNameLabelText="Usuário:" UserNameRequiredErrorMessage="Usuário é requerido" DestinationPageUrl="~/Materias/MinhasMaterias.aspx" FailureText="" OnAuthenticate="Login1_Authenticate">
        <LayoutTemplate>
            <h3 class="titulo-login">Login</h3>
            <div class="form-group">
                <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Usuário:</asp:Label> 
                <asp:TextBox ID="UserName" runat="server" class="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" ErrorMessage="Usuário é requerido" ToolTip="Usuário é requerido" ValidationGroup="Login1">*</asp:RequiredFieldValidator>   
            </div>
            <div class="form-group">
                <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Senha:</asp:Label>                    
                <asp:TextBox ID="Password" runat="server" TextMode="Password" class="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" ErrorMessage="Senha é requerida" ToolTip="Senha é requerida" ValidationGroup="Login1">*</asp:RequiredFieldValidator> 
            </div>
            <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
            <asp:Button ID="LoginButton" class="btn btn-medium btn-primary pull-right" runat="server" CommandName="Login" Text="Entrar" ValidationGroup="Login1" />                    
        </LayoutTemplate>
    </asp:Login>
    </div>
    </div>
</asp:Content>
