namespace CasaPoupanca.Views
{
    partial class FormPlaneamentoCompras
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
            this.comboBoxEstado = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listBoxListaCompras = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.listBoxDetalhesCompra = new System.Windows.Forms.ListBox();
            this.labelTotalCompras = new System.Windows.Forms.Label();
            this.buttonGerirCompra = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonVoltar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxEstado
            // 
            this.comboBoxEstado.FormattingEnabled = true;
            this.comboBoxEstado.Location = new System.Drawing.Point(103, 113);
            this.comboBoxEstado.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxEstado.Name = "comboBoxEstado";
            this.comboBoxEstado.Size = new System.Drawing.Size(160, 24);
            this.comboBoxEstado.TabIndex = 0;
            this.comboBoxEstado.SelectedIndexChanged += new System.EventHandler(this.comboBoxEstado_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 117);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Estado";
            // 
            // listBoxListaCompras
            // 
            this.listBoxListaCompras.FormattingEnabled = true;
            this.listBoxListaCompras.ItemHeight = 16;
            this.listBoxListaCompras.Location = new System.Drawing.Point(27, 185);
            this.listBoxListaCompras.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listBoxListaCompras.Name = "listBoxListaCompras";
            this.listBoxListaCompras.Size = new System.Drawing.Size(560, 276);
            this.listBoxListaCompras.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 165);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Lista de compras";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(687, 165);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Detalhes da compra";
            // 
            // listBoxDetalhesCompra
            // 
            this.listBoxDetalhesCompra.FormattingEnabled = true;
            this.listBoxDetalhesCompra.ItemHeight = 16;
            this.listBoxDetalhesCompra.Location = new System.Drawing.Point(691, 185);
            this.listBoxDetalhesCompra.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listBoxDetalhesCompra.Name = "listBoxDetalhesCompra";
            this.listBoxDetalhesCompra.Size = new System.Drawing.Size(560, 276);
            this.listBoxDetalhesCompra.TabIndex = 6;
            // 
            // labelTotalCompras
            // 
            this.labelTotalCompras.AutoSize = true;
            this.labelTotalCompras.Location = new System.Drawing.Point(23, 481);
            this.labelTotalCompras.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTotalCompras.Name = "labelTotalCompras";
            this.labelTotalCompras.Size = new System.Drawing.Size(184, 16);
            this.labelTotalCompras.TabIndex = 7;
            this.labelTotalCompras.Text = "Total: x compras encontradas";
            // 
            // buttonGerirCompra
            // 
            this.buttonGerirCompra.Location = new System.Drawing.Point(301, 107);
            this.buttonGerirCompra.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonGerirCompra.Name = "buttonGerirCompra";
            this.buttonGerirCompra.Size = new System.Drawing.Size(116, 34);
            this.buttonGerirCompra.TabIndex = 8;
            this.buttonGerirCompra.Text = "Gerir Compra";
            this.buttonGerirCompra.UseVisualStyleBackColor = true;
            this.buttonGerirCompra.Click += new System.EventHandler(this.buttonGerirCompra_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CasaPoupanca.Properties.Resources.final_removebg_preview;
            this.pictureBox1.Location = new System.Drawing.Point(1161, 14);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(123, 82);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            // 
            // buttonVoltar
            // 
            this.buttonVoltar.Location = new System.Drawing.Point(342, 481);
            this.buttonVoltar.Name = "buttonVoltar";
            this.buttonVoltar.Size = new System.Drawing.Size(100, 28);
            this.buttonVoltar.TabIndex = 20;
            this.buttonVoltar.Text = "Voltar";
            this.buttonVoltar.UseVisualStyleBackColor = true;
            this.buttonVoltar.Click += new System.EventHandler(this.buttonVoltar_Click);
            // 
            // FormPlaneamentoCompras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1299, 554);
            this.Controls.Add(this.buttonVoltar);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.buttonGerirCompra);
            this.Controls.Add(this.labelTotalCompras);
            this.Controls.Add(this.listBoxDetalhesCompra);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listBoxListaCompras);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxEstado);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormPlaneamentoCompras";
            this.Text = "FormPlaneamentoCompras";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxEstado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBoxListaCompras;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox listBoxDetalhesCompra;
        private System.Windows.Forms.Label labelTotalCompras;
        private System.Windows.Forms.Button buttonGerirCompra;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonVoltar;
    }
}