<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="AgenciaNoticasN.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function openModal() {
            $('#MainContent_DivDeleteConfirmation').modal('show');
        }
    </script>
    <script type="text/javascript">
        function msg(m) {alert(m);}
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-12">
        <div class="row">
            <div class="col-md-4"></div>
            <div class="col-md-4 ">
                <div class="log">
                    <asp:Login ID="Login1" runat="server" DisplayRememberMe="False" LoginButtonText="Entrar" PasswordLabelText="Senha:" Width="85%" CssClass="form-signin"
                        PasswordRequiredErrorMessage="Senha é requerida" TitleText="Login" UserNameLabelText="Usuário:" UserNameRequiredErrorMessage="Usuário é requerido" DestinationPageUrl="~/Materias/MinhasMaterias.aspx" FailureText="" OnAuthenticate="Login1_Authenticate">
                        <LayoutTemplate>                    
                            <h3 class="titulo-login max">Login</h3>

                            <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Usuário:</asp:Label> 
                
                            <asp:TextBox ID="UserName" runat="server" class="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" ErrorMessage="Usuário é requerido" ToolTip="Usuário é requerido" ValidationGroup="Login1">*</asp:RequiredFieldValidator>   
            
                            <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Senha:</asp:Label>                    
                
                            <asp:TextBox ID="Password" runat="server" TextMode="Password" class="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" ErrorMessage="Senha é requerida" ToolTip="Senha é requerida" ValidationGroup="Login1">*</asp:RequiredFieldValidator> 
            
                            <center>
                                <div class="mensagemerro">
                                    <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                </div>
                            </center>

                            <asp:Button ID="LoginButton" class="btn btn-primary pull-right" runat="server" CommandName="Login" 
                                Text="Entrar" ValidationGroup="Login1" />
                        </LayoutTemplate>                        
                    </asp:Login>
                </div>
            </div>
            <div class="col-md-4"></div>
        </div>
    </div>
</asp:Content>
