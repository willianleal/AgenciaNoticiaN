<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="True" CodeBehind="Secoes.aspx.cs" Inherits="AgenciaNoticasN.Admin.Secoes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        
        <div class="col-md-12 form-group">
            <h2>Seções cadastradas</h2>
            <asp:GridView ID="gdvSecoes" runat="server" AutoGenerateColumns="False" CssClass="table table-hover" BorderWidth="0px" GridLines="None">
            <Columns>
                <asp:BoundField DataField="codSecao" HeaderText="Código" />
                <asp:BoundField DataField="nome" HeaderText="Nome" />
                <asp:BoundField DataField="gerente" HeaderText="Gerente" />
                <asp:BoundField DataField="dataCadastro" HeaderText="Cadastro" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="lbAlterar" runat="server" CommandArgument='<%# Eval("codSecao") %>' Text="Alterar" OnClick="lbAlterar_Click"  />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="lbDeletar" runat="server" CommandArgument='<%# Eval("codSecao") %>' Text="Deletar" OnClick="lbDeletar_Click"  />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
                <EmptyDataTemplate>
                    Nenhuma seção cadastrada.
                </EmptyDataTemplate>
            </asp:GridView>
        </div>

    </div>
    <div class="row">
        <div class="col-md-12 form-group">
            <asp:LinkButton ID="lkNovo" runat="server" Text="Cadastrar" CssClass="btn btn-primary pull-right" OnClick="lkNovo_Click"></asp:LinkButton>
        </div>
    </div>

</asp:Content>
