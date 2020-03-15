<?php

require_once 'lib.inc.php';

$idSelected = (empty($_POST['idHidden'])) ? "" : $_POST['idHidden'];


//phpinfo();
$events = getEvents();

$x = 2;

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
<?php 
if (!empty($idSelected)) {
  $postAAfficher = getEventByID($idSelected);
  echo displayEvent($postAAfficher);
}
?>
  <form method="POST" action="#" id="sendId">
      <input type="hidden" id="idHidden" name="idHidden" value="" />
    </form>


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
var latSelected = <?php echo json_encode(getEventByID($idSelected)[0]["latitude"]); ?>;
var longSelected = <?php echo json_encode(getEventByID($idSelected)[0]["longitude"]); ?>;

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
      center: ol.proj.fromLonLat([longSelected, latSelected]), 
      zoom: 12
    })
  });
  
  // Affichage
  
  function AddLayer(position, idEvent) {
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


// prend 'id
  layer.idE = idEvent;
  // var x avec id
  var idLayer = layer.idE;


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


map.on('click', function(e) {
  var feature = map.forEachFeatureAtPixel(e.pixel,
  function(feature, layer) {
    feature.id_ = layer.idE;
    document.getElementById("idHidden").value = feature.id_;
    document.getElementById("sendId").submit();

    return feature;
  }
);
});

for (var i = 0; i < events.length; i++){
  var obj = events[i];
  var lat = obj.latitude;
  var lon = obj.longitude;

  var id = obj.idEvenement;



  var x = ol.proj.fromLonLat([ lon , lat]);

  AddLayer(x, id);

}




    </script>
  </body>
</html>