import { Component, OnInit, Testability, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Route, Router } from '@angular/router';
import { parse } from 'querystring';
import { Branch } from 'src/app/models/branch.model';
import { BranchTreatment } from 'src/app/models/branchTreatment.model';
import { Treatment } from 'src/app/models/treatment.model';
import { BranchService } from 'src/app/services/branch.service';
import { BranchTreatmentService } from 'src/app/services/branchTreatment.service';
import { TreatmentService } from 'src/app/services/treatment.service';

@Component({
  selector: 'app-branch-info',
  templateUrl: './branch-info.component.html',
  styleUrls: ['./branch-info.component.css'],
  providers: [BranchService, TreatmentService, BranchTreatmentService],
})
export class BranchInfoComponent implements OnInit {
  branch:Branch = new Branch(0,"","");
  treatments: Treatment[];
  branchTreatments: BranchTreatment[];
  checkedTreatments: Treatment[] = [];
  branchTreatmentsAdd: BranchTreatment[];
  id: number;
  numberOfChecked: number = 0;
  a:number = 0;
  @ViewChild('form') public createBranchForm: NgForm;
  constructor(private route: ActivatedRoute, private _branchService: BranchService, private _treatmentService: TreatmentService, private _branchTreatmentService: BranchTreatmentService ,private router: Router) { }

  ngOnInit() {
    this.branch = new Branch(0,"","");
    this.checkedTreatments = [];
    this._treatmentService.getTreatments().subscribe(res => {this.treatments = res;}, err => console.log(err), () => {
      if (this.route.snapshot.paramMap.get("branchID")) {
        this.route.paramMap.subscribe((paramMap) => {
          this.id = parseInt(paramMap.get("branchID"));
        });
        this._branchService.getBranch(this.id).subscribe(
          (branchData) => {
            this.branch = branchData;
          },
          (error) => {
            console.log(error);
          },
          () => {
            this._branchTreatmentService.getBrancTreatments(this.branch.branchID).subscribe(res => this.branchTreatments = res, err => console.log(err),
            () => { console.log(this.branchTreatments);
              this.checkedTreatments = [];
              for(let i = 0; i<this.treatments.length; i++){
                let exist = false;
                for(let j = 0; j<this.branchTreatments.length; j++){
                  if(this.treatments[i].treatmentID === this.branchTreatments[j].treatmentID) {
                    exist = true;
                  }
                }
                // if(exist){
                //   this.checkedTreatments.push(this.treatments[i]);
                // }
                this.checkedTreatments.push(new Treatment(this.treatments[i].treatmentID, this.treatments[i].name, this.treatments[i].price, this.treatments[i].timeRequired, this.treatments[i].image, exist))
              }
              console.log(this.checkedTreatments);
            });
          }
        );
      } else {
        for(let i=0; i<this.treatments.length; i++) {
          this.checkedTreatments.push(new Treatment(this.treatments[i].treatmentID, this.treatments[i].name, this.treatments[i].price, this.treatments[i].timeRequired, this.treatments[i].image, false))
        }
      }
    });

  }

  onSubmit() {
    for(let i=0; i<this.checkedTreatments.length; i++) {
      if(this.checkedTreatments[i].checked) this.numberOfChecked++;
    }
    if(this.createBranchForm.invalid || this.numberOfChecked === 0){
      this.ngOnInit();
    } else {
      if(this.branch.branchID === 0){
        this.insertRecord();
      } else this.updateRecord();
    }

  }

    updateCheckedTreatments(e) {
      const elementIndex = this.checkedTreatments.findIndex(element => element.treatmentID === parseInt(e.target.value));
        this.checkedTreatments[elementIndex].checked = e.target.checked;
        console.log(this.checkedTreatments);
    }



  insertRecord() {
    var id: number;
    const newBranch = Object.assign({}, this.branch);
    this._branchService.insertBranch(newBranch).subscribe(res => id = res.branchID, err => console.log(err),  () =>
     {  for(let i=0; i<this.checkedTreatments.length; i++) {
              if(this.checkedTreatments[i].checked) {
                let branchTreatment = new BranchTreatment(null,id, this.checkedTreatments[i].treatmentID);
                // console.log(branchTreatment);
                this._branchTreatmentService.insertBranchTreatment(branchTreatment).subscribe(res => console.log(res), err => console.log(err));
              }
          }
       this.router.navigate(["/home/all-branches"]);
    })
  }

  updateRecord() {
    const updatedBranch = Object.assign({}, this.branch);
    console.log(this.checkedTreatments);
    var existingBranchTreatments: BranchTreatment[];
    this._branchTreatmentService.getBrancTreatments(updatedBranch.branchID).subscribe(res => {existingBranchTreatments = res; console.log(existingBranchTreatments)}, err => console.log(err),
    () => {
      for(let i=0;i<existingBranchTreatments.length;i++){
        this._branchTreatmentService.deleteBranchTreatment(existingBranchTreatments[i].branchTreatmentID).subscribe(res => console.log(res), err => console.log(err),
                 () => {
                  if(i == existingBranchTreatments.length-1) {
                      for(let j = 0; j < this.checkedTreatments.length; j++) {
                        if(this.checkedTreatments[j].checked) {
                          let branchTreatment = new BranchTreatment(null,updatedBranch.branchID, this.checkedTreatments[j].treatmentID);
                          this._branchTreatmentService.insertBranchTreatment(branchTreatment).subscribe(res => console.log(res), err => console.log(err), () => this.router.navigate(["/home/all-branches"]))
                        }
                      }
                  }
                 });
      }
    });
  }
}
