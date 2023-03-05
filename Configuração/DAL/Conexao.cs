using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class Conexao
    {
        public static string StringDeConexao
        {
            get
            {
                return @"User Id=Leandro_Sousa\leand;Initial Catalog=Gestao;Data Source=.\LEANDRO_SOUSA";
            }
        }
    }
}
