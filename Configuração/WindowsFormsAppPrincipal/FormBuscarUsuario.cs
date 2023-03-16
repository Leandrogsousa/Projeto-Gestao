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
using System.Security.Cryptography.X509Certificates;

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

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (usuarioBindingSource.Count <0)
            {
                MessageBox.Show("Não existe registro para ser excluído!");
                return;
            }
            if (MessageBox.Show("Deseja realmente excluir esse registro?", "Atenção", MessageBoxButtons.YesNo) == DialogResult.No)
            return ;

            int id_usuario = ((Usuario)usuarioBindingSource.Current).id_usuario;
            new UsuarioBLL().Excluir(id_usuario);

            MessageBox.Show("Registro excluído com sucesso.");
            btnBuscar_Click(null, null);
        }

        private void btnAdicionarGrupo_Click(object sender, EventArgs e)
        {
            using (FormConsultarGrupoUsuario frm = new FormConsultarGrupoUsuario())
            {
                frm.ShowDialog();
                UsuarioBLL usuarioBLL = new UsuarioBLL();
                int id_usuario = ((Usuario)usuarioBindingSource.Current).id_usuario;
                usuarioBLL.AdicionarGrupo(id_usuario, frm.id);
            }
        }
    }

}
