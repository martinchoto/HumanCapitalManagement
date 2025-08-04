using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HumanCapitalManagement.Migrations
{
    /// <inheritdoc />
    public partial class newDb : Migration
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
                    { "1", "3349f823-1c6f-4abc-a21c-9cdc31f02117", "HR Admin", "HR ADMIN" },
                    { "2", "12015f7c-1ec1-41c0-9157-39ebd5971baa", "Manager", "MANAGER" },
                    { "3", "cf5569fe-7c04-47fe-8208-5416841f523b", "Employee", "EMPLOYEE" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[,]
                {
                    { "056a8e45-40e3-4665-ae80-a499e7ed4fd6", "bbbf0d28-3ed9-49eb-b36b-b552a8a83bad", "johndoe32@personal.gmail", "JOHNDOE32@PERSONAL.GMAIL", "JOHNDOE32", "AQAAAAIAAYagAAAAEHEm6a6ICUjLa0FOaDZQcKct14ei8tzpJiZAnLsI05xcCxAV4CcY2Mqse9ITo3h2lw==", "7806503e-eb14-4573-8ac6-6e92a69be0fe", "JohnDoe32" },
                    { "06ab1e2f-9194-447b-9847-70297d410585", "1edcdf3c-e58f-4769-8067-e832b592cb7a", "johndoe16@personal.gmail", "JOHNDOE16@PERSONAL.GMAIL", "JOHNDOE16", "AQAAAAIAAYagAAAAEM6zI5LnE0L7zYLmBL+CPSVAWa/e6CfA4KrKQ/NdVvq/8mMoYBYqmK1H0NdWVdBVKQ==", "f16d6df4-0b86-451a-a22a-2ed6815032a7", "JohnDoe16" },
                    { "0b2c6feb-b642-49f8-84ef-680d3ff2c344", "1f266754-9c4e-41d8-b6c4-1ff462ef71ab", "johndoe4@personal.gmail", "JOHNDOE4@PERSONAL.GMAIL", "JOHNDOE4", "AQAAAAIAAYagAAAAEB4197R7o4wvQF11B1c/SwXW4KpeT+SjWaY0yryf9OaABwBMldGEQgslrcIG1Fw8cA==", "b7599c58-1cae-4019-b115-8772a7c23989", "JohnDoe4" },
                    { "1023b4e0-446e-460b-8f95-aa88c57c26df", "fcb02027-aaaf-470b-88e5-ce996e8b164f", "johndoe22@personal.gmail", "JOHNDOE22@PERSONAL.GMAIL", "JOHNDOE22", "AQAAAAIAAYagAAAAEFegaNSeKWEl0yugpiw8E8qGOs6tA/2RlHqOLEUllA/MR64fRpL6/LUTZIi6JeAmJQ==", "58afc918-5ed9-43cf-b164-92feceb6cfca", "JohnDoe22" },
                    { "10d13800-c4cb-4125-a9de-2baf160b09fc", "d5ad9c5c-78c7-42ff-8e90-a20b558122fd", "johndoe46@personal.gmail", "JOHNDOE46@PERSONAL.GMAIL", "JOHNDOE46", "AQAAAAIAAYagAAAAEJ61ujdWk/nLuQ+6I22LoV1tlTp+wWymOSksGJGiYmP88qdysFQxQHIKoSXIT9a2Ng==", "eb4f1015-40bf-46d7-b200-e8f8ede0ec29", "JohnDoe46" },
                    { "10f6c8e2-b8ee-489b-a654-b3c96faec0e7", "c383ca9c-af76-4f7e-b266-85acda8e1b07", "johndoe48@personal.gmail", "JOHNDOE48@PERSONAL.GMAIL", "JOHNDOE48", "AQAAAAIAAYagAAAAEMrWFAaAOCyKbaywVYuzo579ipTPwd+HgWVlevffZ2SoutFXedFDELTQXloq+MCkLQ==", "9866083b-5e07-4d4a-8b0d-596a050e1599", "JohnDoe48" },
                    { "18eaacb8-e4be-4869-9551-7208c70b7824", "f374fccd-4571-4816-9018-d096ef16f917", "johndoe41@personal.gmail", "JOHNDOE41@PERSONAL.GMAIL", "JOHNDOE41", "AQAAAAIAAYagAAAAEADkisikfQ9I+AwbI3j7qCGpEYPzYQxAU3qIPybKUxA9SZsEyPnOyGQFnA3qE4zC8g==", "3be5c49b-1267-4d4d-8449-137661a4a626", "JohnDoe41" },
                    { "2a561aab-d12b-4391-9132-f7da67125396", "2771987f-1f18-4308-a5bf-e05dfbc90a69", "johndoe1@personal.gmail", "JOHNDOE1@PERSONAL.GMAIL", "JOHNDOE1", "AQAAAAIAAYagAAAAEP+k+gHYdDb+iPFpkt5azFsDpfmGvX/vK151e0ztvf7NAoL3bNY6SLRPvJovFoZhPg==", "755a5993-af47-4f85-961a-0303c2b4038f", "JohnDoe1" },
                    { "4b00f983-a2b3-4366-955b-85d1fa2ae6fb", "11971ecd-fde4-43ed-877d-3c050cd67483", "johndoe19@personal.gmail", "JOHNDOE19@PERSONAL.GMAIL", "JOHNDOE19", "AQAAAAIAAYagAAAAEHS4plJ3y7qxD8SZcZlE10pjP7zwLtbisVZ3T7DNJyj0koTQYkOsP4dDnZ2hbbsY8g==", "2aae78c9-e55b-477b-a42b-675948789147", "JohnDoe19" },
                    { "4bcc0e46-09c7-451d-b3d6-2f7d93ac12ae", "bae5881f-13d3-4a5c-bc79-1e0b82a688d2", "johndoe38@personal.gmail", "JOHNDOE38@PERSONAL.GMAIL", "JOHNDOE38", "AQAAAAIAAYagAAAAEKlLf7lry//fhPUecbUEHE9uoxvnoFsoJawPgX25Rf06qtGq+UJkBiiF64mgn7DJBA==", "45699bd1-67f9-4506-8423-855956d49bbf", "JohnDoe38" },
                    { "4eaa9c9e-8590-4534-960b-4c72ec5de01b", "60831237-0670-4696-a762-b2bd81d9224e", "johndoe11@personal.gmail", "JOHNDOE11@PERSONAL.GMAIL", "JOHNDOE11", "AQAAAAIAAYagAAAAENEfp2d4INy7FudNFhYQvkfX3Qzoe4wJ4S82cf/lQ9CmRkbXUA23Wuv61q4lozFwLw==", "f06b7d07-8968-4918-938a-b65ac826de25", "JohnDoe11" },
                    { "52404cf1-e1de-4159-a6c7-206d7eb1782a", "a98bbe52-3741-4c69-8c4f-7fd96eb695ba", "johndoe15@personal.gmail", "JOHNDOE15@PERSONAL.GMAIL", "JOHNDOE15", "AQAAAAIAAYagAAAAEHLuODXReu/xxFnrPEv7EBqOracfVUQU5PfVoJb2WOva7CVr5X/bA70SOU1LgvPV+g==", "c8e61b9e-266d-46fc-9dfd-5cdf01f490ed", "JohnDoe15" },
                    { "5328b4b2-c307-4932-8547-57857a70b30c", "a8c1ee24-1c93-40ca-888a-a27d7bdcbf58", "johndoe18@personal.gmail", "JOHNDOE18@PERSONAL.GMAIL", "JOHNDOE18", "AQAAAAIAAYagAAAAEIiFmpbrz68XTR3Lj2+QeaiYwRLOsjtqcyjiCSozCDA50tiEEIpEzTXwqjmxm8cWRQ==", "44338f50-9562-4462-a3e5-b23d1c9370ff", "JohnDoe18" },
                    { "5b2bc7e2-8f2c-43c5-9027-99b354272660", "31ea420d-64cd-4ed9-9028-c3c5e1200818", "johndoe13@personal.gmail", "JOHNDOE13@PERSONAL.GMAIL", "JOHNDOE13", "AQAAAAIAAYagAAAAEAcbdT1Rqtb+oyORu4ubnRLhMpRgwCgBFKcnvogRMhH+fVddooW+MvHzgLV9Z9/CRQ==", "739d364a-5481-42f7-afbe-703276b9d02f", "JohnDoe13" },
                    { "6096bf5f-c034-4c83-91d5-f911cbe361ea", "eb6f5b8b-595e-46bf-b9f7-dab6a5309a0e", "johndoe14@personal.gmail", "JOHNDOE14@PERSONAL.GMAIL", "JOHNDOE14", "AQAAAAIAAYagAAAAEJoZoQOqAF9JeHziiiICMgj+nCB3YV2HBnTBWQH5lD3QlsL9XimBkh+rYpOkKwaDow==", "37339ac0-1e71-4602-953b-bad2d522bc97", "JohnDoe14" },
                    { "661d2c59-4abf-4f5f-b743-98be0e5644a9", "80c2b5fe-c713-436b-8c51-fdc73b28f85c", "johndoe31@personal.gmail", "JOHNDOE31@PERSONAL.GMAIL", "JOHNDOE31", "AQAAAAIAAYagAAAAEBxtAjmyq/LwHxtf7/PWzcicxFB5lTwWopHMXxjTmbhdueUJBf0eEqol+YLvboA0VA==", "d5b1972f-5515-4397-a91e-5db9f27ce3e5", "JohnDoe31" },
                    { "6951b2ae-f6f4-4da5-9136-b25004c28f9c", "cc988eaf-c0f2-44fb-bdad-22218dce8429", "johndoe3@personal.gmail", "JOHNDOE3@PERSONAL.GMAIL", "JOHNDOE3", "AQAAAAIAAYagAAAAEJGcvtmE+t2W9irvShNKyB4oB++MVl33hmop07StGxewq7tmf4/jnOLYp/3XiE872g==", "210e184e-895a-431c-b694-59829a130a4d", "JohnDoe3" },
                    { "6d83b64c-4eea-4f37-83a9-7353d0e957d6", "3e740169-c4d5-41bb-9d37-51b5f7592e58", "johndoe40@personal.gmail", "JOHNDOE40@PERSONAL.GMAIL", "JOHNDOE40", "AQAAAAIAAYagAAAAEKzOYiwM01FMXyR8Cc4T5D50tf2iRwe2ofdV6RxaTHyEQNJYc5Bxx+b9W7flGfvx1A==", "1cc15fb5-64e6-445e-94c0-a73df9420fde", "JohnDoe40" },
                    { "702b60fd-a373-4099-8c5a-5f4bbd869668", "0a24bb27-d21e-45b1-bcac-e9dfd4ecba8c", "johndoe34@personal.gmail", "JOHNDOE34@PERSONAL.GMAIL", "JOHNDOE34", "AQAAAAIAAYagAAAAECRDPIrLqGwWUqiQgn4AXSFKXflzFlZSzenf8pulbqndXbXnbov6KauDkjB3GRg02w==", "6afd7a36-8a51-4d82-aae9-f1c6e5c089ed", "JohnDoe34" },
                    { "726d58c1-73fa-43fb-b3fb-48ec29b2ac5c", "d9684abf-1e50-482c-9a41-f75e93efe822", "johndoe5@personal.gmail", "JOHNDOE5@PERSONAL.GMAIL", "JOHNDOE5", "AQAAAAIAAYagAAAAEPaCSMzZo/lxHTp5Sr3hgybojTFktI5Ccn6ehg3n362SOEnhyuZO0NZa0WcagQ36VA==", "a56ae11d-07f8-4093-9099-35828ce115c5", "JohnDoe5" },
                    { "729717c6-1ddc-4c09-8117-a254c2d5c263", "f9522e3c-0be2-4ff7-85c1-fbc317e992a6", "johndoe44@personal.gmail", "JOHNDOE44@PERSONAL.GMAIL", "JOHNDOE44", "AQAAAAIAAYagAAAAEKnrZ3TJ1xjvjKxHfzDUyD1Tdhv4/IJcuCMOWmxkd5QL/FNNsIUTur9u08tIYvNuuQ==", "a77d9619-9e69-416d-81fb-5be2057a3842", "JohnDoe44" },
                    { "7b6b47ee-1bf8-4aae-90fc-4c1e268a1371", "fa91a275-5b13-47fc-bc2a-6be25d924808", "johndoe50@personal.gmail", "JOHNDOE50@PERSONAL.GMAIL", "JOHNDOE50", "AQAAAAIAAYagAAAAEP/tL4dXIMmNOajNBvtuWQ/ReDJeswfOvQigIPuL8mRdSwWnuQEC1Ugp9xyGyInzOg==", "63560f12-add6-4e9d-ab89-c4f67690e319", "JohnDoe50" },
                    { "7da74fd5-160f-4cd6-91b2-8628f4f47a83", "17f66d17-b8fa-49b1-9865-ab2b600c3aa4", "johndoe10@personal.gmail", "JOHNDOE10@PERSONAL.GMAIL", "JOHNDOE10", "AQAAAAIAAYagAAAAEB8lLRu95dWH3zRuyUgUYWJNqXOcIQi/ouQL5/KPVidgu/xaIXWjh4fEc7HimECe5Q==", "edf319de-412d-4078-974d-517b7a6418b4", "JohnDoe10" },
                    { "7dd20390-ce34-4e8a-9989-7861830cb12d", "7721debb-2a4d-4f0c-a47c-ab694827dfd8", "johndoe12@personal.gmail", "JOHNDOE12@PERSONAL.GMAIL", "JOHNDOE12", "AQAAAAIAAYagAAAAEM4RaF/ea6o5nNkVklQkSs1jR41AjTDHzGIVIhkBk3zN+rmjDXXaaCTq6eGm6kmlZQ==", "3e571394-622c-4207-a7aa-2deb97bdf33d", "JohnDoe12" },
                    { "8d51c159-6db7-466f-a48d-9dfecc31c543", "00d08295-d24a-4e7c-8f77-45238a181438", "johndoe28@personal.gmail", "JOHNDOE28@PERSONAL.GMAIL", "JOHNDOE28", "AQAAAAIAAYagAAAAEFtVmZ6WeknmmMUukNZWbN+WQ4dU42blMVofdmZ6RbNWcOyp61qZvx+6JiMJCE5yiQ==", "73edaea2-1666-4978-8c6c-fa82e3f766da", "JohnDoe28" },
                    { "8e0bcaef-52af-4021-b2f3-1f2770d38d52", "bbfd9792-6748-4ba9-8d0c-56a3ef0944c8", "johndoe8@personal.gmail", "JOHNDOE8@PERSONAL.GMAIL", "JOHNDOE8", "AQAAAAIAAYagAAAAEKFHGoq/OBkq+NSx/be4MD8OLZeFUHq7agzNL2qjvcSBuzbk1omjYBJUt9VhAaRTjg==", "4804527f-8faa-4c1e-8285-f3d729fad26f", "JohnDoe8" },
                    { "91325d43-de93-49d9-8e08-f48e142a446a", "57cc60d9-0342-4d00-a86d-ce119f0c8441", "johndoe37@personal.gmail", "JOHNDOE37@PERSONAL.GMAIL", "JOHNDOE37", "AQAAAAIAAYagAAAAEAUvzkWMmB5JlDxtr1KE6OvGwd0rcpHP5e2zaaOl+XgIm6gZR4VEgg09og048f7Evw==", "1e028e21-47fb-47a5-b03d-005dae0bc57b", "JohnDoe37" },
                    { "994946ef-8443-4db5-9369-fe1c871577d1", "8bb4b0c5-6f9c-41d5-b5ee-22d79b48ae89", "johndoe29@personal.gmail", "JOHNDOE29@PERSONAL.GMAIL", "JOHNDOE29", "AQAAAAIAAYagAAAAEH9rOIYSZfINj0/+a8ZFPFh0M87BtWFyidOA1I5sVLebyBUKXduBWoYoVGzLAOTSXQ==", "1c875598-7820-4900-9c4f-0bac50b3b54f", "JohnDoe29" },
                    { "9d094fdf-c338-4301-ace7-91d4ca9f7ad0", "be106c1c-fbcf-4b13-a774-1616790adeaa", "johndoe42@personal.gmail", "JOHNDOE42@PERSONAL.GMAIL", "JOHNDOE42", "AQAAAAIAAYagAAAAECtBw51baECmAea/E5xaZbv+tHHACpQ2apdd5Yqu4BVIkBLw5sskFx4IE81ao7EZ7w==", "eb72054a-1582-42d6-8591-fe50f8029fd7", "JohnDoe42" },
                    { "a416fab3-37c5-4771-8e73-e37363d4dc2f", "d7c0f3c9-f62d-483e-92e6-b157a5d9dc7f", "johndoe45@personal.gmail", "JOHNDOE45@PERSONAL.GMAIL", "JOHNDOE45", "AQAAAAIAAYagAAAAEPEjeXsXap0azG+s1hAE7/SeJm4cNUbt/+A48ZIjMtK1hIoGceD96/msvogec8EGhg==", "d7c1bb44-aba0-458b-b89a-cd678e0c9bcd", "JohnDoe45" },
                    { "a95df43d-3e6d-4291-989a-3aa48063e1ac", "cdb19742-0284-4dd1-9310-d31dc85b9fa1", "johndoe25@personal.gmail", "JOHNDOE25@PERSONAL.GMAIL", "JOHNDOE25", "AQAAAAIAAYagAAAAEBp+BxoDDcOwGzkZczdaMKtHehDlv6Rt6fIJ9K0toyigmQvp3adZ1j4BqnGDfXfYkA==", "b5b07cc4-ab92-4bc5-adc2-03b3fddc9801", "JohnDoe25" },
                    { "ab4fa6d6-d7b7-42da-a023-7b1a8e3d0b91", "14915e06-479e-4a41-ba20-faffcce264d8", "johndoe21@personal.gmail", "JOHNDOE21@PERSONAL.GMAIL", "JOHNDOE21", "AQAAAAIAAYagAAAAEBlW5WXneo46iAi83fcpQs8wWPgdT7c6iEYM37wtyMQPJVh0UcNd1Mf+HZOXviTNmQ==", "d85d546b-48d3-4f8b-84e7-2cb936ba36c2", "JohnDoe21" },
                    { "af77617b-e2b5-4e09-8d9e-85d222d82564", "da97d287-f090-4247-be7e-d42a0db98857", "johndoe33@personal.gmail", "JOHNDOE33@PERSONAL.GMAIL", "JOHNDOE33", "AQAAAAIAAYagAAAAEInYxHdzZOEvhM4hOFKGCjk4/Ad9YlgsculDW3HDscO5SRps8WTqM7ceX/vSArrQbA==", "00dd8066-4269-49bf-b09f-833b74ca3fd2", "JohnDoe33" },
                    { "b6ed985c-13ed-4916-8d38-b5a45cb6665c", "21184f8c-7125-44cd-88ac-c01d8058f3d7", "johndoe49@personal.gmail", "JOHNDOE49@PERSONAL.GMAIL", "JOHNDOE49", "AQAAAAIAAYagAAAAEKqy4/Hgg1Ga+a3j8qHpGdiQl0p4ZiWypOvQjzad/LPqbGBC02BRahy5ztH7ZxCX2w==", "71dd4c45-6bbf-489f-93d9-a4e3b885ef2a", "JohnDoe49" },
                    { "bbfed021-45ee-40a5-97b8-a2ac21c6d198", "c9dc8b7f-884e-4f48-b154-2eba3cdda742", "johndoe20@personal.gmail", "JOHNDOE20@PERSONAL.GMAIL", "JOHNDOE20", "AQAAAAIAAYagAAAAEIOgvc9zGxDCyBtYf4jhjxVDPmqfj4pfVHr3yadQLu3wfLt6rEV06p5Y2rjdDmWlUw==", "f7dbb8c3-9444-493d-968c-a2e95e8eba48", "JohnDoe20" },
                    { "bd265674-3975-4d45-b2f4-dab47fe760f9", "14071c6e-6b7d-4c74-b00b-1034919b15be", "johndoe24@personal.gmail", "JOHNDOE24@PERSONAL.GMAIL", "JOHNDOE24", "AQAAAAIAAYagAAAAECZSLcIgmu0y+fC46jjqWbXg0+cDrQooIC+gEWdx01dBOld/wk88ofRRSSaq3iGKPA==", "5842d493-32cf-4a16-bb13-35a407f7d2c4", "JohnDoe24" },
                    { "c04d52fb-9fe6-4782-80cc-1867821fce44", "eeec70c4-bdbb-467e-ba06-ed8cad3dfae5", "johndoe27@personal.gmail", "JOHNDOE27@PERSONAL.GMAIL", "JOHNDOE27", "AQAAAAIAAYagAAAAEGOfDdCpjgLo5kfwYcgWkixuCt8DqIwdeuIjf2hJRLEYCvToNrxbnRMTN/+8fO68QQ==", "1bcfbb8a-7bf9-4514-a7c2-654cf21c067e", "JohnDoe27" },
                    { "c16dbd99-0405-4ada-9298-1240a2f3c1b1", "36f416a4-9da9-4ff1-a881-9b36cfa4e109", "johndoe35@personal.gmail", "JOHNDOE35@PERSONAL.GMAIL", "JOHNDOE35", "AQAAAAIAAYagAAAAECBQcKDlwb+zgvGRpjCkAWyyqINy/fJ/yCcczI0Wc5hZpXSw6EmXGRFC4DvVZbJBsg==", "603e3d1f-105a-4f1d-8f62-d4653cc920ac", "JohnDoe35" },
                    { "c5c20525-4a8f-4a6f-bd5f-70cafc974b97", "b44c5178-c1fa-444e-9761-456aee1020fc", "johndoe9@personal.gmail", "JOHNDOE9@PERSONAL.GMAIL", "JOHNDOE9", "AQAAAAIAAYagAAAAEHJAt2/YhFskGPGnVYf1YEBlE8fCSJwWH7vDFzt36nAyo/eoWk+gwYlgPsIiTWhOLw==", "6a260fa4-83ac-4e1c-b527-24aa63241b27", "JohnDoe9" },
                    { "c5c8a4a8-5e08-4cb9-a1a8-edc657f42719", "d0055d20-129b-4557-84c8-e16cd12a67bc", "johndoe43@personal.gmail", "JOHNDOE43@PERSONAL.GMAIL", "JOHNDOE43", "AQAAAAIAAYagAAAAEMKWIGTWzFqp4MClp7dOQZ7WAbSonzL28A5FKH+DyAzKmIq1CrGPq2hbFHg/5Cb/zQ==", "c8466d17-bc44-4e3a-9280-f3c4f2fa3bd5", "JohnDoe43" },
                    { "d16589d3-e5e3-4c10-a858-c37d115d10ba", "ebd75135-4fe7-4c57-90d7-aac5f5a8249d", "johndoe17@personal.gmail", "JOHNDOE17@PERSONAL.GMAIL", "JOHNDOE17", "AQAAAAIAAYagAAAAEFVkDjQx/8NUDtLQdvrbQxo2xG7UN/j99cDKs+GadSQ/5gZEoXel/wvWfRaeB9YFqw==", "2159fa7b-40c6-44a8-940b-3e98835c576e", "JohnDoe17" },
                    { "d2e4957d-cef0-4062-a6c9-3f588f13f58f", "ac918798-6fad-4d4b-a2e9-25327d4d300b", "johndoe2@personal.gmail", "JOHNDOE2@PERSONAL.GMAIL", "JOHNDOE2", "AQAAAAIAAYagAAAAEJpHdlo01Hr7JwMOIQ8Oj3z4bBBKasgmSKt7/5ZmwZYcwAq7XU9eT9BqQBNE5HHbVg==", "7ab6bbf3-0768-430d-bac6-27c03b288a85", "JohnDoe2" },
                    { "d31ab548-c3ee-489e-b6f4-6794a39beefc", "d2a596c1-044d-45c4-ba72-0a848787f2c1", "johndoe39@personal.gmail", "JOHNDOE39@PERSONAL.GMAIL", "JOHNDOE39", "AQAAAAIAAYagAAAAEJ0XplvoRqq0ZYbvoxvnHHZXJoOTrXGVIpEJ4bl67d6vvhzsby53ti98Pg7jqUFcfA==", "25545d29-eeec-4a72-9a53-390d65a0b78b", "JohnDoe39" },
                    { "df694b56-2105-48bb-a29d-977166995cd4", "f53f0d32-61ab-4b8e-a288-8015a5575aec", "johndoe47@personal.gmail", "JOHNDOE47@PERSONAL.GMAIL", "JOHNDOE47", "AQAAAAIAAYagAAAAENBFfRB8T4zhBmNG4GkxrWiYrw7d2Zw8ooT/0Wi8zW2BMI05mh7WtHxNm4VioJPAYg==", "e465e6b1-5ed6-4802-b7a1-844c9f3a4a85", "JohnDoe47" },
                    { "e2a94c68-334a-4305-b96b-46693e124d1b", "a7e67950-1c95-4a32-b5fe-1211307c98f0", "johndoe7@personal.gmail", "JOHNDOE7@PERSONAL.GMAIL", "JOHNDOE7", "AQAAAAIAAYagAAAAELOdIV/MpydcozYco8xh+6AKzHn0MEmfAQCDVnfJfEgBP0S58kz/Zk1o+m+HrRYYsw==", "8f896a87-1ff9-420d-87ee-986681dd878d", "JohnDoe7" },
                    { "e871640c-a4bd-4299-b669-def9e01d4e67", "97f00eb3-571c-4566-9d38-22937245d58f", "johndoe23@personal.gmail", "JOHNDOE23@PERSONAL.GMAIL", "JOHNDOE23", "AQAAAAIAAYagAAAAEEO42MSEo8Tzh5y7Zm8dzKxKnR4wh7Ro4ZUr/5ARJDGAFZHtz7YzI2iu1wmqpnU5XQ==", "3f32edb6-9dc5-4dbe-b75a-352a58423348", "JohnDoe23" },
                    { "e96bcfb5-e8fe-43e3-8cce-7d34630d395d", "329842a2-810a-4876-8383-f1e8d1c8dba0", "johndoe36@personal.gmail", "JOHNDOE36@PERSONAL.GMAIL", "JOHNDOE36", "AQAAAAIAAYagAAAAEO2SXaGKuF0WpjtOZpmiqUXRUmQMoTySeKNM6y/kw30Byna9Kb05MJNm880WjmndFg==", "4769baf4-e368-493e-820b-55c29ce0b1bb", "JohnDoe36" },
                    { "f08881d5-7483-4eea-afc7-a1c402226c06", "9f702875-4e1e-4a55-8569-1ba533de3555", "johndoe26@personal.gmail", "JOHNDOE26@PERSONAL.GMAIL", "JOHNDOE26", "AQAAAAIAAYagAAAAENbHy+BK9BCE68pYrLEzPUe7hWptDrITDZEK7mkQwoppuZCYHFWPHFG5tyyl4vgpnw==", "d6f7230f-a63b-4ac2-b359-dbf187156a63", "JohnDoe26" },
                    { "f7afdc1e-c904-44e2-9224-43e4aecbc673", "ffc48d3a-988a-4907-a723-116283d37018", "johndoe6@personal.gmail", "JOHNDOE6@PERSONAL.GMAIL", "JOHNDOE6", "AQAAAAIAAYagAAAAEOzs+RDXXW7oHcpVrt2Gqno8sOUVZN0I6GClIJF+n6jjpnUGjaUTzVyM6lh4sX0NNw==", "05d926bd-66ea-47ff-892d-57c14c0c602f", "JohnDoe6" },
                    { "fc28eb59-dcf7-46bf-81ff-bd16ef7171d8", "16e1af7b-f8cc-45b0-9bcd-804538194340", "johndoe30@personal.gmail", "JOHNDOE30@PERSONAL.GMAIL", "JOHNDOE30", "AQAAAAIAAYagAAAAEASEryBPw2B2a9Yz3QPOK65Azew6WEl9SFjWNAK9ZuN75//Nv/jSc9utXdC93XlttA==", "48bcf21d-98e7-4f6f-8271-37dee33a10f7", "JohnDoe30" }
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
                    { "3", "056a8e45-40e3-4665-ae80-a499e7ed4fd6" },
                    { "3", "06ab1e2f-9194-447b-9847-70297d410585" },
                    { "2", "0b2c6feb-b642-49f8-84ef-680d3ff2c344" },
                    { "3", "1023b4e0-446e-460b-8f95-aa88c57c26df" },
                    { "3", "10d13800-c4cb-4125-a9de-2baf160b09fc" },
                    { "1", "10f6c8e2-b8ee-489b-a654-b3c96faec0e7" },
                    { "3", "18eaacb8-e4be-4869-9551-7208c70b7824" },
                    { "2", "2a561aab-d12b-4391-9132-f7da67125396" },
                    { "3", "4b00f983-a2b3-4366-955b-85d1fa2ae6fb" },
                    { "3", "4bcc0e46-09c7-451d-b3d6-2f7d93ac12ae" },
                    { "3", "4eaa9c9e-8590-4534-960b-4c72ec5de01b" },
                    { "3", "52404cf1-e1de-4159-a6c7-206d7eb1782a" },
                    { "1", "5328b4b2-c307-4932-8547-57857a70b30c" },
                    { "3", "5b2bc7e2-8f2c-43c5-9027-99b354272660" },
                    { "3", "6096bf5f-c034-4c83-91d5-f911cbe361ea" },
                    { "3", "661d2c59-4abf-4f5f-b743-98be0e5644a9" },
                    { "2", "6951b2ae-f6f4-4da5-9136-b25004c28f9c" },
                    { "3", "6d83b64c-4eea-4f37-83a9-7353d0e957d6" },
                    { "3", "702b60fd-a373-4099-8c5a-5f4bbd869668" },
                    { "2", "726d58c1-73fa-43fb-b3fb-48ec29b2ac5c" },
                    { "3", "729717c6-1ddc-4c09-8117-a254c2d5c263" },
                    { "3", "7b6b47ee-1bf8-4aae-90fc-4c1e268a1371" },
                    { "3", "7da74fd5-160f-4cd6-91b2-8628f4f47a83" },
                    { "1", "7dd20390-ce34-4e8a-9989-7861830cb12d" },
                    { "3", "8d51c159-6db7-466f-a48d-9dfecc31c543" },
                    { "3", "8e0bcaef-52af-4021-b2f3-1f2770d38d52" },
                    { "3", "91325d43-de93-49d9-8e08-f48e142a446a" },
                    { "3", "994946ef-8443-4db5-9369-fe1c871577d1" },
                    { "1", "9d094fdf-c338-4301-ace7-91d4ca9f7ad0" },
                    { "3", "a416fab3-37c5-4771-8e73-e37363d4dc2f" },
                    { "3", "a95df43d-3e6d-4291-989a-3aa48063e1ac" },
                    { "3", "ab4fa6d6-d7b7-42da-a023-7b1a8e3d0b91" },
                    { "3", "af77617b-e2b5-4e09-8d9e-85d222d82564" },
                    { "3", "b6ed985c-13ed-4916-8d38-b5a45cb6665c" },
                    { "3", "bbfed021-45ee-40a5-97b8-a2ac21c6d198" },
                    { "1", "bd265674-3975-4d45-b2f4-dab47fe760f9" },
                    { "3", "c04d52fb-9fe6-4782-80cc-1867821fce44" },
                    { "3", "c16dbd99-0405-4ada-9298-1240a2f3c1b1" },
                    { "3", "c5c20525-4a8f-4a6f-bd5f-70cafc974b97" },
                    { "3", "c5c8a4a8-5e08-4cb9-a1a8-edc657f42719" },
                    { "3", "d16589d3-e5e3-4c10-a858-c37d115d10ba" },
                    { "2", "d2e4957d-cef0-4062-a6c9-3f588f13f58f" },
                    { "3", "d31ab548-c3ee-489e-b6f4-6794a39beefc" },
                    { "3", "df694b56-2105-48bb-a29d-977166995cd4" },
                    { "3", "e2a94c68-334a-4305-b96b-46693e124d1b" },
                    { "3", "e871640c-a4bd-4299-b669-def9e01d4e67" },
                    { "1", "e96bcfb5-e8fe-43e3-8cce-7d34630d395d" },
                    { "3", "f08881d5-7483-4eea-afc7-a1c402226c06" },
                    { "1", "f7afdc1e-c904-44e2-9224-43e4aecbc673" },
                    { "1", "fc28eb59-dcf7-46bf-81ff-bd16ef7171d8" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "CompanyEmail", "Country", "DepartmentId", "EncryptedIBAN", "FirstName", "JobTitle", "LastName", "Salary", "UserId" },
                values: new object[,]
                {
                    { 1, "johndoe1@company.gmail", "USA", 2, "VVM5N0JPRkE5ODc2NTQzMjEw", "John", "Finance Manager", "Doe", 3036.0m, "2a561aab-d12b-4391-9132-f7da67125396" },
                    { 2, "johndoe2@company.gmail", "Bulgaria", 3, "Qkc2MlVOQ1IxMjM0NTY3ODkw", "John", "IT Manager", "Doe", 6015.0m, "d2e4957d-cef0-4062-a6c9-3f588f13f58f" },
                    { 3, "johndoe3@company.gmail", "Bulgaria", 4, "QkcxMFVOQ1IxMjM0NTY3ODkw", "John", "Marketing Manager", "Doe", 3144.0m, "6951b2ae-f6f4-4da5-9136-b25004c28f9c" },
                    { 4, "johndoe4@company.gmail", "USA", 5, "VVMyMUJPRkE5ODc2NTQzMjEw", "John", "Sales Manager", "Doe", 3022.5m, "0b2c6feb-b642-49f8-84ef-680d3ff2c344" },
                    { 5, "johndoe5@company.gmail", "Germany", 6, "REUzOTM3MDQwMDQ0MDUzMjAxMzAwMA==", "John", "Operations Manager", "Doe", 4309.5m, "726d58c1-73fa-43fb-b3fb-48ec29b2ac5c" },
                    { 6, "johndoe6@company.gmail", "UK", 1, "R0I3NU5XQks2MDE2MTMzMTkyNjgxOQ==", "John", "HR Manager", "Doe", 2610.0m, "f7afdc1e-c904-44e2-9224-43e4aecbc673" },
                    { 7, "johndoe7@company.gmail", "UK", 2, "R0IxMk5XQks2MDE2MTMzMTkyNjgxOQ==", "John", "Financial Analyst", "Doe", 2149m, "e2a94c68-334a-4305-b96b-46693e124d1b" },
                    { 8, "johndoe8@company.gmail", "UK", 3, "R0I0Nk5XQks2MDE2MTMzMTkyNjgxOQ==", "John", "Database Admin", "Doe", 4918m, "8e0bcaef-52af-4021-b2f3-1f2770d38d52" },
                    { 9, "johndoe9@company.gmail", "France", 4, "RlI4OTMwMDA2MTIzNDU2Nzg5MDE4OQ==", "John", "SEO Analyst", "Doe", 2095m, "c5c20525-4a8f-4a6f-bd5f-70cafc974b97" },
                    { 10, "johndoe10@company.gmail", "Bulgaria", 5, "Qkc3NlVOQ1IxMjM0NTY3ODkw", "John", "Business Developer", "Doe", 3292m, "7da74fd5-160f-4cd6-91b2-8628f4f47a83" },
                    { 11, "johndoe11@company.gmail", "Germany", 6, "REUzMzM3MDQwMDQ0MDUzMjAxMzAwMA==", "John", "Logistics Coordinator", "Doe", 2911m, "4eaa9c9e-8590-4534-960b-4c72ec5de01b" },
                    { 12, "johndoe12@company.gmail", "Bulgaria", 1, "Qkc2NFVOQ1IxMjM0NTY3ODkw", "John", "Recruiter", "Doe", 1507m, "7dd20390-ce34-4e8a-9989-7861830cb12d" },
                    { 13, "johndoe13@company.gmail", "France", 2, "RlIzNjMwMDA2MTIzNDU2Nzg5MDE4OQ==", "John", "Financial Analyst", "Doe", 2107m, "5b2bc7e2-8f2c-43c5-9027-99b354272660" },
                    { 14, "johndoe14@company.gmail", "Bulgaria", 3, "Qkc2NVVOQ1IxMjM0NTY3ODkw", "John", "Database Admin", "Doe", 4544m, "6096bf5f-c034-4c83-91d5-f911cbe361ea" },
                    { 15, "johndoe15@company.gmail", "USA", 4, "VVM1MUJPRkE5ODc2NTQzMjEw", "John", "Content Writer", "Doe", 2083m, "52404cf1-e1de-4159-a6c7-206d7eb1782a" },
                    { 16, "johndoe16@company.gmail", "USA", 5, "VVM1NUJPRkE5ODc2NTQzMjEw", "John", "Account Executive", "Doe", 2213m, "06ab1e2f-9194-447b-9847-70297d410585" },
                    { 17, "johndoe17@company.gmail", "Germany", 6, "REU1NzM3MDQwMDQ0MDUzMjAxMzAwMA==", "John", "Operations Specialist", "Doe", 2711m, "d16589d3-e5e3-4c10-a858-c37d115d10ba" },
                    { 18, "johndoe18@company.gmail", "Germany", 1, "REU0NTM3MDQwMDQ0MDUzMjAxMzAwMA==", "John", "Recruiter", "Doe", 1770m, "5328b4b2-c307-4932-8547-57857a70b30c" },
                    { 19, "johndoe19@company.gmail", "Germany", 2, "REU4MTM3MDQwMDQ0MDUzMjAxMzAwMA==", "John", "Tax Specialist", "Doe", 2159m, "4b00f983-a2b3-4366-955b-85d1fa2ae6fb" },
                    { 20, "johndoe20@company.gmail", "UK", 3, "R0IxOU5XQks2MDE2MTMzMTkyNjgxOQ==", "John", "Software Developer", "Doe", 4848m, "bbfed021-45ee-40a5-97b8-a2ac21c6d198" },
                    { 21, "johndoe21@company.gmail", "Bulgaria", 4, "QkcyMVVOQ1IxMjM0NTY3ODkw", "John", "SEO Analyst", "Doe", 2018m, "ab4fa6d6-d7b7-42da-a023-7b1a8e3d0b91" },
                    { 22, "johndoe22@company.gmail", "UK", 5, "R0IzMk5XQks2MDE2MTMzMTkyNjgxOQ==", "John", "Sales Engineer", "Doe", 2859m, "1023b4e0-446e-460b-8f95-aa88c57c26df" },
                    { 23, "johndoe23@company.gmail", "Germany", 6, "REU0NjM3MDQwMDQ0MDUzMjAxMzAwMA==", "John", "Operations Specialist", "Doe", 2622m, "e871640c-a4bd-4299-b669-def9e01d4e67" },
                    { 24, "johndoe24@company.gmail", "Bulgaria", 1, "Qkc4OVVOQ1IxMjM0NTY3ODkw", "John", "Training Specialist", "Doe", 1646m, "bd265674-3975-4d45-b2f4-dab47fe760f9" },
                    { 25, "johndoe25@company.gmail", "Bulgaria", 2, "Qkc3NFVOQ1IxMjM0NTY3ODkw", "John", "Tax Specialist", "Doe", 2095m, "a95df43d-3e6d-4291-989a-3aa48063e1ac" },
                    { 26, "johndoe26@company.gmail", "UK", 3, "R0IzOE5XQks2MDE2MTMzMTkyNjgxOQ==", "John", "Network Engineer", "Doe", 4348m, "f08881d5-7483-4eea-afc7-a1c402226c06" },
                    { 27, "johndoe27@company.gmail", "UK", 4, "R0I0OU5XQks2MDE2MTMzMTkyNjgxOQ==", "John", "SEO Analyst", "Doe", 2022m, "c04d52fb-9fe6-4782-80cc-1867821fce44" },
                    { 28, "johndoe28@company.gmail", "Germany", 5, "REU2MTM3MDQwMDQ0MDUzMjAxMzAwMA==", "John", "Account Executive", "Doe", 2032m, "8d51c159-6db7-466f-a48d-9dfecc31c543" },
                    { 29, "johndoe29@company.gmail", "France", 6, "RlI2NDMwMDA2MTIzNDU2Nzg5MDE4OQ==", "John", "Supply Chain Analyst", "Doe", 2626m, "994946ef-8443-4db5-9369-fe1c871577d1" },
                    { 30, "johndoe30@company.gmail", "France", 1, "RlIyNDMwMDA2MTIzNDU2Nzg5MDE4OQ==", "John", "Compensation Analyst", "Doe", 1713m, "fc28eb59-dcf7-46bf-81ff-bd16ef7171d8" },
                    { 31, "johndoe31@company.gmail", "USA", 2, "VVMxNkJPRkE5ODc2NTQzMjEw", "John", "Financial Analyst", "Doe", 2052m, "661d2c59-4abf-4f5f-b743-98be0e5644a9" },
                    { 32, "johndoe32@company.gmail", "Germany", 3, "REUzODM3MDQwMDQ0MDUzMjAxMzAwMA==", "John", "Software Developer", "Doe", 4226m, "056a8e45-40e3-4665-ae80-a499e7ed4fd6" },
                    { 33, "johndoe33@company.gmail", "UK", 4, "R0I2NU5XQks2MDE2MTMzMTkyNjgxOQ==", "John", "SEO Analyst", "Doe", 2167m, "af77617b-e2b5-4e09-8d9e-85d222d82564" },
                    { 34, "johndoe34@company.gmail", "UK", 5, "R0IyN05XQks2MDE2MTMzMTkyNjgxOQ==", "John", "Account Executive", "Doe", 4965m, "702b60fd-a373-4099-8c5a-5f4bbd869668" },
                    { 35, "johndoe35@company.gmail", "UK", 6, "R0I5OE5XQks2MDE2MTMzMTkyNjgxOQ==", "John", "Facilities Manager", "Doe", 2847m, "c16dbd99-0405-4ada-9298-1240a2f3c1b1" },
                    { 36, "johndoe36@company.gmail", "Germany", 1, "REU1ODM3MDQwMDQ0MDUzMjAxMzAwMA==", "John", "Recruiter", "Doe", 1536m, "e96bcfb5-e8fe-43e3-8cce-7d34630d395d" },
                    { 37, "johndoe37@company.gmail", "France", 2, "RlI3MDMwMDA2MTIzNDU2Nzg5MDE4OQ==", "John", "Auditor", "Doe", 2157m, "91325d43-de93-49d9-8e08-f48e142a446a" },
                    { 38, "johndoe38@company.gmail", "Germany", 3, "REU1NTM3MDQwMDQ0MDUzMjAxMzAwMA==", "John", "System Admin", "Doe", 4151m, "4bcc0e46-09c7-451d-b3d6-2f7d93ac12ae" },
                    { 39, "johndoe39@company.gmail", "France", 4, "RlIxMzMwMDA2MTIzNDU2Nzg5MDE4OQ==", "John", "Content Writer", "Doe", 2073m, "d31ab548-c3ee-489e-b6f4-6794a39beefc" },
                    { 40, "johndoe40@company.gmail", "UK", 5, "R0I4Nk5XQks2MDE2MTMzMTkyNjgxOQ==", "John", "Sales Engineer", "Doe", 3177m, "6d83b64c-4eea-4f37-83a9-7353d0e957d6" },
                    { 41, "johndoe41@company.gmail", "France", 6, "RlIyOTMwMDA2MTIzNDU2Nzg5MDE4OQ==", "John", "Logistics Coordinator", "Doe", 2688m, "18eaacb8-e4be-4869-9551-7208c70b7824" },
                    { 42, "johndoe42@company.gmail", "Germany", 1, "REU4NjM3MDQwMDQ0MDUzMjAxMzAwMA==", "John", "HR Generalist", "Doe", 1723m, "9d094fdf-c338-4301-ace7-91d4ca9f7ad0" },
                    { 43, "johndoe43@company.gmail", "France", 2, "RlI4MDMwMDA2MTIzNDU2Nzg5MDE4OQ==", "John", "Accountant", "Doe", 2192m, "c5c8a4a8-5e08-4cb9-a1a8-edc657f42719" },
                    { 44, "johndoe44@company.gmail", "UK", 3, "R0I1OE5XQks2MDE2MTMzMTkyNjgxOQ==", "John", "Database Admin", "Doe", 4668m, "729717c6-1ddc-4c09-8117-a254c2d5c263" },
                    { 45, "johndoe45@company.gmail", "UK", 4, "R0I4Mk5XQks2MDE2MTMzMTkyNjgxOQ==", "John", "Content Writer", "Doe", 2076m, "a416fab3-37c5-4771-8e73-e37363d4dc2f" },
                    { 46, "johndoe46@company.gmail", "UK", 5, "R0IyM05XQks2MDE2MTMzMTkyNjgxOQ==", "John", "Sales Engineer", "Doe", 2071m, "10d13800-c4cb-4125-a9de-2baf160b09fc" },
                    { 47, "johndoe47@company.gmail", "UK", 6, "R0IyNk5XQks2MDE2MTMzMTkyNjgxOQ==", "John", "Facilities Manager", "Doe", 2512m, "df694b56-2105-48bb-a29d-977166995cd4" },
                    { 48, "johndoe48@company.gmail", "Germany", 1, "REUyODM3MDQwMDQ0MDUzMjAxMzAwMA==", "John", "Compensation Analyst", "Doe", 1546m, "10f6c8e2-b8ee-489b-a654-b3c96faec0e7" },
                    { 49, "johndoe49@company.gmail", "UK", 2, "R0IzN05XQks2MDE2MTMzMTkyNjgxOQ==", "John", "Auditor", "Doe", 2075m, "b6ed985c-13ed-4916-8d38-b5a45cb6665c" },
                    { 50, "johndoe50@company.gmail", "UK", 3, "R0I0N05XQks2MDE2MTMzMTkyNjgxOQ==", "John", "Network Engineer", "Doe", 4675m, "7b6b47ee-1bf8-4aae-90fc-4c1e268a1371" }
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
