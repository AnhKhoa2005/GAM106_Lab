using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab2.Migrations
{
    /// <inheritdoc />
    public partial class adduser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Avatar", "ConcurrencyStamp", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "OTP", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RegionId", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "001", 0, null, "1479e9df-a3df-4aa7-808f-1417b13ad076", "tdakhoa14012005@gmail.com", true, false, false, null, "Anh Khoa", "TDAKHOA14012005@GMAIL.COM", "TDAKHOA14012005@GMAIL.COM", "1763633663none", "AQAAAAIAAYagAAAAEJouGjqvv2hq0fW/ynMpEDX33dB0jC8W9JWZt3Uqfdcgd/FxbEgJqmpZSAeMLZ4XGg==", null, false, 1, "79c1f649-d7a9-4639-8701-00be32b0e32a", false, "tdakhoa14012005@gmail.com" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "001");
        }
    }
}
