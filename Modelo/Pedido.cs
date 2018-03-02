using System;
using System.Collections.Generic;

namespace api.Modelo{

    public class Pedido{

        public string Id;
        public DateTime DataPedido;
        public string NomeCliente;
        public string EnderecoCliente;
        public double ValorTotal;

        public IList<ItemPedido> Itens;

    }

}

