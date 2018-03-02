import { Component, OnInit } from '@angular/core';
import { Http  } from '@angular/http';

@Component({
  selector: 'app-pedido-list',
  templateUrl: './pedido-list.component.html',
  styleUrls: ['./pedido-list.component.css']
})
export class PedidoListComponent implements OnInit {
  
  produtos : any = null;
  constructor(private _http: Http){
    
  }

  ngOnInit(){
    this._http.get("/api/produto").subscribe(result => 
    this.produtos = result.json());
  }

}
