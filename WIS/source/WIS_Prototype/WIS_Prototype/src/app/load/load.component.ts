import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Load } from './load';

@Component({
  selector: 'app-load',
  templateUrl: './load.component.html',
  styleUrls: ['./load.component.scss']
})
export class LoadComponent implements OnInit {
  public loads!: Load[];

  constructor(private http: HttpClient) {

  }

  ngOnInit() {
  this.http.get<Load[]>('api/Loads')
    .subscribe(result => {
      this.loads = result;
    })
  }
}
