namespace Forme.User_controlers
{
    partial class UCdodajUcenikGrupa
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCdodajUcenikGrupa));
            dgvTrenutni = new DataGridView();
            txtImePrezime = new TextBox();
            label1 = new Label();
            btnPretrazi = new Button();
            dgvRaspolozivi = new DataGridView();
            lblGrupa = new Label();
            pictureBox1 = new PictureBox();
            btnDodaj = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvTrenutni).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvRaspolozivi).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // dgvTrenutni
            // 
            dgvTrenutni.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTrenutni.Location = new Point(273, 45);
            dgvTrenutni.Margin = new Padding(2);
            dgvTrenutni.Name = "dgvTrenutni";
            dgvTrenutni.RowHeadersWidth = 82;
            dgvTrenutni.Size = new Size(244, 208);
            dgvTrenutni.TabIndex = 0;
            // 
            // txtImePrezime
            // 
            txtImePrezime.Location = new Point(17, 45);
            txtImePrezime.Margin = new Padding(2);
            txtImePrezime.Name = "txtImePrezime";
            txtImePrezime.Size = new Size(148, 23);
            txtImePrezime.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(17, 20);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(149, 15);
            label1.TabIndex = 2;
            label1.Text = "Pretraga učenika po imenu";
            // 
            // btnPretrazi
            // 
            btnPretrazi.Location = new Point(176, 44);
            btnPretrazi.Margin = new Padding(2);
            btnPretrazi.Name = "btnPretrazi";
            btnPretrazi.Size = new Size(80, 22);
            btnPretrazi.TabIndex = 3;
            btnPretrazi.Text = "Pretraži";
            btnPretrazi.UseVisualStyleBackColor = true;
            // 
            // dgvRaspolozivi
            // 
            dgvRaspolozivi.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRaspolozivi.Location = new Point(17, 77);
            dgvRaspolozivi.Margin = new Padding(2);
            dgvRaspolozivi.Name = "dgvRaspolozivi";
            dgvRaspolozivi.RowHeadersWidth = 82;
            dgvRaspolozivi.Size = new Size(240, 176);
            dgvRaspolozivi.TabIndex = 4;
            // 
            // lblGrupa
            // 
            lblGrupa.AutoSize = true;
            lblGrupa.Location = new Point(273, 20);
            lblGrupa.Margin = new Padding(2, 0, 2, 0);
            lblGrupa.Name = "lblGrupa";
            lblGrupa.Size = new Size(83, 15);
            lblGrupa.TabIndex = 6;
            lblGrupa.Text = "Učenici grupe ";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(522, 94);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(210, 130);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            // 
            // btnDodaj
            // 
            btnDodaj.Location = new Point(17, 264);
            btnDodaj.Margin = new Padding(2);
            btnDodaj.Name = "btnDodaj";
            btnDodaj.Size = new Size(162, 22);
            btnDodaj.TabIndex = 5;
            btnDodaj.Text = "Dodaj učenika u grupi";
            btnDodaj.UseVisualStyleBackColor = true;
            // 
            // UCdodajUcenikGrupa
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pictureBox1);
            Controls.Add(lblGrupa);
            Controls.Add(btnDodaj);
            Controls.Add(dgvRaspolozivi);
            Controls.Add(btnPretrazi);
            Controls.Add(label1);
            Controls.Add(txtImePrezime);
            Controls.Add(dgvTrenutni);
            Margin = new Padding(2);
            Name = "UCdodajUcenikGrupa";
            Size = new Size(709, 300);
            ((System.ComponentModel.ISupportInitialize)dgvTrenutni).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvRaspolozivi).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public DataGridView dgvTrenutni;
        public TextBox txtImePrezime;
        public Label label1;
        public Button btnPretrazi;
        public DataGridView dgvRaspolozivi;
        public Label lblGrupa;
        public PictureBox pictureBox1;
        public Button btnDodaj;
    }
}
