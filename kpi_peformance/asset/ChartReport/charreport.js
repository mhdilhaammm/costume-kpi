const ctxDE = document.getElementById('chartDE');
const ctxQty = document.getElementById('chartQty');
const ctxHscode = document.getElementById('chartHscode');
const ctxSumOp = document.getElementById('chartOp');
const ctxCo = document.getElementById('chartCo');
const ctxVal = document.getElementById('chartVal');
const ctxBil = document.getElementById('chartBil');


//chart untuk Total error
new Chart(ctxSumOp, {
    type: 'bar',
    data: {
        labels: chartLabes,
        datasets: [{
            label: 'Overall Declaration Performance',
            data: chartOp,
            backgroundColor: '#1679AB',
            borderColor: '#1679AB',
            tension: 0.1,
            borderWidth: 1
        }]
    },
    options: {
        scales: {
            y: {
                beginAtZero: true
            }
        }
    },
});

//chart untuk Description Error
new Chart(ctxDE, {
    type: 'line',
    data: {
        labels: chartLabes,
        datasets: [{
            label: 'Description Error',
            data: chartDe,
            borderColor: '#1679AB',
            borderWidth: 2
        }]
    },
    options: {
        scales: {
            y: {
                beginAtZero: true,
                min: 0,
                max: 10,
                grid: {
                    drawOnChartArea: true,
                    color: function (context) {
                        const value = context.tick.value
                        if (value >= 5) {
                            return '#EE4E4E'
                        } else if (value >= 3) {
                            return '#FFC700'
                        } else if (value >= 0) {
                            return '#06D001'
                        }
                    },
                    borderWidth: 1
                }
            },
        }
    }
});

//chart untuk Quantity error
new Chart(ctxQty, {
    type: 'line',
    data: {
        labels: chartLabes,
        datasets: [{
            label: 'Quantity Error',
            data: chartQty,
            borderColor: '#1679AB',
            tension: 0.1,
            borderWidth: 2
        }]
    },
    options: {
        scales: {
            y: {
                beginAtZero: true,
                min: 0,
                max: 10,
                grid: {
                    drawOnChartArea: true,
                    color: function (context) {
                        const value = context.tick.value
                        if (value >= 5) {
                            return '#EE4E4E'
                        } else if (value >= 3) {
                            return '#FFC700'
                        } else if (value >= 0) {
                            return '#06D001'
                        }
                    },
                    borderWidth: 1
                }
            }
        }
    }
});

//chart untuk HS Code error
new Chart(ctxHscode, {
    type: 'line',
    data: {
        labels: chartLabes,
        datasets: [{
            label: 'HS Code Error',
            data: chartHscode,
            borderColor: '#1679AB',
            tension: 0.1,
            borderWidth: 2
        }]
    },
    options: {
        scales: {
            y: {
                beginAtZero: true,
                min: 0,
                max: 10,
                grid: {
                    drawOnChartArea: true,
                    color: function (context) {
                        const value = context.tick.value
                        if (value >= 5) {
                            return '#EE4E4E'
                        } else if (value >= 3) {
                            return '#FFC700'
                        } else if (value >= 0) {
                            return '#06D001'
                        }
                    },
                    borderWidth: 1
                }
            }
        }
    }
});

//chart untuk CoO error
new Chart(ctxCo, {
    type: 'line',
    data: {
        labels: chartLabes,
        datasets: [{
            label: 'CoO Error',
            data: chartCo,
            borderColor: '#1679AB',
            tension: 0.1,
            borderWidth: 2
        }]
    },
    options: {
        scales: {
            y: {
                beginAtZero: true,
                min: 0,
                max: 10,
                grid: {
                    drawOnChartArea: true,
                    color: function (context) {
                        const value = context.tick.value
                        if (value >= 5) {
                            return '#EE4E4E'
                        } else if (value >= 3) {
                            return '#FFC700'
                        } else if (value >= 0) {
                            return '#06D001'
                        } else {
                            return '#dedede'
                        }
                    },
                    borderWidth: 1
                }
            }
        }
    }
});

//chart untuk Value error
new Chart(ctxVal, {
    type: 'line',
    data: {
        labels: chartLabes,
        datasets: [{
            label: 'Value Error',
            fill: false,
            data: chartVal,
            borderColor: '#1679AB',
            tension: 0.1,
            borderWidth: 2
        }]
    },
    options: {
        scales: {
            y: {
                beginAtZero: true,
                min: 0,
                max: 10,
                grid: {
                    drawOnChartArea: true,
                    color: function (context) {
                        const value = context.tick.value
                        if (value >= 5) {
                            return '#EE4E4E'
                        } else if (value >= 3) {
                            return '#FFC700'
                        } else if (value >= 0) {
                            return '#06D001'
                        }
                    },
                    borderWidth: 1
                }
            }
        }
    }
});

//chart untuk Number of items Bill Landing
new Chart(ctxBil, {
    type: 'line',
    data: {
        labels: chartLabes,
        datasets: [{
            label: 'Value Error',
            data: chartNumBil,
            borderColor: '#1679AB',
            tension: 0.1,
            borderWidth: 2
        }]
    },
    options: {
        scales: {
            y: {
                beginAtZero: true,
            }
        }
    }
});
