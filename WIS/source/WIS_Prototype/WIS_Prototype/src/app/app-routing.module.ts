/*****************************************************
 *  Having a sperate app-routing module is consiterded to be best practice.
 *  The other option is to put it in app.module.ts, but NOT best practice.
*****************************************************/

import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { LotComponent } from './lot/lot.component';
import { LoadComponent } from './load/load.component';
import { WeightsheetComponent } from './weightsheet/weightsheet.component';
//import { WarehouseComponent } from './warehouse/warehouse.component';

const routes: Routes = [
  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: 'lot', component: LotComponent },
  { path: 'load', component: LoadComponent },
  { path: 'weightsheet', component: WeightsheetComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }
