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
            this.listBoxDetalhesCompra = new System.Windows.Forms.ListBox();
            this.labelTotalCompras = new System.Windows.Forms.Label();
            this.buttonGerirCompra = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonVoltar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.buttonNovaCompra = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxEstado
            // 
            this.comboBoxEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxEstado.FormattingEnabled = true;
            this.comboBoxEstado.Items.AddRange(new object[] {
            "Todas",
            "Aberta",
            "Fechada"});
            this.comboBoxEstado.Location = new System.Drawing.Point(71, 24);
            this.comboBoxEstado.Name = "comboBoxEstado";
            this.comboBoxEstado.Size = new System.Drawing.Size(121, 21);
            this.comboBoxEstado.TabIndex = 0;
            this.comboBoxEstado.SelectedIndexChanged += new System.EventHandler(this.comboBoxEstado_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Estado";
            // 
            // listBoxListaCompras
            // 
            this.listBoxListaCompras.FormattingEnabled = true;
            this.listBoxListaCompras.Location = new System.Drawing.Point(34, 150);
            this.listBoxListaCompras.Name = "listBoxListaCompras";
            this.listBoxListaCompras.Size = new System.Drawing.Size(407, 225);
            this.listBoxListaCompras.TabIndex = 2;
            this.listBoxListaCompras.SelectedIndexChanged += new System.EventHandler(this.listBoxListaCompras_SelectedIndexChanged_1);
            // 
            // listBoxDetalhesCompra
            // 
            this.listBoxDetalhesCompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxDetalhesCompra.FormattingEnabled = true;
            this.listBoxDetalhesCompra.Location = new System.Drawing.Point(15, 16);
            this.listBoxDetalhesCompra.Name = "listBoxDetalhesCompra";
            this.listBoxDetalhesCompra.Size = new System.Drawing.Size(421, 225);
            this.listBoxDetalhesCompra.TabIndex = 6;
            // 
            // labelTotalCompras
            // 
            this.labelTotalCompras.AutoSize = true;
            this.labelTotalCompras.Location = new System.Drawing.Point(114, 406);
            this.labelTotalCompras.Name = "labelTotalCompras";
            this.labelTotalCompras.Size = new System.Drawing.Size(147, 13);
            this.labelTotalCompras.TabIndex = 7;
            this.labelTotalCompras.Text = "Total: x compras encontradas";
            // 
            // buttonGerirCompra
            // 
            this.buttonGerirCompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGerirCompra.Location = new System.Drawing.Point(314, 19);
            this.buttonGerirCompra.Name = "buttonGerirCompra";
            this.buttonGerirCompra.Size = new System.Drawing.Size(87, 28);
            this.buttonGerirCompra.TabIndex = 8;
            this.buttonGerirCompra.Text = "Gerir Compra";
            this.buttonGerirCompra.UseVisualStyleBackColor = true;
            this.buttonGerirCompra.Click += new System.EventHandler(this.buttonGerirCompra_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CasaPoupanca.Properties.Resources.final_removebg_preview;
            this.pictureBox1.Location = new System.Drawing.Point(871, 11);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(92, 67);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            // 
            // buttonVoltar
            // 
            this.buttonVoltar.Location = new System.Drawing.Point(20, 401);
            this.buttonVoltar.Margin = new System.Windows.Forms.Padding(2);
            this.buttonVoltar.Name = "buttonVoltar";
            this.buttonVoltar.Size = new System.Drawing.Size(75, 23);
            this.buttonVoltar.TabIndex = 20;
            this.buttonVoltar.Text = "Voltar";
            this.buttonVoltar.UseVisualStyleBackColor = true;
            this.buttonVoltar.Click += new System.EventHandler(this.buttonVoltar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonNovaCompra);
            this.groupBox1.Controls.Add(this.buttonGerirCompra);
            this.groupBox1.Controls.Add(this.comboBoxEstado);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(20, 33);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(436, 71);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtrar";
            // 
            // groupBox2
            // 
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(20, 134);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(436, 262);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Lista Compras";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.listBoxDetalhesCompra);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(503, 134);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(459, 262);
            this.groupBox3.TabIndex = 23;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Lista Detalhes Compra";
            // 
            // buttonNovaCompra
            // 
            this.buttonNovaCompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNovaCompra.Location = new System.Drawing.Point(209, 19);
            this.buttonNovaCompra.Name = "buttonNovaCompra";
            this.buttonNovaCompra.Size = new System.Drawing.Size(87, 28);
            this.buttonNovaCompra.TabIndex = 9;
            this.buttonNovaCompra.Text = "Nova Compra";
            this.buttonNovaCompra.UseVisualStyleBackColor = true;
            this.buttonNovaCompra.Click += new System.EventHandler(this.buttonNovaCompra_Click);
            // 
            // FormPlaneamentoCompras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 450);
            this.Controls.Add(this.buttonVoltar);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.labelTotalCompras);
            this.Controls.Add(this.listBoxListaCompras);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Name = "FormPlaneamentoCompras";
            this.Text = "FormPlaneamentoCompras";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxEstado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBoxListaCompras;
        private System.Windows.Forms.ListBox listBoxDetalhesCompra;
        private System.Windows.Forms.Label labelTotalCompras;
        private System.Windows.Forms.Button buttonGerirCompra;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonVoltar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button buttonNovaCompra;
    }
}