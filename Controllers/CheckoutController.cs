using System;
using System.Collections.Generic;
using System.Linq;
using api.Controllers.ViewModel;
using api.Modelo;
using Microsoft.AspNetCore.Mvc;
using static api.Controllers.ViewModel.CheckoutViewModel;

namespace api.Controllers
{
    [Route("api/[controller]")]
    public class CheckoutController : Controller
    {
        private readonly Context _context;

        public CheckoutController(Context context)
        {
            this._context = context;
        }

        [HttpPost]
        public IActionResult FinalizarPedido([FromBody]CheckoutViewModel checkout)
        {
            Pedido pedido = criarPedidoCheckout(checkout);
            _context.Pedidos.Add(pedido);
            IList<ItemPedido> itens = criarItensCheckout(checkout, pedido.Id);
            _context.ItensPedido.AddRange(itens);
            _context.SaveChanges();
            return Ok();
        }
        private IList<ItemPedido> criarItensCheckout(CheckoutViewModel checkout, int pedidoId)
        {
            var listaItens = new List<ItemPedido>();
            foreach(var itemCheckout in checkout.Itens){
                var produto = ProdutoController.Produtos.Where(p => p.Id == itemCheckout.ProdutoId).First();
                var itemPedido = new ItemPedido(){
                    Descricao = produto.Descricao,
                    PedidoId = pedidoId,
                    Quantidade = itemCheckout.Quantidade,
                    ValorUnitario = produto.Preco
                };
                listaItens.Add(itemPedido);
            }
            return listaItens;
        }

        private Pedido criarPedidoCheckout(CheckoutViewModel checkout)
        {
            var pedido = new Pedido();
            pedido.DataPedido = DateTime.Now;
            pedido.NomeCliente = checkout.NomeCliente;
            pedido.EnderecoCliente = checkout.EnderecoCliente;
            pedido.Status = PedidoStatus.PENDENTE;
            return pedido;
        }

        private void ValidarCartao(string cardToken)
        {
            throw new NotImplementedException();
        }
    }

}