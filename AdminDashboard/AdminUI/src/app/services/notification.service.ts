import { HttpClient, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { HttpHeaders } from "@angular/common/http";
import { DatePipe } from "@angular/common";
import { Notification } from "../models/notification.model";

@Injectable()
export class NotificationService {
  readonly rootURL = 'http://localhost:62292/api/Notifications';
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

  getNotifications(): Observable<Notification[]> {
    return this.httpClient.get<Notification[]>(this.rootURL,this.headerOptions);
  }

  getNotification(id: number): Observable<Notification> {
    return this.httpClient.get<Notification>(`${this.rootURL}/${id}`,this.headerOptions);
  }

  searchNotifications(startDate: Date, endDate: Date): Observable<Notification[]> {
    const params = new HttpParams()
    .set('startDate', this.datepipe.transform(startDate, 'yyyy-MM-dd'))
    .set('endDate', this.datepipe.transform(endDate, 'yyyy-MM-dd'));

    return this.httpClient.get<Notification[]>(this.rootURL, {headers: new HttpHeaders({
      "Content-Type": "application/json",
      Authorization: this.authorizationData,
    }), params: params});
  }

  // insert(notification: Notification) {
  //   return this.httpClient.post(this.rootURL, notification, this.headerOptions);
  // }
}
