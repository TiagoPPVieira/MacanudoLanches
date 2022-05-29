using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MacanudoLanches.Migrations
{
    public partial class PopularLanches : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO lanches" +
                "(CategoryId, ShortDescription, LongDescription, InStock, ImageThumbnailUrl," +
                " ImageUrl, IsLanchePreferred, Name, Price)" +
                "VALUES(1, 'Lanche muito bom', 'Pão, hamburguer, ovo, presunto, queijo', 1," +
                " 'https://assets.unileversolutions.com/recipes-v2/230411.jpg'," +
                " 'https://d3sn2rlrwxy0ce.cloudfront.net/whopper-thumb.png?mtime=20210916125149&focal=none'," +
                " 0, 'Cheese Salada', 12.50)");
            migrationBuilder.Sql("INSERT INTO lanches" +
                "(CategoryId, ShortDescription, LongDescription, InStock, ImageThumbnailUrl," +
                " ImageUrl, IsLanchePreferred, Name, Price)" +
                "VALUES(2, 'Lanche muito bom', 'Pão, hamburguer, ovo, presunto, queijo', 1," +
                " 'https://assets.unileversolutions.com/recipes-v2/230411.jpg'," +
                " 'https://d3sn2rlrwxy0ce.cloudfront.net/whopper-thumb.png?mtime=20210916125149&focal=none'," +
                " 1, 'Cheese Bacon', 12.50)"); 
            migrationBuilder.Sql("INSERT INTO lanches" +
                 "(CategoryId, ShortDescription, LongDescription, InStock, ImageThumbnailUrl," +
                 " ImageUrl, IsLanchePreferred, Name, Price)" +
                 "VALUES(1, 'Lanche muito bom', 'Pão, hamburguer, ovo, presunto, queijo', 1," +
                 " 'https://assets.unileversolutions.com/recipes-v2/230411.jpg'," +
                 " 'https://d3sn2rlrwxy0ce.cloudfront.net/whopper-thumb.png?mtime=20210916125149&focal=none'," +
                 " 0, 'Cheese Salada', 12.50)");
            migrationBuilder.Sql("INSERT INTO lanches" +
                "(CategoryId, ShortDescription, LongDescription, InStock, ImageThumbnailUrl," +
                " ImageUrl, IsLanchePreferred, Name, Price)" +
                "VALUES(1, 'Lanche muito bom', 'Pão, hamburguer, ovo, presunto, queijo', 1," +
                " 'https://assets.unileversolutions.com/recipes-v2/230411.jpg'," +
                " 'https://d3sn2rlrwxy0ce.cloudfront.net/whopper-thumb.png?mtime=20210916125149&focal=none'," +
                " 0, 'Cheese Salada', 12.50)");
        }
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Lanches");
        }
    }
}
