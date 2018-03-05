using System;
using System.Collections.Generic;

namespace api.Controllers.ViewModel{

    public class CheckoutViewModel{

        public string NomeCliente {get;set;}
        public string EnderecoCliente {get;set;}
        public string CardToken {get;set;}
        public IList<CheckoutItemViewModel> Itens {get;set;}
        public class CheckoutItemViewModel
        {
            public int ProdutoId {get;set;}
            public int Quantidade {get;set;}
        }
    }

}