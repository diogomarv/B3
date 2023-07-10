import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CdbRoutingModule } from './calcular-routing.module';
import { CalcularComponent } from './calcular.component';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatStepperModule } from '@angular/material/stepper';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { NgxMaskDirective, NgxMaskPipe, provideEnvironmentNgxMask, provideNgxMask } from 'ngx-mask';
import { MatChipsModule } from '@angular/material/chips';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatDividerModule } from '@angular/material/divider';
import { MatTableModule } from '@angular/material/table';


@NgModule({
  declarations: [
    CalcularComponent
  ],
  imports: [
    FormsModule,
    ReactiveFormsModule,
    CommonModule,
    CdbRoutingModule,
    MatSidenavModule,
    MatStepperModule,
    MatFormFieldModule,
    MatButtonModule,
    MatCardModule,
    MatIconModule,
    MatInputModule,
    MatSlideToggleModule,
    NgxMaskDirective,
    NgxMaskPipe,
    MatChipsModule,
    MatSnackBarModule,
    MatDividerModule,
    MatTableModule
  ],
  providers: [
    provideEnvironmentNgxMask(),
    provideNgxMask(),
  ]
})
export class CdbModule { }
