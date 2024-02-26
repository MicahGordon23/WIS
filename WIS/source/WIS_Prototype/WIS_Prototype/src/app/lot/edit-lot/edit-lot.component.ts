import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

import { ILot, Lot } from '../../lot/lot';
import { LotService } from '../lot.service';

@Component({
  selector: 'app-edit-lot',
  templateUrl: './edit-lot.component.html',
  styleUrls: ['./edit-lot.component.scss']
})
export class EditLotComponent {

  constructor(
    private lotService: LotService,
    private activatedRoute: ActivatedRoute,
    private route: Router
  ) { }
  
}
