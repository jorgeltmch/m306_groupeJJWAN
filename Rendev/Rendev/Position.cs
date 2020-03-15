using GMap.NET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rendev
{
    public class Position
    {
        // Fields...
        private int _id;
        private PointLatLng _pointLatLng;

        // Properties...
        public PointLatLng PointLatLng { get => _pointLatLng; set => _pointLatLng = value; }
        public int Id { get => _id; set => _id = value; }

        // Constructor
        public Position(int paramId, PointLatLng paramPosition)
        {
            _id = paramId;
            _pointLatLng = paramPosition;
        }

    }
}
