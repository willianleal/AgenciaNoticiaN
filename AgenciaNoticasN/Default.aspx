<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AgenciaNoticasN.Default1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        
        <div class="col-md-12 form-group">
            <h2>Últimas matérias publicadas</h2>
            <%--<div class="page-header">
                <h2>Últimas notícias publicadas</h2>
            </div>--%>
        </div>

        <div class="col-md-3 form-group">
            <label class="control-label">Filtrar:</label>    
            <asp:DropDownList ID="ddlFiltrar" runat="server" CssClass="form-control">
                <asp:ListItem Selected="True" Value="">Selecione</asp:ListItem>
                <asp:ListItem Value="1">Última semana</asp:ListItem>
                <asp:ListItem Value="2">Último mês</asp:ListItem>
                <asp:ListItem Value="3">Último ano</asp:ListItem>
                <asp:ListItem Value="4">As 15 mais recentes</asp:ListItem>
                <asp:ListItem Value="5">As 60 mais recentes</asp:ListItem>
            </asp:DropDownList>
        </div>
            
        <div class="col-md-2 form-group">
            <label class="control-label"></label>
            <asp:Button ID="btnFiltrar" runat="server" Text="Filtrar" CssClass="btn btn-primary form-control" OnClick="btnFiltrar_Click" ></asp:Button>
        </div>
        
        <asp:DataList ID="dtlMateria" CssClass="table table-hover" runat="server">
                <ItemTemplate>
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h3 class="panel-title">
                                <label class="control-label"><%# Eval("nome") %></label>
                            </h3>
                        </div>
                        <div class="panel-body">
                            <asp:Label ID="lblComentario" runat="server" CssClass="control-label" Text='<%# Eval("materiaEscrita") %>'></asp:Label>
                        </div>
                    </div>    
                </ItemTemplate>
            </asp:DataList>
    </div>
</asp:Content>
