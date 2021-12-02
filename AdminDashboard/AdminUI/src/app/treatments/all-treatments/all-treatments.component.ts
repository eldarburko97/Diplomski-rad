import { Component, OnInit } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { Router } from '@angular/router';
import { Treatment } from 'src/app/models/treatment.model';
import { TreatmentService } from 'src/app/services/treatment.service';

@Component({
  selector: 'app-all-treatments',
  templateUrl: './all-treatments.component.html',
  styleUrls: ['./all-treatments.component.css'],
  providers: [TreatmentService],
})
export class AllTreatmentsComponent implements OnInit {
  p: number = 1;
  total: any;
  err: any;
  collection: Treatment[];
  imageUrl:string;
  name: string = "";
  constructor(private _treatmentService: TreatmentService, private _router: Router, public domSanitizer: DomSanitizer) { }

  ngOnInit() {
    this._treatmentService.getTreatments().subscribe(res => this.collection = res, err => console.log(err), () => {console.log(this.collection)});
  }

  _toBase64(imageBinary) {
    let imageBase64String = btoa(imageBinary);
    this.imageUrl = "data:image/PNG;base64," + imageBase64String;
    return this.imageUrl;
  }

  search() {
    this.collection = [];
    this._treatmentService.searchTreatments(this.name).subscribe(res => this.collection = res, err => console.log(err));
  }

}
