using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Lab2.Migrations
{
    /// <inheritdoc />
    public partial class addnewdatabas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "001",
                columns: new[] { "ConcurrencyStamp", "OTP", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b4a465a8-0b83-4b69-8d9c-8c3aa6728121", "initial", "AQAAAAIAAYagAAAAENJ+6nmE7d0UFC3Wo0Y0A7XpXMVviVOdp7J0/K2Q5MIY5S2WhlMv06J2UNMowxMMtQ==", "f0493b6e-8b01-461d-8044-0decfa7c25cc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "002",
                columns: new[] { "ConcurrencyStamp", "OTP", "PasswordHash", "RegionId", "SecurityStamp" },
                values: new object[] { "be27cb12-11ac-4974-b533-b5c424d36ccf", "initial", "AQAAAAIAAYagAAAAEKMInokm1jb5zv1KzjaGb5YpUl24dBTQf/m2uJtTdWkRu9ovIxW9ekwlaju7HFbPOw==", 2, "7f86170e-597a-4e81-a72f-1957ee47f3af" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Avatar", "ConcurrencyStamp", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "OTP", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RegionId", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "003", 0, null, "d81c56ab-c680-475f-84c8-59eb95030951", "anhkhoa123@gmail.com", true, false, false, null, "Anh Khoa 3", "ANHKHOA123@GMAIL.COM", "ANHKHOA123@GMAIL.COM", "initial", "AQAAAAIAAYagAAAAEKMInokm1jb5zv1KzjaGb5YpUl24dBTQf/m2uJtTdWkRu9ovIxW9ekwlaju7HFbPOw==", null, false, 3, "f9f48ec6-83c9-4143-9bfb-cc6a2f916937", false, "anhkhoa123@gmail.com" },
                    { "004", 0, null, "acb0511e-0b02-4ff8-bb16-a2d0d055d7ec", "user4@example.com", true, false, false, null, "Người dùng 4", "USER4@EXAMPLE.COM", "USER4@EXAMPLE.COM", "initial", "AQAAAAIAAYagAAAAEB1rFDMkr/6RaTLgs4Rc+a7OaKu1oPODEoVRlLg18YelqvBeXo7z3/5GJQCCdtl5Xg==", null, false, 1, "3f6ce5f6-57e9-4cec-9117-b8817dd1a548", false, "user4@example.com" },
                    { "005", 0, null, "576e22cc-609f-49c7-b61d-4e3b223f8f5e", "user5@example.com", true, false, false, null, "Người dùng 5", "USER5@EXAMPLE.COM", "USER5@EXAMPLE.COM", "initial", "AQAAAAIAAYagAAAAEB1rFDMkr/6RaTLgs4Rc+a7OaKu1oPODEoVRlLg18YelqvBeXo7z3/5GJQCCdtl5Xg==", null, false, 2, "72bc2ea9-da8c-48b4-804e-3cc4b93f0846", false, "user5@example.com" },
                    { "006", 0, null, "2f9cfe1d-c949-452e-9722-b3168417869c", "user6@example.com", true, false, false, null, "Người dùng 6", "USER6@EXAMPLE.COM", "USER6@EXAMPLE.COM", "initial", "AQAAAAIAAYagAAAAEB1rFDMkr/6RaTLgs4Rc+a7OaKu1oPODEoVRlLg18YelqvBeXo7z3/5GJQCCdtl5Xg==", null, false, 3, "06f90de8-ebd6-418c-85e9-2ed2db12ad84", false, "user6@example.com" },
                    { "007", 0, null, "339f4939-415f-4107-9b4b-b8bc7d432333", "user7@example.com", true, false, false, null, "Người dùng 7", "USER7@EXAMPLE.COM", "USER7@EXAMPLE.COM", "initial", "AQAAAAIAAYagAAAAEB1rFDMkr/6RaTLgs4Rc+a7OaKu1oPODEoVRlLg18YelqvBeXo7z3/5GJQCCdtl5Xg==", null, false, 1, "38682f07-fd73-4e02-8625-6975489aefb0", false, "user7@example.com" },
                    { "008", 0, null, "159da5f6-d3b1-4704-ab73-deebb13fc651", "user8@example.com", true, false, false, null, "Người dùng 8", "USER8@EXAMPLE.COM", "USER8@EXAMPLE.COM", "initial", "AQAAAAIAAYagAAAAEB1rFDMkr/6RaTLgs4Rc+a7OaKu1oPODEoVRlLg18YelqvBeXo7z3/5GJQCCdtl5Xg==", null, false, 2, "74a80770-8083-4540-a341-35e5316c9910", false, "user8@example.com" },
                    { "009", 0, null, "a7dd063f-6c9d-48fc-814b-e89897472ec4", "user9@example.com", true, false, false, null, "Người dùng 9", "USER9@EXAMPLE.COM", "USER9@EXAMPLE.COM", "initial", "AQAAAAIAAYagAAAAEB1rFDMkr/6RaTLgs4Rc+a7OaKu1oPODEoVRlLg18YelqvBeXo7z3/5GJQCCdtl5Xg==", null, false, 3, "25bffdcb-17ff-4f3a-bcd5-5065316772bd", false, "user9@example.com" },
                    { "010", 0, null, "cfcd55d3-a2ec-4e33-bada-0c682da1015c", "user10@example.com", true, false, false, null, "Người dùng 10", "USER10@EXAMPLE.COM", "USER10@EXAMPLE.COM", "initial", "AQAAAAIAAYagAAAAEB1rFDMkr/6RaTLgs4Rc+a7OaKu1oPODEoVRlLg18YelqvBeXo7z3/5GJQCCdtl5Xg==", null, false, 1, "5e3fcd4e-4588-46a9-b0e4-2a9e3c06f115", false, "user10@example.com" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "003");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "004");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "005");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "006");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "007");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "008");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "009");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "010");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "001",
                columns: new[] { "ConcurrencyStamp", "OTP", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fe289368-54df-4565-88e0-fdf83bb9b587", "1763633861none", "AQAAAAIAAYagAAAAECGwD7jb9nu9rr472/WI+vdZ7WHPQmPSPmk5ZBkQD2SL8jWg6O+HZemZFnI7K2dElw==", "a927777c-dcf9-4bf9-994b-8be4bf8d5baa" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "002",
                columns: new[] { "ConcurrencyStamp", "OTP", "PasswordHash", "RegionId", "SecurityStamp" },
                values: new object[] { "aba34af7-bcdd-4a9f-bccd-db8ed7a878ee", "1763633861none", "AQAAAAIAAYagAAAAEIr73GKZ2sgcPU79HiIqFgUw8r/Uj8aCo86nj8gZNJSMH0h8mZ80dfcAQ71nVvVqwg==", 3, "37f0b3c6-3737-4e89-8cc9-3bd1e4525a60" });
        }
    }
}
