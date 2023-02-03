namespace VarejoSimplesModa.View
{
    partial class FrmDetalhesRelatorioVendas
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnReimprimir = new System.Windows.Forms.Button();
            this.btnEstornar = new System.Windows.Forms.Button();
            this.btnDetalhar = new System.Windows.Forms.Button();
            this.dgDetalhesFluxoCaixa = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Referencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgDetalhesFluxoCaixa)).BeginInit();
            this.SuspendLayout();
            // 
            // btnReimprimir
            // 
            this.btnReimprimir.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReimprimir.Location = new System.Drawing.Point(976, 154);
            this.btnReimprimir.Name = "btnReimprimir";
            this.btnReimprimir.Size = new System.Drawing.Size(85, 33);
            this.btnReimprimir.TabIndex = 7;
            this.btnReimprimir.Text = "Reimprimir";
            this.btnReimprimir.UseVisualStyleBackColor = true;
            this.btnReimprimir.Click += new System.EventHandler(this.btnReimprimir_Click);
            // 
            // btnEstornar
            // 
            this.btnEstornar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEstornar.Location = new System.Drawing.Point(976, 115);
            this.btnEstornar.Name = "btnEstornar";
            this.btnEstornar.Size = new System.Drawing.Size(85, 33);
            this.btnEstornar.TabIndex = 6;
            this.btnEstornar.Text = "Estornar";
            this.btnEstornar.UseVisualStyleBackColor = true;
            this.btnEstornar.Click += new System.EventHandler(this.btnEstornar_Click_1);
            // 
            // btnDetalhar
            // 
            this.btnDetalhar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetalhar.Location = new System.Drawing.Point(976, 76);
            this.btnDetalhar.Name = "btnDetalhar";
            this.btnDetalhar.Size = new System.Drawing.Size(85, 33);
            this.btnDetalhar.TabIndex = 5;
            this.btnDetalhar.Text = "Detalhar";
            this.btnDetalhar.UseVisualStyleBackColor = true;
            this.btnDetalhar.Click += new System.EventHandler(this.btnDetalhar_Click_1);
            // 
            // dgDetalhesFluxoCaixa
            // 
            this.dgDetalhesFluxoCaixa.AllowUserToAddRows = false;
            this.dgDetalhesFluxoCaixa.AllowUserToDeleteRows = false;
            this.dgDetalhesFluxoCaixa.AllowUserToResizeColumns = false;
            this.dgDetalhesFluxoCaixa.AllowUserToResizeRows = false;
            this.dgDetalhesFluxoCaixa.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgDetalhesFluxoCaixa.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgDetalhesFluxoCaixa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDetalhesFluxoCaixa.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Referencia,
            this.Column7,
            this.Column8,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.dgDetalhesFluxoCaixa.GridColor = System.Drawing.SystemColors.Control;
            this.dgDetalhesFluxoCaixa.Location = new System.Drawing.Point(12, 31);
            this.dgDetalhesFluxoCaixa.Name = "dgDetalhesFluxoCaixa";
            this.dgDetalhesFluxoCaixa.RowHeadersVisible = false;
            this.dgDetalhesFluxoCaixa.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgDetalhesFluxoCaixa.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgDetalhesFluxoCaixa.Size = new System.Drawing.Size(947, 413);
            this.dgDetalhesFluxoCaixa.TabIndex = 4;
            this.dgDetalhesFluxoCaixa.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgDetalhesFluxoCaixa_CellClick_1);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Id";
            this.Column1.HeaderText = "Id";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Visible = false;
            // 
            // Referencia
            // 
            this.Referencia.DataPropertyName = "num_referencia";
            this.Referencia.HeaderText = "Referencia";
            this.Referencia.Name = "Referencia";
            this.Referencia.ReadOnly = true;
            this.Referencia.Visible = false;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "DataHora";
            this.Column7.HeaderText = "Data Hora";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 110;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "Descricao";
            this.Column8.HeaderText = "Descrição";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Visible = false;
            this.Column8.Width = 200;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "TiposMovimentacao";
            this.Column2.HeaderText = "Tipos Movimentacao";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 300;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "FormaPagamento";
            this.Column3.HeaderText = "Forma Pagamento";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 150;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "Entrada";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = null;
            dataGridViewCellStyle5.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.Column4.DefaultCellStyle = dataGridViewCellStyle5;
            this.Column4.HeaderText = "Entrada";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "Saida";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = null;
            dataGridViewCellStyle6.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.Column5.DefaultCellStyle = dataGridViewCellStyle6;
            this.Column5.HeaderText = "Saida";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // FrmDetalhesRelatorioVendas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1083, 456);
            this.Controls.Add(this.btnReimprimir);
            this.Controls.Add(this.btnEstornar);
            this.Controls.Add(this.btnDetalhar);
            this.Controls.Add(this.dgDetalhesFluxoCaixa);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDetalhesRelatorioVendas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vendas";
            this.Load += new System.EventHandler(this.FrmDetalhesRelatorioVendas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgDetalhesFluxoCaixa)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnReimprimir;
        private System.Windows.Forms.Button btnEstornar;
        private System.Windows.Forms.Button btnDetalhar;
        private System.Windows.Forms.DataGridView dgDetalhesFluxoCaixa;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Referencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.IO.Ports.SerialPort serialPort1;
    }
}