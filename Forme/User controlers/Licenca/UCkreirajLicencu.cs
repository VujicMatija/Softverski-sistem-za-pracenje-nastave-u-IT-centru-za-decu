using Domeni;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forme.User_controlers
{
    public partial class UCkreirajLicencu : UserControl
    {
 
        public UCkreirajLicencu(Ucitelj ucitelj)
        {
            InitializeComponent();

        }

        public UCkreirajLicencu(Licenca licenca)
        {
            InitializeComponent();
      
        }


    }
}
