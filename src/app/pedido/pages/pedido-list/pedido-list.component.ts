import { Component, OnInit } from '@angular/core';
import { Http  } from '@angular/http';

@Component({
  selector: 'app-pedido-list',
  templateUrl: './pedido-list.component.html',
  styleUrls: ['./pedido-list.component.css']
})
export class PedidoListComponent implements OnInit {
  
  pedidos : any = [];
  baseUrl:string = "";
  constructor(private _http: Http){
    
  }

  ngOnInit(){
    this._http.get(this.baseUrl+"api/pedido").subscribe(result => {
      this.pedidos = result.json();
    });
  }

}
