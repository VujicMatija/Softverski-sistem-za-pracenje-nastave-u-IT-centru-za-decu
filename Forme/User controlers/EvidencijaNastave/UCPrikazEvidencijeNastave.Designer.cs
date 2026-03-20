namespace Forme.User_controlers
{
    partial class UCPrikazEvidencijeNastave
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCPrikazEvidencijeNastave));
            label1 = new Label();
            label2 = new Label();
            cbUcitelj = new ComboBox();
            cbGrupa = new ComboBox();
            dgvUcenici = new DataGridView();
            label3 = new Label();
            dgvStavke = new DataGridView();
            label4 = new Label();
            chAktivna = new CheckBox();
            datePocetak = new DateTimePicker();
            label5 = new Label();
            btnPromeni = new Button();
            btnDodajStavku = new Button();
            label6 = new Label();
            cbUcenici = new ComboBox();
            btnRestart = new Button();
            btnPrikazStavke = new Button();
            btnSacuvajPromene = new Button();
            btnOmoguciIzmene = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvUcenici).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvStavke).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(75, 46);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(40, 15);
            label1.TabIndex = 0;
            label1.Text = "Učitelj";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(29, 76);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(83, 15);
            label2.TabIndex = 1;
            label2.Text = "Grupa učenika";
            // 
            // cbUcitelj
            // 
            cbUcitelj.FormattingEnabled = true;
            cbUcitelj.Location = new Point(144, 44);
            cbUcitelj.Margin = new Padding(2);
            cbUcitelj.Name = "cbUcitelj";
            cbUcitelj.Size = new Size(143, 23);
            cbUcitelj.TabIndex = 2;
            // 
            // cbGrupa
            // 
            cbGrupa.FormattingEnabled = true;
            cbGrupa.Location = new Point(144, 76);
            cbGrupa.Margin = new Padding(2);
            cbGrupa.Name = "cbGrupa";
            cbGrupa.Size = new Size(143, 23);
            cbGrupa.TabIndex = 3;
            // 
            // dgvUcenici
            // 
            dgvUcenici.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUcenici.Location = new Point(319, 44);
            dgvUcenici.Margin = new Padding(2);
            dgvUcenici.Name = "dgvUcenici";
            dgvUcenici.RowHeadersWidth = 82;
            dgvUcenici.Size = new Size(343, 117);
            dgvUcenici.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(319, 23);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(46, 15);
            label3.TabIndex = 5;
            label3.Text = "Učenici";
            // 
            // dgvStavke
            // 
            dgvStavke.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStavke.Location = new Point(29, 236);
            dgvStavke.Margin = new Padding(2);
            dgvStavke.Name = "dgvStavke";
            dgvStavke.RowHeadersWidth = 82;
            dgvStavke.Size = new Size(633, 152);
            dgvStavke.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(30, 177);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(140, 15);
            label4.TabIndex = 7;
            label4.Text = "Stavke evidencije nastave";
            // 
            // chAktivna
            // 
            chAktivna.AutoSize = true;
            chAktivna.Location = new Point(144, 137);
            chAktivna.Margin = new Padding(2);
            chAktivna.Name = "chAktivna";
            chAktivna.Size = new Size(66, 19);
            chAktivna.TabIndex = 8;
            chAktivna.Text = "Aktivna";
            chAktivna.UseVisualStyleBackColor = true;
            // 
            // datePocetak
            // 
            datePocetak.CustomFormat = "dd/MM/yyyy";
            datePocetak.Format = DateTimePickerFormat.Custom;
            datePocetak.Location = new Point(144, 113);
            datePocetak.Margin = new Padding(2);
            datePocetak.Name = "datePocetak";
            datePocetak.Size = new Size(143, 23);
            datePocetak.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(29, 116);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(88, 15);
            label5.TabIndex = 10;
            label5.Text = "Datum početka";
            // 
            // btnPromeni
            // 
            btnPromeni.Location = new Point(540, 401);
            btnPromeni.Margin = new Padding(2);
            btnPromeni.Name = "btnPromeni";
            btnPromeni.Size = new Size(122, 48);
            btnPromeni.TabIndex = 11;
            btnPromeni.Text = "Sacuvaj izmene";
            btnPromeni.UseVisualStyleBackColor = true;
            // 
            // btnDodajStavku
            // 
            btnDodajStavku.Location = new Point(29, 399);
            btnDodajStavku.Margin = new Padding(2);
            btnDodajStavku.Name = "btnDodajStavku";
            btnDodajStavku.Size = new Size(116, 52);
            btnDodajStavku.TabIndex = 12;
            btnDodajStavku.Text = "Dodaj stavku evidencije nastave";
            btnDodajStavku.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(29, 208);
            label6.Name = "label6";
            label6.Size = new Size(141, 15);
            label6.TabIndex = 13;
            label6.Text = "Prikazi stavke za učenika: ";
            // 
            // cbUcenici
            // 
            cbUcenici.FormattingEnabled = true;
            cbUcenici.Location = new Point(189, 206);
            cbUcenici.Margin = new Padding(3, 2, 3, 2);
            cbUcenici.Name = "cbUcenici";
            cbUcenici.Size = new Size(181, 23);
            cbUcenici.TabIndex = 14;
            // 
            // btnRestart
            // 
            btnRestart.BackgroundImage = (Image)resources.GetObject("btnRestart.BackgroundImage");
            btnRestart.BackgroundImageLayout = ImageLayout.Zoom;
            btnRestart.Location = new Point(374, 208);
            btnRestart.Margin = new Padding(3, 2, 3, 2);
            btnRestart.Name = "btnRestart";
            btnRestart.Size = new Size(35, 22);
            btnRestart.TabIndex = 15;
            btnRestart.UseVisualStyleBackColor = true;
            // 
            // btnPrikazStavke
            // 
            btnPrikazStavke.Location = new Point(164, 399);
            btnPrikazStavke.Margin = new Padding(3, 2, 3, 2);
            btnPrikazStavke.Name = "btnPrikazStavke";
            btnPrikazStavke.Size = new Size(160, 52);
            btnPrikazStavke.TabIndex = 16;
            btnPrikazStavke.Text = "Prikaži stavku evidencije nastave";
            btnPrikazStavke.UseVisualStyleBackColor = true;
            // 
            // btnSacuvajPromene
            // 
            btnSacuvajPromene.Location = new Point(540, 399);
            btnSacuvajPromene.Name = "btnSacuvajPromene";
            btnSacuvajPromene.Size = new Size(122, 52);
            btnSacuvajPromene.TabIndex = 17;
            btnSacuvajPromene.Text = "Sačuvaj promene nad stavkama";
            btnSacuvajPromene.UseVisualStyleBackColor = true;
            btnSacuvajPromene.Visible = false;
            // 
            // btnOmoguciIzmene
            // 
            btnOmoguciIzmene.Location = new Point(540, 399);
            btnOmoguciIzmene.Name = "btnOmoguciIzmene";
            btnOmoguciIzmene.Size = new Size(122, 52);
            btnOmoguciIzmene.TabIndex = 18;
            btnOmoguciIzmene.Text = "Omoguci izmene";
            btnOmoguciIzmene.UseVisualStyleBackColor = true;
            // 
            // UCPrikazEvidencijeNastave
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnOmoguciIzmene);
            Controls.Add(btnSacuvajPromene);
            Controls.Add(btnPrikazStavke);
            Controls.Add(btnRestart);
            Controls.Add(cbUcenici);
            Controls.Add(label6);
            Controls.Add(btnDodajStavku);
            Controls.Add(btnPromeni);
            Controls.Add(label5);
            Controls.Add(datePocetak);
            Controls.Add(chAktivna);
            Controls.Add(label4);
            Controls.Add(dgvStavke);
            Controls.Add(label3);
            Controls.Add(dgvUcenici);
            Controls.Add(cbGrupa);
            Controls.Add(cbUcitelj);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(2);
            Name = "UCPrikazEvidencijeNastave";
            Size = new Size(700, 473);
            ((System.ComponentModel.ISupportInitialize)dgvUcenici).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvStavke).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public Label label1;
        public Label label2;
        public ComboBox cbUcitelj;
        public ComboBox cbGrupa;
        public DataGridView dgvUcenici;
        public Label label3;
        public DataGridView dgvStavke;
        public Label label4;
        public CheckBox chAktivna;
        public DateTimePicker datePocetak;
        public Label label5;
        public Button btnPromeni;
        public Button btnDodajStavku;
        public Label label6;
        public ComboBox cbUcenici;
        public Button btnRestart;
        public Button btnPrikazStavke;
        public Button btnSacuvajPromene;
        public Button btnOmoguciIzmene;
    }
}
