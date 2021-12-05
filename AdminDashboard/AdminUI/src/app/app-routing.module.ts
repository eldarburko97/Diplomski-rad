import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { AllAppointmentsComponent } from "./appointments/all-appointments/all-appointments.component";
import { AllBranchesComponent } from "./branches/all-branches/all-branches.component";
import { BranchInfoComponent } from "./branches/branch-info/branch-info.component";
import { AllClientsComponent } from "./clients/all-clients/all-clients.component";
import { ClientInfoComponent } from "./clients/client-info/client-info.component";
import { AllDentistsComponent } from "./dentists/all-dentists/all-dentists.component";
import { DentistInfoComponent } from "./dentists/dentist-info/dentist-info/dentist-info.component";
import { HomeMainComponent } from "./home-main/home-main.component";

import { HomeComponent } from "./home/home.component";
import { LoginComponent } from "./login/login.component";
import { AllNotificationsComponent } from "./notifications/all-notifications/all-notifications.component";
import { NotificationInfoComponent } from "./notifications/notification-info/notification-info.component";
import { AddPaymentComponent } from "./payments/add-payment/add-payment.component";
import { AllPaymentsComponent } from "./payments/all-payments/all-payments.component";
import { BestSellingTreatmentComponent } from "./reports/best-selling-treatment/best-selling-treatment.component";
import { BusinessReportDentistComponent } from "./reports/business-report-dentist/business-report-dentist.component";
import { AllTreatmentsComponent } from "./treatments/all-treatments/all-treatments.component";
import { TreatmentInfoComponent } from "./treatments/treatment-info/treatment-info.component";

const routes: Routes = [
  {
    path: "home",
    component: HomeComponent,
    children: [
      {
        path: "", // child route path
        component: HomeMainComponent, // child route component that the router renders
      },
      {
        path: "home-main",
        component: HomeMainComponent,
      },
      {
        path: "all-dentists",
        component: AllDentistsComponent,
      },
      {
        path: "dentist-info/:dentistID",
        component: DentistInfoComponent,
        pathMatch: 'full'
      },
      {
        path: "add-dentist",
        component: DentistInfoComponent,
      },
      {
        path: "dentist-info/add",
        component: DentistInfoComponent,
      },
      {
        path: "add-branch",
        component: BranchInfoComponent
      },
      {
        path: "all-branches",
        component: AllBranchesComponent
      },
      {
        path: "branch-info/:branchID",
        component: BranchInfoComponent,
        pathMatch: 'full'
      },
      {
        path: "add-treatment",
        component: TreatmentInfoComponent
      },
      {
        path: "all-treatments",
        component: AllTreatmentsComponent
      },
      {
        path: "treatment-info/:treatmentID",
        component: TreatmentInfoComponent,
        pathMatch: 'full'
      },
      {
        path: "all-appointments",
        component: AllAppointmentsComponent
      },
      {
        path: "all-clients",
        component: AllClientsComponent
      },
      {
        path: "client-info/:clientID",
        component: ClientInfoComponent,
        pathMatch: 'full'
      },
      {
        path: "add-payment",
        component: AddPaymentComponent
      },
      {
        path: "all-payments",
        component: AllPaymentsComponent
      },
      {
        path: "all-notifications",
        component: AllNotificationsComponent
      },
      {
        path: "notification-info/:notificationID",
        component: NotificationInfoComponent,
        pathMatch: 'full'
      },
      {
        path: "best-selling-treatment",
        component: BestSellingTreatmentComponent
      },
      {
        path: "business-report-dentist",
        component: BusinessReportDentistComponent
      }
    ],
  },
  {
    path: "login",
    component: LoginComponent,
  },
  {
    path: "",
    redirectTo: "/login",
    pathMatch: "full",
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
