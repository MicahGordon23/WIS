import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Warehouse } from './warehouse';

@Component({
  selector: 'app-warehouse',
  templateUrl: './warehouse.component.html',
  styleUrls: ['./warehouse.component.css']
})
export class WarehouseComponent implements OnInit{
  public warehouses!: Warehouse[];
  constructor(private http: HttpClient) { }
  ngOnInit() {
    this.http.get<Warehouse[]>('api/Warehouses')
      .subscribe(result => {
        this.warehouses = result;
      }, error => console.error(error));
  }
}
