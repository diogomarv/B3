import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  { path: 'cdb', loadChildren: () => import('./calcular/calcular.module').then(m => m.CdbModule) },
  { path: '', loadChildren: () => import('./calcular/calcular.module').then(m => m.CdbModule) }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
