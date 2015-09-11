<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeBehind="Materias.aspx.cs" Inherits="AgenciaNoticasN.Admin.MinhasMaterias" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function msg(m) {alert(m);}
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
     
        <div class="col-md-12 form-group">
            <h2>Matérias cadastradas</h2>
            <asp:GridView ID="gdvMateria" runat="server" AutoGenerateColumns="False" CssClass="table table-hover" BorderWidth="0px" GridLines="None" AllowPaging="True" EmptyDataText="Nenhuma matéria cadastrada." PageSize="7">
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
                            <asp:LinkButton ID="lbAlterar" runat="server" CommandArgument='<%# Eval("codMateria") %>' Text="Alterar" OnClick="lbAlterar_Click" Visible='<%# (Eval("status").ToString().Equals("Proposta") && Eval("revisor").ToString().Equals("")) ? true: false %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="lbDeletar" runat="server" CommandArgument='<%# Eval("codMateria") %>' Text="Deletar" OnClick="lbDeletar_Click" Visible='<%# (Eval("status").ToString().Equals("Proposta") && Eval("revisor").ToString().Equals("")) ? true: false %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="lbRevisar" runat="server" CommandArgument='<%# Eval("codMateria")+","+Eval("status")+","+Eval("revisao") %>' Text="Revisar" OnClick="lbRevisar_Click" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="revisao" HeaderText="Revisao" Visible="False" />
                </Columns>
            </asp:GridView>
        </div>

    </div>
    <div class="row">
        <div class="col-md-12 form-group">
            <asp:LinkButton ID="lkNovo" runat="server" Text="Cadastrar" CssClass="btn btn-primary pull-right" OnClick="lkNovo_Click"></asp:LinkButton>
        </div>
    </div>
</asp:Content>
