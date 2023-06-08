using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PermissaoDAL
    {
        public void Inserir(Permissao _permissao)
        {
            SqlConnection cn = new SqlConnection();

            try
            {
                cn.ConnectionString = Conexao.StringDeConexao;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = @"INSERT INTO Permissao(descricao) VALUES (@descricao)";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@descricao", _permissao.descricao);

                cn.Open();
                cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {

                throw new Exception("Ocorreu um erro ao tentar inserir uma descrição no banco: " + ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }
        public Permissao BuscarPorId(int _id)
        {
            Permissao permissao = new Permissao();
            SqlConnection cn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();

            try
            {
                cn.ConnectionString = Conexao.StringDeConexao;
                cmd.Connection = cn;
                cmd.CommandText = "Select TOP 100 id_permissao, descricao FROM Permissao WHERE id_permissao = @id_permissao";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@id_permissao", _id);
                cn.Open();
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        permissao = new Permissao();
                        permissao.id_permissao = Convert.ToInt32(rd["id_permissao"]);
                        permissao.descricao = rd["descricao"].ToString();
                    }
                }
                
            }
            catch (Exception ex)
            {

                throw new Exception("Ocorreu um erro ao tentar buscar uma permissão no banco: " + ex.Message);
            }
            finally
            {
                cn.Close();
            }
            return permissao;
        }
        public void Alterar(Permissao _permissao)
        {
            SqlConnection cn = new SqlConnection();

            try
            {
                cn.ConnectionString = Conexao.StringDeConexao;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = @"UPDATE Permissao SET descricao = @id_permissao WHERE id_permissao = @id_permissao";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@id_permissao", _permissao.id_permissao);
                cmd.Parameters.AddWithValue("@descricao", _permissao.descricao);

                cn.Open();
                cmd.BeginExecuteNonQuery();
                //cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {

                throw new Exception("Ocorreu um erro ao tentar atualizar uma permissao no banco: " + ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }
        public void Excluir(Permissao _permissao)
        {
            SqlConnection cn = new SqlConnection();

            try
            {
                cn.ConnectionString = Conexao.StringDeConexao;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = @"DELETE FROM Permissao WHERE id_permissao = @id_permissao";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@id_permissao", _permissao.id_permissao);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new Exception("Ocorreu um erro ao tentar excluir uma permissão no banco: " + ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }
        public List<Permissao> BuscarPorIdGrupo(int _idGrupoUsuario)
        {
            List<Permissao> permissaos = new List<Permissao>();
            Permissao permissao = new Permissao();
            SqlConnection cn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            try
            {
                cn.ConnectionString = Conexao.StringDeConexao;
                cmd.Connection = cn;
                cmd.CommandText = @"SELECT Permissao.id_descricao, Permissao.descricao FROM GrupoUsuario
                                    INNER JOIN PermissaoGrupoUsuario ON GrupoUsuario.id_GrupoUsuario = PermissaoGrupoUsuario.IdGrupoUsuario
									inner join Permissao on PermissaoGrupoUsuario.Id_Descricao = Permissao.IDDescricao
                                    WHERE GrupoUsuario.id_GrupoUsuario = @id_GrupoUsuario";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@IDGrupoUsuario", _idGrupoUsuario);
                cn.Open();
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        permissao = new Permissao();
                        permissao.id_permissao = Convert.ToInt32(rd["IdDescricao"]);
                        permissao.descricao = rd["Descricao"].ToString();
                        GrupoUsuarioDAL grupoUsuarioDAL = new GrupoUsuarioDAL();
                        permissao.GrupoUsuarios = grupoUsuarioDAL.BuscarPorId(permissao.id_permissao);
                        permissaos.Add(permissao);
                    }
                }
                return permissaos;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao tentar buscar Grupo de Usuarios: " + ex.Message); ;
            }
            finally
            {
                cn.Close();
            }
        }
    }
}

