import { Component, OnInit } from '@angular/core';
import { Http  } from '@angular/http';
import { forEach } from '@angular/router/src/utils/collection';
import { Observable } from 'rxjs/Observable';
import { Response } from '@angular/http/src/static_response';

@Component({
  selector: 'app-pedido-form',
  templateUrl: './pedido-form.component.html',
  styleUrls: ['./pedido-form.component.css']
})
export class PedidoFormComponent implements OnInit {

  nome: string = "";
  localEntrega: string = "";
  card: any = {
    identification: "41006420835",
    name: "Alan Luiz Viana",
    number: "4235647728025682",
    expirationMonth: "12",
    expirationYear: "2015",
    cvv: "123"
  }
  itensPedido : any = [];

  baseUrl:string = "";

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

  async finalizarPedido(){
    
    // Valida cartão
    var cardToken = await this.validaCartao(this.card);

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

  async validaCartao(card) {
    var response = await this._http.post("https://api.mercadopago.com/v1/card_tokens?public_key=TEST-17b12ef3-9d1d-4e98-b87d-d73f350d6cef",{
      "expirationYear": card.expirationYear,
      "expirationMonth": card.expirationMonth,
      "cardholder": {
        "identification":{
          "number":card.identification,
          "type":"CPF"
        }
      }
    }).toPromise();
    console.log(response);
    return response;
  }
}
