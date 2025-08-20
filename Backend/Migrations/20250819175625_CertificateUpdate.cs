using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class CertificateUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CertificateId",
                table: "Certificates",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Bestanden",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FileName = table.Column<string>(type: "text", nullable: false),
                    FileType = table.Column<string>(type: "text", nullable: false),
                    FileData = table.Column<byte[]>(type: "bytea", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bestanden", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Certificates_CertificateId",
                table: "Certificates",
                column: "CertificateId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Certificates_Bestanden_CertificateId",
                table: "Certificates",
                column: "CertificateId",
                principalTable: "Bestanden",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Certificates_Bestanden_CertificateId",
                table: "Certificates");

            migrationBuilder.DropTable(
                name: "Bestanden");

            migrationBuilder.DropIndex(
                name: "IX_Certificates_CertificateId",
                table: "Certificates");

            migrationBuilder.DropColumn(
                name: "CertificateId",
                table: "Certificates");
        }
    }
}
