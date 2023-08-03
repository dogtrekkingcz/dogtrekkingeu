window.getGpsLocation = async function () {
    const pos = await new Promise((resolve, reject) => {
        navigator.geolocation.getCurrentPosition(resolve, reject);
    });
    
    return [pos.coords.longitude, pos.coords.latitude];
}

let watchPositionId;
let watchPositionOptions;
watchPositionOptions = {
    enableHighAccuracy: false,
    timeout: 5000,
    maximumAge: 0,
};

function watchPositionSuccess(pos) {
    DotNet.invokeMethodAsync('PetsOnTrailApp', "GpsPositionChanged", pos.coords.latitude, pos.coords.longitude);
}

function watchPositionError(err) {
    console.error(`ERROR(${err.code}): ${err.message}`);
}

window.stopWatchPosition = async function () {
    navigator.geolocation.clearWatch(watchPositionId);
}

window.startWatchPosition = async function () {
    watchPositionId = navigator.geolocation.watchPositionSuccess(watchPositionSuccess, watchPositionError, watchPositionOptions);    
}