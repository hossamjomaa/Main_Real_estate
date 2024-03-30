$(document).ready(function () {
    $('#Table').DataTable({
        "pageLength": 10000,

        dom: 'Bfrtip',
        buttons: [
            'copyHtml5',
            'excelHtml5',
            'csvHtml5',
            /*'pdfHtml5'*/
        ],
        language: {
            url: 'https://cdn.datatables.net/plug-ins/1.12.1/i18n/ar.json'
        }
    });
    table.buttons().container()
        .appendTo('#DataTables_Table_0_wrapper .col-md-6:eq(0)');
});