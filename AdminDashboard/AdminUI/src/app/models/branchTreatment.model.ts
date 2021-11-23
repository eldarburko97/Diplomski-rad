export class BranchTreatment {
  branchTreatmentID: number;
  branchID: number;
  treatmentID: number;

  /**
   *
   */
  constructor(branchTreatmentID: number,  branchID: number, treatmentID: number) {
    this.branchTreatmentID = branchTreatmentID,
    this.branchID = branchID,
    this.treatmentID = treatmentID
  }
}
