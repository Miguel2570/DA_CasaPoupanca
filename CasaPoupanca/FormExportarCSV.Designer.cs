namespace CasaPoupanca
{
    partial class FormExportarCSV
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
            this.groupBoxOpcoes = new System.Windows.Forms.GroupBox();
            this.radioResumoMensal = new System.Windows.Forms.RadioButton();
            this.radioComprasFechadas = new System.Windows.Forms.RadioButton();
            this.radioEstatisticasCompletas = new System.Windows.Forms.RadioButton();
            this.radioListaCompras = new System.Windows.Forms.RadioButton();
            this.radioUtilizadores = new System.Windows.Forms.RadioButton();
            this.radioArtigos = new System.Windows.Forms.RadioButton();
            this.radioOrcamentos = new System.Windows.Forms.RadioButton();
            this.btnExportar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.labelTitulo = new System.Windows.Forms.Label();
            this.labelInfo = new System.Windows.Forms.Label();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.groupBoxOpcoes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxOpcoes
            // 
            this.groupBoxOpcoes.Controls.Add(this.radioResumoMensal);
            this.groupBoxOpcoes.Controls.Add(this.radioComprasFechadas);
            this.groupBoxOpcoes.Controls.Add(this.radioEstatisticasCompletas);
            this.groupBoxOpcoes.Controls.Add(this.radioListaCompras);
            this.groupBoxOpcoes.Controls.Add(this.radioUtilizadores);
            this.groupBoxOpcoes.Controls.Add(this.radioArtigos);
            this.groupBoxOpcoes.Controls.Add(this.radioOrcamentos);
            this.groupBoxOpcoes.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.groupBoxOpcoes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.groupBoxOpcoes.Location = new System.Drawing.Point(20, 76);
            this.groupBoxOpcoes.Name = "groupBoxOpcoes";
            this.groupBoxOpcoes.Size = new System.Drawing.Size(450, 305);
            this.groupBoxOpcoes.TabIndex = 2;
            this.groupBoxOpcoes.TabStop = false;
            this.groupBoxOpcoes.Text = "Selecionar o que pretende exportar:";
            // 
            // radioResumoMensal
            // 
            this.radioResumoMensal.Checked = true;
            this.radioResumoMensal.Location = new System.Drawing.Point(20, 35);
            this.radioResumoMensal.Name = "radioResumoMensal";
            this.radioResumoMensal.Size = new System.Drawing.Size(400, 30);
            this.radioResumoMensal.TabIndex = 0;
            this.radioResumoMensal.TabStop = true;
            this.radioResumoMensal.Text = "📅 Resumo Mensal (Orçamento, Gasto, Diferença)";
            // 
            // radioComprasFechadas
            // 
            this.radioComprasFechadas.Location = new System.Drawing.Point(20, 70);
            this.radioComprasFechadas.Name = "radioComprasFechadas";
            this.radioComprasFechadas.Size = new System.Drawing.Size(400, 30);
            this.radioComprasFechadas.TabIndex = 1;
            this.radioComprasFechadas.Text = "📋 Compras Fechadas (detalhe de itens)";
            // 
            // radioEstatisticasCompletas
            // 
            this.radioEstatisticasCompletas.Location = new System.Drawing.Point(20, 105);
            this.radioEstatisticasCompletas.Name = "radioEstatisticasCompletas";
            this.radioEstatisticasCompletas.Size = new System.Drawing.Size(400, 30);
            this.radioEstatisticasCompletas.TabIndex = 2;
            this.radioEstatisticasCompletas.Text = "📊 Estatísticas Completas (tudo)";
            // 
            // radioListaCompras
            // 
            this.radioListaCompras.Location = new System.Drawing.Point(20, 140);
            this.radioListaCompras.Name = "radioListaCompras";
            this.radioListaCompras.Size = new System.Drawing.Size(400, 30);
            this.radioListaCompras.TabIndex = 3;
            this.radioListaCompras.Text = "🛒 Lista de Compras (planeamento)";
            // 
            // radioUtilizadores
            // 
            this.radioUtilizadores.Location = new System.Drawing.Point(20, 175);
            this.radioUtilizadores.Name = "radioUtilizadores";
            this.radioUtilizadores.Size = new System.Drawing.Size(400, 30);
            this.radioUtilizadores.TabIndex = 4;
            this.radioUtilizadores.Text = "👥 Utilizadores";
            // 
            // radioArtigos
            // 
            this.radioArtigos.Location = new System.Drawing.Point(20, 210);
            this.radioArtigos.Name = "radioArtigos";
            this.radioArtigos.Size = new System.Drawing.Size(400, 30);
            this.radioArtigos.TabIndex = 5;
            this.radioArtigos.Text = "📦 Artigos";
            // 
            // radioOrcamentos
            // 
            this.radioOrcamentos.Location = new System.Drawing.Point(20, 245);
            this.radioOrcamentos.Name = "radioOrcamentos";
            this.radioOrcamentos.Size = new System.Drawing.Size(400, 30);
            this.radioOrcamentos.TabIndex = 6;
            this.radioOrcamentos.Text = "💰 Orçamentos";
            // 
            // btnExportar
            // 
            this.btnExportar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnExportar.FlatAppearance.BorderSize = 0;
            this.btnExportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportar.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnExportar.ForeColor = System.Drawing.Color.White;
            this.btnExportar.Location = new System.Drawing.Point(136, 429);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(130, 40);
            this.btnExportar.TabIndex = 4;
            this.btnExportar.Text = "📎 Exportar";
            this.btnExportar.UseVisualStyleBackColor = false;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(306, 429);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(130, 40);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "❌ Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // labelTitulo
            // 
            this.labelTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.labelTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.labelTitulo.Location = new System.Drawing.Point(90, 20);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(380, 45);
            this.labelTitulo.TabIndex = 1;
            this.labelTitulo.Text = "📎 Exportar Dados para CSV";
            this.labelTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelInfo
            // 
            this.labelInfo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.labelInfo.Location = new System.Drawing.Point(16, 384);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(450, 40);
            this.labelInfo.TabIndex = 3;
            this.labelInfo.Text = "ℹ️ O ficheiro será guardado em formato CSV (separado por ponto e vírgula)";
            this.labelInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Image = global::CasaPoupanca.Properties.Resources.final_removebg_preview;
            this.pictureBoxLogo.Location = new System.Drawing.Point(20, 15);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(60, 55);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxLogo.TabIndex = 0;
            this.pictureBoxLogo.TabStop = false;
            // 
            // FormExportarCSV
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(478, 504);
            this.Controls.Add(this.pictureBoxLogo);
            this.Controls.Add(this.labelTitulo);
            this.Controls.Add(this.groupBoxOpcoes);
            this.Controls.Add(this.labelInfo);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.btnCancelar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormExportarCSV";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "📎 Exportar Dados para CSV";
            this.groupBoxOpcoes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #region Atributos

        private System.Windows.Forms.GroupBox groupBoxOpcoes;
        private System.Windows.Forms.RadioButton radioResumoMensal;
        private System.Windows.Forms.RadioButton radioComprasFechadas;
        private System.Windows.Forms.RadioButton radioEstatisticasCompletas;
        private System.Windows.Forms.RadioButton radioListaCompras;
        private System.Windows.Forms.RadioButton radioUtilizadores;
        private System.Windows.Forms.RadioButton radioArtigos;
        private System.Windows.Forms.RadioButton radioOrcamentos;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.Label labelInfo;

        #endregion
    }
}