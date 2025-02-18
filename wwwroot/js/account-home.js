$(window).on('load', function () {
    setNetWorthDisplay();

    document.querySelectorAll('.editAccountHeader').forEach(account => {
        // This will fail if there are any commas where there shouldn't be.
        // Dynamic assinging / embedding. Can do for controller action, couldn't figure out in time for dynamic modal.
        account.addEventListener('click', () => {
            let modalParamters = account.id.split(',');
            $("#ModalAccountHeaderId").prop('value', modalParamters[0]);
            $("#ModalAccountName").prop('value', modalParamters[1]);
            $("#ModalAccountType").prop('value', modalParamters[2]);
            $("#ModalAccountDescription").prop('value', modalParamters[3]);
            $('#EditAccountHeaderModal').modal('show');
        });
    });

    document.querySelectorAll('.deleteAccount').forEach(account => {
        account.addEventListener('click', () => {
            $("#DeleteModalAccountHeaderId").prop('value', account.id);
            $('#DeleteAccountModal').modal('show');
        });
    });

    $("#ResetDataBtn").on('click', function () {
        $("#ResetUserDataModal").modal('show');
    });
});

function setNetWorthDisplay() {
    const netWorth = $("#NetWorth").text();

    let convertedNetWorth = Number(netWorth);

    if (convertedNetWorth < 0.00) {
        $("#NetWorth").css('color', 'red');
    }

    $("#NetWorth").text("$" + convertedNetWorth);

    document.querySelectorAll('.account-value').forEach(account => {
        let accountValue = account.innerText;
        let convertedAccountValue = Number(accountValue);
        if (convertedAccountValue < 0.00) {
            account.classList.add('red-text');
        }

        account.innerText = "$" + convertedAccountValue;
    });
}
