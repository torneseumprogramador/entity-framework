using Microsoft.EntityFrameworkCore.Migrations;

namespace Entity.Pedidos.Data.Migrations
{
    public partial class PluralizarNomes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_pedido_item_pedidos_PedidoId",
                table: "pedido_item");

            migrationBuilder.DropPrimaryKey(
                name: "PK_pedido_item",
                table: "pedido_item");

            migrationBuilder.DropPrimaryKey(
                name: "PK_cupom_desconto",
                table: "cupom_desconto");

            migrationBuilder.RenameTable(
                name: "pedido_item",
                newName: "pedido_itens");

            migrationBuilder.RenameTable(
                name: "cupom_desconto",
                newName: "cupom_descontos");

            migrationBuilder.RenameIndex(
                name: "IX_pedido_item_PedidoId",
                table: "pedido_itens",
                newName: "IX_pedido_itens_PedidoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_pedido_itens",
                table: "pedido_itens",
                column: "PedidoItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_cupom_descontos",
                table: "cupom_descontos",
                column: "CupomDescontoId");

            migrationBuilder.AddForeignKey(
                name: "FK_pedido_itens_pedidos_PedidoId",
                table: "pedido_itens",
                column: "PedidoId",
                principalTable: "pedidos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_pedido_itens_pedidos_PedidoId",
                table: "pedido_itens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_pedido_itens",
                table: "pedido_itens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_cupom_descontos",
                table: "cupom_descontos");

            migrationBuilder.RenameTable(
                name: "pedido_itens",
                newName: "pedido_item");

            migrationBuilder.RenameTable(
                name: "cupom_descontos",
                newName: "cupom_desconto");

            migrationBuilder.RenameIndex(
                name: "IX_pedido_itens_PedidoId",
                table: "pedido_item",
                newName: "IX_pedido_item_PedidoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_pedido_item",
                table: "pedido_item",
                column: "PedidoItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_cupom_desconto",
                table: "cupom_desconto",
                column: "CupomDescontoId");

            migrationBuilder.AddForeignKey(
                name: "FK_pedido_item_pedidos_PedidoId",
                table: "pedido_item",
                column: "PedidoId",
                principalTable: "pedidos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
