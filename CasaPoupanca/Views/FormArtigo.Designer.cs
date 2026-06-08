namespace CasaPoupanca
{
    partial class FormArtigo
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
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.labelArtigos = new System.Windows.Forms.Label();
            this.listBoxArtigos = new System.Windows.Forms.ListBox();
            this.labelTipo = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxTipo = new System.Windows.Forms.ComboBox();
            this.textBoxNome = new System.Windows.Forms.TextBox();
            this.labelPreco = new System.Windows.Forms.Label();
            this.numericUpDownPreco = new System.Windows.Forms.NumericUpDown();
            this.buttonAdicionar = new System.Windows.Forms.Button();
            this.buttonEditar = new System.Windows.Forms.Button();
            this.buttonRemover = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPreco)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::CasaPoupanca.Properties.Resources.final_removebg_preview;
            this.pictureBox3.Location = new System.Drawing.Point(156, 27);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(262, 192);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 22;
            this.pictureBox3.TabStop = false;
            // 
            // labelArtigos
            // 
            this.labelArtigos.AutoSize = true;
            this.labelArtigos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelArtigos.Location = new System.Drawing.Point(234, 202);
            this.labelArtigos.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelArtigos.Name = "labelArtigos";
            this.labelArtigos.Size = new System.Drawing.Size(95, 29);
            this.labelArtigos.TabIndex = 23;
            this.labelArtigos.Text = "Artigos";
            // 
            // listBoxArtigos
            // 
            this.listBoxArtigos.FormattingEnabled = true;
            this.listBoxArtigos.ItemHeight = 20;
            this.listBoxArtigos.Location = new System.Drawing.Point(31, 536);
            this.listBoxArtigos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listBoxArtigos.Name = "listBoxArtigos";
            this.listBoxArtigos.Size = new System.Drawing.Size(498, 284);
            this.listBoxArtigos.TabIndex = 24;
            this.listBoxArtigos.SelectedIndexChanged += new System.EventHandler(this.listBoxArtigos_SelectedIndexChanged);
            // 
            // labelTipo
            // 
            this.labelTipo.AutoSize = true;
            this.labelTipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTipo.Location = new System.Drawing.Point(124, 289);
            this.labelTipo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTipo.Name = "labelTipo";
            this.labelTipo.Size = new System.Drawing.Size(51, 25);
            this.labelTipo.TabIndex = 29;
            this.labelTipo.Text = "Tipo";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(112, 340);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 25);
            this.label6.TabIndex = 30;
            this.label6.Text = "Nome";
            // 
            // comboBoxTipo
            // 
            this.comboBoxTipo.FormattingEnabled = true;
            this.comboBoxTipo.Location = new System.Drawing.Point(229, 290);
            this.comboBoxTipo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBoxTipo.Name = "comboBoxTipo";
            this.comboBoxTipo.Size = new System.Drawing.Size(248, 28);
            this.comboBoxTipo.TabIndex = 31;
            this.comboBoxTipo.SelectedIndexChanged += new System.EventHandler(this.comboBoxTipo_SelectedIndexChanged_1);
            // 
            // textBoxNome
            // 
            this.textBoxNome.Location = new System.Drawing.Point(229, 341);
            this.textBoxNome.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxNome.Name = "textBoxNome";
            this.textBoxNome.Size = new System.Drawing.Size(248, 26);
            this.textBoxNome.TabIndex = 32;
            // 
            // labelPreco
            // 
            this.labelPreco.AutoSize = true;
            this.labelPreco.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPreco.Location = new System.Drawing.Point(112, 395);
            this.labelPreco.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPreco.Name = "labelPreco";
            this.labelPreco.Size = new System.Drawing.Size(63, 25);
            this.labelPreco.TabIndex = 33;
            this.labelPreco.Text = "Preço";
            // 
            // numericUpDownPreco
            // 
            this.numericUpDownPreco.Location = new System.Drawing.Point(229, 394);
            this.numericUpDownPreco.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numericUpDownPreco.Name = "numericUpDownPreco";
            this.numericUpDownPreco.Size = new System.Drawing.Size(250, 26);
            this.numericUpDownPreco.TabIndex = 34;
            // 
            // buttonAdicionar
            // 
            this.buttonAdicionar.Location = new System.Drawing.Point(94, 465);
            this.buttonAdicionar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonAdicionar.Name = "buttonAdicionar";
            this.buttonAdicionar.Size = new System.Drawing.Size(112, 35);
            this.buttonAdicionar.TabIndex = 35;
            this.buttonAdicionar.Text = "Adicionar";
            this.buttonAdicionar.UseVisualStyleBackColor = true;
            this.buttonAdicionar.Click += new System.EventHandler(this.buttonAdicionar_Click_1);
            // 
            // buttonEditar
            // 
            this.buttonEditar.Location = new System.Drawing.Point(231, 465);
            this.buttonEditar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonEditar.Name = "buttonEditar";
            this.buttonEditar.Size = new System.Drawing.Size(112, 35);
            this.buttonEditar.TabIndex = 36;
            this.buttonEditar.Text = "Editar";
            this.buttonEditar.UseVisualStyleBackColor = true;
            this.buttonEditar.Click += new System.EventHandler(this.buttonEditar_Click);
            // 
            // buttonRemover
            // 
            this.buttonRemover.Location = new System.Drawing.Point(367, 465);
            this.buttonRemover.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonRemover.Name = "buttonRemover";
            this.buttonRemover.Size = new System.Drawing.Size(112, 35);
            this.buttonRemover.TabIndex = 37;
            this.buttonRemover.Text = "Remover";
            this.buttonRemover.UseVisualStyleBackColor = true;
            this.buttonRemover.Click += new System.EventHandler(this.buttonRemover_Click_1);
            // 
            // FormArtigo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 834);
            this.Controls.Add(this.buttonRemover);
            this.Controls.Add(this.buttonEditar);
            this.Controls.Add(this.buttonAdicionar);
            this.Controls.Add(this.numericUpDownPreco);
            this.Controls.Add(this.labelPreco);
            this.Controls.Add(this.textBoxNome);
            this.Controls.Add(this.comboBoxTipo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.labelTipo);
            this.Controls.Add(this.listBoxArtigos);
            this.Controls.Add(this.labelArtigos);
            this.Controls.Add(this.pictureBox3);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormArtigo";
            this.Text = "FormArtigo";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPreco)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label labelArtigos;
        private System.Windows.Forms.ListBox listBoxArtigos;
        private System.Windows.Forms.Label labelTipo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBoxTipo;
        private System.Windows.Forms.TextBox textBoxNome;
        private System.Windows.Forms.Label labelPreco;
        private System.Windows.Forms.NumericUpDown numericUpDownPreco;
        private System.Windows.Forms.Button buttonAdicionar;
        private System.Windows.Forms.Button buttonEditar;
        private System.Windows.Forms.Button buttonRemover;
    }
}