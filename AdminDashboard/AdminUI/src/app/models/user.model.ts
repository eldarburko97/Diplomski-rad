import { City } from "./city.model";
import { Gender } from "./gender.model";
import { UserRole } from "./userRole.model";

export class User {
    userID:number;
    firstName: string;
    lastName: string;
    username: string
    phone: string;
    email: string;
    address: string;
    birthDate: Date;
    image: File;
    city: City;
    gender: Gender;
    userRoles: UserRole[]

    /**
     *
     */
    constructor(userID:number, FirstName: string, LastName: string, Username: string, Phone: string, Email:string, Address: string, BirthDate: Date, Image: File, city: City, gender: Gender) {
      this.userID = userID,
      this.firstName = FirstName,
      this.lastName = LastName,
      this.username = Username,
      this.phone = Phone,
      this.email = Email,
      this.address = Address,
      this.birthDate = BirthDate,
      this.image = Image,
      this.city = city,
      this.gender = gender
    }
}
