function LoadTrafficChart() {
    const ctx = document.getElementById('trafficChart').getContext('2d');
    const trafficChart = new Chart(ctx, {
        type: 'line',
        data: {
            labels: ['January', 'February', 'March', 'April', 'May', 'June', 'July'],
            datasets: [
                {
                    label: 'Equipe 1',
                    data: [120, 190, 170, 150, 180, 200, 220],
                    borderColor: 'blue',
                    backgroundColor: 'transparent',
                    borderWidth: 2,
                },
                {
                    label: 'Equipe 2',
                    data: [90, 150, 130, 120, 160, 190, 210],
                    borderColor: 'green',
                    backgroundColor: 'transparent',
                    borderWidth: 2,
                }
            ]
        },
        options: {
            scales: {
                y: {
                    beginAtZero: true
                }
            },
            responsive: true,
            maintainAspectRatio: false,
        }
    });
}
