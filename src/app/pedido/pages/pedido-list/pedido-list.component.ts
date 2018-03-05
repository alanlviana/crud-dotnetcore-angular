import { Component, OnInit } from '@angular/core';
import { Http  } from '@angular/http';

@Component({
  selector: 'app-pedido-list',
  templateUrl: './pedido-list.component.html',
  styleUrls: ['./pedido-list.component.css']
})
export class PedidoListComponent implements OnInit {
  
  pedidos : any = [];

  constructor(private _http: Http){
    
  }

  ngOnInit(){
    this._http.get("http://127.0.0.1:5000/api/pedido").subscribe(result => {
      this.pedidos = result.json();
    });
  }

}
