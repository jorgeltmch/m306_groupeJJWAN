var map = new ol.Map({
    target: 'map',
    layers: [
      new ol.layer.Tile({
        source: new ol.source.OSM()
      })
    ],
    view: new ol.View({
      center: ol.proj.fromLonLat([-117.1610838, 32.715738]),
      zoom: 12
    })
  });
  var centerLongitudeLatitude = ol.proj.fromLonLat([-117.1610838, 32.715738]);
  var layer = new ol.layer.Vector({
    source: new ol.source.Vector({
      projection: 'EPSG:4326',
      features: [new ol.Feature(new ol.geom.Circle(centerLongitudeLatitude, 4000))]
    }),
    style: [
      new ol.style.Style({
        stroke: new ol.style.Stroke({
          color: 'blue',
          width: 3
        }),
        fill: new ol.style.Fill({
          color: 'rgba(0, 0, 255, 0.1)'
        })
      })
    ]
  });
  map.addLayer(layer);