using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DAL
{
    public static class Conexao
    {
        public static string StringDeConexao
        {
            get
            {
               // return @"User Id=Leandro_Sousa\leand;Initial Catalog=Gestao;Data Source=.\LEANDRO_SOUSA";
                return @"User ID=SA;Initial Catalog=Gestao;Data Source=.\SQLEXPRESS2019;Password=Senailab02";
            }
        }
    }
}
