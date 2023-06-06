//Date Editor
function AgDatePicker() { }

// gets called once before the renderer is used
AgDatePicker.prototype.init = function (params) {
    // create the cell
    this.eInput = document.createElement('input');
    this.eInput.value = null; //params.value;

    this.params = params;

    var that = this;

    // https://jqueryui.com/datepicker/
    $(this.eInput).datepicker({
        dateFormat: "yy-mm-dd",
        changeMonth: true,
        changeYear: true,
        onSelect: function (date) {
            that.onDateChanged(date);
        }
    });

    this.eGui = this.eInput;

    this.eInput.addEventListener('keydown', function (event) {
        var key = event.which || event.keyCode;

        if (key == 8 || key == 46) {
            that.params.value = null;
            that.eInput.value = null;
            var filterBody = $(that.eInput).closest(".ag-header-cell");
            var filterButton = $(filterBody[0].querySelector("button[ref='eButtonShowMainFilter']"));
            $(filterButton).trigger('click');
            $("#clearButton").trigger('click');
            $(".ag-filter").hide();
        }
    });

    this.eInput.addEventListener('click', function (event) {
        $(this).datepicker('show');
    });
};

AgDatePicker.prototype.getGui = function () {
    return this.eGui;
};

AgDatePicker.prototype.onDateChanged = function (selectedDates) {
    //this.date = selectedDates[0] || null;
    this.params.onDateChanged();
};

AgDatePicker.prototype.getDate = function () {
    return $(this.eInput).datepicker("getDate");
};

AgDatePicker.prototype.setDate = function (date) {
    $(this.eInput).datepicker("setDate",date);
};

function parseDateTimeString(dateTimeAsString) {
    var date = parseDateString(dateTimeAsString);

    if (date == null) {
        return null;
    } else if (Object.prototype.toString.call(dateTimeAsString) === '[object Date]') {
        return dateTimeAsString;
    }

    var timeParts = dateTimeAsString.split(' ');

    if (timeParts.length <= 1) {
        return date;
    }

    timeParts = timeParts[1].split(':');

    if (timeParts.length < 3) {
        return date;
    }

    var hh = timeParts[0];
    var mm = timeParts[1];
    var ss = timeParts[2].split('.')[0];

    date.setHours(hh, mm, ss);

    return date;
}

function parseDateString(dateAsString) {
    if (dateAsString == null || dateAsString === '') {
        return null;
    } else if (Object.prototype.toString.call(dateAsString) === '[object Date]') {
        return dateAsString;
    }

    var ret = null;
    var dateParts = null;

    if (dateAsString.indexOf('-') !== -1) {
        dateParts = dateAsString.split("-");

        if (dateParts.length < 3) {
            return null;
        }

        ret = new Date(Number(dateParts[0]), Number(dateParts[1]) - 1, Number(dateParts[2].split(' ')[0]));
    } else {
        if (dateAsString.indexOf('.') !== -1) {
            dateParts = dateAsString.split(".");
        } else {
            dateParts = dateAsString.split('/');
        }

        if (dateParts.length < 3) {
            return null;
        }

        ret = new Date(Number(dateParts[2].split(' ')[0]), Number(dateParts[1]) - 1, Number(dateParts[0]));
    }

    return ret;
}

function agDatePickerComparator(filterLocalDateAtMidnight, cellValue) {
    var filterDate = parseDateString(filterLocalDateAtMidnight);
    var cellDate = parseDateString(cellValue);

    if (filterDate.getTime() === cellDate.getTime()) {
        return 0;
    }

    if (cellDate < filterDate) {
        return -1;
    }

    if (cellDate > filterDate) {
        return 1;
    }
}

function agDatePickerSortComparator(filterLocalDateAtMidnight, cellValue) {
    return agDatePickerComparator(filterLocalDateAtMidnight, cellValue) * (-1);
}