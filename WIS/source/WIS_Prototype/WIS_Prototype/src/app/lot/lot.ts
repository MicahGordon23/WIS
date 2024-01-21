export interface Lot {
  lotId: BigInt;
  producerIdLink: number;
  stateId: string;
  startDate: Date;
  endDate: Date;
  landlord: string;
  farmNumber: string;
  notes: string;
}
