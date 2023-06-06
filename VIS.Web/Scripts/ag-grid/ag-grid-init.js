var gridOptions = {};



function onBtExportCsv(elementID) {
    const columnSeperator = ";";
    api = gridOptions['#' + elementID].api.columnController.columnApi;
    let csvContent = "data:text/csv;charset=utf-8,\uFEFF";
    let names = [];
    let colIds = [];
    let lambdas = [];

    api.getAllColumns().forEach(function (entry) {
        names.push(entry.colDef.headerName);
        colIds.push(entry.colId);
        if (entry.colDef.Lambda != undefined)
            lambdas.push(entry.colDef.Lambda);
        else
            lambdas.push("");
    });

    csvContent += names.join(columnSeperator) + "\r\n" + lambdas.join(columnSeperator) + "\r\n";
    api.columnController.gridApi.forEachNodeAfterFilter(function (entry) {
        const text = colIds.map(function (id) {
            return entry.data[id];
        });
        csvContent += text.join(columnSeperator) + "\r\n";
    });
    var a = document.createElement('a');
    a.href = csvContent;
    a.target = '_blank';
    a.download = 'myFile.csv';

    document.body.appendChild(a);
    a.click();
    document.body.removeChild(a);
}

function onFilterTextBoxChanged(elementID) {
    gridOptions['#' + elementID].api.setQuickFilter(document.getElementById('filter-text-box-' + elementID).value);
}

function getGridOptions(elementID) {
    return gridOptions['#' + elementID];
}


function filterLocalDate(filterLocalDateAtMidnight, cellValue) {
    var dateAsString = cellValue;
    var dateParts = dateAsString.split(".");
    var cellDate = new Date(Number(dateParts[2]), Number(dateParts[1]) - 1, Number(dateParts[0]));

    if (filterLocalDateAtMidnight.getTime() == cellDate.getTime()) {
        return 0
    }

    if (cellDate < filterLocalDateAtMidnight) {
        return -1;
    }

    if (cellDate > filterLocalDateAtMidnight) {
        return 1;
    }
}

function agInit(elementID, columnDefs, model, autosize, contextMenuSelector, addOptions) {
    const thisGridOptions = {
        columnDefs: columnDefs,
        floatingFilter: true,
        //enableSorting: true,
        rowSelection: 'single',
        rowDeselection: true,
        //onSelectionChanged: onSelectionChanged,
        rowData: model,
        domLayout: 'autoHeight',
        //enableColResize: true,
        suppressDragLeaveHidesColumns: true,
        getContextMenuItems: getContextMenuItems,
        allowContextMenuWithControlKey: true,
        onGridReady: function (params) {
            if (autosize) {
                params.columnApi.autoSizeColumns(params.columnApi.getAllColumns());
            }
            params.api.sizeColumnsToFit();

            $("input.hasDatepicker").keyup(function () {
                var val = $(this).val();
                if (val == null || val == '') {
                    $.datepicker._clearDate(this);
                }
            });

            window.addEventListener("resize", function (event) {
                params.api.sizeColumnsToFit();
            });
        },
        onFilterChanged: function () {
            if (this.api.getDisplayedRowCount() === 0) {
                this.api.showNoRowsOverlay();
            } else {
                this.api.hideOverlay();
            }
        },
        components: {
            checkboxCellRenderer: function (params) {
                return '<input type="checkbox" class="disabled" ' + (params.value ? "checked" : "") + ' disabled />';
            },
            //filterLocalDate: filterLocalDate,
            //agDateInput: AgDatePicker,
            //agDateComparator: agDatePickerComparator,
            //agDateSortComparator: agDatePickerSortComparator
        },
        defaultColDef: {
            editable: false,
            sortable: true,
            resizeable: true,
            getQuickFilterText: function (params) {
                if (!$('input[name="hidColumnQuickSearch-' + elementID + '"]').val() == true) {
                    if (params.value == null || params.value == '') {
                        return params.colDef.field + ":=null";
                    } else {
                        return params.colDef.field + ":=" + params.value;
                    }

                } else {
                    return params.value;
                }
            }
        }
    };

    if (addOptions != null) {
        for (var key in addOptions) {
            thisGridOptions[key] = addOptions[key];
        }
    }

    var eGridDiv = document.querySelector(elementID);
    new agGrid.Grid(eGridDiv, thisGridOptions);

    gridOptions[elementID] = thisGridOptions;

    if (contextMenuSelector) {
        // Trigger action when the contexmenu is about to be shown
        $(elementID).bind("contextmenu", function (event) {

            // Avoid the real one
            event.preventDefault();

            var thatGridApi = gridOptions['#' + $(this).attr('id')].api;

            var rowsGUI = $(elementID + " .ag-row");

            var header = $(".ag-header")[0];
            var offset = header.getBoundingClientRect().top + $(header).height() + $(document).scrollTop();

            for (var i = 0; i < rowsGUI.length; i++) {
                var rowGUI = rowsGUI[i];
                var idxSubtract = 1;
                if (i + 1 == rowsGUI.length) {
                    if ($(elementID).height() <= event.pageY - offset || event.pageY - offset <= 0) {
                        continue;
                    } else {
                        idxSubtract = 0;
                    }
                }
                else if (event.pageY > offset + parseInt(rowGUI.style.transform.split('Y(')[1].split('px)')[0])) {
                    continue;
                }

                var index = $(rowGUI).attr('row-index');

                focusRow({ rowIndex: index > 0 ? index - idxSubtract : 0, api: thatGridApi });
                break;
            }


            $(contextMenuSelector).finish().show(100).

                // In the right position (the mouse)
                css({
                    top: (event.pageY - 5 - $(document).scrollTop()) + "px",
                    left: (event.pageX - 5) + "px"
                }).addClass("shown");
        });


        // If the document is clicked somewhere
        $(document).bind("mousedown", function (e) {
            // If the clicked element is not the menu
            if ((!$(e.target).parents(contextMenuSelector).length > 0) && $(contextMenuSelector).hasClass("shown")) {
                $(contextMenuSelector).removeClass("shown");
                // Hide it
                $(contextMenuSelector).hide(100);
            }
        });
    }

    return thisGridOptions;
}

function focusRow(params) {
    var node = params.api.getDisplayedRowAtIndex(params.rowIndex);

    if (node) {
        node.setSelected(true);
    }
}

function getContextMenuItems(params) {
    var result = [
        {
            // custom item
            name: 'Alert ' + params.value,
            action: function () {
                window.alert('Alerting about ' + params.value);
            },
            cssClasses: ['redFont', 'bold']
        },
        'separator',
        {
            // custom item
            name: 'Checked',
            checked: true,
            action: function () {
                console.log('Checked Selected');
            },
            icon: '<img src="../images/skills/mac.png"/>'
        }, // built in copy item
        'copy'
    ];

    return result;
}
