namespace ServerskaAplikacija
{
    partial class ServerForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServerForm));
            panel1 = new Panel();
            lblStatus = new Label();
            btnZaustavi = new Button();
            btnPokreni = new Button();
            pictureBox1 = new PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(lblStatus);
            panel1.Controls.Add(btnZaustavi);
            panel1.Controls.Add(btnPokreni);
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(7, 8);
            panel1.Margin = new Padding(2);
            panel1.Name = "panel1";
            panel1.Size = new Size(597, 266);
            panel1.TabIndex = 0;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            lblStatus.Location = new Point(54, 167);
            lblStatus.Margin = new Padding(2, 0, 2, 0);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(199, 28);
            lblStatus.TabIndex = 2;
            lblStatus.Text = "Server nije pokrenut";
            // 
            // btnZaustavi
            // 
            btnZaustavi.Location = new Point(169, 38);
            btnZaustavi.Margin = new Padding(2);
            btnZaustavi.Name = "btnZaustavi";
            btnZaustavi.Size = new Size(119, 69);
            btnZaustavi.TabIndex = 1;
            btnZaustavi.Text = "Zaustavi server";
            btnZaustavi.UseVisualStyleBackColor = true;
            btnZaustavi.Click += btnZaustavi_Click;
            // 
            // btnPokreni
            // 
            btnPokreni.Location = new Point(23, 38);
            btnPokreni.Margin = new Padding(2);
            btnPokreni.Name = "btnPokreni";
            btnPokreni.Size = new Size(119, 69);
            btnPokreni.TabIndex = 0;
            btnPokreni.Text = "Pokreni server";
            btnPokreni.UseVisualStyleBackColor = true;
            btnPokreni.Click += btnPokreni_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(302, 28);
            pictureBox1.Margin = new Padding(2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(294, 212);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // ServerForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(620, 281);
            Controls.Add(panel1);
            Margin = new Padding(2);
            Name = "ServerForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Praćenje nastave - Serverska aplikacija";
            FormClosed += ServerForm_FormClosed;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label lblStatus;
        private Button btnZaustavi;
        private Button btnPokreni;
        private PictureBox pictureBox1;
    }
}
