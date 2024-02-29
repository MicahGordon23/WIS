import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Load } from './load';
import { LoadService } from './load.service';

@Component({
  selector: 'app-load',
  templateUrl: './load.component.html',
  styleUrls: ['./load.component.scss']
})
export class LoadComponent implements OnInit {
  public loads!: Load[];

  constructor(
    private loadService: LoadService
  ) {}

  ngOnInit() {
    this.loadService.getData()
      .subscribe(result => {
        this.loads = result;
        console.log(this.loads);
      }, error => console.error(error));
  }
}
