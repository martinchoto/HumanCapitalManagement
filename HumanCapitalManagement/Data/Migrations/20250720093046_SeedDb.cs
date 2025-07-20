using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HumanManagementCapital.Migrations
{
    /// <inheritdoc />
    public partial class SeedDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccessFailedCount",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "EmailConfirmed",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LockoutEnabled",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LockoutEnd",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PhoneNumberConfirmed",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TwoFactorEnabled",
                table: "AspNetUsers");

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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1", "890dffd4-2c28-4cac-a353-833fb3d2be6a", "HR Admin", "HR ADMIN" },
                    { "2", "2c4a1f4c-8648-476f-b25a-4df76b7439c3", "Manager", "MANAGER" },
                    { "3", "d97f7cf0-9802-452f-9e9e-e2aa6db17e44", "Employee", "EMPLOYEE" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[,]
                {
                    { "01e39ff9-7d2c-4adc-af9a-1def1731f356", "851a4131-d314-42c2-b61a-650c22eceee7", "johndoe29@personal.gmail", "JOHNDOE29@PERSONAL.GMAIL", "JOHNDOE29", "AQAAAAIAAYagAAAAELvCwBQLodhq978IJkmTvDbvhubvnPMprSCnHQJ5RL+5MLeO8LFLea0Fp7wgb/VOnw==", "dda604e9-e615-4715-998f-46983efb21c9", "JohnDoe29" },
                    { "06b8a530-99ed-43e0-868d-e61bddb70fad", "4942aadd-42a6-4a6a-a6d2-2370e1c49c7e", "johndoe22@personal.gmail", "JOHNDOE22@PERSONAL.GMAIL", "JOHNDOE22", "AQAAAAIAAYagAAAAEKXcLPWDjvoNi1xu0GJ6t1OCiBSRZUAdJ83AtcYmu+SlKT5DYK1NeKcva34uoOpRBA==", "f9ab82b8-a19e-4fed-93e9-965ad4bb238e", "JohnDoe22" },
                    { "0c514623-a8dd-4596-a8bb-44aa2cedff5d", "ac7196b1-dee3-4fa0-9469-88ed1f442f9f", "johndoe36@personal.gmail", "JOHNDOE36@PERSONAL.GMAIL", "JOHNDOE36", "AQAAAAIAAYagAAAAEL1wJB3Ey6ZOsU0uQbeoBWEh4RQOoijuzaE87aTGzHlYn6upouLPHvMA8Oc50nSDVA==", "0e38cd33-b23f-416f-96b1-b4fa564e3538", "JohnDoe36" },
                    { "0dbd5552-6f1f-4d82-881c-f22d85c2789b", "0e2a5797-b293-40b2-93ca-5fd68fc9bd78", "johndoe19@personal.gmail", "JOHNDOE19@PERSONAL.GMAIL", "JOHNDOE19", "AQAAAAIAAYagAAAAELXWSwT+Brvcno0ZILx5rorDi88+kpq24f6gZlzwNOPHsIHQuAq6OYbSFrkuS0Hq8A==", "49b8e7f4-14ce-4d0a-8560-bd4fd0d220fd", "JohnDoe19" },
                    { "10744729-d70f-45dc-bfa9-6427490d32ce", "54f938b9-ce87-4871-b821-8af432942fa8", "johndoe50@personal.gmail", "JOHNDOE50@PERSONAL.GMAIL", "JOHNDOE50", "AQAAAAIAAYagAAAAECUd6wRxES3wmhWf4vrdpTJj1V9jEEeqAHqK7QWZIO94d8FcOqz51bT+Rbl0Q9/qlA==", "338fcc9c-27b6-4ddc-9f21-8ed0eccdb494", "JohnDoe50" },
                    { "1f8ce4af-5006-4286-a3a6-2afe3afcdfaf", "14cf51a4-2e50-4a20-bfbb-559ca9a4e596", "johndoe34@personal.gmail", "JOHNDOE34@PERSONAL.GMAIL", "JOHNDOE34", "AQAAAAIAAYagAAAAEMiX8laybEU2rNFSqXlEx64ffrUsWQ8bF/bZIusf51grL490lgS1CIf81fXd97eFYQ==", "d17737c9-88bf-46bf-b8b0-595251449141", "JohnDoe34" },
                    { "27b82b23-1b44-4109-b67e-436096e44aed", "0f69221b-b1f5-4a70-a345-786c4cd2e776", "johndoe35@personal.gmail", "JOHNDOE35@PERSONAL.GMAIL", "JOHNDOE35", "AQAAAAIAAYagAAAAEPkKEWEUP+kK9QCC2G6HtBbC8w+SYwNWe069c7jiLjdXc9rP9YG02jzNOerVDWshDA==", "ca043a9f-b4ff-42f5-a3ad-a6c538fe6f5d", "JohnDoe35" },
                    { "36848f24-c34a-4b47-a978-019a7edf5916", "df1a5af7-2ca4-4b8c-9eaa-af8be2b27d53", "johndoe32@personal.gmail", "JOHNDOE32@PERSONAL.GMAIL", "JOHNDOE32", "AQAAAAIAAYagAAAAEIb2ejkK3r8zC8GZXrMEldvEOX8Die25wPJbknlRliI48kQoQgMzwpCdqB9VhvAZOQ==", "bcf1acd7-f0fc-46c0-8b23-7b3db89e4fce", "JohnDoe32" },
                    { "3753947d-e359-443d-b5b9-e01636c8b306", "c1b92ab3-f8d8-473d-b177-3a46098a6154", "johndoe6@personal.gmail", "JOHNDOE6@PERSONAL.GMAIL", "JOHNDOE6", "AQAAAAIAAYagAAAAENuz7in1l0gD/9kgUNsCicMWd2hacD+/973lBRPjHmdjnK0J11MDrZQCg2iCn69XqQ==", "6289e6e9-e7d5-4cfa-9fa3-86fc951f90a0", "JohnDoe6" },
                    { "40e5148f-fa0b-4d0b-a998-d8ae7b46c2e8", "64ca0af7-cf20-4814-ba43-eb49457c3fdc", "johndoe10@personal.gmail", "JOHNDOE10@PERSONAL.GMAIL", "JOHNDOE10", "AQAAAAIAAYagAAAAEFbk1sUeR/KtmHsuEVB2cp1660Jes1Y3Yx42mNsxhaJgmz3QLUKm6vb99LKRirrAfw==", "bc2fec2c-cfa7-41c4-9b04-e133ee387cd6", "JohnDoe10" },
                    { "418ebbc6-a571-4b16-bddb-3e10c85a94a0", "f1487db4-f3a9-404e-8ee3-ca9a4a1f2b75", "johndoe4@personal.gmail", "JOHNDOE4@PERSONAL.GMAIL", "JOHNDOE4", "AQAAAAIAAYagAAAAEKNddsO/yA2c9nzRmR5x/oiOPFV06kVzkvEBRasS+YXFHW2PSsxEd8blsZeFojy5IA==", "5d6dbd7e-27ad-45be-91e8-bacf8bc7fe99", "JohnDoe4" },
                    { "47e0fcda-58c0-4590-964c-dae179f92932", "2934492c-fe63-4d44-9682-50d4c41a60ae", "johndoe16@personal.gmail", "JOHNDOE16@PERSONAL.GMAIL", "JOHNDOE16", "AQAAAAIAAYagAAAAEEWcESmpFREM+UUvY2dForFjK4Veezgv8mDGikJ2rNJVwHuLpd042giFRS9jvMhmvw==", "b01ccc60-41c6-4ccb-b98a-938f3f455349", "JohnDoe16" },
                    { "50ad756f-75a4-42ac-a9c2-287301f4b518", "3d555e45-c28e-43a1-a248-9f72b24b9a10", "johndoe49@personal.gmail", "JOHNDOE49@PERSONAL.GMAIL", "JOHNDOE49", "AQAAAAIAAYagAAAAEKOGxTmQ6f6yaCu4eOSt2X87Ccb+lQh9ayPqOF5+j7MPnHsRcW2kueGsJYDoW7h7jQ==", "73a2a3df-21c0-41cf-924b-2ee92c3d0cec", "JohnDoe49" },
                    { "5441893b-7bca-418d-870d-fbe7eb16bfe2", "20ae9c06-aab6-4a90-b0af-ab369fd4428b", "johndoe40@personal.gmail", "JOHNDOE40@PERSONAL.GMAIL", "JOHNDOE40", "AQAAAAIAAYagAAAAEMscc3nCiw3BmiDZidJZofmnvG4qXKOhxjR6xPkR6WNuNpKMeuTditHBwhw1OLfGvw==", "93d32b47-040d-4ec6-a9c8-25f2fa32e348", "JohnDoe40" },
                    { "5d6426fb-2a54-4baa-9ed2-507ae47c71f6", "a290e093-6082-41f4-97b9-4694f2c66743", "johndoe46@personal.gmail", "JOHNDOE46@PERSONAL.GMAIL", "JOHNDOE46", "AQAAAAIAAYagAAAAEFEGHHirIbLHxI5wi+fTsgXY6XhP0v3dqDJViOamKsl+ENsiwIfCDdv2Ra110jpoRg==", "0260bf12-4435-4bd0-a46c-0073e03bc88b", "JohnDoe46" },
                    { "5e469dbc-cb73-468d-96f6-08775e3b914f", "3c42e70a-6a20-49a1-a3ba-e27d86dd0ff2", "johndoe25@personal.gmail", "JOHNDOE25@PERSONAL.GMAIL", "JOHNDOE25", "AQAAAAIAAYagAAAAEBgadceVSe7OjP0e+dmOXVdVikDtLdclDtbirIOu/YTdISP0Rfog1UUvIed6o0Rx6g==", "9c5b6638-a9d0-4e2e-a608-36397c62b6d0", "JohnDoe25" },
                    { "5f86318f-6981-4378-b202-b0323193f477", "cf4f2793-8b5b-4d01-86c2-0b072fb5bb82", "johndoe41@personal.gmail", "JOHNDOE41@PERSONAL.GMAIL", "JOHNDOE41", "AQAAAAIAAYagAAAAEGZI6PCKA1/Mw8RChnuncHz1BMftl56bQ8CnU9+2ReX5TU8/WE5FDEAvD82jTEofbg==", "b9f142ee-1589-48a0-af0e-118bb75d5fa6", "JohnDoe41" },
                    { "67915455-ec4a-4f16-9de9-85f70f49a244", "2f12c9b8-a2d1-4234-b399-da43558a30d3", "johndoe45@personal.gmail", "JOHNDOE45@PERSONAL.GMAIL", "JOHNDOE45", "AQAAAAIAAYagAAAAEMeMgIaKLlyVao7Ul6wr7W4jUa1Bzd+2oN+h9P9+iDmwTRJCdN/LRJAfi+HYRnFwuA==", "196c81f9-24b4-4fb2-bf42-6b51af152cfe", "JohnDoe45" },
                    { "6f45e132-0852-4469-abfb-44a8310901ec", "c1d6c0b2-0421-4131-a575-f203db98a720", "johndoe31@personal.gmail", "JOHNDOE31@PERSONAL.GMAIL", "JOHNDOE31", "AQAAAAIAAYagAAAAEEaHe5JMwbODGN83tc6UMSTPcnZYhCwg7i5uQSdYhuBSuIJQGYhMbaTA9ge9hOGriw==", "1dee41b7-375d-4066-88a1-1ebec57da45b", "JohnDoe31" },
                    { "71370e19-12e7-427d-a2cc-02bec1b032a0", "2fc38194-4599-4ed6-8203-87823c1bb06f", "johndoe8@personal.gmail", "JOHNDOE8@PERSONAL.GMAIL", "JOHNDOE8", "AQAAAAIAAYagAAAAEJEnQIBi37xVYjzpF1Ms6ssMBTaCA7+JET9wyFkUNY5ZopGAbGSEWWZ+Lul2t/8Z5g==", "b2e6d832-e325-44a0-94ee-b497b8d009f1", "JohnDoe8" },
                    { "71873536-d293-4abe-b1a8-c3e3409e4419", "285dba5d-8e14-4bf8-9147-98c3edc42643", "johndoe30@personal.gmail", "JOHNDOE30@PERSONAL.GMAIL", "JOHNDOE30", "AQAAAAIAAYagAAAAEGjcVIXoE+Q7WbIhDQ9L5vUiIe06xNryoRNwwoo2zarFNT39uqfXbS9XI8k4tgReAQ==", "3d696bc5-c452-4be9-9e97-c199677f72c1", "JohnDoe30" },
                    { "76fff0d3-0dfb-44ed-92ff-5fa88274efb7", "dfed1792-081c-4040-b935-4dea83836a5a", "johndoe7@personal.gmail", "JOHNDOE7@PERSONAL.GMAIL", "JOHNDOE7", "AQAAAAIAAYagAAAAEDLB5XmYHlvu40Ok7p1h9Iak+1lD0YD/0Y/B4uG6mIK8VKXtHWmoYmSaMPN+fZa0DA==", "5806de1e-1e8f-45f8-9427-0df485066928", "JohnDoe7" },
                    { "789e8ba5-d2a7-474c-9388-709f8d555444", "a202ce54-2913-4733-a79a-4c67b484fdfd", "johndoe28@personal.gmail", "JOHNDOE28@PERSONAL.GMAIL", "JOHNDOE28", "AQAAAAIAAYagAAAAEPPIVZoQNjpnACcerk5gmAik3gtX4e2FkMQUixy0GaQtI4gfNxdCqs77NZ2beVBxBQ==", "6a8a5d09-9c80-4401-9c6f-5ba702caf3e0", "JohnDoe28" },
                    { "7b245aad-b578-4301-8087-1ea820e39562", "d348c3f8-9fa3-43dd-80d2-6f66298993f2", "johndoe1@personal.gmail", "JOHNDOE1@PERSONAL.GMAIL", "JOHNDOE1", "AQAAAAIAAYagAAAAEDV8AyvelMSZzrxkGrn8FE+wOo0e/ZqgWPJtAgsxtyYeZpfk3ChoRjDlnPif1xz5Bg==", "a56c8134-b438-46f4-9184-7267b72f99c0", "JohnDoe1" },
                    { "82678257-b20a-4ee8-8a8f-af9ab8d197d4", "cec74a10-f1fa-42c1-90a9-0d84e3f915d7", "johndoe9@personal.gmail", "JOHNDOE9@PERSONAL.GMAIL", "JOHNDOE9", "AQAAAAIAAYagAAAAEP0vq0jFh4BwXTweqAPV5aOpsCji0hplOdDNHcpyRTc+YsC17C7dM2q+UzR8TrGHKQ==", "eadf2e19-960f-4238-b88e-d81c305d2c5b", "JohnDoe9" },
                    { "82b00941-53b0-43e8-be9b-d499f99422df", "8a19af87-4954-4467-bd13-45d66a79cf87", "johndoe21@personal.gmail", "JOHNDOE21@PERSONAL.GMAIL", "JOHNDOE21", "AQAAAAIAAYagAAAAECjJs8iiZKFWQH7bgXg8XoF5DAImzDcl2/aeVL6WhdfZXkibLcZDdyA/EPfSpjraIg==", "faf59d58-605c-4aae-bc50-40197e49774a", "JohnDoe21" },
                    { "8b3b6a36-740b-4ff4-90a2-68f4d648268f", "51fb44b2-5831-41e3-8b93-5ea43b460b95", "johndoe24@personal.gmail", "JOHNDOE24@PERSONAL.GMAIL", "JOHNDOE24", "AQAAAAIAAYagAAAAENGEphxrA9r6Tg9EI2IKzg1l5+mFHGXK31mn+719wMalHn54Kdod5kDVGodLyYlaiQ==", "1be4a6c6-0f5c-4ebf-b887-e72ef7018474", "JohnDoe24" },
                    { "8c4e6128-4c38-4a55-a37b-7d6df6ce0450", "da67d075-1eb0-465c-93b0-4fb1c0f65d69", "johndoe14@personal.gmail", "JOHNDOE14@PERSONAL.GMAIL", "JOHNDOE14", "AQAAAAIAAYagAAAAECML+KgMPugQRVGd8isGOBPPcggMGcKFGTf64hW7v/GGaB1kMl8ZKayfQdTRaGa6Ig==", "ca89504f-b703-4013-aba3-da29071a3ceb", "JohnDoe14" },
                    { "914d74f3-e00f-4832-bbfc-a1a8fa197dd5", "074d885f-3cce-44f1-89bc-c28677d78a76", "johndoe23@personal.gmail", "JOHNDOE23@PERSONAL.GMAIL", "JOHNDOE23", "AQAAAAIAAYagAAAAEIAaIEmyduR0Taq6mXBwPazDGp7b6r6e29KxpzZXQ/pUwtwM/CSFvW5w3OyAGsS4Ng==", "d77ab191-0da9-4d53-979c-557142b1ecef", "JohnDoe23" },
                    { "924692db-40ba-4c40-bb30-9e2df2a31ba7", "90aabbd7-65b6-4a73-8a89-4cccf30b07ca", "johndoe13@personal.gmail", "JOHNDOE13@PERSONAL.GMAIL", "JOHNDOE13", "AQAAAAIAAYagAAAAEBRCFSfdw1F8NZ8Uuvbk430bEz7VR1JbrU+jnrHxlGy70RsjGbPXvjzrE7wYgklt6Q==", "4842466c-399c-4c28-9d3e-a659dd86c135", "JohnDoe13" },
                    { "a38c9770-bc32-4740-bcea-ee0f6881e0d8", "95b9faac-c894-4cb0-8e8f-ebdcc01a59c4", "johndoe43@personal.gmail", "JOHNDOE43@PERSONAL.GMAIL", "JOHNDOE43", "AQAAAAIAAYagAAAAEGwy3/xTRNAEhlyt3wmsPlZjEf8BqaDcEdA2p1DdJlDNqP2rzyg3fDoCM3FG/EUx8w==", "434fca36-4905-47ef-837a-b00414dbfee9", "JohnDoe43" },
                    { "a640a904-76b0-4b68-9c94-1e9881c14efb", "3233b51f-3c9a-43e2-a6b5-6bdd642bd5fd", "johndoe48@personal.gmail", "JOHNDOE48@PERSONAL.GMAIL", "JOHNDOE48", "AQAAAAIAAYagAAAAEHv9g55SUF/Utt8EqQABGEzkO0/EBUK+lBp3qi8/yrKFc7GToimY+3IJBw7uBY5k+w==", "9eb901e4-7f0c-4c15-8317-b93f35c0487f", "JohnDoe48" },
                    { "a7ac7ab2-ed5b-4bc4-9e3e-a1df13c1992f", "99633d99-a3b2-47e1-b986-cd2bff3f6f3a", "johndoe44@personal.gmail", "JOHNDOE44@PERSONAL.GMAIL", "JOHNDOE44", "AQAAAAIAAYagAAAAEAeoVgfZb7Ak9izQ4KDkMOIgOTzIIxk+ZW6kxPpL05oO9eWCw52+EwPrCh/l5kobyA==", "29d6b513-eb8e-4728-bfdb-be4279699a91", "JohnDoe44" },
                    { "b380b92c-3735-479f-9ac9-ff009e753037", "f70ba16b-cd4f-4a51-a634-382e8f4d8054", "johndoe39@personal.gmail", "JOHNDOE39@PERSONAL.GMAIL", "JOHNDOE39", "AQAAAAIAAYagAAAAEGO9sIsqKQmyJ6N04hL+VuraAOEXue0+WF5McVSrJZ0oAyTkr694RNNMFZxkdhjmrg==", "b3a541d7-9cfc-44f0-9b04-6ff0410f01f8", "JohnDoe39" },
                    { "bfc1e140-3bf5-4b88-83e4-c9c8818edd29", "cff48c20-ce77-4db9-bf3d-756ae9a422f9", "johndoe11@personal.gmail", "JOHNDOE11@PERSONAL.GMAIL", "JOHNDOE11", "AQAAAAIAAYagAAAAEOvgn/USPJbSzdk0lo6zE1iqRRfbECUsmadajp4Tpo7Db4olr5CLADoXscBlWFPTJg==", "80a374f2-2702-4f96-9de9-1c7530fbb47d", "JohnDoe11" },
                    { "ca3606ca-ab04-47dc-9004-18fb129fe813", "ba56a99d-3e81-4e66-af23-b5efdb2df671", "johndoe2@personal.gmail", "JOHNDOE2@PERSONAL.GMAIL", "JOHNDOE2", "AQAAAAIAAYagAAAAEDkwku6UFjq1fYpZ+PkJsE52/x0y2irCwYXP2irF0yNWpsLPaBnATJS+AoAkcBL9Rw==", "271793c6-cfc7-46e3-b41d-8a443c59bbf3", "JohnDoe2" },
                    { "ce329555-f617-4932-8612-35aa95ae7b73", "e924631a-58e7-4e59-81a8-377b078d58c8", "johndoe27@personal.gmail", "JOHNDOE27@PERSONAL.GMAIL", "JOHNDOE27", "AQAAAAIAAYagAAAAEPCGQ49cGJCQ2WgP+FOtps1JuDlw6YVGSXr6/SZQ2F5+gEkbaZAAjGjpydjuKovVBg==", "a476b6fb-4428-45d9-bea6-44042ddaa335", "JohnDoe27" },
                    { "d1062501-1fa7-432a-8580-4c338adcdab2", "28b264fc-0245-4902-a9a7-94e680908f9f", "johndoe42@personal.gmail", "JOHNDOE42@PERSONAL.GMAIL", "JOHNDOE42", "AQAAAAIAAYagAAAAECPtbqjb8HEVOy58qWd9K+Ogk0a8KkZj7GCvAb4p08vhLKZ/QdyHCk1Gt3G/RDQ1KA==", "8b914adb-fded-4ba7-9dcf-02cefbac7f19", "JohnDoe42" },
                    { "d28b7523-bf79-43a3-b00b-cfbcad195925", "a50c93db-9021-49e3-970d-acf682f319c1", "johndoe18@personal.gmail", "JOHNDOE18@PERSONAL.GMAIL", "JOHNDOE18", "AQAAAAIAAYagAAAAEEQy3LGvrwnn4ueJRcvzjgsUZItrEmYSLhPOYevEKXh3MhESxz8n1f3/Q+uBW/fHUQ==", "2287af12-f51e-4446-8087-264f5708d593", "JohnDoe18" },
                    { "d3bed2dd-fc8a-4d79-8c55-fa719ae3d50c", "22395dc9-ce67-4ea8-9e9b-099fcc9c3137", "johndoe33@personal.gmail", "JOHNDOE33@PERSONAL.GMAIL", "JOHNDOE33", "AQAAAAIAAYagAAAAEN1Stkit1UlCGhTkErihswg5+lifqddEmrepCUJxGDyj6sOUgxWbJF5Ecwh5rNF+4w==", "094c7c71-cb9f-4262-8927-0c8f9e6611c4", "JohnDoe33" },
                    { "d3c43796-5ef4-4ffe-937e-5ba4c5a8482b", "90232534-f5e6-4e69-ae6a-c2c0f9bbdaac", "johndoe38@personal.gmail", "JOHNDOE38@PERSONAL.GMAIL", "JOHNDOE38", "AQAAAAIAAYagAAAAEGofrNnc/M84cmCmdn0O1cKPMdY5iiccMSqCytLgIJquEQhuaHc5AF26noKdvlqgGw==", "bf03b34f-060d-44de-a7a9-e5196f5fe589", "JohnDoe38" },
                    { "d791bf20-7fce-4950-9355-f79812bd56fd", "efda7e28-b1cd-49fa-88da-aac78b85e077", "johndoe20@personal.gmail", "JOHNDOE20@PERSONAL.GMAIL", "JOHNDOE20", "AQAAAAIAAYagAAAAEHBYbUDvI9YPWfx43Ko1k5ccDikCRYKrwyNEaFbHXtNaH7TCvFGNVDFzDsHumPMPgg==", "25e57caa-9419-4cc3-8478-1f38354a2371", "JohnDoe20" },
                    { "da3962a7-8c95-47e3-9fba-460090c2205c", "f4cb687a-c2b0-42c3-9173-c4579d1a77fc", "johndoe5@personal.gmail", "JOHNDOE5@PERSONAL.GMAIL", "JOHNDOE5", "AQAAAAIAAYagAAAAEKKd9mIXTA7c4H2Ywfqs9lQk80CbsSDN1jzXX0i0nEgd0mBXh9VFxo/uqezQ0iQIQQ==", "77cf745f-dd45-4885-939c-52fc56646551", "JohnDoe5" },
                    { "ddad886a-0374-4216-8a0e-44b97d9415b6", "91b0a5f6-41a7-4bfd-8905-7227616fc954", "johndoe26@personal.gmail", "JOHNDOE26@PERSONAL.GMAIL", "JOHNDOE26", "AQAAAAIAAYagAAAAEFJ6Rr9zkcWsrBY1rWVw+21ixNqIsDejcKjLq7VkIf9GExIpjPjgSSbpZWb8DJcExg==", "e787522a-ccd1-4ace-a2d3-d41b29f9f627", "JohnDoe26" },
                    { "e32878cb-895b-4f7e-be8b-24bffbb0908b", "68498fec-a41d-4f93-bfe4-b140e1a104ce", "johndoe12@personal.gmail", "JOHNDOE12@PERSONAL.GMAIL", "JOHNDOE12", "AQAAAAIAAYagAAAAEJJwZTxkvNGkC5teFEXVSWj0J4aUBsE5W2FpZL97BecG2fNoGlWaBJS/x9Gt56m4Kg==", "37ce918f-98f5-41d0-838e-f13ebc0ea833", "JohnDoe12" },
                    { "e433d64a-67b7-41bf-a601-b0699aa8b919", "896a4d2e-4dc7-4b48-8d17-10c1ff7af30d", "johndoe37@personal.gmail", "JOHNDOE37@PERSONAL.GMAIL", "JOHNDOE37", "AQAAAAIAAYagAAAAEDz+ElnGRp7L0MJ/izzFtKZr9WP26qMWNFy5aJJY2r8GGcJGRSCbhpKL/DrPPzLaGw==", "ac8f1b73-6d7b-4e71-bbdf-172b8e07a3a2", "JohnDoe37" },
                    { "e56960b3-1ea4-49b2-91e4-e97b3d674370", "ff97c646-e938-48e4-a620-d9135a670683", "johndoe15@personal.gmail", "JOHNDOE15@PERSONAL.GMAIL", "JOHNDOE15", "AQAAAAIAAYagAAAAEGyNyF24IueFUwPG+R2sbar/K0P48aT9TueERBIKMwwxRZlCdUVP2i/E1bcqB123nw==", "30323bbe-515b-44e9-8b05-93f0b18977b2", "JohnDoe15" },
                    { "e76f1d06-a5be-4000-aa0e-53e0cbee6b13", "c573b1a3-39f2-41b9-8090-a8d5c5b3aa3a", "johndoe3@personal.gmail", "JOHNDOE3@PERSONAL.GMAIL", "JOHNDOE3", "AQAAAAIAAYagAAAAEEYs2ISDY1gRsOamzYXOqJ44n9icTO8JETJbwrUSpit7DGxEG1S4MdfdX0YMlDtYRQ==", "f8311b48-b779-44a4-a71f-15fe9958a91f", "JohnDoe3" },
                    { "f5e404c4-33c8-44e7-9334-49eb7fc18b2d", "51990a5a-4548-4234-851b-d378ff9de57e", "johndoe17@personal.gmail", "JOHNDOE17@PERSONAL.GMAIL", "JOHNDOE17", "AQAAAAIAAYagAAAAECtX5rVl4qq4876RPfNWhOC7PD9VsIp3AjzACbfZ63COKUP7BP0EwJQKPX5aKHDB6A==", "56bf3774-7cc8-491d-99b0-81d81844decc", "JohnDoe17" },
                    { "f69a9979-f663-4757-9892-7bea2980908c", "54057a41-099b-4304-8993-5ed1f681d2f7", "johndoe47@personal.gmail", "JOHNDOE47@PERSONAL.GMAIL", "JOHNDOE47", "AQAAAAIAAYagAAAAEGFN0ChK7Vnc1+CJDxYmAnjB6toNPOBKnH4caWzGAvXlp7IwvrV3qRVG6h42l5zDwg==", "a7d5bbe3-33ec-4472-8595-7206375e9465", "JohnDoe47" }
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
                    { "3", "01e39ff9-7d2c-4adc-af9a-1def1731f356" },
                    { "3", "06b8a530-99ed-43e0-868d-e61bddb70fad" },
                    { "1", "0c514623-a8dd-4596-a8bb-44aa2cedff5d" },
                    { "3", "0dbd5552-6f1f-4d82-881c-f22d85c2789b" },
                    { "3", "10744729-d70f-45dc-bfa9-6427490d32ce" },
                    { "3", "1f8ce4af-5006-4286-a3a6-2afe3afcdfaf" },
                    { "3", "27b82b23-1b44-4109-b67e-436096e44aed" },
                    { "3", "36848f24-c34a-4b47-a978-019a7edf5916" },
                    { "1", "3753947d-e359-443d-b5b9-e01636c8b306" },
                    { "3", "40e5148f-fa0b-4d0b-a998-d8ae7b46c2e8" },
                    { "2", "418ebbc6-a571-4b16-bddb-3e10c85a94a0" },
                    { "3", "47e0fcda-58c0-4590-964c-dae179f92932" },
                    { "3", "50ad756f-75a4-42ac-a9c2-287301f4b518" },
                    { "3", "5441893b-7bca-418d-870d-fbe7eb16bfe2" },
                    { "3", "5d6426fb-2a54-4baa-9ed2-507ae47c71f6" },
                    { "3", "5e469dbc-cb73-468d-96f6-08775e3b914f" },
                    { "3", "5f86318f-6981-4378-b202-b0323193f477" },
                    { "3", "67915455-ec4a-4f16-9de9-85f70f49a244" },
                    { "3", "6f45e132-0852-4469-abfb-44a8310901ec" },
                    { "3", "71370e19-12e7-427d-a2cc-02bec1b032a0" },
                    { "1", "71873536-d293-4abe-b1a8-c3e3409e4419" },
                    { "3", "76fff0d3-0dfb-44ed-92ff-5fa88274efb7" },
                    { "3", "789e8ba5-d2a7-474c-9388-709f8d555444" },
                    { "2", "7b245aad-b578-4301-8087-1ea820e39562" },
                    { "3", "82678257-b20a-4ee8-8a8f-af9ab8d197d4" },
                    { "3", "82b00941-53b0-43e8-be9b-d499f99422df" },
                    { "1", "8b3b6a36-740b-4ff4-90a2-68f4d648268f" },
                    { "3", "8c4e6128-4c38-4a55-a37b-7d6df6ce0450" },
                    { "3", "914d74f3-e00f-4832-bbfc-a1a8fa197dd5" },
                    { "3", "924692db-40ba-4c40-bb30-9e2df2a31ba7" },
                    { "3", "a38c9770-bc32-4740-bcea-ee0f6881e0d8" },
                    { "1", "a640a904-76b0-4b68-9c94-1e9881c14efb" },
                    { "3", "a7ac7ab2-ed5b-4bc4-9e3e-a1df13c1992f" },
                    { "3", "b380b92c-3735-479f-9ac9-ff009e753037" },
                    { "3", "bfc1e140-3bf5-4b88-83e4-c9c8818edd29" },
                    { "2", "ca3606ca-ab04-47dc-9004-18fb129fe813" },
                    { "3", "ce329555-f617-4932-8612-35aa95ae7b73" },
                    { "1", "d1062501-1fa7-432a-8580-4c338adcdab2" },
                    { "1", "d28b7523-bf79-43a3-b00b-cfbcad195925" },
                    { "3", "d3bed2dd-fc8a-4d79-8c55-fa719ae3d50c" },
                    { "3", "d3c43796-5ef4-4ffe-937e-5ba4c5a8482b" },
                    { "3", "d791bf20-7fce-4950-9355-f79812bd56fd" },
                    { "2", "da3962a7-8c95-47e3-9fba-460090c2205c" },
                    { "3", "ddad886a-0374-4216-8a0e-44b97d9415b6" },
                    { "1", "e32878cb-895b-4f7e-be8b-24bffbb0908b" },
                    { "3", "e433d64a-67b7-41bf-a601-b0699aa8b919" },
                    { "3", "e56960b3-1ea4-49b2-91e4-e97b3d674370" },
                    { "2", "e76f1d06-a5be-4000-aa0e-53e0cbee6b13" },
                    { "3", "f5e404c4-33c8-44e7-9334-49eb7fc18b2d" },
                    { "3", "f69a9979-f663-4757-9892-7bea2980908c" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "CompanyEmail", "DepartmentId", "FirstName", "JobTitle", "LastName", "Salary", "UserId" },
                values: new object[,]
                {
                    { 1, "johndoe1@company.gmail", 2, "John", "Finance Manager", "Doe", 3009.0m, "7b245aad-b578-4301-8087-1ea820e39562" },
                    { 2, "johndoe2@company.gmail", 3, "John", "IT Manager", "Doe", 6448.5m, "ca3606ca-ab04-47dc-9004-18fb129fe813" },
                    { 3, "johndoe3@company.gmail", 4, "John", "Marketing Manager", "Doe", 3019.5m, "e76f1d06-a5be-4000-aa0e-53e0cbee6b13" },
                    { 4, "johndoe4@company.gmail", 5, "John", "Sales Manager", "Doe", 5560.5m, "418ebbc6-a571-4b16-bddb-3e10c85a94a0" },
                    { 5, "johndoe5@company.gmail", 6, "John", "Operations Manager", "Doe", 4482.0m, "da3962a7-8c95-47e3-9fba-460090c2205c" },
                    { 6, "johndoe6@company.gmail", 1, "John", "HR Manager", "Doe", 2385.0m, "3753947d-e359-443d-b5b9-e01636c8b306" },
                    { 7, "johndoe7@company.gmail", 2, "John", "Auditor", "Doe", 2132m, "76fff0d3-0dfb-44ed-92ff-5fa88274efb7" },
                    { 8, "johndoe8@company.gmail", 3, "John", "System Admin", "Doe", 4372m, "71370e19-12e7-427d-a2cc-02bec1b032a0" },
                    { 9, "johndoe9@company.gmail", 4, "John", "Content Writer", "Doe", 2030m, "82678257-b20a-4ee8-8a8f-af9ab8d197d4" },
                    { 10, "johndoe10@company.gmail", 5, "John", "Account Executive", "Doe", 3266m, "40e5148f-fa0b-4d0b-a998-d8ae7b46c2e8" },
                    { 11, "johndoe11@company.gmail", 6, "John", "Logistics Coordinator", "Doe", 2952m, "bfc1e140-3bf5-4b88-83e4-c9c8818edd29" },
                    { 12, "johndoe12@company.gmail", 1, "John", "Recruiter", "Doe", 1634m, "e32878cb-895b-4f7e-be8b-24bffbb0908b" },
                    { 13, "johndoe13@company.gmail", 2, "John", "Accountant", "Doe", 2130m, "924692db-40ba-4c40-bb30-9e2df2a31ba7" },
                    { 14, "johndoe14@company.gmail", 3, "John", "Database Admin", "Doe", 4011m, "8c4e6128-4c38-4a55-a37b-7d6df6ce0450" },
                    { 15, "johndoe15@company.gmail", 4, "John", "SEO Analyst", "Doe", 2059m, "e56960b3-1ea4-49b2-91e4-e97b3d674370" },
                    { 16, "johndoe16@company.gmail", 5, "John", "Account Executive", "Doe", 3230m, "47e0fcda-58c0-4590-964c-dae179f92932" },
                    { 17, "johndoe17@company.gmail", 6, "John", "Supply Chain Analyst", "Doe", 2557m, "f5e404c4-33c8-44e7-9334-49eb7fc18b2d" },
                    { 18, "johndoe18@company.gmail", 1, "John", "Compensation Analyst", "Doe", 1514m, "d28b7523-bf79-43a3-b00b-cfbcad195925" },
                    { 19, "johndoe19@company.gmail", 2, "John", "Financial Analyst", "Doe", 2169m, "0dbd5552-6f1f-4d82-881c-f22d85c2789b" },
                    { 20, "johndoe20@company.gmail", 3, "John", "Network Engineer", "Doe", 4993m, "d791bf20-7fce-4950-9355-f79812bd56fd" },
                    { 21, "johndoe21@company.gmail", 4, "John", "Social Media Manager", "Doe", 2117m, "82b00941-53b0-43e8-be9b-d499f99422df" },
                    { 22, "johndoe22@company.gmail", 5, "John", "Account Executive", "Doe", 3588m, "06b8a530-99ed-43e0-868d-e61bddb70fad" },
                    { 23, "johndoe23@company.gmail", 6, "John", "Supply Chain Analyst", "Doe", 2875m, "914d74f3-e00f-4832-bbfc-a1a8fa197dd5" },
                    { 24, "johndoe24@company.gmail", 1, "John", "Training Specialist", "Doe", 1551m, "8b3b6a36-740b-4ff4-90a2-68f4d648268f" },
                    { 25, "johndoe25@company.gmail", 2, "John", "Accountant", "Doe", 2199m, "5e469dbc-cb73-468d-96f6-08775e3b914f" },
                    { 26, "johndoe26@company.gmail", 3, "John", "Network Engineer", "Doe", 4484m, "ddad886a-0374-4216-8a0e-44b97d9415b6" },
                    { 27, "johndoe27@company.gmail", 4, "John", "Social Media Manager", "Doe", 2017m, "ce329555-f617-4932-8612-35aa95ae7b73" },
                    { 28, "johndoe28@company.gmail", 5, "John", "Account Executive", "Doe", 3488m, "789e8ba5-d2a7-474c-9388-709f8d555444" },
                    { 29, "johndoe29@company.gmail", 6, "John", "Supply Chain Analyst", "Doe", 2891m, "01e39ff9-7d2c-4adc-af9a-1def1731f356" },
                    { 30, "johndoe30@company.gmail", 1, "John", "HR Generalist", "Doe", 1751m, "71873536-d293-4abe-b1a8-c3e3409e4419" },
                    { 31, "johndoe31@company.gmail", 2, "John", "Accountant", "Doe", 2143m, "6f45e132-0852-4469-abfb-44a8310901ec" },
                    { 32, "johndoe32@company.gmail", 3, "John", "Software Developer", "Doe", 4380m, "36848f24-c34a-4b47-a978-019a7edf5916" },
                    { 33, "johndoe33@company.gmail", 4, "John", "SEO Analyst", "Doe", 2185m, "d3bed2dd-fc8a-4d79-8c55-fa719ae3d50c" },
                    { 34, "johndoe34@company.gmail", 5, "John", "Sales Engineer", "Doe", 3647m, "1f8ce4af-5006-4286-a3a6-2afe3afcdfaf" },
                    { 35, "johndoe35@company.gmail", 6, "John", "Operations Specialist", "Doe", 2939m, "27b82b23-1b44-4109-b67e-436096e44aed" },
                    { 36, "johndoe36@company.gmail", 1, "John", "HR Generalist", "Doe", 1641m, "0c514623-a8dd-4596-a8bb-44aa2cedff5d" },
                    { 37, "johndoe37@company.gmail", 2, "John", "Accountant", "Doe", 2167m, "e433d64a-67b7-41bf-a601-b0699aa8b919" },
                    { 38, "johndoe38@company.gmail", 3, "John", "Software Developer", "Doe", 4582m, "d3c43796-5ef4-4ffe-937e-5ba4c5a8482b" },
                    { 39, "johndoe39@company.gmail", 4, "John", "Social Media Manager", "Doe", 2127m, "b380b92c-3735-479f-9ac9-ff009e753037" },
                    { 40, "johndoe40@company.gmail", 5, "John", "Business Developer", "Doe", 2578m, "5441893b-7bca-418d-870d-fbe7eb16bfe2" },
                    { 41, "johndoe41@company.gmail", 6, "John", "Supply Chain Analyst", "Doe", 2648m, "5f86318f-6981-4378-b202-b0323193f477" },
                    { 42, "johndoe42@company.gmail", 1, "John", "Training Specialist", "Doe", 1574m, "d1062501-1fa7-432a-8580-4c338adcdab2" },
                    { 43, "johndoe43@company.gmail", 2, "John", "Accountant", "Doe", 2173m, "a38c9770-bc32-4740-bcea-ee0f6881e0d8" },
                    { 44, "johndoe44@company.gmail", 3, "John", "Database Admin", "Doe", 4650m, "a7ac7ab2-ed5b-4bc4-9e3e-a1df13c1992f" },
                    { 45, "johndoe45@company.gmail", 4, "John", "SEO Analyst", "Doe", 2009m, "67915455-ec4a-4f16-9de9-85f70f49a244" },
                    { 46, "johndoe46@company.gmail", 5, "John", "Sales Representative", "Doe", 4352m, "5d6426fb-2a54-4baa-9ed2-507ae47c71f6" },
                    { 47, "johndoe47@company.gmail", 6, "John", "Logistics Coordinator", "Doe", 2888m, "f69a9979-f663-4757-9892-7bea2980908c" },
                    { 48, "johndoe48@company.gmail", 1, "John", "Recruiter", "Doe", 1672m, "a640a904-76b0-4b68-9c94-1e9881c14efb" },
                    { 49, "johndoe49@company.gmail", 2, "John", "Tax Specialist", "Doe", 2177m, "50ad756f-75a4-42ac-a9c2-287301f4b518" },
                    { 50, "johndoe50@company.gmail", 3, "John", "Network Engineer", "Doe", 4359m, "10744729-d70f-45dc-bfa9-6427490d32ce" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_UserId",
                table: "Employees",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3", "01e39ff9-7d2c-4adc-af9a-1def1731f356" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3", "06b8a530-99ed-43e0-868d-e61bddb70fad" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "0c514623-a8dd-4596-a8bb-44aa2cedff5d" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3", "0dbd5552-6f1f-4d82-881c-f22d85c2789b" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3", "10744729-d70f-45dc-bfa9-6427490d32ce" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3", "1f8ce4af-5006-4286-a3a6-2afe3afcdfaf" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3", "27b82b23-1b44-4109-b67e-436096e44aed" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3", "36848f24-c34a-4b47-a978-019a7edf5916" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "3753947d-e359-443d-b5b9-e01636c8b306" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3", "40e5148f-fa0b-4d0b-a998-d8ae7b46c2e8" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2", "418ebbc6-a571-4b16-bddb-3e10c85a94a0" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3", "47e0fcda-58c0-4590-964c-dae179f92932" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3", "50ad756f-75a4-42ac-a9c2-287301f4b518" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3", "5441893b-7bca-418d-870d-fbe7eb16bfe2" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3", "5d6426fb-2a54-4baa-9ed2-507ae47c71f6" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3", "5e469dbc-cb73-468d-96f6-08775e3b914f" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3", "5f86318f-6981-4378-b202-b0323193f477" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3", "67915455-ec4a-4f16-9de9-85f70f49a244" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3", "6f45e132-0852-4469-abfb-44a8310901ec" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3", "71370e19-12e7-427d-a2cc-02bec1b032a0" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "71873536-d293-4abe-b1a8-c3e3409e4419" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3", "76fff0d3-0dfb-44ed-92ff-5fa88274efb7" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3", "789e8ba5-d2a7-474c-9388-709f8d555444" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2", "7b245aad-b578-4301-8087-1ea820e39562" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3", "82678257-b20a-4ee8-8a8f-af9ab8d197d4" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3", "82b00941-53b0-43e8-be9b-d499f99422df" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "8b3b6a36-740b-4ff4-90a2-68f4d648268f" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3", "8c4e6128-4c38-4a55-a37b-7d6df6ce0450" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3", "914d74f3-e00f-4832-bbfc-a1a8fa197dd5" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3", "924692db-40ba-4c40-bb30-9e2df2a31ba7" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3", "a38c9770-bc32-4740-bcea-ee0f6881e0d8" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "a640a904-76b0-4b68-9c94-1e9881c14efb" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3", "a7ac7ab2-ed5b-4bc4-9e3e-a1df13c1992f" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3", "b380b92c-3735-479f-9ac9-ff009e753037" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3", "bfc1e140-3bf5-4b88-83e4-c9c8818edd29" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2", "ca3606ca-ab04-47dc-9004-18fb129fe813" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3", "ce329555-f617-4932-8612-35aa95ae7b73" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "d1062501-1fa7-432a-8580-4c338adcdab2" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "d28b7523-bf79-43a3-b00b-cfbcad195925" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3", "d3bed2dd-fc8a-4d79-8c55-fa719ae3d50c" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3", "d3c43796-5ef4-4ffe-937e-5ba4c5a8482b" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3", "d791bf20-7fce-4950-9355-f79812bd56fd" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2", "da3962a7-8c95-47e3-9fba-460090c2205c" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3", "ddad886a-0374-4216-8a0e-44b97d9415b6" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "e32878cb-895b-4f7e-be8b-24bffbb0908b" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3", "e433d64a-67b7-41bf-a601-b0699aa8b919" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3", "e56960b3-1ea4-49b2-91e4-e97b3d674370" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2", "e76f1d06-a5be-4000-aa0e-53e0cbee6b13" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3", "f5e404c4-33c8-44e7-9334-49eb7fc18b2d" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3", "f69a9979-f663-4757-9892-7bea2980908c" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "01e39ff9-7d2c-4adc-af9a-1def1731f356");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "06b8a530-99ed-43e0-868d-e61bddb70fad");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0c514623-a8dd-4596-a8bb-44aa2cedff5d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0dbd5552-6f1f-4d82-881c-f22d85c2789b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "10744729-d70f-45dc-bfa9-6427490d32ce");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1f8ce4af-5006-4286-a3a6-2afe3afcdfaf");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "27b82b23-1b44-4109-b67e-436096e44aed");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "36848f24-c34a-4b47-a978-019a7edf5916");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3753947d-e359-443d-b5b9-e01636c8b306");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "40e5148f-fa0b-4d0b-a998-d8ae7b46c2e8");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "418ebbc6-a571-4b16-bddb-3e10c85a94a0");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "47e0fcda-58c0-4590-964c-dae179f92932");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "50ad756f-75a4-42ac-a9c2-287301f4b518");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5441893b-7bca-418d-870d-fbe7eb16bfe2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5d6426fb-2a54-4baa-9ed2-507ae47c71f6");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5e469dbc-cb73-468d-96f6-08775e3b914f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5f86318f-6981-4378-b202-b0323193f477");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "67915455-ec4a-4f16-9de9-85f70f49a244");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6f45e132-0852-4469-abfb-44a8310901ec");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "71370e19-12e7-427d-a2cc-02bec1b032a0");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "71873536-d293-4abe-b1a8-c3e3409e4419");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "76fff0d3-0dfb-44ed-92ff-5fa88274efb7");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "789e8ba5-d2a7-474c-9388-709f8d555444");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7b245aad-b578-4301-8087-1ea820e39562");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "82678257-b20a-4ee8-8a8f-af9ab8d197d4");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "82b00941-53b0-43e8-be9b-d499f99422df");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8b3b6a36-740b-4ff4-90a2-68f4d648268f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8c4e6128-4c38-4a55-a37b-7d6df6ce0450");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "914d74f3-e00f-4832-bbfc-a1a8fa197dd5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "924692db-40ba-4c40-bb30-9e2df2a31ba7");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a38c9770-bc32-4740-bcea-ee0f6881e0d8");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a640a904-76b0-4b68-9c94-1e9881c14efb");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a7ac7ab2-ed5b-4bc4-9e3e-a1df13c1992f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b380b92c-3735-479f-9ac9-ff009e753037");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bfc1e140-3bf5-4b88-83e4-c9c8818edd29");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ca3606ca-ab04-47dc-9004-18fb129fe813");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ce329555-f617-4932-8612-35aa95ae7b73");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d1062501-1fa7-432a-8580-4c338adcdab2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d28b7523-bf79-43a3-b00b-cfbcad195925");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d3bed2dd-fc8a-4d79-8c55-fa719ae3d50c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d3c43796-5ef4-4ffe-937e-5ba4c5a8482b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d791bf20-7fce-4950-9355-f79812bd56fd");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "da3962a7-8c95-47e3-9fba-460090c2205c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ddad886a-0374-4216-8a0e-44b97d9415b6");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e32878cb-895b-4f7e-be8b-24bffbb0908b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e433d64a-67b7-41bf-a601-b0699aa8b919");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e56960b3-1ea4-49b2-91e4-e97b3d674370");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e76f1d06-a5be-4000-aa0e-53e0cbee6b13");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f5e404c4-33c8-44e7-9334-49eb7fc18b2d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f69a9979-f663-4757-9892-7bea2980908c");

            migrationBuilder.AddColumn<int>(
                name: "AccessFailedCount",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "EmailConfirmed",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LockoutEnabled",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LockoutEnd",
                table: "AspNetUsers",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PhoneNumberConfirmed",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "TwoFactorEnabled",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
