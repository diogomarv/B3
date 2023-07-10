import { ComponentFixture, TestBed } from '@angular/core/testing';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { MatDividerModule } from '@angular/material/divider';
import { MatInputModule } from '@angular/material/input';
import { CalcularComponent } from './calcular.component';
import { NgxMaskDirective, NgxMaskPipe, provideEnvironmentNgxMask, provideNgxMask } from 'ngx-mask';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations'; 


describe('CalcularComponent', () => {
  let component: CalcularComponent;
  let fixture: ComponentFixture<CalcularComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CalcularComponent],
      imports: [
        FormsModule,
        ReactiveFormsModule,
        CommonModule,
        MatSnackBarModule,
        MatCardModule,
        MatFormFieldModule,
        MatIconModule,
        MatSlideToggleModule,
        MatDividerModule,
        NgxMaskDirective,
        NgxMaskPipe,
        MatInputModule,
        BrowserAnimationsModule
      ],
      providers: [
        provideEnvironmentNgxMask(),
        provideNgxMask(),
      ]
    })
      .compileComponents();

    fixture = TestBed.createComponent(CalcularComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('Quando calcular um investimento de R$ 1.000,00 por 12 meses, deve retornar sucesso', async () => {
    component.valorInvestimentoFormControl.setValue(1000);
    component.tempoInvestimentoFormControl.setValue(12);

    await component.calcular();

    expect(component.dataSource.Sucesso).toBe(true);
  });

});
