<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeBehind="Materias.aspx.cs" Inherits="AgenciaNoticasN.Materias.MinhasMaterias" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="row">
        
        <div class="col-md-12 form-group">
            <h2>Matérias cadastradas</h2>
            <asp:GridView ID="gdvMateria" runat="server" AutoGenerateColumns="False" CssClass="table table-hover" BorderWidth="0px" GridLines="None">
            <Columns>
                <asp:BoundField DataField="codMateria" HeaderText="Código" />
                <asp:BoundField DataField="nome" HeaderText="Nome" />
                <asp:BoundField DataField="jornalista" HeaderText="Jornalista" />
                <asp:BoundField DataField="revisor" HeaderText="Revisor" />
                <asp:BoundField DataField="publicador" HeaderText="Publicador" />
                <asp:BoundField DataField="gerente" HeaderText="Gerente" />
                <asp:BoundField DataField="status" HeaderText="Status" />
                <asp:BoundField DataField="dataCadastro" HeaderText="Cadastro" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="lbAlterar" runat="server" CommandArgument='<%# Eval("codMateria") %>' Text="Alterar" OnClick="lbAlterar_Click" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="lbDeletar" runat="server" CommandArgument='<%# Eval("codMateria") %>' Text="Deletar" OnClick="lbDeletar_Click" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            </asp:GridView>
        </div>

    </div>
    <div class="row">
        <div class="col-md-2 form-group pull-right">
            <asp:LinkButton ID="lkNovo" runat="server" Text="Cadastrar" CssClass="btn btn-primary"></asp:LinkButton>
            <asp:LinkButton ID="lkSair" runat="server" Text="Sair" CssClass="btn btn-success"></asp:LinkButton>
        </div>
    </div>

</asp:Content>
