import { HttpClient, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { HttpHeaders } from "@angular/common/http";
import { Dentist } from "../models/dentist.model";
import { Treatment } from "../models/treatment.model";
import { BusinessReportDentist } from "../models/businessReportDentist.model";

@Injectable()
export class ReportService {
  readonly rootURL = 'http://localhost:62292/api/Report';
  formData: Treatment;
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
  constructor(private httpClient: HttpClient) {}

  getBusinessReportDentists(): Observable<BusinessReportDentist[]> {
    let authorizationData = "Basic " + btoa("desktop" + ":" + "test");

    const headerOptions = {
      headers: new HttpHeaders({
        "Content-Type": "application/json",
        Authorization: authorizationData,
      }),
    };
    return this.httpClient.get<BusinessReportDentist[]>(`${this.rootURL}/get-business-report-dentists`,headerOptions);
  }

  getTreatment(id: number): Observable<Treatment> {
    let authorizationData = "Basic " + btoa("desktop" + ":" + "test");

    const headerOptions = {
      headers: new HttpHeaders({
        "Content-Type": "application/json",
        Authorization: authorizationData,
      }),
    };
    return this.httpClient.get<Treatment>(
      `http://localhost:62292/api/Treatments/${id}`,
      headerOptions
    );
  }

  insertDentist(dentist: FormData) {
    console.log(dentist.get('firstName'));
    return this.httpClient.post(this.rootURL, dentist, this.headerOptions);
  }

  searchTreatments(name: string): Observable<Treatment[]> {
    const params = new HttpParams()
    .set('name', name);
    return this.httpClient.get<Treatment[]>(this.rootURL, {headers: new HttpHeaders({
      "Content-Type": "application/json",
      Authorization: this.authorizationData,
    }), params: params});
  }

}
