import 'https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.5.0/Chart.min.js'

export function InitChart(xValues,y1Values,y2Values) {
    
    new Chart("myChart", {
        type: "bar",
        data: {
            labels: xValues,
            datasets: [{
                backgroundColor: "Green",
                data: y1Values
            },
            {
                backgroundColor: "Red",
                data: y2Values
            }]
        },
        options: {
            legend: { display: false },
            title: {
                display: true,
                text: "12 Months Income and Expenses"
            }
        }
    });
}