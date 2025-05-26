using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using desafio.Dataset;
using desafio.Services;
using Microsoft.Ajax.Utilities;
using Oracle.ManagedDataAccess.Client;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace desafio.Web
{
    public partial class home : System.Web.UI.Page
    {
        PessoaService pessoaService = new PessoaService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UsuarioLogado"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                CarregarDados();
            }
        }

        private void CarregarDados()
        {           
            try
            {
                DataTable pessoas = pessoaService.ObterPessoas();

                gvPessoas.DataSource = pessoas;
                gvPessoas.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("Erro: " + ex.Message);
            }
        }

        private void CadastrarPessoa()
        {

            DateTime dataNascimento;
            bool dataValida = DateTime.TryParseExact(
                txtDataNascimento.Text,
                "dd/MM/yyyy",
                System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None,
                out dataNascimento);

            if (!dataValida)
            {
                throw new Exception("Data de nascimento inválida.");
            }

            int cargoId;
            if (!int.TryParse(ddlCargoId.SelectedValue, out cargoId))
            {
                throw new Exception("Selecione um cargo válido.");
               
            }

            try
            {
                pessoaService.CadastrarPessoa(txtNome.Text,txtCidade.Text,txtEmail.Text,txtCEP.Text,txtEndereco.Text,txtPais.Text,txtUsuario.Text,txtTelefone.Text,dataNascimento,cargoId);
            }
            catch (Exception ex)
            {
                Response.Write("Erro: " + ex.Message);
            }

            CarregarDados();
        }


        private void AtualizarPessoa()
        {

            DateTime dataNascimento;
            bool dataValida = DateTime.TryParseExact(
                txtDataNascimento.Text,
                "dd/MM/yyyy",
                System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None,
                out dataNascimento);

            if (!dataValida)
            {
                throw new Exception("Data de nascimento inválida.");
            }

            int cargoId;
            if (!int.TryParse(ddlCargoId.SelectedValue, out cargoId))
            {
                throw new Exception("Selecione um cargo válido.");
            }
            
            try
            {
                pessoaService.AtualizarPessoa(Convert.ToInt32(txtId.Text), txtNome.Text, txtCidade.Text, txtEmail.Text, txtCEP.Text, txtEndereco.Text, txtPais.Text, txtUsuario.Text, txtTelefone.Text, dataNascimento, cargoId);
            }
            catch (Exception ex)
            {
                Response.Write("Erro: " + ex.Message);
            }

            CarregarDados();
        }
        private async Task CalcularSalarioAsync()
        {
            try
            {
                await pessoaService.CalcularSalarioPessoasAsync();
                Response.Write("Cálculo de salário realizado com sucesso.");
            }
            catch (Exception ex)
            {
                Response.Write("Erro: " + ex.Message);
            }

            CarregarDados();
        }

        private void CalcularSalario()
        {
            try
            {
                pessoaService.CalcularSalarioPessoas();
                Response.Write("Cálculo de salário realizado com sucesso.");
            }
            catch (Exception ex)
            {
                Response.Write("Erro: " + ex.Message);
            }

            CarregarDados();
        }



        //protected async void btnCalculaSalario_ServerClick(Object sender, EventArgs e)
        //{
        //  await  CalcularSalarioAsync();
        //}

        protected void btnCalculaSalario_ServerClick(Object sender, EventArgs e)
        {
            CalcularSalario();
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtId.Text == String.Empty)
                {
                    CadastrarPessoa();
                    Response.Write("<script>alert('Pessoa cadastrada com sucesso!');</script>");

                }
                else
                {
                    AtualizarPessoa();
                    Response.Write("<script>alert('Pessoa atualizada com sucesso!');</script>");
                }
                   

            }
            catch (Exception ex)
            {
                Response.Write("Erro: " + ex.Message);
            }
        }

        protected void btnLimpar_Click(object sender, EventArgs e)
        {
            
            txtId.Text = String.Empty;
            txtNome.Text = String.Empty;
            txtCidade.Text = String.Empty;
            txtEmail.Text = String.Empty;
            txtCEP.Text = String.Empty;
            txtEndereco.Text = String.Empty;
            txtPais.Text = String.Empty;
            txtUsuario.Text = String.Empty;
            txtTelefone.Text = String.Empty;
            txtDataNascimento.Text = String.Empty;
            ddlCargoId.ClearSelection();

        }

        protected void gvPessoas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Editar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                string id = gvPessoas.DataKeys[index].Value.ToString();

                PessoaService pessoaService = new PessoaService();
                DataRow pessoa = pessoaService.ObterPessoaPorId(Convert.ToInt32(id));

                if (pessoa != null)
                {

                    txtNome.Text = pessoa["NOME"].ToString();
                    txtCidade.Text = pessoa["CIDADE"].ToString();
                    txtEmail.Text = pessoa["EMAIL"].ToString();
                    txtCEP.Text = pessoa["CEP"].ToString();
                    txtEndereco.Text = pessoa["ENDERECO"].ToString();
                    txtPais.Text = pessoa["PAIS"].ToString();
                    txtUsuario.Text = pessoa["USUARIO"].ToString();
                    txtTelefone.Text = pessoa["TELEFONE"].ToString();

                    if (pessoa["DATA_NASCIMENTO"] != DBNull.Value)
                    {
                        txtDataNascimento.Text = Convert.ToDateTime(pessoa["DATA_NASCIMENTO"]).ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        txtDataNascimento.Text = "";
                    }

                    ddlCargoId.SelectedValue = pessoa["CARGO_ID"].ToString();

                    txtId.Text = pessoa["ID"].ToString();
                }
            }

            if (e.CommandName == "Excluir")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                string id = gvPessoas.DataKeys[index].Value.ToString();

                PessoaService pessoaService = new PessoaService();
                pessoaService.ExcluirPessoa(Convert.ToInt32(id));

                CarregarDados();
            }
        }

        protected void btnSair_Click(object sender, EventArgs e)
        {
            Session["UsuarioLogado"] = null; 
            Session.Abandon();
            Response.Redirect("login.aspx");
        }

    }
}