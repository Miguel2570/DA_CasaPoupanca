namespace CasaPoupanca
{
    partial class FormItemNaoPrevisto
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
            this.label = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonAdicionar = new System.Windows.Forms.Button();
            this.ButtonCancelar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDownQuantidade = new System.Windows.Forms.NumericUpDown();
            this.textBoxObservacao = new System.Windows.Forms.TextBox();
            this.numericUpDownPrecoUnitario = new System.Windows.Forms.NumericUpDown();
            this.listBoxItensNaoPrevistos = new System.Windows.Forms.ListBox();
            this.labelAviso = new System.Windows.Forms.Label();
            this.labelOrcamentoDisponivel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonRemover = new System.Windows.Forms.Button();
            this.Artigo = new System.Windows.Forms.Label();
            this.comboBoxTipoDeArtigo = new System.Windows.Forms.ComboBox();
            this.comboBoxArtigo = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownQuantidade)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPrecoUnitario)).BeginInit();
            this.SuspendLayout();
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.Location = new System.Drawing.Point(240, 60);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(357, 32);
            this.label.TabIndex = 20;
            this.label.Text = "Adicionar Item não previsto";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CasaPoupanca.Properties.Resources.final_removebg_preview;
            this.pictureBox1.Location = new System.Drawing.Point(16, 17);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(218, 132);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 21;
            this.pictureBox1.TabStop = false;
            // 
            // buttonAdicionar
            // 
            this.buttonAdicionar.Location = new System.Drawing.Point(532, 612);
            this.buttonAdicionar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonAdicionar.Name = "buttonAdicionar";
            this.buttonAdicionar.Size = new System.Drawing.Size(140, 51);
            this.buttonAdicionar.TabIndex = 22;
            this.buttonAdicionar.Text = "Adicionar";
            this.buttonAdicionar.UseVisualStyleBackColor = true;
            this.buttonAdicionar.Click += new System.EventHandler(this.buttonAdicionar_Click);
            // 
            // ButtonCancelar
            // 
            this.ButtonCancelar.Location = new System.Drawing.Point(850, 612);
            this.ButtonCancelar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ButtonCancelar.Name = "ButtonCancelar";
            this.ButtonCancelar.Size = new System.Drawing.Size(140, 51);
            this.ButtonCancelar.TabIndex = 23;
            this.ButtonCancelar.Text = "Cancelar";
            this.ButtonCancelar.UseVisualStyleBackColor = true;
            this.ButtonCancelar.Click += new System.EventHandler(this.Cancelar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 344);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 20);
            this.label1.TabIndex = 24;
            this.label1.Text = "Tipo de artigo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 566);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 20);
            this.label2.TabIndex = 25;
            this.label2.Text = "Observação";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 502);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 20);
            this.label3.TabIndex = 26;
            this.label3.Text = "Preço Unitário";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(44, 438);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 20);
            this.label4.TabIndex = 27;
            this.label4.Text = "Quantidade";
            // 
            // numericUpDownQuantidade
            // 
            this.numericUpDownQuantidade.Location = new System.Drawing.Point(153, 435);
            this.numericUpDownQuantidade.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numericUpDownQuantidade.Name = "numericUpDownQuantidade";
            this.numericUpDownQuantidade.Size = new System.Drawing.Size(180, 26);
            this.numericUpDownQuantidade.TabIndex = 28;
            // 
            // textBoxObservacao
            // 
            this.textBoxObservacao.Location = new System.Drawing.Point(153, 562);
            this.textBoxObservacao.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxObservacao.Name = "textBoxObservacao";
            this.textBoxObservacao.Size = new System.Drawing.Size(178, 26);
            this.textBoxObservacao.TabIndex = 30;
            // 
            // numericUpDownPrecoUnitario
            // 
            this.numericUpDownPrecoUnitario.Location = new System.Drawing.Point(153, 498);
            this.numericUpDownPrecoUnitario.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numericUpDownPrecoUnitario.Name = "numericUpDownPrecoUnitario";
            this.numericUpDownPrecoUnitario.Size = new System.Drawing.Size(180, 26);
            this.numericUpDownPrecoUnitario.TabIndex = 31;
            // 
            // listBoxItensNaoPrevistos
            // 
            this.listBoxItensNaoPrevistos.FormattingEnabled = true;
            this.listBoxItensNaoPrevistos.ItemHeight = 20;
            this.listBoxItensNaoPrevistos.Location = new System.Drawing.Point(532, 272);
            this.listBoxItensNaoPrevistos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listBoxItensNaoPrevistos.Name = "listBoxItensNaoPrevistos";
            this.listBoxItensNaoPrevistos.Size = new System.Drawing.Size(580, 304);
            this.listBoxItensNaoPrevistos.TabIndex = 32;
            this.listBoxItensNaoPrevistos.SelectedIndexChanged += new System.EventHandler(this.listBoxItensNaoPrevistos_SelectedIndexChanged);
            // 
            // labelAviso
            // 
            this.labelAviso.AutoSize = true;
            this.labelAviso.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAviso.Location = new System.Drawing.Point(22, 265);
            this.labelAviso.Name = "labelAviso";
            this.labelAviso.Size = new System.Drawing.Size(365, 29);
            this.labelAviso.TabIndex = 37;
            this.labelAviso.Text = "(Alerta vermelho se ultrapassar)  ";
            // 
            // labelOrcamentoDisponivel
            // 
            this.labelOrcamentoDisponivel.AutoSize = true;
            this.labelOrcamentoDisponivel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOrcamentoDisponivel.Location = new System.Drawing.Point(16, 214);
            this.labelOrcamentoDisponivel.Name = "labelOrcamentoDisponivel";
            this.labelOrcamentoDisponivel.Size = new System.Drawing.Size(365, 29);
            this.labelOrcamentoDisponivel.TabIndex = 36;
            this.labelOrcamentoDisponivel.Text = "Orçamento Disponível: 500,00 €  ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(526, 214);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(220, 29);
            this.label6.TabIndex = 38;
            this.label6.Text = "Itens Não Previstos";
            // 
            // buttonRemover
            // 
            this.buttonRemover.Location = new System.Drawing.Point(692, 612);
            this.buttonRemover.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonRemover.Name = "buttonRemover";
            this.buttonRemover.Size = new System.Drawing.Size(140, 51);
            this.buttonRemover.TabIndex = 39;
            this.buttonRemover.Text = "Remover";
            this.buttonRemover.UseVisualStyleBackColor = true;
            this.buttonRemover.Click += new System.EventHandler(this.buttonRemover_Click);
            // 
            // Artigo
            // 
            this.Artigo.AutoSize = true;
            this.Artigo.Location = new System.Drawing.Point(97, 390);
            this.Artigo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Artigo.Name = "Artigo";
            this.Artigo.Size = new System.Drawing.Size(51, 20);
            this.Artigo.TabIndex = 40;
            this.Artigo.Text = "Artigo";
            // 
            // comboBoxTipoDeArtigo
            // 
            this.comboBoxTipoDeArtigo.FormattingEnabled = true;
            this.comboBoxTipoDeArtigo.Location = new System.Drawing.Point(153, 344);
            this.comboBoxTipoDeArtigo.Name = "comboBoxTipoDeArtigo";
            this.comboBoxTipoDeArtigo.Size = new System.Drawing.Size(180, 28);
            this.comboBoxTipoDeArtigo.TabIndex = 41;
            this.comboBoxTipoDeArtigo.SelectedIndexChanged += new System.EventHandler(this.comboBoxTipoDeArtigo_SelectedIndexChanged);
            // 
            // comboBoxArtigo
            // 
            this.comboBoxArtigo.FormattingEnabled = true;
            this.comboBoxArtigo.Location = new System.Drawing.Point(153, 387);
            this.comboBoxArtigo.Name = "comboBoxArtigo";
            this.comboBoxArtigo.Size = new System.Drawing.Size(180, 28);
            this.comboBoxArtigo.TabIndex = 42;
            this.comboBoxArtigo.SelectedIndexChanged += new System.EventHandler(this.comboBoxArtigo_SelectedIndexChanged);
            // 
            // FormItemNaoPrevisto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1186, 903);
            this.Controls.Add(this.comboBoxArtigo);
            this.Controls.Add(this.comboBoxTipoDeArtigo);
            this.Controls.Add(this.Artigo);
            this.Controls.Add(this.buttonRemover);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.labelAviso);
            this.Controls.Add(this.labelOrcamentoDisponivel);
            this.Controls.Add(this.listBoxItensNaoPrevistos);
            this.Controls.Add(this.numericUpDownPrecoUnitario);
            this.Controls.Add(this.textBoxObservacao);
            this.Controls.Add(this.numericUpDownQuantidade);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ButtonCancelar);
            this.Controls.Add(this.buttonAdicionar);
            this.Controls.Add(this.label);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormItemNaoPrevisto";
            this.Text = "FormItemNaoPrevisto";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownQuantidade)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPrecoUnitario)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonAdicionar;
        private System.Windows.Forms.Button ButtonCancelar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDownQuantidade;
        private System.Windows.Forms.TextBox textBoxObservacao;
        private System.Windows.Forms.NumericUpDown numericUpDownPrecoUnitario;
        private System.Windows.Forms.ListBox listBoxItensNaoPrevistos;
        private System.Windows.Forms.Label labelAviso;
        private System.Windows.Forms.Label labelOrcamentoDisponivel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonRemover;
        private System.Windows.Forms.Label Artigo;
        private System.Windows.Forms.ComboBox comboBoxTipoDeArtigo;
        private System.Windows.Forms.ComboBox comboBoxArtigo;
    }
}