using BLL;
using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppPrincipal
{
    public partial class FormConsultarGrupoUsuario : Form
    {
        public int id;
        public FormConsultarGrupoUsuario()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            grupoUsuarioBindingSource.DataSource = new GrupoUsuarioBLL().BuscarPorNomeGrupo(txtBuscarGrupo.Text);
        }

        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            if (grupoUsuarioBindingSource.Count >0)
            {
                id = ((GrupoUsuario)grupoUsuarioBindingSource.Current).id_GrupoUsuario;
                Close();
            }
            else
            {
                MessageBox.Show("Não existe um grupo de usuário para ser selecionado.");
            }
        }
    }
}
