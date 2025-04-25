using Microsoft.EntityFrameworkCore.Migrations;

public partial class InitialCreate : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Producto",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("Oracle:Identity", "1, 1"),
                Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                Descripcion = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                Precio = table.Column<decimal>(type: "number(10,2)", nullable: false),
                Cantidad = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Producto", x => x.Id);
            });
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Producto");
    }
}
