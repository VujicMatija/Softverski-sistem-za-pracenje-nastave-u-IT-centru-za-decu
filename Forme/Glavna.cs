using Domeni;
using Forme.Controllers;
using Forme.Controllers.UcenikKontroleri;
using Forme.User_controlers;
using Forme.Utils;

namespace Forme
{
    public partial class Glavna : Form
    {
        Ucitelj uciteljGlobalna = new Ucitelj();



        public Glavna(Ucitelj ucitelj)
        {
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.None;
            uciteljGlobalna = ucitelj;


            prikažiUčiteljaToolStripMenuItem.Click += (s, e) => MainCoordinator.Instance.ShowPrikazUcitelja(uciteljGlobalna);
            kreirajUčiteljaToolStripMenuItem.Click += (s, e) => MainCoordinator.Instance.ShowKreirajUcitelja();
            pretražiUčiteljaToolStripMenuItem.Click += (s, e) => MainCoordinator.Instance.ShowPretraziUcitelja();
            licenceToolStripMenuItem.Click += (s, e) => MainCoordinator.Instance.ShowPretragaLicenci();
            kreiranjeEvidencijanNastaveToolStripMenuItem.Click += (s, e) => MainCoordinator.Instance.ShowKreirajEvidencijuNastave();
            pretražiEvidencijuNastaveToolStripMenuItem.Click += (s, e) => MainCoordinator.Instance.ShowPretraziEvidencijeNastave();
            kreirajUčenikaToolStripMenuItem.Click += (s, e) => MainCoordinator.Instance.ShowKreiranjeUcenika();
            pretražiUčenikaToolStripMenuItem.Click += (s, e) => MainCoordinator.Instance.ShowPretragaUcenika();
            kreirajGrupuUčenikaToolStripMenuItem.Click += (s, e) => MainCoordinator.Instance.ShowKreirajGrupaUcenika();
            pretražiGrupuUčenikaToolStripMenuItem.Click += (s, e) => MainCoordinator.Instance.ShowPretraziGrupuUcenika();
            radSaKursevimaToolStripMenuItem.Click += (s, e) => MainCoordinator.Instance.ShowRadSaKursom();
            radSaSertifikatimaToolStripMenuItem.Click += (s, e) => MainCoordinator.Instance.ShowRadSaSertifikatom();
                
            this.CenterToScreen();
        }
        private void Glavna_Load(object sender, EventArgs e)
        {
            MainCoordinator.Instance.ShowPrikazUcitelja(uciteljGlobalna);
        }

        public void ChangePanel(Control control)
        {
            panel.Controls.Clear();

            panel.Controls.Add(control);

            control.BringToFront();
            this.CenterToScreen();


        }



    }
}
