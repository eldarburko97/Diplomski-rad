import { Component, OnInit } from "@angular/core";
import { Dentist } from "src/app/models/dentist.model";
import { DentistService } from "src/app/services/dentist.service";
import { DomSanitizer } from '@angular/platform-browser';

@Component({
  selector: "app-all-dentists",
  templateUrl: "./all-dentists.component.html",
  styleUrls: ["./all-dentists.component.css"],
  providers: [DentistService],
})
export class AllDentistsComponent implements OnInit {
  p: number = 1;
  total: any;
  err: any;
  collection: Dentist[];
  imageUrl:string;
  firstName:string = "";
  lastName:string = "";

  constructor(private _dentistService: DentistService, public domSanitizer: DomSanitizer) {}

  ngOnInit() {
    this._dentistService.getDentists().subscribe(
      (dentistsData) => (this.collection = dentistsData),
      (error) => {
        this.err = error;
        if (this.err) console.log(this.err);
        else console.log("Nema error");
      },
      () => {
        if (this.collection) {
          // this.router.navigate(["/home"]);
          // console.log(this.collection);
          this.total = this.collection.length;
          // this.collection.forEach((element) => {
          //    element.image = this._toBase64(element.image);
          //   //  console.log(element.image);
          // });
        }
      }
    );
  }

  //  _arrayBufferToBase64( buffer ) {
  //   //  console.log(buffer);
  //   var binary = '';
  //   var bytes = new Uint8Array( buffer );
  //   var len = bytes.byteLength;
  //   for (var i = 0; i < len; i++) {
  //     binary += String.fromCharCode( bytes[ i ] );
  //   }
  //   console.log(window.btoa(binary));
  //   return window.btoa( binary );
  // }

  _toBase64(imageBinary) {
    let imageBase64String = btoa(imageBinary);
    this.imageUrl = "data:image/PNG;base64," + imageBase64String;
    return this.imageUrl;
  }

  searchDentists() {
    this.collection = [];
    this._dentistService.searchDentists(this.firstName, this.lastName).subscribe(res => this.collection = res, err => console.log(err));
  }


}
