using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hornetsecurity.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitHornetsecurityDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HashesFile",
                columns: table => new
                {
                    Path = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Md5 = table.Column<string>(type: "TEXT", maxLength: 2000, nullable: false),
                    Sha1 = table.Column<string>(type: "TEXT", maxLength: 2000, nullable: false),
                    Sha256 = table.Column<string>(type: "TEXT", maxLength: 2000, nullable: false),
                    FileSize = table.Column<long>(type: "INTEGER", nullable: false),
                    Scanned = table.Column<int>(type: "INTEGER", nullable: false),
                    LastSeen = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HashesFile", x => x.Path);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HashesFile");
        }
    }
}
