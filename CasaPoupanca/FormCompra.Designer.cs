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
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataCriacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsFechada = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.label1.Location = new System.Drawing.Point(201, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nova Compra";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CasaPoupanca.Properties.Resources.final_removebg_preview;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(160, 132);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 205);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 20);
            this.label2.TabIndex = 18;
            this.label2.Text = "Nome da Compra";
            // 
            // dataGridViewCompras
            // 
            this.dataGridViewCompras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCompras.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Nome,
            this.DataCriacao,
            this.IsFechada});
            this.dataGridViewCompras.Location = new System.Drawing.Point(570, 205);
            this.dataGridViewCompras.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridViewCompras.Name = "dataGridViewCompras";
            this.dataGridViewCompras.RowHeadersWidth = 62;
            this.dataGridViewCompras.Size = new System.Drawing.Size(690, 231);
            this.dataGridViewCompras.TabIndex = 19;
            this.dataGridViewCompras.SelectionChanged += new System.EventHandler(this.dataGridViewCompras_SelectionChanged);
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.MinimumWidth = 8;
            this.Id.Name = "Id";
            this.Id.Width = 150;
            // 
            // Nome
            // 
            this.Nome.HeaderText = "Nome da Compra";
            this.Nome.MinimumWidth = 8;
            this.Nome.Name = "Nome";
            this.Nome.Width = 150;
            // 
            // DataCriacao
            // 
            this.DataCriacao.HeaderText = "Data Criação";
            this.DataCriacao.MinimumWidth = 8;
            this.DataCriacao.Name = "DataCriacao";
            this.DataCriacao.Width = 150;
            // 
            // IsFechada
            // 
            this.IsFechada.HeaderText = "IsFechada";
            this.IsFechada.MinimumWidth = 8;
            this.IsFechada.Name = "IsFechada";
            this.IsFechada.Width = 150;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 266);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 20);
            this.label3.TabIndex = 20;
            this.label3.Text = "Tipo";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 323);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 20);
            this.label4.TabIndex = 21;
            this.label4.Text = "Artigo";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 380);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 20);
            this.label5.TabIndex = 22;
            this.label5.Text = "Quantidade";
            // 
            // buttonAdicionar
            // 
            this.buttonAdicionar.Location = new System.Drawing.Point(30, 460);
            this.buttonAdicionar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonAdicionar.Name = "buttonAdicionar";
            this.buttonAdicionar.Size = new System.Drawing.Size(112, 35);
            this.buttonAdicionar.TabIndex = 23;
            this.buttonAdicionar.Text = "Adicionar";
            this.buttonAdicionar.UseVisualStyleBackColor = true;
            this.buttonAdicionar.Click += new System.EventHandler(this.buttonAdicionar_Click);
            // 
            // buttonRemover
            // 
            this.buttonRemover.Location = new System.Drawing.Point(320, 460);
            this.buttonRemover.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonRemover.Name = "buttonRemover";
            this.buttonRemover.Size = new System.Drawing.Size(112, 35);
            this.buttonRemover.TabIndex = 24;
            this.buttonRemover.Text = "Remover";
            this.buttonRemover.UseVisualStyleBackColor = true;
            this.buttonRemover.Click += new System.EventHandler(this.buttonRemover_Click);
            // 
            // comboBoxTipo
            // 
            this.comboBoxTipo.FormattingEnabled = true;
            this.comboBoxTipo.Location = new System.Drawing.Point(194, 262);
            this.comboBoxTipo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBoxTipo.Name = "comboBoxTipo";
            this.comboBoxTipo.Size = new System.Drawing.Size(180, 28);
            this.comboBoxTipo.TabIndex = 27;
            this.comboBoxTipo.SelectedIndexChanged += new System.EventHandler(this.comboBoxTipo_SelectedIndexChanged);
            // 
            // comboBoxArtigo
            // 
            this.comboBoxArtigo.FormattingEnabled = true;
            this.comboBoxArtigo.Location = new System.Drawing.Point(194, 318);
            this.comboBoxArtigo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBoxArtigo.Name = "comboBoxArtigo";
            this.comboBoxArtigo.Size = new System.Drawing.Size(180, 28);
            this.comboBoxArtigo.TabIndex = 28;
            this.comboBoxArtigo.SelectedIndexChanged += new System.EventHandler(this.comboBoxArtigo_SelectedIndexChanged);
            // 
            // numericUpDownQuantidade
            // 
            this.numericUpDownQuantidade.Location = new System.Drawing.Point(194, 377);
            this.numericUpDownQuantidade.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numericUpDownQuantidade.Name = "numericUpDownQuantidade";
            this.numericUpDownQuantidade.Size = new System.Drawing.Size(180, 26);
            this.numericUpDownQuantidade.TabIndex = 29;
            // 
            // textBoxNomeCompra
            // 
            this.textBoxNomeCompra.Location = new System.Drawing.Point(194, 205);
            this.textBoxNomeCompra.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxNomeCompra.Name = "textBoxNomeCompra";
            this.textBoxNomeCompra.Size = new System.Drawing.Size(180, 26);
            this.textBoxNomeCompra.TabIndex = 30;
            this.textBoxNomeCompra.TextChanged += new System.EventHandler(this.textBoxNomeCompra_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(564, 146);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(111, 29);
            this.label6.TabIndex = 31;
            this.label6.Text = "Compras";
            // 
            // buttonEditar
            // 
            this.buttonEditar.Location = new System.Drawing.Point(171, 460);
            this.buttonEditar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonEditar.Name = "buttonEditar";
            this.buttonEditar.Size = new System.Drawing.Size(112, 35);
            this.buttonEditar.TabIndex = 32;
            this.buttonEditar.Text = "Editar";
            this.buttonEditar.UseVisualStyleBackColor = true;
            this.buttonEditar.Click += new System.EventHandler(this.buttonEditar_Click);
            // 
            // buttonVoltar
            // 
            this.buttonVoltar.Location = new System.Drawing.Point(30, 535);
            this.buttonVoltar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonVoltar.Name = "buttonVoltar";
            this.buttonVoltar.Size = new System.Drawing.Size(112, 35);
            this.buttonVoltar.TabIndex = 33;
            this.buttonVoltar.Text = "Voltar";
            this.buttonVoltar.UseVisualStyleBackColor = true;
            this.buttonVoltar.Click += new System.EventHandler(this.buttonVoltar_Click);
            // 
            // FormCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1470, 672);
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
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nome;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataCriacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsFechada;
    }
}