import { HttpClient, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { HttpHeaders } from "@angular/common/http";
import { Payment } from "../models/payment.model";
import { DatePipe } from "@angular/common";

@Injectable()
export class PaymentService {
  readonly rootURL = 'http://localhost:62292/api/Payments';
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

  getPayments(): Observable<Payment[]> {
    return this.httpClient.get<Payment[]>(this.rootURL,this.headerOptions);
  }

  searchPayments(firstName: string,lastName: string,dateFrom: Date, dateTo: Date): Observable<Payment[]> {
    const params = new HttpParams()
    .set('dateFrom', this.datepipe.transform(dateFrom, 'yyyy-MM-dd'))
    .set('dateTo', this.datepipe.transform(dateTo, 'yyyy-MM-dd'))
    .set('firstName', firstName)
    .set('lastName', lastName);
    return this.httpClient.get<Payment[]>(this.rootURL, {headers: new HttpHeaders({
      "Content-Type": "application/json",
      Authorization: this.authorizationData,
    }), params: params});
  }


  insert(payment: Payment) {
    return this.httpClient.post(this.rootURL, payment, this.headerOptions);
  }


}
