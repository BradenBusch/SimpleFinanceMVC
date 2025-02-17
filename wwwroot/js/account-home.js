$(window).on('load', function () {
    setNetWorthDisplay();

    document.querySelectorAll('.editAccountHeader').forEach(account => {

        // Note: This is hacky. You shouldn't do this. I had no problem keeping this modal as a separate page.
        // As a dynamic onClick from an <i>, I had to get a bit creative.
        // Obviously this will fail if there are any commas where there shouldn't be.
 
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
        console.log(convertedAccountValue);
        if (convertedAccountValue < 0.00) {
            console.log('adding red textg');
            account.classList.add('red-text');
        }

        account.innerText = "$" + convertedAccountValue;
    });
}
