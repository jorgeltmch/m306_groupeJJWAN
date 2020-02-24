using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GreatMap_setup
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            map.ShowCenter = false;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerAndCache;
            map.MapProvider = GMap.NET.MapProviders.BingMapProvider.Instance;
            //map.Position = new GMap.NET.PointLatLng(46.195566, 6.110237);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GMap.NET.GeoCoderStatusCode geocode = map.SetPositionByKeywords("USA");
        }
    }
}
