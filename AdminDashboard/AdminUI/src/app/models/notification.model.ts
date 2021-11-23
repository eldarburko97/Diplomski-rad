export class Notification {
    notificationID: number;
    title: string;
    text: string;
    notificationDate: Date;
    userID: number
    /**
     *
     */
    constructor(notificationID: number, title: string, text: string, notificationDate: Date, userID: number) {
      this.notificationID = notificationID,
      this.title = title,
      this.text = text,
      this.notificationDate = notificationDate,
      this.userID = userID
    }
}
