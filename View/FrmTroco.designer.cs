namespace VarejoSimplesModa.View
{
    partial class FrmTroco
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
            this.texdinheiro = new System.Windows.Forms.TextBox();
            this.lblDesconto = new System.Windows.Forms.Label();
            this.textDesconto = new System.Windows.Forms.TextBox();
            this.lbltroco = new System.Windows.Forms.Label();
            this.lbldinheiro = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textroco = new System.Windows.Forms.TextBox();
            this.textTotal = new System.Windows.Forms.TextBox();
            this.btnConfirma = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // texdinheiro
            // 
            this.texdinheiro.Font = new System.Drawing.Font("Calibri", 30F, System.Drawing.FontStyle.Bold);
            this.texdinheiro.Location = new System.Drawing.Point(239, 123);
            this.texdinheiro.Name = "texdinheiro";
            this.texdinheiro.Size = new System.Drawing.Size(169, 56);
            this.texdinheiro.TabIndex = 36;
            this.texdinheiro.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.texdinheiro.Enter += new System.EventHandler(this.texdinheiro_Enter);
            this.texdinheiro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.texdinheiro_KeyPress);
            this.texdinheiro.KeyUp += new System.Windows.Forms.KeyEventHandler(this.texdinheiro_KeyUp);
            this.texdinheiro.Leave += new System.EventHandler(this.texdinheiro_Leave);
            // 
            // lblDesconto
            // 
            this.lblDesconto.AutoSize = true;
            this.lblDesconto.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesconto.Location = new System.Drawing.Point(16, 209);
            this.lblDesconto.Name = "lblDesconto";
            this.lblDesconto.Size = new System.Drawing.Size(199, 46);
            this.lblDesconto.TabIndex = 35;
            this.lblDesconto.Text = "Desconto";
            // 
            // textDesconto
            // 
            this.textDesconto.Font = new System.Drawing.Font("Calibri", 30F, System.Drawing.FontStyle.Bold);
            this.textDesconto.Location = new System.Drawing.Point(239, 206);
            this.textDesconto.Name = "textDesconto";
            this.textDesconto.ReadOnly = true;
            this.textDesconto.Size = new System.Drawing.Size(169, 56);
            this.textDesconto.TabIndex = 34;
            this.textDesconto.Text = "0,00";
            this.textDesconto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textDesconto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textDesconto_KeyPress);
            // 
            // lbltroco
            // 
            this.lbltroco.AutoSize = true;
            this.lbltroco.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltroco.Location = new System.Drawing.Point(83, 299);
            this.lbltroco.Name = "lbltroco";
            this.lbltroco.Size = new System.Drawing.Size(129, 46);
            this.lbltroco.TabIndex = 32;
            this.lbltroco.Text = "Troco";
            // 
            // lbldinheiro
            // 
            this.lbldinheiro.AutoSize = true;
            this.lbldinheiro.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldinheiro.Location = new System.Drawing.Point(38, 126);
            this.lbldinheiro.Name = "lbldinheiro";
            this.lbldinheiro.Size = new System.Drawing.Size(177, 46);
            this.lbldinheiro.TabIndex = 31;
            this.lbldinheiro.Text = "Dinheiro";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(87, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 46);
            this.label2.TabIndex = 30;
            this.label2.Text = "Total ";
            // 
            // textroco
            // 
            this.textroco.Font = new System.Drawing.Font("Calibri", 30F, System.Drawing.FontStyle.Bold);
            this.textroco.Location = new System.Drawing.Point(239, 292);
            this.textroco.Name = "textroco";
            this.textroco.ReadOnly = true;
            this.textroco.Size = new System.Drawing.Size(169, 56);
            this.textroco.TabIndex = 29;
            this.textroco.Text = "0,00";
            this.textroco.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textTotal
            // 
            this.textTotal.Font = new System.Drawing.Font("Calibri", 30F, System.Drawing.FontStyle.Bold);
            this.textTotal.Location = new System.Drawing.Point(239, 44);
            this.textTotal.Name = "textTotal";
            this.textTotal.ReadOnly = true;
            this.textTotal.Size = new System.Drawing.Size(169, 56);
            this.textTotal.TabIndex = 28;
            this.textTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnConfirma
            // 
            this.btnConfirma.BackColor = System.Drawing.Color.ForestGreen;
            this.btnConfirma.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirma.ForeColor = System.Drawing.Color.White;
            this.btnConfirma.Location = new System.Drawing.Point(64, 388);
            this.btnConfirma.Name = "btnConfirma";
            this.btnConfirma.Size = new System.Drawing.Size(169, 39);
            this.btnConfirma.TabIndex = 37;
            this.btnConfirma.Text = "Confirma";
            this.btnConfirma.UseVisualStyleBackColor = false;
            this.btnConfirma.Click += new System.EventHandler(this.btnConfirma_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Red;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(239, 388);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(169, 39);
            this.button2.TabIndex = 38;
            this.button2.Text = "Cancela";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // FrmTroco
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(481, 452);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnConfirma);
            this.Controls.Add(this.texdinheiro);
            this.Controls.Add(this.lblDesconto);
            this.Controls.Add(this.textDesconto);
            this.Controls.Add(this.lbltroco);
            this.Controls.Add(this.lbldinheiro);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textroco);
            this.Controls.Add(this.textTotal);
            this.KeyPreview = true;
            this.Location = new System.Drawing.Point(100, 100);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmTroco";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Troco";
            this.Load += new System.EventHandler(this.FrmTroco_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmTroco_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox texdinheiro;
        private System.Windows.Forms.Label lblDesconto;
        private System.Windows.Forms.TextBox textDesconto;
        private System.Windows.Forms.Label lbltroco;
        private System.Windows.Forms.Label lbldinheiro;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textroco;
        private System.Windows.Forms.TextBox textTotal;
        private System.Windows.Forms.Button btnConfirma;
        private System.Windows.Forms.Button button2;
    }
}