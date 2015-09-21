<%@ Page Title="" Language="C#" MasterPageFile="~/Materias/MasterPage.master" AutoEventWireup="true" CodeBehind="RevisaoMateria.aspx.cs" Inherits="AgenciaNoticasN.Materias.RevisaoMateria" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"> 
    <script type="text/javascript">
        function msg(m) { alert(m); }     
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    
    <div class="row">
        <div class="col-md-12 form-group">
            <asp:HyperLink NavigateUrl="~/Materias/Materias.aspx" runat="server" ID="hpVoltar" ><span class="glyphicon glyphicon-chevron-left"></span> &nbsp; voltar </asp:HyperLink>
            <div class="page-header">
                <h2>Revisão de matérias</h2>
            </div>
        </div>

        <div class="col-md-4 form-group">
            <label class="control-label">Status:</label>
            <asp:Label ID="lblStatus" runat="server" Text="lblStatus" CssClass="control-label"></asp:Label>  
        </div>

        <div class="col-md-4 form-group">
            <label class="control-label">Jornalista:</label>
            <asp:Label ID="lblJornalista" runat="server" Text="lblJornalista" CssClass="control-label"></asp:Label>   
        </div>

        <div class="col-md-4 form-group">
            <label class="control-label">Revisor:</label>
            <asp:Label ID="lblRevisor" runat="server" Text="" CssClass="control-label"></asp:Label>
        </div>

        <asp:Panel ID="pnDados" runat="server" Enabled="false">
            <div class="col-md-12 form-group">
                <label class="control-label">Seção:</label> 
            
                <asp:DropDownList ID="ddlSecao" runat="server" CssClass="form-control" AutoPostBack="True" AppendDataBoundItems="True" Enabled="false">
                    <asp:ListItem Selected="True" Value="">Selecione</asp:ListItem>
                </asp:DropDownList>
            </div>  

            <div class="col-md-12 form-group">
                <label class="control-label">Título:</label>    
            
                <asp:TextBox ID="txtNome" runat="server" CssClass="form-control" MaxLength="50" placeholder="Título da matéria"></asp:TextBox>
            </div>

            <div class="col-md-12 form-group">
                <label class="control-label">Matéria:</label>
                <asp:TextBox ID="txtMateriaEscrita" runat="server" CssClass="form-control" TextMode="MultiLine" Columns="120" Rows="6" placeholder="Texto da matéria"></asp:TextBox>
            
                <ajaxToolkit:HtmlEditorExtender ID="txtMateriaEscrita_HtmlEditorExtender" Enabled="false" runat="server" BehaviorID="txtMateriaEscrita_HtmlEditorExtender" TargetControlID="txtMateriaEscrita" >
                </ajaxToolkit:HtmlEditorExtender>
            </div>
        </asp:Panel>

        <div class="col-md-12 form-group">
            <label class="control-label">Envio:</label>    
        
            <asp:TextBox ID="txtDescricao" runat="server" CssClass="form-control" MaxLength="100" placeholder="Informe uma descrição para o envio. Ex: Envio inicial, Revisão final..."></asp:TextBox>
        </div>

        <div class="col-md-12 form-group">
            <label class="control-label">Comentário:</label>
        
            <asp:TextBox ID="txtComentario" runat="server" CssClass="form-control" TextMode="MultiLine" Columns="120" Rows="3" placeholder="Escreva um comentário sobre a revisão feita."></asp:TextBox>
        </div>
            
        <div class="col-md-12 form-group">
            <hr>
            <h4><asp:Label ID="lblParecer" runat="server" Text="Parecer Revisor:" CssClass="label label-success pull-left"></asp:Label></h4>
            <h4><asp:Label ID="lblAlteracao" runat="server" Text="Houve alteração:" CssClass="label label-success pull-left"></asp:Label></h4>      
        </div>

        <div class="col-md-12 form-group">
            <label class="control-label">Alterar?</label>
            <asp:RadioButtonList ID="rdlAlteracao" runat="server" RepeatLayout="flow" RepeatDirection="Horizontal" CssClass="btn-group" AutoPostBack="true" OnSelectedIndexChanged="rdlAlteracao_SelectedIndexChanged" >
                <asp:ListItem class="btn btn-default" Text="Sim" Value="S"/>
                <asp:ListItem class="btn btn-default" Text="Não" Value="N"/>
            </asp:RadioButtonList>
            
            <label class="control-label">Parecer após revisão:</label>
            <asp:RadioButtonList ID="rdlSituacao" runat="server" RepeatLayout="flow" RepeatDirection="Horizontal" CssClass="btn-group" AutoPostBack="true" OnSelectedIndexChanged="rdlSituacao_SelectedIndexChanged">
                <asp:ListItem class="btn btn-default" Text="Aprovar" Value="A"/>
                <asp:ListItem class="btn btn-default" Text="Rejeitar" Value="R"/>
            </asp:RadioButtonList>
        </div>

        <div class="col-md-12 form-group">
            <hr>
            <h4><asp:Label ID="lblMensagemErro" runat="server" Text="" CssClass="label label-danger pull-left"></asp:Label></h4>
            <asp:LinkButton ID="lkGravar" runat="server" Text="Enviar para Revisão" CssClass="btn btn-primary pull-right" OnClick="lkGravar_Click"></asp:LinkButton>
        </div>

        <div class="col-md-12 form-group">
            <hr>
            <label class="control-label">Comentários.....</label>    
            
            <asp:DataList ID="dtlComentarios" CssClass="table table-hover" runat="server">
                <ItemTemplate>
                    <div class="panel panel-info">
                        <div class="panel-heading">
                            <h3 class="panel-title">
                                <asp:Label ID="lblPessoa" runat="server" CssClass="control-label" Text='<%# Eval("Pessoa") + " - " + Eval("Funcao") + " - " + Eval("dataCadastro") %>'></asp:Label>
                            </h3>
                        </div>
                        <div class="panel-body">
                            <label class="control-label"><%# Eval("titulo") %></label>
                            <br />
                            <asp:Label ID="lblComentario" runat="server" CssClass="control-label" Text='<%# Eval("comentario") %>'></asp:Label>
                        </div>
                    </div>    
                </ItemTemplate>
            </asp:DataList>
        </div>  
    </div>
</asp:Content>
