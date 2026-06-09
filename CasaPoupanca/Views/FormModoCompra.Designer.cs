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
            this.buttonAdquirirItemNaoPrevisto = new System.Windows.Forms.Button();
            this.groupBoxAdquirir = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listBoxListaFinal = new System.Windows.Forms.ListBox();
            this.buttonSalvar = new System.Windows.Forms.Button();
            this.buttonRemoverItemListaFinal = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownQuantidadeAdquirir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPrecoUnitarioAdquirir)).BeginInit();
            this.groupBoxPrevistos.SuspendLayout();
            this.groupBoxNaoPrevistos.SuspendLayout();
            this.groupBoxAdquirir.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelNomeCompra
            // 
            this.labelNomeCompra.AutoSize = true;
            this.labelNomeCompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.labelNomeCompra.Location = new System.Drawing.Point(120, 20);
            this.labelNomeCompra.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelNomeCompra.Name = "labelNomeCompra";
            this.labelNomeCompra.Size = new System.Drawing.Size(120, 20);
            this.labelNomeCompra.TabIndex = 18;
            this.labelNomeCompra.Text = "Modo Compra";
            // 
            // labelOrcamentoDisponivel
            // 
            this.labelOrcamentoDisponivel.AutoSize = true;
            this.labelOrcamentoDisponivel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelOrcamentoDisponivel.Location = new System.Drawing.Point(120, 42);
            this.labelOrcamentoDisponivel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelOrcamentoDisponivel.Name = "labelOrcamentoDisponivel";
            this.labelOrcamentoDisponivel.Size = new System.Drawing.Size(178, 17);
            this.labelOrcamentoDisponivel.TabIndex = 34;
            this.labelOrcamentoDisponivel.Text = "Orçamento restante: €0,00";
            // 
            // labelAviso
            // 
            this.labelAviso.AutoSize = true;
            this.labelAviso.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.labelAviso.Location = new System.Drawing.Point(120, 62);
            this.labelAviso.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelAviso.Name = "labelAviso";
            this.labelAviso.Size = new System.Drawing.Size(0, 15);
            this.labelAviso.TabIndex = 35;
            this.labelAviso.Visible = false;
            // 
            // buttonFecharCompra
            // 
            this.buttonFecharCompra.BackColor = System.Drawing.Color.Gold;
            this.buttonFecharCompra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonFecharCompra.Location = new System.Drawing.Point(184, 416);
            this.buttonFecharCompra.Margin = new System.Windows.Forms.Padding(2);
            this.buttonFecharCompra.Name = "buttonFecharCompra";
            this.buttonFecharCompra.Size = new System.Drawing.Size(153, 26);
            this.buttonFecharCompra.TabIndex = 39;
            this.buttonFecharCompra.Text = "Fechar Compra";
            this.buttonFecharCompra.UseVisualStyleBackColor = false;
            this.buttonFecharCompra.Click += new System.EventHandler(this.buttonFecharCompra_Click);
            // 
            // buttonVoltar
            // 
            this.buttonVoltar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonVoltar.Location = new System.Drawing.Point(8, 416);
            this.buttonVoltar.Margin = new System.Windows.Forms.Padding(2);
            this.buttonVoltar.Name = "buttonVoltar";
            this.buttonVoltar.Size = new System.Drawing.Size(153, 26);
            this.buttonVoltar.TabIndex = 42;
            this.buttonVoltar.Text = "Voltar";
            this.buttonVoltar.UseVisualStyleBackColor = true;
            this.buttonVoltar.Click += new System.EventHandler(this.buttonVoltar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CasaPoupanca.Properties.Resources.final_removebg_preview;
            this.pictureBox1.Location = new System.Drawing.Point(8, 8);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 52);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            // 
            // listBoxItensPrevistos
            // 
            this.listBoxItensPrevistos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxItensPrevistos.FormattingEnabled = true;
            this.listBoxItensPrevistos.Location = new System.Drawing.Point(7, 20);
            this.listBoxItensPrevistos.Margin = new System.Windows.Forms.Padding(2);
            this.listBoxItensPrevistos.Name = "listBoxItensPrevistos";
            this.listBoxItensPrevistos.Size = new System.Drawing.Size(221, 186);
            this.listBoxItensPrevistos.TabIndex = 43;
            this.listBoxItensPrevistos.SelectedIndexChanged += new System.EventHandler(this.listBoxItensPrevistos_SelectedIndexChanged_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 45;
            this.label1.Text = "Quantidade:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(157, 23);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 47;
            this.label2.Text = "Preço Unitário:";
            // 
            // buttonAddItemNaoPrevisto
            // 
            this.buttonAddItemNaoPrevisto.BackColor = System.Drawing.Color.LightBlue;
            this.buttonAddItemNaoPrevisto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddItemNaoPrevisto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAddItemNaoPrevisto.Location = new System.Drawing.Point(146, 214);
            this.buttonAddItemNaoPrevisto.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAddItemNaoPrevisto.Name = "buttonAddItemNaoPrevisto";
            this.buttonAddItemNaoPrevisto.Size = new System.Drawing.Size(177, 32);
            this.buttonAddItemNaoPrevisto.TabIndex = 38;
            this.buttonAddItemNaoPrevisto.Text = "Adicionar Item Não Previsto";
            this.buttonAddItemNaoPrevisto.UseVisualStyleBackColor = false;
            this.buttonAddItemNaoPrevisto.Click += new System.EventHandler(this.buttonAddItemNaoPrevisto_Click);
            // 
            // listBoxItensNaoPrevistos
            // 
            this.listBoxItensNaoPrevistos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxItensNaoPrevistos.FormattingEnabled = true;
            this.listBoxItensNaoPrevistos.Location = new System.Drawing.Point(7, 20);
            this.listBoxItensNaoPrevistos.Margin = new System.Windows.Forms.Padding(2);
            this.listBoxItensNaoPrevistos.Name = "listBoxItensNaoPrevistos";
            this.listBoxItensNaoPrevistos.Size = new System.Drawing.Size(427, 186);
            this.listBoxItensNaoPrevistos.TabIndex = 50;
            this.listBoxItensNaoPrevistos.SelectedIndexChanged += new System.EventHandler(this.listBoxItensNaoPrevistos_SelectedIndexChanged);
            // 
            // numericUpDownQuantidadeAdquirir
            // 
            this.numericUpDownQuantidadeAdquirir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownQuantidadeAdquirir.Location = new System.Drawing.Point(81, 20);
            this.numericUpDownQuantidadeAdquirir.Margin = new System.Windows.Forms.Padding(2);
            this.numericUpDownQuantidadeAdquirir.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownQuantidadeAdquirir.Name = "numericUpDownQuantidadeAdquirir";
            this.numericUpDownQuantidadeAdquirir.Size = new System.Drawing.Size(67, 20);
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
            this.numericUpDownPrecoUnitarioAdquirir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownPrecoUnitarioAdquirir.Location = new System.Drawing.Point(236, 20);
            this.numericUpDownPrecoUnitarioAdquirir.Margin = new System.Windows.Forms.Padding(2);
            this.numericUpDownPrecoUnitarioAdquirir.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownPrecoUnitarioAdquirir.Name = "numericUpDownPrecoUnitarioAdquirir";
            this.numericUpDownPrecoUnitarioAdquirir.Size = new System.Drawing.Size(80, 20);
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
            this.buttonRemoverItemNaoPrevisto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRemoverItemNaoPrevisto.Location = new System.Drawing.Point(327, 214);
            this.buttonRemoverItemNaoPrevisto.Margin = new System.Windows.Forms.Padding(2);
            this.buttonRemoverItemNaoPrevisto.Name = "buttonRemoverItemNaoPrevisto";
            this.buttonRemoverItemNaoPrevisto.Size = new System.Drawing.Size(107, 32);
            this.buttonRemoverItemNaoPrevisto.TabIndex = 54;
            this.buttonRemoverItemNaoPrevisto.Text = "Remover Item";
            this.buttonRemoverItemNaoPrevisto.UseVisualStyleBackColor = false;
            this.buttonRemoverItemNaoPrevisto.Click += new System.EventHandler(this.buttonRemoverItemNaoPrevisto_Click);
            // 
            // buttonAdquirirItemPrevisto
            // 
            this.buttonAdquirirItemPrevisto.BackColor = System.Drawing.Color.LightGreen;
            this.buttonAdquirirItemPrevisto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAdquirirItemPrevisto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAdquirirItemPrevisto.Location = new System.Drawing.Point(7, 214);
            this.buttonAdquirirItemPrevisto.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAdquirirItemPrevisto.Name = "buttonAdquirirItemPrevisto";
            this.buttonAdquirirItemPrevisto.Size = new System.Drawing.Size(107, 32);
            this.buttonAdquirirItemPrevisto.TabIndex = 55;
            this.buttonAdquirirItemPrevisto.Text = "Adquirir Item";
            this.buttonAdquirirItemPrevisto.UseVisualStyleBackColor = false;
            this.buttonAdquirirItemPrevisto.Click += new System.EventHandler(this.buttonAdquirirItemPrevisto_Click);
            // 
            // buttonRemoverItemPrevisto
            // 
            this.buttonRemoverItemPrevisto.BackColor = System.Drawing.Color.LightCoral;
            this.buttonRemoverItemPrevisto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRemoverItemPrevisto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRemoverItemPrevisto.Location = new System.Drawing.Point(120, 214);
            this.buttonRemoverItemPrevisto.Margin = new System.Windows.Forms.Padding(2);
            this.buttonRemoverItemPrevisto.Name = "buttonRemoverItemPrevisto";
            this.buttonRemoverItemPrevisto.Size = new System.Drawing.Size(107, 32);
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
            this.groupBoxPrevistos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxPrevistos.Location = new System.Drawing.Point(8, 84);
            this.groupBoxPrevistos.Margin = new System.Windows.Forms.Padding(2);
            this.groupBoxPrevistos.Name = "groupBoxPrevistos";
            this.groupBoxPrevistos.Padding = new System.Windows.Forms.Padding(2);
            this.groupBoxPrevistos.Size = new System.Drawing.Size(233, 260);
            this.groupBoxPrevistos.TabIndex = 36;
            this.groupBoxPrevistos.TabStop = false;
            this.groupBoxPrevistos.Text = "Itens Previstos";
            // 
            // groupBoxNaoPrevistos
            // 
            this.groupBoxNaoPrevistos.Controls.Add(this.buttonAdquirirItemNaoPrevisto);
            this.groupBoxNaoPrevistos.Controls.Add(this.listBoxItensNaoPrevistos);
            this.groupBoxNaoPrevistos.Controls.Add(this.buttonAddItemNaoPrevisto);
            this.groupBoxNaoPrevistos.Controls.Add(this.buttonRemoverItemNaoPrevisto);
            this.groupBoxNaoPrevistos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxNaoPrevistos.Location = new System.Drawing.Point(253, 84);
            this.groupBoxNaoPrevistos.Margin = new System.Windows.Forms.Padding(2);
            this.groupBoxNaoPrevistos.Name = "groupBoxNaoPrevistos";
            this.groupBoxNaoPrevistos.Padding = new System.Windows.Forms.Padding(2);
            this.groupBoxNaoPrevistos.Size = new System.Drawing.Size(438, 260);
            this.groupBoxNaoPrevistos.TabIndex = 37;
            this.groupBoxNaoPrevistos.TabStop = false;
            this.groupBoxNaoPrevistos.Text = "Itens Não Previstos";
            // 
            // buttonAdquirirItemNaoPrevisto
            // 
            this.buttonAdquirirItemNaoPrevisto.BackColor = System.Drawing.Color.LightGreen;
            this.buttonAdquirirItemNaoPrevisto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAdquirirItemNaoPrevisto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAdquirirItemNaoPrevisto.Location = new System.Drawing.Point(7, 214);
            this.buttonAdquirirItemNaoPrevisto.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAdquirirItemNaoPrevisto.Name = "buttonAdquirirItemNaoPrevisto";
            this.buttonAdquirirItemNaoPrevisto.Size = new System.Drawing.Size(135, 32);
            this.buttonAdquirirItemNaoPrevisto.TabIndex = 55;
            this.buttonAdquirirItemNaoPrevisto.Text = "Aquirir Item Não Previsto";
            this.buttonAdquirirItemNaoPrevisto.UseVisualStyleBackColor = false;
            this.buttonAdquirirItemNaoPrevisto.Click += new System.EventHandler(this.buttonAdquirirItemNaoPrevisto_Click);
            // 
            // groupBoxAdquirir
            // 
            this.groupBoxAdquirir.Controls.Add(this.label1);
            this.groupBoxAdquirir.Controls.Add(this.label2);
            this.groupBoxAdquirir.Controls.Add(this.numericUpDownQuantidadeAdquirir);
            this.groupBoxAdquirir.Controls.Add(this.numericUpDownPrecoUnitarioAdquirir);
            this.groupBoxAdquirir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxAdquirir.Location = new System.Drawing.Point(8, 354);
            this.groupBoxAdquirir.Margin = new System.Windows.Forms.Padding(2);
            this.groupBoxAdquirir.Name = "groupBoxAdquirir";
            this.groupBoxAdquirir.Padding = new System.Windows.Forms.Padding(2);
            this.groupBoxAdquirir.Size = new System.Drawing.Size(329, 52);
            this.groupBoxAdquirir.TabIndex = 38;
            this.groupBoxAdquirir.TabStop = false;
            this.groupBoxAdquirir.Text = "Dados para Adquirir";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listBoxListaFinal);
            this.groupBox1.Controls.Add(this.buttonSalvar);
            this.groupBox1.Controls.Add(this.buttonRemoverItemListaFinal);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(695, 84);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(233, 260);
            this.groupBox1.TabIndex = 43;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lista Final";
            // 
            // listBoxListaFinal
            // 
            this.listBoxListaFinal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxListaFinal.FormattingEnabled = true;
            this.listBoxListaFinal.Location = new System.Drawing.Point(7, 20);
            this.listBoxListaFinal.Margin = new System.Windows.Forms.Padding(2);
            this.listBoxListaFinal.Name = "listBoxListaFinal";
            this.listBoxListaFinal.Size = new System.Drawing.Size(221, 186);
            this.listBoxListaFinal.TabIndex = 50;
            // 
            // buttonSalvar
            // 
            this.buttonSalvar.BackColor = System.Drawing.Color.LightGreen;
            this.buttonSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSalvar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSalvar.Location = new System.Drawing.Point(7, 214);
            this.buttonSalvar.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSalvar.Name = "buttonSalvar";
            this.buttonSalvar.Size = new System.Drawing.Size(107, 32);
            this.buttonSalvar.TabIndex = 38;
            this.buttonSalvar.Text = "Salvar";
            this.buttonSalvar.UseVisualStyleBackColor = false;
            this.buttonSalvar.Click += new System.EventHandler(this.buttonSalvar_Click);
            // 
            // buttonRemoverItemListaFinal
            // 
            this.buttonRemoverItemListaFinal.BackColor = System.Drawing.Color.LightCoral;
            this.buttonRemoverItemListaFinal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRemoverItemListaFinal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRemoverItemListaFinal.Location = new System.Drawing.Point(120, 214);
            this.buttonRemoverItemListaFinal.Margin = new System.Windows.Forms.Padding(2);
            this.buttonRemoverItemListaFinal.Name = "buttonRemoverItemListaFinal";
            this.buttonRemoverItemListaFinal.Size = new System.Drawing.Size(107, 32);
            this.buttonRemoverItemListaFinal.TabIndex = 54;
            this.buttonRemoverItemListaFinal.Text = "Remover da Lista";
            this.buttonRemoverItemListaFinal.UseVisualStyleBackColor = false;
            this.buttonRemoverItemListaFinal.Click += new System.EventHandler(this.buttonRemoverItemListaFinal_Click);
            // 
            // FormModoCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(939, 455);
            this.Controls.Add(this.groupBox1);
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
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "FormModoCompra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modo Compra";
            this.Load += new System.EventHandler(this.FormModoCompra_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownQuantidadeAdquirir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPrecoUnitarioAdquirir)).EndInit();
            this.groupBoxPrevistos.ResumeLayout(false);
            this.groupBoxNaoPrevistos.ResumeLayout(false);
            this.groupBoxAdquirir.ResumeLayout(false);
            this.groupBoxAdquirir.PerformLayout();
            this.groupBox1.ResumeLayout(false);
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
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox listBoxListaFinal;
        private System.Windows.Forms.Button buttonSalvar;
        private System.Windows.Forms.Button buttonRemoverItemListaFinal;
        private System.Windows.Forms.Button buttonAdquirirItemNaoPrevisto;
    }
}