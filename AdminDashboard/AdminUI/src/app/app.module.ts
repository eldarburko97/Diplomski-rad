import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';

import {HttpClientModule} from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { HomeComponent } from './home/home.component';
import { HomeMainComponent } from './home-main/home-main.component';
import { AllDentistsComponent } from './dentists/all-dentists/all-dentists.component';
import {NgxPaginationModule} from 'ngx-pagination';
import { DentistInfoComponent } from './dentists/dentist-info/dentist-info/dentist-info.component'; // <-- import the module
import { DatePipe } from '@angular/common';
import { SelectRequiredValidatorDirective } from './validators/select-required-validator.directive';
import { NgbDate, NgbModule } from '@ng-bootstrap/ng-bootstrap';
import {BsDatepickerModule} from 'ngx-bootstrap/datepicker';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BranchInfoComponent } from './branches/branch-info/branch-info.component';
import { AllBranchesComponent } from './branches/all-branches/all-branches.component';
import { TreatmentInfoComponent } from './treatments/treatment-info/treatment-info.component';
import { AllTreatmentsComponent } from './treatments/all-treatments/all-treatments.component';
import { AllAppointmentsComponent } from './appointments/all-appointments/all-appointments.component';
import { AllClientsComponent } from './clients/all-clients/all-clients.component';
import { ClientInfoComponent } from './clients/client-info/client-info.component';
import { AddPaymentComponent } from './payments/add-payment/add-payment.component';
import { AllPaymentsComponent } from './payments/all-payments/all-payments.component';
import { AllNotificationsComponent } from './notifications/all-notifications/all-notifications.component';
import { NotificationInfoComponent } from './notifications/notification-info/notification-info.component';
import { BestSellingTreatmentComponent } from './reports/best-selling-treatment/best-selling-treatment.component';
import { BusinessReportDentistComponent } from './reports/business-report-dentist/business-report-dentist.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    HomeComponent,
    HomeMainComponent,
    AllDentistsComponent,
    DentistInfoComponent,
    SelectRequiredValidatorDirective,
    BranchInfoComponent,
    AllBranchesComponent,
    TreatmentInfoComponent,
    AllTreatmentsComponent,
    AllAppointmentsComponent,
    AllClientsComponent,
    ClientInfoComponent,
    AddPaymentComponent,
    AllPaymentsComponent,
    AllNotificationsComponent,
    NotificationInfoComponent,
    BestSellingTreatmentComponent,
    BusinessReportDentistComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    NgxPaginationModule,
    NgbModule,
    BsDatepickerModule.forRoot(),
    BrowserAnimationsModule
  ],
  providers: [DatePipe],
  bootstrap: [AppComponent]
})
export class AppModule { }
