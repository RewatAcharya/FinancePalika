using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinancePalika.Migrations
{
    /// <inheritdoc />
    public partial class sameer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "State",
                columns: table => new
                {
                    StateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StateName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StateName_Nep = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State", x => x.StateId);
                });

            migrationBuilder.CreateTable(
                name: "District",
                columns: table => new
                {
                    DistrictId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DistrictName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StateId = table.Column<int>(type: "int", nullable: true),
                    DistrictName_Nep = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_District", x => x.DistrictId);
                    table.ForeignKey(
                        name: "FK_District_State_StateId",
                        column: x => x.StateId,
                        principalTable: "State",
                        principalColumn: "StateId");
                });

            migrationBuilder.CreateTable(
                name: "SahakariSuchi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DartaNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DartaMiti = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameNepali = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FinanceType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PanNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MainTask = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkArea = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StateId = table.Column<int>(type: "int", nullable: true),
                    DistrictId = table.Column<int>(type: "int", nullable: true),
                    LocalLevel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WardNo = table.Column<int>(type: "int", nullable: false),
                    ToleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FaxNo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SahakariSuchi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SahakariSuchi_District_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "District",
                        principalColumn: "DistrictId");
                    table.ForeignKey(
                        name: "FK_SahakariSuchi_State_StateId",
                        column: x => x.StateId,
                        principalTable: "State",
                        principalColumn: "StateId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_District_StateId",
                table: "District",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_SahakariSuchi_DistrictId",
                table: "SahakariSuchi",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_SahakariSuchi_StateId",
                table: "SahakariSuchi",
                column: "StateId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SahakariSuchi");

            migrationBuilder.DropTable(
                name: "District");

            migrationBuilder.DropTable(
                name: "State");
        }
    }
}
