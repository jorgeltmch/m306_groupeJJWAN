<?php

require_once 'lib.inc.php';

//phpinfo();
$events = getEvents();

var_dump($events);

?>

<!doctype html>
<html lang="en">
  <head>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/gh/openlayers/openlayers.github.io@master/en/v6.1.1/css/ol.css" type="text/css">
    <link rel="stylesheet" href="css/style.css">
    <script src="https://cdn.jsdelivr.net/gh/openlayers/openlayers.github.io@master/en/v6.1.1/build/ol.js"></script>
    <title>Map</title>
  </head>
  <body>
    <div id="map" class="map"></div>
    <div id="status">
    </div>
	<div id="popup" class="ol-popup">
      <a href="#" id="popup-closer" class="ol-popup-closer"></a>
      <div id="popup-content"></div>
    </div>
    <script type="text/javascript"  >

            /**
 * Elements that make up the popup.
 */


var events = <?php echo json_encode($events); ?>;

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
      center: ol.proj.fromLonLat([6.1667, 46.2]), 
      zoom: 12
    })
  });



  
  
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

var highlightStyle = new ol.style.Style({
  fill: new ol.style.Fill({
    color: 'rgba(255,255,255,0.7)'
  }),
  stroke: new ol.style.Stroke({
    color: '#3399CC',
    width: 3
  })
});

var selected = null;
var status = document.getElementById('status');

map.on('pointermove', function(e) {
  if (selected !== null) {
    selected.setStyle(undefined);
    selected = null;
  }

  map.forEachFeatureAtPixel(e.pixel, function(f) {
    selected = f;
    f.setStyle(highlightStyle);
    return true;
  });

  if (selected) {
    var coordinate = e.coordinate;
    var hdms = ol.coordinate.toStringHDMS(ol.proj.toLonLat(coordinate));
    status.innerHTML = '<p>test</p>'
  } else {
    status.innerHTML = '&nbsp;';
  }
});

for (var i = 0; i < events.length; i++){
  var obj = events[i];
  var lat = obj.latitude;
  var lon = obj.longitude;



  var x = ol.proj.fromLonLat([ lon , lat]);
  AddLayer(x);

}

	// Ajout des positions via la fonction 
  //AddLayer(centerLongitudeLatitude);
  //AddLayer(centerLongitudeLatitude2);


    </script>
  </body>
</html>