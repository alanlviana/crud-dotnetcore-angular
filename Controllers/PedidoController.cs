using System;
using System.Collections.Generic;
using System.Linq;
using api.Modelo;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers{
    [Route("api/[controller]")]
    public class PedidoController :Controller{

        private static List<Pedido> _pedidos = new List<Pedido>(){new Pedido(){
            Id = "1",
            NomeCliente = "Alan",
            EnderecoCliente = "Mesa 01",
            DataPedido = DateTime.Now,
            ValorTotal = 9,
            Itens = new List<ItemPedido>(){
                new ItemPedido(){
                    Id = "1",
                    IdPedido = "1",
                    Descricao = "Pão de Mel Tradicional",
                    ValorUnitario = 3
                }
            }
        }};

        [HttpPost]
        public IActionResult CadastroPedido([FromBody]Pedido pedido){
            _pedidos.Add(pedido);
            return Ok();
        }

        [HttpPost("{id}/ItemPedido/")]
        public IActionResult AdicionarItemPedido(int id, [FromBody]ItemPedido item){

            var pedido = _pedidos.Where(p => p.Id.Equals(id.ToString())).FirstOrDefault();

            if (pedido == null){
                return NotFound();
            }

            pedido.Itens.Add(item);
            return Ok();
        }

        [HttpGet("{id}/ItemPedido/{idItemPedido}")]
        public IActionResult RecuperarItemPedido(int id,int idItemPedido){

            var pedido = _pedidos.Where(p => p.Id.Equals(id.ToString())).FirstOrDefault();

            if (pedido == null){
                return NotFound();
            }
            var itemPedido = pedido.Itens.Where(i => i.Id.Equals(idItemPedido.ToString())).FirstOrDefault();

            if (itemPedido == null){
                return NotFound();
            }


            return Ok(itemPedido);
        }
        [HttpGet]
        public IActionResult ListaPedidos(){
            return Ok(_pedidos);
        }



    }


}