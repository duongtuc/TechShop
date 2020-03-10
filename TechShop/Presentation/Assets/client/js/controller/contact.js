var contact = {
    init: function () {
        contact.registerEvents();
    },
    registerEvents: function () {
        contact.initMap();
    },
    // This example displays a marker at the center of Australia.
    // When the user clicks the marker, an info window opens.

    initMap: function() {
        var uluru = { lat: parseFloat($('#hidLat').val()), lng: parseFloat($('#hidLng').val()) };
        var map = new google.maps.Map(document.getElementById('map'), {
            zoom: 15,
            center: uluru
        });

        var contentString = $('#hiContactDetail').val();

        var infowindow = new google.maps.InfoWindow({
            content: contentString
        });

        var marker = new google.maps.Marker({
            position: uluru,
            map: map,
            title: $('#hidName').val()
        });
        marker.addListener('click', function () {
            infowindow.open(map, marker);
        });
    }
}
contact.init();