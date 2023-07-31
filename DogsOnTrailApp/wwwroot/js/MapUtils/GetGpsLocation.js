window.getGpsLocation = async function () {
    navigator.geolocation.getCurrentPosition(function (location) {
        return (location.coords);
    });
}