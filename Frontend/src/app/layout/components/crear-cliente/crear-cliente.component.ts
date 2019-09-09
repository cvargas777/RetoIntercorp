import { Component, OnInit } from '@angular/core';
import { ClienteService } from '../../services/cliente.service';
import { Cliente } from '../../models/cliente';

@Component({
  selector: 'app-crear-cliente',
  templateUrl: './crear-cliente.component.html',
  styleUrls: ['./crear-cliente.component.css']
})
export class CrearClienteComponent implements OnInit {

  model: Cliente = new Cliente();

  constructor(private _clienteService: ClienteService) { }
  
  ngOnInit() {}

  Crear(){
    this._clienteService.crearCliente(this.model).subscribe(data => {
      console.log("Registro exitoso!");
      alert("Cliente creado!!!");
      this.model = new Cliente();
    });
  }

}
