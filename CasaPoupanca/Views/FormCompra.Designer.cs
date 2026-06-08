namespace CasaPoupanca
{
    partial class FormCompra
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
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonAdicionar = new System.Windows.Forms.Button();
            this.buttonRemover = new System.Windows.Forms.Button();
            this.textBoxNomeCompra = new System.Windows.Forms.TextBox();
            this.buttonEditar = new System.Windows.Forms.Button();
            this.buttonVoltar = new System.Windows.Forms.Button();
            this.listBoxListaDeArtigos = new System.Windows.Forms.ListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.labelOrcamentoAtual = new System.Windows.Forms.Label();
            this.labelTotal = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.listBoxListaDeCompras = new System.Windows.Forms.ListBox();
            this.buttonCriarLista = new System.Windows.Forms.Button();
            this.buttonApagarLista = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.listBoxArtigosDisponiveis = new System.Windows.Forms.ListBox();
            this.numericUpDownQuantidade = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDownMes = new System.Windows.Forms.NumericUpDown();
            this.buttonGuardar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.labelOrcamento = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownQuantidade)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMes)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(179, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(314, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Criação/Alteração de uma Compra";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CasaPoupanca.Properties.Resources.final_removebg_preview;
            this.pictureBox1.Location = new System.Drawing.Point(11, 10);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(142, 106);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 16);
            this.label2.TabIndex = 18;
            this.label2.Text = "Nome da Compra";
            // 
            // buttonAdicionar
            // 
            this.buttonAdicionar.Location = new System.Drawing.Point(610, 434);
            this.buttonAdicionar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonAdicionar.Name = "buttonAdicionar";
            this.buttonAdicionar.Size = new System.Drawing.Size(100, 28);
            this.buttonAdicionar.TabIndex = 23;
            this.buttonAdicionar.Text = "Adicionar";
            this.buttonAdicionar.UseVisualStyleBackColor = true;
            this.buttonAdicionar.Click += new System.EventHandler(this.buttonAdicionar_Click);
            // 
            // buttonRemover
            // 
            this.buttonRemover.Location = new System.Drawing.Point(716, 434);
            this.buttonRemover.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonRemover.Name = "buttonRemover";
            this.buttonRemover.Size = new System.Drawing.Size(100, 28);
            this.buttonRemover.TabIndex = 24;
            this.buttonRemover.Text = "Remover";
            this.buttonRemover.UseVisualStyleBackColor = true;
            this.buttonRemover.Click += new System.EventHandler(this.buttonRemover_Click);
            // 
            // textBoxNomeCompra
            // 
            this.textBoxNomeCompra.Location = new System.Drawing.Point(183, 135);
            this.textBoxNomeCompra.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxNomeCompra.Name = "textBoxNomeCompra";
            this.textBoxNomeCompra.Size = new System.Drawing.Size(160, 22);
            this.textBoxNomeCompra.TabIndex = 30;
            // 
            // buttonEditar
            // 
            this.buttonEditar.Location = new System.Drawing.Point(823, 434);
            this.buttonEditar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonEditar.Name = "buttonEditar";
            this.buttonEditar.Size = new System.Drawing.Size(100, 28);
            this.buttonEditar.TabIndex = 32;
            this.buttonEditar.Text = "Editar";
            this.buttonEditar.UseVisualStyleBackColor = true;
            this.buttonEditar.Click += new System.EventHandler(this.buttonEditar_Click);
            // 
            // buttonVoltar
            // 
            this.buttonVoltar.Location = new System.Drawing.Point(823, 510);
            this.buttonVoltar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonVoltar.Name = "buttonVoltar";
            this.buttonVoltar.Size = new System.Drawing.Size(100, 28);
            this.buttonVoltar.TabIndex = 33;
            this.buttonVoltar.Text = "Voltar";
            this.buttonVoltar.UseVisualStyleBackColor = true;
            this.buttonVoltar.Click += new System.EventHandler(this.buttonVoltar_Click);
            // 
            // listBoxListaDeArtigos
            // 
            this.listBoxListaDeArtigos.FormattingEnabled = true;
            this.listBoxListaDeArtigos.ItemHeight = 16;
            this.listBoxListaDeArtigos.Location = new System.Drawing.Point(39, 364);
            this.listBoxListaDeArtigos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listBoxListaDeArtigos.Name = "listBoxListaDeArtigos";
            this.listBoxListaDeArtigos.Size = new System.Drawing.Size(237, 164);
            this.listBoxListaDeArtigos.TabIndex = 34;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(398, 135);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 16);
            this.label7.TabIndex = 35;
            this.label7.Text = "Mês da compra";
            // 
            // labelOrcamentoAtual
            // 
            this.labelOrcamentoAtual.AutoSize = true;
            this.labelOrcamentoAtual.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelOrcamentoAtual.Location = new System.Drawing.Point(622, 54);
            this.labelOrcamentoAtual.Name = "labelOrcamentoAtual";
            this.labelOrcamentoAtual.Size = new System.Drawing.Size(231, 25);
            this.labelOrcamentoAtual.TabIndex = 37;
            this.labelOrcamentoAtual.Text = "Orcamento do mês atual:";
            // 
            // labelTotal
            // 
            this.labelTotal.AutoSize = true;
            this.labelTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelTotal.Location = new System.Drawing.Point(622, 82);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(62, 25);
            this.labelTotal.TabIndex = 38;
            this.labelTotal.Text = "Total:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(35, 180);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(173, 16);
            this.label10.TabIndex = 39;
            this.label10.Text = "Listas de compras | Abertas";
            // 
            // listBoxListaDeCompras
            // 
            this.listBoxListaDeCompras.FormattingEnabled = true;
            this.listBoxListaDeCompras.ItemHeight = 16;
            this.listBoxListaDeCompras.Location = new System.Drawing.Point(39, 206);
            this.listBoxListaDeCompras.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listBoxListaDeCompras.Name = "listBoxListaDeCompras";
            this.listBoxListaDeCompras.Size = new System.Drawing.Size(562, 100);
            this.listBoxListaDeCompras.TabIndex = 40;
            this.listBoxListaDeCompras.SelectedIndexChanged += new System.EventHandler(this.listBoxListaDeCompras_SelectedIndexChanged_1);
            // 
            // buttonCriarLista
            // 
            this.buttonCriarLista.Location = new System.Drawing.Point(605, 222);
            this.buttonCriarLista.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonCriarLista.Name = "buttonCriarLista";
            this.buttonCriarLista.Size = new System.Drawing.Size(100, 28);
            this.buttonCriarLista.TabIndex = 41;
            this.buttonCriarLista.Text = "Criar lista";
            this.buttonCriarLista.UseVisualStyleBackColor = true;
            this.buttonCriarLista.Click += new System.EventHandler(this.buttonCriarLista_Click);
            // 
            // buttonApagarLista
            // 
            this.buttonApagarLista.Location = new System.Drawing.Point(605, 254);
            this.buttonApagarLista.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonApagarLista.Name = "buttonApagarLista";
            this.buttonApagarLista.Size = new System.Drawing.Size(100, 28);
            this.buttonApagarLista.TabIndex = 42;
            this.buttonApagarLista.Text = "Apagar lista";
            this.buttonApagarLista.UseVisualStyleBackColor = true;
            this.buttonApagarLista.Click += new System.EventHandler(this.buttonApagarLista_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(338, 346);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 16);
            this.label3.TabIndex = 43;
            this.label3.Text = "Artigos disponiveis";
            // 
            // listBoxArtigosDisponiveis
            // 
            this.listBoxArtigosDisponiveis.FormattingEnabled = true;
            this.listBoxArtigosDisponiveis.ItemHeight = 16;
            this.listBoxArtigosDisponiveis.Location = new System.Drawing.Point(341, 364);
            this.listBoxArtigosDisponiveis.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listBoxArtigosDisponiveis.Name = "listBoxArtigosDisponiveis";
            this.listBoxArtigosDisponiveis.Size = new System.Drawing.Size(237, 164);
            this.listBoxArtigosDisponiveis.TabIndex = 44;
            // 
            // numericUpDownQuantidade
            // 
            this.numericUpDownQuantidade.Location = new System.Drawing.Point(697, 406);
            this.numericUpDownQuantidade.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numericUpDownQuantidade.Name = "numericUpDownQuantidade";
            this.numericUpDownQuantidade.Size = new System.Drawing.Size(226, 22);
            this.numericUpDownQuantidade.TabIndex = 45;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(606, 407);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 16);
            this.label4.TabIndex = 46;
            this.label4.Text = "Quantidade";
            // 
            // numericUpDownMes
            // 
            this.numericUpDownMes.Location = new System.Drawing.Point(520, 134);
            this.numericUpDownMes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numericUpDownMes.Name = "numericUpDownMes";
            this.numericUpDownMes.Size = new System.Drawing.Size(135, 22);
            this.numericUpDownMes.TabIndex = 47;
            this.numericUpDownMes.ValueChanged += new System.EventHandler(this.numericUpDownMes_ValueChanged);
            // 
            // buttonGuardar
            // 
            this.buttonGuardar.Location = new System.Drawing.Point(711, 222);
            this.buttonGuardar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonGuardar.Name = "buttonGuardar";
            this.buttonGuardar.Size = new System.Drawing.Size(188, 60);
            this.buttonGuardar.TabIndex = 48;
            this.buttonGuardar.Text = "Guardar Compra";
            this.buttonGuardar.UseVisualStyleBackColor = true;
            this.buttonGuardar.Click += new System.EventHandler(this.buttonGuardar_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(35, 346);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 16);
            this.label5.TabIndex = 49;
            this.label5.Text = "Lista de Artigos";
            // 
            // labelOrcamento
            // 
            this.labelOrcamento.AutoSize = true;
            this.labelOrcamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelOrcamento.Location = new System.Drawing.Point(690, 82);
            this.labelOrcamento.Name = "labelOrcamento";
            this.labelOrcamento.Size = new System.Drawing.Size(45, 25);
            this.labelOrcamento.TabIndex = 50;
            this.labelOrcamento.Text = "500";
            // 
            // FormCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(944, 549);
            this.Controls.Add(this.labelOrcamento);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.buttonGuardar);
            this.Controls.Add(this.numericUpDownMes);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numericUpDownQuantidade);
            this.Controls.Add(this.listBoxArtigosDisponiveis);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonApagarLista);
            this.Controls.Add(this.buttonCriarLista);
            this.Controls.Add(this.listBoxListaDeCompras);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.labelTotal);
            this.Controls.Add(this.labelOrcamentoAtual);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.listBoxListaDeArtigos);
            this.Controls.Add(this.buttonVoltar);
            this.Controls.Add(this.buttonEditar);
            this.Controls.Add(this.textBoxNomeCompra);
            this.Controls.Add(this.buttonRemover);
            this.Controls.Add(this.buttonAdicionar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormCompra";
            this.Text = "FormCompra";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownQuantidade)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonAdicionar;
        private System.Windows.Forms.Button buttonRemover;
        private System.Windows.Forms.TextBox textBoxNomeCompra;
        private System.Windows.Forms.Button buttonEditar;
        private System.Windows.Forms.Button buttonVoltar;
        private System.Windows.Forms.ListBox listBoxListaDeArtigos;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelOrcamentoAtual;
        private System.Windows.Forms.Label labelTotal;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ListBox listBoxListaDeCompras;
        private System.Windows.Forms.Button buttonCriarLista;
        private System.Windows.Forms.Button buttonApagarLista;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox listBoxArtigosDisponiveis;
        private System.Windows.Forms.NumericUpDown numericUpDownQuantidade;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDownMes;
        private System.Windows.Forms.Button buttonGuardar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelOrcamento;
    }
}