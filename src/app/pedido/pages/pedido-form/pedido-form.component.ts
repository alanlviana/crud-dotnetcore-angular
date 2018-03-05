import { Component, OnInit } from '@angular/core';
import { Http  } from '@angular/http';
import { forEach } from '@angular/router/src/utils/collection';

@Component({
  selector: 'app-pedido-form',
  templateUrl: './pedido-form.component.html',
  styleUrls: ['./pedido-form.component.css']
})
export class PedidoFormComponent implements OnInit {

  nome: string = "";
  localEntrega: string = "";
  itensPedido : any = [];

  baseUrl:string = "http://127.0.0.1:5000/";

  constructor(private _http: Http){
    
  }

  ngOnInit(){
    this._http.get(this.baseUrl+"api/produto").subscribe(result => {
      this.itensPedido = result.json().map((produto)=>{
        produto.quantidade = 0;
        return produto;
      });
      
    });
  }

  getTotalItens(){
    return this.itensPedido.map( i => i.preco * i.quantidade)
                      .reduce((sum,current) => sum + current,0);
  }

  finalizarPedido(){
    
    var itensParaEnvio = this.itensPedido.filter(item => item.quantidade > 0);
    
    var checkout : any = {
      "nomeCliente": this.nome,
      "enderecoCliente": this.localEntrega,
      "cardToken": "1234",
      "itens": itensParaEnvio.map(i => {
        return {
          "produtoId": i.id,
          "quantidade": i.quantidade
        };
      })
    };
    this._http.post(this.baseUrl+"api/checkout",checkout).subscribe(result => {
      console.log(result);
    });
  }


}
