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
            this.dataGridViewItensPrevistos = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Artigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Adquirir = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Preço = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Subtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelOrcamentoDisponivel = new System.Windows.Forms.Label();
            this.dataGridViewItensNaoPrevistos = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonAddItemNaoPrevisto = new System.Windows.Forms.Button();
            this.buttonFecharCompra = new System.Windows.Forms.Button();
            this.buttonSalvar = new System.Windows.Forms.Button();
            this.buttonAdquirirItensPrevistos = new System.Windows.Forms.Button();
            this.buttonVoltar = new System.Windows.Forms.Button();
            this.labelAviso = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewItensPrevistos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewItensNaoPrevistos)).BeginInit();
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
            this.label6.Location = new System.Drawing.Point(21, 174);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 20);
            this.label6.TabIndex = 32;
            this.label6.Text = "Itens Previstos";
            // 
            // dataGridViewItensPrevistos
            // 
            this.dataGridViewItensPrevistos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewItensPrevistos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Artigo,
            this.Quantidade,
            this.Adquirir,
            this.Preço,
            this.Subtotal});
            this.dataGridViewItensPrevistos.Location = new System.Drawing.Point(25, 211);
            this.dataGridViewItensPrevistos.Name = "dataGridViewItensPrevistos";
            this.dataGridViewItensPrevistos.Size = new System.Drawing.Size(643, 150);
            this.dataGridViewItensPrevistos.TabIndex = 33;
            this.dataGridViewItensPrevistos.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewItensPrevistos_CellEndEdit);
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
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
            // Adquirir
            // 
            this.Adquirir.HeaderText = "Adquirir";
            this.Adquirir.Name = "Adquirir";
            // 
            // Preço
            // 
            this.Preço.HeaderText = "Preço";
            this.Preço.Name = "Preço";
            // 
            // Subtotal
            // 
            this.Subtotal.HeaderText = "Subtotal";
            this.Subtotal.Name = "Subtotal";
            // 
            // labelOrcamentoDisponivel
            // 
            this.labelOrcamentoDisponivel.AutoSize = true;
            this.labelOrcamentoDisponivel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOrcamentoDisponivel.Location = new System.Drawing.Point(256, 113);
            this.labelOrcamentoDisponivel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelOrcamentoDisponivel.Name = "labelOrcamentoDisponivel";
            this.labelOrcamentoDisponivel.Size = new System.Drawing.Size(242, 20);
            this.labelOrcamentoDisponivel.TabIndex = 34;
            this.labelOrcamentoDisponivel.Text = "Orçamento Disponível: 500,00 €  ";
            // 
            // dataGridViewItensNaoPrevistos
            // 
            this.dataGridViewItensNaoPrevistos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewItensNaoPrevistos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6});
            this.dataGridViewItensNaoPrevistos.Location = new System.Drawing.Point(25, 483);
            this.dataGridViewItensNaoPrevistos.Name = "dataGridViewItensNaoPrevistos";
            this.dataGridViewItensNaoPrevistos.Size = new System.Drawing.Size(643, 150);
            this.dataGridViewItensNaoPrevistos.TabIndex = 37;
            this.dataGridViewItensNaoPrevistos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewItensNaoPrevistos_CellClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Id";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Artigo";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Quantidade";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Adquirir";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Preço";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Subtotal";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(21, 446);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(146, 20);
            this.label4.TabIndex = 36;
            this.label4.Text = "Itens Não Previstos";
            // 
            // buttonAddItemNaoPrevisto
            // 
            this.buttonAddItemNaoPrevisto.Location = new System.Drawing.Point(25, 657);
            this.buttonAddItemNaoPrevisto.Name = "buttonAddItemNaoPrevisto";
            this.buttonAddItemNaoPrevisto.Size = new System.Drawing.Size(154, 31);
            this.buttonAddItemNaoPrevisto.TabIndex = 38;
            this.buttonAddItemNaoPrevisto.Text = "Adicionar Item não previsto";
            this.buttonAddItemNaoPrevisto.UseVisualStyleBackColor = true;
            this.buttonAddItemNaoPrevisto.Click += new System.EventHandler(this.buttonAddItemNaoPrevisto_Click);
            // 
            // buttonFecharCompra
            // 
            this.buttonFecharCompra.Location = new System.Drawing.Point(236, 762);
            this.buttonFecharCompra.Name = "buttonFecharCompra";
            this.buttonFecharCompra.Size = new System.Drawing.Size(154, 30);
            this.buttonFecharCompra.TabIndex = 39;
            this.buttonFecharCompra.Text = "Fechar Compra";
            this.buttonFecharCompra.UseVisualStyleBackColor = true;
            this.buttonFecharCompra.Click += new System.EventHandler(this.buttonFecharCompra_Click);
            // 
            // buttonSalvar
            // 
            this.buttonSalvar.Location = new System.Drawing.Point(467, 762);
            this.buttonSalvar.Name = "buttonSalvar";
            this.buttonSalvar.Size = new System.Drawing.Size(154, 30);
            this.buttonSalvar.TabIndex = 40;
            this.buttonSalvar.Text = "Salvar Progresso";
            this.buttonSalvar.UseVisualStyleBackColor = true;
            this.buttonSalvar.Click += new System.EventHandler(this.buttonSalvar_Click);
            // 
            // buttonAdquirirItensPrevistos
            // 
            this.buttonAdquirirItensPrevistos.Location = new System.Drawing.Point(25, 380);
            this.buttonAdquirirItensPrevistos.Name = "buttonAdquirirItensPrevistos";
            this.buttonAdquirirItensPrevistos.Size = new System.Drawing.Size(154, 30);
            this.buttonAdquirirItensPrevistos.TabIndex = 41;
            this.buttonAdquirirItensPrevistos.Text = "Adquirir Itens Previstos";
            this.buttonAdquirirItensPrevistos.UseVisualStyleBackColor = true;
            this.buttonAdquirirItensPrevistos.Click += new System.EventHandler(this.buttonAdquirirItensPrevistos_Click);
            // 
            // buttonVoltar
            // 
            this.buttonVoltar.Location = new System.Drawing.Point(12, 762);
            this.buttonVoltar.Name = "buttonVoltar";
            this.buttonVoltar.Size = new System.Drawing.Size(154, 30);
            this.buttonVoltar.TabIndex = 42;
            this.buttonVoltar.Text = "Voltar";
            this.buttonVoltar.UseVisualStyleBackColor = true;
            this.buttonVoltar.Click += new System.EventHandler(this.buttonVoltar_Click);
            // 
            // labelAviso
            // 
            this.labelAviso.AutoSize = true;
            this.labelAviso.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAviso.Location = new System.Drawing.Point(257, 142);
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
            // FormModoCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 830);
            this.Controls.Add(this.buttonVoltar);
            this.Controls.Add(this.buttonAdquirirItensPrevistos);
            this.Controls.Add(this.buttonSalvar);
            this.Controls.Add(this.buttonFecharCompra);
            this.Controls.Add(this.buttonAddItemNaoPrevisto);
            this.Controls.Add(this.dataGridViewItensNaoPrevistos);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labelAviso);
            this.Controls.Add(this.labelOrcamentoDisponivel);
            this.Controls.Add(this.labelNomeCompra);
            this.Controls.Add(this.dataGridViewItensPrevistos);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.pictureBox1);
            this.Name = "FormModoCompra";
            this.Text = "FormModoCompra";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewItensPrevistos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewItensNaoPrevistos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelNomeCompra;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dataGridViewItensPrevistos;
        private System.Windows.Forms.Label labelOrcamentoDisponivel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Artigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn Adquirir;
        private System.Windows.Forms.DataGridViewTextBoxColumn Preço;
        private System.Windows.Forms.DataGridViewTextBoxColumn Subtotal;
        private System.Windows.Forms.DataGridView dataGridViewItensNaoPrevistos;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonAddItemNaoPrevisto;
        private System.Windows.Forms.Button buttonFecharCompra;
        private System.Windows.Forms.Button buttonSalvar;
        private System.Windows.Forms.Button buttonAdquirirItensPrevistos;
        private System.Windows.Forms.Button buttonVoltar;
        private System.Windows.Forms.Label labelAviso;
    }
}