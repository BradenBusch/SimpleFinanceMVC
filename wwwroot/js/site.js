function formatNumbers() {
    const numbers = document.querySelectorAll('.number');
    numbers.forEach(element => {
        element.textContent = element.textContent.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",")
    });
}

window.addEventListener('load', formatNumbers);

$("#ResetDataBtn").click(function () {
    $("#ResetUserDataModal").modal('show');
});

