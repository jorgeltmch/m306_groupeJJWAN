using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms.Markers;

namespace Rendev
{
    public static class Constants
    {
        // Map constants
        public static readonly GMapProvider MAP_PROVIDER = OpenStreetMapProvider.Instance;
        public static readonly bool IS_SHOWING_CENTER = false;
        public static readonly MouseWheelZoomType ZOOM_TYPE = MouseWheelZoomType.MousePositionWithoutCenter;
        public static readonly string REFERER_URL = "MhMq4p3g07Z9KsKTwy9CNpMs32Fz2VSuh70rAd5h";
        public static readonly string USER_AGENT = "RenDev";
        public static readonly AccessMode ACCESS_MODE = AccessMode.ServerAndCache;
        public static readonly string STARTING_POSITION = "Geneva";
        public static readonly int STARTING_ZOOM = 10;
        public static readonly GMarkerGoogleType CLICK_MARKER_TYPE = GMarkerGoogleType.red_dot;
        public static readonly GMarkerGoogleType EVENT_MARKER_TYPE = GMarkerGoogleType.blue_dot;

        // Connection to DB constants
        public static readonly string CONNECTION_STRING = "server=localhost;database=rendevdb;port=3307;userid=root;password=Super";
    }
}
