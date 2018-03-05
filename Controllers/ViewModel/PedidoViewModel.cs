using System;
using api.Modelo;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace api.Controllers.ViewModel{
    public class PedidoViewModel{

        public PedidoViewModel(Pedido pedido, double valorTotal){
            Id = pedido.Id;
            DataPedido = pedido.DataPedido;
            NomeCliente = pedido.NomeCliente;
            EnderecoCliente = pedido.EnderecoCliente;
            Status = pedido.Status;
            ValorTotal = valorTotal;
        }

        public int Id{get;set;}
        public DateTime DataPedido{get;set;}
        public string NomeCliente{get;set;}
        public string EnderecoCliente{get;set;}
        [JsonConverter(typeof(StringEnumConverter))]
        public PedidoStatus Status{get;set;}
        public double ValorTotal{get;set;}



    }
}