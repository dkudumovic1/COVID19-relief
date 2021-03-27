var map;

function initMap(zoomeLevel, latDb, longDb) {

    window.map = new google.maps.Map(document.getElementById('map'), {
        center: { lat: latDb != null ? latDb : 43.8563, lng: longDb != null ? longDb : 18.4131 },
        zoom: zoomeLevel != null ? zoomeLevel : 6
    });


    /*  const myLatLng = { lat: 43.8563, lng: 18.4131 };
      const map = new google.maps.Map(document.getElementById("map"), {
          zoom: 8,
          center: myLatLng,
      });
      new google.maps.Marker({
          position: myLatLng,
          map,
          title: "Hello World!",
      });*/
}