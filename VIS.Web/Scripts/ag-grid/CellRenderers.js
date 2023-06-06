function myCheckboxCellRenderer(params) {
    var element = document.createElement("input");
    element.type = 'checkbox';

    if (params.value === true || params.value == 1) {
        element.checked = true;
    } else {
        element.checked = false;
    }
    return element;
}
function myDisabledCheckboxCellRenderer(params) {
    var element = document.createElement("input");
    element.type = 'checkbox';

    if (params.value === true || params.value == 1) {
        element.checked = true;
    } else {
        element.checked = false;
    }
    element.disabled = "disabled";
    return element;
}

function checkShiftAttendanceCellRenderer(params) {
    let userShiftID = -1;
    var element = document.createElement("input");
    element.type = 'checkbox';
    userShiftID = params.data.UserShift_ID;
    if (params.value === true || params.value == 1) {
        element.checked = true;
    }
    else {
        element.checked = false;
    }
    element.onchange = function (e) {
        selectedUsers.push(userShiftID);
        handleShiftAttendance(this.checked);
    }

    return element;
}

function colorSpanCellRenderer(params) {
    var element = document.createElement('label');
    element.setAttribute("style","background-color:rgb(" + params.value + ");width:100%;height:100%;");
    console.log(params);
    return element;
}