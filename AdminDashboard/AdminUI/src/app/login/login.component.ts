import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { User } from '../models/user.model';
import { UserService } from '../services/user.service';
import { CanActivate, CanActivateChild, Router, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';




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
  err: any;
  constructor(private _userService: UserService, private router: Router) {

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
      this._userService.getUsers().subscribe(usersData => this.users = usersData,(error) => {
        this.err = error;
        if(this.err) console.log(this.err); else console.log("Nema error");
      },
       () => {
         if(this.users){
          this.router.navigate(["/home"]);
         }
       });

      // if(this.users) console.log("Ima usera"); else console.log("Prazna lista");
    }
}
