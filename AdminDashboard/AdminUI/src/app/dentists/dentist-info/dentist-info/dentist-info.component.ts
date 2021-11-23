import { Component, Input, OnInit } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { formatDate } from "@angular/common";
import { Dentist } from "src/app/models/dentist.model";
import { DentistService } from "src/app/services/dentist.service";
import { Branch } from "src/app/models/branch.model";
import { DomSanitizer } from "@angular/platform-browser";
import { NgForm } from "@angular/forms";
import { BranchService } from "src/app/services/branch.service";
import { convertActionBinding } from "@angular/compiler/src/compiler_util/expression_converter";
import { HttpClient } from "@angular/common/http";
import { DatePipe } from "@angular/common";
import { ResponseContentType } from "@angular/http";
import { saveAs } from "file-saver";
import {NgbDateStruct} from '@ng-bootstrap/ng-bootstrap';
import { BsDatepickerConfig } from "ngx-bootstrap/datepicker";

@Component({
  selector: "app-dentist-info",
  templateUrl: "./dentist-info.component.html",
  styleUrls: ["./dentist-info.component.css"],
  providers: [DentistService, BranchService],
})
export class DentistInfoComponent implements OnInit {
  datePickerConfig: Partial<BsDatepickerConfig>;
  id: number;
  dentist: Dentist;
  fileChosen: boolean = false;
  fileName: string;
  err: any;
  rezultat: any = "./assets/images/userDefault.png";
  imageExist: boolean = false;
  branches: Branch[];
  img: any; // Image koju je admin uploadovo
  selectedFile: File = null;
  dentistImage: any; // Image koju dentist vec ima
  defaultImage: File;
  url: any;
  birth: Date = new Date();
  constructor(
    private route: ActivatedRoute,
    private _dentistService: DentistService,
    private _branchService: BranchService,
    public domSanitizer: DomSanitizer,
    private router: Router,
    private http: HttpClient,
    public datepipe: DatePipe
  ) {
    this._branchService.getBranches().subscribe(
      (res) => (this.branches = res),
      (err) => console.log(err),
      () => {}
    );
    this.datePickerConfig = Object.assign({}, {containerClass: 'theme-dark-blue', showWeekNumbers: false, dateInputFormat: 'YYYY/MM/DD'});
  }

  ngOnInit() {
    // Mora stajati ovo prvo
    this.dentist = {
      dentistID: 0,
      dentalClinicID: 0,
      branchID: 0,
      firstName: "",
      lastName: "",
      phone: "",
      email: "",
      address: "",
      birthDate: new Date(),
      image: null,
      description: "",
      active: false,
    };

    if (this.route.snapshot.paramMap.get("dentistID")) {
      this.route.paramMap.subscribe((paramMap) => {
        this.id = parseInt(paramMap.get("dentistID"));
      });
      this._dentistService.getDentist(this.id).subscribe(
        (dentistData) => {
          this.dentist = dentistData;
          this.imageExist = true;
          this.dentistImage = dentistData.image;
          // console.log(typeof this.dentistImage);
          // console.log(this.dentistImage);
        },
        (error) => {
          this.err = error;
          if (this.err) console.log(this.err);
          else console.log("Nema error");
        }
      );
    } else {
      this.getBase64ImageFromUrl("./assets/images/userDefault.png")
        .then((result) => {
          this.dentistImage = result;
          this.imageExist = false;
        })
        .catch((err) => console.error(err));
      this.dentist = {
        dentistID: 0,
        dentalClinicID: 0,
        branchID: 0,
        firstName: "",
        lastName: "",
        phone: "",
        email: "",
        address: "",
        birthDate: new Date(),
        image: null,
        description: "",
        active: false,
        // branch: new Branch(),
      };
    }
  }

  onFileSelected(event) {
    if (event.target.files.length > 0) {
      this.fileChosen = true;
      this.fileName = event.target.files[0].name;
      this.img = event.target.files[0]; // Uploadovana slika
      let file = event.target.files[0];
      var reader = new FileReader();
      reader.onload = (event: any) => {
        this.url = event.target.result;
        this.dentistImage = event.target.result;
        // console.log(this.url);
      }
      reader.readAsDataURL(event.target.files[0]);

    } else this.fileChosen = false;
  }

  async getBase64ImageFromUrl(imageUrl) {
    var res = await fetch(imageUrl);
    var blob = await res.blob();

    return new Promise((resolve, reject) => {
      var reader = new FileReader();
      reader.addEventListener(
        "load",
        function () {
          resolve(reader.result);
        },
        false
      );

      reader.onerror = () => {
        return reject(this);
      };
      reader.readAsDataURL(blob);
    });
  }

