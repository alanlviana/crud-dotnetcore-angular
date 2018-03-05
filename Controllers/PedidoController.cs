using System;
using System.Collections.Generic;
using System.Linq;
using api.Controllers.ViewModel;
using api.Modelo;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers{
    [Route("api/[controller]")]
    public class PedidoController :Controller{

        public PedidoController(Context context){
            this._context = context;
        }
        private readonly Context _context;
        [HttpPost]
        public IActionResult CadastroPedido([FromBody]Pedido pedido){
            
            pedido.DataPedido = DateTime.Now;
            pedido.Status = PedidoStatus.PENDENTE;
            _context.Pedidos.Add(pedido);
            _context.SaveChanges();
            return Ok();
        }

         
        [HttpPost("{id}/ItemPedido/")]
        public IActionResult AdicionarItemPedido(int id, [FromBody]ItemPedido item){

            var pedido = _context.Pedidos.Where(p => p.Id == id).FirstOrDefault();

            if (pedido == null){
                return NotFound();
            }

            item.PedidoId = id;
            _context.ItensPedido.Add(item);
            _context.SaveChanges();
            return Ok();
        }

        [HttpGet("{id}/ItemPedido/{idItemPedido}")]
        public IActionResult RecuperarItemPedido(int id,int idItemPedido){
            var itemPedido = _context.ItensPedido.Where(ip => ip.Id == idItemPedido && ip.PedidoId == id).FirstOrDefault();
            if (itemPedido == null){
                return NotFound();
            }


            return Ok(itemPedido);
        }
        [HttpGet("{id}/ItemPedido/")]
        public IActionResult RecuperarTodosItensPedido(int id){
            var listaItens = _context.ItensPedido.Where(ip => ip.PedidoId == id).ToList();

            return Ok(listaItens);
        }
        
        [HttpGet]
        public IActionResult ListaPedidos(){
            var pedidosViews = _context.Pedidos.ToList().Select(pedido => {
                var valorTotal = _context.ItensPedido.Where(i => i.PedidoId == pedido.Id).Sum(i => i.ValorUnitario * i.Quantidade);
                return new PedidoViewModel(pedido,valorTotal);
            });
            
            return Ok(pedidosViews);
        }



    }


}