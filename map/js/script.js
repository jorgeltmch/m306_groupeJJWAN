      /**
 * Elements that make up the popup.
 */




var container = document.getElementById('popup');
var content = document.getElementById('popup-content');
var closer = document.getElementById('popup-closer');


/**
 * Create an overlay to anchor the popup to the map.
 */
var overlay = new ol.Overlay({
  element: container,
  autoPan: true,
  autoPanAnimation: {
    duration: 250
  }
});


/**
 * Add a click handler to hide the popup.
 * @return {boolean} Don't follow the href.
 */
closer.onclick = function() {
  overlay.setPosition(undefined);
  closer.blur();
  return false;
};


    var map = new ol.Map({
    overlays: [overlay],
    target: 'map',
    layers: [
      new ol.layer.Tile({
        source: new ol.source.OSM()
      })
    ],
    
    //Vue spawn
    view: new ol.View({
      center: ol.proj.fromLonLat([6.1667, 46.2]), // AJOUTER LAT LONG DEPUIS LA BASE
      zoom: 12
    })
  });



/**
 * Add a click handler to the map to render the popup.
 */
 map.on('singleclick', function(evt) {
  var coordinate = evt.coordinate;
  var hdms = ol.coordinate.toStringHDMS(ol.proj.toLonLat(coordinate));

  content.innerHTML = "<img src='img/paris.jpg' alt='Avatar' style='width:100%''> <div class='container'> <h4><b>" + hdms + " </b></h4> <p>Architect & Engineer</p></div>"  ;
  overlay.setPosition(coordinate);
});
  
  // Positions
  // AJOUTER LAT LONG DEPUIS LA BASE
  var centerLongitudeLatitude = ol.proj.fromLonLat([6.055692, 46.233058]);
  var centerLongitudeLatitude2 = ol.proj.fromLonLat([6.255692, 46.233058]);
  
  // Affichage
  
  function AddLayer(position) {
    var layer = new ol.layer.Vector({
    source: new ol.source.Vector({
      projection: 'EPSG:4326',
      features: [new ol.Feature(new ol.geom.Circle(position, 1000))]
    }),
    style: [
      new ol.style.Style({
        stroke: new ol.style.Stroke({
          color: 'red',
          width: 3
        }),
        fill: new ol.style.Fill({
          color: 'rgba(255, 0, 0, 0.1)'
        })
      })
    ]
  });
  // ajout layer
  map.addLayer(layer);
}

	// Ajout des positions via la fonction 
  AddLayer(centerLongitudeLatitude);
  AddLayer(centerLongitudeLatitude2);