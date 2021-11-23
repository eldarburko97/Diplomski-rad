import { HttpClient } from '@angular/common/http';
import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { DomSanitizer } from '@angular/platform-browser';
import { ActivatedRoute, Router } from '@angular/router';
import { Treatment } from 'src/app/models/treatment.model';
import { TreatmentService } from 'src/app/services/treatment.service';

@Component({
  selector: 'app-treatment-info',
  templateUrl: './treatment-info.component.html',
  styleUrls: ['./treatment-info.component.css'],
  providers: [TreatmentService]
})
export class TreatmentInfoComponent implements OnInit {
  treatment: Treatment;
  imageExist: boolean = false;
  img: any; // Image koju je admin uploadovo
  treatmentImage: any; // Image koju dentist vec ima
  fileChosen: boolean = false;
  fileName: string;
  url: any;
  defaultImage: File;
  id: number;
  @ViewChild('form') public createTreatmentForm: NgForm;
  constructor(public domSanitizer: DomSanitizer, private http: HttpClient, private router: Router,  private route: ActivatedRoute, private _treatmentService: TreatmentService) { }

  ngOnInit() {
    this.treatment = new Treatment(0, "", 0, 0, null, false);
    // this.treatment = {
    //   treatmentID: 0,
    //   name: "",
    //   price: 0,
    //   timeRequired: 0,
    //   image: null
    // };
    // console.log(this.treatment);

    if (this.route.snapshot.paramMap.get("treatmentID")) {
      this.route.paramMap.subscribe((paramMap) => {
        this.id = parseInt(paramMap.get("treatmentID"));
      });
      this._treatmentService.getTreatment(this.id).subscribe(
        (treatmentData) => {
          this.treatment = treatmentData;
          this.imageExist = true;
          this.treatmentImage = treatmentData.image;
        },
        (error) => {
        console.log(error);
        }
      );
    } else {
      this.getBase64ImageFromUrl("./assets/images/treatment.jpg")
        .then((result) => {
          this.treatmentImage = result;
          this.imageExist = false;
        })
        .catch((err) => console.error(err));

      // this.treatment = {
      //   treatmentID: 0,
      //   name: "",
      //   price: 0,
      //   timeRequired: 0,
      //   image: null,
      // };
    }
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

  onFileSelected(event) {
    if (event.target.files.length > 0) {
      this.fileChosen = true;
      this.fileName = event.target.files[0].name;
      this.img = event.target.files[0]; // Uploadovana slika
      let file = event.target.files[0];
      var reader = new FileReader();
      reader.onload = (event: any) => {
        this.url = event.target.result;
        this.treatmentImage = event.target.result;
        // console.log(this.url);
      }
      reader.readAsDataURL(event.target.files[0]);

    } else this.fileChosen = false;
  }

  onSubmit(form: NgForm) {
    if (this.treatment.treatmentID == 0) {
      this.insertRecord(form);
    }
    // else this.updateRecord(form);
  }

  insertRecord(form: NgForm) {
    if(this.createTreatmentForm.invalid){
      this.ngOnInit();
    } else
    {
      const newTreatment: Treatment = Object.assign({}, this.treatment);
      const fileData = new FormData();
      fileData.append("name", newTreatment.name);
      fileData.append("price", newTreatment.price.toString());
      fileData.append("timeRequired", newTreatment.timeRequired.toString());

      if (this.img) {
        newTreatment.image = this.img;
        fileData.append("image", newTreatment.image);
        this.http.post("http://localhost:62292/api/Treatments/insert", fileData).subscribe(
          (res) => console.log(res),
          (err) => console.log(err),
          () => {
            this.router.navigate(["/home/all-dentists"]);
          }
        );
      } else {
        this.http
          .get("./assets/images/treatment.jpg", { responseType: "blob" })
          .subscribe(
            (res) => {
              this.defaultImage = new File([res], "treatment.jpg");
              fileData.append("image", this.defaultImage);
            },
            (err) => console.log(err),
            () => {
              // console.log(fileData.get("image"));
              // this.http.post('http://localhost:62292/api/values', fileData).subscribe(res => console.log(res));
              this.http
                .post("http://localhost:62292/api/Treatments/insert", fileData)
                .subscribe(
                  (res) => console.log(res),
                  (err) => console.log(err),
                  () => {
                    this.router.navigate(["/home/all-treatments"]);
                  }
                );
            }
          );
      }
    }

  }

  updateRecord(form: NgForm) {
    if(this.createTreatmentForm.invalid){
      this.ngOnInit();
    } else {
      const updatedTreatment: Treatment = Object.assign({}, this.treatment);
      console.log(updatedTreatment);
      const fileData = new FormData();
      fileData.append("treatmentID", updatedTreatment.treatmentID.toString());
      fileData.append("name", updatedTreatment.name);
      fileData.append("price", updatedTreatment.price.toString());
      fileData.append("timeRequired", updatedTreatment.timeRequired.toString());
      if (this.img) {
        updatedTreatment.image = this.img;
        fileData.append("image", updatedTreatment.image);
        // console.log(updatedDentist.image);
        this.http
        .put("http://localhost:62292/api/Treatments/" + updatedTreatment.treatmentID, fileData)
        .subscribe(
          (res) => console.log(res),
          (err) => console.log(err),
          () => {
            this.router.navigate(["/home/all-treatments"]);
          }
        );
        fileData.append("image", updatedTreatment.image);
         } else {
        updatedTreatment.image = this.treatmentImage;
        this.http
          .put("http://localhost:62292/api/Treatments/" + updatedTreatment.treatmentID, fileData)
          .subscribe(
            (res) => console.log(res),
            (err) => console.log(err),
            () => {
              this.router.navigate(["/home/all-treatments"]);
            }
          );
      }
    }
  }
}
