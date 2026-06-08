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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelOrcamento = new System.Windows.Forms.Label();
            this.labelTotal = new System.Windows.Forms.Label();
            this.buttonVoltar = new System.Windows.Forms.Button();
            this.groupBoxItensCompra = new System.Windows.Forms.GroupBox();
            this.listBoxListaDeArtigos = new System.Windows.Forms.ListBox();
            this.buttonEditar = new System.Windows.Forms.Button();
            this.buttonRemover = new System.Windows.Forms.Button();
            this.groupBoxArtigosDisponiveisBox = new System.Windows.Forms.GroupBox();
            this.comboBoxFiltroTipo = new System.Windows.Forms.ComboBox();
            this.labelFiltro = new System.Windows.Forms.Label();
            this.listBoxArtigosDisponiveis = new System.Windows.Forms.ListBox();
            this.buttonAdicionar = new System.Windows.Forms.Button();
            this.groupBoxDados = new System.Windows.Forms.GroupBox();
            this.textBoxNomeCompra = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.numericUpDownMes = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDownQuantidade = new System.Windows.Forms.NumericUpDown();
            this.groupBoxListas = new System.Windows.Forms.GroupBox();
            this.listBoxListaDeCompras = new System.Windows.Forms.ListBox();
            this.buttonCriarLista = new System.Windows.Forms.Button();
            this.buttonApagarLista = new System.Windows.Forms.Button();
            this.buttonGuardar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBoxItensCompra.SuspendLayout();
            this.groupBoxArtigosDisponiveisBox.SuspendLayout();
            this.groupBoxDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownQuantidade)).BeginInit();
            this.groupBoxListas.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CasaPoupanca.Properties.Resources.final_removebg_preview;
            this.pictureBox1.Location = new System.Drawing.Point(9, 10);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(75, 49);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(97, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 20);
            this.label1.TabIndex = 18;
            this.label1.Text = "Criar/Editar Compra";
            // 
            // labelOrcamento
            // 
            this.labelOrcamento.AutoSize = true;
            this.labelOrcamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelOrcamento.Location = new System.Drawing.Point(97, 40);
            this.labelOrcamento.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelOrcamento.Name = "labelOrcamento";
            this.labelOrcamento.Size = new System.Drawing.Size(122, 17);
            this.labelOrcamento.TabIndex = 34;
            this.labelOrcamento.Text = "Orçamento: €0,00";
            // 
            // labelTotal
            // 
            this.labelTotal.AutoSize = true;
            this.labelTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.labelTotal.Location = new System.Drawing.Point(97, 61);
            this.labelTotal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(96, 17);
            this.labelTotal.TabIndex = 35;
            this.labelTotal.Text = "Total: €0,00";
            // 
            // buttonVoltar
            // 
            this.buttonVoltar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonVoltar.Location = new System.Drawing.Point(9, 422);
            this.buttonVoltar.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.buttonVoltar.Name = "buttonVoltar";
            this.buttonVoltar.Size = new System.Drawing.Size(150, 29);
            this.buttonVoltar.TabIndex = 42;
            this.buttonVoltar.Text = "Voltar";
            this.buttonVoltar.UseVisualStyleBackColor = true;
            this.buttonVoltar.Click += new System.EventHandler(this.buttonVoltar_Click_1);
            // 
            // groupBoxItensCompra
            // 
            this.groupBoxItensCompra.Controls.Add(this.listBoxListaDeArtigos);
            this.groupBoxItensCompra.Controls.Add(this.buttonEditar);
            this.groupBoxItensCompra.Controls.Add(this.buttonRemover);
            this.groupBoxItensCompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.groupBoxItensCompra.Location = new System.Drawing.Point(9, 98);
            this.groupBoxItensCompra.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBoxItensCompra.Name = "groupBoxItensCompra";
            this.groupBoxItensCompra.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBoxItensCompra.Size = new System.Drawing.Size(225, 309);
            this.groupBoxItensCompra.TabIndex = 36;
            this.groupBoxItensCompra.TabStop = false;
            this.groupBoxItensCompra.Text = "Itens da Compra";
            // 
            // listBoxListaDeArtigos
            // 
            this.listBoxListaDeArtigos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.listBoxListaDeArtigos.FormattingEnabled = true;
            this.listBoxListaDeArtigos.ItemHeight = 15;
            this.listBoxListaDeArtigos.Location = new System.Drawing.Point(7, 20);
            this.listBoxListaDeArtigos.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.listBoxListaDeArtigos.Name = "listBoxListaDeArtigos";
            this.listBoxListaDeArtigos.Size = new System.Drawing.Size(211, 184);
            this.listBoxListaDeArtigos.TabIndex = 43;
            this.listBoxListaDeArtigos.SelectedIndexChanged += new System.EventHandler(this.listBoxListaDeArtigos_SelectedIndexChanged_1);
            // 
            // buttonEditar
            // 
            this.buttonEditar.BackColor = System.Drawing.Color.LightBlue;
            this.buttonEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEditar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.buttonEditar.Location = new System.Drawing.Point(120, 227);
            this.buttonEditar.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.buttonEditar.Name = "buttonEditar";
            this.buttonEditar.Size = new System.Drawing.Size(97, 29);
            this.buttonEditar.TabIndex = 55;
            this.buttonEditar.Text = "Editar Item";
            this.buttonEditar.UseVisualStyleBackColor = false;
            this.buttonEditar.Click += new System.EventHandler(this.buttonEditar_Click);
            // 
            // buttonRemover
            // 
            this.buttonRemover.BackColor = System.Drawing.Color.LightCoral;
            this.buttonRemover.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRemover.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.buttonRemover.Location = new System.Drawing.Point(7, 227);
            this.buttonRemover.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.buttonRemover.Name = "buttonRemover";
            this.buttonRemover.Size = new System.Drawing.Size(97, 29);
            this.buttonRemover.TabIndex = 56;
            this.buttonRemover.Text = "Remover Item";
            this.buttonRemover.UseVisualStyleBackColor = false;
            this.buttonRemover.Click += new System.EventHandler(this.buttonRemover_Click);
            // 
            // groupBoxArtigosDisponiveisBox
            // 
            this.groupBoxArtigosDisponiveisBox.Controls.Add(this.comboBoxFiltroTipo);
            this.groupBoxArtigosDisponiveisBox.Controls.Add(this.labelFiltro);
            this.groupBoxArtigosDisponiveisBox.Controls.Add(this.listBoxArtigosDisponiveis);
            this.groupBoxArtigosDisponiveisBox.Controls.Add(this.buttonAdicionar);
            this.groupBoxArtigosDisponiveisBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.groupBoxArtigosDisponiveisBox.Location = new System.Drawing.Point(247, 98);
            this.groupBoxArtigosDisponiveisBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBoxArtigosDisponiveisBox.Name = "groupBoxArtigosDisponiveisBox";
            this.groupBoxArtigosDisponiveisBox.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBoxArtigosDisponiveisBox.Size = new System.Drawing.Size(225, 309);
            this.groupBoxArtigosDisponiveisBox.TabIndex = 37;
            this.groupBoxArtigosDisponiveisBox.TabStop = false;
            this.groupBoxArtigosDisponiveisBox.Text = "Artigos Disponíveis";
            // 
            // comboBoxFiltroTipo
            // 
            this.comboBoxFiltroTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFiltroTipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.comboBoxFiltroTipo.FormattingEnabled = true;
            this.comboBoxFiltroTipo.Location = new System.Drawing.Point(73, 20);
            this.comboBoxFiltroTipo.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.comboBoxFiltroTipo.Name = "comboBoxFiltroTipo";
            this.comboBoxFiltroTipo.Size = new System.Drawing.Size(146, 23);
            this.comboBoxFiltroTipo.TabIndex = 51;
            this.comboBoxFiltroTipo.SelectedIndexChanged += new System.EventHandler(this.comboBoxFiltroTipo_SelectedIndexChanged_1);
            // 
            // labelFiltro
            // 
            this.labelFiltro.AutoSize = true;
            this.labelFiltro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.labelFiltro.Location = new System.Drawing.Point(7, 23);
            this.labelFiltro.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelFiltro.Name = "labelFiltro";
            this.labelFiltro.Size = new System.Drawing.Size(62, 15);
            this.labelFiltro.TabIndex = 52;
            this.labelFiltro.Text = "Filtrar por:";
            // 
            // listBoxArtigosDisponiveis
            // 
            this.listBoxArtigosDisponiveis.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.listBoxArtigosDisponiveis.FormattingEnabled = true;
            this.listBoxArtigosDisponiveis.ItemHeight = 15;
            this.listBoxArtigosDisponiveis.Location = new System.Drawing.Point(7, 49);
            this.listBoxArtigosDisponiveis.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.listBoxArtigosDisponiveis.Name = "listBoxArtigosDisponiveis";
            this.listBoxArtigosDisponiveis.Size = new System.Drawing.Size(211, 154);
            this.listBoxArtigosDisponiveis.TabIndex = 50;
            // 
            // buttonAdicionar
            // 
            this.buttonAdicionar.BackColor = System.Drawing.Color.LightGreen;
            this.buttonAdicionar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAdicionar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.buttonAdicionar.Location = new System.Drawing.Point(64, 227);
            this.buttonAdicionar.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.buttonAdicionar.Name = "buttonAdicionar";
            this.buttonAdicionar.Size = new System.Drawing.Size(97, 29);
            this.buttonAdicionar.TabIndex = 38;
            this.buttonAdicionar.Text = "Adicionar Item";
            this.buttonAdicionar.UseVisualStyleBackColor = false;
            this.buttonAdicionar.Click += new System.EventHandler(this.buttonAdicionar_Click_1);
            // 
            // groupBoxDados
            // 
            this.groupBoxDados.Controls.Add(this.textBoxNomeCompra);
            this.groupBoxDados.Controls.Add(this.label2);
            this.groupBoxDados.Controls.Add(this.label7);
            this.groupBoxDados.Controls.Add(this.numericUpDownMes);
            this.groupBoxDados.Controls.Add(this.label4);
            this.groupBoxDados.Controls.Add(this.numericUpDownQuantidade);
            this.groupBoxDados.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.groupBoxDados.Location = new System.Drawing.Point(487, 98);
            this.groupBoxDados.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBoxDados.Name = "groupBoxDados";
            this.groupBoxDados.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBoxDados.Size = new System.Drawing.Size(225, 146);
            this.groupBoxDados.TabIndex = 38;
            this.groupBoxDados.TabStop = false;
            this.groupBoxDados.Text = "Dados da Compra";
            // 
            // textBoxNomeCompra
            // 
            this.textBoxNomeCompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.textBoxNomeCompra.Location = new System.Drawing.Point(97, 25);
            this.textBoxNomeCompra.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textBoxNomeCompra.Name = "textBoxNomeCompra";
            this.textBoxNomeCompra.Size = new System.Drawing.Size(121, 21);
            this.textBoxNomeCompra.TabIndex = 30;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label2.Location = new System.Drawing.Point(7, 27);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 15);
            this.label2.TabIndex = 49;
            this.label2.Text = "Nome da Compra:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label7.Location = new System.Drawing.Point(7, 55);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 15);
            this.label7.TabIndex = 45;
            this.label7.Text = "Mês:";
            // 
            // numericUpDownMes
            // 
            this.numericUpDownMes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.numericUpDownMes.Location = new System.Drawing.Point(97, 53);
            this.numericUpDownMes.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.numericUpDownMes.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.numericUpDownMes.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownMes.Name = "numericUpDownMes";
            this.numericUpDownMes.Size = new System.Drawing.Size(60, 21);
            this.numericUpDownMes.TabIndex = 47;
            this.numericUpDownMes.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownMes.ValueChanged += new System.EventHandler(this.numericUpDownMes_ValueChanged_1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label4.Location = new System.Drawing.Point(7, 85);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 15);
            this.label4.TabIndex = 47;
            this.label4.Text = "Quantidade:";
            // 
            // numericUpDownQuantidade
            // 
            this.numericUpDownQuantidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.numericUpDownQuantidade.Location = new System.Drawing.Point(97, 81);
            this.numericUpDownQuantidade.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.numericUpDownQuantidade.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownQuantidade.Name = "numericUpDownQuantidade";
            this.numericUpDownQuantidade.Size = new System.Drawing.Size(90, 21);
            this.numericUpDownQuantidade.TabIndex = 52;
            this.numericUpDownQuantidade.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // groupBoxListas
            // 
            this.groupBoxListas.Controls.Add(this.listBoxListaDeCompras);
            this.groupBoxListas.Controls.Add(this.buttonCriarLista);
            this.groupBoxListas.Controls.Add(this.buttonApagarLista);
            this.groupBoxListas.Controls.Add(this.buttonGuardar);
            this.groupBoxListas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.groupBoxListas.Location = new System.Drawing.Point(487, 252);
            this.groupBoxListas.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBoxListas.Name = "groupBoxListas";
            this.groupBoxListas.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBoxListas.Size = new System.Drawing.Size(225, 155);
            this.groupBoxListas.TabIndex = 40;
            this.groupBoxListas.TabStop = false;
            this.groupBoxListas.Text = "Listas de Compras";
            // 
            // listBoxListaDeCompras
            // 
            this.listBoxListaDeCompras.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.listBoxListaDeCompras.FormattingEnabled = true;
            this.listBoxListaDeCompras.ItemHeight = 15;
            this.listBoxListaDeCompras.Location = new System.Drawing.Point(7, 20);
            this.listBoxListaDeCompras.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.listBoxListaDeCompras.Name = "listBoxListaDeCompras";
            this.listBoxListaDeCompras.Size = new System.Drawing.Size(211, 49);
            this.listBoxListaDeCompras.TabIndex = 40;
            this.listBoxListaDeCompras.SelectedIndexChanged += new System.EventHandler(this.listBoxListaDeCompras_SelectedIndexChanged_1);
            // 
            // buttonCriarLista
            // 
            this.buttonCriarLista.BackColor = System.Drawing.Color.LightBlue;
            this.buttonCriarLista.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCriarLista.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.buttonCriarLista.Location = new System.Drawing.Point(7, 90);
            this.buttonCriarLista.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.buttonCriarLista.Name = "buttonCriarLista";
            this.buttonCriarLista.Size = new System.Drawing.Size(97, 29);
            this.buttonCriarLista.TabIndex = 41;
            this.buttonCriarLista.Text = "Criar Lista";
            this.buttonCriarLista.UseVisualStyleBackColor = false;
            this.buttonCriarLista.Click += new System.EventHandler(this.buttonCriarLista_Click_1);
            // 
            // buttonApagarLista
            // 
            this.buttonApagarLista.BackColor = System.Drawing.Color.LightCoral;
            this.buttonApagarLista.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonApagarLista.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.buttonApagarLista.Location = new System.Drawing.Point(120, 90);
            this.buttonApagarLista.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.buttonApagarLista.Name = "buttonApagarLista";
            this.buttonApagarLista.Size = new System.Drawing.Size(97, 29);
            this.buttonApagarLista.TabIndex = 42;
            this.buttonApagarLista.Text = "Apagar Lista";
            this.buttonApagarLista.UseVisualStyleBackColor = false;
            this.buttonApagarLista.Click += new System.EventHandler(this.buttonApagarLista_Click);
            // 
            // buttonGuardar
            // 
            this.buttonGuardar.BackColor = System.Drawing.Color.Gold;
            this.buttonGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.buttonGuardar.Location = new System.Drawing.Point(64, 122);
            this.buttonGuardar.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.buttonGuardar.Name = "buttonGuardar";
            this.buttonGuardar.Size = new System.Drawing.Size(97, 29);
            this.buttonGuardar.TabIndex = 48;
            this.buttonGuardar.Text = "Guardar Compra";
            this.buttonGuardar.UseVisualStyleBackColor = false;
            this.buttonGuardar.Click += new System.EventHandler(this.buttonGuardar_Click_1);
            // 
            // FormCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(727, 467);
            this.Controls.Add(this.groupBoxListas);
            this.Controls.Add(this.groupBoxDados);
            this.Controls.Add(this.groupBoxArtigosDisponiveisBox);
            this.Controls.Add(this.groupBoxItensCompra);
            this.Controls.Add(this.labelOrcamento);
            this.Controls.Add(this.labelTotal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.buttonVoltar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MaximizeBox = false;
            this.Name = "FormCompra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestão de Compras";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBoxItensCompra.ResumeLayout(false);
            this.groupBoxArtigosDisponiveisBox.ResumeLayout(false);
            this.groupBoxArtigosDisponiveisBox.PerformLayout();
            this.groupBoxDados.ResumeLayout(false);
            this.groupBoxDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownQuantidade)).EndInit();
            this.groupBoxListas.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonAdicionar;
        private System.Windows.Forms.Button buttonRemover;
        private System.Windows.Forms.TextBox textBoxNomeCompra;
        private System.Windows.Forms.Button buttonEditar;
        private System.Windows.Forms.Button buttonVoltar;
        private System.Windows.Forms.ListBox listBoxListaDeArtigos;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelOrcamento;
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
        private System.Windows.Forms.Label labelTotal;
        private System.Windows.Forms.GroupBox groupBoxItensCompra;
        private System.Windows.Forms.GroupBox groupBoxArtigosDisponiveisBox;
        private System.Windows.Forms.GroupBox groupBoxDados;
        private System.Windows.Forms.GroupBox groupBoxListas;
        private System.Windows.Forms.ComboBox comboBoxFiltroTipo;
        private System.Windows.Forms.Label labelFiltro;
    }
}