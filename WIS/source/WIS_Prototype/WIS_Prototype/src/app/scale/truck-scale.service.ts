//************************************************
// Filename: truck-scale.service.ts
// Purpose: Get the truck scale current weight reading.
//    01/31/2024: The Adeno web scale has not been set up for me at this point. This will mock
//        the service until then. Ideally, the interface will remain the same between mock
//        and actual service.

import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TruckScaleService {

  constructor() { }

  // Mocks the heavy weight (gross)
  private grossWeight: number = 105340;
  // Mocks the light weight (tare)
  private tareWeight: number = 34800;

  private weighIn: boolean = true;

  // Mocked to switch between gross and tare weight on every call for testing purposes.
  getWeight(): number {
    let weight = this.grossWeight;
    if (!this.weighIn) {
      weight = this.tareWeight;
      
    }
    this.weighIn = false;
    return weight;
  }
}
