function GetUrlDelete() {
    return $("#urlDelete").val();
}

function GetUrlDetails() {
    return $("#urlDetails").val();
}

function getEmployeeDetails(empId) {
    $.ajax({
        url: GetUrlDetails(),
        data: { employeeId: empId },
        success: function (data) {
            $('#empDetailsModal').modal("show");
            $("#empDetails").html(data).modal("show");
        }
    });
}

function showDeleteDialog(ordId) {
    $.ajax(
        {
            url: GetUrlDelete(),
            data: { orderId: ordId },
            success: function (data) {
                $('#myModal').data('id', ordId).modal("show");
                $("#orderInfo").html(data).modal("show");
            }
        });
}

function del() {
    var id = $('#myModal').data('id');
    $.ajax({
        type: "POST",
        url: $("#urlDelete").val(),
        data: { orderId: id },
        success: function () {
            $('#myModal').modal('hide');
        }
    });
}

function close() {
    $('#myModal').modal('hide');
}