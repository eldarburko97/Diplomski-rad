import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { HttpHeaders } from "@angular/common/http";
import { Dentist } from "../models/dentist.model";
import { Treatment } from "../models/treatment.model";

@Injectable()
export class TreatmentService {
  readonly rootURL = 'http://localhost:62292/api/Dentists';
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

  getTreatments(): Observable<Treatment[]> {
    let authorizationData = "Basic " + btoa("desktop" + ":" + "test");

    const headerOptions = {
      headers: new HttpHeaders({
        "Content-Type": "application/json",
        Authorization: authorizationData,
      }),
    };
    return this.httpClient.get<Treatment[]>(
      "http://localhost:62292/api/Treatments",
      headerOptions
    );
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


}
