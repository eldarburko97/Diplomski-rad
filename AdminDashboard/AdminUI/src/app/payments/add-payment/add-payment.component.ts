import { Component, OnInit, ViewChild } from '@angular/core';
import { User } from 'src/app/models/user.model';
import { BsDatepickerConfig } from "ngx-bootstrap/datepicker";
import { Payment } from 'src/app/models/payment.model';
import { Treatment } from 'src/app/models/treatment.model';
import { UserService } from 'src/app/services/user.service';
import { TreatmentService } from 'src/app/services/treatment.service';
import { PaymentService } from 'src/app/services/payment.service';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-payment',
  templateUrl: './add-payment.component.html',
  styleUrls: ['./add-payment.component.css'],
  providers: [UserService, TreatmentService, PaymentService]
})
export class AddPaymentComponent implements OnInit {
  clients: User[];
  treatments: Treatment[];
  datePickerConfig: Partial<BsDatepickerConfig>;
  payment: Payment;
  @ViewChild('form') public createPaymentForm: NgForm;
  constructor(private _clientService: UserService, private _treatmentService: TreatmentService, private _paymentService: PaymentService, private _router: Router) {
    this.datePickerConfig = Object.assign({}, {containerClass: 'theme-dark-blue', showWeekNumbers: false, dateInputFormat: 'YYYY/MM/DD'});
  }

  ngOnInit() {
    this.clients = [];
    this.treatments = [];
    this.payment = new Payment(0,0,0,new Date());
    this._clientService.getUsers().subscribe(res => {
      for(let i=0;i<res.length;i++) {
        for(let j=0;j<res[i].userRoles.length;j++) {
          if(res[i].userRoles[j].role.name == "Client") {
            this.clients.push(res[i]);
          }
        }
      }
    }, err => console.log(err));

    this._treatmentService.getTreatments().subscribe(res => this.treatments = res, err => console.log(err));
  }

  onSubmit() {
    if(this.createPaymentForm.valid)
      this._paymentService.insert(this.payment).subscribe(res => console.log(res), err => console.log(err), () => {
        this._router.navigate(["/home/all-payments"]);
      });
    else this.ngOnInit();
  }

  onChange(e) {
    if(parseInt(e.target.value) === 0)
      this.payment.amount = 0;
    else this._treatmentService.getTreatment(parseInt(e.target.value)).subscribe(res => this.payment.amount = res.price,
      err => console.log(err));
  }

}
