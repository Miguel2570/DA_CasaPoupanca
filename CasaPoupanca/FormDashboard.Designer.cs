namespace CasaPoupanca
{
    partial class FormDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDashboard));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ficheiroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.converterEmCSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comprasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.estatisticasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tiposDeArtigoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.artigosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.utilizadoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modoCompraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelOrcamento = new System.Windows.Forms.Label();
            this.labelTotalGasto = new System.Windows.Forms.Label();
            this.labelDisponivel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonNovaCompra = new System.Windows.Forms.Button();
            this.buttonContinuarCompra = new System.Windows.Forms.Button();
            this.buttonEstatisticas = new System.Windows.Forms.Button();
            this.dataGridViewCompras = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataAlteracao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataCriacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsFechada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelPerfil = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.buttonSair = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCompras)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ficheiroToolStripMenuItem,
            this.comprasToolStripMenuItem,
            this.estatisticasToolStripMenuItem,
            this.oToolStripMenuItem,
            this.tiposDeArtigoToolStripMenuItem,
            this.artigosToolStripMenuItem,
            this.utilizadoresToolStripMenuItem,
            this.modoCompraToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1123, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ficheiroToolStripMenuItem
            // 
            this.ficheiroToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sairToolStripMenuItem,
            this.converterEmCSVToolStripMenuItem});
            this.ficheiroToolStripMenuItem.Name = "ficheiroToolStripMenuItem";
            this.ficheiroToolStripMenuItem.Size = new System.Drawing.Size(89, 29);
            this.ficheiroToolStripMenuItem.Text = "Ficheiro";
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            this.sairToolStripMenuItem.Size = new System.Drawing.Size(258, 34);
            this.sairToolStripMenuItem.Text = "Sair";
            this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
            // 
            // converterEmCSVToolStripMenuItem
            // 
            this.converterEmCSVToolStripMenuItem.Name = "converterEmCSVToolStripMenuItem";
            this.converterEmCSVToolStripMenuItem.Size = new System.Drawing.Size(258, 34);
            this.converterEmCSVToolStripMenuItem.Text = "Converter em CSV";
            // 
            // comprasToolStripMenuItem
            // 
            this.comprasToolStripMenuItem.Name = "comprasToolStripMenuItem";
            this.comprasToolStripMenuItem.Size = new System.Drawing.Size(100, 29);
            this.comprasToolStripMenuItem.Text = "Compras";
            this.comprasToolStripMenuItem.Click += new System.EventHandler(this.comprasToolStripMenuItem_Click);
            // 
            // estatisticasToolStripMenuItem
            // 
            this.estatisticasToolStripMenuItem.Name = "estatisticasToolStripMenuItem";
            this.estatisticasToolStripMenuItem.Size = new System.Drawing.Size(113, 29);
            this.estatisticasToolStripMenuItem.Text = "Estatisticas";
            this.estatisticasToolStripMenuItem.Click += new System.EventHandler(this.estisticasToolStripMenuItem_Click);
            // 
            // oToolStripMenuItem
            // 
            this.oToolStripMenuItem.Name = "oToolStripMenuItem";
            this.oToolStripMenuItem.Size = new System.Drawing.Size(117, 29);
            this.oToolStripMenuItem.Text = "Orçamento";
            this.oToolStripMenuItem.Click += new System.EventHandler(this.OrcamentoToolStripMenuItem_Click);
            // 
            // tiposDeArtigoToolStripMenuItem
            // 
            this.tiposDeArtigoToolStripMenuItem.Name = "tiposDeArtigoToolStripMenuItem";
            this.tiposDeArtigoToolStripMenuItem.Size = new System.Drawing.Size(151, 29);
            this.tiposDeArtigoToolStripMenuItem.Text = "Tipos de Artigo";
            this.tiposDeArtigoToolStripMenuItem.Click += new System.EventHandler(this.tiposDeArtigoToolStripMenuItem_Click);
            // 
            // artigosToolStripMenuItem
            // 
            this.artigosToolStripMenuItem.Name = "artigosToolStripMenuItem";
            this.artigosToolStripMenuItem.Size = new System.Drawing.Size(86, 29);
            this.artigosToolStripMenuItem.Text = "Artigos";
            this.artigosToolStripMenuItem.Click += new System.EventHandler(this.artigosToolStripMenuItem_Click);
            // 
            // utilizadoresToolStripMenuItem
            // 
            this.utilizadoresToolStripMenuItem.Name = "utilizadoresToolStripMenuItem";
            this.utilizadoresToolStripMenuItem.Size = new System.Drawing.Size(120, 29);
            this.utilizadoresToolStripMenuItem.Text = "Utilizadores";
            this.utilizadoresToolStripMenuItem.Click += new System.EventHandler(this.utilizadoresToolStripMenuItem_Click);
            // 
            // modoCompraToolStripMenuItem
            // 
            this.modoCompraToolStripMenuItem.Name = "modoCompraToolStripMenuItem";
            this.modoCompraToolStripMenuItem.Size = new System.Drawing.Size(146, 29);
            this.modoCompraToolStripMenuItem.Text = "Modo Compra";
            this.modoCompraToolStripMenuItem.Click += new System.EventHandler(this.modoCompraToolStripMenuItem_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(375, 172);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 29);
            this.label2.TabIndex = 2;
            this.label2.Text = "Orçamento:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(375, 212);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 29);
            this.label3.TabIndex = 3;
            this.label3.Text = "Total Gasto:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(375, 252);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(132, 29);
            this.label4.TabIndex = 4;
            this.label4.Text = "Disponivel:";
            // 
            // labelOrcamento
            // 
            this.labelOrcamento.AutoSize = true;
            this.labelOrcamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOrcamento.Location = new System.Drawing.Point(586, 175);
            this.labelOrcamento.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelOrcamento.Name = "labelOrcamento";
            this.labelOrcamento.Size = new System.Drawing.Size(50, 25);
            this.labelOrcamento.TabIndex = 5;
            this.labelOrcamento.Text = "0,00";
            // 
            // labelTotalGasto
            // 
            this.labelTotalGasto.AutoSize = true;
            this.labelTotalGasto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotalGasto.Location = new System.Drawing.Point(586, 257);
            this.labelTotalGasto.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTotalGasto.Name = "labelTotalGasto";
            this.labelTotalGasto.Size = new System.Drawing.Size(50, 25);
            this.labelTotalGasto.TabIndex = 6;
            this.labelTotalGasto.Text = "0,00";
            // 
            // labelDisponivel
            // 
            this.labelDisponivel.AutoSize = true;
            this.labelDisponivel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDisponivel.Location = new System.Drawing.Point(586, 215);
            this.labelDisponivel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDisponivel.Name = "labelDisponivel";
            this.labelDisponivel.Size = new System.Drawing.Size(50, 25);
            this.labelDisponivel.TabIndex = 7;
            this.labelDisponivel.Text = "0,00";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(21, 361);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(169, 22);
            this.label5.TabIndex = 8;
            this.label5.Text = "Compras em Aberto";
            // 
            // buttonNovaCompra
            // 
            this.buttonNovaCompra.Location = new System.Drawing.Point(939, 388);
            this.buttonNovaCompra.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonNovaCompra.Name = "buttonNovaCompra";
            this.buttonNovaCompra.Size = new System.Drawing.Size(168, 35);
            this.buttonNovaCompra.TabIndex = 9;
            this.buttonNovaCompra.Text = "Nova compra";
            this.buttonNovaCompra.UseVisualStyleBackColor = true;
            this.buttonNovaCompra.Click += new System.EventHandler(this.buttonNovaCompra_Click);
            // 
            // buttonContinuarCompra
            // 
            this.buttonContinuarCompra.Location = new System.Drawing.Point(939, 453);
            this.buttonContinuarCompra.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonContinuarCompra.Name = "buttonContinuarCompra";
            this.buttonContinuarCompra.Size = new System.Drawing.Size(168, 35);
            this.buttonContinuarCompra.TabIndex = 10;
            this.buttonContinuarCompra.Text = "Continuar a comprar";
            this.buttonContinuarCompra.UseVisualStyleBackColor = true;
            this.buttonContinuarCompra.Click += new System.EventHandler(this.buttonContinuarCompra_Click);
            // 
            // buttonEstatisticas
            // 
            this.buttonEstatisticas.Location = new System.Drawing.Point(939, 516);
            this.buttonEstatisticas.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonEstatisticas.Name = "buttonEstatisticas";
            this.buttonEstatisticas.Size = new System.Drawing.Size(168, 35);
            this.buttonEstatisticas.TabIndex = 11;
            this.buttonEstatisticas.Text = "Estatisticas";
            this.buttonEstatisticas.UseVisualStyleBackColor = true;
            this.buttonEstatisticas.Click += new System.EventHandler(this.buttonEstatisticas_Click);
            // 
            // dataGridViewCompras
            // 
            this.dataGridViewCompras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCompras.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.dataAlteracao,
            this.Nome,
            this.DataCriacao,
            this.IsFechada});
            this.dataGridViewCompras.Location = new System.Drawing.Point(25, 388);
            this.dataGridViewCompras.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridViewCompras.Name = "dataGridViewCompras";
            this.dataGridViewCompras.ReadOnly = true;
            this.dataGridViewCompras.RowHeadersWidth = 62;
            this.dataGridViewCompras.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewCompras.Size = new System.Drawing.Size(878, 231);
            this.dataGridViewCompras.TabIndex = 12;
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.MinimumWidth = 8;
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Width = 197;
            // 
            // dataAlteracao
            // 
            this.dataAlteracao.HeaderText = "Data de alteração";
            this.dataAlteracao.MinimumWidth = 8;
            this.dataAlteracao.Name = "dataAlteracao";
            this.dataAlteracao.ReadOnly = true;
            this.dataAlteracao.Width = 150;
            // 
            // Nome
            // 
            this.Nome.HeaderText = "Nome da Compra";
            this.Nome.MinimumWidth = 8;
            this.Nome.Name = "Nome";
            this.Nome.ReadOnly = true;
            this.Nome.Width = 150;
            // 
            // DataCriacao
            // 
            this.DataCriacao.HeaderText = "Data Criação";
            this.DataCriacao.MinimumWidth = 8;
            this.DataCriacao.Name = "DataCriacao";
            this.DataCriacao.ReadOnly = true;
            this.DataCriacao.Width = 150;
            // 
            // IsFechada
            // 
            this.IsFechada.HeaderText = "Estado";
            this.IsFechada.MinimumWidth = 8;
            this.IsFechada.Name = "IsFechada";
            this.IsFechada.ReadOnly = true;
            this.IsFechada.Width = 150;
            // 
            // labelPerfil
            // 
            this.labelPerfil.AutoSize = true;
            this.labelPerfil.Location = new System.Drawing.Point(900, 63);
            this.labelPerfil.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPerfil.Name = "labelPerfil";
            this.labelPerfil.Size = new System.Drawing.Size(87, 20);
            this.labelPerfil.TabIndex = 13;
            this.labelPerfil.Text = "Bem vindo,";
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "interface.png");
            this.imageList2.Images.SetKeyName(1, "interface.png");
            // 
            // buttonSair
            // 
            this.buttonSair.Location = new System.Drawing.Point(939, 570);
            this.buttonSair.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonSair.Name = "buttonSair";
            this.buttonSair.Size = new System.Drawing.Size(168, 35);
            this.buttonSair.TabIndex = 15;
            this.buttonSair.Text = "Sair";
            this.buttonSair.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(398, 122);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(216, 29);
            this.label6.TabIndex = 16;
            this.label6.Text = "Orçamento Mensal";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CasaPoupanca.Properties.Resources.final_removebg_preview;
            this.pictureBox1.Location = new System.Drawing.Point(12, 49);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(118, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // FormDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1123, 633);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.buttonSair);
            this.Controls.Add(this.labelPerfil);
            this.Controls.Add(this.dataGridViewCompras);
            this.Controls.Add(this.buttonEstatisticas);
            this.Controls.Add(this.buttonContinuarCompra);
            this.Controls.Add(this.buttonNovaCompra);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.labelDisponivel);
            this.Controls.Add(this.labelTotalGasto);
            this.Controls.Add(this.labelOrcamento);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.pictureBox1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormDashboard";
            this.Text = "Dashboard";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCompras)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ficheiroToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem comprasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem estatisticasToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelOrcamento;
        private System.Windows.Forms.Label labelTotalGasto;
        private System.Windows.Forms.Label labelDisponivel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonNovaCompra;
        private System.Windows.Forms.Button buttonContinuarCompra;
        private System.Windows.Forms.Button buttonEstatisticas;
        private System.Windows.Forms.DataGridView dataGridViewCompras;
        private System.Windows.Forms.Label labelPerfil;
        private System.Windows.Forms.ToolStripMenuItem oToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tiposDeArtigoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem artigosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem utilizadoresToolStripMenuItem;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonSair;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataAlteracao;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nome;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataCriacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsFechada;
        private System.Windows.Forms.ToolStripMenuItem converterEmCSVToolStripMenuItem;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ToolStripMenuItem modoCompraToolStripMenuItem;
    }
}