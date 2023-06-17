using DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class FornecedorBLL
    {
        public void Inserir(Fornecedor _fornecedor)
        {
            new FornecedorBLL().Inserir(_fornecedor);
        }
        public List<Fornecedor> BuscarTodos()
        {
          return  new FornecedorDAL().BuscarTodos();
        }
        public Fornecedor BuscarPorId(int _id)
        {
           return new FornecedorDAL().BuscarPorId(_id);
        }
        public List<Fornecedor> BuscarPorNome(string _nome)
        {
            return new FornecedorDAL().BuscarPorNome(_nome);
        }
        public List<Fornecedor> BuscarPorSite(string _site)
        {
            return new FornecedorDAL().BuscarPorSite(_site);
        }
        public void Alterar(Fornecedor _fornecedor)
        {
            new FornecedorDAL().Alterar(_fornecedor);

        }
        public void Excluir(int _id)
        {
            new FornecedorDAL().Excluir(_id);
        }
    }
}
