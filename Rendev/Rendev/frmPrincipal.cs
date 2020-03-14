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
            SetEventPoints();
        }


        private void btnAddEvent_Click(object sender, EventArgs e)
        {
            frmAddModif frmAdd = new frmAddModif();
            if (_map.MouseClickMarker != null)
            {
                frmAdd.Map.UpdateMouseClickMarkerPosition(_map.MouseClickMarker.Position);
                if (frmAdd.ShowDialog() == DialogResult.OK)
                {
                    SetEventPoints();
                }
            }
        }
        private void SetEventPoints()
        {
            ConnectionBD myConnec = ConnectionBD.getInstance();
            List<PointLatLng> values = myConnec.GetAllEventPositions();
            if (values != null)
            {
                _map.SetEventsMarker(values);
            }
        }
    }
}
