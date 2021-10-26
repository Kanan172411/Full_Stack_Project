var Accepted = document.getElementById("acceptedpercent").value;
var radialoptions = {
    series: [11],
    chart: { type: "radialBar", width: 72, height: 72, sparkline: { enabled: !0 } },
    dataLabels: { enabled: !1 },
    colors: ["#0ab39c"],
    stroke: { lineCap: "round" },
    plotOptions: { radialBar: { hollow: { margin: 0, size: "70%" }, track: { margin: 0 }, dataLabels: { name: { show: !1 }, value: { offsetY: 5, show: !0 } } } },
},
    radialchart = new ApexCharts(document.querySelector("#radialchart-1"), radialoptions);
radialchart.render();
(radialchart = new ApexCharts(document.querySelector("#radialchart-2"), radialoptions)).render();
radialoptions = {
    series: [Accepted],
    chart: { type: "radialBar", width: 72, height: 72, sparkline: { enabled: !0 } },
    dataLabels: { enabled: !1 },
    colors: ["#0ab39c"],
    stroke: { lineCap: "round" },
    plotOptions: { radialBar: { hollow: { margin: 0, size: "70%" }, track: { margin: 0 }, dataLabels: { name: { show: !1 }, value: { offsetY: 5, show: !0 } } } },
};
(radialchart = new ApexCharts(document.querySelector("#radialchart-3"), radialoptions)).render();
var options = {
    series: [
        { name: "Expenses", type: "column", data: [23, 11, 22, 27, 13, 22, 37, 21, 44, 22, 30, 18] },
        { name: "Maintenance", type: "area", data: [44, 55, 41, 42, 22, 43, 21, 41, 56, 27, 43, 27] },
        { name: "Profit", type: "line", data: [30, 25, 36, 30, 45, 35, 64, 52, 59, 36, 39, 51] },
    ],
    chart: { height: 350, type: "line", stacked: !1, toolbar: { show: !1 } },
    stroke: { width: [0, 1, 1], dashArray: [0, 0, 5], curve: "smooth" },
    plotOptions: { bar: { columnWidth: "18%" } },
    legend: { show: !1 },
    fill: { opacity: [0.85, 0.25, 1], gradient: { inverseColors: !1, shade: "light", type: "vertical", opacityFrom: 0.85, opacityTo: 0.55, stops: [0, 100, 100, 100] } },
    labels: ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"],
    markers: { size: 0 },
    colors: ["#0bb197", "#eff2f7", "#ff3d60"],
},
  
(chart = new ApexCharts(document.querySelector("#radialBar-chart"), options)).render()
