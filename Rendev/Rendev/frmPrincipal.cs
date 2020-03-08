using GMap.NET.WindowsForms;
using System;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.MapProviders;

namespace Rendev
{
    public partial class frmPrincipal : Form
    {
        private Map _map;
        public frmPrincipal()
        {
            InitializeComponent();
            _map = new Map(AddMap);
        }


        private void btnAddEvent_Click(object sender, EventArgs e)
        {
            ConnectionBD myConnec = ConnectionBD.getInstance();
            //label1.Text = myConnec.getValues();
            //myConnec.changeValues();
            //myConnec.InsertDataEvent();
            //myConnec.Update();
            myConnec.Delete();
        }
    }
}
