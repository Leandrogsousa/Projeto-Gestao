using System;
using Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class GrupoUsuarioDAL
    {
        public void Inserir(GrupoUsuario _grupousuario)
        {
            SqlConnection cn = new SqlConnection();

            try
            {
                cn.ConnectionString = Conexao.StringDeConexao;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = @"INSERT INTO GrupoUsuario(NomeGrupo) VALUES (@NomeGrupo)";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@GrupoUsuario", _grupousuario.NomeGrupo);

                cn.Open();
                cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {

                throw new Exception("Ocorreu um erro ao tentar inserir o Nome do grupo no banco: " + ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }
        public GrupoUsuario Buscar(GrupoUsuario _grupousuario)
        {
            GrupoUsuario grupo = new GrupoUsuario();
            SqlConnection cn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            try
            {
                cn.ConnectionString = Conexao.StringDeConexao;
                cmd.Connection = cn;
                cmd.CommandText = "SELECT TOP 100 id_GrupoUsuario, NomeGrupo FROM GrupoUsuario WHERE id_GrupoUsuario = @id_GrupoUsuario";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@id_NomeGrupo", _grupousuario.id_GrupoUsuario);

                cn.Open();

                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        grupo = new GrupoUsuario();
                        grupo.id_GrupoUsuario = Convert.ToInt32(rd["id_GrupoUsuario"]);
                        grupo.NomeGrupo = rd["NomeGrupo"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao tentar listar o grupo." + ex.Message);
            }
            finally
            {
                cn.Close();
            }
            return grupo;
        }
        public void Alterar(GrupoUsuario _grupousuario)
        {
            SqlConnection cn = new SqlConnection();

            try
            {
                cn.ConnectionString = Conexao.StringDeConexao;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = @"UPDATE GrupoUsuario SET NomeGrupo = @NomeGrupo WHERE id_GrupoUsuario = @id_GrupoUsuario";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("id_GrupoUsuario", _grupousuario.id_GrupoUsuario);
                cmd.Parameters.AddWithValue("@GrupoUsuario", _grupousuario.NomeGrupo);

                cn.Open();
                cmd.BeginExecuteNonQuery();
                
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao tentar alterar o nome do grupo no banco: " + ex.Message);
            }
            finally
            {
                cn.Close();
            }

        }
        public void Excluir(GrupoUsuario _grupoUsuario)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conexao.StringDeConexao;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = @"DELETE FROM GrupoUsuario WHERE id_GrupoUsuario = @id_GrupoUsuario";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@id_GrupoUsuario", _grupoUsuario.id_GrupoUsuario);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new Exception("Ocorreu um erro ao tentar excluir o grupo no banco: " + ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }
    }

   }
