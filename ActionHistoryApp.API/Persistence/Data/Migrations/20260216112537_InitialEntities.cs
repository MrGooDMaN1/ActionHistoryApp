using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ActionHistoryApp.API.Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DataBaseName = table.Column<string>(type: "TEXT", nullable: false),
                    WhoDid = table.Column<string>(type: "TEXT", nullable: false),
                    WhatDid = table.Column<string>(type: "TEXT", nullable: false),
                    WhenDid = table.Column<DateTime>(type: "TEXT", nullable: false)
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
