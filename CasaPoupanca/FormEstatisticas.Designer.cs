namespace CasaPoupanca
{
    partial class FormEstatisticas
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabResumoMensal = new System.Windows.Forms.TabPage();
            this.dataGridViewResumo = new System.Windows.Forms.DataGridView();
            this.tabCompras = new System.Windows.Forms.TabPage();
            this.dataGridViewCompras = new System.Windows.Forms.DataGridView();
            this.tabSugestoes = new System.Windows.Forms.TabPage();
            this.lblSugestaoOrcamento = new System.Windows.Forms.Label();
            this.lstSugestaoCompras = new System.Windows.Forms.ListBox();
            this.btnAtualizar = new System.Windows.Forms.Button();
            this.btnExportar = new System.Windows.Forms.Button();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.labelTitulo = new System.Windows.Forms.Label();
            this.panelBotoes = new System.Windows.Forms.Panel();
            this.tabControl.SuspendLayout();
            this.tabResumoMensal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResumo)).BeginInit();
            this.tabCompras.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCompras)).BeginInit();
            this.tabSugestoes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.panelBotoes.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabResumoMensal);
            this.tabControl.Controls.Add(this.tabCompras);
            this.tabControl.Controls.Add(this.tabSugestoes);
            this.tabControl.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.tabControl.Location = new System.Drawing.Point(20, 100);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(950, 430);
            this.tabControl.TabIndex = 2;
            // 
            // tabResumoMensal
            // 
            this.tabResumoMensal.BackColor = System.Drawing.Color.White;
            this.tabResumoMensal.Controls.Add(this.dataGridViewResumo);
            this.tabResumoMensal.Location = new System.Drawing.Point(4, 29);
            this.tabResumoMensal.Name = "tabResumoMensal";
            this.tabResumoMensal.Padding = new System.Windows.Forms.Padding(10);
            this.tabResumoMensal.Size = new System.Drawing.Size(942, 397);
            this.tabResumoMensal.TabIndex = 0;
            this.tabResumoMensal.Text = "📅 Resumo Mensal";
            // 
            // dataGridViewResumo
            // 
            this.dataGridViewResumo.AllowUserToAddRows = false;
            this.dataGridViewResumo.AllowUserToDeleteRows = false;
            this.dataGridViewResumo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewResumo.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewResumo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewResumo.ColumnHeadersHeight = 34;
            this.dataGridViewResumo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewResumo.Location = new System.Drawing.Point(10, 10);
            this.dataGridViewResumo.Name = "dataGridViewResumo";
            this.dataGridViewResumo.ReadOnly = true;
            this.dataGridViewResumo.RowHeadersWidth = 40;
            this.dataGridViewResumo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewResumo.Size = new System.Drawing.Size(922, 377);
            this.dataGridViewResumo.TabIndex = 0;
            this.dataGridViewResumo.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewResumo_CellContentClick);
            // 
            // tabCompras
            // 
            this.tabCompras.BackColor = System.Drawing.Color.White;
            this.tabCompras.Controls.Add(this.dataGridViewCompras);
            this.tabCompras.Location = new System.Drawing.Point(4, 29);
            this.tabCompras.Name = "tabCompras";
            this.tabCompras.Padding = new System.Windows.Forms.Padding(10);
            this.tabCompras.Size = new System.Drawing.Size(942, 397);
            this.tabCompras.TabIndex = 1;
            this.tabCompras.Text = "📋 % de Compras";
            // 
            // dataGridViewCompras
            // 
            this.dataGridViewCompras.AllowUserToAddRows = false;
            this.dataGridViewCompras.AllowUserToDeleteRows = false;
            this.dataGridViewCompras.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewCompras.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewCompras.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewCompras.ColumnHeadersHeight = 34;
            this.dataGridViewCompras.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewCompras.Location = new System.Drawing.Point(10, 10);
            this.dataGridViewCompras.Name = "dataGridViewCompras";
            this.dataGridViewCompras.ReadOnly = true;
            this.dataGridViewCompras.RowHeadersWidth = 40;
            this.dataGridViewCompras.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewCompras.Size = new System.Drawing.Size(922, 377);
            this.dataGridViewCompras.TabIndex = 0;
            // 
            // tabSugestoes
            // 
            this.tabSugestoes.BackColor = System.Drawing.Color.White;
            this.tabSugestoes.Controls.Add(this.lblSugestaoOrcamento);
            this.tabSugestoes.Controls.Add(this.lstSugestaoCompras);
            this.tabSugestoes.Location = new System.Drawing.Point(4, 29);
            this.tabSugestoes.Name = "tabSugestoes";
            this.tabSugestoes.Padding = new System.Windows.Forms.Padding(15);
            this.tabSugestoes.Size = new System.Drawing.Size(942, 397);
            this.tabSugestoes.TabIndex = 2;
            this.tabSugestoes.Text = "💡 Sugestões";
            // 
            // lblSugestaoOrcamento
            // 
            this.lblSugestaoOrcamento.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblSugestaoOrcamento.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.lblSugestaoOrcamento.Location = new System.Drawing.Point(15, 20);
            this.lblSugestaoOrcamento.Name = "lblSugestaoOrcamento";
            this.lblSugestaoOrcamento.Size = new System.Drawing.Size(550, 40);
            this.lblSugestaoOrcamento.TabIndex = 0;
            this.lblSugestaoOrcamento.Text = "💰 Sugestão de Orçamento: --";
            // 
            // lstSugestaoCompras
            // 
            this.lstSugestaoCompras.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.lstSugestaoCompras.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lstSugestaoCompras.ItemHeight = 20;
            this.lstSugestaoCompras.Location = new System.Drawing.Point(15, 80);
            this.lstSugestaoCompras.Name = "lstSugestaoCompras";
            this.lstSugestaoCompras.Size = new System.Drawing.Size(550, 264);
            this.lstSugestaoCompras.TabIndex = 1;
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnAtualizar.FlatAppearance.BorderSize = 0;
            this.btnAtualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAtualizar.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnAtualizar.ForeColor = System.Drawing.Color.White;
            this.btnAtualizar.Location = new System.Drawing.Point(250, 5);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(130, 40);
            this.btnAtualizar.TabIndex = 0;
            this.btnAtualizar.Text = "🔄 Atualizar";
            this.btnAtualizar.UseVisualStyleBackColor = false;
            this.btnAtualizar.Click += new System.EventHandler(this.btnAtualizar_Click);
            // 
            // btnExportar
            // 
            this.btnExportar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnExportar.FlatAppearance.BorderSize = 0;
            this.btnExportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportar.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnExportar.ForeColor = System.Drawing.Color.White;
            this.btnExportar.Location = new System.Drawing.Point(410, 5);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(130, 40);
            this.btnExportar.TabIndex = 1;
            this.btnExportar.Text = "📎 Exportar CSV";
            this.btnExportar.UseVisualStyleBackColor = false;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // btnVoltar
            // 
            this.btnVoltar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnVoltar.FlatAppearance.BorderSize = 0;
            this.btnVoltar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVoltar.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnVoltar.ForeColor = System.Drawing.Color.White;
            this.btnVoltar.Location = new System.Drawing.Point(570, 5);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(130, 40);
            this.btnVoltar.TabIndex = 2;
            this.btnVoltar.Text = "🔙 Voltar";
            this.btnVoltar.UseVisualStyleBackColor = false;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Image = global::CasaPoupanca.Properties.Resources.final_removebg_preview;
            this.pictureBoxLogo.Location = new System.Drawing.Point(20, 15);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(80, 70);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxLogo.TabIndex = 0;
            this.pictureBoxLogo.TabStop = false;
            // 
            // labelTitulo
            // 
            this.labelTitulo.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.labelTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.labelTitulo.Location = new System.Drawing.Point(110, 25);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(300, 50);
            this.labelTitulo.TabIndex = 1;
            this.labelTitulo.Text = "📊 Estatísticas";
            this.labelTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelBotoes
            // 
            this.panelBotoes.BackColor = System.Drawing.Color.Transparent;
            this.panelBotoes.Controls.Add(this.btnAtualizar);
            this.panelBotoes.Controls.Add(this.btnExportar);
            this.panelBotoes.Controls.Add(this.btnVoltar);
            this.panelBotoes.Location = new System.Drawing.Point(20, 540);
            this.panelBotoes.Name = "panelBotoes";
            this.panelBotoes.Size = new System.Drawing.Size(950, 50);
            this.panelBotoes.TabIndex = 3;
            // 
            // FormEstatisticas
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(978, 594);
            this.Controls.Add(this.pictureBoxLogo);
            this.Controls.Add(this.labelTitulo);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.panelBotoes);
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "FormEstatisticas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "📊 Estatísticas";
            this.tabControl.ResumeLayout(false);
            this.tabResumoMensal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResumo)).EndInit();
            this.tabCompras.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCompras)).EndInit();
            this.tabSugestoes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.panelBotoes.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #region Atributos

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabResumoMensal;
        private System.Windows.Forms.TabPage tabCompras;
        private System.Windows.Forms.TabPage tabSugestoes;
        private System.Windows.Forms.DataGridView dataGridViewResumo;
        private System.Windows.Forms.DataGridView dataGridViewCompras;
        private System.Windows.Forms.Label lblSugestaoOrcamento;
        private System.Windows.Forms.ListBox lstSugestaoCompras;
        private System.Windows.Forms.Button btnAtualizar;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.Panel panelBotoes;

        #endregion
    }
}