<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="AgenciaNoticasN.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Login ID="Login1" runat="server" DisplayRememberMe="False" LoginButtonText="Entrar" PasswordLabelText="Senha:"
        PasswordRequiredErrorMessage="Senha é requerida" TitleText="Login" UserNameLabelText="Usuário:" UserNameRequiredErrorMessage="Usuário é requerido" DestinationPageUrl="~/Materias/MinhasMaterias.aspx" FailureText="" OnAuthenticate="Login1_Authenticate">
    </asp:Login>
</asp:Content>
