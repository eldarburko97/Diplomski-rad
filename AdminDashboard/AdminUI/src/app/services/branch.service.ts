import { HttpClient, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { HttpHeaders } from "@angular/common/http";
import { Dentist } from "../models/dentist.model";
import { Branch } from "../models/branch.model";

@Injectable()
export class BranchService {
  readonly rootURL = "http://localhost:62292/api/Branches";
  formData: Dentist;
  authorizationData = "Basic " + btoa("desktop" + ":" + "test");

  headerOptions = {
    headers: new HttpHeaders({
      "Content-Type": "application/json",
      Authorization: this.authorizationData,
    })
  };
  /**
   *
   */
  constructor(private httpClient: HttpClient) {}

  getBranches(): Observable<Branch[]> {
    return this.httpClient.get<Branch[]>(this.rootURL, this.headerOptions);
  }

  searchBranches(name: string): Observable<Branch[]> {
    const params = new HttpParams()
    .set('name', name);
    return this.httpClient.get<Branch[]>(this.rootURL, {headers: new HttpHeaders({
      "Content-Type": "application/json",
      Authorization: this.authorizationData,
    }), params: params});
  }

  getBranch(id: number): Observable<Branch> {
    return this.httpClient.get<Branch>(`${this.rootURL}/${id}`,this.headerOptions);
  }

  insertBranch(branch: Branch): Observable<Branch> {
    return this.httpClient.post<Branch>(`${this.rootURL}`, branch, this.headerOptions);
  }

  updateBranch(branch: Branch): Observable<Branch> {
    return this.httpClient.put<Branch>(`${this.rootURL}/update/${branch.branchID}`, branch, this.headerOptions);
  }
}
