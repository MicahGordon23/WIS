export class TransferReport {
  weightsheetId: bigint;
  sourceName: string;
  commodityTypeName: string;
  commodityVarietyName: string;
  netWeight: number;
  numLoads: number;

  constructor() {
    this.weightsheetId =BigInt(0);
    this.sourceName = '';
    this.commodityTypeName = '';
    this.commodityVarietyName = '';
    this.netWeight = 0;
    this.numLoads = 0;
  }
}
