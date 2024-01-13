export interface Lot {
  lotId: BigInt;
  producerIdLink: number;
  stateId: string;
  startDate: Date;
  endDate: Date;
  landlord: string;
  farmNumber: string;
  truckId: string; // ToDo remove row from db.
  notes: string;
}
