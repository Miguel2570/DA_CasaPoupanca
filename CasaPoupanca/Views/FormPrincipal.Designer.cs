namespace CasaPoupanca
{
    partial class FormPrincipal
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPrincipal));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ficheiroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonNovaCompra = new System.Windows.Forms.Button();
            this.dataGridViewCompras = new System.Windows.Forms.DataGridView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonModoCompra = new System.Windows.Forms.Button();
            this.buttonOrcamento = new System.Windows.Forms.Button();
            this.buttonGerirUtilizadores = new System.Windows.Forms.Button();
            this.buttonPerfil = new System.Windows.Forms.Button();
            this.buttonArtigo = new System.Windows.Forms.Button();
            this.buttonGerirTipoArtigo = new System.Windows.Forms.Button();
            this.buttonExportarCSV = new System.Windows.Forms.Button();
            this.buttonEstatisticas = new System.Windows.Forms.Button();
            this.buttonLogout = new System.Windows.Forms.Button();
            this.buttonPlaneamentoCompra = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCompras)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ficheiroToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(852, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ficheiroToolStripMenuItem
            // 
            this.ficheiroToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sairToolStripMenuItem});
            this.ficheiroToolStripMenuItem.Name = "ficheiroToolStripMenuItem";
            this.ficheiroToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.ficheiroToolStripMenuItem.Text = "Ficheiro";
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            this.sairToolStripMenuItem.Size = new System.Drawing.Size(93, 22);
            this.sairToolStripMenuItem.Text = "Sair";
            this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(195, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(151, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Compras em Aberto";
            // 
            // buttonNovaCompra
            // 
            this.buttonNovaCompra.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonNovaCompra.Location = new System.Drawing.Point(667, 114);
            this.buttonNovaCompra.Name = "buttonNovaCompra";
            this.buttonNovaCompra.Size = new System.Drawing.Size(112, 42);
            this.buttonNovaCompra.TabIndex = 9;
            this.buttonNovaCompra.Text = "Gerir compras";
            this.buttonNovaCompra.UseVisualStyleBackColor = true;
            this.buttonNovaCompra.Click += new System.EventHandler(this.buttonNovaCompra_Click);
            // 
            // dataGridViewCompras
            // 
            this.dataGridViewCompras.AllowUserToAddRows = false;
            this.dataGridViewCompras.AllowUserToDeleteRows = false;
            this.dataGridViewCompras.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewCompras.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewCompras.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewCompras.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewCompras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewCompras.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewCompras.Location = new System.Drawing.Point(199, 115);
            this.dataGridViewCompras.Name = "dataGridViewCompras";
            this.dataGridViewCompras.ReadOnly = true;
            this.dataGridViewCompras.RowHeadersVisible = false;
            this.dataGridViewCompras.RowHeadersWidth = 62;
            this.dataGridViewCompras.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewCompras.Size = new System.Drawing.Size(433, 305);
            this.dataGridViewCompras.TabIndex = 12;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "interface.png");
            this.imageList2.Images.SetKeyName(1, "interface.png");
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CasaPoupanca.Properties.Resources.final_removebg_preview;
            this.pictureBox1.Location = new System.Drawing.Point(12, 41);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(112, 59);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // buttonModoCompra
            // 
            this.buttonModoCompra.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonModoCompra.Location = new System.Drawing.Point(667, 173);
            this.buttonModoCompra.Name = "buttonModoCompra";
            this.buttonModoCompra.Size = new System.Drawing.Size(112, 41);
            this.buttonModoCompra.TabIndex = 17;
            this.buttonModoCompra.Text = "Modo compra";
            this.buttonModoCompra.UseVisualStyleBackColor = true;
            this.buttonModoCompra.Click += new System.EventHandler(this.buttonModoCompra_Click);
            // 
            // buttonOrcamento
            // 
            this.buttonOrcamento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOrcamento.Location = new System.Drawing.Point(12, 115);
            this.buttonOrcamento.Name = "buttonOrcamento";
            this.buttonOrcamento.Size = new System.Drawing.Size(112, 41);
            this.buttonOrcamento.TabIndex = 18;
            this.buttonOrcamento.Text = "Gerir Orçamento";
            this.buttonOrcamento.UseVisualStyleBackColor = true;
            this.buttonOrcamento.Click += new System.EventHandler(this.buttonOrcamento_Click);
            // 
            // buttonGerirUtilizadores
            // 
            this.buttonGerirUtilizadores.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonGerirUtilizadores.Location = new System.Drawing.Point(667, 379);
            this.buttonGerirUtilizadores.Name = "buttonGerirUtilizadores";
            this.buttonGerirUtilizadores.Size = new System.Drawing.Size(112, 41);
            this.buttonGerirUtilizadores.TabIndex = 19;
            this.buttonGerirUtilizadores.Text = "Gerir Utilizadores";
            this.buttonGerirUtilizadores.UseVisualStyleBackColor = true;
            this.buttonGerirUtilizadores.Click += new System.EventHandler(this.buttonGerirUtilizadores_Click);
            // 
            // buttonPerfil
            // 
            this.buttonPerfil.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPerfil.Location = new System.Drawing.Point(667, 435);
            this.buttonPerfil.Name = "buttonPerfil";
            this.buttonPerfil.Size = new System.Drawing.Size(112, 41);
            this.buttonPerfil.TabIndex = 20;
            this.buttonPerfil.Text = "Perfil";
            this.buttonPerfil.UseVisualStyleBackColor = true;
            this.buttonPerfil.Click += new System.EventHandler(this.buttonPerfil_Click);
            // 
            // buttonArtigo
            // 
            this.buttonArtigo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonArtigo.Location = new System.Drawing.Point(12, 230);
            this.buttonArtigo.Name = "buttonArtigo";
            this.buttonArtigo.Size = new System.Drawing.Size(112, 41);
            this.buttonArtigo.TabIndex = 21;
            this.buttonArtigo.Text = "Gerir Artigos";
            this.buttonArtigo.UseVisualStyleBackColor = true;
            this.buttonArtigo.Click += new System.EventHandler(this.buttonArtigo_Click);
            // 
            // buttonGerirTipoArtigo
            // 
            this.buttonGerirTipoArtigo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonGerirTipoArtigo.Location = new System.Drawing.Point(12, 173);
            this.buttonGerirTipoArtigo.Name = "buttonGerirTipoArtigo";
            this.buttonGerirTipoArtigo.Size = new System.Drawing.Size(112, 41);
            this.buttonGerirTipoArtigo.TabIndex = 22;
            this.buttonGerirTipoArtigo.Text = "Gerir Tipo de Artigos";
            this.buttonGerirTipoArtigo.UseVisualStyleBackColor = true;
            this.buttonGerirTipoArtigo.Click += new System.EventHandler(this.buttonGerirTipoArtigo_Click);
            // 
            // buttonExportarCSV
            // 
            this.buttonExportarCSV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonExportarCSV.Location = new System.Drawing.Point(520, 435);
            this.buttonExportarCSV.Name = "buttonExportarCSV";
            this.buttonExportarCSV.Size = new System.Drawing.Size(112, 41);
            this.buttonExportarCSV.TabIndex = 23;
            this.buttonExportarCSV.Text = "Exportar CSV";
            this.buttonExportarCSV.UseVisualStyleBackColor = true;
            this.buttonExportarCSV.Click += new System.EventHandler(this.buttonExportarCSV_Click);
            // 
            // buttonEstatisticas
            // 
            this.buttonEstatisticas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonEstatisticas.Location = new System.Drawing.Point(199, 435);
            this.buttonEstatisticas.Name = "buttonEstatisticas";
            this.buttonEstatisticas.Size = new System.Drawing.Size(112, 41);
            this.buttonEstatisticas.TabIndex = 24;
            this.buttonEstatisticas.Text = "Estatisticas";
            this.buttonEstatisticas.UseVisualStyleBackColor = true;
            this.buttonEstatisticas.Click += new System.EventHandler(this.buttonEstatisticas_Click);
            // 
            // buttonLogout
            // 
            this.buttonLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonLogout.Location = new System.Drawing.Point(12, 435);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(112, 41);
            this.buttonLogout.TabIndex = 25;
            this.buttonLogout.Text = "Logout";
            this.buttonLogout.UseVisualStyleBackColor = true;
            this.buttonLogout.Click += new System.EventHandler(this.buttonLogout_Click);
            // 
            // buttonPlaneamentoCompra
            // 
            this.buttonPlaneamentoCompra.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPlaneamentoCompra.Location = new System.Drawing.Point(667, 230);
            this.buttonPlaneamentoCompra.Name = "buttonPlaneamentoCompra";
            this.buttonPlaneamentoCompra.Size = new System.Drawing.Size(112, 41);
            this.buttonPlaneamentoCompra.TabIndex = 26;
            this.buttonPlaneamentoCompra.Text = "Planemento Compra";
            this.buttonPlaneamentoCompra.UseVisualStyleBackColor = true;
            this.buttonPlaneamentoCompra.Click += new System.EventHandler(this.buttonPlaneamentoCompra_Click);
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(852, 488);
            this.Controls.Add(this.buttonPlaneamentoCompra);
            this.Controls.Add(this.buttonLogout);
            this.Controls.Add(this.buttonEstatisticas);
            this.Controls.Add(this.buttonExportarCSV);
            this.Controls.Add(this.buttonGerirTipoArtigo);
            this.Controls.Add(this.buttonArtigo);
            this.Controls.Add(this.buttonPerfil);
            this.Controls.Add(this.buttonGerirUtilizadores);
            this.Controls.Add(this.buttonOrcamento);
            this.Controls.Add(this.buttonModoCompra);
            this.Controls.Add(this.dataGridViewCompras);
            this.Controls.Add(this.buttonNovaCompra);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.pictureBox1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormPrincipal";
            this.Text = "Formulario Principal";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCompras)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ficheiroToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonNovaCompra;
        private System.Windows.Forms.DataGridView dataGridViewCompras;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonModoCompra;
        private System.Windows.Forms.Button buttonOrcamento;
        private System.Windows.Forms.Button buttonGerirUtilizadores;
        private System.Windows.Forms.Button buttonPerfil;
        private System.Windows.Forms.Button buttonArtigo;
        private System.Windows.Forms.Button buttonGerirTipoArtigo;
        private System.Windows.Forms.Button buttonExportarCSV;
        private System.Windows.Forms.Button buttonEstatisticas;
        private System.Windows.Forms.Button buttonLogout;
        private System.Windows.Forms.Button buttonPlaneamentoCompra;
    }
}