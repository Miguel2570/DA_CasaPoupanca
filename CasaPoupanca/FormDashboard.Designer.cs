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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ficheiroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comprasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.estatisticasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tiposDeArtigoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.artigosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.utilizadoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
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
            this.Nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataCriacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsFechada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelPerfil = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCompras)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ficheiroToolStripMenuItem,
            this.comprasToolStripMenuItem,
            this.estatisticasToolStripMenuItem,
            this.oToolStripMenuItem,
            this.tiposDeArtigoToolStripMenuItem,
            this.artigosToolStripMenuItem,
            this.utilizadoresToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ficheiroToolStripMenuItem
            // 
            this.ficheiroToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sairToolStripMenuItem});
            this.ficheiroToolStripMenuItem.Name = "ficheiroToolStripMenuItem";
            this.ficheiroToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.ficheiroToolStripMenuItem.Text = "Ficheiro";
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            this.sairToolStripMenuItem.Size = new System.Drawing.Size(93, 22);
            this.sairToolStripMenuItem.Text = "Sair";
            this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
            // 
            // comprasToolStripMenuItem
            // 
            this.comprasToolStripMenuItem.Name = "comprasToolStripMenuItem";
            this.comprasToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.comprasToolStripMenuItem.Text = "Compras";
            this.comprasToolStripMenuItem.Click += new System.EventHandler(this.comprasToolStripMenuItem_Click);
            // 
            // estatisticasToolStripMenuItem
            // 
            this.estatisticasToolStripMenuItem.Name = "estatisticasToolStripMenuItem";
            this.estatisticasToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.estatisticasToolStripMenuItem.Text = "Estatisticas";
            this.estatisticasToolStripMenuItem.Click += new System.EventHandler(this.estisticasToolStripMenuItem_Click);
            // 
            // oToolStripMenuItem
            // 
            this.oToolStripMenuItem.Name = "oToolStripMenuItem";
            this.oToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.oToolStripMenuItem.Text = "Orçamento";
            this.oToolStripMenuItem.Click += new System.EventHandler(this.OrcamentoToolStripMenuItem_Click);
            // 
            // tiposDeArtigoToolStripMenuItem
            // 
            this.tiposDeArtigoToolStripMenuItem.Name = "tiposDeArtigoToolStripMenuItem";
            this.tiposDeArtigoToolStripMenuItem.Size = new System.Drawing.Size(100, 20);
            this.tiposDeArtigoToolStripMenuItem.Text = "Tipos de Artigo";
            this.tiposDeArtigoToolStripMenuItem.Click += new System.EventHandler(this.tiposDeArtigoToolStripMenuItem_Click);
            // 
            // artigosToolStripMenuItem
            // 
            this.artigosToolStripMenuItem.Name = "artigosToolStripMenuItem";
            this.artigosToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.artigosToolStripMenuItem.Text = "Artigos";
            this.artigosToolStripMenuItem.Click += new System.EventHandler(this.artigosToolStripMenuItem_Click);
            // 
            // utilizadoresToolStripMenuItem
            // 
            this.utilizadoresToolStripMenuItem.Name = "utilizadoresToolStripMenuItem";
            this.utilizadoresToolStripMenuItem.Size = new System.Drawing.Size(80, 20);
            this.utilizadoresToolStripMenuItem.Text = "Utilizadores";
            this.utilizadoresToolStripMenuItem.Click += new System.EventHandler(this.utilizadoresToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Orçamento Mensal";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(78, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Orçamento";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(175, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Total Gasto";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(280, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Disponivel";
            // 
            // labelOrcamento
            // 
            this.labelOrcamento.AutoSize = true;
            this.labelOrcamento.Location = new System.Drawing.Point(78, 164);
            this.labelOrcamento.Name = "labelOrcamento";
            this.labelOrcamento.Size = new System.Drawing.Size(28, 13);
            this.labelOrcamento.TabIndex = 5;
            this.labelOrcamento.Text = "0,00";
            // 
            // labelTotalGasto
            // 
            this.labelTotalGasto.AutoSize = true;
            this.labelTotalGasto.Location = new System.Drawing.Point(175, 164);
            this.labelTotalGasto.Name = "labelTotalGasto";
            this.labelTotalGasto.Size = new System.Drawing.Size(28, 13);
            this.labelTotalGasto.TabIndex = 6;
            this.labelTotalGasto.Text = "0,00";
            // 
            // labelDisponivel
            // 
            this.labelDisponivel.AutoSize = true;
            this.labelDisponivel.Location = new System.Drawing.Point(280, 164);
            this.labelDisponivel.Name = "labelDisponivel";
            this.labelDisponivel.Size = new System.Drawing.Size(28, 13);
            this.labelDisponivel.TabIndex = 7;
            this.labelDisponivel.Text = "0,00";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(55, 242);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Compras em Aberto";
            // 
            // buttonNovaCompra
            // 
            this.buttonNovaCompra.Location = new System.Drawing.Point(58, 439);
            this.buttonNovaCompra.Name = "buttonNovaCompra";
            this.buttonNovaCompra.Size = new System.Drawing.Size(93, 23);
            this.buttonNovaCompra.TabIndex = 9;
            this.buttonNovaCompra.Text = "Nova compra";
            this.buttonNovaCompra.UseVisualStyleBackColor = true;
            this.buttonNovaCompra.Click += new System.EventHandler(this.buttonNovaCompra_Click);
            // 
            // buttonContinuarCompra
            // 
            this.buttonContinuarCompra.Location = new System.Drawing.Point(202, 439);
            this.buttonContinuarCompra.Name = "buttonContinuarCompra";
            this.buttonContinuarCompra.Size = new System.Drawing.Size(112, 23);
            this.buttonContinuarCompra.TabIndex = 10;
            this.buttonContinuarCompra.Text = "Continuar a comprar";
            this.buttonContinuarCompra.UseVisualStyleBackColor = true;
            this.buttonContinuarCompra.Click += new System.EventHandler(this.buttonContinuarCompra_Click);
            // 
            // buttonEstatisticas
            // 
            this.buttonEstatisticas.Location = new System.Drawing.Point(363, 439);
            this.buttonEstatisticas.Name = "buttonEstatisticas";
            this.buttonEstatisticas.Size = new System.Drawing.Size(93, 23);
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
            this.Nome,
            this.DataCriacao,
            this.IsFechada});
            this.dataGridViewCompras.Location = new System.Drawing.Point(58, 271);
            this.dataGridViewCompras.Name = "dataGridViewCompras";
            this.dataGridViewCompras.ReadOnly = true;
            this.dataGridViewCompras.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewCompras.Size = new System.Drawing.Size(543, 150);
            this.dataGridViewCompras.TabIndex = 12;
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Width = 197;
            // 
            // Nome
            // 
            this.Nome.HeaderText = "Nome da Compra";
            this.Nome.Name = "Nome";
            this.Nome.ReadOnly = true;
            // 
            // DataCriacao
            // 
            this.DataCriacao.HeaderText = "Data Criação";
            this.DataCriacao.Name = "DataCriacao";
            this.DataCriacao.ReadOnly = true;
            // 
            // IsFechada
            // 
            this.IsFechada.HeaderText = "Estado";
            this.IsFechada.Name = "IsFechada";
            this.IsFechada.ReadOnly = true;
            // 
            // labelPerfil
            // 
            this.labelPerfil.AutoSize = true;
            this.labelPerfil.Location = new System.Drawing.Point(708, 36);
            this.labelPerfil.Name = "labelPerfil";
            this.labelPerfil.Size = new System.Drawing.Size(30, 13);
            this.labelPerfil.TabIndex = 13;
            this.labelPerfil.Text = "Perfil";
            // 
            // FormDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 564);
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
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormDashboard";
            this.Text = "Dashboard";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCompras)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ficheiroToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem comprasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem estatisticasToolStripMenuItem;
        private System.Windows.Forms.Label label1;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nome;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataCriacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsFechada;
        private System.Windows.Forms.ToolStripMenuItem oToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tiposDeArtigoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem artigosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem utilizadoresToolStripMenuItem;
    }
}