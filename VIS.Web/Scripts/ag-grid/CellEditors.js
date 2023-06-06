changed = [];

function NumericCellEditor() {
}


NumericCellEditor.prototype.init = function (params) {
    this.eInput = document.createElement('input');
    this.eInput.value = params.value;
    this.eInput.setAttribute("style", params.eGridCell.attributes.style.nodeValue);
    if (!changed.includes(params.rowIndex))
        changed.push(params.rowIndex);
    if ((!isNaN(params.charPress) || params.charPress == ".") && params.charPress != null && params.charPress!=" ") {
        this.eInput.value += params.charPress;
    }

    var that = this;
    this.eInput.addEventListener('keypress', function (event) {
        if ((isNaN(event.key) && event.key != ".") || event.key == " ") {
            that.eInput.focus();
            if (event.preventDefault) event.preventDefault();
        } else if (that.isKeyPressedNavigation(event)) {
            event.stopPropagation();
        }
    });
    var charPressIsNotANumber = params.charPress && ('1234567890'.indexOf(params.charPress) < 0);
    this.cancelBeforeStart = charPressIsNotANumber;
};

NumericCellEditor.prototype.isKeyPressedNavigation = function (event) {
    return event.keyCode === 39
        || event.keyCode === 37;
};


    // gets called once when grid ready to insert the element
    NumericCellEditor.prototype.getGui = function () {
        return this.eInput;
    };

    // focus and select can be done after the gui is attached
    NumericCellEditor.prototype.afterGuiAttached = function () {
        this.eInput.focus();
    };

    // returns the new value after editing
    NumericCellEditor.prototype.isCancelBeforeStart = function () {
        return this.cancelBeforeStart;
    };

    // returns the new value after editing
    NumericCellEditor.prototype.getValue = function () {
        return this.eInput.value;
    };

    // any cleanup we need to be done here
    NumericCellEditor.prototype.destroy = function () {
    };

    // if true, then this editor will appear in a popup 
    NumericCellEditor.prototype.isPopup = function () {
        // and we could leave this method out also, false is the default
        return false;
    };