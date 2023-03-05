using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    internal class Permissao
    {
        public int IdDescricao { get; set; }
        public string Descricao { get; set; }
        public List<GrupoUsuario> GrupoUsuarios { get; set; }
    }
}
