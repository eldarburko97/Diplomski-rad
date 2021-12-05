import { HttpClient, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { HttpHeaders } from "@angular/common/http";
import { BusinessReportDentist } from "../models/businessReportDentist.model";
import { DatePipe } from "@angular/common";
import { BestSellingTreatment } from "../models/bestSellingTreatment.model";

@Injectable()
export class ReportService {
  readonly rootURL = "http://localhost:62292/api/Report";
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

  getBusinessReportDentists(startDate: Date, endDate: Date): Observable<BusinessReportDentist[]> {
    const params = new HttpParams()
      .set("startDate", this.datepipe.transform(startDate, "yyyy-MM-dd"))
      .set("endDate", this.datepipe.transform(endDate, "yyyy-MM-dd"));

    return this.httpClient.get<BusinessReportDentist[]>(`${this.rootURL}/get-business-report-dentists`, {
      headers: new HttpHeaders({
        "Content-Type": "application/json",
        Authorization: this.authorizationData,
      }),
      params: params,
    });
  }

  getBestSellingTreatment(startDate: Date, endDate: Date): Observable<BestSellingTreatment[]> {
    const params = new HttpParams()
      .set("startDate", this.datepipe.transform(startDate, "yyyy-MM-dd"))
      .set("endDate", this.datepipe.transform(endDate, "yyyy-MM-dd"));

    return this.httpClient.get<BestSellingTreatment[]>(`${this.rootURL}/get-best-selling-treatment`, {
      headers: new HttpHeaders({
        "Content-Type": "application/json",
        Authorization: this.authorizationData,
      }),
      params: params,
    });
  }
}
