import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';

import { ProducerService } from './producer/producer.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  constructor(
    private producerService: ProducerService
  ) { }
  title = 'NWGG Warehoues Inventory System';

  ngOnInit() {
    // Populate producer service with data on app start up.
    this.producerService.getProducers();
  }

}
