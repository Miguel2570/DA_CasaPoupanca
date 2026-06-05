namespace CasaPoupanca
{
    partial class FormModoCompra
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
            this.labelNomeCompra = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.labelOrcamentoDisponivel = new System.Windows.Forms.Label();
            this.buttonFecharCompra = new System.Windows.Forms.Button();
            this.buttonAdquirirItensPrevistos = new System.Windows.Forms.Button();
            this.buttonVoltar = new System.Windows.Forms.Button();
            this.labelAviso = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.listBoxItensPrevistos = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxQuantidade = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxPrecoUnitario = new System.Windows.Forms.TextBox();
            this.buttonAddItemNaoPrevisto = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelNomeCompra
            // 
            this.labelNomeCompra.AutoSize = true;
            this.labelNomeCompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNomeCompra.Location = new System.Drawing.Point(160, 39);
            this.labelNomeCompra.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelNomeCompra.Name = "labelNomeCompra";
            this.labelNomeCompra.Size = new System.Drawing.Size(131, 24);
            this.labelNomeCompra.TabIndex = 18;
            this.labelNomeCompra.Text = "Modo Compra";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(295, 120);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 20);
            this.label6.TabIndex = 32;
            this.label6.Text = "Itens Previstos";
            // 
            // labelOrcamentoDisponivel
            // 
            this.labelOrcamentoDisponivel.AutoSize = true;
            this.labelOrcamentoDisponivel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOrcamentoDisponivel.Location = new System.Drawing.Point(7, 121);
            this.labelOrcamentoDisponivel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelOrcamentoDisponivel.Name = "labelOrcamentoDisponivel";
            this.labelOrcamentoDisponivel.Size = new System.Drawing.Size(242, 20);
            this.labelOrcamentoDisponivel.TabIndex = 34;
            this.labelOrcamentoDisponivel.Text = "Orçamento Disponível: 500,00 €  ";
            // 
            // buttonFecharCompra
            // 
            this.buttonFecharCompra.Location = new System.Drawing.Point(25, 390);
            this.buttonFecharCompra.Name = "buttonFecharCompra";
            this.buttonFecharCompra.Size = new System.Drawing.Size(154, 28);
            this.buttonFecharCompra.TabIndex = 39;
            this.buttonFecharCompra.Text = "Fechar Compra";
            this.buttonFecharCompra.UseVisualStyleBackColor = true;
            this.buttonFecharCompra.Click += new System.EventHandler(this.buttonFecharCompra_Click);
            // 
            // buttonAdquirirItensPrevistos
            // 
            this.buttonAdquirirItensPrevistos.Location = new System.Drawing.Point(25, 299);
            this.buttonAdquirirItensPrevistos.Name = "buttonAdquirirItensPrevistos";
            this.buttonAdquirirItensPrevistos.Size = new System.Drawing.Size(138, 28);
            this.buttonAdquirirItensPrevistos.TabIndex = 41;
            this.buttonAdquirirItensPrevistos.Text = "Adquirir Itens Previstos";
            this.buttonAdquirirItensPrevistos.UseVisualStyleBackColor = true;
            this.buttonAdquirirItensPrevistos.Click += new System.EventHandler(this.buttonAdquirirItensPrevistos_Click);
            // 
            // buttonVoltar
            // 
            this.buttonVoltar.Location = new System.Drawing.Point(25, 437);
            this.buttonVoltar.Name = "buttonVoltar";
            this.buttonVoltar.Size = new System.Drawing.Size(154, 28);
            this.buttonVoltar.TabIndex = 42;
            this.buttonVoltar.Text = "Voltar";
            this.buttonVoltar.UseVisualStyleBackColor = true;
            this.buttonVoltar.Click += new System.EventHandler(this.buttonVoltar_Click);
            // 
            // labelAviso
            // 
            this.labelAviso.AutoSize = true;
            this.labelAviso.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAviso.Location = new System.Drawing.Point(11, 154);
            this.labelAviso.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelAviso.Name = "labelAviso";
            this.labelAviso.Size = new System.Drawing.Size(241, 20);
            this.labelAviso.TabIndex = 35;
            this.labelAviso.Text = "(Alerta vermelho se ultrapassar)  ";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CasaPoupanca.Properties.Resources.final_removebg_preview;
            this.pictureBox1.Location = new System.Drawing.Point(11, 11);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(145, 86);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            // 
            // listBoxItensPrevistos
            // 
            this.listBoxItensPrevistos.FormattingEnabled = true;
            this.listBoxItensPrevistos.Location = new System.Drawing.Point(299, 164);
            this.listBoxItensPrevistos.Name = "listBoxItensPrevistos";
            this.listBoxItensPrevistos.Size = new System.Drawing.Size(476, 199);
            this.listBoxItensPrevistos.TabIndex = 43;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 210);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 45;
            this.label1.Text = "Quantidade";
            // 
            // textBoxQuantidade
            // 
            this.textBoxQuantidade.Location = new System.Drawing.Point(103, 207);
            this.textBoxQuantidade.Name = "textBoxQuantidade";
            this.textBoxQuantidade.Size = new System.Drawing.Size(100, 20);
            this.textBoxQuantidade.TabIndex = 46;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 251);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 47;
            this.label2.Text = "Preço Unitário";
            // 
            // textBoxPrecoUnitario
            // 
            this.textBoxPrecoUnitario.Location = new System.Drawing.Point(103, 248);
            this.textBoxPrecoUnitario.Name = "textBoxPrecoUnitario";
            this.textBoxPrecoUnitario.Size = new System.Drawing.Size(100, 20);
            this.textBoxPrecoUnitario.TabIndex = 48;
            // 
            // buttonAddItemNaoPrevisto
            // 
            this.buttonAddItemNaoPrevisto.Location = new System.Drawing.Point(25, 345);
            this.buttonAddItemNaoPrevisto.Name = "buttonAddItemNaoPrevisto";
            this.buttonAddItemNaoPrevisto.Size = new System.Drawing.Size(149, 28);
            this.buttonAddItemNaoPrevisto.TabIndex = 38;
            this.buttonAddItemNaoPrevisto.Text = "Adicionar Item não previsto";
            this.buttonAddItemNaoPrevisto.UseVisualStyleBackColor = true;
            this.buttonAddItemNaoPrevisto.Click += new System.EventHandler(this.buttonAddItemNaoPrevisto_Click);
            // 
            // FormModoCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 584);
            this.Controls.Add(this.textBoxPrecoUnitario);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxQuantidade);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBoxItensPrevistos);
            this.Controls.Add(this.buttonVoltar);
            this.Controls.Add(this.buttonAdquirirItensPrevistos);
            this.Controls.Add(this.buttonFecharCompra);
            this.Controls.Add(this.buttonAddItemNaoPrevisto);
            this.Controls.Add(this.labelAviso);
            this.Controls.Add(this.labelOrcamentoDisponivel);
            this.Controls.Add(this.labelNomeCompra);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.pictureBox1);
            this.Name = "FormModoCompra";
            this.Text = "FormModoCompra";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelNomeCompra;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelOrcamentoDisponivel;
        private System.Windows.Forms.Button buttonFecharCompra;
        private System.Windows.Forms.Button buttonAdquirirItensPrevistos;
        private System.Windows.Forms.Button buttonVoltar;
        private System.Windows.Forms.Label labelAviso;
        private System.Windows.Forms.ListBox listBoxItensPrevistos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxQuantidade;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxPrecoUnitario;
        private System.Windows.Forms.Button buttonAddItemNaoPrevisto;
    }
}