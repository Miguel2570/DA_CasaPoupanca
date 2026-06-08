namespace CasaPoupanca
{
    partial class FormModoCompra
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.labelNomeCompra = new System.Windows.Forms.Label();
            this.labelOrcamentoDisponivel = new System.Windows.Forms.Label();
            this.labelAviso = new System.Windows.Forms.Label();
            this.buttonFecharCompra = new System.Windows.Forms.Button();
            this.buttonVoltar = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.listBoxItensPrevistos = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonAddItemNaoPrevisto = new System.Windows.Forms.Button();
            this.listBoxItensNaoPrevistos = new System.Windows.Forms.ListBox();
            this.numericUpDownQuantidadeAdquirir = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownPrecoUnitarioAdquirir = new System.Windows.Forms.NumericUpDown();
            this.buttonRemoverItemNaoPrevisto = new System.Windows.Forms.Button();
            this.buttonAdquirirItemPrevisto = new System.Windows.Forms.Button();
            this.buttonRemoverItemPrevisto = new System.Windows.Forms.Button();
            this.groupBoxPrevistos = new System.Windows.Forms.GroupBox();
            this.groupBoxNaoPrevistos = new System.Windows.Forms.GroupBox();
            this.groupBoxAdquirir = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownQuantidadeAdquirir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPrecoUnitarioAdquirir)).BeginInit();
            this.groupBoxPrevistos.SuspendLayout();
            this.groupBoxNaoPrevistos.SuspendLayout();
            this.groupBoxAdquirir.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelNomeCompra
            // 
            this.labelNomeCompra.AutoSize = true;
            this.labelNomeCompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.labelNomeCompra.Location = new System.Drawing.Point(180, 30);
            this.labelNomeCompra.Name = "labelNomeCompra";
            this.labelNomeCompra.Size = new System.Drawing.Size(178, 29);
            this.labelNomeCompra.TabIndex = 18;
            this.labelNomeCompra.Text = "Modo Compra";
            // 
            // labelOrcamentoDisponivel
            // 
            this.labelOrcamentoDisponivel.AutoSize = true;
            this.labelOrcamentoDisponivel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelOrcamentoDisponivel.Location = new System.Drawing.Point(180, 65);
            this.labelOrcamentoDisponivel.Name = "labelOrcamentoDisponivel";
            this.labelOrcamentoDisponivel.Size = new System.Drawing.Size(169, 25);
            this.labelOrcamentoDisponivel.TabIndex = 34;
            this.labelOrcamentoDisponivel.Text = "Orçamento: €0,00";
            // 
            // labelAviso
            // 
            this.labelAviso.AutoSize = true;
            this.labelAviso.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.labelAviso.Location = new System.Drawing.Point(180, 95);
            this.labelAviso.Name = "labelAviso";
            this.labelAviso.Size = new System.Drawing.Size(0, 22);
            this.labelAviso.TabIndex = 35;
            this.labelAviso.Visible = false;
            // 
            // buttonFecharCompra
            // 
            this.buttonFecharCompra.BackColor = System.Drawing.Color.Gold;
            this.buttonFecharCompra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonFecharCompra.Location = new System.Drawing.Point(500, 640);
            this.buttonFecharCompra.Name = "buttonFecharCompra";
            this.buttonFecharCompra.Size = new System.Drawing.Size(230, 40);
            this.buttonFecharCompra.TabIndex = 39;
            this.buttonFecharCompra.Text = "Fechar Compra";
            this.buttonFecharCompra.UseVisualStyleBackColor = false;
            this.buttonFecharCompra.Click += new System.EventHandler(this.buttonFecharCompra_Click);
            // 
            // buttonVoltar
            // 
            this.buttonVoltar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonVoltar.Location = new System.Drawing.Point(12, 640);
            this.buttonVoltar.Name = "buttonVoltar";
            this.buttonVoltar.Size = new System.Drawing.Size(230, 40);
            this.buttonVoltar.TabIndex = 42;
            this.buttonVoltar.Text = "Voltar";
            this.buttonVoltar.UseVisualStyleBackColor = true;
            this.buttonVoltar.Click += new System.EventHandler(this.buttonVoltar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CasaPoupanca.Properties.Resources.final_removebg_preview;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(150, 80);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            // 
            // listBoxItensPrevistos
            // 
            this.listBoxItensPrevistos.FormattingEnabled = true;
            this.listBoxItensPrevistos.ItemHeight = 20;
            this.listBoxItensPrevistos.Location = new System.Drawing.Point(10, 30);
            this.listBoxItensPrevistos.Name = "listBoxItensPrevistos";
            this.listBoxItensPrevistos.Size = new System.Drawing.Size(330, 284);
            this.listBoxItensPrevistos.TabIndex = 43;
            this.listBoxItensPrevistos.SelectedIndexChanged += new System.EventHandler(this.listBoxItensPrevistos_SelectedIndexChanged_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 20);
            this.label1.TabIndex = 45;
            this.label1.Text = "Quantidade:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(235, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 20);
            this.label2.TabIndex = 47;
            this.label2.Text = "Preço Unitário:";
            // 
            // buttonAddItemNaoPrevisto
            // 
            this.buttonAddItemNaoPrevisto.BackColor = System.Drawing.Color.LightBlue;
            this.buttonAddItemNaoPrevisto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddItemNaoPrevisto.Location = new System.Drawing.Point(10, 330);
            this.buttonAddItemNaoPrevisto.Name = "buttonAddItemNaoPrevisto";
            this.buttonAddItemNaoPrevisto.Size = new System.Drawing.Size(160, 50);
            this.buttonAddItemNaoPrevisto.TabIndex = 38;
            this.buttonAddItemNaoPrevisto.Text = "Adicionar Item";
            this.buttonAddItemNaoPrevisto.UseVisualStyleBackColor = false;
            this.buttonAddItemNaoPrevisto.Click += new System.EventHandler(this.buttonAddItemNaoPrevisto_Click);
            // 
            // listBoxItensNaoPrevistos
            // 
            this.listBoxItensNaoPrevistos.FormattingEnabled = true;
            this.listBoxItensNaoPrevistos.ItemHeight = 20;
            this.listBoxItensNaoPrevistos.Location = new System.Drawing.Point(10, 30);
            this.listBoxItensNaoPrevistos.Name = "listBoxItensNaoPrevistos";
            this.listBoxItensNaoPrevistos.Size = new System.Drawing.Size(330, 284);
            this.listBoxItensNaoPrevistos.TabIndex = 50;
            this.listBoxItensNaoPrevistos.SelectedIndexChanged += new System.EventHandler(this.listBoxItensNaoPrevistos_SelectedIndexChanged);
            // 
            // numericUpDownQuantidadeAdquirir
            // 
            this.numericUpDownQuantidadeAdquirir.Location = new System.Drawing.Point(122, 30);
            this.numericUpDownQuantidadeAdquirir.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownQuantidadeAdquirir.Name = "numericUpDownQuantidadeAdquirir";
            this.numericUpDownQuantidadeAdquirir.Size = new System.Drawing.Size(100, 26);
            this.numericUpDownQuantidadeAdquirir.TabIndex = 52;
            this.numericUpDownQuantidadeAdquirir.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDownPrecoUnitarioAdquirir
            // 
            this.numericUpDownPrecoUnitarioAdquirir.DecimalPlaces = 2;
            this.numericUpDownPrecoUnitarioAdquirir.Location = new System.Drawing.Point(354, 30);
            this.numericUpDownPrecoUnitarioAdquirir.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownPrecoUnitarioAdquirir.Name = "numericUpDownPrecoUnitarioAdquirir";
            this.numericUpDownPrecoUnitarioAdquirir.Size = new System.Drawing.Size(120, 26);
            this.numericUpDownPrecoUnitarioAdquirir.TabIndex = 53;
            this.numericUpDownPrecoUnitarioAdquirir.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // buttonRemoverItemNaoPrevisto
            // 
            this.buttonRemoverItemNaoPrevisto.BackColor = System.Drawing.Color.LightCoral;
            this.buttonRemoverItemNaoPrevisto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRemoverItemNaoPrevisto.Location = new System.Drawing.Point(180, 330);
            this.buttonRemoverItemNaoPrevisto.Name = "buttonRemoverItemNaoPrevisto";
            this.buttonRemoverItemNaoPrevisto.Size = new System.Drawing.Size(160, 50);
            this.buttonRemoverItemNaoPrevisto.TabIndex = 54;
            this.buttonRemoverItemNaoPrevisto.Text = "Remover Item";
            this.buttonRemoverItemNaoPrevisto.UseVisualStyleBackColor = false;
            this.buttonRemoverItemNaoPrevisto.Click += new System.EventHandler(this.buttonRemoverItemNaoPrevisto_Click);
            // 
            // buttonAdquirirItemPrevisto
            // 
            this.buttonAdquirirItemPrevisto.BackColor = System.Drawing.Color.LightGreen;
            this.buttonAdquirirItemPrevisto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAdquirirItemPrevisto.Location = new System.Drawing.Point(10, 330);
            this.buttonAdquirirItemPrevisto.Name = "buttonAdquirirItemPrevisto";
            this.buttonAdquirirItemPrevisto.Size = new System.Drawing.Size(160, 50);
            this.buttonAdquirirItemPrevisto.TabIndex = 55;
            this.buttonAdquirirItemPrevisto.Text = "Adquirir Item";
            this.buttonAdquirirItemPrevisto.UseVisualStyleBackColor = false;
            this.buttonAdquirirItemPrevisto.Click += new System.EventHandler(this.buttonAdquirirItemPrevisto_Click);
            // 
            // buttonRemoverItemPrevisto
            // 
            this.buttonRemoverItemPrevisto.BackColor = System.Drawing.Color.LightCoral;
            this.buttonRemoverItemPrevisto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRemoverItemPrevisto.Location = new System.Drawing.Point(180, 330);
            this.buttonRemoverItemPrevisto.Name = "buttonRemoverItemPrevisto";
            this.buttonRemoverItemPrevisto.Size = new System.Drawing.Size(160, 50);
            this.buttonRemoverItemPrevisto.TabIndex = 56;
            this.buttonRemoverItemPrevisto.Text = "Remover Item";
            this.buttonRemoverItemPrevisto.UseVisualStyleBackColor = false;
            this.buttonRemoverItemPrevisto.Click += new System.EventHandler(this.buttonRemoverItemPrevisto_Click);
            // 
            // groupBoxPrevistos
            // 
            this.groupBoxPrevistos.Controls.Add(this.listBoxItensPrevistos);
            this.groupBoxPrevistos.Controls.Add(this.buttonAdquirirItemPrevisto);
            this.groupBoxPrevistos.Controls.Add(this.buttonRemoverItemPrevisto);
            this.groupBoxPrevistos.Location = new System.Drawing.Point(12, 130);
            this.groupBoxPrevistos.Name = "groupBoxPrevistos";
            this.groupBoxPrevistos.Size = new System.Drawing.Size(350, 400);
            this.groupBoxPrevistos.TabIndex = 36;
            this.groupBoxPrevistos.TabStop = false;
            this.groupBoxPrevistos.Text = "Itens Previstos";
            // 
            // groupBoxNaoPrevistos
            // 
            this.groupBoxNaoPrevistos.Controls.Add(this.listBoxItensNaoPrevistos);
            this.groupBoxNaoPrevistos.Controls.Add(this.buttonAddItemNaoPrevisto);
            this.groupBoxNaoPrevistos.Controls.Add(this.buttonRemoverItemNaoPrevisto);
            this.groupBoxNaoPrevistos.Location = new System.Drawing.Point(380, 130);
            this.groupBoxNaoPrevistos.Name = "groupBoxNaoPrevistos";
            this.groupBoxNaoPrevistos.Size = new System.Drawing.Size(350, 400);
            this.groupBoxNaoPrevistos.TabIndex = 37;
            this.groupBoxNaoPrevistos.TabStop = false;
            this.groupBoxNaoPrevistos.Text = "Itens Não Previstos";
            // 
            // groupBoxAdquirir
            // 
            this.groupBoxAdquirir.Controls.Add(this.label1);
            this.groupBoxAdquirir.Controls.Add(this.label2);
            this.groupBoxAdquirir.Controls.Add(this.numericUpDownQuantidadeAdquirir);
            this.groupBoxAdquirir.Controls.Add(this.numericUpDownPrecoUnitarioAdquirir);
            this.groupBoxAdquirir.Location = new System.Drawing.Point(12, 545);
            this.groupBoxAdquirir.Name = "groupBoxAdquirir";
            this.groupBoxAdquirir.Size = new System.Drawing.Size(718, 80);
            this.groupBoxAdquirir.TabIndex = 38;
            this.groupBoxAdquirir.TabStop = false;
            this.groupBoxAdquirir.Text = "Dados para Adquirir";
            // 
            // FormModoCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(750, 700);
            this.Controls.Add(this.groupBoxAdquirir);
            this.Controls.Add(this.groupBoxNaoPrevistos);
            this.Controls.Add(this.groupBoxPrevistos);
            this.Controls.Add(this.labelAviso);
            this.Controls.Add(this.labelOrcamentoDisponivel);
            this.Controls.Add(this.labelNomeCompra);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.buttonVoltar);
            this.Controls.Add(this.buttonFecharCompra);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormModoCompra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modo Compra";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownQuantidadeAdquirir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPrecoUnitarioAdquirir)).EndInit();
            this.groupBoxPrevistos.ResumeLayout(false);
            this.groupBoxNaoPrevistos.ResumeLayout(false);
            this.groupBoxAdquirir.ResumeLayout(false);
            this.groupBoxAdquirir.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelNomeCompra;
        private System.Windows.Forms.Label labelOrcamentoDisponivel;
        private System.Windows.Forms.Label labelAviso;
        private System.Windows.Forms.Button buttonFecharCompra;
        private System.Windows.Forms.Button buttonVoltar;
        private System.Windows.Forms.ListBox listBoxItensPrevistos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonAddItemNaoPrevisto;
        private System.Windows.Forms.ListBox listBoxItensNaoPrevistos;
        private System.Windows.Forms.NumericUpDown numericUpDownQuantidadeAdquirir;
        private System.Windows.Forms.NumericUpDown numericUpDownPrecoUnitarioAdquirir;
        private System.Windows.Forms.Button buttonRemoverItemNaoPrevisto;
        private System.Windows.Forms.Button buttonAdquirirItemPrevisto;
        private System.Windows.Forms.Button buttonRemoverItemPrevisto;
        private System.Windows.Forms.GroupBox groupBoxPrevistos;
        private System.Windows.Forms.GroupBox groupBoxNaoPrevistos;
        private System.Windows.Forms.GroupBox groupBoxAdquirir;
    }
}