﻿namespace CrudWindowsForms.InterfaceDoUsuario
{
    partial class TelaAdcionar
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
            this.btnConcluir = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.campoId = new System.Windows.Forms.TextBox();
            this.nome = new System.Windows.Forms.TextBox();
            this.email = new System.Windows.Forms.TextBox();
            this.senha = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dataDeCriacao = new System.Windows.Forms.TextBox();
            this.dataDeNascimento = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // btnConcluir
            // 
            this.btnConcluir.ForeColor = System.Drawing.Color.Blue;
            this.btnConcluir.Location = new System.Drawing.Point(13, 341);
            this.btnConcluir.Margin = new System.Windows.Forms.Padding(4);
            this.btnConcluir.Name = "btnConcluir";
            this.btnConcluir.Size = new System.Drawing.Size(157, 33);
            this.btnConcluir.TabIndex = 6;
            this.btnConcluir.Text = "Salvar";
            this.btnConcluir.UseVisualStyleBackColor = true;
            this.btnConcluir.Click += new System.EventHandler(this.AoClicarEmSalvar);
            // 
            // btnCancelar
            // 
            this.btnCancelar.ForeColor = System.Drawing.Color.Red;
            this.btnCancelar.Location = new System.Drawing.Point(224, 341);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(157, 33);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.AoClicarEmCancelar);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(15, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 25);
            this.label1.TabIndex = 12;
            this.label1.Text = "código:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(18, 179);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 25);
            this.label2.TabIndex = 13;
            this.label2.Text = "E-mail: *";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(21, 123);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 25);
            this.label3.TabIndex = 14;
            this.label3.Text = "Nome: *";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(20, 229);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 25);
            this.label4.TabIndex = 15;
            this.label4.Text = "Senha: *";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(-1, 274);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(186, 25);
            this.label5.TabIndex = 16;
            this.label5.Text = "Data de Nascimento:";
            // 
            // campoId
            // 
            this.campoId.Location = new System.Drawing.Point(96, 9);
            this.campoId.Margin = new System.Windows.Forms.Padding(4);
            this.campoId.Name = "campoId";
            this.campoId.ReadOnly = true;
            this.campoId.Size = new System.Drawing.Size(103, 32);
            this.campoId.TabIndex = 0;
            // 
            // nome
            // 
            this.nome.Location = new System.Drawing.Point(96, 123);
            this.nome.Margin = new System.Windows.Forms.Padding(4);
            this.nome.Name = "nome";
            this.nome.Size = new System.Drawing.Size(235, 32);
            this.nome.TabIndex = 2;
            // 
            // email
            // 
            this.email.Location = new System.Drawing.Point(96, 176);
            this.email.Margin = new System.Windows.Forms.Padding(4);
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(235, 32);
            this.email.TabIndex = 3;
            // 
            // senha
            // 
            this.senha.Location = new System.Drawing.Point(96, 229);
            this.senha.Margin = new System.Windows.Forms.Padding(4);
            this.senha.Name = "senha";
            this.senha.PasswordChar = '*';
            this.senha.Size = new System.Drawing.Size(235, 32);
            this.senha.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(13, 49);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(124, 25);
            this.label6.TabIndex = 22;
            this.label6.Text = "Data Criação:";
            // 
            // dataDeCriacao
            // 
            this.dataDeCriacao.Location = new System.Drawing.Point(96, 78);
            this.dataDeCriacao.Margin = new System.Windows.Forms.Padding(4);
            this.dataDeCriacao.Name = "dataDeCriacao";
            this.dataDeCriacao.ReadOnly = true;
            this.dataDeCriacao.Size = new System.Drawing.Size(103, 32);
            this.dataDeCriacao.TabIndex = 1;
            this.dataDeCriacao.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dataDeNascimento
            // 
            this.dataDeNascimento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dataDeNascimento.Location = new System.Drawing.Point(96, 302);
            this.dataDeNascimento.MaxDate = new System.DateTime(2100, 12, 30, 0, 0, 0, 0);
            this.dataDeNascimento.MinDate = new System.DateTime(1920, 1, 1, 0, 0, 0, 0);
            this.dataDeNascimento.Name = "dataDeNascimento";
            this.dataDeNascimento.Size = new System.Drawing.Size(235, 32);
            this.dataDeNascimento.TabIndex = 5;
            // 
            // TelaAdcionar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 380);
            this.Controls.Add(this.dataDeNascimento);
            this.Controls.Add(this.dataDeCriacao);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.senha);
            this.Controls.Add(this.email);
            this.Controls.Add(this.nome);
            this.Controls.Add(this.campoId);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnConcluir);
            this.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TelaAdcionar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Button btnConcluir;
        public System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox campoId;
        public System.Windows.Forms.TextBox nome;
        public System.Windows.Forms.TextBox email;
        public System.Windows.Forms.TextBox senha;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox dataDeCriacao;
        public System.Windows.Forms.DateTimePicker dataDeNascimento;
    }
}