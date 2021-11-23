import { last } from "@angular/router/src/utils/collection";
import { Branch } from "./branch.model";

export class Dentist {
  dentistID: number;
  dentalClinicID: number;
  branchID: number;
  firstName: string;
  lastName: string;
  phone: string;
  email: string;
  address: string;
  birthDate: Date;
  image: File;
  description: string;
  active: boolean;
  // branch: Branch;

  /**
   *
   */
  // constructor(
  //   dentistId: number,
  //   dentalClinicID: number,
  //   branchID: number,
  //   firstName: string,
  //   lastName: string,
  //   phone: string,
  //   email: string,
  //   address: string,
  //   birthDate: Date,
  //   image: string,
  //   description: string,
  //   active: boolean,
  //   // branch: Branch
  // ) {
  //   (this.dentistID = dentistId),
  //     (this.dentalClinicID = dentalClinicID),
  //     (this.branchID = branchID),
  //     (this.firstName = firstName),
  //     (this.lastName = lastName),
  //     (this.phone = phone),
  //     (this.email = email),
  //     (this.address = address),
  //     (this.birthDate = birthDate),
  //     (this.image = image),
  //     (this.description = description),
  //     (this.active = active),
  //     // (this.branch = branch);
  // }
}
