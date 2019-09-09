import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CrearClienteComponent } from './layout/components/crear-cliente/crear-cliente.component';
import { ListarClientesComponent } from './layout/components/listar-clientes/listar-clientes.component';


const routes: Routes = [
  {path: 'crear-cliente', component: CrearClienteComponent},
  {path: 'listar-clientes', component: ListarClientesComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
