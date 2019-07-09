using Microsoft.EntityFrameworkCore.Migrations;

namespace SalonAPI.Migrations
{
    public partial class initSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    CartId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(nullable: false),
                    Total = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.CartId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Firstname = table.Column<string>(nullable: true),
                    Lastname = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    CartItemId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    ProductPrice = table.Column<double>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    CartId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.CartItemId);
                    table.ForeignKey(
                        name: "FK_CartItems_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "CartId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Description", "Name", "Price" },
                values: new object[] { 1, "This conditioner is one of the best out! A quick tip for this product is to put on as much as possible and work it through the hair strands.", "Black Vanilla Conditioner", 24.0 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Description", "Name", "Price" },
                values: new object[] { 2, "Add length and volume to your hair with the 20″ Jet Black Clip-In Hair Extensions. Quickly clip in a new look and style straight or with curls.", "Jet Black Clip-In Extensions", 81.0 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Description", "Name", "Price" },
                values: new object[] { 3, "Brazilian Silky Straight Hair Extensions are true to length with the ability to color and style to perfection. With our wholesale straight bundles starting at just $29.99, it is hard to beat our quality and price. Maintenance is simple and silky straight is perfect for a bob or long lengths up to 32.", "Brazilian Straight Hair", 29.989999999999998 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "Firstname", "Lastname" },
                values: new object[] { 1, "janeeharris@hotmail.com", "Ashley", "Walter" });

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_CartId",
                table: "CartItems",
                column: "CartId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Carts");
        }
    }
}
