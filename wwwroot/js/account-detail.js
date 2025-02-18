document.addEventListener('DOMContentLoaded', function () {
    let chartXAxis = [];
    let chartYAxis = [];
    let dataSetSize = 0;

    document.querySelectorAll('.hidden-chart-details-value').forEach(a => {
        chartYAxis.push(a.value);
        dataSetSize++;
    });

    document.querySelectorAll('.hidden-chart-details-date').forEach(a => {
        chartXAxis.push(a.value);
    });

    const ctx = document.getElementById('myChart');

    new Chart(ctx, {
        type: 'line',
        data: {
            labels: chartXAxis,
            datasets: [{
                label: 'Account Growth',
                data: chartYAxis,
                fill: false,
                borderColor: 'rgb(50, 205, 50)',
                tension: 0.1
            }]
        },
        options: {
            scales: {
                y: {
                    beginAtZero: true
                }
            }
        }
    });

    let chartContainer = document.getElementById('ChartContainer');
    if (dataSetSize < 2) {
        chartContainer.style.display = 'none';
    }
});