namespace WinFormsApp1
{
    partial class TelaPrincipal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnDeletar = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.atualizar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.gridUsuarios = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridUsuarios)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDeletar
            // 
            this.btnDeletar.ForeColor = System.Drawing.Color.Red;
            this.btnDeletar.Location = new System.Drawing.Point(622, 483);
            this.btnDeletar.Name = "btnDeletar";
            this.btnDeletar.Size = new System.Drawing.Size(179, 33);
            this.btnDeletar.TabIndex = 1;
            this.btnDeletar.Text = "Deletar Usuário";
            this.btnDeletar.UseVisualStyleBackColor = true;
            this.btnDeletar.Click += new System.EventHandler(this.btnDeletar_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.ForeColor = System.Drawing.Color.Blue;
            this.btnAdd.Location = new System.Drawing.Point(816, 483);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(179, 33);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Adcionar Usuário";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.aoClicarAdcionarUsuario);
            // 
            // btnSair
            // 
            this.btnSair.Location = new System.Drawing.Point(14, 483);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(179, 33);
            this.btnSair.TabIndex = 3;
            this.btnSair.Text = "Sair";
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // atualizar
            // 
            this.atualizar.Location = new System.Drawing.Point(247, 483);
            this.atualizar.Name = "atualizar";
            this.atualizar.Size = new System.Drawing.Size(111, 33);
            this.atualizar.TabIndex = 4;
            this.atualizar.Text = "Atualizar Tabela";
            this.atualizar.UseVisualStyleBackColor = true;
            this.atualizar.Click += new System.EventHandler(this.aoClickarAtualizar);
            // 
            // btnEditar
            // 
            this.btnEditar.ForeColor = System.Drawing.Color.Black;
            this.btnEditar.Location = new System.Drawing.Point(423, 483);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(179, 33);
            this.btnEditar.TabIndex = 5;
            this.btnEditar.Text = "Editar Usuário";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.aoClickarEditar);
            // 
            // gridUsuarios
            // 
            this.gridUsuarios.AllowUserToAddRows = false;
            this.gridUsuarios.AllowUserToDeleteRows = false;
            this.gridUsuarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridUsuarios.EnableHeadersVisualStyles = false;
            this.gridUsuarios.Location = new System.Drawing.Point(14, 16);
            this.gridUsuarios.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridUsuarios.Name = "gridUsuarios";
            this.gridUsuarios.ReadOnly = true;
            this.gridUsuarios.RowHeadersWidth = 51;
            this.gridUsuarios.RowTemplate.Height = 25;
            this.gridUsuarios.Size = new System.Drawing.Size(982, 460);
            this.gridUsuarios.TabIndex = 6;
            this.gridUsuarios.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridUsuarios_CellClick);
            this.gridUsuarios.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridUsuarios_CellContentClick);
            // 
            // TelaPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 531);
            this.Controls.Add(this.gridUsuarios);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.atualizar);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnDeletar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TelaPrincipal";
            this.Text = "Lista De Clientes";
            this.Load += new System.EventHandler(this.frameLista_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridUsuarios)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion


        private System.Windows.Forms.Button btnDeletar;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnSair;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button atualizar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.DataGridView gridUsuarios;
    }
}
