using System;
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
    public partial class TelaCarreg : Form
    {
        public TelaCarreg()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value <100)
            {
                progressBar1.Value += 4;
            }
            else
            {
                timer1.Enabled = false;
                FormPrincipal log = new FormPrincipal();
                log.Show();
                this.Visible = false;
            }
        }
    }
}
