<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="desafio.Web.home" Async="true" %>

<!DOCTYPE html>

<html>
<head>
    <title>Lista de Pessoas</title>
    <link rel="stylesheet" href="style.css">
</head>
<body>
    <div class="container">

        <form runat="server">
            <div style="width: 100%; display: flex; justify-content: flex-end; margin-bottom: 10px;">
                <asp:Button ID="btnSair" runat="server" Text="Sair" OnClick="btnSair_Click" CssClass="form-button" />
            </div>
 <h2>Cadastro</h2>
   <asp:Panel ID="pnlCadastroPessoa" runat="server" CssClass="form-panel">

    <div class="form-row">


        <div class="form-group" style="display: none;">
            <asp:Label ID="lblId" runat="server" Text="Id:" CssClass="form-label" style="display: none;"  />
            <asp:TextBox ID="txtId" runat="server" CssClass="form-input" style="display: none;" ></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="lblNome" runat="server" Text="Nome:" CssClass="form-label" />
            <asp:TextBox ID="txtNome" runat="server" CssClass="form-input"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="lblCidade" runat="server" Text="Cidade:" CssClass="form-label" />
            <asp:TextBox ID="txtCidade" runat="server" CssClass="form-input"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="lblEmail" runat="server" Text="Email:" CssClass="form-label" />
            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-input"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="lblCEP" runat="server" Text="CEP:" CssClass="form-label" />
            <asp:TextBox ID="txtCEP" runat="server" CssClass="form-input"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="lblEndereco" runat="server" Text="Endereço:" CssClass="form-label" />
            <asp:TextBox ID="txtEndereco" runat="server" CssClass="form-input"></asp:TextBox>
        </div>
    </div>

    <div class="form-row">
        <div class="form-group">
            <asp:Label ID="lblPais" runat="server" Text="País:" CssClass="form-label" />
            <asp:TextBox ID="txtPais" runat="server" CssClass="form-input"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="lblUsuario" runat="server" Text="Usuário:" CssClass="form-label" />
            <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-input"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="lblTelefone" runat="server" Text="Telefone:" CssClass="form-label" />
            <asp:TextBox ID="txtTelefone" runat="server" CssClass="form-input"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="lblDataNascimento" runat="server" Text="Data de Nascimento:" CssClass="form-label" />
            <asp:TextBox ID="txtDataNascimento" runat="server" placeholder="dd/MM/yyyy" CssClass="form-input"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="lblCargoId" runat="server" Text="Cargo:" CssClass="form-label" />
            <asp:DropDownList ID="ddlCargoId" runat="server" CssClass="form-input">
                <asp:ListItem Value=""></asp:ListItem>
                <asp:ListItem Value="1">Estagiário</asp:ListItem>
                <asp:ListItem Value="2">Técnico</asp:ListItem>
                <asp:ListItem Value="3">Analista</asp:ListItem>
                <asp:ListItem Value="4">Coordenador</asp:ListItem>
                <asp:ListItem Value="5">Gerente</asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>

   <div style="display: flex; gap: 10px;">
    <asp:Button ID="btnCadastrar" runat="server" Text="Cadastrar" CssClass="form-button" OnClick="btnCadastrar_Click" />
    <asp:Button ID="btnLimpar" runat="server" Text="Limpar" CssClass="form-button" OnClick="btnLimpar_Click" />
</div>


</asp:Panel>


            <h2>Lista de Pessoas</h2>

            <div style="display: flex; gap: 10px; margin-top: 10px;">
                <asp:Button ID="btnCalculaSalario" runat="server" Text="Calcular Salário" OnClick="btnCalculaSalario_ServerClick" />
            </div>
            <asp:GridView ID="gvPessoas" CssClass="gridview" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" OnRowCommand="gvPessoas_RowCommand">
                 <PagerStyle HorizontalAlign="Center" />

                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID" Visible="false" />
                    <asp:BoundField DataField="Nome" HeaderText="Nome" />
                    <asp:BoundField DataField="Email" HeaderText="Email" />
                    <asp:BoundField DataField="Cargo_Nome" HeaderText="Cargo" />
                    <asp:BoundField DataField="Salario_Bruto" HeaderText="Salário Bruto" DataFormatString="{0:C}" />
                    <asp:BoundField DataField="Descontos" HeaderText="Descontos" DataFormatString="{0:C}" />
                    <asp:BoundField DataField="Salario_Liquido" HeaderText="Salário Líquido" DataFormatString="{0:C}" />
                    <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="btnEditar" runat="server" CommandName="Editar" CommandArgument='<%# Container.DataItemIndex %>'>
                             Editar
                        </asp:LinkButton>
                    </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="btnExcluir" runat="server" CommandName="Excluir" CommandArgument='<%# Container.DataItemIndex %>'>
                             Excluir
                        </asp:LinkButton>
                    </ItemTemplate>

                </asp:TemplateField>


                </Columns>
            </asp:GridView>

        </form>
    </div>
</body>
</html>
