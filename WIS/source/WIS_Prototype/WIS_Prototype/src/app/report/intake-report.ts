export class IntakeReport {
  public commodityTypeIdLink: number;
  public commodityTypeName: string;
  public commodityVarietyIdLink?: bigint;
  public commodityVarietyName?: string;
  public producerIdLink: number;
  public producerName: string;
  public lotIdLink: number;
  public weightsheetId: bigint;
 // public dateLotOpened: Date | null;
  public endDate: Date | null;
  public landlord: string | null;
  public farmNumber: number | null;
  public netWeightLbs: number;
  public netUom: number;
  public isClosedString: string | null;

  constructor() {
    this.commodityTypeIdLink = 0;
    this.commodityTypeName = "";
    this.commodityVarietyIdLink = BigInt(0);
    this.commodityVarietyName = "";
    this.producerIdLink = 0;
    this.producerName = "";
    this.lotIdLink = 0;
    this.weightsheetId = BigInt(0);
    //this.dateLotOpened = null;
    this.endDate = null;
    this.landlord = null;
    this.farmNumber = null;
    this.netWeightLbs = 0;
    this.netUom = 0;
    this.isClosedString = null;
  }

  // Populates a field that allows for easier display on the table.
  SetClosedToString(): void {
    if (this.endDate == null) {
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
