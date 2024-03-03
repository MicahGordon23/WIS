// Filename: weightsheet.ts
// Purpose: Allow for modularity and ability to send HTTP POST and GET requests

// IWeightsheet
// Purpose: Define a common interface for all other LOT interfaces. Has bare min propertoes
export class IWeightsheet {
  // nessary properties
  weightSheetId: number;
  commodityTypeIdLink: number;  // Commodity taken in on weightsheet
  warehouseIdLink: number;      // Warehouse where the load is deposited
  weigher: string;              // Operator who weighed in the load
  dateOpened?: Date;            // Not safely nullable when sending POST
                                // Date when the weightsheet was opened.
  lotIdLink?: number;
  producerIdLink?: number;
  sourceIdLink?: number; // need to create a solution to EF DB issue of warehouese
  hauler?: string;
  miles?: number;
  notes?: string;

  // Default Constructor
  constructor() {
    this.weightSheetId = 0;
    this.commodityTypeIdLink = 0;
    this.warehouseIdLink = 0;
    this.weigher = '';
    this.miles = 0;
  }
}

// Weightsheet
// Purpose: Class for GETs of Lots. Hass all associated properties
export class Weightsheet extends IWeightsheet {
  dateClosed?: Date;
  commodityVarietyIdLink?: number;
  
}

// NewWeightsheet
// Purpose: Class for POST of new lots with all needed properties. Use when the new Weightsheet
//    has a Commodity Variety
export class NewWeightsheet extends IWeightsheet {
  commodityVarietyIdLink?: number;
}

// NewWeightsheetNoVariety
// Purpose: Class for POST of new lots which has no associated Variety.
export class NewWeightsheetNoVariety extends IWeightsheet {
  
}

export class WeightsheetOverview {
  weightsheetId: bigint;
  sumNumLoads: number;
  inYard: number;
  producerName?: string;
  sourceName?: string;
  commodityTypeName: string
  commodityVarietyName?: string
  lotId?: number;
  notes?: string;

  constructor() {
    this.weightsheetId = BigInt(0);
    this.sumNumLoads = 0;
    this.inYard = 0;
    this.commodityTypeName = '';
  }
}
