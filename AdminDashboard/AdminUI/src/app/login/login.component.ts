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
  username: string;
  password: string;
  err: any;
  user: User;
  constructor(private _userService: UserService, private router: Router) {}

  ngOnInit() {}

    login(loginForm: NgForm): void {
      this._userService.username = this.username;
      this._userService.password = this.password;
      this._userService.getUser(1).subscribe(usersData => { this.user = usersData; console.log(usersData)},(error) => {
        this.err = error;
      },
       () => {
         if(this.user){
          this.router.navigate(["/home"]);
         }
       });
    }
}
