export interface Load {
  loadId: bigint;
  weigthsheetIdLink: bigint;
  grossWeight?: number;
  tareWeight?: number;
  netWeight?: number;
  truckId: string;
  timeIn?: Date;
  timeOut?: Date;
  bolNumber?: number;
  destBin?: string;
  moistureLevel?: number;
  testWeight?: number;
  proteinLevel?: number;
  notes?: string;
}
