export interface Weightsheet {
  weightsheetId: number;
  commodityTypeIdLink: number;
  commodityVerityIdLink: number;
  producerIdLink: number;
  sourceIdLink: number;
  weigher: string;
  hauler: string;
  miles: number;
  billOfLading: string;
  notes: string;
}
