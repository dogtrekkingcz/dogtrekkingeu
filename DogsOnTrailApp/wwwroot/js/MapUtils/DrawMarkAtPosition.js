window.drawMarkAtPosition = async function (id, imgSrc, positions, mapBottom, mapRight, mapLeft)
{
    var canvas = document.getElementById(id);
    var ctx = canvas.getContext('2d');

    canvas.width = window.innerWidth;
    canvas.height = window.innerHeight;

    var img = new Image();

    await new Promise(r => {
        img.onload = r;
        img.src = imgSrc;
    });

    var hRatio = canvas.width / img.width    ;
    var vRatio = canvas.height / img.height  ;
    var ratio  = Math.min ( hRatio, vRatio );

    ctx.drawImage(img, 0, 0, img.width, img.height, 0, 0, img.width * ratio, img.height * ratio);

    positions.forEach(position => {
        let mapLatBottomRad = mapBottom * Math.PI / 180;
        let latitudeRad = position.latitude * Math.PI / 180;
        let mapLngDelta = (mapRight - mapLeft);
        let mapWidth = img.width * ratio;
        let mapHeight = img.height * ratio;

        let worldMapWidth = ((mapWidth / mapLngDelta) * 360) / (2 * Math.PI);
        let mapOffsetY = (worldMapWidth / 2 * Math.log((1 + Math.sin(mapLatBottomRad)) / (1 - Math.sin(mapLatBottomRad))));

        let x = (position.longitude - mapLeft) * (mapWidth / mapLngDelta);
        let y = mapHeight - ((worldMapWidth / 2 * Math.log((1 + Math.sin(latitudeRad)) / (1 - Math.sin(latitudeRad)))) - mapOffsetY);

        ctx.fillStyle = "#00FF00";
        ctx.beginPath();
        ctx.arc(x, y, 10, 0, 2 * Math.PI);
        ctx.fill();
    });
}