import { Component, OnInit } from "@angular/core";
import { Appointment } from "../models/appointment.model";
import { BusinessReportDentist } from "../models/businessReportDentist.model";
import { AppointmentService } from "../services/appointment.service";
import { DentistService } from "../services/dentist.service";
import { PaymentService } from "../services/payment.service";
import { ReportService } from "../services/report.service";
import { UserService } from "../services/user.service";


@Component({
  selector: "app-home",
  templateUrl: "./home.component.html",
  styleUrls: ["./home.component.css"],
  providers: [DentistService, UserService, AppointmentService, PaymentService, ReportService]
})
export class HomeComponent implements OnInit {
  showHomeMain: boolean;
  constructor(private _dentistService: DentistService,
     private _clientService: UserService,
      private _appointmentService: AppointmentService,
       _paymentService: PaymentService) {}

  ngOnInit() {
    this.Collapse();
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


}
