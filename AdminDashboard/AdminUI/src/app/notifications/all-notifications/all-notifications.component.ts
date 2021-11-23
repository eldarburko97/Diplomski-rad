import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BsDatepickerConfig } from "ngx-bootstrap/datepicker";
import { Notification } from 'src/app/models/notification.model';
import { NotificationService } from 'src/app/services/notification.service';

@Component({
  selector: 'app-all-notifications',
  templateUrl: './all-notifications.component.html',
  styleUrls: ['./all-notifications.component.css'],
  providers: [NotificationService]
})
export class AllNotificationsComponent implements OnInit {
  notifications: Notification[];
  datePickerConfig: Partial<BsDatepickerConfig>;
  startDate: Date = new Date();
  endDate: Date = new Date();
  constructor(private _notificationService: NotificationService, private _router: Router) {
    this.datePickerConfig = Object.assign({}, {containerClass: 'theme-dark-blue', showWeekNumbers: false, dateInputFormat: 'YYYY/MM/DD'});
   }

  ngOnInit() {
    this._notificationService.getNotifications().subscribe(res => this.notifications = res, err => console.log(err), () => console.log(this.notifications));
  }

  navigate(notification: Notification) {
    this._router.navigate([`/home/notification-info/${notification.notificationID}`]);
  }

  searchNotifications() {
    this._notificationService.searchNotifications(this.startDate, this.endDate).subscribe(res => this.notifications = res, err => console.log(err));
  }

}
