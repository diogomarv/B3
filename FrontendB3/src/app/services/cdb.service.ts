import { Injectable } from '@angular/core';
import { ICalcularCdbRequest } from '../models/calcularCdbRequest';
import { ApiResponse } from '../shared/IApiResponse';
import { ApiService } from './api.service';

const url = '/ativos/calcular-cdb';

@Injectable({
  providedIn: 'root'
})
export class CdbService {

  constructor(private api : ApiService) { }

  calcularCdb = async (data : ICalcularCdbRequest) : Promise<ApiResponse> => {
    return await this.api.post<ApiResponse>(url, data);
  }

}
