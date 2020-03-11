﻿using GMap.NET.WindowsForms;
using System;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.MapProviders;
using System.Collections.Generic;

namespace Rendev
{
    public partial class frmPrincipal : Form
    {
        private Map _map;
        public frmPrincipal()
        {
            InitializeComponent();
            _map = new Map(AddMap);
            List<PointLatLng> events = new List<PointLatLng>();
            events.Add(new PointLatLng(46.167333, 6.140081));
            events.Add(new PointLatLng(46.176789, 6.095105));
            _map.SetEventsMarker(events);
        }


        private void btnAddEvent_Click(object sender, EventArgs e)
        {
            frmAddModif frmAdd = new frmAddModif();
            if (_map.MouseClickMarker != null)
            {
                frmAdd.Map.UpdateMouseClickMarkerPosition(_map.MouseClickMarker.Position);
                if (frmAdd.ShowDialog() == DialogResult.OK)
                {
                }
            }
        }
    }
}
