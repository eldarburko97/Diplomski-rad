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
        (res) => {this.createBestSellingTreatmentChart(res), console.log(res)},
        (err) => console.log(err)
      );
  }

  createBestSellingTreatmentChart(model: BestSellingTreatment[]): void {
    const canvas = <HTMLCanvasElement>(
      document.getElementById("bestSellingTreatmentCanvas")
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
            backgroundColor: "#A2DDFF",
            stack: "stack 0",
            type: "bar",
            borderWidth: 1,
          },
          {
            label: "Total Profit",
            data:  model.map((x) => x.total),
            backgroundColor: "#FF9489",
            stack: "stack 1",
            type: "bar",
            borderWidth: 1,
          },
        ],
      },
      options: {
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
      .getBestSellingTreatment(this.startDate, this.endDate)
      .subscribe(
        (res) => { this.createBestSellingTreatmentChart(res); console.log(res)  },
        (err) => console.log(err)
      );
  }

}
