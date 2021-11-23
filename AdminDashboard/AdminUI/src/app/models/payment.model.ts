import { Treatment } from "./treatment.model";
import { User } from "./user.model";

export class Payment {
  userID: number;
  treatmentID: number;
  amount: number;
  date: Date;
  user: User;
  treatment: Treatment

  /**
   *
   */
  constructor(userID: number, treatmentID: number, amount: number, date: Date) {
    this.userID = userID,
    this.treatmentID = treatmentID,
    this.amount = amount,
    this.date = date
  }
}
