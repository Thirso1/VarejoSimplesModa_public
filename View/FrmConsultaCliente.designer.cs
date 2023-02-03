namespace VarejoSimplesModa.View
{
    partial class FrmConsultaCliente
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgConsultaCliente = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblCliente = new System.Windows.Forms.Label();
            this.textNome = new System.Windows.Forms.TextBox();
            this.textRua = new System.Windows.Forms.TextBox();
            this.lblEndereco = new System.Windows.Forms.Label();
            this.lblCpf = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnNovo = new System.Windows.Forms.Button();
            this.btnConfirma = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgConsultaCliente)).BeginInit();
            this.SuspendLayout();
            // 
            // dgConsultaCliente
            // 
            this.dgConsultaCliente.AllowUserToAddRows = false;
            this.dgConsultaCliente.AllowUserToDeleteRows = false;
            this.dgConsultaCliente.AllowUserToResizeColumns = false;
            this.dgConsultaCliente.AllowUserToResizeRows = false;
            this.dgConsultaCliente.BackgroundColor = System.Drawing.Color.White;
            this.dgConsultaCliente.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgConsultaCliente.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgConsultaCliente.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgConsultaCliente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgConsultaCliente.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column3,
            this.Column4,
            this.Column2,
            this.Column5});
            this.dgConsultaCliente.Location = new System.Drawing.Point(68, 169);
            this.dgConsultaCliente.Name = "dgConsultaCliente";
            this.dgConsultaCliente.ReadOnly = true;
            this.dgConsultaCliente.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgConsultaCliente.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgConsultaCliente.RowHeadersVisible = false;
            this.dgConsultaCliente.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgConsultaCliente.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgConsultaCliente.Size = new System.Drawing.Size(831, 340);
            this.dgConsultaCliente.TabIndex = 39;
            this.dgConsultaCliente.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgConsultaCliente_CellClick);
            this.dgConsultaCliente.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgConsultaCliente_CellMouseMove);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "idclientes";
            this.Column1.HeaderText = "id";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Visible = false;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "nome";
            this.Column3.HeaderText = "nome";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 150;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "sobrenome";
            this.Column4.HeaderText = "sobrenome";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 350;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "cpf";
            this.Column2.HeaderText = "CPF";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 150;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "telefone";
            this.Column5.HeaderText = "telefone";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 150;
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCliente.Location = new System.Drawing.Point(64, 76);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(73, 24);
            this.lblCliente.TabIndex = 35;
            this.lblCliente.Text = "Cliente:";
            // 
            // textNome
            // 
            this.textNome.BackColor = System.Drawing.Color.White;
            this.textNome.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textNome.ForeColor = System.Drawing.Color.Black;
            this.textNome.Location = new System.Drawing.Point(169, 76);
            this.textNome.Name = "textNome";
            this.textNome.Size = new System.Drawing.Size(369, 22);
            this.textNome.TabIndex = 36;
            this.textNome.Enter += new System.EventHandler(this.textNome_Enter);
            this.textNome.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textNome_KeyPress);
            // 
            // textRua
            // 
            this.textRua.BackColor = System.Drawing.Color.White;
            this.textRua.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textRua.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textRua.ForeColor = System.Drawing.Color.Black;
            this.textRua.Location = new System.Drawing.Point(169, 114);
            this.textRua.Name = "textRua";
            this.textRua.Size = new System.Drawing.Size(587, 22);
            this.textRua.TabIndex = 37;
            // 
            // lblEndereco
            // 
            this.lblEndereco.AutoSize = true;
            this.lblEndereco.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEndereco.Location = new System.Drawing.Point(64, 114);
            this.lblEndereco.Name = "lblEndereco";
            this.lblEndereco.Size = new System.Drawing.Size(99, 24);
            this.lblEndereco.TabIndex = 40;
            this.lblEndereco.Text = "Endereço:";
            // 
            // lblCpf
            // 
            this.lblCpf.AutoSize = true;
            this.lblCpf.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCpf.Location = new System.Drawing.Point(544, 76);
            this.lblCpf.Name = "lblCpf";
            this.lblCpf.Size = new System.Drawing.Size(52, 24);
            this.lblCpf.TabIndex = 41;
            this.lblCpf.Text = "CPF:";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.Black;
            this.textBox1.Location = new System.Drawing.Point(602, 76);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(154, 22);
            this.textBox1.TabIndex = 42;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(327, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 29);
            this.label1.TabIndex = 43;
            this.label1.Text = "Busca Cliente";
            // 
            // btnNovo
            // 
            this.btnNovo.BackColor = System.Drawing.Color.Red;
            this.btnNovo.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnNovo.FlatAppearance.BorderSize = 0;
            this.btnNovo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNovo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNovo.ForeColor = System.Drawing.Color.White;
            this.btnNovo.Location = new System.Drawing.Point(808, 72);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(91, 28);
            this.btnNovo.TabIndex = 44;
            this.btnNovo.Text = "Novo";
            this.btnNovo.UseVisualStyleBackColor = false;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // btnConfirma
            // 
            this.btnConfirma.BackColor = System.Drawing.Color.ForestGreen;
            this.btnConfirma.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnConfirma.FlatAppearance.BorderSize = 0;
            this.btnConfirma.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirma.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirma.ForeColor = System.Drawing.Color.White;
            this.btnConfirma.Location = new System.Drawing.Point(808, 114);
            this.btnConfirma.Name = "btnConfirma";
            this.btnConfirma.Size = new System.Drawing.Size(91, 28);
            this.btnConfirma.TabIndex = 46;
            this.btnConfirma.Text = "Confirma";
            this.btnConfirma.UseVisualStyleBackColor = false;
            this.btnConfirma.Click += new System.EventHandler(this.btnConfirma_Click);
            // 
            // FrmConsultaCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(927, 532);
            this.Controls.Add(this.btnConfirma);
            this.Controls.Add(this.btnNovo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblCpf);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lblEndereco);
            this.Controls.Add(this.dgConsultaCliente);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.textNome);
            this.Controls.Add(this.textRua);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmConsultaCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmConsultaCliente";
            this.Load += new System.EventHandler(this.FrmConsultaCliente_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmConsultaCliente_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgConsultaCliente)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgConsultaCliente;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.TextBox textNome;
        private System.Windows.Forms.TextBox textRua;
        private System.Windows.Forms.Label lblEndereco;
        private System.Windows.Forms.Label lblCpf;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.Button btnConfirma;
    }
}