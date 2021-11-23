import { Dentist } from "./dentist.model";
import { Treatment } from "./treatment.model";
import { User } from "./user.model";

export class Appointment {
  startDate: Date;
  endDate: Date;
  user: User;
  dentist: Dentist;
  treatment: Treatment
}
