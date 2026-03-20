using Domeni;
using Forme.Controllers;
using Forme.User_controlers;
using Forme.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forme
{
    public partial class PomocnaForma : Form
    {

        EvidencijaNastave evidencija;
        WorkMode mode = WorkMode.DEAFULT;

        StavkaEvidencijeNastave stavka;

        GrupaUcenika grupa;

        private void PomocnaForma_Load(object sender, EventArgs e)
        {
            
            if (evidencija != null && mode != WorkMode.DEAFULT)
            {
                MainCoordinator.Instance.ShowPrikazEvidencijeNastave(evidencija, mode);
            }
            else if (evidencija != null)
            {
                MainCoordinator.Instance.ShowRadSaStavkomEvidencijeNastave(evidencija);
            }else if(stavka != null)
            {
                MainCoordinator.Instance.ShowRadSaStavkomEvidencijeNastave(stavka);
            }else if(grupa != null)
            {
                MainCoordinator.Instance.ShowDodajUcenika(grupa);
            }
        }

        public PomocnaForma()
        {
            InitializeComponent();
        }


        public void ChangePanel(Control control)
        {

            panel1.Controls.Clear();
            panel1.Controls.Add(control);

            control.BringToFront();
            this.CenterToScreen();

        }

        public PomocnaForma(EvidencijaNastave ev, WorkMode mode)
        {
            InitializeComponent();
            evidencija = ev;
            Debug.WriteLine(ev.ToString());
            this.mode = mode;

        }

        public PomocnaForma(StavkaEvidencijeNastave stavka)
        {
            InitializeComponent();
            this.stavka = stavka;
        }

        public PomocnaForma(EvidencijaNastave evidencija)
        {
            InitializeComponent();
            this.evidencija = evidencija;
        }

       
        public PomocnaForma(GrupaUcenika grupa)
        {
            InitializeComponent();
            this.grupa = grupa;
        }
     

    
        

   
    }
}
