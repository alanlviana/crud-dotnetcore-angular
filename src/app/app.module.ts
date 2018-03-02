import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpModule } from '@angular/http';

import { AppComponent } from './app.component';
import { NavbarComponent } from './shared/navbar/navbar.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { RoutingModule } from './app.router'
import { PedidoModule } from './pedido/pedido.module'

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    PageNotFoundComponent
  ],
  imports: [
    BrowserModule,
    HttpModule,
    RoutingModule,
    PedidoModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
