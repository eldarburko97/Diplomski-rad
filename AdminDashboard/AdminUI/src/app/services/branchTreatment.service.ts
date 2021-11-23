import { HttpClient, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { HttpHeaders } from "@angular/common/http";
import { Dentist } from "../models/dentist.model";
import { Treatment } from "../models/treatment.model";
import { BranchTreatment } from "../models/branchTreatment.model";

@Injectable()
export class BranchTreatmentService {
  readonly rootURL = 'http://localhost:62292/api/BranchTreatments';
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

  getBrancTreatments(id :number): Observable<BranchTreatment[]> {
    const params = new HttpParams()
    .set('branchID', id.toString());
    return this.httpClient.get<BranchTreatment[]>(this.rootURL,{headers: new HttpHeaders({
      "Content-Type": "application/json",
      Authorization: this.authorizationData,
    }), params: params});
  }

  // getTreatment(id: number): Observable<Treatment> {
  //   let authorizationData = "Basic " + btoa("desktop" + ":" + "test");

  //   const headerOptions = {
  //     headers: new HttpHeaders({
  //       "Content-Type": "application/json",
  //       Authorization: authorizationData,
  //     }),
  //   };
  //   return this.httpClient.get<Treatment>(
  //     `http://localhost:62292/api/Treatments/${id}`,
  //     headerOptions
  //   );
  // }

  insertBranchTreatment(branchTreatment: BranchTreatment) {
    return this.httpClient.post(this.rootURL, branchTreatment, this.headerOptions);
  }

  deleteBranchTreatment(branchTreatmentID: number): Observable<BranchTreatment> {
    return this.httpClient.delete<BranchTreatment>(`${this.rootURL}/${branchTreatmentID}`, this.headerOptions);
  }
}
