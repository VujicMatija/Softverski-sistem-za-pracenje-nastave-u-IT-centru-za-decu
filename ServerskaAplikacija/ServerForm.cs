namespace ServerskaAplikacija
{
    public partial class ServerForm : Form
    {

        private Server server;

        public ServerForm()
        {
            InitializeComponent();
            btnPokreni.Enabled = true;
            btnZaustavi.Enabled = false;

        }

        private void btnPokreni_Click(object sender, EventArgs e)
        {
            server = new Server();
            btnPokreni.Enabled = false;
            btnZaustavi.Enabled = true;
            lblStatus.Text = "Server je pokrenut!";
            server.Pokreni();
        }

        private void btnZaustavi_Click(object sender, EventArgs e)
        {
            btnPokreni.Enabled = true;
            btnZaustavi.Enabled = false;
            lblStatus.Text = "Server je zaustavljen!";
            server.Stop();
        }

        private void ServerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
