function getEmployeeInfo() {
    var id = $('#employeesList').val();

    $('#employeeInfoBlock').load('/Employees/GetEmployeeInfo', { id: id});
}