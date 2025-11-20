using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab2.Migrations
{
    /// <inheritdoc />
    public partial class _ : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "001",
                columns: new[] { "ConcurrencyStamp", "OTP", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fe289368-54df-4565-88e0-fdf83bb9b587", "1763633861none", "AQAAAAIAAYagAAAAECGwD7jb9nu9rr472/WI+vdZ7WHPQmPSPmk5ZBkQD2SL8jWg6O+HZemZFnI7K2dElw==", "a927777c-dcf9-4bf9-994b-8be4bf8d5baa" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Avatar", "ConcurrencyStamp", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "OTP", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RegionId", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "002", 0, null, "aba34af7-bcdd-4a9f-bccd-db8ed7a878ee", "hatakeiku450@gmail.com", true, false, false, null, "Anh Khoa 2", "HATAKEIKU450@GMAIL.COM", "HATAKEIKU450@GMAIL.COM", "1763633861none", "AQAAAAIAAYagAAAAEIr73GKZ2sgcPU79HiIqFgUw8r/Uj8aCo86nj8gZNJSMH0h8mZ80dfcAQ71nVvVqwg==", null, false, 3, "37f0b3c6-3737-4e89-8cc9-3bd1e4525a60", false, "hatakeiku450@gmail.com" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "002");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "001",
                columns: new[] { "ConcurrencyStamp", "OTP", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1479e9df-a3df-4aa7-808f-1417b13ad076", "1763633663none", "AQAAAAIAAYagAAAAEJouGjqvv2hq0fW/ynMpEDX33dB0jC8W9JWZt3Uqfdcgd/FxbEgJqmpZSAeMLZ4XGg==", "79c1f649-d7a9-4639-8701-00be32b0e32a" });
        }
    }
}
