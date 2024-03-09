export class ProducerReport {
  producerName: string;
  districtName: string;
  warehouseName: string;
  commodityTypeName: string;
  commodityVarietyName: string;
  netWeightLbs: number;
  sumLoads: number;

  constructor() {
    this.producerName = '';
    this.districtName = '';
    this.warehouseName = '';
    this.commodityTypeName = '';
    this.commodityVarietyName = '';
    this.netWeightLbs = 0;
    this.sumLoads = 0;
  }
}
