using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Rendev
{
    /// <summary>
    /// Class that deal with the map control
    /// </summary>
    class Map
    {
        #region Fields...
        private GMapOverlay _markers;
        private GMapMarker _mouseClickMarker;
        private List<GMapMarker> _events;
        private GMapControl _mapControl;
        #endregion

        #region Properties...
        /// <summary>
        /// Overlay that contains all the marker that will be displayed on the map
        /// </summary>
        public GMapOverlay Markers { get => _markers;}

        /// <summary>
        /// The marker that shows up when the user click on the map
        /// Is unique
        /// </summary>
        public GMapMarker MouseClickMarker { get => _mouseClickMarker;}

        /// <summary>
        /// Link to the form control to update;
        /// </summary>
        public GMapControl MapControl { get => _mapControl;}
        /// <summary>
        /// All markers of already existing events
        /// </summary>
        public List<GMapMarker> Events { get => _events; set => _events = value; }

        #endregion

        #region Constructors...
        public Map(GMapControl paramMapControl)
        {
            _events = new List<GMapMarker>();
            _mapControl = paramMapControl;
            // Create overlay and bind it to the control
            _markers = new GMapOverlay("markers");
            _mapControl.Overlays.Add(Markers);
            InitializeMapControl();
        }
        #endregion

        #region Methods...
        /// <summary>
        /// Initialize the map with all the constants from @Constants.cs
        /// </summary>
        private void InitializeMapControl()
        {
            _mapControl.MapProvider = Constants.MAP_PROVIDER;
            _mapControl.ShowCenter = Constants.IS_SHOWING_CENTER;
            _mapControl.MouseWheelZoomType = Constants.ZOOM_TYPE;
            _mapControl.MapProvider.RefererUrl = Constants.REFERER_URL;
            //GMapProvider.UserAgent = Constants.USER_AGENT;
            //GMaps.Instance.Mode = Constants.ACCESS_MODE;
            _mapControl.SetPositionByKeywords(Constants.STARTING_POSITION);
            _mapControl.Zoom = Constants.STARTING_ZOOM;

            _mapControl.MouseClick += MapControl_MouseClick;
        }
        /// <summary>
        /// Update the main marker to the given mouse position
        /// </summary>
        /// <param name="paramPositionX"></param>
        /// <param name="paramPositionY"></param>
        public void UpdateMouseClickMarkerPosition(PointLatLng paramPosition)
        {
            _markers.Markers.Remove(_mouseClickMarker);
            _mouseClickMarker = new GMarkerGoogle(paramPosition, Constants.CLICK_MARKER_TYPE);
            _markers.Markers.Add(MouseClickMarker);
        }
        public void UpdateMouseClickMarkerPosition(int paramPositionX, int paramPositionY)
        {
            UpdateMouseClickMarkerPosition(MapControl.FromLocalToLatLng(paramPositionX, paramPositionY));
        }
        public void AddMarkerAtLocation(PointLatLng paramPosition)
        {
            GMarkerGoogle _newMarker = new GMarkerGoogle(paramPosition, Constants.EVENT_MARKER_TYPE);
            _events.Add(_newMarker);
            _markers.Markers.Add(_newMarker);
        }
        /// <summary>
        /// Get the LatLong position of the mouseMarker
        /// </summary>
        /// <returns>PointLatLng --> need the using GMap.NET </returns>
        public PointLatLng GetMarkerLatLon()
        {
            return MouseClickMarker.Position;
        }
        public void SetEventsMarker(List<PointLatLng> paramEventsPositions)
        {
            paramEventsPositions.ForEach(AddMarkerAtLocation);
        }
        #endregion

        #region Events...
        /// <summary>
        /// Adds the point to the map on left click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MapControl_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                UpdateMouseClickMarkerPosition(e.X, e.Y);
            }
        }
        #endregion
    }
}
