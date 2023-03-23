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

        public List<GrupoUsuario> BuscarPorNomeGrupo(string _nomeGrupo)
        {
            List<GrupoUsuario> grupo_nomes = new List<GrupoUsuario>();
            GrupoUsuario grupo = new GrupoUsuario();
            SqlConnection cn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            try
            {
                cn.ConnectionString = Conexao.StringDeConexao;
                cmd.Connection = cn;
                cmd.CommandText = "SELECT id_GrupoUsuario, NomeGrupo FROM GrupoUsuario WHERE NomeGrupo like @NomeGrupo";
                cmd.Parameters.AddWithValue("@NomeGrupo", "%" + _nomeGrupo + "%");
                cmd.CommandType = System.Data.CommandType.Text;
                cn.Open();
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        grupo = new GrupoUsuario();
                        grupo.id_GrupoUsuario = Convert.ToInt32(rd["id_GrupoUsuario"]);
                        grupo.NomeGrupo = rd["NomeGrupo"].ToString();
                        PermissaoDAL permissaoDAL = new PermissaoDAL();
                        grupo.Permissoes = permissaoDAL.BuscarPorIdGrupo(grupo.id_GrupoUsuario);

                        grupo_nomes.Add(grupo);
                    }
                }
                return grupo_nomes;
            }
            catch (Exception ex)
            {

                throw new Exception("Ocorreu um erro ao tentar buscar Nome do Grupo: " + ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }
        public List<GrupoUsuario> BuscarPorIdUsuario(int _idGrupousuario)
        {
            List<GrupoUsuario> grupos = new List<GrupoUsuario>();
            GrupoUsuario grupoUsuario;
            SqlConnection cn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();





            try
            {
                cn.ConnectionString = Conexao.StringDeConexao;
                cmd.Connection = cn;
                cmd.CommandText = @"SELECT GrupoUsuario.IdGrupoUsuario, GrupoUsuario.NomeGrupo FROM GrupoUsuario 
                                    INNER JOIN UsuarioGrupoUsuario ON GrupoUsuario.id_GrupoUsuario = UsuarioGrupoUsuario.Id_GrupoUsuario 
                                    WHERE id_usuario = @id_GrupoUsuario";
                cmd.Parameters.AddWithValue("@id_GrupoUsuario", _idGrupousuario);
                cmd.CommandType = System.Data.CommandType.Text;

                cn.Open();

                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        grupoUsuario = new GrupoUsuario();
                        grupoUsuario.id_GrupoUsuario = Convert.ToInt32(rd["id_GrupoUsuario"]);
                        grupoUsuario.NomeGrupo = rd["NomeGrupo"].ToString();
                        PermissaoDAL permissaoDAL = new PermissaoDAL();
                        grupoUsuario.Permissoes = permissaoDAL.BuscarPorIdGrupo(grupoUsuario.id_GrupoUsuario);
                        grupos.Add(grupoUsuario);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao tentar listar grupos." + ex.Message);
            }
            finally
            {
                cn.Close();
            }
            return grupos;

            public List<GrupoUsuario> BuscarGrupoPorNome(string _nomeGrupo)
            {
                List<GrupoUsuario> grupo_nomes = new List<GrupoUsuario>();
                GrupoUsuario grupo = new GrupoUsuario();
                SqlConnection cn = new SqlConnection();
                SqlCommand cmd = new SqlCommand();
                try
                {
                    cn.ConnectionString = Conexao.StringDeConexao;
                    cmd.Connection = cn;
                    cmd.CommandText = "SELECT IdGrupoUsuario, NomeGrupo FROM GrupoUsuario " +
                        "               WHERE NomeGrupo like @NomeGrupo order by NomeGrupo";
                    cmd.Parameters.AddWithValue("@NomeGrupo", "%" + _nomeGrupo + "%");
                    cmd.CommandType = System.Data.CommandType.Text;
                    cn.Open();
                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            grupo = new GrupoUsuario();
                            grupo.id_GrupoUsuario = Convert.ToInt32(rd["id_GrupoUsuario"]);
                            grupo.NomeGrupo = rd["NomeGrupo"].ToString();
                            PermissaoDAL permissaoDAL = new PermissaoDAL();
                            grupo.Permissoes = permissaoDAL.BuscarPorIdGrupo(grupo.id_GrupoUsuario);

                            grupo_nomes.Add(grupo);
                        }
                    }
                    return grupo_nomes;
                }
                catch (Exception ex)
                {
                    throw new Exception("Ocorreu um erro ao tentar buscar um Nome do Grupo: " + ex.Message);
                }
                finally
                {
                    cn.Close();
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
    }
}
  
