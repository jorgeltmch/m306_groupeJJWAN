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
            map.MapProvider = GMap.NET.MapProviders.OpenStreetMapProvider.Instance;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;
            GMap.NET.MapProviders.GMapProvider.UserAgent = "RenDev";
            map.MapProvider.RefererUrl = "MhMq4p3g07Z9KsKTwy9CNpMs32Fz2VSuh70rAd5h";
            GMap.NET.GeoCoderStatusCode geocode = map.SetPositionByKeywords("Geneva");
        }
    }
}
