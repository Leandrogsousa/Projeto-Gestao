using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Permissao
    {
        public int id_permissao { get; set; }
        public string descricao { get; set; }
        public List<GrupoUsuario> GrupoUsuarios { get; set; }
    }
}
