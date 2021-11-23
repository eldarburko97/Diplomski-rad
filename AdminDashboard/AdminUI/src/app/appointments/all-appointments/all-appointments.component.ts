import { Component, OnInit } from '@angular/core';
import { Appointment } from 'src/app/models/appointment.model';
import { AppointmentService } from 'src/app/services/appointment.service';
import { BsDatepickerConfig } from "ngx-bootstrap/datepicker";

@Component({
  selector: 'app-all-appointments',
  templateUrl: './all-appointments.component.html',
  styleUrls: ['./all-appointments.component.css'],
  providers: [AppointmentService]
})
export class AllAppointmentsComponent implements OnInit {
  search: string;
  appointments: Appointment[];
  datePickerConfig: Partial<BsDatepickerConfig>;
  startDate: Date = new Date();
  endDate: Date = new Date();

  constructor(private _appointmentService: AppointmentService) {
    this.datePickerConfig = Object.assign({}, {containerClass: 'theme-dark-blue', showWeekNumbers: false, dateInputFormat: 'YYYY/MM/DD'});
  }

  ngOnInit() {
    this._appointmentService.getAppointments().subscribe(res => this.appointments = res, err => console.log(err), () => console.log(this.appointments));
    console.log(this.startDate);
    console.log(this.endDate);
    if(this.startDate < this.endDate) console.log("aa");
  }

  onInput() {
    // this._appointmentService.searchBranches(this.search, this.search).subscribe(res => this.branches = res);
    console.log(this.startDate);
  }

  searchAppointments() {
    this._appointmentService.searchAppointments(this.startDate, this.endDate).subscribe(res => this.appointments = res, err => console.log(err));
  }

}
