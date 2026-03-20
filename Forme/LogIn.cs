using Domeni;
using Forme.Controllers;
using Microsoft.IdentityModel.Tokens.Configuration;
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
    public partial class LogIn : Form
    {


        public LogIn()
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

        private void LogIn_Load(object sender, EventArgs e)
        {
            MainCoordinator.Instance.ShowLogInControl();
        }
    }
}
