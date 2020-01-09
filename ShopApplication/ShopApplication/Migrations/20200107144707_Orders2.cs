using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ShopApplication.Migrations
{
    public partial class Orders2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerProductID",
                table: "Product");

            migrationBuilder.AddColumn<int>(
                name: "CustomerProductID",
                table: "Customer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerProductID",
                table: "Customer");

            migrationBuilder.AddColumn<int>(
                name: "CustomerProductID",
                table: "Product",
                nullable: false,
                defaultValue: 0);
        }
    }
}
