namespace VarejoSimplesModa.View
{
    partial class FrmConsultaProduto
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
            this.txtBusca = new System.Windows.Forms.TextBox();
            this.radioEstoqueZerado = new System.Windows.Forms.RadioButton();
            this.radioEstoqueBaixo = new System.Windows.Forms.RadioButton();
            this.radioTodos = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgProdutos = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgProdutos)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Produto";
            // 
            // txtBusca
            // 
            this.txtBusca.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBusca.Location = new System.Drawing.Point(83, 56);
            this.txtBusca.Name = "txtBusca";
            this.txtBusca.Size = new System.Drawing.Size(316, 26);
            this.txtBusca.TabIndex = 1;
            this.txtBusca.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBusca_KeyUp);
            // 
            // radioEstoqueZerado
            // 
            this.radioEstoqueZerado.AutoSize = true;
            this.radioEstoqueZerado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioEstoqueZerado.Location = new System.Drawing.Point(514, 56);
            this.radioEstoqueZerado.Name = "radioEstoqueZerado";
            this.radioEstoqueZerado.Size = new System.Drawing.Size(142, 24);
            this.radioEstoqueZerado.TabIndex = 7;
            this.radioEstoqueZerado.TabStop = true;
            this.radioEstoqueZerado.Text = "Estoque Zerado";
            this.radioEstoqueZerado.UseVisualStyleBackColor = true;
            // 
            // radioEstoqueBaixo
            // 
            this.radioEstoqueBaixo.AutoSize = true;
            this.radioEstoqueBaixo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioEstoqueBaixo.Location = new System.Drawing.Point(691, 55);
            this.radioEstoqueBaixo.Name = "radioEstoqueBaixo";
            this.radioEstoqueBaixo.Size = new System.Drawing.Size(130, 24);
            this.radioEstoqueBaixo.TabIndex = 8;
            this.radioEstoqueBaixo.TabStop = true;
            this.radioEstoqueBaixo.Text = "Estoque Baixo";
            this.radioEstoqueBaixo.UseVisualStyleBackColor = true;
            // 
            // radioTodos
            // 
            this.radioTodos.AutoSize = true;
            this.radioTodos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioTodos.Location = new System.Drawing.Point(861, 55);
            this.radioTodos.Name = "radioTodos";
            this.radioTodos.Size = new System.Drawing.Size(71, 24);
            this.radioTodos.TabIndex = 9;
            this.radioTodos.TabStop = true;
            this.radioTodos.Text = "Todos";
            this.radioTodos.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "Busca";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(510, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "Filtros";
            // 
            // dgProdutos
            // 
            this.dgProdutos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgProdutos.Location = new System.Drawing.Point(12, 137);
            this.dgProdutos.Name = "dgProdutos";
            this.dgProdutos.Size = new System.Drawing.Size(979, 409);
            this.dgProdutos.TabIndex = 2;
            // 
            // FrmConsultaProduto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1003, 558);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.radioTodos);
            this.Controls.Add(this.radioEstoqueBaixo);
            this.Controls.Add(this.radioEstoqueZerado);
            this.Controls.Add(this.dgProdutos);
            this.Controls.Add(this.txtBusca);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmConsultaProduto";
            this.Text = "FrmConsultaProduto";
            this.Load += new System.EventHandler(this.FrmConsultaProduto_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmConsultaProduto_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgProdutos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBusca;
        private System.Windows.Forms.RadioButton radioEstoqueZerado;
        private System.Windows.Forms.RadioButton radioEstoqueBaixo;
        private System.Windows.Forms.RadioButton radioTodos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgProdutos;
    }
}