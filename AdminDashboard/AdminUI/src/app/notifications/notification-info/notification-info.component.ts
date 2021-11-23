import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Notification } from 'src/app/models/notification.model';
import { NotificationService } from 'src/app/services/notification.service';

@Component({
  selector: 'app-notification-info',
  templateUrl: './notification-info.component.html',
  styleUrls: ['./notification-info.component.css'],
  providers: [NotificationService]
})
export class NotificationInfoComponent implements OnInit {
  id: number;
  notification: Notification = new Notification(0,"","",new Date(),0);

  constructor(private _notificationService: NotificationService, private route: ActivatedRoute) { }

  ngOnInit() {
    this.id = parseInt(this.route.snapshot.paramMap.get("notificationID"));
    this._notificationService.getNotification(this.id).subscribe(res => this.notification = res, err => console.log(err));
  }

}
