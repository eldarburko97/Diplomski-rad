import { HttpClient, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { HttpHeaders } from "@angular/common/http";
import { Dentist } from "../models/dentist.model";

@Injectable()
export class DentistService {
  readonly rootURL = 'http://localhost:62292/api/Dentists';
  formData: Dentist;
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

  getDentists(): Observable<Dentist[]> {
    let authorizationData = "Basic " + btoa("desktop" + ":" + "test");

    const headerOptions = {
      headers: new HttpHeaders({
        "Content-Type": "application/json",
        Authorization: authorizationData,
      }),
    };
    return this.httpClient.get<Dentist[]>(
      "http://localhost:62292/api/Dentists",
      headerOptions
    );
    // return this.httpClient.get<User[]>('http://localhost:5000/api/Users', headerOptions);
  }

  getDentist(id: number): Observable<Dentist> {
    let authorizationData = "Basic " + btoa("desktop" + ":" + "test");

    const headerOptions = {
      headers: new HttpHeaders({
        "Content-Type": "application/json",
        Authorization: authorizationData,
      }),
    };
    return this.httpClient.get<Dentist>(
      `http://localhost:62292/api/Dentists/${id}`,
      headerOptions
    );
  }

  insertDentist(dentist: FormData) {
    console.log(dentist.get('firstName'));
    return this.httpClient.post(this.rootURL, dentist, this.headerOptions);
  }

  searchDentists(firstName: string, lastName: string): Observable<Dentist[]> {
    const params = new HttpParams()
    .set('firstName', firstName)
    .set('lastName', lastName);
    return this.httpClient.get<Dentist[]>(this.rootURL, {headers: new HttpHeaders({
      "Content-Type": "application/json",
      Authorization: this.authorizationData,
    }), params: params});
  }

  deleteDentist(id: number) {
    return this.httpClient.delete(`${this.rootURL}/${id}`,this.headerOptions);
  }

}
