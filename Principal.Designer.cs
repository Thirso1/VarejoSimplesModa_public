namespace VarejoSimplesModa
{
    partial class Principal
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.empresaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.relatóriosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.crediarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuáriosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastrarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.produtosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastrarToolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.consultarToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.estoquesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.etiquetasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.relatóriosToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pedidoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.novoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.consultarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.localDeEstoqueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itensRápidosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.códigoBarrasBalançaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportarParaBalançaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vendasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.novaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.suspensasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultarToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.relatóriosToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.caixaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fecharToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.retiradaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.suprimentoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button2 = new System.Windows.Forms.Button();
            this.btnRetirada = new System.Windows.Forms.Button();
            this.btnCrediario = new System.Windows.Forms.Button();
            this.btnTeste = new System.Windows.Forms.Button();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.iconPictureBox12 = new FontAwesome.Sharp.IconPictureBox();
            this.iconPictureBox4 = new FontAwesome.Sharp.IconPictureBox();
            this.iconPictureBox10 = new FontAwesome.Sharp.IconPictureBox();
            this.iconPictureBox6 = new FontAwesome.Sharp.IconPictureBox();
            this.iconPictureBox5 = new FontAwesome.Sharp.IconPictureBox();
            this.iconPictureBox2 = new FontAwesome.Sharp.IconPictureBox();
            this.iconPictureBox3 = new FontAwesome.Sharp.IconPictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.PaleTurquoise;
            this.button1.Location = new System.Drawing.Point(343, 175);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(173, 131);
            this.button1.TabIndex = 0;
            this.button1.Text = "PDV";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.btnPdv_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.empresaToolStripMenuItem,
            this.clienteToolStripMenuItem,
            this.usuáriosToolStripMenuItem,
            this.produtosToolStripMenuItem,
            this.vendasToolStripMenuItem,
            this.caixaToolStripMenuItem,
            this.sairToolStripMenuItem});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(6, 2, 5, 2);
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size(146, 558);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // empresaToolStripMenuItem
            // 
            this.empresaToolStripMenuItem.ForeColor = System.Drawing.Color.PaleTurquoise;
            this.empresaToolStripMenuItem.Margin = new System.Windows.Forms.Padding(50, 150, 0, 0);
            this.empresaToolStripMenuItem.Name = "empresaToolStripMenuItem";
            this.empresaToolStripMenuItem.Size = new System.Drawing.Size(73, 25);
            this.empresaToolStripMenuItem.Text = "Empresa";
            this.empresaToolStripMenuItem.Click += new System.EventHandler(this.empresaToolStripMenuItem_Click);
            // 
            // clienteToolStripMenuItem
            // 
            this.clienteToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.clienteToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastrarToolStripMenuItem,
            this.consultarToolStripMenuItem,
            this.relatóriosToolStripMenuItem,
            this.crediarioToolStripMenuItem});
            this.clienteToolStripMenuItem.ForeColor = System.Drawing.Color.PaleTurquoise;
            this.clienteToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Gray;
            this.clienteToolStripMenuItem.Margin = new System.Windows.Forms.Padding(50, 10, 0, 0);
            this.clienteToolStripMenuItem.Name = "clienteToolStripMenuItem";
            this.clienteToolStripMenuItem.Padding = new System.Windows.Forms.Padding(4, 20, 4, 0);
            this.clienteToolStripMenuItem.Size = new System.Drawing.Size(73, 45);
            this.clienteToolStripMenuItem.Text = "Clientes";
            this.clienteToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cadastrarToolStripMenuItem
            // 
            this.cadastrarToolStripMenuItem.BackColor = System.Drawing.Color.Yellow;
            this.cadastrarToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.cadastrarToolStripMenuItem.Name = "cadastrarToolStripMenuItem";
            this.cadastrarToolStripMenuItem.Size = new System.Drawing.Size(150, 26);
            this.cadastrarToolStripMenuItem.Text = "Cadastrar";
            this.cadastrarToolStripMenuItem.Click += new System.EventHandler(this.cadastrarToolStripMenuItem_Click);
            // 
            // consultarToolStripMenuItem
            // 
            this.consultarToolStripMenuItem.BackColor = System.Drawing.Color.Yellow;
            this.consultarToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.consultarToolStripMenuItem.Name = "consultarToolStripMenuItem";
            this.consultarToolStripMenuItem.Size = new System.Drawing.Size(150, 26);
            this.consultarToolStripMenuItem.Text = "Consultar";
            // 
            // relatóriosToolStripMenuItem
            // 
            this.relatóriosToolStripMenuItem.BackColor = System.Drawing.Color.Yellow;
            this.relatóriosToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.relatóriosToolStripMenuItem.Name = "relatóriosToolStripMenuItem";
            this.relatóriosToolStripMenuItem.Size = new System.Drawing.Size(150, 26);
            this.relatóriosToolStripMenuItem.Text = "Relatórios";
            // 
            // crediarioToolStripMenuItem
            // 
            this.crediarioToolStripMenuItem.Name = "crediarioToolStripMenuItem";
            this.crediarioToolStripMenuItem.Size = new System.Drawing.Size(150, 26);
            this.crediarioToolStripMenuItem.Text = "Crediario";
            this.crediarioToolStripMenuItem.Click += new System.EventHandler(this.crediarioToolStripMenuItem_Click);
            // 
            // usuáriosToolStripMenuItem
            // 
            this.usuáriosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastrarToolStripMenuItem1});
            this.usuáriosToolStripMenuItem.ForeColor = System.Drawing.Color.PaleTurquoise;
            this.usuáriosToolStripMenuItem.Margin = new System.Windows.Forms.Padding(50, 0, 0, 0);
            this.usuáriosToolStripMenuItem.Name = "usuáriosToolStripMenuItem";
            this.usuáriosToolStripMenuItem.Padding = new System.Windows.Forms.Padding(4, 20, 4, 0);
            this.usuáriosToolStripMenuItem.Size = new System.Drawing.Size(73, 45);
            this.usuáriosToolStripMenuItem.Text = "Usuários";
            this.usuáriosToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cadastrarToolStripMenuItem1
            // 
            this.cadastrarToolStripMenuItem1.Name = "cadastrarToolStripMenuItem1";
            this.cadastrarToolStripMenuItem1.Size = new System.Drawing.Size(147, 26);
            this.cadastrarToolStripMenuItem1.Text = "Cadastrar";
            this.cadastrarToolStripMenuItem1.Click += new System.EventHandler(this.cadastrarToolStripMenuItem1_Click);
            // 
            // produtosToolStripMenuItem
            // 
            this.produtosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastrarToolStripMenuItem4,
            this.consultarToolStripMenuItem2,
            this.estoquesToolStripMenuItem,
            this.relatóriosToolStripMenuItem1,
            this.pedidoToolStripMenuItem,
            this.localDeEstoqueToolStripMenuItem,
            this.itensRápidosToolStripMenuItem,
            this.códigoBarrasBalançaToolStripMenuItem,
            this.exportarParaBalançaToolStripMenuItem,
            this.backupToolStripMenuItem});
            this.produtosToolStripMenuItem.ForeColor = System.Drawing.Color.PaleTurquoise;
            this.produtosToolStripMenuItem.Margin = new System.Windows.Forms.Padding(50, 0, 0, 0);
            this.produtosToolStripMenuItem.Name = "produtosToolStripMenuItem";
            this.produtosToolStripMenuItem.Padding = new System.Windows.Forms.Padding(4, 20, 4, 0);
            this.produtosToolStripMenuItem.Size = new System.Drawing.Size(73, 45);
            this.produtosToolStripMenuItem.Text = "Produtos";
            this.produtosToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cadastrarToolStripMenuItem4
            // 
            this.cadastrarToolStripMenuItem4.Name = "cadastrarToolStripMenuItem4";
            this.cadastrarToolStripMenuItem4.Size = new System.Drawing.Size(258, 26);
            this.cadastrarToolStripMenuItem4.Text = "Cadastrar ";
            this.cadastrarToolStripMenuItem4.Click += new System.EventHandler(this.cadastrarToolStripMenuItem4_Click);
            // 
            // consultarToolStripMenuItem2
            // 
            this.consultarToolStripMenuItem2.Name = "consultarToolStripMenuItem2";
            this.consultarToolStripMenuItem2.Size = new System.Drawing.Size(258, 26);
            this.consultarToolStripMenuItem2.Text = "Consultar";
            this.consultarToolStripMenuItem2.Click += new System.EventHandler(this.consultarToolStripMenuItem2_Click);
            // 
            // estoquesToolStripMenuItem
            // 
            this.estoquesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.etiquetasToolStripMenuItem});
            this.estoquesToolStripMenuItem.Name = "estoquesToolStripMenuItem";
            this.estoquesToolStripMenuItem.Size = new System.Drawing.Size(258, 26);
            this.estoquesToolStripMenuItem.Text = "Estoques";
            // 
            // etiquetasToolStripMenuItem
            // 
            this.etiquetasToolStripMenuItem.Name = "etiquetasToolStripMenuItem";
            this.etiquetasToolStripMenuItem.Size = new System.Drawing.Size(143, 26);
            this.etiquetasToolStripMenuItem.Text = "Etiquetas";
            // 
            // relatóriosToolStripMenuItem1
            // 
            this.relatóriosToolStripMenuItem1.Name = "relatóriosToolStripMenuItem1";
            this.relatóriosToolStripMenuItem1.Size = new System.Drawing.Size(258, 26);
            this.relatóriosToolStripMenuItem1.Text = "Relatórios";
            // 
            // pedidoToolStripMenuItem
            // 
            this.pedidoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.novoToolStripMenuItem1,
            this.consultarToolStripMenuItem1});
            this.pedidoToolStripMenuItem.Name = "pedidoToolStripMenuItem";
            this.pedidoToolStripMenuItem.Size = new System.Drawing.Size(258, 26);
            this.pedidoToolStripMenuItem.Text = "Pedido";
            // 
            // novoToolStripMenuItem1
            // 
            this.novoToolStripMenuItem1.Name = "novoToolStripMenuItem1";
            this.novoToolStripMenuItem1.Size = new System.Drawing.Size(147, 26);
            this.novoToolStripMenuItem1.Text = "Novo";
            // 
            // consultarToolStripMenuItem1
            // 
            this.consultarToolStripMenuItem1.Name = "consultarToolStripMenuItem1";
            this.consultarToolStripMenuItem1.Size = new System.Drawing.Size(147, 26);
            this.consultarToolStripMenuItem1.Text = "Consultar";
            // 
            // localDeEstoqueToolStripMenuItem
            // 
            this.localDeEstoqueToolStripMenuItem.Name = "localDeEstoqueToolStripMenuItem";
            this.localDeEstoqueToolStripMenuItem.Size = new System.Drawing.Size(258, 26);
            this.localDeEstoqueToolStripMenuItem.Text = "Local de Estoque";
            // 
            // itensRápidosToolStripMenuItem
            // 
            this.itensRápidosToolStripMenuItem.Name = "itensRápidosToolStripMenuItem";
            this.itensRápidosToolStripMenuItem.Size = new System.Drawing.Size(258, 26);
            this.itensRápidosToolStripMenuItem.Text = "Itens Rápidos";
            this.itensRápidosToolStripMenuItem.Click += new System.EventHandler(this.itensRápidosToolStripMenuItem_Click);
            // 
            // códigoBarrasBalançaToolStripMenuItem
            // 
            this.códigoBarrasBalançaToolStripMenuItem.Name = "códigoBarrasBalançaToolStripMenuItem";
            this.códigoBarrasBalançaToolStripMenuItem.Size = new System.Drawing.Size(258, 26);
            this.códigoBarrasBalançaToolStripMenuItem.Text = "Consultar Código Balança";
            this.códigoBarrasBalançaToolStripMenuItem.Click += new System.EventHandler(this.códigoBarrasBalançaToolStripMenuItem_Click);
            // 
            // exportarParaBalançaToolStripMenuItem
            // 
            this.exportarParaBalançaToolStripMenuItem.Name = "exportarParaBalançaToolStripMenuItem";
            this.exportarParaBalançaToolStripMenuItem.Size = new System.Drawing.Size(258, 26);
            this.exportarParaBalançaToolStripMenuItem.Text = "Exportar Para Balança";
            this.exportarParaBalançaToolStripMenuItem.Click += new System.EventHandler(this.exportarParaBalançaToolStripMenuItem_Click);
            // 
            // backupToolStripMenuItem
            // 
            this.backupToolStripMenuItem.Name = "backupToolStripMenuItem";
            this.backupToolStripMenuItem.Size = new System.Drawing.Size(258, 26);
            this.backupToolStripMenuItem.Text = "Backup";
            this.backupToolStripMenuItem.Click += new System.EventHandler(this.backupToolStripMenuItem_Click);
            // 
            // vendasToolStripMenuItem
            // 
            this.vendasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.novaToolStripMenuItem,
            this.suspensasToolStripMenuItem,
            this.consultarToolStripMenuItem3,
            this.relatóriosToolStripMenuItem3});
            this.vendasToolStripMenuItem.ForeColor = System.Drawing.Color.PaleTurquoise;
            this.vendasToolStripMenuItem.Margin = new System.Windows.Forms.Padding(50, 0, 0, 0);
            this.vendasToolStripMenuItem.Name = "vendasToolStripMenuItem";
            this.vendasToolStripMenuItem.Padding = new System.Windows.Forms.Padding(4, 20, 4, 0);
            this.vendasToolStripMenuItem.Size = new System.Drawing.Size(73, 45);
            this.vendasToolStripMenuItem.Text = "Vendas";
            this.vendasToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // novaToolStripMenuItem
            // 
            this.novaToolStripMenuItem.Name = "novaToolStripMenuItem";
            this.novaToolStripMenuItem.Size = new System.Drawing.Size(153, 26);
            this.novaToolStripMenuItem.Text = "PDV";
            this.novaToolStripMenuItem.Click += new System.EventHandler(this.novaToolStripMenuItem_Click);
            // 
            // suspensasToolStripMenuItem
            // 
            this.suspensasToolStripMenuItem.Name = "suspensasToolStripMenuItem";
            this.suspensasToolStripMenuItem.Size = new System.Drawing.Size(153, 26);
            this.suspensasToolStripMenuItem.Text = "Suspensas";
            // 
            // consultarToolStripMenuItem3
            // 
            this.consultarToolStripMenuItem3.Name = "consultarToolStripMenuItem3";
            this.consultarToolStripMenuItem3.Size = new System.Drawing.Size(153, 26);
            this.consultarToolStripMenuItem3.Text = "Consultar";
            // 
            // relatóriosToolStripMenuItem3
            // 
            this.relatóriosToolStripMenuItem3.Name = "relatóriosToolStripMenuItem3";
            this.relatóriosToolStripMenuItem3.Size = new System.Drawing.Size(153, 26);
            this.relatóriosToolStripMenuItem3.Text = "Relatórios";
            this.relatóriosToolStripMenuItem3.Click += new System.EventHandler(this.relatóriosToolStripMenuItem3_Click);
            // 
            // caixaToolStripMenuItem
            // 
            this.caixaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusToolStripMenuItem,
            this.abrirToolStripMenuItem,
            this.fecharToolStripMenuItem,
            this.retiradaToolStripMenuItem,
            this.suprimentoToolStripMenuItem});
            this.caixaToolStripMenuItem.ForeColor = System.Drawing.Color.PaleTurquoise;
            this.caixaToolStripMenuItem.Margin = new System.Windows.Forms.Padding(50, 0, 0, 0);
            this.caixaToolStripMenuItem.Name = "caixaToolStripMenuItem";
            this.caixaToolStripMenuItem.Padding = new System.Windows.Forms.Padding(4, 20, 4, 0);
            this.caixaToolStripMenuItem.Size = new System.Drawing.Size(73, 45);
            this.caixaToolStripMenuItem.Text = "Caixa";
            this.caixaToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // statusToolStripMenuItem
            // 
            this.statusToolStripMenuItem.Name = "statusToolStripMenuItem";
            this.statusToolStripMenuItem.Size = new System.Drawing.Size(162, 26);
            this.statusToolStripMenuItem.Text = "Status";
            this.statusToolStripMenuItem.Click += new System.EventHandler(this.statusToolStripMenuItem_Click);
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(162, 26);
            this.abrirToolStripMenuItem.Text = "Abrir";
            this.abrirToolStripMenuItem.Click += new System.EventHandler(this.abrirToolStripMenuItem_Click);
            // 
            // fecharToolStripMenuItem
            // 
            this.fecharToolStripMenuItem.Name = "fecharToolStripMenuItem";
            this.fecharToolStripMenuItem.Size = new System.Drawing.Size(162, 26);
            this.fecharToolStripMenuItem.Text = "Fechar";
            this.fecharToolStripMenuItem.Click += new System.EventHandler(this.fecharToolStripMenuItem_Click);
            // 
            // retiradaToolStripMenuItem
            // 
            this.retiradaToolStripMenuItem.Name = "retiradaToolStripMenuItem";
            this.retiradaToolStripMenuItem.Size = new System.Drawing.Size(162, 26);
            this.retiradaToolStripMenuItem.Text = "Retirada";
            this.retiradaToolStripMenuItem.Click += new System.EventHandler(this.retiradaToolStripMenuItem_Click);
            // 
            // suprimentoToolStripMenuItem
            // 
            this.suprimentoToolStripMenuItem.Name = "suprimentoToolStripMenuItem";
            this.suprimentoToolStripMenuItem.Size = new System.Drawing.Size(162, 26);
            this.suprimentoToolStripMenuItem.Text = "Suprimento";
            this.suprimentoToolStripMenuItem.Click += new System.EventHandler(this.suprimentoToolStripMenuItem_Click);
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.ForeColor = System.Drawing.Color.PaleTurquoise;
            this.sairToolStripMenuItem.Margin = new System.Windows.Forms.Padding(50, 0, 0, 0);
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            this.sairToolStripMenuItem.Padding = new System.Windows.Forms.Padding(4, 20, 4, 0);
            this.sairToolStripMenuItem.Size = new System.Drawing.Size(73, 45);
            this.sairToolStripMenuItem.Text = "Sair";
            this.sairToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.PaleTurquoise;
            this.button2.Location = new System.Drawing.Point(522, 175);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(173, 131);
            this.button2.TabIndex = 43;
            this.button2.Text = "Status";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnRetirada
            // 
            this.btnRetirada.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnRetirada.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRetirada.ForeColor = System.Drawing.Color.PaleTurquoise;
            this.btnRetirada.Location = new System.Drawing.Point(343, 312);
            this.btnRetirada.Name = "btnRetirada";
            this.btnRetirada.Size = new System.Drawing.Size(173, 131);
            this.btnRetirada.TabIndex = 44;
            this.btnRetirada.Text = "Retirada";
            this.btnRetirada.UseVisualStyleBackColor = false;
            this.btnRetirada.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnCrediario
            // 
            this.btnCrediario.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnCrediario.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrediario.ForeColor = System.Drawing.Color.PaleTurquoise;
            this.btnCrediario.Location = new System.Drawing.Point(522, 312);
            this.btnCrediario.Name = "btnCrediario";
            this.btnCrediario.Size = new System.Drawing.Size(173, 131);
            this.btnCrediario.TabIndex = 45;
            this.btnCrediario.Text = "Crediario";
            this.btnCrediario.UseVisualStyleBackColor = false;
            this.btnCrediario.Click += new System.EventHandler(this.btnCrediario_Click);
            // 
            // btnTeste
            // 
            this.btnTeste.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTeste.Location = new System.Drawing.Point(701, 312);
            this.btnTeste.Name = "btnTeste";
            this.btnTeste.Size = new System.Drawing.Size(173, 131);
            this.btnTeste.TabIndex = 46;
            this.btnTeste.Text = "Código Barras Balança";
            this.btnTeste.UseVisualStyleBackColor = true;
            this.btnTeste.Click += new System.EventHandler(this.btnTeste_Click);
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.ForeColor = System.Drawing.Color.Orange;
            this.lblUsuario.Location = new System.Drawing.Point(57, 41);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(64, 20);
            this.lblUsuario.TabIndex = 48;
            this.lblUsuario.Text = "Usuário";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.PaleTurquoise;
            this.button3.Location = new System.Drawing.Point(701, 175);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(173, 131);
            this.button3.TabIndex = 50;
            this.button3.Text = "Cadastro Produtos";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // iconPictureBox12
            // 
            this.iconPictureBox12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.iconPictureBox12.ForeColor = System.Drawing.Color.PaleTurquoise;
            this.iconPictureBox12.IconChar = FontAwesome.Sharp.IconChar.UsersCog;
            this.iconPictureBox12.IconColor = System.Drawing.Color.PaleTurquoise;
            this.iconPictureBox12.IconSize = 24;
            this.iconPictureBox12.Location = new System.Drawing.Point(31, 245);
            this.iconPictureBox12.Name = "iconPictureBox12";
            this.iconPictureBox12.Size = new System.Drawing.Size(24, 24);
            this.iconPictureBox12.TabIndex = 56;
            this.iconPictureBox12.TabStop = false;
            // 
            // iconPictureBox4
            // 
            this.iconPictureBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.iconPictureBox4.ForeColor = System.Drawing.Color.PaleTurquoise;
            this.iconPictureBox4.IconChar = FontAwesome.Sharp.IconChar.CashRegister;
            this.iconPictureBox4.IconColor = System.Drawing.Color.PaleTurquoise;
            this.iconPictureBox4.IconSize = 24;
            this.iconPictureBox4.Location = new System.Drawing.Point(31, 380);
            this.iconPictureBox4.Name = "iconPictureBox4";
            this.iconPictureBox4.Size = new System.Drawing.Size(24, 24);
            this.iconPictureBox4.TabIndex = 53;
            this.iconPictureBox4.TabStop = false;
            // 
            // iconPictureBox10
            // 
            this.iconPictureBox10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.iconPictureBox10.ForeColor = System.Drawing.Color.PaleTurquoise;
            this.iconPictureBox10.IconChar = FontAwesome.Sharp.IconChar.ShoppingCart;
            this.iconPictureBox10.IconColor = System.Drawing.Color.PaleTurquoise;
            this.iconPictureBox10.IconSize = 24;
            this.iconPictureBox10.Location = new System.Drawing.Point(31, 334);
            this.iconPictureBox10.Name = "iconPictureBox10";
            this.iconPictureBox10.Size = new System.Drawing.Size(24, 24);
            this.iconPictureBox10.TabIndex = 51;
            this.iconPictureBox10.TabStop = false;
            // 
            // iconPictureBox6
            // 
            this.iconPictureBox6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.iconPictureBox6.ForeColor = System.Drawing.Color.PaleTurquoise;
            this.iconPictureBox6.IconChar = FontAwesome.Sharp.IconChar.Barcode;
            this.iconPictureBox6.IconColor = System.Drawing.Color.PaleTurquoise;
            this.iconPictureBox6.IconSize = 24;
            this.iconPictureBox6.Location = new System.Drawing.Point(31, 291);
            this.iconPictureBox6.Name = "iconPictureBox6";
            this.iconPictureBox6.Size = new System.Drawing.Size(24, 24);
            this.iconPictureBox6.TabIndex = 55;
            this.iconPictureBox6.TabStop = false;
            // 
            // iconPictureBox5
            // 
            this.iconPictureBox5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.iconPictureBox5.ForeColor = System.Drawing.Color.PaleTurquoise;
            this.iconPictureBox5.IconChar = FontAwesome.Sharp.IconChar.UserFriends;
            this.iconPictureBox5.IconColor = System.Drawing.Color.PaleTurquoise;
            this.iconPictureBox5.IconSize = 24;
            this.iconPictureBox5.Location = new System.Drawing.Point(31, 199);
            this.iconPictureBox5.Name = "iconPictureBox5";
            this.iconPictureBox5.Size = new System.Drawing.Size(24, 24);
            this.iconPictureBox5.TabIndex = 54;
            this.iconPictureBox5.TabStop = false;
            // 
            // iconPictureBox2
            // 
            this.iconPictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.iconPictureBox2.ForeColor = System.Drawing.Color.PaleTurquoise;
            this.iconPictureBox2.IconChar = FontAwesome.Sharp.IconChar.PowerOff;
            this.iconPictureBox2.IconColor = System.Drawing.Color.PaleTurquoise;
            this.iconPictureBox2.IconSize = 24;
            this.iconPictureBox2.Location = new System.Drawing.Point(31, 427);
            this.iconPictureBox2.Name = "iconPictureBox2";
            this.iconPictureBox2.Size = new System.Drawing.Size(24, 24);
            this.iconPictureBox2.TabIndex = 52;
            this.iconPictureBox2.TabStop = false;
            // 
            // iconPictureBox3
            // 
            this.iconPictureBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.iconPictureBox3.ForeColor = System.Drawing.Color.PaleTurquoise;
            this.iconPictureBox3.IconChar = FontAwesome.Sharp.IconChar.Store;
            this.iconPictureBox3.IconColor = System.Drawing.Color.PaleTurquoise;
            this.iconPictureBox3.IconSize = 24;
            this.iconPictureBox3.Location = new System.Drawing.Point(31, 153);
            this.iconPictureBox3.Name = "iconPictureBox3";
            this.iconPictureBox3.Size = new System.Drawing.Size(24, 24);
            this.iconPictureBox3.TabIndex = 58;
            this.iconPictureBox3.TabStop = false;
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(971, 558);
            this.Controls.Add(this.iconPictureBox3);
            this.Controls.Add(this.iconPictureBox12);
            this.Controls.Add(this.iconPictureBox4);
            this.Controls.Add(this.iconPictureBox10);
            this.Controls.Add(this.iconPictureBox6);
            this.Controls.Add(this.iconPictureBox5);
            this.Controls.Add(this.iconPictureBox2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.btnTeste);
            this.Controls.Add(this.btnCrediario);
            this.Controls.Add(this.btnRetirada);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.button1);
            this.Name = "Principal";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem clienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cadastrarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem relatóriosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem crediarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuáriosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem produtosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cadastrarToolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem consultarToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem estoquesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem etiquetasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem relatóriosToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem pedidoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem novoToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem consultarToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem localDeEstoqueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vendasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem novaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem suspensasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultarToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem relatóriosToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem caixaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem statusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fecharToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem retiradaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem suprimentoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnRetirada;
        private System.Windows.Forms.ToolStripMenuItem cadastrarToolStripMenuItem1;
        private System.Windows.Forms.Button btnCrediario;
        private System.Windows.Forms.Button btnTeste;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ToolStripMenuItem itensRápidosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem códigoBarrasBalançaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportarParaBalançaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backupToolStripMenuItem;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox12;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox4;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox10;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox6;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox5;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox2;
        private System.Windows.Forms.ToolStripMenuItem empresaToolStripMenuItem;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox3;
    }
}


