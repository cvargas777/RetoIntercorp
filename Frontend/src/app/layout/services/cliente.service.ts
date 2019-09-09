import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Cliente } from '../models/cliente';
import { Kpicliente } from '../models/kpicliente';

@Injectable({
  providedIn: 'root'
})
export class ClienteService {

  private _apiURL = "https://retoIBKapi.azurewebsites.net/api/Cliente/";
  
  constructor(private _http: HttpClient) { }

  crearCliente(params) : Observable<boolean>{
    return this._http.post<boolean>(this._apiURL + "creacliente", params);
  }

  listarClientes() : Observable<Cliente[]>{
    return this._http.get<Cliente[]>(this._apiURL + "listclientes");
  }

  kpiClientes() : Observable<Kpicliente>{
    return this._http.get<Kpicliente>(this._apiURL + "kpideclientes");
  }
}
