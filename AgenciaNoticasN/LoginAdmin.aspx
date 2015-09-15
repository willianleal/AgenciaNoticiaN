<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="True" CodeBehind="LoginAdmin.aspx.cs" Inherits="AgenciaNoticasN.LoginAdmin" %>
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
        <asp:HyperLink NavigateUrl="~/Default.aspx" runat="server" ID="hpVoltar" ><span class="glyphicon glyphicon-chevron-left"></span> &nbsp; voltar </asp:HyperLink>
        <div class="row">
            <div class="col-md-4"></div>
            <div class="col-md-4">
                <div class="log">
                    <asp:Login ID="Login1" runat="server" FailureText="Usuário e/ou Senha incorreto" Width="85%"
                        CssClass="form-signin" DisplayRememberMe="False" OnAuthenticate="Login1_Authenticate" DestinationPageUrl="~/Admin/HomeAdmin.aspx">
                        <%--LoginButtonText="Entrar" PasswordLabelText="Senha:" PasswordRequiredErrorMessage="Senha é requerida" TitleText="Login" 
                        UserNameLabelText="Usuário:" UserNameRequiredErrorMessage="Usuário é requerido">--%>
                         
                        <LayoutTemplate>                    
                            <h3 class="titulo-login max">Login</h3>

                            <%--<asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Usuário:</asp:Label>--%> 
                
                            <asp:TextBox ID="UserName" runat="server" class="form-control" required autofocus placeholder="Email"></asp:TextBox>
                            
                            <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                ErrorMessage="Usuário é requerido" ToolTip="Usuário é requerido" ValidationGroup="Login1"
                                ForeColor="Red" CssClass="rfvusername">*</asp:RequiredFieldValidator>   
            
                            <%--<asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Senha:</asp:Label>--%>                    
                
                            <asp:TextBox ID="Password" runat="server" TextMode="Password" class="form-control" placeholder="Senha" required></asp:TextBox>
                            
                            <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                ErrorMessage="Senha é requerida" ToolTip="Senha é requerida" ValidationGroup="Login1"
                                Font-Size="0.8em" ForeColor="Red" CssClass="rfvpassword">*</asp:RequiredFieldValidator>
            
                            <center>
                                <div class="mensagemerro">
                                    <asp:CheckBox ID="RememberMe" runat="server" Text="Lembrar Senha." Visible="false" />
                                    <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                </div>
                            </center>

                            <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Entrar" ValidationGroup="Login1"
                                class="btn btn-primary pull-right" />
                        </LayoutTemplate>                        
                    </asp:Login>
                </div>
            </div>
            <div class="col-md-4">

            </div>
        </div>
    </div>
</asp:Content>