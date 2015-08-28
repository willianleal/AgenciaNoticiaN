<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="MinhasMaterias.aspx.cs" Inherits="AgenciaNoticasN.Materias.MinhasMaterias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="gdvMateria" runat="server" AutoGenerateColumns="False">
    <Columns>
        <asp:BoundField DataField="codPessoa" HeaderText="Código" />
        <asp:BoundField DataField="nome" HeaderText="Nome" />
        <asp:BoundField DataField="funcao" HeaderText="Função" />
        <asp:BoundField DataField="email" HeaderText="Email" />
    </Columns>
</asp:GridView>
</asp:Content>
