using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class FornecedorDAL
    {
        public void Inserir(Fornecedor _fornecedor)
        {
            SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);
            try
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = @"INSERT INTO Fornecedor(Nome, Fone,Email,Site) VALUES(@Nome,@Fone,@Email,@Site)";
                cmd.CommandType = System.Data.CommandType.Text;

                cmd.Parameters.AddWithValue("@Nome", _fornecedor.Nome);
                cmd.Parameters.AddWithValue("@Fone", _fornecedor.Fone);
                cmd.Parameters.AddWithValue("@Email", _fornecedor.Email);
                cmd.Parameters.AddWithValue("@Site", _fornecedor.Site);
               

                cmd.Connection = cn;
                cn.Open();

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new Exception("Ocorreu um erro ao tentar inserir um Fornecedor no banco de dados", ex) { Data = { { "Id", 15 } } };
            }
            finally
            {
                cn.Close();
            }

        }
        public List<Fornecedor> BuscarTodos()
        {
            List<Fornecedor> fornecedorList = new List<Fornecedor>();
            Fornecedor fornecedor = new Fornecedor();
            SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = @"SELECT Nome, Fone, Email, Site FORM Fornecedor";
                cmd.CommandType = System.Data.CommandType.Text;

                cn.Open();
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        fornecedor.Id = (int)rd["Id"];
                        fornecedor.Nome = rd["Nome"].ToString();
                        fornecedor.Fone = rd["Fone"].ToString();
                        fornecedor.Email = rd["Email"].ToString();
                        fornecedor.Site = rd["Site"].ToString();

                        fornecedorList.Add(fornecedor);
                    }
                }
                return fornecedorList;
            }
            catch (Exception ex)
            {

                throw new Exception("ocorreu um erro ao tentar buscar no banco de dados", ex) { Data = { { "Id", 16 } } };
            }
            finally
            {
                cn.Close();
            }
        }
        public Fornecedor BuscarPorId(int _id)
        {
            Fornecedor cliente = new Fornecedor();
            SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = @"SELECT Nome, Fone, Email,Site FORM Fornecedor WHERE Id = @Id";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@Id", _id);

                cn.Open();
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        cliente.Id = (int)rd["Id"];
                        cliente.Nome = rd["Nome"].ToString();
                        cliente.Fone = rd["Fone"].ToString();
                        cliente.Email = rd["Email"].ToString();
                        cliente.Site = rd["Site"].ToString();

                    }
                }
                return cliente;
            }
            catch (Exception ex)
            {

                throw new Exception("Ocorreu um erro ao tentar buscar Fornecedor por Id no banco de dados", ex) { Data = { { "Id", 18 } } };
            }
            finally
            {
                cn.Close();
            }
        }
        public List<Fornecedor> BuscarPorNome(string _nome)
        {
            List<Fornecedor> fornecedorList = new List<Fornecedor>();
            Fornecedor fornecedor = new Fornecedor();
            SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = @"SELECT Nome, Fone, Email, Site FORM Fornecedor WHERE Nome LIKE @Nome";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@Nome", "%" + _nome + "%");

                cn.Open();
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        fornecedor.Id = (int)rd["Id"];
                        fornecedor.Nome = rd["Nome"].ToString();
                        fornecedor.Fone = rd["Fone"].ToString();
                        fornecedor.Email = rd["Email"].ToString();
                        fornecedor.Site = rd["Site"].ToString();

                        fornecedorList.Add(fornecedor);
                    }
                }
                return fornecedorList;
            }
            catch (Exception ex)
            {

                throw new Exception("Ocorreu um erro ao tentar buscar Fornecedor por Nome no banco de dados", ex) { Data = { { "Id", 17 } } };
            }
            finally
            {
                cn.Close();
            }
        }
        public List<Fornecedor> BuscarPorSite(string _site)
        {
            List<Fornecedor> fornecedorList = new List<Fornecedor>();
            Fornecedor fornecedor = new Fornecedor();
            SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = @"SELECT Nome, Fone, Email, Site FORM Fornecedor WHERE Site LIKE @Site";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@Site", "%" + _site + "%");

                cn.Open();
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        fornecedor.Id = (int)rd["Id"];
                        fornecedor.Nome = rd["Nome"].ToString();
                        fornecedor.Fone = rd["Fone"].ToString();
                        fornecedor.Email = rd["Email"].ToString();
                        fornecedor.Site = rd["Site"].ToString();

                        fornecedorList.Add(fornecedor);
                    }
                }
                return fornecedorList;
            }
            catch (Exception ex)
            {

                throw new Exception("Ocorreu um erro ao tentar buscar Fornecedor por Nome no banco de dados", ex) { Data = { { "Id", 17 } } };
            }
            finally
            {
                cn.Close();
            }
        }
        public void Alterar(Fornecedor _fornecedor)
        {
            SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);
            try
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = @"UPDATE Fornecedor SET Nome = @Nome, Fone =@Fone,,Email =@Email,Site =@Site WHERE Id = @Id";
                ;
                cmd.CommandType = System.Data.CommandType.Text;

                cmd.Parameters.AddWithValue("@Nome", _fornecedor.Nome);
                cmd.Parameters.AddWithValue("@Fone", _fornecedor.Fone);
                cmd.Parameters.AddWithValue("@Email", _fornecedor.Email);
                cmd.Parameters.AddWithValue("@Site", _fornecedor.Site);

                cmd.Connection = cn;
                cn.Open();

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new Exception("Ocorreu um erro ao tentar alterar Fonecedor no banco de dados", ex) { Data = { { "Id", 20 } } };
            }
            finally
            {
                cn.Close();
            }
        }
        public void Excluir(int _id)
        {
            SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);
            try
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = @"DELETE FROM Fornecedor WHERE Id = @Id";
                ;
                cmd.CommandType = System.Data.CommandType.Text;

                cmd.Parameters.AddWithValue("@Id", _id);


                cmd.Connection = cn;
                cn.Open();

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new Exception("Ocorreu um erro ao tentar excluir Fornecedor no banco de dados", ex) { Data = { { "Id", 21 } } };
            }
            finally
            {
                cn.Close();
            }
        }
    }
}
