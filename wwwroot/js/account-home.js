$(window).on('load', function () {
    setNetWorthDisplay();

    const editButtons = document.querySelectorAll('.editAccountHeader').forEach(account => {

        // Note: This is hacky. You shouldn't do this. I had no problem keeping this modal as a separate page.
        // As a dynamic onClick from an <i>, I had to get a bit creative.
        // Obviously this will fail if there are any commas where there shouldn't be.
        // Validate that no ',' are in Account name. if i had time id add an if check here to say that 
        // if modalParameters.length != 4(there was a comma then) AJAX post with the idea instead of using what was set in the id.
        account.addEventListener('click', () => {
            let modalParamters = account.id.split(',');
            $("#ModalAccountHeaderId").prop('value', modalParamters[0]);
            $("#ModalAccountName").prop('value', modalParamters[1]);
            $("#ModalAccountType").prop('value', modalParamters[2]);
            $("#ModalAccountDescription").prop('value', modalParamters[3]);

            $('#EditAccountHeaderModal').modal('show');
        });
    })
});

function setNetWorthDisplay() {
    const netWorth = $("#NetWorth").text();
    console.log
    let convertedNetWorth = Number(netWorth);

    if (convertedNetWorth < 0.00) {
        $("#NetWorth").css('color', 'red');
    }

    $("#NetWorth").text("$" + convertedNetWorth);
}

function getSelectedAccount() {
    $('#EditAccountHeaderModal').modal('show');
}
