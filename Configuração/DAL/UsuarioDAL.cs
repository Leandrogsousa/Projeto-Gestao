using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UsuarioDAL
    {
        public void Inserir(Usuario _usuario)
        {
            SqlConnection cn = new SqlConnection();

            try
            {
                cn.ConnectionString = Conexao.StringDeConexao;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = @"INSERT INTO Usuario(Nome, NomeUsuario, CPF, Email, Senha, Ativo)
                                      VALUES (@Nome, @NomeUsuario, @CPF, @Email, @Senha, @Ativo)";

                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@Nome", _usuario.Nome);
                cmd.Parameters.AddWithValue("@NomeUsuario", _usuario.NomeUsuario);
                cmd.Parameters.AddWithValue("@CPF", _usuario.CPF);
                cmd.Parameters.AddWithValue("@Email", _usuario.Email);
                cmd.Parameters.AddWithValue("@Senha", _usuario.Senha);
                cmd.Parameters.AddWithValue("@Ativo", _usuario.Ativo);

                cn.Open();
                cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao tentar inserir um usuário no banco: " + ex.Message);
            }
            finally
            {
                cn.Close();
            }


            public List<Usuario> BuscarTodos()
            {
                List<Usuario> usuarios = new List<Usuario>();
                Usuario usuario;

                SqlConnection cn = new SqlConnection();
                SqlCommand cmd = new SqlCommand();

                //SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);//dessa forma também funciona
                try
                {
                    cn.ConnectionString = Conexao.StringDeConexao;
                    cmd.Connection = cn;
                    cmd.CommandText = "SELECT TOP 100 id_usuario, Nome, NomeUsuario, CPF, Email, Ativo FROM Usuario";
                    cmd.CommandType = System.Data.CommandType.Text;
                    cn.Open();

                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            usuario = new Usuario();
                            usuario.id_usuario = Convert.ToInt32(rd["id_usuario"]);
                            usuario.Nome = rd["Nome"].ToString();
                            usuario.NomeUsuario = rd["NomeUsuario"].ToString();
                            usuario.CPF = rd["CPF"].ToString();
                            usuario.Email = rd["Email"].ToString();
                            usuario.Ativo = Convert.ToBoolean(rd["Ativo"]);

                            usuarios.Add(usuario);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Ocorreu um erro ao tentar buscar todos os usuários: " + ex.Message);
                }
                finally
                {
                    cn.Close();
                }
                return usuarios;
            }
            public void Alterar(Usuario _usuario)
            {
                SqlConnection cn = new SqlConnection();

                try
                {
                    cn.ConnectionString = Conexao.StringDeConexao;
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = cn;
                    cmd.CommandText = @"UPDATE Usuario SET Nome = @Nome, NomeUsuario = @NomeUsuario, CPF = @CPF, Email = @Email, Senha = @Senha, Ativo = @Ativo WHERE IdUsuario = @IdUsuario";
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Parameters.AddWithValue("@Nome", _usuario.Nome);
                    cmd.Parameters.AddWithValue("@NomeUsuario", _usuario.NomeUsuario);
                    cmd.Parameters.AddWithValue("@CPF", _usuario.CPF);
                    cmd.Parameters.AddWithValue("@Email", _usuario.Email);
                    cmd.Parameters.AddWithValue("@Senha", _usuario.Senha);
                    cmd.Parameters.AddWithValue("@Ativo", _usuario.Ativo);
                    cmd.Parameters.AddWithValue("@IdUsuario", _usuario.id_usuario);

                    cn.Open();
                    cmd.BeginExecuteNonQuery();
                    //cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    throw new Exception("Ocorreu um erro ao tentar atualizar o cadastro de usuário no banco: " + ex.Message);
                }
                finally
                {
                    cn.Close();
                }
            }
            public void Excluir(Usuario _usuario)
            {
                SqlConnection cn = new SqlConnection();

                try
                {
                    cn.ConnectionString = Conexao.StringDeConexao;
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = cn;
                    cmd.CommandText = @"DELETE FROM Usuario WHERE id_usuario = @id_usuario";
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Parameters.AddWithValue("@id_usuario", _usuario.id_usuario);

                    cn.Open();
                    cmd.ExecuteScalar();

                 
                }
                catch (Exception ex)
                {

                    throw new Exception("Ocorreu um erro ao tentar excluir o usuário no banco de dados: " + ex.Message);
                }
                finally
                {
                    cn.Close();
                }
            }
            public Usuario BuscarPorNome(string _nomeUsuario)
            {
                SqlConnection cn = new SqlConnection();
                SqlCommand cmd = new SqlCommand();
                Usuario usuario = new Usuario();

                try
                {
                    cn.ConnectionString = Conexao.StringDeConexao;
                    cmd.Connection = cn;
                    cmd.CommandText = @"SELECT id_usuario, Nome, NomeUsuario, CPF, Email, Ativo FROM Usuario WHERE NomeUsuario = @NomeUsuario";
                    cmd.Parameters.AddWithValue("@NomeUsuario", _nomeUsuario);
                    cmd.CommandType = System.Data.CommandType.Text;

                    cn.Open();

                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            usuario = new Usuario();
                            usuario.id_usuario = Convert.ToInt32(rd["id_usuario"]);
                            usuario.Nome = rd["Nome"].ToString();
                            usuario.NomeUsuario = rd["NomeUsuario"].ToString();
                            usuario.CPF = rd["CPF"].ToString();
                            usuario.Email = rd["Email"].ToString();
                            usuario.Ativo = Convert.ToBoolean(rd["Ativo"]);
                        }
                    }
                    return usuario;
                }
                catch (Exception ex)
                {
                    throw new Exception("Ocorreu um erro ao tentar buscar por usuário: " + ex.Message); ;
                }
                finally
                {
                    cn.Close();
                }

            }
        }
    }
}