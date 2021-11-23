import { HttpClient, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { HttpHeaders } from "@angular/common/http";
import { Dentist } from "../models/dentist.model";
import { Treatment } from "../models/treatment.model";
import { Appointment } from "../models/appointment.model";
import { DatePipe } from '@angular/common'

@Injectable()
export class AppointmentService {
  readonly rootURL = 'http://localhost:62292/api/Appointments';
  authorizationData = "Basic " + btoa("desktop" + ":" + "test");

     headerOptions = {
      headers: new HttpHeaders({
        "Content-Type": "application/json",
        Authorization: this.authorizationData,
      }),
    };
  /**
   *
   */
  constructor(private httpClient: HttpClient, public datepipe: DatePipe) {}

  getAppointments(): Observable<Appointment[]> {
    let authorizationData = "Basic " + btoa("desktop" + ":" + "test");

    const headerOptions = {
      headers: new HttpHeaders({
        "Content-Type": "application/json",
        Authorization: authorizationData,
      }),
    };
    return this.httpClient.get<Appointment[]>(this.rootURL,headerOptions);
  }

  searchAppointments(startDate: Date, endDate: Date): Observable<Appointment[]> {
    const params = new HttpParams()
    .set('startDate', this.datepipe.transform(startDate, 'yyyy-MM-dd'))
    .set('endDate', this.datepipe.transform(endDate, 'yyyy-MM-dd'));
    return this.httpClient.get<Appointment[]>(this.rootURL, {headers: new HttpHeaders({
      "Content-Type": "application/json",
      Authorization: this.authorizationData,
    }), params: params});
  }

  // getTreatment(id: number): Observable<Treatment> {
  //   let authorizationData = "Basic " + btoa("desktop" + ":" + "test");

  //   const headerOptions = {
  //     headers: new HttpHeaders({
  //       "Content-Type": "application/json",
  //       Authorization: authorizationData,
  //     }),
  //   };
  //   return this.httpClient.get<Treatment>(
  //     `http://localhost:62292/api/Treatments/${id}`,
  //     headerOptions
  //   );
  // }



}
