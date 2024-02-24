export class IntakeReport {
  public commodityTypeIdLink: number;
  public commodityTypeName: string;
  public commodityVarietyIdLink?: number;
  public commodityVarietyName?: string;
  public producerIdLink: number;
  public proudcerName: string;
  public lotIdLink: number;
  public weightsheetId: bigint;
 // public dateLotOpened: Date | null;
  public lotEndDate: Date | null;
  public landlord: string | null;
  public farmNumber: number | null;
  public netWeightLbs: number | null;
  public isClosedString: string | null;

  constructor() {
    this.commodityTypeIdLink = 0;
    this.commodityTypeName = "";
    this.commodityVarietyIdLink = 0;
    this.commodityVarietyName = "";
    this.producerIdLink = 0;
    this.proudcerName = "";
    this.lotIdLink = 0;
    this.weightsheetId = BigInt(0);
    //this.dateLotOpened = null;
    this.lotEndDate = null;
    this.landlord = null;
    this.farmNumber = null;
    this.netWeightLbs = null;
    this.isClosedString = null;
  }

  // Populates a field that allows for easier display on the table.
  SetClosedToString(): void {
    if (this.lotEndDate == null) {
      this.isClosedString = "Open";
    }
    else {
      this.isClosedString = "Closed";
    }
  }

  AsBushel(): number {
    if (this.netWeightLbs != null) {
      return (this.netWeightLbs / 60);
    }
    else {
      return -1;
    }
  }
}
