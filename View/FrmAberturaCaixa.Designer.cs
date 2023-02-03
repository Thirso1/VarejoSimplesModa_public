namespace VarejoSimplesModa.View
{
    partial class FrmAberturaCaixa
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnConfirma = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.Inicial = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtGerente = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbOperadorCaixa = new System.Windows.Forms.ComboBox();
            this.txtFundoCaixa = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTotalAbertura = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.pnSenhaOperador = new System.Windows.Forms.Panel();
            this.textSenhaOperador = new System.Windows.Forms.TextBox();
            this.lblOperador = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.pnSenhaOperador.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(290, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(202, 42);
            this.label1.TabIndex = 0;
            this.label1.Text = "Abrir Caixa";
            // 
            // btnConfirma
            // 
            this.btnConfirma.BackColor = System.Drawing.Color.Green;
            this.btnConfirma.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirma.ForeColor = System.Drawing.Color.White;
            this.btnConfirma.Location = new System.Drawing.Point(252, 412);
            this.btnConfirma.Name = "btnConfirma";
            this.btnConfirma.Size = new System.Drawing.Size(117, 33);
            this.btnConfirma.TabIndex = 1;
            this.btnConfirma.Text = "Confirma";
            this.btnConfirma.UseVisualStyleBackColor = false;
            this.btnConfirma.Click += new System.EventHandler(this.btnConfirma_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.Red;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(375, 412);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(117, 33);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "Cancela";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(409, 202);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Suprimento Inicial: ";
            // 
            // Inicial
            // 
            this.Inicial.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Inicial.Location = new System.Drawing.Point(559, 199);
            this.Inicial.Name = "Inicial";
            this.Inicial.Size = new System.Drawing.Size(130, 26);
            this.Inicial.TabIndex = 4;
            this.Inicial.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Inicial.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Inicial_KeyPress_1);
            this.Inicial.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Inicial_KeyUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(80, 161);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Gerente:";
            // 
            // txtGerente
            // 
            this.txtGerente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGerente.Location = new System.Drawing.Point(158, 158);
            this.txtGerente.Name = "txtGerente";
            this.txtGerente.ReadOnly = true;
            this.txtGerente.Size = new System.Drawing.Size(130, 26);
            this.txtGerente.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(29, 202);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Operador Caixa:";
            // 
            // cbOperadorCaixa
            // 
            this.cbOperadorCaixa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOperadorCaixa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbOperadorCaixa.FormattingEnabled = true;
            this.cbOperadorCaixa.Location = new System.Drawing.Point(158, 199);
            this.cbOperadorCaixa.Name = "cbOperadorCaixa";
            this.cbOperadorCaixa.Size = new System.Drawing.Size(130, 28);
            this.cbOperadorCaixa.TabIndex = 8;
            // 
            // txtFundoCaixa
            // 
            this.txtFundoCaixa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFundoCaixa.Location = new System.Drawing.Point(559, 158);
            this.txtFundoCaixa.Name = "txtFundoCaixa";
            this.txtFundoCaixa.ReadOnly = true;
            this.txtFundoCaixa.Size = new System.Drawing.Size(130, 26);
            this.txtFundoCaixa.TabIndex = 10;
            this.txtFundoCaixa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(424, 161);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(128, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "Fundo de Caixa: ";
            // 
            // txtTotalAbertura
            // 
            this.txtTotalAbertura.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalAbertura.Location = new System.Drawing.Point(559, 308);
            this.txtTotalAbertura.Name = "txtTotalAbertura";
            this.txtTotalAbertura.ReadOnly = true;
            this.txtTotalAbertura.Size = new System.Drawing.Size(130, 26);
            this.txtTotalAbertura.TabIndex = 12;
            this.txtTotalAbertura.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(371, 311);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(181, 20);
            this.label6.TabIndex = 11;
            this.label6.Text = "Saldo total de Abertura: ";
            // 
            // pnSenhaOperador
            // 
            this.pnSenhaOperador.Controls.Add(this.textSenhaOperador);
            this.pnSenhaOperador.Controls.Add(this.lblOperador);
            this.pnSenhaOperador.Controls.Add(this.label8);
            this.pnSenhaOperador.Controls.Add(this.label7);
            this.pnSenhaOperador.Location = new System.Drawing.Point(695, 121);
            this.pnSenhaOperador.Name = "pnSenhaOperador";
            this.pnSenhaOperador.Size = new System.Drawing.Size(695, 250);
            this.pnSenhaOperador.TabIndex = 13;
            // 
            // textSenhaOperador
            // 
            this.textSenhaOperador.Location = new System.Drawing.Point(234, 95);
            this.textSenhaOperador.Name = "textSenhaOperador";
            this.textSenhaOperador.Size = new System.Drawing.Size(100, 20);
            this.textSenhaOperador.TabIndex = 3;
            // 
            // lblOperador
            // 
            this.lblOperador.AutoSize = true;
            this.lblOperador.Location = new System.Drawing.Point(231, 48);
            this.lblOperador.Name = "lblOperador";
            this.lblOperador.Size = new System.Drawing.Size(0, 13);
            this.lblOperador.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(116, 98);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Senha:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(116, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Operador de Caixa:";
            // 
            // FrmAberturaCaixa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(768, 486);
            this.Controls.Add(this.pnSenhaOperador);
            this.Controls.Add(this.txtTotalAbertura);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtFundoCaixa);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbOperadorCaixa);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtGerente);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Inicial);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnConfirma);
            this.Controls.Add(this.label1);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAberturaCaixa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AbrirCaixa";
            this.Load += new System.EventHandler(this.FrmAberturaCaixa_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmAberturaCaixa_KeyDown);
            this.pnSenhaOperador.ResumeLayout(false);
            this.pnSenhaOperador.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnConfirma;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Inicial;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtGerente;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbOperadorCaixa;
        private System.Windows.Forms.TextBox txtFundoCaixa;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTotalAbertura;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel pnSenhaOperador;
        private System.Windows.Forms.TextBox textSenhaOperador;
        private System.Windows.Forms.Label lblOperador;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
    }
}