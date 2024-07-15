window.initializeNumpad = (dotNetHelper) => {
    document.querySelectorAll('input.simple-datetime').forEach(input => {
        input.addEventListener('focus', () => {
            const rect = input.getBoundingClientRect();
            const numpadOverlay = document.querySelector('.numpad-overlay');
            numpadOverlay.style.display = 'block';
            numpadOverlay.style.top = `${rect.bottom}px`;
            numpadOverlay.style.left = '0';
            numpadOverlay.style.right = '0';

            dotNetHelper.invokeMethodAsync('ShowNumpad', input);
        });
    });
};

window.updateInputValue = (input, value) => {
    input.value = value;
};

window.hideNumpad = () => {
    document.querySelector('.numpad-overlay').style.display = 'none';
};