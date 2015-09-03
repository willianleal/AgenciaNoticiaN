<%@ Page Title="" Language="C#" MasterPageFile="~/Materias/MasterPage.master" AutoEventWireup="true" CodeBehind="CadPessoas.aspx.cs" Inherits="AgenciaNoticasN.Materias.CadPessoas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        
        <div class="col-md-12 form-group">
            <h2>Cadastro de pessoas</h2>
            
        </div>

    </div>
    <div class="row">
        <div class="col-md-2 form-group pull-right">
            <asp:LinkButton ID="lkGravar" runat="server" Text="Gravar" CssClass="btn btn-primary"></asp:LinkButton>
            <asp:LinkButton ID="lkSair" runat="server" Text="Sair" CssClass="btn btn-success"></asp:LinkButton>
        </div>
    </div>
</asp:Content>
