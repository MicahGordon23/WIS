export interface Lot {
  lotId: BigInt;
  producerIdLink: number;
  commodityTypeIdLink: number;
  commodityVarietyIdLink: number;
  stateId: string;
  startDate: Date;
  endDate: Date;
  landlord: string;
  farmNumber: string;
  notes: string;
}
