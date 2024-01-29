export interface Weightsheet {
  weightSheetId: number;
  commodityTypeIdLink: number;
  commodityVarietyIdLink: number;
  producerIdLink: number;
  sourceIdLink: number;
  weigher: string;
  hauler: string;
  miles: number;
  billOfLading: string;
  notes: string;
}
