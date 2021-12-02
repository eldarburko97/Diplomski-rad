import { Component, OnInit } from "@angular/core";
import { Appointment } from "../models/appointment.model";
import { AppointmentDTO } from "../models/appointmentDTO.model";
import { AppointmentService } from "../services/appointment.service";
import { DashboarService } from "../services/dashboard.service";
import { DentistService } from "../services/dentist.service";
import { PaymentService } from "../services/payment.service";
import { UserService } from "../services/user.service";

@Component({
  selector: "app-home-main",
  templateUrl: "./home-main.component.html",
  styleUrls: ["./home-main.component.css"],
  providers: [DashboarService],
})
export class HomeMainComponent implements OnInit {
  dentists: number = 0;
  clients: number = 0;
  appointments: number = 0;
  recentAppointments: AppointmentDTO[] = [];
  earnings: number = 0;
  /**
   *
   */
  constructor(private _dashboardService: DashboarService) {

  }

  ngOnInit() {
    this._dashboardService.getDashboardInfo().subscribe(res => {
      this.dentists = res.dentists;
      this.clients = res.clients;
      this.appointments = res.appointments;
      this.recentAppointments = res.recentAppointments;
      this.earnings = res.earnings;
    }, err => console.log(err));
  }
}
