import { Component, OnInit } from '@angular/core';
import { ClienteService } from '../../services/cliente.service';
import { Cliente } from '../../models/cliente';
import { Kpicliente } from '../../models/kpicliente';

@Component({
  selector: 'app-listar-clientes',
  templateUrl: './listar-clientes.component.html',
  styleUrls: ['./listar-clientes.component.css']
})
export class ListarClientesComponent implements OnInit {

  data: Cliente[] = [];
  kpi: Kpicliente = new Kpicliente();

  constructor(private _clienteService: ClienteService) { }

  ngOnInit() {
    this._clienteService.kpiClientes().subscribe(kpi =>{
      this.kpi = kpi;
    });
    this._clienteService.listarClientes().subscribe(data =>{
      this.data = data;
    });
  }
  
}
