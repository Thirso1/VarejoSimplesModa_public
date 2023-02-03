namespace VarejoSimplesModa.View
{
    partial class FrmSuprimento
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
            this.button1 = new System.Windows.Forms.Button();
            this.btnConfirma = new System.Windows.Forms.Button();
            this.textValor = new System.Windows.Forms.TextBox();
            this.lblValor = new System.Windows.Forms.Label();
            this.lblretirada = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(249, 206);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(144, 35);
            this.button1.TabIndex = 22;
            this.button1.Text = "Cancelar";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // btnConfirma
            // 
            this.btnConfirma.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnConfirma.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirma.ForeColor = System.Drawing.Color.White;
            this.btnConfirma.Location = new System.Drawing.Point(99, 206);
            this.btnConfirma.Name = "btnConfirma";
            this.btnConfirma.Size = new System.Drawing.Size(144, 35);
            this.btnConfirma.TabIndex = 21;
            this.btnConfirma.Text = "Confirmar";
            this.btnConfirma.UseVisualStyleBackColor = false;
            this.btnConfirma.Click += new System.EventHandler(this.btnConfirma_Click);
            // 
            // textValor
            // 
            this.textValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textValor.Location = new System.Drawing.Point(237, 109);
            this.textValor.Name = "textValor";
            this.textValor.Size = new System.Drawing.Size(130, 30);
            this.textValor.TabIndex = 20;
            this.textValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textValor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textValor_KeyPress);
            this.textValor.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textValRetirada_KeyUp);
            // 
            // lblValor
            // 
            this.lblValor.AutoSize = true;
            this.lblValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValor.ForeColor = System.Drawing.Color.Navy;
            this.lblValor.Location = new System.Drawing.Point(133, 109);
            this.lblValor.Name = "lblValor";
            this.lblValor.Size = new System.Drawing.Size(98, 29);
            this.lblValor.TabIndex = 19;
            this.lblValor.Text = "VALOR:";
            // 
            // lblretirada
            // 
            this.lblretirada.AutoSize = true;
            this.lblretirada.Font = new System.Drawing.Font("Arial Rounded MT Bold", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblretirada.ForeColor = System.Drawing.Color.Navy;
            this.lblretirada.Location = new System.Drawing.Point(101, 9);
            this.lblretirada.Name = "lblretirada";
            this.lblretirada.Size = new System.Drawing.Size(292, 37);
            this.lblretirada.TabIndex = 23;
            this.lblretirada.Text = "Suprimento Caixa";
            // 
            // FrmSuprimento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 304);
            this.Controls.Add(this.lblretirada);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnConfirma);
            this.Controls.Add(this.textValor);
            this.Controls.Add(this.lblValor);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSuprimento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Suprimento Caixa";
            this.Load += new System.EventHandler(this.FrmSuprimento_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnConfirma;
        private System.Windows.Forms.TextBox textValor;
        private System.Windows.Forms.Label lblValor;
        private System.Windows.Forms.Label lblretirada;
    }
}