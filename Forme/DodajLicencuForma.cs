using Domeni;
using Forme.Controllers;
using Forme.User_controlers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forme
{
    public partial class DodajLicencuForma : Form
    {
        Ucitelj ucitelj;
        Licenca licenca;
        public DodajLicencuForma(Ucitelj ucitelj)
        {
            InitializeComponent();
            this.ucitelj = ucitelj;
          
        }

        public DodajLicencuForma(Licenca licenca)
        {
            InitializeComponent();
            this.licenca = licenca;
            
        }
        public void ChangePanel(Control control)
        {

            panel1.Controls.Clear();
            panel1.Controls.Add(control);
            control.BringToFront();

        }

        private void DodajLicencuForma_Load(object sender, EventArgs e)
        {
            if(licenca != null)
            {
                MainCoordinator.Instance.ShowKreirajLicencu(licenca);
            }
            else
            {
                MainCoordinator.Instance.ShowKreirajLicencu(ucitelj);
            }
        }
    }
}