  onSubmit(form: NgForm) {
    if (this.dentist.dentistID == 0) {
      this.insertRecord(form);
    } else this.updateRecord(form);
  }

  insertRecord(form: NgForm) {
    const newDentist: Dentist = Object.assign({}, this.dentist);
    const fileData = new FormData();
    fileData.append("firstName", newDentist.firstName);
    fileData.append("lastName", newDentist.lastName);
    fileData.append("email", newDentist.email);
    fileData.append("address", newDentist.address);
    fileData.append("phone", newDentist.phone);
    fileData.append("dentalClinicID", "1");
    fileData.append("branchID", newDentist.branchID.toString());
    fileData.append("description", newDentist.description);
    fileData.append(
      "birthDate",
      this.datepipe.transform(newDentist.birthDate, "yyyy-MM-dd")
    );
    fileData.append("active", newDentist.active.toString());

    if (this.img) {
      newDentist.image = this.img;
      fileData.append("image", newDentist.image);
      this.http.post("http://localhost:62292/api/Dentists/insert", fileData).subscribe(
        (res) => console.log(res),
        (err) => console.log(this.err),
        () => {
          this.router.navigate(["/home/all-dentists"]);
        }
      );
    } else {
      this.http
        .get("./assets/images/userDefault.png", { responseType: "blob" })
        .subscribe(
          (res) => {
            this.defaultImage = new File([res], "userDefault.png");
            fileData.append("image", this.defaultImage);
          },
          (err) => console.log(err),
          () => {
            // console.log(fileData.get("image"));
            // this.http.post('http://localhost:62292/api/values', fileData).subscribe(res => console.log(res));
            this.http
              .post("http://localhost:62292/api/Dentists/insert", fileData)
              .subscribe(
                (res) => console.log(res),
                (err) => console.log(this.err),
                () => {
                  this.router.navigate(["/home/all-dentists"]);
                }
              );
          }
        );
    }

    // console.log(`First name: ${fileData.get("firstName")}`);
    // console.log(`Last name: ${fileData.get("lastName")}`);
    // console.log(`Email: ${fileData.get("email")}`);
    // console.log(`Address: ${fileData.get("address")}`);
    // console.log(`Phone: ${fileData.get("phone")}`);
    // console.log(`DentalClinicID: ${fileData.get("dentalClinicID")}`);
    // console.log(`BranchID: ${fileData.get("branchID")}`);
    // console.log(`Description: ${fileData.get("description")}`);
    // console.log(`BirthDate: ${fileData.get("birthDate")}`);
    // console.log(`Active: ${fileData.get("active")}`);
    // // console.log(`Image: ${fileData.get("image")}`);
    // console.log(fileData.get("image"));
  }

  updateRecord(form: NgForm) {
    const updatedDentist: Dentist = Object.assign({}, this.dentist);
    console.log(updatedDentist);
    const fileData = new FormData();
    fileData.append("dentistID", updatedDentist.dentistID.toString());
    fileData.append("firstName", updatedDentist.firstName);
    fileData.append("lastName", updatedDentist.lastName);
    fileData.append("email", updatedDentist.email);
    fileData.append("address", updatedDentist.address);
    fileData.append("phone", updatedDentist.phone);
    fileData.append("dentalClinicID", "1");
    fileData.append("branchID", updatedDentist.branchID.toString());
    fileData.append("description", updatedDentist.description);
    fileData.append(
      "birthDate",
      this.datepipe.transform(updatedDentist.birthDate, "yyyy-MM-dd")
    );
    fileData.append("active", updatedDentist.active.toString());
    if (this.img) {
      updatedDentist.image = this.img;
      fileData.append("image", updatedDentist.image);
      // console.log(updatedDentist.image);
      this.http
      .put("http://localhost:62292/api/Dentists/" + updatedDentist.dentistID, fileData)
      .subscribe(
        (res) => console.log(res),
        (err) => console.log(this.err),
        () => {
          this.router.navigate(["/home/all-dentists"]);
        }
      );
      fileData.append("image", updatedDentist.image);
       } else {
      updatedDentist.image = this.dentistImage;
      this.http
        .put("http://localhost:62292/api/Dentists/" + updatedDentist.dentistID, fileData)
        .subscribe(
          (res) => console.log(res),
          (err) => console.log(this.err),
          () => {
            this.router.navigate(["/home/all-dentists"]);
          }
        );
    }
  }
}
