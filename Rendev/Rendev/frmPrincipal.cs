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
            myConnec.getValues("rendev.evenement");
            //myConnec.changeValues();
            //myConnec.InsertDataEvent();
            //myConnec.Update();
            //myConnec.Delete();
            //label1.Text = myConnec.CountIdEvent().ToString();
        }
        private void AddMap_Load(object sender, EventArgs e)
        {
            AddMap.ShowCenter = false;
            AddMap.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;
            AddMap.Position = new GMap.NET.PointLatLng(46.195566, 6.110237);
        }
    }
}
