// Filename: lot.ts
// Purpose: Allow for modulatrity and ability to send HTTP POST request.

// ILot interface
// Purpose: Define a common interface for all other Lot interfaces. Has the bare miniumn properties
export class ILot {
  // these properties are nessary for a Lot
 
  public producerIdLink: number;
  public commodityTypeIdLink: number;
  public stateId: string;
  public startDate?: Date;
  public warehouseIdLink!: number;
  // the below properties are safely nullable. Dont cause a Error 400
  public landlord?: string;
  public farmNumber?: string;
  public notes?: string;

  // Default Constructor
  constructor() {
    
    this.producerIdLink = 0;
    this.commodityTypeIdLink = 0;
    this.stateId = '';
  }
 
}

// Lot Interface
// Purpose: Contract for GETs of Lots. Has all associated properties
export class Lot extends ILot {

  // extra properties
  public lotId?: BigInt;
  public commodityVarietyIdLink?: number;  // Can cause an Error 400 if null in POST
  public endDate?: Date;   // can cause an Error 400 if null in POST

}

// New Lot Interface
// Purpose: Contract for a new Lot POST
export class NewLot extends ILot{
  // additional propertiy
  public commodityVarietyIdLink?: number;

}

// New Lot Interface
// Purpose: Contract for a new Lot POST where the new lot has no Commodity Variety
export class NewLotNoVariety extends ILot {
  
  
}


// Pupose: LotDto
export class LotDto extends ILot {
  constructor() {
    super();
    this.producerName = "";
    this.commodityTypeName = "";
  }
  public producerName: string;
  public commodityTypeName: string;
  public commodityVarietyName?: string | null;
}
