using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MacanudoLanches.Migrations
{
    public partial class PopularCategorias : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Categorias(Name, Description)" +
                "VALUES('Normal', 'Lanche feito com ingredientes normais')");
            migrationBuilder.Sql("INSERT INTO Categorias(Name, Description)" +
                "VALUES('Natural', 'Lanche feito com ingredientes integrais e normais')");
        }
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Categorias");
        }
    }
}
