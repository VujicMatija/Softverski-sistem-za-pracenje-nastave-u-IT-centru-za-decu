namespace Forme.User_controlers
{
    partial class UCpretraziLicencu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCpretraziLicencu));
            cbUcitelj = new ComboBox();
            cbSertifikat = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            btnResetuj = new Button();
            btnPretazi = new Button();
            dgvLicence = new DataGridView();
            btnPrikazi = new Button();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)dgvLicence).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // cbUcitelj
            // 
            cbUcitelj.FormattingEnabled = true;
            cbUcitelj.Location = new Point(90, 29);
            cbUcitelj.Margin = new Padding(2);
            cbUcitelj.Name = "cbUcitelj";
            cbUcitelj.Size = new Size(173, 23);
            cbUcitelj.TabIndex = 0;
            // 
            // cbSertifikat
            // 
            cbSertifikat.FormattingEnabled = true;
            cbSertifikat.Location = new Point(90, 65);
            cbSertifikat.Margin = new Padding(2);
            cbSertifikat.Name = "cbSertifikat";
            cbSertifikat.Size = new Size(173, 23);
            cbSertifikat.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(38, 29);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(40, 15);
            label1.TabIndex = 2;
            label1.Text = "Učitelj";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(24, 67);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(53, 15);
            label2.TabIndex = 3;
            label2.Text = "Sertifikat";
            // 
            // btnResetuj
            // 
            btnResetuj.Location = new Point(310, 29);
            btnResetuj.Margin = new Padding(2);
            btnResetuj.Name = "btnResetuj";
            btnResetuj.Size = new Size(107, 23);
            btnResetuj.TabIndex = 4;
            btnResetuj.Text = "Resetuj";
            btnResetuj.UseVisualStyleBackColor = true;
    
            // 
            // btnPretazi
            // 
            btnPretazi.Location = new Point(310, 61);
            btnPretazi.Margin = new Padding(2);
            btnPretazi.Name = "btnPretazi";
            btnPretazi.Size = new Size(107, 23);
            btnPretazi.TabIndex = 5;
            btnPretazi.Text = "Pretraži";
            btnPretazi.UseVisualStyleBackColor = true;
            // 
            // dgvLicence
            // 
            dgvLicence.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLicence.Location = new Point(24, 108);
            dgvLicence.Margin = new Padding(2);
            dgvLicence.Name = "dgvLicence";
            dgvLicence.RowHeadersWidth = 82;
            dgvLicence.Size = new Size(393, 124);
            dgvLicence.TabIndex = 6;
            // 
            // btnPrikazi
            // 
            btnPrikazi.Location = new Point(254, 247);
            btnPrikazi.Margin = new Padding(2);
            btnPrikazi.Name = "btnPrikazi";
            btnPrikazi.Size = new Size(163, 25);
            btnPrikazi.TabIndex = 7;
            btnPrikazi.Text = "Prikaži izabranu licencu";
            btnPrikazi.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(421, 47);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(307, 235);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            // 
            // UCpretraziLicencu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pictureBox1);
            Controls.Add(btnPrikazi);
            Controls.Add(dgvLicence);
            Controls.Add(btnPretazi);
            Controls.Add(btnResetuj);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cbSertifikat);
            Controls.Add(cbUcitelj);
            Margin = new Padding(2);
            Name = "UCpretraziLicencu";
            Size = new Size(700, 300);
            ((System.ComponentModel.ISupportInitialize)dgvLicence).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public ComboBox cbUcitelj;
        public ComboBox cbSertifikat;
        public Label label1;
        public Label label2;
        public Button btnResetuj;
        public Button btnPretazi;
        public DataGridView dgvLicence;
        public Button btnPrikazi;
        public PictureBox pictureBox1;
    }
}
