namespace VarejoSimplesModa.View
{
    partial class Retirada
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
            this.lblDescricao = new System.Windows.Forms.Label();
            this.lblValor = new System.Windows.Forms.Label();
            this.lblretirada = new System.Windows.Forms.Label();
            this.cmbUsuario = new System.Windows.Forms.ComboBox();
            this.textValRetirada = new System.Windows.Forms.TextBox();
            this.cmbDescricao = new System.Windows.Forms.ComboBox();
            this.btnConfirma = new System.Windows.Forms.Button();
            this.textEspecificar = new System.Windows.Forms.TextBox();
            this.lblEspecificar = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textGaveta = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(147, 138);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 29);
            this.label1.TabIndex = 9;
            this.label1.Text = "USUÁRIO";
            // 
            // lblDescricao
            // 
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescricao.ForeColor = System.Drawing.Color.Navy;
            this.lblDescricao.Location = new System.Drawing.Point(98, 232);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(159, 29);
            this.lblDescricao.TabIndex = 8;
            this.lblDescricao.Text = "DESCRIÇÃO:";
            // 
            // lblValor
            // 
            this.lblValor.AutoSize = true;
            this.lblValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValor.ForeColor = System.Drawing.Color.Navy;
            this.lblValor.Location = new System.Drawing.Point(159, 186);
            this.lblValor.Name = "lblValor";
            this.lblValor.Size = new System.Drawing.Size(98, 29);
            this.lblValor.TabIndex = 7;
            this.lblValor.Text = "VALOR:";
            // 
            // lblretirada
            // 
            this.lblretirada.AutoSize = true;
            this.lblretirada.Font = new System.Drawing.Font("Arial Rounded MT Bold", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblretirada.ForeColor = System.Drawing.Color.Navy;
            this.lblretirada.Location = new System.Drawing.Point(179, 9);
            this.lblretirada.Name = "lblretirada";
            this.lblretirada.Size = new System.Drawing.Size(184, 37);
            this.lblretirada.TabIndex = 6;
            this.lblretirada.Text = "RETIRADA";
            // 
            // cmbUsuario
            // 
            this.cmbUsuario.Enabled = false;
            this.cmbUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbUsuario.FormattingEnabled = true;
            this.cmbUsuario.Location = new System.Drawing.Point(273, 138);
            this.cmbUsuario.Name = "cmbUsuario";
            this.cmbUsuario.Size = new System.Drawing.Size(181, 33);
            this.cmbUsuario.TabIndex = 10;
            // 
            // textValRetirada
            // 
            this.textValRetirada.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textValRetirada.Location = new System.Drawing.Point(273, 186);
            this.textValRetirada.Name = "textValRetirada";
            this.textValRetirada.Size = new System.Drawing.Size(181, 30);
            this.textValRetirada.TabIndex = 11;
            this.textValRetirada.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textValRetirada.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textValRetirada_KeyPress);
            this.textValRetirada.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textValRetirada_KeyUp);
            // 
            // cmbDescricao
            // 
            this.cmbDescricao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDescricao.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDescricao.FormattingEnabled = true;
            this.cmbDescricao.Items.AddRange(new object[] {
            "Fornecedor",
            "Retirada Numerário",
            "outros"});
            this.cmbDescricao.Location = new System.Drawing.Point(273, 232);
            this.cmbDescricao.Name = "cmbDescricao";
            this.cmbDescricao.Size = new System.Drawing.Size(181, 33);
            this.cmbDescricao.TabIndex = 12;
            this.cmbDescricao.SelectedIndexChanged += new System.EventHandler(this.cmbDescricao_SelectedIndexChanged);
            this.cmbDescricao.Leave += new System.EventHandler(this.cmbDescricao_Leave);
            // 
            // btnConfirma
            // 
            this.btnConfirma.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnConfirma.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirma.ForeColor = System.Drawing.Color.White;
            this.btnConfirma.Location = new System.Drawing.Point(133, 380);
            this.btnConfirma.Name = "btnConfirma";
            this.btnConfirma.Size = new System.Drawing.Size(144, 35);
            this.btnConfirma.TabIndex = 13;
            this.btnConfirma.Text = "Confirmar";
            this.btnConfirma.UseVisualStyleBackColor = false;
            this.btnConfirma.Click += new System.EventHandler(this.btnConfirma_Click);
            // 
            // textEspecificar
            // 
            this.textEspecificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEspecificar.Location = new System.Drawing.Point(273, 281);
            this.textEspecificar.Name = "textEspecificar";
            this.textEspecificar.Size = new System.Drawing.Size(181, 30);
            this.textEspecificar.TabIndex = 14;
            // 
            // lblEspecificar
            // 
            this.lblEspecificar.AutoSize = true;
            this.lblEspecificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEspecificar.ForeColor = System.Drawing.Color.Navy;
            this.lblEspecificar.Location = new System.Drawing.Point(81, 281);
            this.lblEspecificar.Name = "lblEspecificar";
            this.lblEspecificar.Size = new System.Drawing.Size(176, 29);
            this.lblEspecificar.TabIndex = 15;
            this.lblEspecificar.Text = "ESPECIFICAR:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(55, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(202, 36);
            this.label2.TabIndex = 16;
            this.label2.Text = "Saldo Gaveta:";
            // 
            // textGaveta
            // 
            this.textGaveta.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textGaveta.Location = new System.Drawing.Point(273, 93);
            this.textGaveta.Name = "textGaveta";
            this.textGaveta.ReadOnly = true;
            this.textGaveta.Size = new System.Drawing.Size(181, 30);
            this.textGaveta.TabIndex = 17;
            this.textGaveta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(295, 380);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(144, 35);
            this.button1.TabIndex = 18;
            this.button1.Text = "Cancelar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Retirada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 447);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textGaveta);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblEspecificar);
            this.Controls.Add(this.textEspecificar);
            this.Controls.Add(this.btnConfirma);
            this.Controls.Add(this.cmbDescricao);
            this.Controls.Add(this.textValRetirada);
            this.Controls.Add(this.cmbUsuario);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblDescricao);
            this.Controls.Add(this.lblValor);
            this.Controls.Add(this.lblretirada);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Retirada";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmRetirada";
            this.Load += new System.EventHandler(this.FrmRetirada_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmRetirada_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDescricao;
        private System.Windows.Forms.Label lblValor;
        private System.Windows.Forms.Label lblretirada;
        private System.Windows.Forms.ComboBox cmbUsuario;
        private System.Windows.Forms.TextBox textValRetirada;
        private System.Windows.Forms.ComboBox cmbDescricao;
        private System.Windows.Forms.Button btnConfirma;
        private System.Windows.Forms.TextBox textEspecificar;
        private System.Windows.Forms.Label lblEspecificar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textGaveta;
        private System.Windows.Forms.Button button1;
    }
}