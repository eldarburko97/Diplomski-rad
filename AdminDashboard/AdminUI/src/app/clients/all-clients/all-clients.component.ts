import { Component, OnInit } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { User } from 'src/app/models/user.model';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-all-clients',
  templateUrl: './all-clients.component.html',
  styleUrls: ['./all-clients.component.css'],
  providers: [UserService]
})
export class AllClientsComponent implements OnInit {
  p: number = 1;
  total: any;
  err: any;
  collection: User[] = [];
  imageUrl:string;
  firstName: string;
  lastName: string;

  constructor(private _userService: UserService, public domSanitizer: DomSanitizer) { }

  ngOnInit() {
    // this._userService.getUsers().subscribe(
    //   (clientsData) => (this.collection = clientsData), err => console.log(err), () => {
    //     if (this.collection) {
    //       this.total = this.collection.length;
    //     }
    //   }
    // );

    this._userService.getUsers().subscribe(res => {
      for(let i = 0; i < res.length; i++) {
          for(let j = 0; j < res[i].userRoles.length; j++) {
            if(res[i].userRoles[j].role.name == "Client") {
                this.collection.push(res[i]);
                console.log(res[i]);
            }
          }
      }
    }, err => console.log(err), () => {

    })
  }

  searchClients() {

  }

}
