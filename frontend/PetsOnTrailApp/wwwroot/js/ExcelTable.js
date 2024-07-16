window.addMouseEvents = function (dotNetHelper) {
    document.addEventListener('mousemove', function (e) {
        dotNetHelper.invokeMethodAsync('OnMouseMoveJS', {
            clientX: e.clientX
        });
    });

    document.addEventListener('mouseup', function (e) {
        dotNetHelper.invokeMethodAsync('OnMouseUpJS', {
            clientX: e.clientX
        });
    });
};