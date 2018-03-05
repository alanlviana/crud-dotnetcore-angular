using System;
using Microsoft.EntityFrameworkCore;

namespace api.Modelo{

    public class Context: DbContext {
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<ItemPedido> ItensPedido { get; set; }

        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlite("Data Source=PaoMel.db");
        //}
    }
    

}