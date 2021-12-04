import { Component, OnInit } from "@angular/core";
import Chart from 'chart.js/auto';
import { Appointment } from "../models/appointment.model";
import { AppointmentService } from "../services/appointment.service";
import { DentistService } from "../services/dentist.service";
import { PaymentService } from "../services/payment.service";
import { UserService } from "../services/user.service";


@Component({
  selector: "app-home",
  templateUrl: "./home.component.html",
  styleUrls: ["./home.component.css"],
  providers: [DentistService, UserService, AppointmentService, PaymentService]
})
export class HomeComponent implements OnInit {
  showHomeMain: boolean;
  constructor(private _dentistService: DentistService, private _clientService: UserService, private _appointmentService: AppointmentService, _paymentService: PaymentService) {}

  ngOnInit() {
    this.Collapse();
    this.createNetPositionsChart();
  }


  onClick(target): void {
    let toggle = target;
    let navigation = document.querySelector(".navigation");
    let main = document.querySelector(".main");
    toggle.classList.toggle("active");
    navigation.classList.toggle("active");
    main.classList.toggle("active");
  }

  Collapse(): void {
    var coll = document.getElementsByClassName("collapsible");
    var i;

    for (i = 0; i < coll.length; i++) {
      coll[i].addEventListener("click", function () {
        this.classList.toggle("active");
        var content = this.nextElementSibling;
        if (content.style.maxHeight) {
          content.style.maxHeight = null;
        } else {
          content.style.maxHeight = content.scrollHeight + "px";
        }
      });
    }
  }

  createNetPositionsChart(): void {
    const canvas = <HTMLCanvasElement>(
        document.getElementById("mainBarChartCanvas")
    );
    const ctx = canvas.getContext("2d");
    var myChart = new Chart(ctx, {
    type: 'bar',
    data: {
        labels: ["Red", "Blue", "Yellow", "Green", "Purple", "Orange"],
        datasets: [{
            label: '# of Votes',
            data: [12, 19, 3, 5, 2, 3],
            backgroundColor: [
                'rgba(255, 99, 132, 0.2)',
                'rgba(54, 162, 235, 0.2)',
                'rgba(255, 206, 86, 0.2)',
                'rgba(75, 192, 192, 0.2)',
                'rgba(153, 102, 255, 0.2)',
                'rgba(255, 159, 64, 0.2)'
            ],
            borderColor: [
                'rgba(255,99,132,1)',
                'rgba(54, 162, 235, 1)',
                'rgba(255, 206, 86, 1)',
                'rgba(75, 192, 192, 1)',
                'rgba(153, 102, 255, 1)',
                'rgba(255, 159, 64, 1)'
            ],
            borderWidth: 1
        }]
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
          }
        }
    }
});
}
}
