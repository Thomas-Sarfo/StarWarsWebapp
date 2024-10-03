document.addEventListener('DOMContentLoaded', function () {
    // Obtenha os dados passados para o ViewBag
    var planetNames = JSON.parse(document.getElementById('planetNames').textContent);
    var planetPopulations = JSON.parse(document.getElementById('planetPopulations').textContent);

    // Configuração do gráfico
    var ctx = document.getElementById('planetChart').getContext('2d');
    var planetChart = new Chart(ctx, {
        type: 'bar', // Tipo de gráfico: barra
        data: {
            labels: planetNames,
            datasets: [{
                label: 'Population of Planets',
                data: planetPopulations,
                backgroundColor: 'rgba(75, 192, 192, 0.2)',
                borderColor: 'rgba(75, 192, 192, 1)',
                borderWidth: 1
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
});
