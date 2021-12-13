using Microsoft.EntityFrameworkCore.Migrations;

namespace eDentalClinicWebAPI.Migrations
{
    public partial class NewMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "2G25bjqL8w3py03NpQ6A2BQQEbE=", "PPS8elLm6q8pows3GTbZWw==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "yBXghs+0/OvKUmg7P/4apOiBKuw=", "BUrGtv3Wz3ZKTl686Y5wuA==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 3,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "f2O9YOM0982Inb6m+F5GWE66ogQ=", "gimT8SWqEpo6YW67aLgpYA==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 4,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "fTrMfvbleeKQmwyc76Pgio8UYhM=", "ovZH2CB57lMEetXpuYr4Rw==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "I32Ng4MOSoFeP+6Vo4pMv3RKHh4=", "syw7gOU4src3zQFpc9Ge2Q==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "kjL+29DfxOnJQDhTbzlSEvM4y5c=", "LRjwl87QIql3uvh1RGSzZw==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 3,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "RCbMpj3tEcRlyG4yEiB3WLuyyTo=", "kSa57u2vz2lpm2ZEZQs9hQ==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 4,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "rFuJEP0izmmSUd1sanC1np6uH28=", "+QFI51mlnJwCX1H74EbwZA==" });
        }
    }
}
