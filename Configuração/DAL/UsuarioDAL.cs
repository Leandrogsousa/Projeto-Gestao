using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
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
                                    VALUES(@Nome, @NomeUsuario, @CPF, @Email, @Senha, @Ativo)";

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
        }
        public Usuario BuscarPorNome(string _nomeUsuario)
        {
            Usuario usuario = new Usuario();
            SqlConnection cn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();

            try
            {
                cn.ConnectionString = Conexao.StringDeConexao;
                cmd.Connection = cn;
                cmd.CommandText = @"SELECT id_usuario, Nome, CPF, Email, Ativo
                                    FROM Usuario WHERE NomeUsuario = @NomeUsuario";

                cmd.Parameters.AddWithValue("@NomeUsuario", _nomeUsuario);
                cmd.CommandType = System.Data.CommandType.Text;
                cn.Open();
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    if (rd.Read())
                    {
                        usuario = new Usuario();
                        usuario.id_usuario = Convert.ToInt32(rd["id_usuario"]);
                        usuario.Nome = rd["Nome"].ToString();
                        usuario.NomeUsuario = rd["NomeUsuario"].ToString();
                        usuario.CPF = rd["CPF"].ToString();
                        usuario.Email = rd["Email"].ToString();
                        usuario.Ativo = Convert.ToBoolean(rd["Ativo"]);

                        GrupoUsuarioDAL grupoUsuarioDAL = new GrupoUsuarioDAL();
                       // usuario.GrupoUsuarios = grupoUsuarioDAL.BuscarPorNome(usuario.id_usuario);
                        
                    }
                    else
                    {
                        throw new Exception("Usuário não encontrado.");
                    }
                }
                return usuario;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao tentar fazer busca de usuário por Nome de Usuário: " + ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }
        public List<Usuario> BuscarTodos()
        {
            List<Usuario> usuarios = new List<Usuario>();
            Usuario usuario;

            SqlConnection cn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();

            try
            {
                cn.ConnectionString = Conexao.StringDeConexao;
                cmd.Connection = cn;
                cmd.CommandText = @"SELECT id_usuario, Nome, NomeUsuario,CPF, Email, Ativo 
                                    FROM Usuario";
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
                return usuarios;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao tentar buscar todos os usuários: " + ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

        public void Alterar(Usuario _alterarUsuario)
        {
            SqlConnection cn = new SqlConnection();

            try
            {
                cn.ConnectionString = Conexao.StringDeConexao;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = @"UPDATE Usuario SET Nome = @Nome, NomeUsuario = @NomeUsuario, CPF = @CPF, Email = @Email, Senha = @Senha, Ativo = @Ativo WHERE id_usuario = @id_usuario";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@Nome", _alterarUsuario.Nome);
                cmd.Parameters.AddWithValue("@NomeUsuario", _alterarUsuario.NomeUsuario);
                cmd.Parameters.AddWithValue("@CPF", _alterarUsuario.CPF);
                cmd.Parameters.AddWithValue("@Email", _alterarUsuario.Email);
                cmd.Parameters.AddWithValue("@Senha", _alterarUsuario.Senha);
                cmd.Parameters.AddWithValue("@Ativo", _alterarUsuario.Ativo);
                cmd.Parameters.AddWithValue("@id_usuario", _alterarUsuario.id_usuario);

                cn.Open();
                cmd.BeginExecuteNonQuery();
                
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao tentar Atualizar o cadastro de usuário no banco: " + ex.Message);
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
                cmd.CommandText = @"DELETE FROM UsuarioGrupoUsuario WHERE id_usuario = @id_usuario
                                    DELETE FROM Usuario WHERE id_usuario = @id_usuario";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@id_usuario", _usuario);

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

        public Usuario BuscarPorID(int id_usuario)
        {
            throw new NotImplementedException();
        }

        public bool ExisteRelacionamento(int idUsuario, int idGrupoUsuario)
        {
            throw new NotImplementedException();
        }

        public void AdicionarGrupo(int idUsuario, int idGrupoUsuario)
        {
            throw new NotImplementedException();
        }
        public bool ValidarPermissao(int _idUsuario, int _idPermissao)
        {
           

            SqlConnection cn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();

            try
            {
                cn.ConnectionString = Conexao.StringDeConexao;
                cmd.Connection = cn;
                cmd.CommandText = @"SELELCT TOP 1 1  AS Resultado FROM UsuarioGrupoUsuario
                                    INNER JOIN PermissaoGrupoUsuario
                                    ON UsuarioGrupoUsuario.id_GrupoUsuario = PermissaoGrupoUsuario.id_GrupoUsuario
                                    WHERE UsuarioGrupoUsuario.id_usuario = @id_usuario
                                    AND PermissaoGrupoUsuario.id_permissao = @id_permissao";


                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@id_usuario", _idUsuario);
                cmd.Parameters.AddWithValue("@id_permissao", _idPermissao);

                cn.Open();
                using (SqlDataReader rd = cmd.ExecuteReader()) ;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}