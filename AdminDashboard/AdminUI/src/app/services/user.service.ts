import { HttpClient, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { User } from "../models/user.model";
import { HttpHeaders } from '@angular/common/http';

@Injectable()
export class UserService {
  readonly rootURL = 'http://localhost:62292/api/Users';

    /**
     *
     */
    username: string;
    password: string;
    constructor(private httpClient: HttpClient) {

    }

    // authorizationData = "Basic " + btoa(this.username + ":" + this.password);
    authorizationData = "Basic " + btoa("desktop" + ":" + "test");

     headerOptions = {
      headers: new HttpHeaders({
        "Content-Type": "application/json",
        Authorization: this.authorizationData,
      }),
    };

    getUsers(): Observable<User[]> {
      console.log(this.username);
        return this.httpClient.get<User[]>('http://localhost:62292/api/Users', this.headerOptions);
    }

    getUser(id :number): Observable<User> {
      if(this.username && this.password) {
        this.headerOptions = {
          headers: new HttpHeaders({
            "Content-Type": "application/json",
             Authorization: "Basic " + btoa(this.username + ":" + this.password)
          })
        };
      }
      return this.httpClient.get<User>(`${this.rootURL}/${id}`,this.headerOptions);
    }

    searchUsers(firstName: string, lastName: string): Observable<User[]> {
      const params = new HttpParams()
      .set('firstName', firstName)
      .set('lastName', lastName);
      return this.httpClient.get<User[]>(this.rootURL, {headers: new HttpHeaders({
        "Content-Type": "application/json",
        Authorization: this.authorizationData,
      }), params: params});
    }
}
