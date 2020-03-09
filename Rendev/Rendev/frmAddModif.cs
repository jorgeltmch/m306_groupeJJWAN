using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rendev
{
    public partial class frmAddModif : Form
    {
        private Map _map;
        public frmAddModif()
        {
            InitializeComponent();
            _map = new Map(ModifMap);
        }

        private void btnConfirmEvent_Click(object sender, EventArgs e)
        {

        }
    }
}
