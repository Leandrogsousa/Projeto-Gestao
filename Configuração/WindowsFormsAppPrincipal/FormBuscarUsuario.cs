using BLL;
using System;
using Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppPrincipal
{
    public partial class FormBuscarUsuario : Form
    {
        public FormBuscarUsuario()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            UsuarioBLL usuarioBLL = new UsuarioBLL();
            if (txtBuscar.Text =="")
            {
                usuarioBindingSource.DataSource = usuarioBLL.BuscarTodos();
            }
            else
            {
                usuarioBindingSource.DataSource = usuarioBLL.BuscarPorNome(txtBuscar.Text);
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            int id_usuario = ((Usuario)usuarioBindingSource.Current).id_usuario;
            using(FormCadastroUsuario frm = new FormCadastroUsuario(true, id_usuario))
            {
                frm.ShowDialog();
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            using (FormCadastroUsuario frm = new FormCadastroUsuario())
            {
                frm.ShowDialog();
            }
          
        }
    }

}
