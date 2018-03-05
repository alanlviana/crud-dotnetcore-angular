using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace api.Migrations
{
    public partial class CriandoDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ItensPedido",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Descricao = table.Column<string>(nullable: true),
                    PedidoId = table.Column<string>(nullable: true),
                    Quantidade = table.Column<int>(nullable: false),
                    ValorUnitario = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItensPedido", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    DataPedido = table.Column<DateTime>(nullable: false),
                    EnderecoCliente = table.Column<string>(nullable: true),
                    NomeCliente = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItensPedido");

            migrationBuilder.DropTable(
                name: "Pedidos");
        }
    }
}
