var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#DT_load').DataTable({
        
        "ajax": {
            "url": "/employeesalary/getall/",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "firstName"},
            { "data": "lastName"},
            { "data": "netSalary" },
            { "data": "tax" },
            { "data": "pioTaxEmployee" },
            { "data": "heltTaxEmployee" },
            { "data": "unemploymentTaxEmployee"},
            { "data": "grossSalary" },
            { "data": "pioTaxEmployer"},
            { "data": "heltTaxEmployer"},
            { "data": "superGrossSalary" },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="text-center">
                        <a href="/EmployeeSalary/Upsert?id=${data}" class='btn btn-success text-white' style='cursor:pointer; width:70px;'>
                            Edit
                        </a>
                        &nbsp;
                        <a class='btn btn-danger text-white' style='cursor:pointer; width:70px;'
                            onclick=Delete('/EmployeeSalary/Delete?id='+${data})>
                            Delete
                        </a>
                        </div>`;
                }
                
            }
        ],
        "language": {
            "emptyTable": "no data found"
        },
        "scrollX": true,      
    });
}

// Alret https://sweetalert2.github.io/
// Notification https://codeseven.github.io/toastr/

function Delete(url) {
    swal({
        title: "Are you sure?",
        text: "Once deleted, you will not be able to recover!",
        icon: "warning",
        buttons: true,
        dangerMode: true
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                type: "DELETE",
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        dataTable.ajax.reload();
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    });
}