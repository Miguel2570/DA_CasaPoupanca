namespace CasaPoupanca
{
    partial class FormCompra
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridViewCompras = new System.Windows.Forms.DataGridView();
            this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Artigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ações = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonAdicionar = new System.Windows.Forms.Button();
            this.buttonRemover = new System.Windows.Forms.Button();
            this.comboBoxTipo = new System.Windows.Forms.ComboBox();
            this.comboBoxArtigo = new System.Windows.Forms.ComboBox();
            this.numericUpDownQuantidade = new System.Windows.Forms.NumericUpDown();
            this.textBoxNomeCompra = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonEditar = new System.Windows.Forms.Button();
            this.buttonVoltar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCompras)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownQuantidade)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(134, 44);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nova Compra";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CasaPoupanca.Properties.Resources.final_removebg_preview;
            this.pictureBox1.Location = new System.Drawing.Point(8, 8);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(107, 86);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Nome da Compra";
            // 
            // dataGridViewCompras
            // 
            this.dataGridViewCompras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCompras.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Tipo,
            this.Artigo,
            this.Quantidade,
            this.Ações});
            this.dataGridViewCompras.Location = new System.Drawing.Point(380, 133);
            this.dataGridViewCompras.Name = "dataGridViewCompras";
            this.dataGridViewCompras.Size = new System.Drawing.Size(448, 150);
            this.dataGridViewCompras.TabIndex = 19;
            this.dataGridViewCompras.SelectionChanged += new System.EventHandler(this.dataGridViewCompras_SelectionChanged);
            // 
            // Tipo
            // 
            this.Tipo.HeaderText = "Tipo";
            this.Tipo.Name = "Tipo";
            // 
            // Artigo
            // 
            this.Artigo.HeaderText = "Artigo";
            this.Artigo.Name = "Artigo";
            // 
            // Quantidade
            // 
            this.Quantidade.HeaderText = "Quantidade";
            this.Quantidade.Name = "Quantidade";
            // 
            // Ações
            // 
            this.Ações.HeaderText = "Ações";
            this.Ações.Name = "Ações";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 173);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Tipo";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 210);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Artigo";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 247);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Quantidade";
            // 
            // buttonAdicionar
            // 
            this.buttonAdicionar.Location = new System.Drawing.Point(20, 299);
            this.buttonAdicionar.Name = "buttonAdicionar";
            this.buttonAdicionar.Size = new System.Drawing.Size(75, 23);
            this.buttonAdicionar.TabIndex = 23;
            this.buttonAdicionar.Text = "Adicionar";
            this.buttonAdicionar.UseVisualStyleBackColor = true;
            this.buttonAdicionar.Click += new System.EventHandler(this.buttonAdicionar_Click);
            // 
            // buttonRemover
            // 
            this.buttonRemover.Location = new System.Drawing.Point(213, 299);
            this.buttonRemover.Name = "buttonRemover";
            this.buttonRemover.Size = new System.Drawing.Size(75, 23);
            this.buttonRemover.TabIndex = 24;
            this.buttonRemover.Text = "Remover";
            this.buttonRemover.UseVisualStyleBackColor = true;
            this.buttonRemover.Click += new System.EventHandler(this.buttonRemover_Click);
            // 
            // comboBoxTipo
            // 
            this.comboBoxTipo.FormattingEnabled = true;
            this.comboBoxTipo.Items.AddRange(new object[] {
            "Alimentação",
            "Higiene",
            "Limpeza",
            "Roupa",
            "Eletrônicos",
            "Ferramentas",
            "Brinquedos",
            "Papelaria"});
            this.comboBoxTipo.Location = new System.Drawing.Point(129, 170);
            this.comboBoxTipo.Name = "comboBoxTipo";
            this.comboBoxTipo.Size = new System.Drawing.Size(121, 21);
            this.comboBoxTipo.TabIndex = 27;
            // 
            // comboBoxArtigo
            // 
            this.comboBoxArtigo.FormattingEnabled = true;
            this.comboBoxArtigo.Items.AddRange(new object[] {
            "Arroz",
            "Massa",
            "Açúcar",
            "Sal",
            "Azeite",
            "Leite",
            "Pão",
            "Manteiga",
            "Detergente",
            "Champô"});
            this.comboBoxArtigo.Location = new System.Drawing.Point(129, 207);
            this.comboBoxArtigo.Name = "comboBoxArtigo";
            this.comboBoxArtigo.Size = new System.Drawing.Size(121, 21);
            this.comboBoxArtigo.TabIndex = 28;
            // 
            // numericUpDownQuantidade
            // 
            this.numericUpDownQuantidade.Location = new System.Drawing.Point(129, 245);
            this.numericUpDownQuantidade.Name = "numericUpDownQuantidade";
            this.numericUpDownQuantidade.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownQuantidade.TabIndex = 29;
            // 
            // textBoxNomeCompra
            // 
            this.textBoxNomeCompra.Location = new System.Drawing.Point(129, 133);
            this.textBoxNomeCompra.Name = "textBoxNomeCompra";
            this.textBoxNomeCompra.Size = new System.Drawing.Size(121, 20);
            this.textBoxNomeCompra.TabIndex = 30;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(376, 95);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 20);
            this.label6.TabIndex = 31;
            this.label6.Text = "Compras";
            // 
            // buttonEditar
            // 
            this.buttonEditar.Location = new System.Drawing.Point(114, 299);
            this.buttonEditar.Name = "buttonEditar";
            this.buttonEditar.Size = new System.Drawing.Size(75, 23);
            this.buttonEditar.TabIndex = 32;
            this.buttonEditar.Text = "Editar";
            this.buttonEditar.UseVisualStyleBackColor = true;
            this.buttonEditar.Click += new System.EventHandler(this.buttonEditar_Click);
            // 
            // buttonVoltar
            // 
            this.buttonVoltar.Location = new System.Drawing.Point(20, 348);
            this.buttonVoltar.Name = "buttonVoltar";
            this.buttonVoltar.Size = new System.Drawing.Size(75, 23);
            this.buttonVoltar.TabIndex = 33;
            this.buttonVoltar.Text = "Voltar";
            this.buttonVoltar.UseVisualStyleBackColor = true;
            this.buttonVoltar.Click += new System.EventHandler(this.buttonVoltar_Click);
            // 
            // FormCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(980, 437);
            this.Controls.Add(this.buttonVoltar);
            this.Controls.Add(this.buttonEditar);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxNomeCompra);
            this.Controls.Add(this.numericUpDownQuantidade);
            this.Controls.Add(this.comboBoxArtigo);
            this.Controls.Add(this.comboBoxTipo);
            this.Controls.Add(this.buttonRemover);
            this.Controls.Add(this.buttonAdicionar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridViewCompras);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormCompra";
            this.Text = "FormCompra";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCompras)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownQuantidade)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridViewCompras;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Artigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ações;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonAdicionar;
        private System.Windows.Forms.Button buttonRemover;
        private System.Windows.Forms.ComboBox comboBoxTipo;
        private System.Windows.Forms.ComboBox comboBoxArtigo;
        private System.Windows.Forms.NumericUpDown numericUpDownQuantidade;
        private System.Windows.Forms.TextBox textBoxNomeCompra;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonEditar;
        private System.Windows.Forms.Button buttonVoltar;
    }
}