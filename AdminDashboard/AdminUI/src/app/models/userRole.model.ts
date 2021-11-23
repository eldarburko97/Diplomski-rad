import { Role } from "./role.model";
import { User } from "./user.model";

export class UserRole {
  userID: number;
  roleID: number;
  user: User;
  role: Role
}
