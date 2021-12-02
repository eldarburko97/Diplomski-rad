import { Component, OnInit } from '@angular/core';
import { BsDatepickerConfig } from 'ngx-bootstrap/datepicker';
import { Payment } from 'src/app/models/payment.model';
import { PaymentService } from 'src/app/services/payment.service';

@Component({
  selector: 'app-all-payments',
  templateUrl: './all-payments.component.html',
  styleUrls: ['./all-payments.component.css'],
  providers: [PaymentService]
})
export class AllPaymentsComponent implements OnInit {
  search: string;
  payments: Payment[];
  datePickerConfig: Partial<BsDatepickerConfig>;
  dateFrom: Date = new Date();
  dateTo: Date = new Date();
  firstName: string = "";
  lastName: string = "";
  constructor(private _paymentService: PaymentService) {
    this.datePickerConfig = Object.assign({}, {containerClass: 'theme-dark-blue', showWeekNumbers: false, dateInputFormat: 'YYYY/MM/DD'});
  }

  ngOnInit() {
    this._paymentService.getPayments().subscribe(res => this.payments = res, err => console.log(err));
  }

  searchPayments() {
    this._paymentService.searchPayments(this.firstName,this.lastName,this.dateFrom,this.dateTo).subscribe(res => this.payments = res, err => console.log(err));
  }

}
