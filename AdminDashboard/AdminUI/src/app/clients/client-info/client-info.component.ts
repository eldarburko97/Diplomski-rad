import { Component, OnInit } from "@angular/core";
import { DomSanitizer } from "@angular/platform-browser";
import { ActivatedRoute } from "@angular/router";
import { City } from "src/app/models/city.model";
import { Gender } from "src/app/models/gender.model";
import { User } from "src/app/models/user.model";
import { UserService } from "src/app/services/user.service";

@Component({
  selector: "app-client-info",
  templateUrl: "./client-info.component.html",
  styleUrls: ["./client-info.component.css"],
  providers: [UserService],
})
export class ClientInfoComponent implements OnInit {
  id: number;
  client: User = new User(0,"","","","","","",new Date(),null,new City(), new Gender());
  clientImage: any;
  constructor(
    private route: ActivatedRoute,
    private _clientService: UserService,
    public domSanitizer: DomSanitizer
  ) {}

  ngOnInit() {
    this.id = parseInt(this.route.snapshot.paramMap.get("clientID"));
    console.log(this.id);
    this._clientService.getUser(this.id).subscribe(res => this.client = res, err => console.log(err), () => this.clientImage = this.client.image);
  }
}
