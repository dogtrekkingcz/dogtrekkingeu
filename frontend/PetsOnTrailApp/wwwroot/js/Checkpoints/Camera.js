var video = null;
var canvasElement = null;

window.destroyCamera = async function () {
    video.pause();
    
    video.srcObject.getTracks().forEach(function (track) {
        track.stop();
    });
    
    video.srcObject = null;
    
    
    var canvasElement = document.getElementById("canvas");
    
    console.log(canvasElement);
    
    if (canvasElement != null) {
        canvasElement.width = 0;
        canvasElement.height = 0;
        canvasElement.hidden = true;
    }
}

window.startCamera = async function () {
    video = document.createElement("video");
    canvasElement = document.getElementById("canvas");
    var canvas = canvasElement.getContext("2d");
    var loadingMessage = document.getElementById("loadingMessage");
    var outputContainer = document.getElementById("output");
    var outputMessage = document.getElementById("outputMessage");

    // Use facingMode: environment to attemt to get the front camera on phones
    navigator.mediaDevices
        .getUserMedia({ video: { facingMode: "environment" } })
        .then(function(stream) {
            video.srcObject = stream;
            video.setAttribute("playsinline", true); // required to tell iOS safari we don't want fullscreen
            video.play();
            
            requestAnimationFrame(requestAnimationFrameCb);
        });

    function requestAnimationFrameCb() {
        loadingMessage.innerText = "⌛ Loading video..."

        if (video.readyState === video.HAVE_ENOUGH_DATA) {
            loadingMessage.hidden = true;
            canvasElement.hidden = false;
            outputContainer.hidden = false;

            canvasElement.height = video.videoHeight;
            canvasElement.width = video.videoWidth;
            canvas.drawImage(video, 0, 0, canvasElement.width, canvasElement.height);
            var imageData = canvas.getImageData(0, 0, canvasElement.width, canvasElement.height);

            var code = jsQR(imageData.data, imageData.width, imageData.height, {
                inversionAttempts: "dontInvert",
            });

            if (code) {
                qrReaderDrawLine(code.location.topLeftCorner, code.location.topRightCorner, "#FF3B58");
                qrReaderDrawLine(code.location.topRightCorner, code.location.bottomRightCorner, "#FF3B58");
                qrReaderDrawLine(code.location.bottomRightCorner, code.location.bottomLeftCorner, "#FF3B58");
                qrReaderDrawLine(code.location.bottomLeftCorner, code.location.topLeftCorner, "#FF3B58");
                outputMessage.hidden = true;
                
                canvasElement.height = 0;
                canvasElement.width = 0;
                
                video.pause();
                
                video.srcObject.getTracks().forEach(function(track) {
                    track.stop();
                });
                
                video.remove();

                canvasElement.hidden = true;

                DotNet.invokeMethodAsync('PetsOnTrailApp', "QrCodeAcquiredAsync", code.data);
                
                return;
            }
            else {
                outputMessage.hidden = false;
            }
        }

        requestAnimationFrame(qrReaderRequestAnimationFrameCb);
    }
}


