import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { OverviewComponent } from './overview/overview.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';

const routes: Routes = [
  { path: '', component: OverviewComponent, pathMatch: 'full' },
  { path: 'fetch-data', component: FetchDataComponent }
];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }
