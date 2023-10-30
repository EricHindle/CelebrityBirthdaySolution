$(document).ready(function() {
    var x = document.getElementById("loclat");
    var y = document.getElementById("loclon");
    var z = document.getElementById("myLocation");

    getLocation();

    function getLocation() {
        if (navigator.geolocation) {
            navigator.geolocation.getCurrentPosition(showPosition, showError);
        } else {
            x.innerHTML = "Geolocation is not supported by this browser.";
            y.innerHTML = "Geolocation is not supported by this browser.";
            z.innerHTML = "Geolocation is not supported by this browser.";
        }
    }

    function showPosition(position) {
        lat = position.coords.latitude;
        lon = position.coords.longitude;
        x.value = lat;
        y.value = lon;
        z.innerHTML = "Location acquired";
    }

    function showError(error) {
        switch (error.code) {
            case error.PERMISSION_DENIED:
                x.value = "User denied the request for Geolocation";
                y.value = "User denied the request for Geolocation";
                z.innerHTML = "User denied the request for Geolocation";
                break;
            case error.POSITION_UNAVAILABLE:
                x.value = "Location information is unavailable";
                y.value = "Location information is unavailable";
                z.innerHTML = "Location information is unavailable";
                break;
            case error.TIMEOUT:
                x.value = "The request to get user location timed out";
                y.value = "The request to get user location timed out";
                z.innerHTML = "The request to get user location timed out";
                break;
            case error.UNKNOWN_ERROR:
                x.value = "An unknown error occurred";
                y.value = "An unknown error occurred";
                z.innerHTML = "An unknown error occurred";
                break;
        }
    }
});
