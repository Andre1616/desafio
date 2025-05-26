using System;
using System.Data;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;

namespace desafio.Services
{
    public class PessoaService
    {
        private readonly OracleDatabaseService _dbService;

        public PessoaService()
        {
            _dbService = new OracleDatabaseService();
        }

        public DataTable ObterPessoas()
        {
            DataTable dt = new DataTable();

            using (OracleConnection conn = _dbService.GetConnection())
            {
                using (OracleCommand cmd = new OracleCommand("STPPESSOALIST", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("p_cursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                    try
                    {
                        conn.Open();
                        using (OracleDataAdapter da = new OracleDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Erro ao obter pessoas: " + ex.Message, ex);
                    }
                }
            }

            return dt;
        }

        public async Task CalcularSalarioPessoasAsync()
        {
            using (OracleConnection conn = _dbService.GetConnection())
            {
                using (OracleCommand cmd = new OracleCommand("STPCALCULASALARIOPESSOAS", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    try
                    {
                       await conn.OpenAsync();
                       await cmd.ExecuteNonQueryAsync();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Erro ao calcular salário das pessoas: " + ex.Message, ex);
                    }
                }
            }
        }

        public void CalcularSalarioPessoas()
        {
            using (OracleConnection conn = _dbService.GetConnection())
            {
                using (OracleCommand cmd = new OracleCommand("STPCALCULASALARIOPESSOAS", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Erro ao calcular salário das pessoas: " + ex.Message, ex);
                    }
                }
            }
        }

        public void CadastrarPessoa(
            string nome,
            string cidade,
            string email,
            string cep,
            string endereco,
            string pais,
            string usuario,
            string telefone,
            DateTime dataNascimento,
            int cargoId)
        {
            using (OracleConnection conn = _dbService.GetConnection())
            {
                using (OracleCommand cmd = new OracleCommand("STPPESSOAINS", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("p_nome", OracleDbType.Varchar2).Value = nome;
                    cmd.Parameters.Add("p_cidade", OracleDbType.Varchar2).Value = cidade;
                    cmd.Parameters.Add("p_email", OracleDbType.Varchar2).Value = email;
                    cmd.Parameters.Add("p_cep", OracleDbType.Varchar2).Value = cep;
                    cmd.Parameters.Add("p_endereco", OracleDbType.Varchar2).Value = endereco;
                    cmd.Parameters.Add("p_pais", OracleDbType.Varchar2).Value = pais;
                    cmd.Parameters.Add("p_usuario", OracleDbType.Varchar2).Value = usuario;
                    cmd.Parameters.Add("p_telefone", OracleDbType.Varchar2).Value = telefone;
                    cmd.Parameters.Add("p_data_nascimento", OracleDbType.Date).Value = dataNascimento;
                    cmd.Parameters.Add("p_cargo_id", OracleDbType.Int32).Value = cargoId;

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Erro ao inserir pessoa: " + ex.Message, ex);
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
        }

        public void AtualizarPessoa(
    int id,
    string nome,
    string cidade,
    string email,
    string cep,
    string endereco,
    string pais,
    string usuario,
    string telefone,
    DateTime dataNascimento,
    int cargoId)
        {
            using (OracleConnection conn = _dbService.GetConnection())
            {
                using (OracleCommand cmd = new OracleCommand("STPPESSOAUPD", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("p_id", OracleDbType.Int32).Value = id;
                    cmd.Parameters.Add("p_nome", OracleDbType.Varchar2).Value = nome;
                    cmd.Parameters.Add("p_cidade", OracleDbType.Varchar2).Value = cidade;
                    cmd.Parameters.Add("p_email", OracleDbType.Varchar2).Value = email;
                    cmd.Parameters.Add("p_cep", OracleDbType.Varchar2).Value = cep;
                    cmd.Parameters.Add("p_endereco", OracleDbType.Varchar2).Value = endereco;
                    cmd.Parameters.Add("p_pais", OracleDbType.Varchar2).Value = pais;
                    cmd.Parameters.Add("p_usuario", OracleDbType.Varchar2).Value = usuario;
                    cmd.Parameters.Add("p_telefone", OracleDbType.Varchar2).Value = telefone;
                    cmd.Parameters.Add("p_data_nascimento", OracleDbType.Date).Value = dataNascimento;
                    cmd.Parameters.Add("p_cargo_id", OracleDbType.Int32).Value = cargoId;

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Erro ao atualizar pessoa: " + ex.Message, ex);
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
        }

        public void ExcluirPessoa(int id)
        {
            using (OracleConnection conn = _dbService.GetConnection())
            {
                using (OracleCommand cmd = new OracleCommand("STPPESSOADEL", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("p_id", OracleDbType.Int32).Value = id;

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Erro ao excluir pessoa: " + ex.Message, ex);
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
        }


        public DataRow ObterPessoaPorId(int id)
        {
            DataTable dt = new DataTable();

            using (OracleConnection conn = _dbService.GetConnection())
            {
                using (OracleCommand cmd = new OracleCommand("STPPESSOASEL", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("p_id", OracleDbType.Int32).Value = id;
                    cmd.Parameters.Add("p_result", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                    try
                    {
                        conn.Open();

                        using (OracleDataAdapter da = new OracleDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }

                        if (dt.Rows.Count > 0)
                        {
                            return dt.Rows[0];
                        }
                        else
                        {
                            return null;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Erro ao obter pessoa por ID: " + ex.Message, ex);
                    }
                }
            }
        }

    }
}
