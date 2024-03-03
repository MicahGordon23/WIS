export class WeightSheetReport {
  public weightsheetId: bigint;
  public commodityTypeId: number;
  public commodityTypeName: string;
  public commodityVarietyId?: bigint;
  public commodityVarietyName?: string;
  public loadsOnSheet: number;
  public netWeight: number;

  constructor() {
    this.weightsheetId = BigInt(0);
    this.commodityTypeId = 0;
    this.commodityTypeName = '';
    this.loadsOnSheet = 0;
    this.netWeight = 0;
  }
}
