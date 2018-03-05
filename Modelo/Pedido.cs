using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace api.Modelo{

    public class Pedido{
        
        public int Id{get; set;}
        
        public DateTime DataPedido{get; set;}
        
        public string NomeCliente{get; set;}
        
        public string EnderecoCliente{get; set;}
        [JsonConverter(typeof(StringEnumConverter))]
        public PedidoStatus Status{get; set;}
        
       
    }

}

