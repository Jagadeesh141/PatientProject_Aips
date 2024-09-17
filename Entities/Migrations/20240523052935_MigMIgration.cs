using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Entities.Migrations
{
    /// <inheritdoc />
    public partial class MigMIgration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    PatientId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PatientName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    CountryID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PresentDoorNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PresentStreetName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PresentVillageTown = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PresentPostOffice = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PresentTaluk = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PresentState = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PresentDistrict = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PresentPincode = table.Column<long>(type: "bigint", maxLength: 100, nullable: true),
                    PermanentDoorNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PermanentStreetName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PermanentVillageTown = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PermanentPostOffice = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PermanentTaluk = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PermanentState = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PermanentDistrict = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PermanentPincode = table.Column<long>(type: "bigint", maxLength: 100, nullable: true),
                    Phone = table.Column<long>(type: "bigint", nullable: true),
                    GurdainOccupation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gurdain = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Detailedinfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Aadhar = table.Column<long>(type: "bigint", nullable: true),
                    Occupation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FatherName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MotherName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GuardianName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    GuardianPhoneNumber = table.Column<long>(type: "bigint", nullable: true),
                    Religion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaritalStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PermanentCountry = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.PatientId);
                    table.ForeignKey(
                        name: "FK_Patients_Countries_CountryID",
                        column: x => x.CountryID,
                        principalTable: "Countries",
                        principalColumn: "CountryID");
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryID", "CountryName" },
                values: new object[,]
                {
                    { new Guid("12e15727-d369-49a9-8b13-bc22e9362179"), "China" },
                    { new Guid("14629847-905a-4a0e-9abe-80b61655c5cb"), "Philippines" },
                    { new Guid("501c6d33-1bbe-45f1-8fbd-2275913c6218"), "India" },
                    { new Guid("56bf46a4-02b8-4693-a0f5-0a95e2218bdc"), "Thailand" },
                    { new Guid("8f30bedc-47dd-4286-8950-73d8a68e5d41"), "Palestinian Territory" }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "PatientId", "Aadhar", "CountryID", "DateOfBirth", "Detailedinfo", "Email", "FatherName", "Gender", "GuardianName", "GuardianPhoneNumber", "Gurdain", "GurdainOccupation", "MaritalStatus", "MotherName", "Occupation", "PatientName", "PermanentCountry", "PermanentDistrict", "PermanentDoorNo", "PermanentPincode", "PermanentPostOffice", "PermanentState", "PermanentStreetName", "PermanentTaluk", "PermanentVillageTown", "Phone", "PresentDistrict", "PresentDoorNo", "PresentPincode", "PresentPostOffice", "PresentState", "PresentStreetName", "PresentTaluk", "PresentVillageTown", "Religion", "Title" },
                values: new object[,]
                {
                    { "012107df-862f-4f16-ba94-e5c16886f005", null, null, new DateTime(1990, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "hmosco8@tripod.com", null, "Male", null, null, null, null, null, null, null, "Hansiain", null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null },
                    { "28d11936-9466-4a4b-b9c5-2f0a8e0cbde9", null, null, new DateTime(1990, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "mconachya@va.gov", null, "Female", null, null, null, null, null, null, null, "Minta", null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null },
                    { "29339209-63f5-492f-8459-754943c74abf", null, null, new DateTime(1983, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "mjarrell6@wisc.edu", null, "Male", null, null, null, null, null, null, null, "Maddy", null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null },
                    { "2a6d3738-9def-43ac-9279-0310edc7ceca", null, null, new DateTime(1988, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "mlingfoot5@netvibes.com", null, "Male", null, null, null, null, null, null, null, "Mitchael", null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null },
                    { "89e5f445-d89f-4e12-94e0-5ad5b235d704", null, null, new DateTime(1995, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "ttregona4@stumbleupon.com", null, "Others", null, null, null, null, null, null, null, "Tanthr", null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null },
                    { "a3b9833b-8a4d-43e9-8690-61e08df81a9a", null, null, new DateTime(1987, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "vklussb@nationalgeographic.com", null, "Female", null, null, null, null, null, null, null, "Verene", null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null },
                    { "ac660a73-b0b7-4340-abc1-a914257a6189", null, null, new DateTime(1998, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "pretchford7@virginia.edu", null, "Female", null, null, null, null, null, null, null, "Pegeen", null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null },
                    { "c03bbe45-9aeb-4d24-99e0-4743016ffce9", null, null, new DateTime(1989, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "mwebsdale0@people.com.cn", null, "Female", null, null, null, null, null, null, null, "Manu", null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null },
                    { "c3abddbd-cf50-41d2-b6c4-cc7d5a750928", null, null, new DateTime(1990, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "ushears1@globo.com", null, "Female", null, null, null, null, null, null, null, "Ursa", null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null },
                    { "c6d50a47-f7e6-4482-8be0-4ddfc057fa6e", null, null, new DateTime(1995, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "fbowsher2@howstuffworks.com", null, "Male", null, null, null, null, null, null, null, "Narayan", null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null },
                    { "cb035f22-e7cf-4907-bd07-91cfee5240f3", null, null, new DateTime(1997, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "lwoodwing9@wix.com", null, "Male", null, null, null, null, null, null, null, "Lombard", null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null },
                    { "d15c6d9f-70b4-48c5-afd3-e71261f1a9be", null, null, new DateTime(1987, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "asarvar3@dropbox.com", null, "Male", null, null, null, null, null, null, null, "Arya", null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_CountryID",
                table: "Patients",
                column: "CountryID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
