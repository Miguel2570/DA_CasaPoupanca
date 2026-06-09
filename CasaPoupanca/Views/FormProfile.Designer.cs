using System;

namespace CasaPoupanca
{
    partial class FormProfile
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
            this.groupBoxInfo = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelUsername = new System.Windows.Forms.Label();
            this.groupBoxStats = new System.Windows.Forms.GroupBox();
            this.labelUltimaCompraValor = new System.Windows.Forms.Label();
            this.labelUltimaCompra = new System.Windows.Forms.Label();
            this.labelTotalGastoValor = new System.Windows.Forms.Label();
            this.labelTotalGasto = new System.Windows.Forms.Label();
            this.labelTotalComprasValor = new System.Windows.Forms.Label();
            this.labelTotalCompras = new System.Windows.Forms.Label();
            this.labelDataRegistoValor = new System.Windows.Forms.Label();
            this.labelDataRegisto = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonVoltar = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.groupBoxInfo.SuspendLayout();
            this.groupBoxStats.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxInfo
            // 
            this.groupBoxInfo.Controls.Add(this.label1);
            this.groupBoxInfo.Controls.Add(this.labelUsername);
            this.groupBoxInfo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupBoxInfo.Location = new System.Drawing.Point(84, 107);
            this.groupBoxInfo.Name = "groupBoxInfo";
            this.groupBoxInfo.Size = new System.Drawing.Size(400, 83);
            this.groupBoxInfo.TabIndex = 1;
            this.groupBoxInfo.TabStop = false;
            this.groupBoxInfo.Text = "Informações Pessoais";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label1.Location = new System.Drawing.Point(102, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // labelUsername
            // 
            this.labelUsername.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelUsername.Location = new System.Drawing.Point(15, 41);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(81, 20);
            this.labelUsername.TabIndex = 0;
            this.labelUsername.Text = "Username:";
            // 
            // groupBoxStats
            // 
            this.groupBoxStats.Controls.Add(this.labelUltimaCompraValor);
            this.groupBoxStats.Controls.Add(this.labelUltimaCompra);
            this.groupBoxStats.Controls.Add(this.labelTotalGastoValor);
            this.groupBoxStats.Controls.Add(this.labelTotalGasto);
            this.groupBoxStats.Controls.Add(this.labelTotalComprasValor);
            this.groupBoxStats.Controls.Add(this.labelTotalCompras);
            this.groupBoxStats.Controls.Add(this.labelDataRegistoValor);
            this.groupBoxStats.Controls.Add(this.labelDataRegisto);
            this.groupBoxStats.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupBoxStats.Location = new System.Drawing.Point(84, 257);
            this.groupBoxStats.Name = "groupBoxStats";
            this.groupBoxStats.Size = new System.Drawing.Size(400, 150);
            this.groupBoxStats.TabIndex = 2;
            this.groupBoxStats.TabStop = false;
            this.groupBoxStats.Text = "Estatísticas da Conta";
            // 
            // labelUltimaCompraValor
            // 
            this.labelUltimaCompraValor.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelUltimaCompraValor.Location = new System.Drawing.Point(120, 100);
            this.labelUltimaCompraValor.Name = "labelUltimaCompraValor";
            this.labelUltimaCompraValor.Size = new System.Drawing.Size(260, 20);
            this.labelUltimaCompraValor.TabIndex = 7;
            this.labelUltimaCompraValor.Text = "---";
            // 
            // labelUltimaCompra
            // 
            this.labelUltimaCompra.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelUltimaCompra.Location = new System.Drawing.Point(15, 100);
            this.labelUltimaCompra.Name = "labelUltimaCompra";
            this.labelUltimaCompra.Size = new System.Drawing.Size(100, 20);
            this.labelUltimaCompra.TabIndex = 6;
            this.labelUltimaCompra.Text = "Última Compra:";
            // 
            // labelTotalGastoValor
            // 
            this.labelTotalGastoValor.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelTotalGastoValor.Location = new System.Drawing.Point(120, 80);
            this.labelTotalGastoValor.Name = "labelTotalGastoValor";
            this.labelTotalGastoValor.Size = new System.Drawing.Size(260, 20);
            this.labelTotalGastoValor.TabIndex = 5;
            this.labelTotalGastoValor.Text = "0,00 €";
            // 
            // labelTotalGasto
            // 
            this.labelTotalGasto.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelTotalGasto.Location = new System.Drawing.Point(15, 80);
            this.labelTotalGasto.Name = "labelTotalGasto";
            this.labelTotalGasto.Size = new System.Drawing.Size(100, 20);
            this.labelTotalGasto.TabIndex = 4;
            this.labelTotalGasto.Text = "Total Gasto:";
            // 
            // labelTotalComprasValor
            // 
            this.labelTotalComprasValor.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelTotalComprasValor.Location = new System.Drawing.Point(120, 60);
            this.labelTotalComprasValor.Name = "labelTotalComprasValor";
            this.labelTotalComprasValor.Size = new System.Drawing.Size(260, 20);
            this.labelTotalComprasValor.TabIndex = 3;
            this.labelTotalComprasValor.Text = "0";
            // 
            // labelTotalCompras
            // 
            this.labelTotalCompras.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelTotalCompras.Location = new System.Drawing.Point(15, 60);
            this.labelTotalCompras.Name = "labelTotalCompras";
            this.labelTotalCompras.Size = new System.Drawing.Size(116, 20);
            this.labelTotalCompras.TabIndex = 2;
            this.labelTotalCompras.Text = "Total de Compras:";
            // 
            // labelDataRegistoValor
            // 
            this.labelDataRegistoValor.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelDataRegistoValor.Location = new System.Drawing.Point(120, 40);
            this.labelDataRegistoValor.Name = "labelDataRegistoValor";
            this.labelDataRegistoValor.Size = new System.Drawing.Size(260, 20);
            this.labelDataRegistoValor.TabIndex = 1;
            this.labelDataRegistoValor.Text = "---";
            // 
            // labelDataRegisto
            // 
            this.labelDataRegisto.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelDataRegisto.Location = new System.Drawing.Point(15, 40);
            this.labelDataRegisto.Name = "labelDataRegisto";
            this.labelDataRegisto.Size = new System.Drawing.Size(100, 20);
            this.labelDataRegisto.TabIndex = 0;
            this.labelDataRegisto.Text = "Data de Registo:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CasaPoupanca.Properties.Resources.user;
            this.pictureBox1.Location = new System.Drawing.Point(239, 21);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(78, 70);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // buttonVoltar
            // 
            this.buttonVoltar.Location = new System.Drawing.Point(217, 414);
            this.buttonVoltar.Margin = new System.Windows.Forms.Padding(4);
            this.buttonVoltar.Name = "buttonVoltar";
            this.buttonVoltar.Size = new System.Drawing.Size(100, 28);
            this.buttonVoltar.TabIndex = 14;
            this.buttonVoltar.Text = "Voltar";
            this.buttonVoltar.UseVisualStyleBackColor = true;
            this.buttonVoltar.Click += new System.EventHandler(this.buttonVoltar_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::CasaPoupanca.Properties.Resources.final_removebg_preview;
            this.pictureBox2.Location = new System.Drawing.Point(12, 11);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(105, 80);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 15;
            this.pictureBox2.TabStop = false;
            // 
            // FormProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(550, 480);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.buttonVoltar);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBoxStats);
            this.Controls.Add(this.groupBoxInfo);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormProfile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormProfile";
            this.groupBoxInfo.ResumeLayout(false);
            this.groupBoxStats.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        // Controlos
        private System.Windows.Forms.GroupBox groupBoxInfo;
        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.GroupBox groupBoxStats;
        private System.Windows.Forms.Label labelUltimaCompraValor;
        private System.Windows.Forms.Label labelUltimaCompra;
        private System.Windows.Forms.Label labelTotalGastoValor;
        private System.Windows.Forms.Label labelTotalGasto;
        private System.Windows.Forms.Label labelTotalComprasValor;
        private System.Windows.Forms.Label labelTotalCompras;
        private System.Windows.Forms.Label labelDataRegistoValor;
        private System.Windows.Forms.Label labelDataRegisto;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonVoltar;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
    }
}