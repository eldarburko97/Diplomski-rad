import { Component, OnInit } from '@angular/core';
import Chart from "chart.js";
import { BsDatepickerConfig } from 'ngx-bootstrap/datepicker';
import { BestSellingTreatment } from 'src/app/models/bestSellingTreatment.model';
import { ReportService } from 'src/app/services/report.service';

@Component({
  selector: 'app-best-selling-treatment',
  templateUrl: './best-selling-treatment.component.html',
  styleUrls: ['./best-selling-treatment.component.css'],
  providers: [ReportService]
})
export class BestSellingTreatmentComponent implements OnInit {
  datePickerConfig: Partial<BsDatepickerConfig>;
  startDate: Date = new Date();
  endDate: Date = new Date();

  constructor(private _reportService: ReportService) {
    this.datePickerConfig = Object.assign(
      {},
      {
        containerClass: "theme-dark-blue",
        showWeekNumbers: false,
        dateInputFormat: "YYYY/MM/DD",
      }
    );
  }

  ngOnInit() {
    this._reportService
      .getBestSellingTreatment(this.startDate, this.endDate)
      .subscribe(
        (res) => {this.createNetPositionsChart(res), console.log(res)},
        (err) => console.log(err)
      );
  }

  createNetPositionsChart(model: BestSellingTreatment[]): void {
    const canvas = <HTMLCanvasElement>(
      document.getElementById("mainBarChartCanvas")
    );
    const ctx = canvas.getContext("2d");
    var myChart = new Chart(ctx, {
      type: "bar",
      data: {
        labels: model.map((x) => x.treatment),
        datasets: [
          {
            label: "Total treatments",
            data:  model.map((x) => x.number),
            // data: [10, 2, 3, 4, 5],
            backgroundColor: [
              "rgba(255, 99, 132, 0.2)",
              "rgba(54, 162, 235, 0.2)",
              "rgba(54, 162, 235, 0.2)",
              "rgba(75, 192, 192, 0.2)",
              "rgba(153, 102, 255, 0.2)",
              "rgba(255, 159, 64, 0.2)",
            ],
            borderColor: [
              "rgba(255,99,132,1)",
              "rgba(54, 162, 235, 1)",
              "rgba(255, 206, 86, 1)",
              "rgba(75, 192, 192, 1)",
              "rgba(153, 102, 255, 1)",
              "rgba(255, 159, 64, 1)",
            ],
            borderWidth: 1,
          },
        ],
      },
      options: {
        scales: {
          yAxis: {
            stacked: true,
            position: "left",
            beginAtZero: true,
            grid: {
              color: "#E4E4E7",
              borderDash: [25],
              drawBorder: false,
            },
            ticks: {
              color: "#BBB",
              callback: function (value) {
                return value.toLocaleString("en-GB", {
                  style: "currency",
                  currency: "GBP",
                  minimumFractionDigits: 0,
                });
              },
            },
          },
        },
      },
    });
  }

  filter() {
    this._reportService
      .getBestSellingTreatment(this.startDate, this.endDate)
      .subscribe(
        (res) => { this.createNetPositionsChart(res); console.log(res)  },
        (err) => console.log(err)
      );
  }

}
