using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Neon.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Manufacturers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HashPassword = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cost = table.Column<double>(type: "float", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ManufacturerId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Products_Manufacturers_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "Manufacturers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Histories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Histories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Histories_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Histories_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderCompositions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Count = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderCompositions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderCompositions_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderCompositions_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2025, 1, 11, 15, 3, 33, 258, DateTimeKind.Unspecified).AddTicks(2702), new TimeSpan(0, 5, 0, 0, 0)), "Компьютеры", new DateTimeOffset(new DateTime(2025, 1, 11, 15, 3, 33, 260, DateTimeKind.Unspecified).AddTicks(951), new TimeSpan(0, 5, 0, 0, 0)) },
                    { 2, new DateTimeOffset(new DateTime(2025, 1, 11, 15, 3, 33, 260, DateTimeKind.Unspecified).AddTicks(1283), new TimeSpan(0, 5, 0, 0, 0)), "Ноутбуки", new DateTimeOffset(new DateTime(2025, 1, 11, 15, 3, 33, 260, DateTimeKind.Unspecified).AddTicks(1289), new TimeSpan(0, 5, 0, 0, 0)) },
                    { 3, new DateTimeOffset(new DateTime(2025, 1, 11, 15, 3, 33, 260, DateTimeKind.Unspecified).AddTicks(1291), new TimeSpan(0, 5, 0, 0, 0)), "Сканеры", new DateTimeOffset(new DateTime(2025, 1, 11, 15, 3, 33, 260, DateTimeKind.Unspecified).AddTicks(1292), new TimeSpan(0, 5, 0, 0, 0)) },
                    { 4, new DateTimeOffset(new DateTime(2025, 1, 11, 15, 3, 33, 260, DateTimeKind.Unspecified).AddTicks(1294), new TimeSpan(0, 5, 0, 0, 0)), "Принтеры", new DateTimeOffset(new DateTime(2025, 1, 11, 15, 3, 33, 260, DateTimeKind.Unspecified).AddTicks(1295), new TimeSpan(0, 5, 0, 0, 0)) },
                    { 5, new DateTimeOffset(new DateTime(2025, 1, 11, 15, 3, 33, 260, DateTimeKind.Unspecified).AddTicks(1297), new TimeSpan(0, 5, 0, 0, 0)), "Плоттеры", new DateTimeOffset(new DateTime(2025, 1, 11, 15, 3, 33, 260, DateTimeKind.Unspecified).AddTicks(1298), new TimeSpan(0, 5, 0, 0, 0)) },
                    { 6, new DateTimeOffset(new DateTime(2025, 1, 11, 15, 3, 33, 260, DateTimeKind.Unspecified).AddTicks(1299), new TimeSpan(0, 5, 0, 0, 0)), "Микрокомпьютреы", new DateTimeOffset(new DateTime(2025, 1, 11, 15, 3, 33, 260, DateTimeKind.Unspecified).AddTicks(1300), new TimeSpan(0, 5, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2025, 1, 11, 15, 3, 33, 261, DateTimeKind.Unspecified).AddTicks(2391), new TimeSpan(0, 5, 0, 0, 0)), "Apple", new DateTimeOffset(new DateTime(2025, 1, 11, 15, 3, 33, 261, DateTimeKind.Unspecified).AddTicks(2401), new TimeSpan(0, 5, 0, 0, 0)) },
                    { 2, new DateTimeOffset(new DateTime(2025, 1, 11, 15, 3, 33, 261, DateTimeKind.Unspecified).AddTicks(2403), new TimeSpan(0, 5, 0, 0, 0)), "Raspberry Pi Foundation", new DateTimeOffset(new DateTime(2025, 1, 11, 15, 3, 33, 261, DateTimeKind.Unspecified).AddTicks(2404), new TimeSpan(0, 5, 0, 0, 0)) },
                    { 3, new DateTimeOffset(new DateTime(2025, 1, 11, 15, 3, 33, 261, DateTimeKind.Unspecified).AddTicks(2406), new TimeSpan(0, 5, 0, 0, 0)), "ASUS", new DateTimeOffset(new DateTime(2025, 1, 11, 15, 3, 33, 261, DateTimeKind.Unspecified).AddTicks(2407), new TimeSpan(0, 5, 0, 0, 0)) },
                    { 4, new DateTimeOffset(new DateTime(2025, 1, 11, 15, 3, 33, 261, DateTimeKind.Unspecified).AddTicks(2408), new TimeSpan(0, 5, 0, 0, 0)), "MSI", new DateTimeOffset(new DateTime(2025, 1, 11, 15, 3, 33, 261, DateTimeKind.Unspecified).AddTicks(2409), new TimeSpan(0, 5, 0, 0, 0)) },
                    { 5, new DateTimeOffset(new DateTime(2025, 1, 11, 15, 3, 33, 261, DateTimeKind.Unspecified).AddTicks(2410), new TimeSpan(0, 5, 0, 0, 0)), "Acer", new DateTimeOffset(new DateTime(2025, 1, 11, 15, 3, 33, 261, DateTimeKind.Unspecified).AddTicks(2411), new TimeSpan(0, 5, 0, 0, 0)) },
                    { 6, new DateTimeOffset(new DateTime(2025, 1, 11, 15, 3, 33, 261, DateTimeKind.Unspecified).AddTicks(2413), new TimeSpan(0, 5, 0, 0, 0)), "HP", new DateTimeOffset(new DateTime(2025, 1, 11, 15, 3, 33, 261, DateTimeKind.Unspecified).AddTicks(2414), new TimeSpan(0, 5, 0, 0, 0)) },
                    { 7, new DateTimeOffset(new DateTime(2025, 1, 11, 15, 3, 33, 261, DateTimeKind.Unspecified).AddTicks(2415), new TimeSpan(0, 5, 0, 0, 0)), "Canon", new DateTimeOffset(new DateTime(2025, 1, 11, 15, 3, 33, 261, DateTimeKind.Unspecified).AddTicks(2415), new TimeSpan(0, 5, 0, 0, 0)) },
                    { 8, new DateTimeOffset(new DateTime(2025, 1, 11, 15, 3, 33, 261, DateTimeKind.Unspecified).AddTicks(2417), new TimeSpan(0, 5, 0, 0, 0)), "Xerox", new DateTimeOffset(new DateTime(2025, 1, 11, 15, 3, 33, 261, DateTimeKind.Unspecified).AddTicks(2417), new TimeSpan(0, 5, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "HashPassword", "IsAdmin", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2025, 1, 11, 15, 3, 33, 263, DateTimeKind.Unspecified).AddTicks(8654), new TimeSpan(0, 5, 0, 0, 0)), "A665A45920422F9D417E4867EFDC4FB8A04A1F3FFF1FA07E998E86F7F7A27AE3", true, "Admin1", new DateTimeOffset(new DateTime(2025, 1, 11, 15, 3, 33, 263, DateTimeKind.Unspecified).AddTicks(8663), new TimeSpan(0, 5, 0, 0, 0)) },
                    { 2, new DateTimeOffset(new DateTime(2025, 1, 11, 15, 3, 33, 263, DateTimeKind.Unspecified).AddTicks(8668), new TimeSpan(0, 5, 0, 0, 0)), "03AC674216F3E15C761EE1A5E255F067953623C8B388B4459E13F978D7C846F4", true, "Admin2", new DateTimeOffset(new DateTime(2025, 1, 11, 15, 3, 33, 263, DateTimeKind.Unspecified).AddTicks(8669), new TimeSpan(0, 5, 0, 0, 0)) },
                    { 3, new DateTimeOffset(new DateTime(2025, 1, 11, 15, 3, 33, 263, DateTimeKind.Unspecified).AddTicks(8670), new TimeSpan(0, 5, 0, 0, 0)), "F6E0A1E2AC41945A9AA7FF8A8AAA0CEBC12A3BCC981A929AD5CF810A090E11AE", false, "Swifty", new DateTimeOffset(new DateTime(2025, 1, 11, 15, 3, 33, 263, DateTimeKind.Unspecified).AddTicks(8671), new TimeSpan(0, 5, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CreatedAt", "Title", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2025, 1, 11, 15, 3, 33, 262, DateTimeKind.Unspecified).AddTicks(577), new TimeSpan(0, 5, 0, 0, 0)), "1638722046132620082", new DateTimeOffset(new DateTime(2025, 1, 11, 15, 3, 33, 262, DateTimeKind.Unspecified).AddTicks(581), new TimeSpan(0, 5, 0, 0, 0)), 1 },
                    { 2, new DateTimeOffset(new DateTime(2025, 1, 11, 15, 3, 33, 262, DateTimeKind.Unspecified).AddTicks(593), new TimeSpan(0, 5, 0, 0, 0)), "1638722046132620584", new DateTimeOffset(new DateTime(2025, 1, 11, 15, 3, 33, 262, DateTimeKind.Unspecified).AddTicks(594), new TimeSpan(0, 5, 0, 0, 0)), 1 },
                    { 3, new DateTimeOffset(new DateTime(2025, 1, 11, 15, 3, 33, 262, DateTimeKind.Unspecified).AddTicks(598), new TimeSpan(0, 5, 0, 0, 0)), "1638722046132620596", new DateTimeOffset(new DateTime(2025, 1, 11, 15, 3, 33, 262, DateTimeKind.Unspecified).AddTicks(598), new TimeSpan(0, 5, 0, 0, 0)), 1 },
                    { 4, new DateTimeOffset(new DateTime(2025, 1, 11, 15, 3, 33, 262, DateTimeKind.Unspecified).AddTicks(601), new TimeSpan(0, 5, 0, 0, 0)), "1638722046132620600", new DateTimeOffset(new DateTime(2025, 1, 11, 15, 3, 33, 262, DateTimeKind.Unspecified).AddTicks(602), new TimeSpan(0, 5, 0, 0, 0)), 1 },
                    { 5, new DateTimeOffset(new DateTime(2025, 1, 11, 15, 3, 33, 262, DateTimeKind.Unspecified).AddTicks(605), new TimeSpan(0, 5, 0, 0, 0)), "2638722046132620603", new DateTimeOffset(new DateTime(2025, 1, 11, 15, 3, 33, 262, DateTimeKind.Unspecified).AddTicks(605), new TimeSpan(0, 5, 0, 0, 0)), 2 },
                    { 6, new DateTimeOffset(new DateTime(2025, 1, 11, 15, 3, 33, 262, DateTimeKind.Unspecified).AddTicks(608), new TimeSpan(0, 5, 0, 0, 0)), "2638722046132620607", new DateTimeOffset(new DateTime(2025, 1, 11, 15, 3, 33, 262, DateTimeKind.Unspecified).AddTicks(609), new TimeSpan(0, 5, 0, 0, 0)), 2 },
                    { 7, new DateTimeOffset(new DateTime(2025, 1, 11, 15, 3, 33, 262, DateTimeKind.Unspecified).AddTicks(611), new TimeSpan(0, 5, 0, 0, 0)), "2638722046132620610", new DateTimeOffset(new DateTime(2025, 1, 11, 15, 3, 33, 262, DateTimeKind.Unspecified).AddTicks(612), new TimeSpan(0, 5, 0, 0, 0)), 2 },
                    { 8, new DateTimeOffset(new DateTime(2025, 1, 11, 15, 3, 33, 262, DateTimeKind.Unspecified).AddTicks(614), new TimeSpan(0, 5, 0, 0, 0)), "2638722046132620613", new DateTimeOffset(new DateTime(2025, 1, 11, 15, 3, 33, 262, DateTimeKind.Unspecified).AddTicks(615), new TimeSpan(0, 5, 0, 0, 0)), 2 },
                    { 9, new DateTimeOffset(new DateTime(2025, 1, 11, 15, 3, 33, 262, DateTimeKind.Unspecified).AddTicks(618), new TimeSpan(0, 5, 0, 0, 0)), "3638722046132620616", new DateTimeOffset(new DateTime(2025, 1, 11, 15, 3, 33, 262, DateTimeKind.Unspecified).AddTicks(618), new TimeSpan(0, 5, 0, 0, 0)), 3 },
                    { 10, new DateTimeOffset(new DateTime(2025, 1, 11, 15, 3, 33, 262, DateTimeKind.Unspecified).AddTicks(621), new TimeSpan(0, 5, 0, 0, 0)), "3638722046132620620", new DateTimeOffset(new DateTime(2025, 1, 11, 15, 3, 33, 262, DateTimeKind.Unspecified).AddTicks(622), new TimeSpan(0, 5, 0, 0, 0)), 3 },
                    { 11, new DateTimeOffset(new DateTime(2025, 1, 11, 15, 3, 33, 262, DateTimeKind.Unspecified).AddTicks(624), new TimeSpan(0, 5, 0, 0, 0)), "3638722046132620623", new DateTimeOffset(new DateTime(2025, 1, 11, 15, 3, 33, 262, DateTimeKind.Unspecified).AddTicks(625), new TimeSpan(0, 5, 0, 0, 0)), 3 },
                    { 12, new DateTimeOffset(new DateTime(2025, 1, 11, 15, 3, 33, 262, DateTimeKind.Unspecified).AddTicks(627), new TimeSpan(0, 5, 0, 0, 0)), "3638722046132620626", new DateTimeOffset(new DateTime(2025, 1, 11, 15, 3, 33, 262, DateTimeKind.Unspecified).AddTicks(628), new TimeSpan(0, 5, 0, 0, 0)), 3 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Cost", "Count", "CreatedAt", "Description", "ImagePath", "ManufacturerId", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 5, 162999.0, 1, new DateTimeOffset(new DateTime(2025, 1, 11, 15, 3, 33, 263, DateTimeKind.Unspecified).AddTicks(1035), new TimeSpan(0, 5, 0, 0, 0)), "Широкоформатный принтер HP DesignJet T630 24-in позволит работать с бумагой A1-формата при ширине печати, достигающей 24 дюйма. Оборудование для большого офиса действует по принципу термоструйной четырехцветной печати с разрешением 2400x1200 dpi. На печать одного листа A1 уходит всего 30 секунд – в цветном и черно-белом режиме. Прибор HP DesignJet T630 24-in оснащен USB-портом стандарта 2.0, Ethernet-интерфейсом и модулем Wi-Fi. Конструкция дополнена дисплеем, автоматическим резаком и лотком для материалов печати. Принтер поставляется вместе с комплектом картриджей, кабелем питания, шпинделем, печатающей головкой, подставкой и устройством для подачи листов в автоматическом режиме. Оборудование весит 28.9 кг и обладает размерами 101.3x93.2x60.5 см.", "https://c.dns-shop.ru/thumb/st4/fit/wm/0/0/5b265f525061f2adb15df59de124f8ac/24a623924dda6c2fd58ef2192c31067b716f5e7c867654a79c74e552aebc2373.jpg.webp", 6, "HP DesignJet T630 24-in", new DateTimeOffset(new DateTime(2025, 1, 11, 15, 3, 33, 263, DateTimeKind.Unspecified).AddTicks(1044), new TimeSpan(0, 5, 0, 0, 0)) },
                    { 2, 5, 105499.0, 1, new DateTimeOffset(new DateTime(2025, 1, 11, 15, 3, 33, 263, DateTimeKind.Unspecified).AddTicks(1049), new TimeSpan(0, 5, 0, 0, 0)), "Широкоформатный принтер HP DesignJet T230 используется для печати чертежей и презентационных материалов. Оборудование позволяет работать с бумагой A1-формата, обеспечивая печать шириной 24 дюйма. Вы можете использовать техническую, фотобумагу, пленку, документальную, с покрытием и самоклеящуюся бумагу. Модель HP DesignJet T230 работает по принципу термоструйной печати с применением чернил на основе пигментов и красителей. Оборудование оснащено модулем Wi-Fi, а также USB-портом, сетевым интерфейсом Ethernet. Устройство дополняется автоматическим резаком, а поставляется вместе с печатающей головкой, набором пробных струйных картриджей и кабелем питания.", "https://c.dns-shop.ru/thumb/st1/fit/wm/0/0/7c7a3dc904a797623685280a372fb643/6a347875fb179a3df40591835edb0d977b847988f86ae6c84a6a6af11018963f.jpg.webp", 6, "HP DesignJet T230", new DateTimeOffset(new DateTime(2025, 1, 11, 15, 3, 33, 263, DateTimeKind.Unspecified).AddTicks(1050), new TimeSpan(0, 5, 0, 0, 0)) },
                    { 3, 3, 9999.0, 2, new DateTimeOffset(new DateTime(2025, 1, 11, 15, 3, 33, 263, DateTimeKind.Unspecified).AddTicks(1053), new TimeSpan(0, 5, 0, 0, 0)), "Сканер Canon CanoScan LiDE 300 с компактной планшетной конструкцией обеспечивает высокое качество сканирования и удобство в эксплуатации. В устройстве установлены датчик CIS и светодиодный источник, который позволяет создавать четкие насыщенные отпечатки с разрешением до 2400x2400 dpi. Данная модель поддерживает различные документы форматом до А4. Из особенностей сканера отмечаются 4 кнопки управления и технология автоматического сканирования. Подключение и питание Canon CanoScan LiDE 300 осуществляется посредством интерфейсного разъема USB.", "https://c.dns-shop.ru/thumb/st1/fit/wm/0/0/1776a1ea7815e01a24a1dcb5d1cc318d/96bd12b7b97dc7ac1e4bb14414fa9a61dd765b5f5d9bbc6dca0861129adc7636.jpg.webp", 7, "Canon CanoScan LiDE 300", new DateTimeOffset(new DateTime(2025, 1, 11, 15, 3, 33, 263, DateTimeKind.Unspecified).AddTicks(1054), new TimeSpan(0, 5, 0, 0, 0)) },
                    { 4, 3, 34499.0, 1, new DateTimeOffset(new DateTime(2025, 1, 11, 15, 3, 33, 263, DateTimeKind.Unspecified).AddTicks(1056), new TimeSpan(0, 5, 0, 0, 0)), "Повысьте производительность профессионального сканирования с помощью быстрого, компактного и надежного сканера HP ScanJet Pro, предназначенного для сканирования до 1500 страниц в день. Автоматизируйте рабочие процессы с помощью ярлыков для вызова функций одной кнопкой и автоподатчика с поддержкой быстрого двустороннего сканирования.", "https://c.dns-shop.ru/thumb/st1/fit/wm/0/0/8cb9677f278668e95acaa9f3060d0731/b7740bdb64460420f4be4a6611675340ddc876008bd76033222ff927116bab31.jpg.webp", 6, "HP Scanjet Pro 2600 f1", new DateTimeOffset(new DateTime(2025, 1, 11, 15, 3, 33, 263, DateTimeKind.Unspecified).AddTicks(1056), new TimeSpan(0, 5, 0, 0, 0)) },
                    { 5, 4, 15899.0, 4, new DateTimeOffset(new DateTime(2025, 1, 11, 15, 3, 33, 263, DateTimeKind.Unspecified).AddTicks(1059), new TimeSpan(0, 5, 0, 0, 0)), "Принтер лазерный Xerox Phaser 3020 со светодиодной системой и разрешением 1200х1200 dpi обеспечивает четкость при печати черно-белых документов. Модель ориентирована на ежемесячную нагрузку до 15000 страниц. За 1 минуту устройство печатает 20 страниц формата А4. Подключение принтера Xerox Phaser 3020 к компьютеру выполняется по кабелю с разъемом USB. Для беспроводной синхронизации и обмена файлами реализован модуль Wi-Fi. Функция Apple AirPrint предусматривает печать из поддерживаемых приложений устройств Apple.", "https://c.dns-shop.ru/thumb/st4/fit/wm/0/0/3e2c97e07298a8f07c0dd75909a483f2/c0f3a5d99edd31c5ab9114cc65754aacfdac2dafc7a3cb235e1235b3759c2b04.jpg.webp", 8, "Xerox Phaser 3020", new DateTimeOffset(new DateTime(2025, 1, 11, 15, 3, 33, 263, DateTimeKind.Unspecified).AddTicks(1059), new TimeSpan(0, 5, 0, 0, 0)) },
                    { 6, 6, 13999.0, 3, new DateTimeOffset(new DateTime(2025, 1, 11, 15, 3, 33, 263, DateTimeKind.Unspecified).AddTicks(1061), new TimeSpan(0, 5, 0, 0, 0)), "Микрокомпьютер Raspberry Pi 4 Model B ориентирован на решение различных повседневных задач, не настаивающих на наличии внушительной вычислительной мощности. Благодаря процессору Broadcom BCM2711 вы сможете обрабатывать небольшие файлы, общаться с друзьями, а также использовать всевозможные приложения. В модели Raspberry Pi 4 Model B появился интерфейс Bluetooth, незаменимый для сопряжения с необходимыми устройствами. Быстрое подключение накопителей обеспечивается посредством предусмотренных в микрокомпьютере портов USB 3.0. Необходимое ПО пользователь выбирает в соответствии со своими предпочтениями.", "https://c.dns-shop.ru/thumb/st4/fit/wm/0/0/4665bd94590b11b0b725d72c98cf0538/eb92953343599336171855d1a57e9f70398acb880b4f86bc40b6e6c31c33df4d.jpg.webp", 2, "Raspberry Pi 4 Model B", new DateTimeOffset(new DateTime(2025, 1, 11, 15, 3, 33, 263, DateTimeKind.Unspecified).AddTicks(1062), new TimeSpan(0, 5, 0, 0, 0)) },
                    { 7, 6, 24999.0, 2, new DateTimeOffset(new DateTime(2025, 1, 11, 15, 3, 33, 263, DateTimeKind.Unspecified).AddTicks(1064), new TimeSpan(0, 5, 0, 0, 0)), "Микрокомпьютер Raspberry Pi 4 Model B 8GB представляет собой одноплатное компактное решение, которое при этом отличается высокой функциональностью и широкими возможностями использования. Данное устройство может выступать в качестве платформы для разработки программного обеспечения, эмулятора игровой приставки, а также медиа-центра и просто рабочей станции. В основе микрокомпьютера Raspberry Pi 4 Model B 8GB используется 4-ядерный процессор Broadcom BCM2711, работающий на частоте 1500 МГц, что вкупе с 8 ГБ оперативной памяти типа LPDDR4 может обеспечить комфортный уровень производительности для различных базовых задач. Для использования накопителей на плате предусмотрено множество интерфейсов периферии. Также есть полноформатные разъемы USB и HDMI 2.0, позволяющий выводить изображение в разрешении до 4K. Для доступа к сети модель поддерживает Wi-Fi и проводное подключение посредством Ethernet. Также для беспроводного соединения микрокомпьютер оснащен модулем Bluetooth. Устройство поставляется без операционной системы.", "https://c.dns-shop.ru/thumb/st4/fit/wm/0/0/5312c232092cb38edf5d5ac454dbef63/907f823cdaa4ed5db4aec3d027cd1afb6f7ca7ae8584a45dc28f58c160c51a83.jpg.webp", 2, "Raspberry Pi 4 Model B 8GB", new DateTimeOffset(new DateTime(2025, 1, 11, 15, 3, 33, 263, DateTimeKind.Unspecified).AddTicks(1065), new TimeSpan(0, 5, 0, 0, 0)) },
                    { 8, 1, 61799.0, 2, new DateTimeOffset(new DateTime(2025, 1, 11, 15, 3, 33, 263, DateTimeKind.Unspecified).AddTicks(1067), new TimeSpan(0, 5, 0, 0, 0)), "Мини ПК ASUS ExpertCenter PN52-S5149MD в корпусе-неттопе с размерами 130x120x58 мм предусматривает встроенный сетевой адаптер для проводного подключения к сети Интернет со скоростью обработки данных до 2.5 Гбит/с. Модель поддерживает вывод изображения на экраны нескольких мониторов благодаря присутствию на задней панели видеоразъемов HDMI (2 шт.) и USB Type-C. Для удобного подключения внешних накопителей данных на передней панели есть интерфейсы USB Type-A и USB Type-C. Мини ПК ASUS ExpertCenter PN52-S5149MD предусматривает твердотельный накопитель данных емкостью 256 ГБ для установки программ и хранения файлов, которые могут понадобиться в повседневной работе. 6-ядерный процессор AMD Ryzen 5 5600H и 8 ГБ оперативной памяти обеспечат достаточное быстродействие для запуска популярных офисных программ и решения нересурсоемких задач. На борту устройства отсутствует предустановленная операционная система.", "https://c.dns-shop.ru/thumb/st1/fit/wm/0/0/6d342c326b18387e6fc00490f91854e0/477330cfddac40388d3f9f9af02c613a90f2500c6b8213d128725fc09124832b.jpg.webp", 3, "ASUS ExpertCenter PN52-S5149MD", new DateTimeOffset(new DateTime(2025, 1, 11, 15, 3, 33, 263, DateTimeKind.Unspecified).AddTicks(1067), new TimeSpan(0, 5, 0, 0, 0)) },
                    { 9, 1, 79999.0, 1, new DateTimeOffset(new DateTime(2025, 1, 11, 15, 3, 33, 263, DateTimeKind.Unspecified).AddTicks(1069), new TimeSpan(0, 5, 0, 0, 0)), "Мини ПК Apple Mac mini может похвастаться миниатюрным корпусом с «серьезной» начинкой внутри. В основе его производительности – процессор Apple M2. Благодаря прогрессивной системе Neural Engine скорость машинного обучения возросла до 15 раз. ПК обеспечит недоступные ранее ресурсы для работы, игр и творчества – больше, чем вы могли себе представить. Процессор сочетается с оперативной памятью LPDDR5 объемом 8 ГБ и интегрированной видеокартой Apple M2 10-core. Твердотельного накопителя хватает для размещения до 256 ГБ информации. Производитель гордится тем, что Apple Mac mini работает «как большой», несмотря на свои миниатюрные размеры.", "https://c.dns-shop.ru/thumb/st1/fit/wm/0/0/d202b91bd55a1a89372ea173ce0eb49c/009a75a3b474bb897a06b38287f783608f212eab500b9d311de864276bf56ffb.jpg.webp", 1, "Apple Mac mini", new DateTimeOffset(new DateTime(2025, 1, 11, 15, 3, 33, 263, DateTimeKind.Unspecified).AddTicks(1070), new TimeSpan(0, 5, 0, 0, 0)) },
                    { 10, 1, 42799.0, 3, new DateTimeOffset(new DateTime(2025, 1, 11, 15, 3, 33, 263, DateTimeKind.Unspecified).AddTicks(1072), new TimeSpan(0, 5, 0, 0, 0)), "Мини ПК Acer Veriton N4710GT [DT.VXVCD.001] с малогабаритным корпусом-неттопом черного цвета рассчитан на выполнение офисных задач или эксплуатацию в качестве универсальной домашней станции. В сборке предусмотрены центральный процессор Intel Core i3-13100 оперативная память стандарта DDR4 общей емкостью 8 ГБ. Для операций с графическими данными используется встроенное графическое видеоядро ЦПУ Intel UHD Graphics 730. Для установки операционной системы и долговременного хранения данных компьютер компактного форм-фактора Acer Veriton N4710GT [DT.VXVCD.001] располагает одним накопителем SSD объемом 512 ГБ. Задачу снабжения всех потребителей системного блока электроэнергией решает блок питания с выходной мощностью 90 Вт. ПК поставляется без предустановленной рабочей платформы, чтобы вы смогли выбрать для него ОС самостоятельно.", "https://c.dns-shop.ru/thumb/st1/fit/wm/0/0/eaad089ab5a250ea0761e3e627b369ed/88536a35172397022dc8276542aeb7eb186f1f5fe8b5c588f1fbb5be14f71746.jpg.webp", 5, "Acer Veriton N4710GT", new DateTimeOffset(new DateTime(2025, 1, 11, 15, 3, 33, 263, DateTimeKind.Unspecified).AddTicks(1073), new TimeSpan(0, 5, 0, 0, 0)) },
                    { 11, 1, 64999.0, 3, new DateTimeOffset(new DateTime(2025, 1, 11, 15, 3, 33, 263, DateTimeKind.Unspecified).AddTicks(1075), new TimeSpan(0, 5, 0, 0, 0)), "Мини ПК MSI PRO DP 21 13M-631XRU в компактном корпусе размерами 208x54.8x204 мм предусматривает интерфейсы USB и jack 3.5 mm для подключения периферийных устройств, которые могут понадобиться в повседневной работе за компьютером. Модель совместима с VESA-крепежом, благодаря чему ее можно незаметно зафиксировать в любом удобном месте при помощи кронштейна. Устройство предусматривает COM-порт, который используется для подключения различного торгового оборудования, чековых принтеров и сканеров штрих-кодов. Мини ПК MSI PRO DP 21 13M-631XRU оснащен интерфейсом USB 3.2 Gen2 Type-C, благодаря которому при подключении к компьютеру внешних накопителей обеспечивается быстрый обмен файлами. Сборка функционирует на базе 10-ядерного процессора Intel Core i5-13400 и 16 ГБ оперативной памяти, которые обеспечивают стабильную работу при обработке данных электронной и мобильной коммерции.", "https://c.dns-shop.ru/thumb/st4/fit/wm/0/0/85a3fda8b8d165ec1cb7f31e788ff65d/1a4d09e2be16f43e25eb63cdb7895a154357e391f319c62a985d12cd49d96634.jpg.webp", 4, "MSI PRO DP 21 13M-631XRU", new DateTimeOffset(new DateTime(2025, 1, 11, 15, 3, 33, 263, DateTimeKind.Unspecified).AddTicks(1075), new TimeSpan(0, 5, 0, 0, 0)) },
                    { 12, 1, 80999.0, 1, new DateTimeOffset(new DateTime(2025, 1, 11, 15, 3, 33, 263, DateTimeKind.Unspecified).AddTicks(1077), new TimeSpan(0, 5, 0, 0, 0)), "Мини ПК HP ProDesk 400 G9 R Mini имеет компактный корпус из черного пластика, который можно установить в вертикальном положении на специальной подставке. Он занимает мало места на рабочем столе. 16 ядер процессора Intel Core i7 производят вычисления в 24 потока, что обеспечивает моментальное выполнение разных задач без зависаний и торможений. Модуль оперативной памяти на 8 ГБ позволяет открывать множество программ или вкладок в браузере, легко переключаясь между ними. За хранение и быструю загрузку файлов отвечает SSD-накопитель на 512 ГБ. На корпусе мини ПК HP ProDesk 400 G9 R Mini имеются разъемы USB для подключения периферийных устройств и видеоразъемы для мониторов. Возможно беспроводное подключение устройств через Bluetooth. Встроенный сетевой адаптер обеспечивает стабильное интернет-соединение со скоростью 1 Гбит/с. Для этой же цели можно использовать модуль Wi-Fi. В комплекте с мини ПК предусмотрены проводные клавиатура и мышь.", "https://c.dns-shop.ru/thumb/st1/fit/wm/0/0/ed5496ded049c64584bd19ad1fb3ec60/183003053da5384e9e20a70c42f2f24a301248f9ed2ab02c43f3403182d6adf5.jpg.webp", 6, "HP ProDesk 400 G9 R Mini", new DateTimeOffset(new DateTime(2025, 1, 11, 15, 3, 33, 263, DateTimeKind.Unspecified).AddTicks(1078), new TimeSpan(0, 5, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "Histories",
                columns: new[] { "Id", "CreatedAt", "Date", "ProductId", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2025, 1, 11, 15, 3, 33, 272, DateTimeKind.Unspecified).AddTicks(542), new TimeSpan(0, 5, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1, new DateTimeOffset(new DateTime(2025, 1, 11, 15, 3, 33, 272, DateTimeKind.Unspecified).AddTicks(553), new TimeSpan(0, 5, 0, 0, 0)), 3 },
                    { 2, new DateTimeOffset(new DateTime(2025, 1, 11, 15, 3, 33, 272, DateTimeKind.Unspecified).AddTicks(583), new TimeSpan(0, 5, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 11, new DateTimeOffset(new DateTime(2025, 1, 11, 15, 3, 33, 272, DateTimeKind.Unspecified).AddTicks(584), new TimeSpan(0, 5, 0, 0, 0)), 3 },
                    { 3, new DateTimeOffset(new DateTime(2025, 1, 11, 15, 3, 33, 272, DateTimeKind.Unspecified).AddTicks(587), new TimeSpan(0, 5, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 3, new DateTimeOffset(new DateTime(2025, 1, 11, 15, 3, 33, 272, DateTimeKind.Unspecified).AddTicks(588), new TimeSpan(0, 5, 0, 0, 0)), 2 },
                    { 4, new DateTimeOffset(new DateTime(2025, 1, 11, 15, 3, 33, 272, DateTimeKind.Unspecified).AddTicks(589), new TimeSpan(0, 5, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 2, new DateTimeOffset(new DateTime(2025, 1, 11, 15, 3, 33, 272, DateTimeKind.Unspecified).AddTicks(590), new TimeSpan(0, 5, 0, 0, 0)), 3 },
                    { 5, new DateTimeOffset(new DateTime(2025, 1, 11, 15, 3, 33, 272, DateTimeKind.Unspecified).AddTicks(591), new TimeSpan(0, 5, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 12, new DateTimeOffset(new DateTime(2025, 1, 11, 15, 3, 33, 272, DateTimeKind.Unspecified).AddTicks(592), new TimeSpan(0, 5, 0, 0, 0)), 3 }
                });

            migrationBuilder.InsertData(
                table: "OrderCompositions",
                columns: new[] { "Id", "Count", "CreatedAt", "OrderId", "ProductId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 1, new DateTimeOffset(new DateTime(2025, 1, 11, 15, 3, 33, 273, DateTimeKind.Unspecified).AddTicks(4509), new TimeSpan(0, 5, 0, 0, 0)), 1, 5, new DateTimeOffset(new DateTime(2025, 1, 11, 15, 3, 33, 273, DateTimeKind.Unspecified).AddTicks(4520), new TimeSpan(0, 5, 0, 0, 0)) },
                    { 2, 2, new DateTimeOffset(new DateTime(2025, 1, 11, 15, 3, 33, 273, DateTimeKind.Unspecified).AddTicks(4523), new TimeSpan(0, 5, 0, 0, 0)), 2, 5, new DateTimeOffset(new DateTime(2025, 1, 11, 15, 3, 33, 273, DateTimeKind.Unspecified).AddTicks(4524), new TimeSpan(0, 5, 0, 0, 0)) },
                    { 3, 3, new DateTimeOffset(new DateTime(2025, 1, 11, 15, 3, 33, 273, DateTimeKind.Unspecified).AddTicks(4526), new TimeSpan(0, 5, 0, 0, 0)), 3, 5, new DateTimeOffset(new DateTime(2025, 1, 11, 15, 3, 33, 273, DateTimeKind.Unspecified).AddTicks(4527), new TimeSpan(0, 5, 0, 0, 0)) },
                    { 4, 1, new DateTimeOffset(new DateTime(2025, 1, 11, 15, 3, 33, 273, DateTimeKind.Unspecified).AddTicks(4529), new TimeSpan(0, 5, 0, 0, 0)), 4, 5, new DateTimeOffset(new DateTime(2025, 1, 11, 15, 3, 33, 273, DateTimeKind.Unspecified).AddTicks(4530), new TimeSpan(0, 5, 0, 0, 0)) },
                    { 5, 4, new DateTimeOffset(new DateTime(2025, 1, 11, 15, 3, 33, 273, DateTimeKind.Unspecified).AddTicks(4531), new TimeSpan(0, 5, 0, 0, 0)), 5, 5, new DateTimeOffset(new DateTime(2025, 1, 11, 15, 3, 33, 273, DateTimeKind.Unspecified).AddTicks(4532), new TimeSpan(0, 5, 0, 0, 0)) },
                    { 6, 3, new DateTimeOffset(new DateTime(2025, 1, 11, 15, 3, 33, 273, DateTimeKind.Unspecified).AddTicks(4534), new TimeSpan(0, 5, 0, 0, 0)), 6, 5, new DateTimeOffset(new DateTime(2025, 1, 11, 15, 3, 33, 273, DateTimeKind.Unspecified).AddTicks(4535), new TimeSpan(0, 5, 0, 0, 0)) },
                    { 7, 2, new DateTimeOffset(new DateTime(2025, 1, 11, 15, 3, 33, 273, DateTimeKind.Unspecified).AddTicks(4536), new TimeSpan(0, 5, 0, 0, 0)), 7, 5, new DateTimeOffset(new DateTime(2025, 1, 11, 15, 3, 33, 273, DateTimeKind.Unspecified).AddTicks(4537), new TimeSpan(0, 5, 0, 0, 0)) },
                    { 8, 2, new DateTimeOffset(new DateTime(2025, 1, 11, 15, 3, 33, 273, DateTimeKind.Unspecified).AddTicks(4539), new TimeSpan(0, 5, 0, 0, 0)), 8, 5, new DateTimeOffset(new DateTime(2025, 1, 11, 15, 3, 33, 273, DateTimeKind.Unspecified).AddTicks(4540), new TimeSpan(0, 5, 0, 0, 0)) },
                    { 9, 3, new DateTimeOffset(new DateTime(2025, 1, 11, 15, 3, 33, 273, DateTimeKind.Unspecified).AddTicks(4541), new TimeSpan(0, 5, 0, 0, 0)), 9, 5, new DateTimeOffset(new DateTime(2025, 1, 11, 15, 3, 33, 273, DateTimeKind.Unspecified).AddTicks(4542), new TimeSpan(0, 5, 0, 0, 0)) },
                    { 10, 1, new DateTimeOffset(new DateTime(2025, 1, 11, 15, 3, 33, 273, DateTimeKind.Unspecified).AddTicks(4544), new TimeSpan(0, 5, 0, 0, 0)), 10, 5, new DateTimeOffset(new DateTime(2025, 1, 11, 15, 3, 33, 273, DateTimeKind.Unspecified).AddTicks(4545), new TimeSpan(0, 5, 0, 0, 0)) },
                    { 11, 5, new DateTimeOffset(new DateTime(2025, 1, 11, 15, 3, 33, 273, DateTimeKind.Unspecified).AddTicks(4546), new TimeSpan(0, 5, 0, 0, 0)), 11, 5, new DateTimeOffset(new DateTime(2025, 1, 11, 15, 3, 33, 273, DateTimeKind.Unspecified).AddTicks(4547), new TimeSpan(0, 5, 0, 0, 0)) },
                    { 12, 7, new DateTimeOffset(new DateTime(2025, 1, 11, 15, 3, 33, 273, DateTimeKind.Unspecified).AddTicks(4549), new TimeSpan(0, 5, 0, 0, 0)), 12, 5, new DateTimeOffset(new DateTime(2025, 1, 11, 15, 3, 33, 273, DateTimeKind.Unspecified).AddTicks(4550), new TimeSpan(0, 5, 0, 0, 0)) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Title",
                table: "Categories",
                column: "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Histories_ProductId",
                table: "Histories",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Histories_UserId",
                table: "Histories",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Manufacturers_Name",
                table: "Manufacturers",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderCompositions_OrderId",
                table: "OrderCompositions",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderCompositions_ProductId",
                table: "OrderCompositions",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Title",
                table: "Orders",
                column: "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ManufacturerId",
                table: "Products",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Name",
                table: "Products",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_HashPassword",
                table: "Users",
                column: "HashPassword",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Name",
                table: "Users",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Histories");

            migrationBuilder.DropTable(
                name: "OrderCompositions");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Manufacturers");
        }
    }
}
