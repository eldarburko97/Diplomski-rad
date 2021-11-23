import { HttpClient, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { User } from "../models/user.model";
import { HttpHeaders } from '@angular/common/http';

@Injectable()
export class UserService {
  readonly rootURL = 'http://localhost:62292/api/Users';
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
    username: string;
    password: string;
    constructor(private httpClient: HttpClient) {

    }

    public setValues(username: string, password: string) {
      this.username = username;
      this.password = password;
    }

    getUsers(): Observable<User[]> {
        return this.httpClient.get<User[]>('http://localhost:62292/api/Users', this.headerOptions);
    }

    getUser(id :number): Observable<User> {
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
