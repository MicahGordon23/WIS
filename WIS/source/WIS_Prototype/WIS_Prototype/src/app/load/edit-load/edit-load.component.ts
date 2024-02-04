import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';

import { Bin } from '../../bin/bin';
import { BinService } from '../../bin/bin.service';

import { Weightsheet } from '../../weightsheet/weightsheet';
import { WeightsheetService } from '../../weightsheet/weightsheet.service';

import { TruckScaleService } from '../../scale/truck-scale.service';

// Load related imports
import {
  ILoad,
  Load,
  NewLoad,
  NewLoadMoisture,
  NewLoadTestWeight,
  NewLoadProtien,
  NewLoadMoistureTestWeight,
  NewLoadMoistureProtien,
  NewLoadTestWeightProtein
} from '../load';
import { LoadService } from '../load.service';

import { from } from 'rxjs';

@Component({
  selector: 'app-edit-load',
  templateUrl: './edit-load.component.html',
  styleUrls: ['./edit-load.component.scss']
})
export class EditLoadComponent {

  constructor(private loadService: LoadService) { }

  form!: FormGroup;

  // refernce to load being editied
  load!: ILoad;

  // Bin options for select
  bins!: Bin[];

  // Weightsheet options for select
  weightsheets!: Weightsheet[];

  // On Init
  ngOnInit() {
    this.form = new FormGroup({
      truckId: new FormControl(''),
      bin: new FormControl(''),
      weightsheet: new FormControl(''),
      moistureLevel: new FormControl(''),
      testWeight: new FormControl(''),
      protienLevel: new FormControl(''),
      bolNumber: new FormControl(''),
      notes: new FormControl('')
    });
  }
  // Weigh Out
  weighOut() { }

  // Done
  onSubmit() { }

  // Cancel edit
  onCancel() { }
}
