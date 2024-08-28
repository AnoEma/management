function createLeaderboardChart() {
    const ctx = document.getElementById('leaderboardChart').getContext('2d');
    new Chart(ctx, {
        type: 'bar',
        data: {
            labels: ['User 1', 'User 2', 'User 3', 'User 4', 'User 5'],
            datasets: [
                {
                    label: 'Completed',
                    data: [50, 60, 70, 40, 90],
                    backgroundColor: '#6A1B9A',
                },
                {
                    label: 'Active',
                    data: [30, 20, 15, 25, 10],
                    backgroundColor: '#43A047',
                },
                {
                    label: 'Overdue',
                    data: [20, 20, 15, 35, 20],
                    backgroundColor: '#E53935',
                },
            ],
        },
        options: {
            indexAxis: 'y', // Orienta as barras horizontalmente
            responsive: true,
            scales: {
                x: {
                    stacked: true,
                },
                y: {
                    stacked: true,
                },
            },
            plugins: {
                legend: {
                    display: true,
                    position: 'top',
                },
            },
        },
    });
}