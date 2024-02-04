// Filename: load.ts
// Purpose: Allow for modularity and ability to send HTTP POST request.

// ILoad parent class
// Purpose: Define a common interface for other Load classes to inhert from. 
export class ILoad {
  loadId?: bigint;
  weightsheetIdLink?: bigint;
  grossWeight: number;
  tareWeight: number;
  netWeight: number;
  truckId: string;
  timeIn?: Date;
  bolNumber?: number;
  destBin?: number;
  notes?: string;

  constructor() {
    this.grossWeight = 0
    this.tareWeight = 0;
    this.netWeight = 0;
    this.truckId = '';
  }
}

// Load Class
// Purpose: Defines state for GET requets for Loads. Hass all load properties
export class Load extends ILoad{
  timeOut?: Date;
  moistureLevel?: number;
  testWeight?: number;
  protienLevel?: number;
}


export class LoadMoistureTestWeightProtien extends ILoad {
  moistureLevel?: number;
  testWeight?: number;
  protienLevel?: number;
}

export class LoadMoisture extends ILoad {
  moistureLevel?: number;
}

export class LoadTestWeight extends ILoad {
  testWeight?: number;
}

export class LoadProtien extends ILoad {
  protienLevel?: number;
}

export class LoadMoistureTestWeight extends ILoad {
  moistureLevel?: number;
  testWeight?: number;
}

export class LoadMoistureProtien extends ILoad {
  moistureLevel?: number;
  protienLevel?: number;
}

export class LoadTestWeightProtein extends ILoad {
  testWeight?: number;
  protienLevel?: number;
}
