import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Branch } from 'src/app/models/branch.model';
import { BranchService } from 'src/app/services/branch.service';

@Component({
  selector: 'app-all-branches',
  templateUrl: './all-branches.component.html',
  styleUrls: ['./all-branches.component.css'],
  providers: [BranchService],
})
export class AllBranchesComponent implements OnInit {
  branches: Branch[];
  name: string = "";
  constructor(private _branchService: BranchService, private _router: Router) { }

  ngOnInit() {
    this._branchService.getBranches().subscribe(res => this.branches = res, err => console.log(err));
  }

  navigate(branch: Branch) {
    this._router.navigate([`/home/branch-info/${branch.branchID}`]);
  }

 search() {
   this._branchService.searchBranches(this.name).subscribe(res => this.branches = res);
 }

}
