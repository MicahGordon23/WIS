export class CommodityReport {

  public commodityTypeId: number;
  public commodityTypeName: string;
  public numLoads: number;
  public commodityVarietyId?: bigint;
  public commodityVarietyName?: string;

  constructor() {
    this.commodityTypeId = 0;
    this.commodityTypeName = '';
    this.numLoads = 0;
  }
}
