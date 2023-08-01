window.getGpsLocation = async function () {
    const pos = await new Promise((resolve, reject) => {
        navigator.geolocation.getCurrentPosition(resolve, reject);
    });
    
    return [pos.coords.longitude, pos.coords.latitude];
}