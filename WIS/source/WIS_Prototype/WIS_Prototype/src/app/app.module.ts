import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AngularMaterialModule } from './angular-material.module';
import { AppComponent } from './app.component';
import { WarehouseComponent } from './warehouse/warehouse.component';
import { HomeComponent } from './home/home.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';
import { WeightsheetComponent } from './weightsheet/weightsheet.component';
import { LoadComponent } from './load/load.component';
import { LotComponent } from './lot/lot.component';

@NgModule({
  declarations: [
    AppComponent,
    WarehouseComponent,
    HomeComponent,
    NavMenuComponent,
    WeightsheetComponent,
    LoadComponent,
    LotComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    NoopAnimationsModule,
    AngularMaterialModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
