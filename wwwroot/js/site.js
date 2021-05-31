function getEmployeeInfo() {
    var id = $('#employeesList').val();

    $('#employeeInfoBlock').load('/Employees/GetEmployeeInfo', { id: id});
}

function EmployeeEdit(id) {
    $('#personalInfoBlock').load('/Employees/Edit/' + id);
}

function SendEditForm() {
    $.ajax({
        url: '/Employees/Edit/',
        type: 'POST',
        dataType: 'html',
        data: $('#editForm').serialize(),
        success: function (response) {
            $('#personalInfoBlock').html(response);
        }
    })
}

function search() {
    var searchInput = $('#searachString').val();

    $('#employeesListBlock').load('/Employees/Search', { searchString: searchInput });
}

function dateOfTimeSheetChangeListener() {
    if ($('#month').val() != 0 && $('#year').val() != 0) {
        $('#timeSheetDateSubmitBtn').removeAttr('disabled');
    }
    else {
        $('#timeSheetDateSubmitBtn').attr('disabled', 'disabled');
    }
}

function getAttendanceMarks() {
    $.ajax({
        url: '/TimeSheets/GetAttendanceMarks/',
        type: 'GET',
        dataType: 'html',
        data: $('#employeeTimeSheetForm').serialize(),
        success: function (response) {
            $('#attendanceMarksBlock').html(response);
        }
    })
}

function getTimeSheets() {
    $.ajax({
        url: '/TimeSheets/GetTimeSheets/',
        type: 'GET',
        dataType: 'html',
        data: $('#timeSheetDateForm').serialize(),
        success: function (response) {
            $('#timeSheetsBlock').html(response);
        }
    })
}

function saveTimeSheet() {
    $.ajax({
        url: '/TimeSheets/SaveTimeSheet/',
        type: 'POST',
        dataType: 'html',
        data: $('#attendanceMarksForm').serialize(),
        success: function (response) {
            $('#modal-info').html(response);
            $('#smallModal').modal({
                show: true
            });
        }
    })
}

function getActions() {
    console.log($('#actionsFilterForm').serialize());
    $.ajax({
        url: '/Management/GetActions/',
        type: 'GET',
        dataType: 'html',
        data: $('#actionsFilterForm').serialize(),
        success: function (response) {
            $('#actionsBlock').html(response);
        }
    })
}

function allTimeCheckboxListener() {
    if (!$('#allTimeCheckbox').is(":checked")) {
        $('#actionDate').removeAttr('disabled');
    }
    else {
        $('#actionDate').attr('disabled', 'disabled');
    }
}