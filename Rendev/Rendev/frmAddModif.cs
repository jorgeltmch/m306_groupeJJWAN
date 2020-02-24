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
        public frmAddModif()
        {
            InitializeComponent();

        }

        private void ModifMap_Load(object sender, EventArgs e)
        {
            ModifMap.ShowCenter = false;
            ModifMap.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;
            ModifMap.Position = new GMap.NET.PointLatLng(46.195566, 6.110237);
        }
    }
}
