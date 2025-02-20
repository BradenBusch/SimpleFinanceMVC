document.addEventListener('DOMContentLoaded', function () {
    let chartXAxis = [];
    let chartYAxis = [];
    let dataSetSize = 0;

    document.querySelectorAll('.hidden-chart-details-value').forEach(a => {
        chartYAxis.push(a.value);
        dataSetSize++;
    });
    document.querySelectorAll('.hidden-chart-details-date').forEach((a, i) => {
        if (i == 0 || i == (dataSetSize - 1)) {
            chartXAxis.push(a.value);
        }
        else {
            chartXAxis.push(" ");
        }
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
                x: {
                    ticks: {
                        autoSkip: true
                    }
                },
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