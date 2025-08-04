using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HumanCapitalManagement.Migrations
{
    /// <inheritdoc />
    public partial class DbInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JobTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EncryptedIBAN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SalaryRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DateIssued = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalaryRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalaryRecords_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1", "f3a923c1-02e6-4931-b7b3-5238032f9155", "HR Admin", "HR ADMIN" },
                    { "2", "92e0c423-c842-496b-921b-2704ffc17550", "Manager", "MANAGER" },
                    { "3", "f0524a52-48d3-4ff3-b945-6dc5980f62e8", "Employee", "EMPLOYEE" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[,]
                {
                    { "0573bbba-a926-4845-a28d-b59dbee8e7a9", "9f6a9e43-a7a8-4e33-8379-464b1953f547", "johndoe23@personal.gmail", "JOHNDOE23@PERSONAL.GMAIL", "JOHNDOE23", "AQAAAAIAAYagAAAAEHCSNSJVggiXi4SOTlX63jJjxgiSSSq2ORwdoedGgmNxZM2JMRoVkyXTr6q1ZgD2RQ==", "bcfc07a3-a033-4176-8633-f9dec24b69bb", "JohnDoe23" },
                    { "0bc32a8f-fadb-4f16-85f6-acfb652c7762", "7fdec769-2d04-4e6c-83af-77bcb6e0bab8", "johndoe27@personal.gmail", "JOHNDOE27@PERSONAL.GMAIL", "JOHNDOE27", "AQAAAAIAAYagAAAAEFsN/1CoGrBObiViseFV7e6CYZpqe0MbEHAWRGHgG6Bicdaiv15c5UY+emjE5sjvbg==", "86fa7f06-f61c-45e2-bb02-ead0a599c4eb", "JohnDoe27" },
                    { "15620d8e-12da-41a7-80ee-6671ad4a0433", "57d15120-3e07-4457-9fed-b2ca09e78787", "johndoe15@personal.gmail", "JOHNDOE15@PERSONAL.GMAIL", "JOHNDOE15", "AQAAAAIAAYagAAAAEKs3kdzSqFXfsjDL9mUNxHR0Cd9I0RDSG/E94aZijG4Mm1EQMBohdxSvP8eMQars1Q==", "93af864a-9a9f-49c6-a28a-94e35c7755e4", "JohnDoe15" },
                    { "1fb73c13-9a3a-4ee8-ac12-3c45a235f491", "b5cd75c2-b81c-4a8d-9c72-f0edb4ef0114", "johndoe38@personal.gmail", "JOHNDOE38@PERSONAL.GMAIL", "JOHNDOE38", "AQAAAAIAAYagAAAAEC5ys070NIM+D2B7Hi2XuPVKHPtN7PrcBh/XV+4F4M4d0hpv1621j+XOi8vjt1QTOg==", "f3d91211-95bd-4206-b083-890d5bc551e6", "JohnDoe38" },
                    { "231bbd41-d41b-408a-82af-7f9c09aedadd", "b13a4219-8bd4-4f89-8c5d-49b7dc47d3b3", "johndoe4@personal.gmail", "JOHNDOE4@PERSONAL.GMAIL", "JOHNDOE4", "AQAAAAIAAYagAAAAEPR06EAbJ80MdMaNiuEAyZEyCowKoNA5l60p4fB06VNDg/eVuWaGNUHVO5ORyjCiQA==", "53258e01-cf7f-404e-99a1-50e9eedf1fe6", "JohnDoe4" },
                    { "2ade2183-5269-451d-9f68-1450770ee6e0", "78bf7962-7715-43d6-98ed-54f22b85be8a", "johndoe41@personal.gmail", "JOHNDOE41@PERSONAL.GMAIL", "JOHNDOE41", "AQAAAAIAAYagAAAAEKUO3AprbmokGsJ/Ik1a1ETbiDUc6lSjgIvPI98/vkid4SG3oRoW9pxnctw2PC0Bxg==", "cbdd5342-1874-4bdc-ad12-f60cd1c6acba", "JohnDoe41" },
                    { "2d4eb86b-684f-45e4-b4d7-c9716449878b", "9a30467e-ae72-48ca-b46d-9ee69316c91c", "johndoe14@personal.gmail", "JOHNDOE14@PERSONAL.GMAIL", "JOHNDOE14", "AQAAAAIAAYagAAAAEK7+cQ+eZQOHQIJvRv9c8hWVTXm1fKhF182cEjPpRG6P6bOy/j4hrcIBVs3kjJSMBA==", "dcd0c91b-dfd3-41c4-b680-febb393e149f", "JohnDoe14" },
                    { "2fb7807a-edaa-4cf2-b413-689279eff9e6", "b2460c60-e6ed-4012-aca8-8c7fb73c3cec", "johndoe32@personal.gmail", "JOHNDOE32@PERSONAL.GMAIL", "JOHNDOE32", "AQAAAAIAAYagAAAAEPBSQK7MJs4cO4nowSesBlKKLcl6gONyo8oWQsJIVeUk+NO45iGRD3yUr2qqO90sIA==", "34495a9c-c65b-40f9-b1fe-35a9dfc8c084", "JohnDoe32" },
                    { "38292939-4e0e-4d33-b8c9-aa99b6c033be", "3598ca6d-1b5d-44f2-98ec-3001163f986a", "johndoe7@personal.gmail", "JOHNDOE7@PERSONAL.GMAIL", "JOHNDOE7", "AQAAAAIAAYagAAAAEEYIwQBY5uISo0cPzelGHR5NwBFms6ScqW8tfpzvWOuKGiMsdux6QX+yFpeaioeNyQ==", "a888635c-2661-4cb1-85c2-5b3b4a7d6f9a", "JohnDoe7" },
                    { "3856ea67-c0ec-49f5-8562-b551b9f4b4b5", "e48ab97c-c66d-4b32-be47-51fe946c37f1", "johndoe36@personal.gmail", "JOHNDOE36@PERSONAL.GMAIL", "JOHNDOE36", "AQAAAAIAAYagAAAAEODMq2uXBc29n20yDXdHfxLZ/2kqPz3HjKTBivPZ5dxMipEkUYOy4/MyjM3DocP0qA==", "18115d65-35d8-4c93-b681-639154bb6b20", "JohnDoe36" },
                    { "385e6370-3ae5-465e-bd9d-d13902f11c83", "3493f3de-e7bf-4e43-96e6-db42c4a654f4", "johndoe6@personal.gmail", "JOHNDOE6@PERSONAL.GMAIL", "JOHNDOE6", "AQAAAAIAAYagAAAAEDnLYBkxjvjFo69Za8Lv/IKAnLUPJ9amK7MyYi8psPB8siCAKKR9sqjMWLRqlIw+SQ==", "1959f1a1-ba09-403c-b533-a7ff95fce2d4", "JohnDoe6" },
                    { "3bfd2e43-16ea-4d3e-a8cf-cc83bd9169cd", "5ef9e99f-45ed-417e-bac4-6b50d11c36ee", "johndoe19@personal.gmail", "JOHNDOE19@PERSONAL.GMAIL", "JOHNDOE19", "AQAAAAIAAYagAAAAENSdr+kLG7CHejytHr1guzj3I6OFgmuHXnPF8/hDdziulOMgO8koH3w+rGvXTPOISQ==", "fe2638d8-5dc7-42f1-a5bf-49a4a8b80254", "JohnDoe19" },
                    { "4849c0a0-5253-46dc-b38c-a80744f6a224", "df327ab9-df0e-4e88-b7a7-734097976ad1", "johndoe10@personal.gmail", "JOHNDOE10@PERSONAL.GMAIL", "JOHNDOE10", "AQAAAAIAAYagAAAAEJtKAVWHfflapqv+siVSAutvJi1SJIVU9ngqeg/6SYZWdogAthpLWMlovwAvmk2XUw==", "ea0554f5-4254-424d-a813-36119d2be49c", "JohnDoe10" },
                    { "48a9ec2b-37c5-4483-988f-28956c4c8bc7", "21878c8b-7d59-4741-a0cb-e05fa3a7d208", "johndoe24@personal.gmail", "JOHNDOE24@PERSONAL.GMAIL", "JOHNDOE24", "AQAAAAIAAYagAAAAEI2OaRStfjKKbrocDqKwXlBlv9r65Rf+HzDZJ8W9sUbjfUKbRXrUt4J0zLfglk1ZFg==", "bc640612-444d-4369-b5d0-e065dc360403", "JohnDoe24" },
                    { "543d1a57-fd27-4089-8f92-83016b397cde", "dda3ae5e-e061-4055-a07d-e9a1dc2d0f0c", "johndoe18@personal.gmail", "JOHNDOE18@PERSONAL.GMAIL", "JOHNDOE18", "AQAAAAIAAYagAAAAEPkYBVtCW/P+kETSSjo7hAZqMSE0hYiF9e6LYtRH/cOCAb1j3C5EWAEKb7trFD0Drw==", "ceef723d-8c4e-4d42-b6d0-fae6c876b30b", "JohnDoe18" },
                    { "56ced998-b75f-4d6e-bfd6-a681c2bb1bd9", "6071da45-9c18-4e73-9b08-03d262c34edb", "johndoe29@personal.gmail", "JOHNDOE29@PERSONAL.GMAIL", "JOHNDOE29", "AQAAAAIAAYagAAAAED907A+ylV22kW2S03w7VEs++NamOWcJ+TfAzh1Mi0U22pUPGbf8AwvAigahtlU2Iw==", "9b3565c4-d3b3-4781-9eae-8fe7d5e48002", "JohnDoe29" },
                    { "5784b99e-69e3-4f8d-9217-c3cd1b4f4145", "8c894027-cdee-4df7-88e5-5ce07a67ad8a", "johndoe22@personal.gmail", "JOHNDOE22@PERSONAL.GMAIL", "JOHNDOE22", "AQAAAAIAAYagAAAAEI1XcFpGU9LYuNSr1YMPTl+pGNxzInavFR6QmETe7RnKP4I9J7K5LNytY61BtS2uBw==", "a5a0c907-91b3-4df3-8634-c8f22c28eb30", "JohnDoe22" },
                    { "66c314f2-e23c-401d-abca-931b1a9172a5", "ea535300-bc7d-4aed-af78-0af53591e0f0", "johndoe35@personal.gmail", "JOHNDOE35@PERSONAL.GMAIL", "JOHNDOE35", "AQAAAAIAAYagAAAAEDF65tNITIeR+BIMfVkZnkdkD+/yY02m4Z4QSQdI3JKEpcUlbYoknnZSMOv2TeyNbQ==", "2ae1e6ba-0df3-4da2-97df-1b385a5b3d9d", "JohnDoe35" },
                    { "6a21b06b-55ea-42b4-a104-90089134e536", "4286a1b2-c10b-4dce-84b0-193ea1745727", "johndoe8@personal.gmail", "JOHNDOE8@PERSONAL.GMAIL", "JOHNDOE8", "AQAAAAIAAYagAAAAELcJr2qgcgxp720JoqHGCwjpYFsR2m6/wIvFUgalmBrNqB9ZbO5Bzwhi2qJBpJKRLg==", "bc776a81-2278-4ffd-a3b8-aa6d2fac8cf6", "JohnDoe8" },
                    { "6dd4a31c-08cb-4049-85fa-0c0d8e774b15", "f0198ca9-a2a7-4adc-9a79-803b1481ec7e", "johndoe31@personal.gmail", "JOHNDOE31@PERSONAL.GMAIL", "JOHNDOE31", "AQAAAAIAAYagAAAAEKreJSTD/YUyuPLJ2m28Zn43j5/gxO4J2LAPEg08oFqRIOwvWcFzJcjN2N4St1knKQ==", "27e4b9c7-8852-4bdf-b025-96828b65bad6", "JohnDoe31" },
                    { "711d97ad-25c9-40b8-b079-fc9e8ef748a2", "124c29bd-c7c1-4cb5-a691-1f447e888026", "johndoe11@personal.gmail", "JOHNDOE11@PERSONAL.GMAIL", "JOHNDOE11", "AQAAAAIAAYagAAAAEFmtpVMvjqUUO5IrBMEgxtSW05bglFVJw+rLDisDvoUHtfZYlT3osAiOL4mPqeSBbg==", "f29eaa94-b804-4873-8980-dbc24d5ca32f", "JohnDoe11" },
                    { "71b4e51e-f700-4c24-a9cc-65235cca927b", "638d0407-0b3c-48dc-af5a-45c3e4abbf0b", "johndoe44@personal.gmail", "JOHNDOE44@PERSONAL.GMAIL", "JOHNDOE44", "AQAAAAIAAYagAAAAECejzd7X1Wt0bkbC0O1sH3hEM0G4hJ6kmZt0kxucT5488Fe4aFtINu0qGZdC+gAEjQ==", "ae927f7a-f973-4899-8cda-b3dd3cddef9d", "JohnDoe44" },
                    { "7827929f-837c-4c79-9aa6-6a025f9309c8", "29b96cd1-b080-459d-bc1c-c3ecea54b486", "johndoe5@personal.gmail", "JOHNDOE5@PERSONAL.GMAIL", "JOHNDOE5", "AQAAAAIAAYagAAAAED95jy1zRYz+5xmO3pvl5RGHZH9BG7TmwBzpydi65QiBA53j7cazJCGEpd+DY64KTQ==", "56e57cf1-294c-4668-8556-ee5eef56bf2a", "JohnDoe5" },
                    { "7c7d1d58-5431-4628-95a4-65b25a10f771", "829cdaf7-010e-42ff-b50b-b7c0fe4dcca2", "johndoe9@personal.gmail", "JOHNDOE9@PERSONAL.GMAIL", "JOHNDOE9", "AQAAAAIAAYagAAAAEGFHc7wwzTcpXu3XWxxGfj8m5VyMoYKauqN0pctI7hV9nRL5lrKDU7gDwuxoP6N0XQ==", "dd9eb9ae-672e-4b89-9157-309f56c09eba", "JohnDoe9" },
                    { "7e567655-fbca-47b2-b50d-a090d51b7e6e", "aa7d8f7d-f882-47fc-a06c-dcef86570584", "johndoe34@personal.gmail", "JOHNDOE34@PERSONAL.GMAIL", "JOHNDOE34", "AQAAAAIAAYagAAAAEH5PUbMl3ePJKHPPhRkj8Ovy+imghqiZqyjMMpoNu3A9RIyDRJeMvdHX/SQEoHNYdA==", "9f562078-084c-4bc3-a7b1-534935232cac", "JohnDoe34" },
                    { "807ffea6-a378-4b09-90c3-cbc53690a228", "bcc8f8db-2b4c-430c-af42-5b07034211ce", "johndoe1@personal.gmail", "JOHNDOE1@PERSONAL.GMAIL", "JOHNDOE1", "AQAAAAIAAYagAAAAEPiCod0nY8YMD1me8IYwaFXhMbznd6ViK8kb/yEDiWh+G6l+z1EOgcX8F0bAwFT/UA==", "0db7654b-c8c1-489c-9795-34bc30256721", "JohnDoe1" },
                    { "8177d6ef-90c9-4690-b3e8-bc5971204277", "d8ed011e-00bf-4f8e-989e-5eaa359985a1", "johndoe13@personal.gmail", "JOHNDOE13@PERSONAL.GMAIL", "JOHNDOE13", "AQAAAAIAAYagAAAAEEWKCNLB2c1uYLaeV3wDhaJh/+9nWwxR19U9QYqi9/tb+EnFbHKGNNQAVvhnn3UOKA==", "97154a62-30ae-42c9-a9f1-5aa4cb1d2a7e", "JohnDoe13" },
                    { "843ccd29-f525-43cf-a621-94c32a04e3e2", "13ae5aeb-0202-4450-bc17-2da338e70712", "johndoe40@personal.gmail", "JOHNDOE40@PERSONAL.GMAIL", "JOHNDOE40", "AQAAAAIAAYagAAAAEPRwdg/EnCW3jeVCzubfZeHipTStV9arcuydEX0t+dMmQJTrcJ2MpLoVL0SApByhMA==", "ef76bc2f-a619-4412-8a9e-104177801f80", "JohnDoe40" },
                    { "870bc4c6-8719-4c65-9f1a-605762ec5f5c", "cf39c3ea-b3e7-40a5-b10e-3520365a321e", "johndoe26@personal.gmail", "JOHNDOE26@PERSONAL.GMAIL", "JOHNDOE26", "AQAAAAIAAYagAAAAEMN0i5ee/pDWg2Hf6IA7ETnYFNFxAWuRIZXjQe5I5eWMZFgeWIPgsBmdzMxjLUVF+A==", "5c8f4a12-d5c6-4067-b647-02cb82a339ad", "JohnDoe26" },
                    { "870fdb1b-aaa0-4df2-828b-c2b51af111e1", "8e7c316c-598d-4115-bc3b-b85824607594", "johndoe25@personal.gmail", "JOHNDOE25@PERSONAL.GMAIL", "JOHNDOE25", "AQAAAAIAAYagAAAAEACS4B2H63YvMkh1VNMfpMkziaLX2Uxq/x3mrkR47VT/XFxwMkmZIPLpA3xkuc6Ufw==", "7cac8d02-9c97-4dd5-87fb-a318b757243c", "JohnDoe25" },
                    { "885218c8-80f6-4906-8357-e231f6f5272f", "b679a567-ef50-4c3a-b119-85c37a63802e", "johndoe43@personal.gmail", "JOHNDOE43@PERSONAL.GMAIL", "JOHNDOE43", "AQAAAAIAAYagAAAAEC13RTjxzvFEf/4giNKwbIfhM/Li90uXtUe7kvmx9DLolo6kcrb4/gMZuSl+cnXMnA==", "56f7174d-ef8a-4d18-8b11-966aadc78843", "JohnDoe43" },
                    { "889d02b1-8a37-43f5-94b8-feb07a4489bc", "963ec5c3-c41f-4968-80bb-c7f0bbc11af9", "johndoe12@personal.gmail", "JOHNDOE12@PERSONAL.GMAIL", "JOHNDOE12", "AQAAAAIAAYagAAAAEFzYd7dA/NQgutZPQFNFw1PsFNHXUshudE2zGIqyv/As8CKA3Y8+FjFCToOpNKVJWA==", "5cdc2a50-7671-4a36-9b03-dade0504463b", "JohnDoe12" },
                    { "8ccba1c0-b8b3-4d13-abf7-ffaa356f9c28", "d277cbdb-4cfc-4d00-b8d7-bdfe69bdc071", "johndoe21@personal.gmail", "JOHNDOE21@PERSONAL.GMAIL", "JOHNDOE21", "AQAAAAIAAYagAAAAEF7wZ6WSsjy6q5SgCUWXQwju50TIuQAaaOhV2a1YrHfp6KPlRbdlbsPAoSUo03Osog==", "85d7171f-412f-4d33-bb01-1422b43255c2", "JohnDoe21" },
                    { "955f6510-121c-4da4-b3cc-be5a76ef0136", "b3b79e8f-2469-45bf-97b3-fd823269c9b8", "johndoe39@personal.gmail", "JOHNDOE39@PERSONAL.GMAIL", "JOHNDOE39", "AQAAAAIAAYagAAAAEJEWWsXWgy7j7DJ/jqfgSrmLlbSSo3goOEbJmJt3XKuyKAP5JaDrrnP4s1EbGgoMNg==", "539c706f-5c24-46ff-aae1-8eb3ac03f1cd", "JohnDoe39" },
                    { "97007bfd-66be-4585-9de1-3201e8ed912b", "64847704-cea1-478b-ad0f-28e86c988205", "johndoe49@personal.gmail", "JOHNDOE49@PERSONAL.GMAIL", "JOHNDOE49", "AQAAAAIAAYagAAAAEDihdeP/MFSDyxBGAWqvQK4fdVbDAWZq0TOY21X6jC3S0SydJu1koD2XS+8Lp3Ggmw==", "3821dd79-2579-42ca-8a69-0ef8549ad20a", "JohnDoe49" },
                    { "9fa4fd2a-2fe1-4e35-9060-0bb66c8d6c01", "fe8ef65f-2af7-44ce-90f6-a144b0f31894", "johndoe50@personal.gmail", "JOHNDOE50@PERSONAL.GMAIL", "JOHNDOE50", "AQAAAAIAAYagAAAAEFFOuGSumBdWUpYT/+VS1QnCl2/d9YlZ09ZjonpUG1CUJwvuhzUUCnyiXFOMmphBWA==", "6fea90f9-5832-4266-8003-79a391d2bb32", "JohnDoe50" },
                    { "b5bae1b5-4e8f-4fb4-a018-0fe283a46e59", "2b6d8b93-11b1-4cca-b65d-b1ed31f443b6", "johndoe47@personal.gmail", "JOHNDOE47@PERSONAL.GMAIL", "JOHNDOE47", "AQAAAAIAAYagAAAAEMZhEV8okkJRuq4gybGDhF/i1nkP05scPKgQ520zAv1yO47fnvXwFuAXNcTIv3L5gg==", "ce3679d5-cf2e-4d3c-abaa-4866f3e0de83", "JohnDoe47" },
                    { "bb0e0279-3a6c-4dab-86f6-f3d90cb2b3e4", "32962d5a-3a3e-46c9-90e4-ac8c9aadd1c4", "johndoe48@personal.gmail", "JOHNDOE48@PERSONAL.GMAIL", "JOHNDOE48", "AQAAAAIAAYagAAAAEFfghMXhEHnh+YmWFBcstiQcn6C7MdFwHluo7l5n5zF/LA/qyyzpNj9q/jeP7ED+nw==", "fe094606-04d9-46cf-a8b5-cbf0c25ca0d9", "JohnDoe48" },
                    { "d1348522-6107-4ed5-824b-f30a3709aa04", "32ff7d09-170b-44fe-a888-fe68b6776926", "johndoe45@personal.gmail", "JOHNDOE45@PERSONAL.GMAIL", "JOHNDOE45", "AQAAAAIAAYagAAAAEP2B3UJKmC35f5QLTwAme4K5otfJx4YktCZJ2x6TmU7THx7TE5qKwt5RRFq/BXug9w==", "166ff630-2c71-438d-999d-691f11591f89", "JohnDoe45" },
                    { "dee346c3-0e66-4762-b2f4-4c6cbb72f53f", "a8057408-a49b-4dcf-94f4-5c1f9fc8a082", "johndoe42@personal.gmail", "JOHNDOE42@PERSONAL.GMAIL", "JOHNDOE42", "AQAAAAIAAYagAAAAEP/4W240XUL1lN1QhiLPp02B6hnmBxxbsy1kQrl0qGLHuodyqfoD3QJSa70vY6GczQ==", "ae0561d9-668f-4a6a-97f3-1365d7a8b495", "JohnDoe42" },
                    { "e0a31994-45f5-4924-949b-4288b7a87f8d", "4d968c34-4750-45d5-bbe2-edc9c8d14e19", "johndoe46@personal.gmail", "JOHNDOE46@PERSONAL.GMAIL", "JOHNDOE46", "AQAAAAIAAYagAAAAEBwxY+714enMI8Ru6EyWvVrGtHlgJ0MMNJ6ZVJINuhNDBD4FEQb5zNOkiEjs3Kn3WA==", "e8570cc1-e449-4829-b59b-77b278e5cb4f", "JohnDoe46" },
                    { "e1569033-d81c-467c-b249-e8bb3e16100e", "cbc14b9b-2efd-4218-9f9f-b724a202f274", "johndoe2@personal.gmail", "JOHNDOE2@PERSONAL.GMAIL", "JOHNDOE2", "AQAAAAIAAYagAAAAEKLprRwDl98ONZv7nQT8OJx2E52rMVQ/6LqQX4YKrJB7rOTCev+vaxEH6ywX7+dFQQ==", "a9276a60-6f7c-4b82-bec7-aa7bd23d2596", "JohnDoe2" },
                    { "e5d87954-c9ce-496b-a84f-79dd729ea29e", "6cdb3d33-77e5-43c6-b6cb-236c68db3825", "johndoe20@personal.gmail", "JOHNDOE20@PERSONAL.GMAIL", "JOHNDOE20", "AQAAAAIAAYagAAAAEM+qBo8xvgcexbrUA46ZsRe0QqKp1VM7cLgSnrnrPWztTHcHHA9h1oAVkK8bzsHuVg==", "3d6f8e61-4b23-4b46-b9f7-43cdfaed4fc4", "JohnDoe20" },
                    { "e847fbe7-e9bd-4cae-9a1e-9e3c4577c6a6", "98c01e13-c450-4174-ab47-1883ba29de78", "johndoe37@personal.gmail", "JOHNDOE37@PERSONAL.GMAIL", "JOHNDOE37", "AQAAAAIAAYagAAAAEI1iV+PbdTFKGKmJNx7A5RxgVq7rxN52KCN3CY6C7ZjgwsbZjkden6yjAMrXOmrSOg==", "830e55a5-18ec-4a6d-a93e-f2032b591e98", "JohnDoe37" },
                    { "eff03be9-2eda-4304-948c-55fc3d65a457", "62741722-86da-4e2e-9eb3-f22922528408", "johndoe17@personal.gmail", "JOHNDOE17@PERSONAL.GMAIL", "JOHNDOE17", "AQAAAAIAAYagAAAAEJzbnzqphxm3GW3fct3Ze7nMynakYD4q2n0wI7cJkLBksveKQt99Hp6Grk1l4qVMkw==", "39a4a8d7-3821-482f-ad38-83829add921a", "JohnDoe17" },
                    { "f0a80dde-96fe-4611-9bee-44ca68cfba4c", "ca5da5d0-9c7c-4159-b0b1-f67d687b1cea", "johndoe3@personal.gmail", "JOHNDOE3@PERSONAL.GMAIL", "JOHNDOE3", "AQAAAAIAAYagAAAAEKoj1f2/WIDdae18R93lBByL5hEtfMzezz2+373xrmq4XLDvYN618pkxHzDGYHYc/w==", "00a57427-df0c-4773-b134-046a079f2468", "JohnDoe3" },
                    { "f20b371a-4a74-47b5-ac13-82faa4a003df", "284a1f51-63da-4567-9e96-8c5ed2515046", "johndoe30@personal.gmail", "JOHNDOE30@PERSONAL.GMAIL", "JOHNDOE30", "AQAAAAIAAYagAAAAEHayHX/rwvnUX3NL7bw/28Id0P1gDqSG0guv3zL0WcZY7E7/gJQteyRu+NoCHEDGIw==", "ca89c575-9e4a-4f32-83b1-2c6f5c884932", "JohnDoe30" },
                    { "f3f22722-2561-45a8-8602-99d3d7c08c4c", "4a94b657-0a0e-4492-b621-5d16fc4000c1", "johndoe28@personal.gmail", "JOHNDOE28@PERSONAL.GMAIL", "JOHNDOE28", "AQAAAAIAAYagAAAAEIGraplLmRi9RhqNBz0BQf7C3rIRx5Q6sKDUzWln3N83rJ8s9XRiE74Ql+EyXBUilg==", "c402b85a-d205-4190-9df5-e296c4e7ee3e", "JohnDoe28" },
                    { "f54d0684-3e25-4c67-9950-ad6cc073f815", "eab4a3a0-cbc7-4838-ab27-a7855d5efc30", "johndoe33@personal.gmail", "JOHNDOE33@PERSONAL.GMAIL", "JOHNDOE33", "AQAAAAIAAYagAAAAEIJyiLbflLMLS4/7z/KFm63dQhJOncBGFRiBndMxJ3glI+khE7eycYM84N+mI2YPVg==", "334ab9ea-a379-4a28-b080-2e1781529ff0", "JohnDoe33" },
                    { "fe76c706-6f52-49c4-820f-6d378710df2f", "2ae73e95-060f-4a5c-898b-fb32f86a4657", "johndoe16@personal.gmail", "JOHNDOE16@PERSONAL.GMAIL", "JOHNDOE16", "AQAAAAIAAYagAAAAEDRbk84HY4SRs3SGMykVT3RydTTZu4z4MqyXXaxF0UHSNRJZw8rfhmnaPC2OdPBakw==", "559e7ffb-4c1e-4b7b-8c63-a6e0f0b6fcfe", "JohnDoe16" }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Human Resources" },
                    { 2, "Finance" },
                    { 3, "IT" },
                    { 4, "Marketing" },
                    { 5, "Sales" },
                    { 6, "Operations" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "3", "0573bbba-a926-4845-a28d-b59dbee8e7a9" },
                    { "3", "0bc32a8f-fadb-4f16-85f6-acfb652c7762" },
                    { "3", "15620d8e-12da-41a7-80ee-6671ad4a0433" },
                    { "3", "1fb73c13-9a3a-4ee8-ac12-3c45a235f491" },
                    { "2", "231bbd41-d41b-408a-82af-7f9c09aedadd" },
                    { "3", "2ade2183-5269-451d-9f68-1450770ee6e0" },
                    { "3", "2d4eb86b-684f-45e4-b4d7-c9716449878b" },
                    { "3", "2fb7807a-edaa-4cf2-b413-689279eff9e6" },
                    { "3", "38292939-4e0e-4d33-b8c9-aa99b6c033be" },
                    { "1", "3856ea67-c0ec-49f5-8562-b551b9f4b4b5" },
                    { "1", "385e6370-3ae5-465e-bd9d-d13902f11c83" },
                    { "3", "3bfd2e43-16ea-4d3e-a8cf-cc83bd9169cd" },
                    { "3", "4849c0a0-5253-46dc-b38c-a80744f6a224" },
                    { "1", "48a9ec2b-37c5-4483-988f-28956c4c8bc7" },
                    { "1", "543d1a57-fd27-4089-8f92-83016b397cde" },
                    { "3", "56ced998-b75f-4d6e-bfd6-a681c2bb1bd9" },
                    { "3", "5784b99e-69e3-4f8d-9217-c3cd1b4f4145" },
                    { "3", "66c314f2-e23c-401d-abca-931b1a9172a5" },
                    { "3", "6a21b06b-55ea-42b4-a104-90089134e536" },
                    { "3", "6dd4a31c-08cb-4049-85fa-0c0d8e774b15" },
                    { "3", "711d97ad-25c9-40b8-b079-fc9e8ef748a2" },
                    { "3", "71b4e51e-f700-4c24-a9cc-65235cca927b" },
                    { "2", "7827929f-837c-4c79-9aa6-6a025f9309c8" },
                    { "3", "7c7d1d58-5431-4628-95a4-65b25a10f771" },
                    { "3", "7e567655-fbca-47b2-b50d-a090d51b7e6e" },
                    { "2", "807ffea6-a378-4b09-90c3-cbc53690a228" },
                    { "3", "8177d6ef-90c9-4690-b3e8-bc5971204277" },
                    { "3", "843ccd29-f525-43cf-a621-94c32a04e3e2" },
                    { "3", "870bc4c6-8719-4c65-9f1a-605762ec5f5c" },
                    { "3", "870fdb1b-aaa0-4df2-828b-c2b51af111e1" },
                    { "3", "885218c8-80f6-4906-8357-e231f6f5272f" },
                    { "1", "889d02b1-8a37-43f5-94b8-feb07a4489bc" },
                    { "3", "8ccba1c0-b8b3-4d13-abf7-ffaa356f9c28" },
                    { "3", "955f6510-121c-4da4-b3cc-be5a76ef0136" },
                    { "3", "97007bfd-66be-4585-9de1-3201e8ed912b" },
                    { "3", "9fa4fd2a-2fe1-4e35-9060-0bb66c8d6c01" },
                    { "3", "b5bae1b5-4e8f-4fb4-a018-0fe283a46e59" },
                    { "1", "bb0e0279-3a6c-4dab-86f6-f3d90cb2b3e4" },
                    { "3", "d1348522-6107-4ed5-824b-f30a3709aa04" },
                    { "1", "dee346c3-0e66-4762-b2f4-4c6cbb72f53f" },
                    { "3", "e0a31994-45f5-4924-949b-4288b7a87f8d" },
                    { "2", "e1569033-d81c-467c-b249-e8bb3e16100e" },
                    { "3", "e5d87954-c9ce-496b-a84f-79dd729ea29e" },
                    { "3", "e847fbe7-e9bd-4cae-9a1e-9e3c4577c6a6" },
                    { "3", "eff03be9-2eda-4304-948c-55fc3d65a457" },
                    { "2", "f0a80dde-96fe-4611-9bee-44ca68cfba4c" },
                    { "1", "f20b371a-4a74-47b5-ac13-82faa4a003df" },
                    { "3", "f3f22722-2561-45a8-8602-99d3d7c08c4c" },
                    { "3", "f54d0684-3e25-4c67-9950-ad6cc073f815" },
                    { "3", "fe76c706-6f52-49c4-820f-6d378710df2f" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "CompanyEmail", "Country", "DepartmentId", "EncryptedIBAN", "FirstName", "JobTitle", "LastName", "Salary", "UserId" },
                values: new object[,]
                {
                    { 1, "johndoe1@company.gmail", "France", 2, "RlI2NDMwMDA2MTIzNDU2Nzg5MDE4OQ==", "John", "Finance Manager", "Doe", 3012.0m, "807ffea6-a378-4b09-90c3-cbc53690a228" },
                    { 2, "johndoe2@company.gmail", "France", 3, "RlI1MTMwMDA2MTIzNDU2Nzg5MDE4OQ==", "John", "IT Manager", "Doe", 7389.0m, "e1569033-d81c-467c-b249-e8bb3e16100e" },
                    { 3, "johndoe3@company.gmail", "Britain", 4, "R0IxNk5XQks2MDE2MTMzMTkyNjgxOQ==", "John", "Marketing Manager", "Doe", 3055.5m, "f0a80dde-96fe-4611-9bee-44ca68cfba4c" },
                    { 4, "johndoe4@company.gmail", "Britain", 5, "R0IxMU5XQks2MDE2MTMzMTkyNjgxOQ==", "John", "Sales Manager", "Doe", 5010.0m, "231bbd41-d41b-408a-82af-7f9c09aedadd" },
                    { 5, "johndoe5@company.gmail", "Bulgaria", 6, "Qkc2OVVOQ1IxMjM0NTY3ODkw", "John", "Operations Manager", "Doe", 4198.5m, "7827929f-837c-4c79-9aa6-6a025f9309c8" },
                    { 6, "johndoe6@company.gmail", "Bulgaria", 1, "Qkc0M1VOQ1IxMjM0NTY3ODkw", "John", "HR Manager", "Doe", 2308.5m, "385e6370-3ae5-465e-bd9d-d13902f11c83" },
                    { 7, "johndoe7@company.gmail", "France", 2, "RlI2NzMwMDA2MTIzNDU2Nzg5MDE4OQ==", "John", "Auditor", "Doe", 2096m, "38292939-4e0e-4d33-b8c9-aa99b6c033be" },
                    { 8, "johndoe8@company.gmail", "Bulgaria", 3, "Qkc3OVVOQ1IxMjM0NTY3ODkw", "John", "System Admin", "Doe", 4674m, "6a21b06b-55ea-42b4-a104-90089134e536" },
                    { 9, "johndoe9@company.gmail", "Britain", 4, "R0I3M05XQks2MDE2MTMzMTkyNjgxOQ==", "John", "Marketing Specialist", "Doe", 2109m, "7c7d1d58-5431-4628-95a4-65b25a10f771" },
                    { 10, "johndoe10@company.gmail", "Britain", 5, "R0I2Nk5XQks2MDE2MTMzMTkyNjgxOQ==", "John", "Business Developer", "Doe", 2320m, "4849c0a0-5253-46dc-b38c-a80744f6a224" },
                    { 11, "johndoe11@company.gmail", "USA", 6, "VVMzOEJPRkE5ODc2NTQzMjEw", "John", "Supply Chain Analyst", "Doe", 2876m, "711d97ad-25c9-40b8-b079-fc9e8ef748a2" },
                    { 12, "johndoe12@company.gmail", "Britain", 1, "R0I2N05XQks2MDE2MTMzMTkyNjgxOQ==", "John", "Training Specialist", "Doe", 1702m, "889d02b1-8a37-43f5-94b8-feb07a4489bc" },
                    { 13, "johndoe13@company.gmail", "Britain", 2, "R0I5NE5XQks2MDE2MTMzMTkyNjgxOQ==", "John", "Auditor", "Doe", 2045m, "8177d6ef-90c9-4690-b3e8-bc5971204277" },
                    { 14, "johndoe14@company.gmail", "USA", 3, "VVM5MEJPRkE5ODc2NTQzMjEw", "John", "Network Engineer", "Doe", 4807m, "2d4eb86b-684f-45e4-b4d7-c9716449878b" },
                    { 15, "johndoe15@company.gmail", "USA", 4, "VVM2MEJPRkE5ODc2NTQzMjEw", "John", "SEO Analyst", "Doe", 2095m, "15620d8e-12da-41a7-80ee-6671ad4a0433" },
                    { 16, "johndoe16@company.gmail", "Germany", 5, "REU5NTM3MDQwMDQ0MDUzMjAxMzAwMA==", "John", "Sales Engineer", "Doe", 2396m, "fe76c706-6f52-49c4-820f-6d378710df2f" },
                    { 17, "johndoe17@company.gmail", "France", 6, "RlI4MTMwMDA2MTIzNDU2Nzg5MDE4OQ==", "John", "Supply Chain Analyst", "Doe", 2546m, "eff03be9-2eda-4304-948c-55fc3d65a457" },
                    { 18, "johndoe18@company.gmail", "Germany", 1, "REU1MTM3MDQwMDQ0MDUzMjAxMzAwMA==", "John", "Training Specialist", "Doe", 1708m, "543d1a57-fd27-4089-8f92-83016b397cde" },
                    { 19, "johndoe19@company.gmail", "Britain", 2, "R0I4Nk5XQks2MDE2MTMzMTkyNjgxOQ==", "John", "Auditor", "Doe", 2156m, "3bfd2e43-16ea-4d3e-a8cf-cc83bd9169cd" },
                    { 20, "johndoe20@company.gmail", "France", 3, "RlI0ODMwMDA2MTIzNDU2Nzg5MDE4OQ==", "John", "Database Admin", "Doe", 4925m, "e5d87954-c9ce-496b-a84f-79dd729ea29e" },
                    { 21, "johndoe21@company.gmail", "USA", 4, "VVM4MUJPRkE5ODc2NTQzMjEw", "John", "SEO Analyst", "Doe", 2066m, "8ccba1c0-b8b3-4d13-abf7-ffaa356f9c28" },
                    { 22, "johndoe22@company.gmail", "France", 5, "RlI4NDMwMDA2MTIzNDU2Nzg5MDE4OQ==", "John", "Business Developer", "Doe", 3746m, "5784b99e-69e3-4f8d-9217-c3cd1b4f4145" },
                    { 23, "johndoe23@company.gmail", "Britain", 6, "R0I5OE5XQks2MDE2MTMzMTkyNjgxOQ==", "John", "Logistics Coordinator", "Doe", 2604m, "0573bbba-a926-4845-a28d-b59dbee8e7a9" },
                    { 24, "johndoe24@company.gmail", "France", 1, "RlI4OTMwMDA2MTIzNDU2Nzg5MDE4OQ==", "John", "Recruiter", "Doe", 1678m, "48a9ec2b-37c5-4483-988f-28956c4c8bc7" },
                    { 25, "johndoe25@company.gmail", "Germany", 2, "REU3OTM3MDQwMDQ0MDUzMjAxMzAwMA==", "John", "Accountant", "Doe", 2085m, "870fdb1b-aaa0-4df2-828b-c2b51af111e1" },
                    { 26, "johndoe26@company.gmail", "Germany", 3, "REU0NjM3MDQwMDQ0MDUzMjAxMzAwMA==", "John", "Network Engineer", "Doe", 4017m, "870bc4c6-8719-4c65-9f1a-605762ec5f5c" },
                    { 27, "johndoe27@company.gmail", "Germany", 4, "REUxMzM3MDQwMDQ0MDUzMjAxMzAwMA==", "John", "Marketing Specialist", "Doe", 2144m, "0bc32a8f-fadb-4f16-85f6-acfb652c7762" },
                    { 28, "johndoe28@company.gmail", "Bulgaria", 5, "Qkc3MFVOQ1IxMjM0NTY3ODkw", "John", "Sales Representative", "Doe", 4330m, "f3f22722-2561-45a8-8602-99d3d7c08c4c" },
                    { 29, "johndoe29@company.gmail", "Britain", 6, "R0I2Mk5XQks2MDE2MTMzMTkyNjgxOQ==", "John", "Supply Chain Analyst", "Doe", 2721m, "56ced998-b75f-4d6e-bfd6-a681c2bb1bd9" },
                    { 30, "johndoe30@company.gmail", "Germany", 1, "REU1OTM3MDQwMDQ0MDUzMjAxMzAwMA==", "John", "Recruiter", "Doe", 1542m, "f20b371a-4a74-47b5-ac13-82faa4a003df" },
                    { 31, "johndoe31@company.gmail", "Bulgaria", 2, "QkcxOFVOQ1IxMjM0NTY3ODkw", "John", "Accountant", "Doe", 2048m, "6dd4a31c-08cb-4049-85fa-0c0d8e774b15" },
                    { 32, "johndoe32@company.gmail", "Bulgaria", 3, "Qkc1OVVOQ1IxMjM0NTY3ODkw", "John", "Network Engineer", "Doe", 4466m, "2fb7807a-edaa-4cf2-b413-689279eff9e6" },
                    { 33, "johndoe33@company.gmail", "Germany", 4, "REUxNjM3MDQwMDQ0MDUzMjAxMzAwMA==", "John", "Marketing Specialist", "Doe", 2061m, "f54d0684-3e25-4c67-9950-ad6cc073f815" },
                    { 34, "johndoe34@company.gmail", "France", 5, "RlI4NzMwMDA2MTIzNDU2Nzg5MDE4OQ==", "John", "Sales Representative", "Doe", 2633m, "7e567655-fbca-47b2-b50d-a090d51b7e6e" },
                    { 35, "johndoe35@company.gmail", "Bulgaria", 6, "Qkc5N1VOQ1IxMjM0NTY3ODkw", "John", "Supply Chain Analyst", "Doe", 2624m, "66c314f2-e23c-401d-abca-931b1a9172a5" },
                    { 36, "johndoe36@company.gmail", "Bulgaria", 1, "QkczM1VOQ1IxMjM0NTY3ODkw", "John", "Recruiter", "Doe", 1742m, "3856ea67-c0ec-49f5-8562-b551b9f4b4b5" },
                    { 37, "johndoe37@company.gmail", "Bulgaria", 2, "QkczM1VOQ1IxMjM0NTY3ODkw", "John", "Accountant", "Doe", 2011m, "e847fbe7-e9bd-4cae-9a1e-9e3c4577c6a6" },
                    { 38, "johndoe38@company.gmail", "USA", 3, "VVM0NUJPRkE5ODc2NTQzMjEw", "John", "Software Developer", "Doe", 4587m, "1fb73c13-9a3a-4ee8-ac12-3c45a235f491" },
                    { 39, "johndoe39@company.gmail", "France", 4, "RlI5NDMwMDA2MTIzNDU2Nzg5MDE4OQ==", "John", "SEO Analyst", "Doe", 2000m, "955f6510-121c-4da4-b3cc-be5a76ef0136" },
                    { 40, "johndoe40@company.gmail", "France", 5, "RlI3NTMwMDA2MTIzNDU2Nzg5MDE4OQ==", "John", "Sales Representative", "Doe", 4956m, "843ccd29-f525-43cf-a621-94c32a04e3e2" },
                    { 41, "johndoe41@company.gmail", "USA", 6, "VVM4MkJPRkE5ODc2NTQzMjEw", "John", "Facilities Manager", "Doe", 2993m, "2ade2183-5269-451d-9f68-1450770ee6e0" },
                    { 42, "johndoe42@company.gmail", "Bulgaria", 1, "Qkc2NlVOQ1IxMjM0NTY3ODkw", "John", "Training Specialist", "Doe", 1715m, "dee346c3-0e66-4762-b2f4-4c6cbb72f53f" },
                    { 43, "johndoe43@company.gmail", "Britain", 2, "R0I0N05XQks2MDE2MTMzMTkyNjgxOQ==", "John", "Auditor", "Doe", 2198m, "885218c8-80f6-4906-8357-e231f6f5272f" },
                    { 44, "johndoe44@company.gmail", "Britain", 3, "R0I0OE5XQks2MDE2MTMzMTkyNjgxOQ==", "John", "Network Engineer", "Doe", 4953m, "71b4e51e-f700-4c24-a9cc-65235cca927b" },
                    { 45, "johndoe45@company.gmail", "France", 4, "RlI3OTMwMDA2MTIzNDU2Nzg5MDE4OQ==", "John", "SEO Analyst", "Doe", 2024m, "d1348522-6107-4ed5-824b-f30a3709aa04" },
                    { 46, "johndoe46@company.gmail", "Britain", 5, "R0IxOE5XQks2MDE2MTMzMTkyNjgxOQ==", "John", "Business Developer", "Doe", 4183m, "e0a31994-45f5-4924-949b-4288b7a87f8d" },
                    { 47, "johndoe47@company.gmail", "Germany", 6, "REU0NjM3MDQwMDQ0MDUzMjAxMzAwMA==", "John", "Logistics Coordinator", "Doe", 2691m, "b5bae1b5-4e8f-4fb4-a018-0fe283a46e59" },
                    { 48, "johndoe48@company.gmail", "Bulgaria", 1, "Qkc0NVVOQ1IxMjM0NTY3ODkw", "John", "Compensation Analyst", "Doe", 1506m, "bb0e0279-3a6c-4dab-86f6-f3d90cb2b3e4" },
                    { 49, "johndoe49@company.gmail", "Britain", 2, "R0IxNk5XQks2MDE2MTMzMTkyNjgxOQ==", "John", "Auditor", "Doe", 2117m, "97007bfd-66be-4585-9de1-3201e8ed912b" },
                    { 50, "johndoe50@company.gmail", "Bulgaria", 3, "QkcxMlVOQ1IxMjM0NTY3ODkw", "John", "Database Admin", "Doe", 4553m, "9fa4fd2a-2fe1-4e35-9060-0bb66c8d6c01" }
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
                name: "IX_Employees_DepartmentId",
                table: "Employees",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_UserId",
                table: "Employees",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SalaryRecords_EmployeeId",
                table: "SalaryRecords",
                column: "EmployeeId");
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
                name: "SalaryRecords");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
