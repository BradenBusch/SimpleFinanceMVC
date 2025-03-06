

function toggleDetails(id) {
    var detailContainer = document.getElementById(id);
    var isVisible = detailContainer.classList.contains('d-block');

    if (isVisible) {
        detailContainer.classList.remove('d-block');
        detailContainer.classList.add('d-none');
        var btn = document.getElementById(id + "-Btn");
        btn.innerHTML = "Show Details <i class='fa fa-arrow-down' aria-hidden='true'></i>";
    }
    else {
        detailContainer.classList.add('d-block');
        detailContainer.classList.remove('d-none');
        var btn = document.getElementById(id + "-Btn");
        btn.innerHTML = "Hide Details <i class='fa fa-arrow-up' aria-hidden='true'></i>";
    }
}

function addEntry(id) {
    if (id != "") {

        $.ajax({
            url: "/ExpenseHeader/GetExpenseHeaderData/",
            method: 'GET',
            data: { expenseHeaderId: id },
            success: function (data) {
                var expenseType = data.expenseType;
                var expenseName = data.expenseName;

                var details = expenseName + " - " + expenseType;

                $(".modal-title").empty();
                $(".modal-title").html(details)

                $('#AddExpenseDetailModal').modal('show');
                $('#ModalExpenseId').prop('value', id);
            }
        });
    }
}