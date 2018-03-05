using System;
using System.ComponentModel.DataAnnotations;

namespace api.Modelo{

    public class ItemPedido{
        [Key]
        public int  Id {get; set;}
        public int PedidoId {get; set;}
        public String Descricao{get; set;}
        
        public double ValorUnitario{get; set;}
        
        public int Quantidade{get; set;}

        public double CalcularValorTotal()
        {
            return ValorUnitario * Quantidade;
        }
    }

}