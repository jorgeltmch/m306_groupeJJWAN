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
	<div id="popup" class="ol-popup">
      <a href="#" id="popup-closer" class="ol-popup-closer"></a>
      <div id="popup-content"></div>
    </div>
    <script type="text/javascript"  >

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
      center: ol.proj.fromLonLat([6.1667, 46.2]),
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

  //var hdms = ol.coordinate.toStringHDMS(ol.proj.toLonLat(coordinate));
  //layer.innerHTML = "<img src='img/paris.jpg' alt='Avatar' style='width:100%''> <div class='container'> <h4><b> </b></h4> <p>Architect & Engineer</p></div>"  ;
  // ajout layer
  map.addLayer(layer);
}

	// Ajout des positions via la fonction 
  // AddLayer(centerLongitudeLatitude);
  // AddLayer(centerLongitudeLatitude2);
  for (var i = 0; i < events.length; i++){
    var obj = events[i];
    var lat = obj.latitude;
    var lon = obj.longitude;



    var x = ol.proj.fromLonLat([ lon , lat]);
    AddLayer(x);

  }


    </script>
  </body>
</html>