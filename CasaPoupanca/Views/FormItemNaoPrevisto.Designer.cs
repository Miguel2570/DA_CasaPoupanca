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
            this.buttonRemover = new System.Windows.Forms.Button();
            this.Artigo = new System.Windows.Forms.Label();
            this.comboBoxTipoDeArtigo = new System.Windows.Forms.ComboBox();
            this.comboBoxArtigo = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonEditar = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownQuantidade)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPrecoUnitario)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.Location = new System.Drawing.Point(160, 39);
            this.label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(237, 24);
            this.label.TabIndex = 20;
            this.label.Text = "Adicionar Item não previsto";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CasaPoupanca.Properties.Resources.final_removebg_preview;
            this.pictureBox1.Location = new System.Drawing.Point(11, 11);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(145, 86);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 21;
            this.pictureBox1.TabStop = false;
            // 
            // buttonAdicionar
            // 
            this.buttonAdicionar.Location = new System.Drawing.Point(355, 398);
            this.buttonAdicionar.Name = "buttonAdicionar";
            this.buttonAdicionar.Size = new System.Drawing.Size(93, 33);
            this.buttonAdicionar.TabIndex = 22;
            this.buttonAdicionar.Text = "Adicionar";
            this.buttonAdicionar.UseVisualStyleBackColor = true;
            this.buttonAdicionar.Click += new System.EventHandler(this.buttonAdicionar_Click);
            // 
            // ButtonCancelar
            // 
            this.ButtonCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonCancelar.Location = new System.Drawing.Point(305, 246);
            this.ButtonCancelar.Name = "ButtonCancelar";
            this.ButtonCancelar.Size = new System.Drawing.Size(93, 33);
            this.ButtonCancelar.TabIndex = 23;
            this.ButtonCancelar.Text = "Cancelar";
            this.ButtonCancelar.UseVisualStyleBackColor = true;
            this.ButtonCancelar.Click += new System.EventHandler(this.Cancelar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 224);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Tipo de artigo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 368);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Observação";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 326);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "Preço Unitário";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 285);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = "Quantidade";
            // 
            // numericUpDownQuantidade
            // 
            this.numericUpDownQuantidade.Location = new System.Drawing.Point(102, 283);
            this.numericUpDownQuantidade.Name = "numericUpDownQuantidade";
            this.numericUpDownQuantidade.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownQuantidade.TabIndex = 28;
            // 
            // textBoxObservacao
            // 
            this.textBoxObservacao.Location = new System.Drawing.Point(102, 365);
            this.textBoxObservacao.Name = "textBoxObservacao";
            this.textBoxObservacao.Size = new System.Drawing.Size(120, 20);
            this.textBoxObservacao.TabIndex = 30;
            // 
            // numericUpDownPrecoUnitario
            // 
            this.numericUpDownPrecoUnitario.Location = new System.Drawing.Point(102, 324);
            this.numericUpDownPrecoUnitario.Name = "numericUpDownPrecoUnitario";
            this.numericUpDownPrecoUnitario.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownPrecoUnitario.TabIndex = 31;
            // 
            // listBoxItensNaoPrevistos
            // 
            this.listBoxItensNaoPrevistos.FormattingEnabled = true;
            this.listBoxItensNaoPrevistos.Location = new System.Drawing.Point(355, 177);
            this.listBoxItensNaoPrevistos.Name = "listBoxItensNaoPrevistos";
            this.listBoxItensNaoPrevistos.Size = new System.Drawing.Size(388, 199);
            this.listBoxItensNaoPrevistos.TabIndex = 32;
            this.listBoxItensNaoPrevistos.SelectedIndexChanged += new System.EventHandler(this.listBoxItensNaoPrevistos_SelectedIndexChanged);
            // 
            // labelAviso
            // 
            this.labelAviso.AutoSize = true;
            this.labelAviso.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAviso.Location = new System.Drawing.Point(17, 152);
            this.labelAviso.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelAviso.Name = "labelAviso";
            this.labelAviso.Size = new System.Drawing.Size(241, 20);
            this.labelAviso.TabIndex = 37;
            this.labelAviso.Text = "(Alerta vermelho se ultrapassar)  ";
            // 
            // labelOrcamentoDisponivel
            // 
            this.labelOrcamentoDisponivel.AutoSize = true;
            this.labelOrcamentoDisponivel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOrcamentoDisponivel.Location = new System.Drawing.Point(13, 119);
            this.labelOrcamentoDisponivel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelOrcamentoDisponivel.Name = "labelOrcamentoDisponivel";
            this.labelOrcamentoDisponivel.Size = new System.Drawing.Size(128, 20);
            this.labelOrcamentoDisponivel.TabIndex = 36;
            this.labelOrcamentoDisponivel.Text = "Orçamento: X €  ";
            // 
            // buttonRemover
            // 
            this.buttonRemover.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRemover.Location = new System.Drawing.Point(206, 246);
            this.buttonRemover.Name = "buttonRemover";
            this.buttonRemover.Size = new System.Drawing.Size(93, 33);
            this.buttonRemover.TabIndex = 39;
            this.buttonRemover.Text = "Remover";
            this.buttonRemover.UseVisualStyleBackColor = true;
            this.buttonRemover.Click += new System.EventHandler(this.buttonRemover_Click);
            // 
            // Artigo
            // 
            this.Artigo.AutoSize = true;
            this.Artigo.Location = new System.Drawing.Point(65, 253);
            this.Artigo.Name = "Artigo";
            this.Artigo.Size = new System.Drawing.Size(34, 13);
            this.Artigo.TabIndex = 40;
            this.Artigo.Text = "Artigo";
            // 
            // comboBoxTipoDeArtigo
            // 
            this.comboBoxTipoDeArtigo.FormattingEnabled = true;
            this.comboBoxTipoDeArtigo.Location = new System.Drawing.Point(102, 224);
            this.comboBoxTipoDeArtigo.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxTipoDeArtigo.Name = "comboBoxTipoDeArtigo";
            this.comboBoxTipoDeArtigo.Size = new System.Drawing.Size(121, 21);
            this.comboBoxTipoDeArtigo.TabIndex = 41;
            this.comboBoxTipoDeArtigo.SelectedIndexChanged += new System.EventHandler(this.comboBoxTipoDeArtigo_SelectedIndexChanged);
            // 
            // comboBoxArtigo
            // 
            this.comboBoxArtigo.FormattingEnabled = true;
            this.comboBoxArtigo.Location = new System.Drawing.Point(102, 252);
            this.comboBoxArtigo.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxArtigo.Name = "comboBoxArtigo";
            this.comboBoxArtigo.Size = new System.Drawing.Size(121, 21);
            this.comboBoxArtigo.TabIndex = 42;
            this.comboBoxArtigo.SelectedIndexChanged += new System.EventHandler(this.comboBoxArtigo_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonEditar);
            this.groupBox1.Controls.Add(this.ButtonCancelar);
            this.groupBox1.Controls.Add(this.buttonRemover);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(345, 152);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(409, 303);
            this.groupBox1.TabIndex = 43;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lista de Itens Não Previstos";
            // 
            // buttonEditar
            // 
            this.buttonEditar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEditar.Location = new System.Drawing.Point(107, 246);
            this.buttonEditar.Name = "buttonEditar";
            this.buttonEditar.Size = new System.Drawing.Size(93, 33);
            this.buttonEditar.TabIndex = 45;
            this.buttonEditar.Text = "Editar";
            this.buttonEditar.UseVisualStyleBackColor = true;
            this.buttonEditar.Click += new System.EventHandler(this.buttonEditar_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(11, 196);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(228, 209);
            this.groupBox2.TabIndex = 44;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Adicionar/Editar Item Não Previsto";
            // 
            // FormItemNaoPrevisto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(791, 587);
            this.Controls.Add(this.comboBoxArtigo);
            this.Controls.Add(this.comboBoxTipoDeArtigo);
            this.Controls.Add(this.Artigo);
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
            this.Controls.Add(this.buttonAdicionar);
            this.Controls.Add(this.label);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "FormItemNaoPrevisto";
            this.Text = "FormItemNaoPrevisto";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownQuantidade)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPrecoUnitario)).EndInit();
            this.groupBox1.ResumeLayout(false);
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
        private System.Windows.Forms.Button buttonRemover;
        private System.Windows.Forms.Label Artigo;
        private System.Windows.Forms.ComboBox comboBoxTipoDeArtigo;
        private System.Windows.Forms.ComboBox comboBoxArtigo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonEditar;
    }
}