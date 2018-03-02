using System;
using System.Collections.Generic;
using api.Modelo;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace api.Controllers{

    [Route("api/[controller]")]
    public class ProdutoController:Controller{

        private List<Produto> Produtos = new List<Produto>{
                new Produto(){Id="1",Descricao="Pão de Mel - Doce de Leite",Preco=3},
                new Produto(){Id="2",Descricao="Pão de Mel - Chocolate",Preco=3.5},
                new Produto(){Id="3",Descricao="Pão de Mel - Paçoca",Preco=4.5}
        };
         
        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
         return Ok(Produtos);    
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var produto = await Task<Produto>.Run(() => Produtos.Where(p => p.Id.Equals(id.ToString()))
                                                                .FirstOrDefault()
                                                );
            if (produto == null){
                return NotFound();
            }

            return Ok(produto);
        }
    }

}