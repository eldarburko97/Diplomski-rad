import { HttpClient, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { HttpHeaders } from '@angular/common/http';
import { DashboardDTO } from "../models/dashboardDTO.model";

@Injectable()
export class DashboarService {
  readonly rootURL = 'http://localhost:62292/api/Dashboard';
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
    constructor(private httpClient: HttpClient) {

    }

    getDashboardInfo(): Observable<DashboardDTO> {
        return this.httpClient.get<DashboardDTO>(this.rootURL, this.headerOptions);
    }


}
