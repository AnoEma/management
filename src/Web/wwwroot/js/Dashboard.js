document.addEventListener("DOMContentLoaded", function () {
    // Gráfico de Tarefas Completas
    var ctx1 = document.getElementById('completionTasksChart').getContext('2d');
    var completionTasksChart = new Chart(ctx1, {
        type: 'bar',
        data: {
            labels: ['21 Mar', '22 Mar', '23 Mar', '24 Mar', '25 Mar', '26 Mar', '27 Mar'],
            datasets: [{
                label: 'Tasks',
                data: [100, 50, 450, 300, 250, 200, 100],
                backgroundColor: '#007bff',
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

    // Gráfico de Desempenho das Tarefas
    var ctx2 = document.getElementById('tasksPerformanceChart').getContext('2d');
    var tasksPerformanceChart = new Chart(ctx2, {
        type: 'doughnut',
        data: {
            labels: ['Assigned', 'Completed', 'Active'],
            datasets: [{
                data: [100, 75, 60],
                backgroundColor: ['#007bff', '#6f42c1', '#28a745'],
            }]
        },
        options: {
            cutout: '80%',
        }
    });
});
