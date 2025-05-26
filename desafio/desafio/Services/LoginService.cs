using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Security.Cryptography;



namespace desafio.Services
{

    public class LoginService
    {
        private readonly OracleDatabaseService _dbService;

        public LoginService()
        {
            _dbService = new OracleDatabaseService();
        }

        public string CriarSenha(string usuario, string senha)
        {
            string mensagem = "";
            string senhaHash = GerarHashSHA256(senha);

            using (OracleConnection conn = _dbService.GetConnection())
            {
                using (OracleCommand cmd = new OracleCommand("STPCRIARSENHA", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("p_usuario", OracleDbType.Varchar2).Value = usuario;
                    cmd.Parameters.Add("p_senha", OracleDbType.Varchar2).Value = senhaHash;
                    cmd.Parameters.Add("p_mensagem", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();

                        mensagem = cmd.Parameters["p_mensagem"].Value.ToString();
                    }
                    catch (Exception ex)
                    {
                        mensagem = "Erro: " + ex.Message;
                    }
                }
            }

            return mensagem;
        }

        public bool ValidarLogin(string usuario, string senha)
        {
            bool autenticado = false;
            string senhaHash = GerarHashSHA256(senha);
            using (OracleConnection conn = _dbService.GetConnection())
            {
                string sql = @"
            SELECT COUNT(*) 
            FROM PESSOA p
            JOIN PESSOA_LOGIN pl ON p.ID = pl.PESSOA_ID
            WHERE p.USUARIO = :usuario AND pl.SENHA = :senha";

                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    cmd.Parameters.Add("usuario", OracleDbType.Varchar2).Value = usuario;
                    cmd.Parameters.Add("senha", OracleDbType.Varchar2).Value = senhaHash;

                    try
                    {
                        conn.Open();
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        autenticado = count > 0;
                    }
                    catch
                    {
                        autenticado = false;
                    }
                }
            }

            return autenticado;
        }

        public string GerarHashSHA256(string senha)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(senha));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
    }