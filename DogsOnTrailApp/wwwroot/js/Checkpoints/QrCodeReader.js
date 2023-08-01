window.destroyQrReader = async function () {
    var videoEle = document.getElementsByTagName<HTMLVideoElement>("video");

    if (videoEle != null) {
        videoEle.pause();
        videoEle.remove();
    }
}

window.createQrReader = async function () {
    var video = document.createElement("video");
    var canvasElement = document.getElementById("canvas");
    var canvas = canvasElement.getContext("2d");
    var loadingMessage = document.getElementById("loadingMessage");
    var outputContainer = document.getElementById("output");
    var outputMessage = document.getElementById("outputMessage");
    var outputData = document.getElementById("outputData");

    // Use facingMode: environment to attemt to get the front camera on phones
    navigator.mediaDevices
        .getUserMedia({ video: { facingMode: "environment" } })
        .then(function(stream) {
            video.srcObject = stream;
            video.setAttribute("playsinline", true); // required to tell iOS safari we don't want fullscreen
            video.play();
            
            requestAnimationFrame(qrReaderRequestAnimationFrameCb);
        });

    function qrReaderDrawLine(begin, end, color) {
        canvas.beginPath();
        canvas.moveTo(begin.x, begin.y);
        canvas.lineTo(end.x, end.y);
        canvas.lineWidth = 4;
        canvas.strokeStyle = color;
        canvas.stroke();
    }

    function qrReaderRequestAnimationFrameCb() {
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
                outputData.parentElement.hidden = false;
                outputData.innerText = code.data;
                
                video.remove();
                
                return code.data;
            }
            else {
                outputMessage.hidden = false;
                outputData.parentElement.hidden = true;
            }
        }

        requestAnimationFrame(qrReaderRequestAnimationFrameCb);
    }
}


