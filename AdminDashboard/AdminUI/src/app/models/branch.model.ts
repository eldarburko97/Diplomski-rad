export class Branch {
  branchID: number;
  name: string;
  title: string;

  /**
   *
   */
  constructor(branchID: number, name: string, title: string) {
    this.branchID = branchID,
    this.name = name,
    this.title = title
  }
}
