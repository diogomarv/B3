import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CalcularComponent } from './calcular.component';

const routes: Routes = [{ path: '', component: CalcularComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CdbRoutingModule { }
