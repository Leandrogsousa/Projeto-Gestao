using BLL;
using Models;
using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppPrincipal
{
    public partial class FormCadastroUsuario : Form
    {
        private bool alterar;
        

        public FormCadastroUsuario(bool _alterar = false, int _id_usuario=0)
        {
            InitializeComponent();
            alterar = _alterar;

            if (alterar)
            {
                usuarioBindingSource.DataSource = new UsuarioBLL().BuscarPorID(_id_usuario);
                
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            UsuarioBLL usuarioBLL = new UsuarioBLL();

            try
            {
                usuarioBindingSource.EndEdit();

                if (!alterar)
                {
                    usuarioBLL.Inserir((Usuario)usuarioBindingSource.Current, txtConfirmacao.Text);
                }
                else
                {
                    usuarioBLL.Alterar((Usuario)usuarioBindingSource.Current, txtConfirmacao.Text);
                }
                MessageBox.Show("Registro Salvo com Sucesso.");
                Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void FormCadastroUsuario_load(object sender, EventArgs e)
        {
            if (!alterar)
                usuarioBindingSource.AddNew();
        }

        
    }
}
