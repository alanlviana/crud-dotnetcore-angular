import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PedidoFormComponent } from './pages/pedido-form/pedido-form.component';
import { PedidoListComponent } from './pages/pedido-list/pedido-list.component';
import { HttpModule } from '@angular/http';
import { FormsModule } from '@angular/forms';

@NgModule({
  imports: [
    CommonModule,
    HttpModule,
    FormsModule
  ],
  exports: [
    PedidoFormComponent,
    PedidoListComponent
  ],
  declarations: [PedidoFormComponent, PedidoListComponent]
})
export class PedidoModule { }
