import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { User } from "../models/user.model";
import { HttpHeaders } from '@angular/common/http';

@Injectable()
export class UserService {
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
        let authorizationData = 'Basic ' + btoa(this.username + ':' + this.password);

        const headerOptions = {
          headers: new HttpHeaders({
            'Content-Type': 'application/json',
            'Authorization': authorizationData
          })
        };
        return this.httpClient.get<User[]>('http://localhost:62292/api/Users', headerOptions);
    }
}