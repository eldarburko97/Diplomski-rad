import { Component, OnInit } from "@angular/core";
import { BusinessReportDentist } from "src/app/models/businessReportDentist.model";
import Chart from "chart.js";
import { ReportService } from "src/app/services/report.service";
import { BsDatepickerConfig } from "ngx-bootstrap/datepicker";

@Component({
  selector: "app-business-report-dentist",
  templateUrl: "./business-report-dentist.component.html",
  styleUrls: ["./business-report-dentist.component.css"],
  providers: [ReportService],
})
export class BusinessReportDentistComponent implements OnInit {
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
      .getBusinessReportDentists(this.startDate, this.endDate)
      .subscribe(
        (res) => this.createDentistChart(res),
        (err) => console.log(err)
      );
  }

  createDentistChart(model: BusinessReportDentist[]): void {
    const canvas = <HTMLCanvasElement>(
      document.getElementById("dentistChartCanvas")
    );
    const ctx = canvas.getContext("2d");
    var myChart = new Chart(ctx, {
      type: "bar",
      data: {
        labels: model.map((x) => x.name),
        datasets: [
          {
            label: "Total appointments",
            data:  model.map((x) => x.totalAppointments),
            backgroundColor: [
              "rgba(255, 99, 132, 0.2)",
              "rgba(54, 162, 235, 0.2)",
              "rgba(255, 206, 86, 0.2)",
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
        legend: {
          labels: {
            boxWidth: 0,
          }
         },
        scales: {
          yAxes: [{
            ticks: {
                beginAtZero: true
            }
        }]
        },
      },
    });
  }

  filter() {
    this._reportService
      .getBusinessReportDentists(this.startDate, this.endDate)
      .subscribe(
        (res) => this.createDentistChart(res),
        (err) => console.log(err)
      );
  }
}
