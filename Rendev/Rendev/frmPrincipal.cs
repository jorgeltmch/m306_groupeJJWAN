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
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void btnAddEvent_Click(object sender, EventArgs e)
        {
            ConnectionBD myConnec = ConnectionBD.getInstance();
            //label1.Text = myConnec.getValues();
            myConnec.changeValues();
        }
    }
}
