export class Treatment {
  treatmentID: number;
  name: string;
  price: number;
  timeRequired: number;
  image: File;
  checked: boolean

  /**
   *
   */
  constructor(treatmentID: number, name: string, price: number, timeRequired: number, image: File ,checked: boolean) {
    this.treatmentID = treatmentID,
    this.name = name,
    this.price = price,
    this.timeRequired = timeRequired,
    this.image = image,
    this.checked = checked
  }
}
