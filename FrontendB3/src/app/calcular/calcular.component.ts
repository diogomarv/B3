import { Component } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ICalcularCdbRequest } from '../models/calcularCdbRequest';
import { ApiResponse } from '../shared/IApiResponse';
import { CdbService } from '../services/cdb.service';

@Component({
  selector: 'app-cdb',
  templateUrl: './calcular.component.html',
})
export class CalcularComponent {

  tempoInvestimentoFormControl = new FormControl(2, [Validators.required]);
  valorInvestimentoFormControl = new FormControl(1, [Validators.required]);
  dataSource: ApiResponse;

  loading: boolean = false;

  constructor(private _snackBar: MatSnackBar, private _cdbService: CdbService) { }

  calcular = async () => {

    if (!this.validarForms()) {
      this.openSnackBar('Preencha todos os campos', 'Ok');
      return;
    }

    const valorInvestimento = this.valorInvestimentoFormControl.value;
    const tempoInvestimento = this.tempoInvestimentoFormControl.value;
    const payLoad = { qtdMeses: tempoInvestimento, valor: valorInvestimento } as ICalcularCdbRequest;

    try {
        this.loading = true;
        this.dataSource = await this._cdbService.calcularCdb(payLoad);      
    }
    catch (error: any) {
      const msg = error.response.data.Message;
      this.openSnackBar(msg, 'Entendi');

    }finally{

      this.loading = false;
    
    }
  }

  validarForms = () => (this.valorInvestimentoFormControl.valid) && this.tempoInvestimentoFormControl.valid;

  openSnackBar = (message: string, action: string) => this._snackBar.open(message, action);

}
