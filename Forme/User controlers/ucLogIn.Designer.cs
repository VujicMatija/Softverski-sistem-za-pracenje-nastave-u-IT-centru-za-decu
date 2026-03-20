namespace Forme.User_controlers
{
    partial class ucLogIn
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
            btnPrijava = new Button();
            txtLozinka = new TextBox();
            txtKorisnickoIme = new TextBox();
            label2 = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // btnPrijava
            // 
            btnPrijava.Location = new Point(131, 149);
            btnPrijava.Name = "btnPrijava";
            btnPrijava.Size = new Size(130, 57);
            btnPrijava.TabIndex = 9;
            btnPrijava.Text = "Prijavi se";
            btnPrijava.UseVisualStyleBackColor = true;
            // 
            // txtLozinka
            // 
            txtLozinka.Location = new Point(162, 102);
            txtLozinka.Name = "txtLozinka";
            txtLozinka.PasswordChar = '*';
            txtLozinka.Size = new Size(183, 23);
            txtLozinka.TabIndex = 8;
            txtLozinka.Text = "vm123";
            // 
            // txtKorisnickoIme
            // 
            txtKorisnickoIme.Location = new Point(162, 69);
            txtKorisnickoIme.Name = "txtKorisnickoIme";
            txtKorisnickoIme.Size = new Size(183, 23);
            txtKorisnickoIme.TabIndex = 7;
            txtKorisnickoIme.Text = "vujicmatija";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(92, 105);
            label2.Name = "label2";
            label2.Size = new Size(53, 15);
            label2.TabIndex = 6;
            label2.Text = "Lozinka: ";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(57, 72);
            label1.Name = "label1";
            label1.Size = new Size(88, 15);
            label1.TabIndex = 5;
            label1.Text = "Korisničko ime:";
            // 
            // ucLogIn
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnPrijava);
            Controls.Add(txtLozinka);
            Controls.Add(txtKorisnickoIme);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "ucLogIn";
            Size = new Size(386, 271);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public Button btnPrijava;
        public TextBox txtLozinka;
        public TextBox txtKorisnickoIme;
        public Label label2;
        public Label label1;
    }
}
