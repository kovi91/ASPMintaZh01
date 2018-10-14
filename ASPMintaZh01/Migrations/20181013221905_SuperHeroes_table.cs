using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ASPMintaZh01.Migrations
{
    public partial class SuperHeroes_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SuperHeroes",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: false),
                    Power = table.Column<int>(nullable: false),
                    Speed = table.Column<int>(nullable: false),
                    Magic = table.Column<int>(nullable: false),
                    Side = table.Column<string>(nullable: false),
                    Image = table.Column<byte[]>(nullable: true),
                    ContentType = table.Column<string>(nullable: true),
                    Health = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuperHeroes", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SuperHeroes");
        }
    }
}
