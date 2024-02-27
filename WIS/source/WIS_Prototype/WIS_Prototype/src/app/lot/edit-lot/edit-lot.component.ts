import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

import { ILot, Lot } from '../../lot/lot';
import { LotService } from '../lot.service';

import { Producer } from '../../producer/producer';
import { ProducerService } from '../../producer/producer.service';

import { CommodityType } from '../../commodity-type/commodity-type';
import { CommodityTypeService } from '../../commodity-type/commodity-type.service';

import { CommodityVariety } from '../../commodity-variety/commodity-variety';
import { CommodityVarietyService } from '../../commodity-variety/commodity-variety.service';

import { States } from '../../states/states';

@Component({
  selector: 'app-edit-lot',
  templateUrl: './edit-lot.component.html',
  styleUrls: ['./edit-lot.component.scss']
})
export class EditLotComponent {
  constructor(
    private lotService: LotService,
    private producerService: ProducerService,
    private commodityTypeService: CommodityTypeService,
    private commodityVarietyService: CommodityVarietyService,
    private activatedRoute: ActivatedRoute,
    private route: Router
  ) {
     //this.states = new States();
  }

  form!: FormGroup;

  lot!: Lot;

  producers!: Producer[];
  producer!: string;

  commodityTypes!: CommodityType[];

  commodityVarieties!: CommodityVariety[];

  states = [
    { value: 'ID', viewValue: 'ID' },
    { value: "WA", viewValue: 'WA' },
    { value: 'OR', viewValue: 'OR' }
  ];

  ngOnInit() {
    this.form = new FormGroup({
      producer: new FormControl('', Validators.required),
      commodityType: new FormControl('', Validators.required),
      commodityVariety: new FormControl(''),
      stateId: new FormControl('', Validators.required),
      landlord: new FormControl(''),
      farmNumber: new FormControl(''),
      notes: new FormControl('')
    })

    // Get the lot using id from the route.
    let idParam = this.activatedRoute.snapshot.paramMap.get('id');
    let id = idParam ? +idParam : 0;

    // Populate Producers
    this.producerService.getData()

      .subscribe(result => {
        this.producers = result;
        // Populate Commodity Type
        this.commodityTypeService.getData()

          .subscribe(result => {
            this.commodityTypes = result;

            this.lotService.getLot(BigInt(id))
              .subscribe(result => {
                this.lot = result;
                console.log(this.getProducerById(this.lot.producerIdLink));
                console.log(this.form.controls['producer'].value);
                //this.producer = this.getProducerNameById(this.lot.producerIdLink);
                //this.form.controls['producer'].patchValue(this.getProducerById(this.lot.producerIdLink));
                console.log(this.form.controls['producer'].value);
                this.form.patchValue(this.lot);
                //console.log(this.form.controls['producer'].value);
              }, error => console.log(error));

          }, error => console.log(error));

          }, error => console.log(error));

        
  }
  //**********************************************
  // Purpose: Return the producer based off Id O(n)
  // Returns: a producer if found null if not found.
  getProducerById(producerId: number): Producer {
    if (this.producers) {
      for (let i = 0; i < this.producers.length; i++) {
        if (this.producers[i].producerId == producerId) {
          return this.producers[i];
        }
      }
    }
    return this.producers[0];
  }

  getProducerNameById(producerId: number): string {
    if (this.producers) {
      for (let i = 0; i < this.producers.length; i++) {
        if (this.producers[i].producerId == producerId) {
          return this.producers[i].producerName;
        }
      }
    }
    return "";
  }

  //**********************************************
  // Purpose: When a Commodity Type is selected in the form, the variety field is populated.
  onSelect(event: Event) {
    const typeId = Number((event.target as HTMLInputElement).value);
    this.commodityVarietyService.getByType(typeId)
      .subscribe(result => this.commodityVarieties = result);
  }

  //**********************************************
  // Purpose: Submit Form. Updates database.
  onSubmit() {

  }
}
