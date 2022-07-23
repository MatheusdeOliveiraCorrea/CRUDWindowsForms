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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabela = new System.Windows.Forms.DataGridView();
            this.btnDeletar = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.atualizar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tabela)).BeginInit();
            this.SuspendLayout();
            // 
            // tabela
            // 
            this.tabela.AllowUserToResizeColumns = false;
            this.tabela.AllowUserToResizeRows = false;
            this.tabela.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tabela.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.tabela.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.tabela.DefaultCellStyle = dataGridViewCellStyle1;
            this.tabela.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.tabela.Location = new System.Drawing.Point(18, 9);
            this.tabela.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabela.Name = "tabela";
            this.tabela.RowHeadersWidth = 51;
            this.tabela.RowTemplate.Height = 29;
            this.tabela.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tabela.Size = new System.Drawing.Size(853, 345);
            this.tabela.TabIndex = 0;
            this.tabela.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // btnDeletar
            // 
            this.btnDeletar.ForeColor = System.Drawing.Color.Red;
            this.btnDeletar.Location = new System.Drawing.Point(544, 362);
            this.btnDeletar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDeletar.Name = "btnDeletar";
            this.btnDeletar.Size = new System.Drawing.Size(157, 25);
            this.btnDeletar.TabIndex = 1;
            this.btnDeletar.Text = "Deletar Usuário";
            this.btnDeletar.UseVisualStyleBackColor = true;
            this.btnDeletar.Click += new System.EventHandler(this.btnDeletar_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.ForeColor = System.Drawing.Color.Blue;
            this.btnAdd.Location = new System.Drawing.Point(714, 362);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(157, 25);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Adcionar Usuário";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.aoClicarAdcionarUsuario);
            // 
            // btnSair
            // 
            this.btnSair.Location = new System.Drawing.Point(12, 362);
            this.btnSair.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(157, 25);
            this.btnSair.TabIndex = 3;
            this.btnSair.Text = "Sair";
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // atualizar
            // 
            this.atualizar.Location = new System.Drawing.Point(381, 362);
            this.atualizar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.atualizar.Name = "atualizar";
            this.atualizar.Size = new System.Drawing.Size(157, 25);
            this.atualizar.TabIndex = 4;
            this.atualizar.Text = "Atualizar Tabela";
            this.atualizar.UseVisualStyleBackColor = true;
            this.atualizar.Click += new System.EventHandler(this.aoClickarAtualizar);
            // 
            // TelaPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 398);
            this.Controls.Add(this.atualizar);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnDeletar);
            this.Controls.Add(this.tabela);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "TelaPrincipal";
            this.Text = "Lista De Clientes";
            this.Load += new System.EventHandler(this.frameLista_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tabela)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView tabela;
        private System.Windows.Forms.Button btnDeletar;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnSair;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button atualizar;
    }
}
