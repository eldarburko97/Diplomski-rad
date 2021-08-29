import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { User } from '../models/user.model';
import { UserService } from '../services/user.service';




@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
  providers: [UserService]
})
export class LoginComponent implements OnInit {
  users: User[];
  username: string;
  password: string;
  constructor(private _userService: UserService) { 
  
  }

  sendValuesIntoService(username: string, password: string) {
    this._userService.setValues(username,password);
  }

  ngOnInit() {
    // this._userService.getUsers().subscribe(usersData => this.users = usersData);
  }

  // login(): void {
  //   this._userService.getUsers().subscribe(usersData => this.users = usersData);
  //   console.log(this.users);
  // }

    login(loginForm: NgForm): void {
      // console.log(loginForm.value);
      this.sendValuesIntoService(this.username,this.password);
      this._userService.getUsers().subscribe(usersData => this.users = usersData);
    }
}
