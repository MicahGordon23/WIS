export class IntakeReport {
  public commodityTypeId: number;
  public commodityTypeName: string;
  public commodityVarietyId?: number;
  public commodityVarietyName?: string;
  public producerId: number;
  public proudcerName: string;
  public lotNumber: number;
  public weightsheetId: bigint;
  public dateLotOpened: Date | null;
  public landlord: string | null;
  public farmNumber: number | null;
  public netWeightLbs: number | null;

  constructor() {
    this.commodityTypeId = 0;
    this.commodityTypeName = "";
    this.commodityVarietyId = 0;
    this.commodityVarietyName = "";
    this.producerId = 0;
    this.proudcerName = "";
    this.lotNumber = 0;
    this.weightsheetId = BigInt(0);
    this.dateLotOpened = null;
    this.landlord = null;
    this.farmNumber = null;
    this.netWeightLbs = null;
  }
}
