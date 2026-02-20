using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ActionHistoryApp.API.Migrations
{
    /// <inheritdoc />
    public partial class nitialreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataBaseName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WhoDid = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WhatDid = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WhenDid = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actions", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Actions");
        }
    }
}
