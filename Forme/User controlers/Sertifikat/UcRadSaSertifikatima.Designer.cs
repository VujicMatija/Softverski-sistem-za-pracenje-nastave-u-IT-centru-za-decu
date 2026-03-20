namespace Forme.User_controlers
{
    partial class UcRadSaSertifikatima
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcRadSaSertifikatima));
            txtNazivSertifikata = new TextBox();
            label1 = new Label();
            btnUbaciSertifikat = new Button();
            dgvPodaci = new DataGridView();
            btnPrikazi = new Button();
            btnOmoguciIzmene = new Button();
            btnIzmeni = new Button();
            btnObrisi = new Button();
            btnPretrazi = new Button();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)dgvPodaci).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // txtNazivSertifikata
            // 
            txtNazivSertifikata.Location = new Point(56, 40);
            txtNazivSertifikata.Margin = new Padding(2);
            txtNazivSertifikata.Name = "txtNazivSertifikata";
            txtNazivSertifikata.Size = new Size(179, 23);
            txtNazivSertifikata.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(56, 16);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(90, 15);
            label1.TabIndex = 1;
            label1.Text = "Naziv sertifikata";
            // 
            // btnUbaciSertifikat
            // 
            btnUbaciSertifikat.Location = new Point(56, 72);
            btnUbaciSertifikat.Margin = new Padding(2);
            btnUbaciSertifikat.Name = "btnUbaciSertifikat";
            btnUbaciSertifikat.Size = new Size(95, 36);
            btnUbaciSertifikat.TabIndex = 2;
            btnUbaciSertifikat.Text = "Ubaci sertifikat";
            btnUbaciSertifikat.UseVisualStyleBackColor = true;

            // 
            // dgvPodaci
            // 
            dgvPodaci.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPodaci.Location = new Point(56, 121);
            dgvPodaci.Margin = new Padding(2);
            dgvPodaci.Name = "dgvPodaci";
            dgvPodaci.RowHeadersWidth = 82;
            dgvPodaci.Size = new Size(320, 118);
            dgvPodaci.TabIndex = 3;
            // 
            // btnPrikazi
            // 
            btnPrikazi.Location = new Point(253, 242);
            btnPrikazi.Margin = new Padding(2);
            btnPrikazi.Name = "btnPrikazi";
            btnPrikazi.Size = new Size(123, 40);
            btnPrikazi.TabIndex = 4;
            btnPrikazi.Text = "Prikazi selektovani sertifikat";
            btnPrikazi.UseVisualStyleBackColor = true;

            // 
            // btnOmoguciIzmene
            // 
            btnOmoguciIzmene.Location = new Point(56, 71);
            btnOmoguciIzmene.Margin = new Padding(2);
            btnOmoguciIzmene.Name = "btnOmoguciIzmene";
            btnOmoguciIzmene.Size = new Size(95, 36);
            btnOmoguciIzmene.TabIndex = 5;
            btnOmoguciIzmene.Text = "Omogući izmene";
            btnOmoguciIzmene.UseVisualStyleBackColor = true;
            btnOmoguciIzmene.Visible = false;

            // 
            // btnIzmeni
            // 
            btnIzmeni.Location = new Point(56, 72);
            btnIzmeni.Margin = new Padding(2);
            btnIzmeni.Name = "btnIzmeni";
            btnIzmeni.Size = new Size(95, 36);
            btnIzmeni.TabIndex = 6;
            btnIzmeni.Text = "Izmeni sertifikat";
            btnIzmeni.UseVisualStyleBackColor = true;
            btnIzmeni.Visible = false;

            // 
            // btnObrisi
            // 
            btnObrisi.Location = new Point(56, 242);
            btnObrisi.Margin = new Padding(2);
            btnObrisi.Name = "btnObrisi";
            btnObrisi.Size = new Size(99, 40);
            btnObrisi.TabIndex = 7;
            btnObrisi.Text = "Obrisi sertifikat";
            btnObrisi.UseVisualStyleBackColor = true;
            btnObrisi.Visible = false;

            // 
            // btnPretrazi
            // 
            btnPretrazi.Location = new Point(281, 72);
            btnPretrazi.Margin = new Padding(2);
            btnPretrazi.Name = "btnPretrazi";
            btnPretrazi.Size = new Size(95, 34);
            btnPretrazi.TabIndex = 8;
            btnPretrazi.Text = "Pretrazi sertifikat";
            btnPretrazi.UseVisualStyleBackColor = true;

            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(395, 40);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(303, 242);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 9;
            pictureBox1.TabStop = false;
            // 
            // UcRadSaSertifikatima
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pictureBox1);
            Controls.Add(btnPretrazi);
            Controls.Add(btnObrisi);
            Controls.Add(btnIzmeni);
            Controls.Add(btnOmoguciIzmene);
            Controls.Add(btnPrikazi);
            Controls.Add(dgvPodaci);
            Controls.Add(btnUbaciSertifikat);
            Controls.Add(label1);
            Controls.Add(txtNazivSertifikata);
            Margin = new Padding(2);
            Name = "UcRadSaSertifikatima";
            Size = new Size(700, 300);
            ((System.ComponentModel.ISupportInitialize)dgvPodaci).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public TextBox txtNazivSertifikata;
        public Label label1;
        public Button btnUbaciSertifikat;
        public DataGridView dgvPodaci;
        public Button btnPrikazi;
        public Button btnOmoguciIzmene;
        public Button btnIzmeni;
        public Button btnObrisi;
        public Button btnPretrazi;
        public PictureBox pictureBox1;
    }
}
