using desafio.Services;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace desafio.Web
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["UsuarioLogado"] = null;
        }

        protected void btnEntrar_Click(object sender, EventArgs e)
        {
          

            LoginService loginService = new LoginService();

            string usuario = txtUsuario.Text.Trim();
            string senha = txtSenha.Text.Trim();

            bool autenticado = loginService.ValidarLogin(usuario, senha);

            if (autenticado)
            {
                Session["UsuarioLogado"] = usuario;
                Response.Redirect("home.aspx");
            }
            else
            {
                
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Login ou senha incorretos.');", true);
            }
        }

        protected void btnCriarSenha_Click(object sender, EventArgs e)
        {
            {
                LoginService loginService = new LoginService();

                string usuario = txtUsuario.Text.Trim();
                string senha = txtSenha.Text.Trim();

                string resultado = loginService.CriarSenha(usuario, senha);
                ClientScript.RegisterStartupScript(this.GetType(), "alert", $"alert('{resultado}');", true);
               
            }

        }
    }
}