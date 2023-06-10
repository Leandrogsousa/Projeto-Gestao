namespace WindowsFormsAppPrincipal
{
    partial class FormCadastroCliente
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label nomeLabel;
            System.Windows.Forms.Label cPFLabel;
            System.Windows.Forms.Label rGLabel;
            System.Windows.Forms.Label emailLabel;
            System.Windows.Forms.Label foneLabel;
            this.nomeTextBox = new System.Windows.Forms.TextBox();
            this.clienteBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cPFTextBox = new System.Windows.Forms.TextBox();
            this.rGTextBox = new System.Windows.Forms.TextBox();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.foneTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            nomeLabel = new System.Windows.Forms.Label();
            cPFLabel = new System.Windows.Forms.Label();
            rGLabel = new System.Windows.Forms.Label();
            emailLabel = new System.Windows.Forms.Label();
            foneLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.clienteBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // nomeLabel
            // 
            nomeLabel.AutoSize = true;
            nomeLabel.Location = new System.Drawing.Point(23, 97);
            nomeLabel.Name = "nomeLabel";
            nomeLabel.Size = new System.Drawing.Size(44, 16);
            nomeLabel.TabIndex = 1;
            nomeLabel.Text = "Nome";
            // 
            // nomeTextBox
            // 
            this.nomeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.clienteBindingSource, "Nome", true));
            this.nomeTextBox.Location = new System.Drawing.Point(26, 116);
            this.nomeTextBox.Name = "nomeTextBox";
            this.nomeTextBox.Size = new System.Drawing.Size(281, 22);
            this.nomeTextBox.TabIndex = 2;
            // 
            // clienteBindingSource
            // 
            this.clienteBindingSource.DataSource = typeof(Models.Cliente);
            // 
            // cPFLabel
            // 
            cPFLabel.AutoSize = true;
            cPFLabel.Location = new System.Drawing.Point(325, 97);
            cPFLabel.Name = "cPFLabel";
            cPFLabel.Size = new System.Drawing.Size(33, 16);
            cPFLabel.TabIndex = 3;
            cPFLabel.Text = "CPF";
            // 
            // cPFTextBox
            // 
            this.cPFTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.clienteBindingSource, "CPF", true));
            this.cPFTextBox.Location = new System.Drawing.Point(328, 116);
            this.cPFTextBox.Name = "cPFTextBox";
            this.cPFTextBox.Size = new System.Drawing.Size(180, 22);
            this.cPFTextBox.TabIndex = 4;
            // 
            // rGLabel
            // 
            rGLabel.AutoSize = true;
            rGLabel.Location = new System.Drawing.Point(529, 97);
            rGLabel.Name = "rGLabel";
            rGLabel.Size = new System.Drawing.Size(27, 16);
            rGLabel.TabIndex = 5;
            rGLabel.Text = "RG";
            // 
            // rGTextBox
            // 
            this.rGTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.clienteBindingSource, "RG", true));
            this.rGTextBox.Location = new System.Drawing.Point(532, 116);
            this.rGTextBox.Name = "rGTextBox";
            this.rGTextBox.Size = new System.Drawing.Size(163, 22);
            this.rGTextBox.TabIndex = 6;
            // 
            // emailLabel
            // 
            emailLabel.AutoSize = true;
            emailLabel.Location = new System.Drawing.Point(26, 163);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new System.Drawing.Size(45, 16);
            emailLabel.TabIndex = 7;
            emailLabel.Text = "E-mail";
            // 
            // emailTextBox
            // 
            this.emailTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.clienteBindingSource, "Email", true));
            this.emailTextBox.Location = new System.Drawing.Point(29, 182);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(278, 22);
            this.emailTextBox.TabIndex = 8;
            // 
            // foneLabel
            // 
            foneLabel.AutoSize = true;
            foneLabel.Location = new System.Drawing.Point(325, 163);
            foneLabel.Name = "foneLabel";
            foneLabel.Size = new System.Drawing.Size(38, 16);
            foneLabel.TabIndex = 9;
            foneLabel.Text = "Fone";
            // 
            // foneTextBox
            // 
            this.foneTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.clienteBindingSource, "Fone", true));
            this.foneTextBox.Location = new System.Drawing.Point(328, 182);
            this.foneTextBox.Name = "foneTextBox";
            this.foneTextBox.Size = new System.Drawing.Size(180, 22);
            this.foneTextBox.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(728, 45);
            this.label1.TabIndex = 11;
            this.label1.Text = "Cadastro de Cliente";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(607, 354);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 12;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(508, 355);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(75, 23);
            this.btnSalvar.TabIndex = 13;
            this.btnSalvar.Text = "&Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // FormCadastroCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 425);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.label1);
            this.Controls.Add(foneLabel);
            this.Controls.Add(this.foneTextBox);
            this.Controls.Add(emailLabel);
            this.Controls.Add(this.emailTextBox);
            this.Controls.Add(rGLabel);
            this.Controls.Add(this.rGTextBox);
            this.Controls.Add(cPFLabel);
            this.Controls.Add(this.cPFTextBox);
            this.Controls.Add(nomeLabel);
            this.Controls.Add(this.nomeTextBox);
            this.Name = "FormCadastroCliente";
            this.Text = "FormCadastroCliente";
            ((System.ComponentModel.ISupportInitialize)(this.clienteBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource clienteBindingSource;
        private System.Windows.Forms.TextBox nomeTextBox;
        private System.Windows.Forms.TextBox cPFTextBox;
        private System.Windows.Forms.TextBox rGTextBox;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.TextBox foneTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnSalvar;
    }
}