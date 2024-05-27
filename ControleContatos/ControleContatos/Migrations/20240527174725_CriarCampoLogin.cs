﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleContatos.Migrations
{
    /// <inheritdoc />
    public partial class CriarCampoLogin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Login",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Login",
                table: "Usuarios");
        }
    }
}
