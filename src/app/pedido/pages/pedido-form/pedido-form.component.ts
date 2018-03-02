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
  itensPedido : any = null;

  constructor(private _http: Http){
    
  }

  ngOnInit(){
    this._http.get("api/produto").subscribe(result => {
      this.itensPedido = result.json().map((produto)=>{
        produto.quantidade = 0;
        return produto;
      });
      
    });
  }

  getTotalItens(){
    return this.itensPedido.map( i => i.preco * i.quantidade)
                      .reduce((sum,current) => sum + current);
  }

  finalizarPedido(){
    var pedido : any = {
      "nomeCliente": this.nome,
      "enderecoCliente": this.localEntrega,
      "valorTotal": this.getTotalItens(),
      "itens": this.itensPedido.map(i => {
        return {
          "descricao": i.descricao,
          "valorUnitario": i.preco * i.quantidade
        };
      })
    };

    console.log(pedido);
  }


}
