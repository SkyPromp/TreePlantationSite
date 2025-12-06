using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AP.BTP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class cleanContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlantationSite",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HouseNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<int>(type: "int", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Size = table.Column<double>(type: "float", nullable: false),
                    GroundPlan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantationSite", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tree",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Species = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaintenancePlanSpring = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaintenancePlanSummer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaintenancePlanAutumn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaintenancePlanWinter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tree", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Auth0Id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TreePicture",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsFavourite = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    TreeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreePicture", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TreePicture_Tree_TreeId",
                        column: x => x.TreeId,
                        principalTable: "Tree",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Zone",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Size = table.Column<int>(type: "int", nullable: true),
                    PlantationSiteId = table.Column<int>(type: "int", nullable: false),
                    TreeId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zone", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Zone_PlantationSite_PlantationSiteId",
                        column: x => x.PlantationSiteId,
                        principalTable: "PlantationSite",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Zone_Tree_TreeId",
                        column: x => x.TreeId,
                        principalTable: "Tree",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlantationSiteUser",
                columns: table => new
                {
                    PlantationSitesId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantationSiteUser", x => new { x.PlantationSitesId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_PlantationSiteUser_PlantationSite_PlantationSitesId",
                        column: x => x.PlantationSitesId,
                        principalTable: "PlantationSite",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlantationSiteUser_User_UsersId",
                        column: x => x.UsersId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaskList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    PlantationSiteId = table.Column<int>(type: "int", nullable: true),
                    ZoneId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskList_PlantationSite_PlantationSiteId",
                        column: x => x.PlantationSiteId,
                        principalTable: "PlantationSite",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_TaskList_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaskList_Zone_ZoneId",
                        column: x => x.ZoneId,
                        principalTable: "Zone",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TaskItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DurationInMinutes = table.Column<int>(type: "int", nullable: false),
                    TaskListId = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskItem_TaskList_TaskListId",
                        column: x => x.TaskListId,
                        principalTable: "TaskList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "PlantationSite",
                columns: new[] { "Id", "City", "Country", "GroundPlan", "HouseNumber", "IsDeleted", "Name", "PostalCode", "Size", "Street" },
                values: new object[,]
                {
                    { 1, "Leuven", "Belgium", "", "12", false, "Kwekerij Groenvallei", 3000, 5300.0, "Beukenlaan" },
                    { 2, "Antwerpen", "Belgium", "", "5B", false, "Arborium Noordhaven", 2000, 7600.0, "Noordkaai" },
                    { 3, "Mechelen", "Belgium", "", "44", false, "Boomgaard Zilverbos", 2800, 6900.0, "Zilverbosstraat" },
                    { 4, "Kortrijk", "Belgium", "", "7A", false, "Plantcentrum Vlaanderweide", 8500, 5100.0, "Vlaanderweideweg" },
                    { 5, "Marche-en-Famenne", "Belgium", "", "91", false, "Kweeksite Ardennenpark", 6900, 14000.0, "Ardennenparklaan" },
                    { 6, "Gent", "Belgium", "", "3C", false, "Arboretum Scheldedreef", 9000, 8700.0, "Scheldedreef" },
                    { 7, "Hasselt", "Belgium", "", "28", false, "Groenpunt Kempenveld", 3500, 6700.0, "Kempenveldsteenweg" },
                    { 8, "Brugge", "Belgium", "", "16", false, "Boomkwekerij Zonnewoud", 8000, 8400.0, "Zonnewoudlaan" },
                    { 9, "Sint-Truiden", "Belgium", "", "77", false, "EcoKweek Haspengouw", 3800, 9200.0, "Haspengouwsebaan" },
                    { 10, "Turnhout", "Belgium", "", "10D", false, "Bosrand Groeihoeve", 2300, 12500.0, "Bosrandweg" }
                });

            migrationBuilder.InsertData(
                table: "Tree",
                columns: new[] { "Id", "IsDeleted", "MaintenancePlanAutumn", "MaintenancePlanSpring", "MaintenancePlanSummer", "MaintenancePlanWinter", "Species" },
                values: new object[,]
                {
                    { 1, false, null, null, null, null, "Amerikaans krentenboompje" },
                    { 2, false, null, null, null, null, "Amerikaans krentenboompje ‘Robin Hill’" },
                    { 3, false, null, null, null, null, "Amerikaanse amberboom" },
                    { 4, false, null, null, null, null, "Amerikaanse amberboom ‘Worplesdon’" },
                    { 5, false, null, null, null, null, "Amerikaanse eik" },
                    { 6, false, null, null, null, null, "Amerikaanse es" },
                    { 7, false, null, null, null, null, "Amerikaanse es ‘Skyline’" },
                    { 8, false, null, null, null, null, "Amerikaanse gleditsia" },
                    { 9, false, null, null, null, null, "Amerikaanse gleditsia ‘Elegantissima’" },
                    { 10, false, null, null, null, null, "Amerikaanse gleditsia ‘Skyline’" },
                    { 11, false, null, null, null, null, "Amerikaanse gleditsia ‘Sunburst’" },
                    { 12, false, null, null, null, null, "Amerikaanse gleditsia f. inermis" },
                    { 13, false, null, null, null, null, "Amerikaanse Judasboom" },
                    { 14, false, null, null, null, null, "Amerikaanse linde" },
                    { 15, false, null, null, null, null, "Amerikaanse tulpenboom" },
                    { 16, false, null, null, null, null, "Amerikaanse tulpenboom ‘Fastigiatum’" },
                    { 17, false, null, null, null, null, "Amerikaanse vogelkers" },
                    { 18, false, null, null, null, null, "Amoer-kurkboom" },
                    { 19, false, null, null, null, null, "Anna Paulownaboom" },
                    { 20, false, null, null, null, null, "Antarctische schijnbeuk" },
                    { 21, false, null, null, null, null, "Basterd meidoorn" },
                    { 22, false, null, null, null, null, "Basterd-goudenregen" },
                    { 23, false, null, null, null, null, "Beuk" },
                    { 24, false, null, null, null, null, "Beuk ‘Dawyck’" },
                    { 25, false, null, null, null, null, "Bijenboom" },
                    { 26, false, null, null, null, null, "Biltmoreana es" },
                    { 27, false, null, null, null, null, "Blauwe spar" },
                    { 28, false, null, null, null, null, "Bolprunus" },
                    { 29, false, null, null, null, null, "Boltrompetboom" },
                    { 30, false, null, null, null, null, "Bonte gladde iep" },
                    { 31, false, null, null, null, null, "Boomhazelaar" },
                    { 32, false, null, null, null, null, "Bosmagnolia" },
                    { 33, false, null, null, null, null, "Boswilg" },
                    { 34, false, null, null, null, null, "Breedbladige meelbes" },
                    { 35, false, null, null, null, null, "Bruine beuk" },
                    { 36, false, null, null, null, null, "Bruine treurbeuk" },
                    { 37, false, null, null, null, null, "Californische cipres" },
                    { 38, false, null, null, null, null, "Canada populier ‘Robusta’" },
                    { 39, false, null, null, null, null, "Canadapopulier" },
                    { 40, false, null, null, null, null, "Chinese balsempopulier ‘Fastigiata’" },
                    { 41, false, null, null, null, null, "Chinese treurwilg" },
                    { 42, false, null, null, null, null, "Colchische esdoorn" },
                    { 43, false, null, null, null, null, "Davids esdoorn" },
                    { 44, false, null, null, null, null, "Doodsbeenderenboom" },
                    { 45, false, null, null, null, null, "Douglasspar" },
                    { 46, false, null, null, null, null, "Drietandesdoorn" },
                    { 47, false, null, null, null, null, "Dubbelbloemige paardenkastanje" },
                    { 48, false, null, null, null, null, "Duiveltjesiep" },
                    { 49, false, null, null, null, null, "Eenbladige es" },
                    { 50, false, null, null, null, null, "Eenbladige robinia" },
                    { 51, false, null, null, null, null, "Eenstijlige meidoorn" },
                    { 52, false, null, null, null, null, "Eenstijlige meidoorn ‘Stricta’" },
                    { 53, false, null, null, null, null, "Eetappel" },
                    { 54, false, null, null, null, null, "Eik ‘Columna’" },
                    { 55, false, null, null, null, null, "Es" },
                    { 56, false, null, null, null, null, "Es ‘Altena’" },
                    { 57, false, null, null, null, null, "Es ‘Atlas’" },
                    { 58, false, null, null, null, null, "Es ‘Nana’" },
                    { 59, false, null, null, null, null, "Es ‘Westhof’s Glorie’" },
                    { 60, false, null, null, null, null, "Esdoornbladige plataan" },
                    { 61, false, null, null, null, null, "Esdoornbladige plataan ‘Alphen’s Globe’" },
                    { 62, false, null, null, null, null, "Esdoornbladige plataan ‘Tremonia’" },
                    { 63, false, null, null, null, null, "Europese hopbeuk" },
                    { 64, false, null, null, null, null, "Europese judasboom" },
                    { 65, false, null, null, null, null, "Europese larix" },
                    { 66, false, null, null, null, null, "Europese netelboom" },
                    { 67, false, null, null, null, null, "Fijnspar" },
                    { 68, false, null, null, null, null, "Finse meelbes ‘Gibbsii’" },
                    { 69, false, null, null, null, null, "Fladderiep" },
                    { 70, false, null, null, null, null, "Gedeelde meelbes" },
                    { 71, false, null, null, null, null, "Geelbladige trompetboom" },
                    { 72, false, null, null, null, null, "Gele bergiep" },
                    { 73, false, null, null, null, null, "Gele kornoelje" },
                    { 74, false, null, null, null, null, "Gele pavia" },
                    { 75, false, null, null, null, null, "Gele treurwilg" },
                    { 76, false, null, null, null, null, "Gele zeepboom" },
                    { 77, false, null, null, null, null, "Gele zeepboom ‘Fastigiata’" },
                    { 78, false, null, null, null, null, "Geveerdbladige esdoorn" },
                    { 79, false, null, null, null, null, "Geveerdbladige lijsterbes" },
                    { 80, false, null, null, null, null, "Gewone esdoorn" },
                    { 81, false, null, null, null, null, "Gewone esdoorn ‘Atropurpureum’" },
                    { 82, false, null, null, null, null, "Gewone esdoorn ‘Leopoldii’" },
                    { 83, false, null, null, null, null, "Gewone magnolia" },
                    { 84, false, null, null, null, null, "Gewone vijg" },
                    { 85, false, null, null, null, null, "Gewone vlier" },
                    { 86, false, null, null, null, null, "Gewone vogelkers" },
                    { 87, false, null, null, null, null, "Gewone walnoot" },
                    { 88, false, null, null, null, null, "Ginkgo" },
                    { 89, false, null, null, null, null, "Gladde iep" },
                    { 90, false, null, null, null, null, "Goudberk ‘Blush’" },
                    { 91, false, null, null, null, null, "Goudberk ‘Holland’" },
                    { 92, false, null, null, null, null, "Goudels" },
                    { 93, false, null, null, null, null, "Goudenregen" },
                    { 94, false, null, null, null, null, "Goudes" },
                    { 95, false, null, null, null, null, "Goudiep" },
                    { 96, false, null, null, null, null, "Grauwe abeel" },
                    { 97, false, null, null, null, null, "Grauwe abeel ‘De Moffart’" },
                    { 98, false, null, null, null, null, "Grootbladige els" },
                    { 99, false, null, null, null, null, "Grootbloemige trompetboom" },
                    { 100, false, null, null, null, null, "Grove den" },
                    { 101, false, null, null, null, null, "Haagbeuk" },
                    { 102, false, null, null, null, null, "Haagbeuk ‘Fastigiata’" },
                    { 103, false, null, null, null, null, "Haagbeuk ‘Frans Fontaine’" },
                    { 104, false, null, null, null, null, "Hartbladige els" },
                    { 105, false, null, null, null, null, "Hemelboom" },
                    { 106, false, null, null, null, null, "Himalaya-berk ‘Doorenbos’" },
                    { 107, false, null, null, null, null, "Himalaya-ceder" },
                    { 108, false, null, null, null, null, "Hollandse iep ‘Belgica’" },
                    { 109, false, null, null, null, null, "Hollandse linde" },
                    { 110, false, null, null, null, null, "Hongaarse eik" },
                    { 111, false, null, null, null, null, "Hulst" },
                    { 112, false, null, null, null, null, "Huntingdons iep" },
                    { 113, false, null, null, null, null, "Iep ‘Columella’" },
                    { 114, false, null, null, null, null, "Iep ‘Dodoens’" },
                    { 115, false, null, null, null, null, "Iep ‘Frontier’" },
                    { 116, false, null, null, null, null, "Iep ‘Lobel’" },
                    { 117, false, null, null, null, null, "Iep ‘New Horizon’" },
                    { 118, false, null, null, null, null, "Iep ‘Plantijn’" },
                    { 119, false, null, null, null, null, "Iep ‘Rebona’" },
                    { 120, false, null, null, null, null, "Ierse taxus" },
                    { 121, false, null, null, null, null, "Italiaanse populier" },
                    { 122, false, null, null, null, null, "Japanse esdoorn" },
                    { 123, false, null, null, null, null, "Japanse grootbloemige kornoelje" },
                    { 124, false, null, null, null, null, "Japanse honingboom" },
                    { 125, false, null, null, null, null, "Japanse honingboom ‘Harrie van Haaren’" },
                    { 126, false, null, null, null, null, "Japanse honingboom ‘Pendula’" },
                    { 127, false, null, null, null, null, "Japanse larix" },
                    { 128, false, null, null, null, null, "Japanse sierkers" },
                    { 129, false, null, null, null, null, "Japanse sierkers ‘Amanogawa’" },
                    { 130, false, null, null, null, null, "Japanse sierkers ‘Kanzan’" },
                    { 131, false, null, null, null, null, "Katsuraboom" },
                    { 132, false, null, null, null, null, "Kaukasische els" },
                    { 133, false, null, null, null, null, "Kaukasische vleugelnoot" },
                    { 134, false, null, null, null, null, "Kerspruim ‘Nigra’" },
                    { 135, false, null, null, null, null, "Kleverige robinia" },
                    { 136, false, null, null, null, null, "Kogelrobinia" },
                    { 137, false, null, null, null, null, "Koningslinde" },
                    { 138, false, null, null, null, null, "Krimlinde" },
                    { 139, false, null, null, null, null, "Krulwilg" },
                    { 140, false, null, null, null, null, "Kust sequoia" },
                    { 141, false, null, null, null, null, "Libanonceder" },
                    { 142, false, null, null, null, null, "Libanonceder ‘Glauca’" },
                    { 143, false, null, null, null, null, "Mammoetboom" },
                    { 144, false, null, null, null, null, "Meelbes" },
                    { 145, false, null, null, null, null, "Mispel" },
                    { 146, false, null, null, null, null, "Moerascipres" },
                    { 147, false, null, null, null, null, "Moeraseik" },
                    { 148, false, null, null, null, null, "Moeraseik ‘Green Pillar’" },
                    { 149, false, null, null, null, null, "Mongoolse linde" },
                    { 150, false, null, null, null, null, "Monumentaal-iep" },
                    { 151, false, null, null, null, null, "Moseik" },
                    { 152, false, null, null, null, null, "Noordelijke Japanse magnolia" },
                    { 153, false, null, null, null, null, "Noorse bolesdoorn" },
                    { 154, false, null, null, null, null, "Noorse esdoorn" },
                    { 155, false, null, null, null, null, "Noorse esdoorn ‘Crimson King’" },
                    { 156, false, null, null, null, null, "Noorse esdoorn ‘Drumondii’" },
                    { 157, false, null, null, null, null, "Noorse esdoorn ‘Faassen’s Black’" },
                    { 158, false, null, null, null, null, "Olijf" },
                    { 159, false, null, null, null, null, "Oostelijke hemlockspar" },
                    { 160, false, null, null, null, null, "Oostenrijkse den" },
                    { 161, false, null, null, null, null, "Oostenrijkse eik" },
                    { 162, false, null, null, null, null, "Oosterse plataan" },
                    { 163, false, null, null, null, null, "Oosterse plataan ‘Digitata’" },
                    { 164, false, null, null, null, null, "Papierberk" },
                    { 165, false, null, null, null, null, "Papieresdoorn" },
                    { 166, false, null, null, null, null, "Papiermoerbei" },
                    { 167, false, null, null, null, null, "Peer" },
                    { 168, false, null, null, null, null, "Peer ‘Beech Hill’" },
                    { 169, false, null, null, null, null, "Pennsylvaanse es" },
                    { 170, false, null, null, null, null, "Pennsylvaanse es ‘Zundert’" },
                    { 171, false, null, null, null, null, "Perzisch ijzerhout" },
                    { 172, false, null, null, null, null, "Perzische slaapboom" },
                    { 173, false, null, null, null, null, "Pluim-es" },
                    { 174, false, null, null, null, null, "Pluim-es ‘Mecsek’" },
                    { 175, false, null, null, null, null, "Pluim-iep" },
                    { 176, false, null, null, null, null, "Prieel-iep" },
                    { 177, false, null, null, null, null, "Prieelberk" },
                    { 178, false, null, null, null, null, "Pruimbladige meidoorn ‘Splendens’" },
                    { 179, false, null, null, null, null, "Ratelpopulier" },
                    { 180, false, null, null, null, null, "Reuzenkornoelje" },
                    { 181, false, null, null, null, null, "Reuzenlevensboom" },
                    { 182, false, null, null, null, null, "Reuzenzilverspar" },
                    { 183, false, null, null, null, null, "Robinia" },
                    { 184, false, null, null, null, null, "Robinia ‘Bessoniana’" },
                    { 185, false, null, null, null, null, "Robinia ‘Decaisneana’" },
                    { 186, false, null, null, null, null, "Robinia ‘Frisia’" },
                    { 187, false, null, null, null, null, "Robinia ‘Pink Cascade’" },
                    { 188, false, null, null, null, null, "Robinia ‘Pyramidalis’" },
                    { 189, false, null, null, null, null, "Rode esdoorn" },
                    { 190, false, null, null, null, null, "Rode paardenkastanje" },
                    { 191, false, null, null, null, null, "Rode paardenkastanje ‘Briotii’" },
                    { 192, false, null, null, null, null, "Rode pavia" },
                    { 193, false, null, null, null, null, "Rondbladige beuk" },
                    { 194, false, null, null, null, null, "Ruwe berk" },
                    { 195, false, null, null, null, null, "Ruwe berk ‘Fastigiata’" },
                    { 196, false, null, null, null, null, "Ruwe berk ‘Zwitsers Glorie’" },
                    { 197, false, null, null, null, null, "Ruwe iep" },
                    { 198, false, null, null, null, null, "Ruwvruchtige populier" },
                    { 199, false, null, null, null, null, "Scharlaken eik ‘Splendens’" },
                    { 200, false, null, null, null, null, "Schietwilg" },
                    { 201, false, null, null, null, null, "Schietwilg ‘Chermesina’" },
                    { 202, false, null, null, null, null, "Servische spar" },
                    { 203, false, null, null, null, null, "Siberische balsempopulier" },
                    { 204, false, null, null, null, null, "Sierappel" },
                    { 205, false, null, null, null, null, "Sierappel" },
                    { 206, false, null, null, null, null, "Sierappel" },
                    { 207, false, null, null, null, null, "Sierkers gondouinii ‘Schnee’" },
                    { 208, false, null, null, null, null, "Sierkers sargentii ‘Rancho’" },
                    { 209, false, null, null, null, null, "Sierpeer ‘Chanticleer’" },
                    { 210, false, null, null, null, null, "Sitka spar" },
                    { 211, false, null, null, null, null, "Slangenden" },
                    { 212, false, null, null, null, null, "Sleedoorn" },
                    { 213, false, null, null, null, null, "Smalbladige es" },
                    { 214, false, null, null, null, null, "Smalbladige es ‘Raywood’" },
                    { 215, false, null, null, null, null, "Smalle olijfwilg" },
                    { 216, false, null, null, null, null, "Sneeuwklokjesboom" },
                    { 217, false, null, null, null, null, "Spaanse aak" },
                    { 218, false, null, null, null, null, "Spaanse aak ‘Elsrijk’" },
                    { 219, false, null, null, null, null, "Spaanse eik" },
                    { 220, false, null, null, null, null, "Steeneik" },
                    { 221, false, null, null, null, null, "Suikeresdoorn" },
                    { 222, false, null, null, null, null, "Tamme kastanje" },
                    { 223, false, null, null, null, null, "Tamme kastanje ‘Albomarginata’" },
                    { 224, false, null, null, null, null, "Taxus" },
                    { 225, false, null, null, null, null, "Treurberk" },
                    { 226, false, null, null, null, null, "Treurbeuk" },
                    { 227, false, null, null, null, null, "Treures" },
                    { 228, false, null, null, null, null, "Treuriep" },
                    { 229, false, null, null, null, null, "Trompetboom" },
                    { 230, false, null, null, null, null, "Tweestijlige meidoorn" },
                    { 231, false, null, null, null, null, "Vaantjesboom" },
                    { 232, false, null, null, null, null, "Varenbeuk" },
                    { 233, false, null, null, null, null, "Vederesdoorn" },
                    { 234, false, null, null, null, null, "Vederesdoorn ‘Variegatum’" },
                    { 235, false, null, null, null, null, "Vijvercipres" },
                    { 236, false, null, null, null, null, "Watercipres" },
                    { 237, false, null, null, null, null, "Westelijke hemlockspar" },
                    { 238, false, null, null, null, null, "Westerse levensboom" },
                    { 239, false, null, null, null, null, "Westerse netelboom" },
                    { 240, false, null, null, null, null, "Weymouthden" },
                    { 241, false, null, null, null, null, "Wilde lijsterbes" },
                    { 242, false, null, null, null, null, "Wilde lijsterbes ‘Fastigiata’" },
                    { 243, false, null, null, null, null, "Wilgbladige peer" },
                    { 244, false, null, null, null, null, "Winterbloeiende kers" },
                    { 245, false, null, null, null, null, "Wintereik" },
                    { 246, false, null, null, null, null, "Winterlinde" },
                    { 247, false, null, null, null, null, "Winterlinde ‘Böhlje’" },
                    { 248, false, null, null, null, null, "Winterlinde ‘Greenspire’" },
                    { 249, false, null, null, null, null, "Winterlinde ‘Rancho’" },
                    { 250, false, null, null, null, null, "Witte abeel" },
                    { 251, false, null, null, null, null, "Witte bitternoot" },
                    { 252, false, null, null, null, null, "Witte els" },
                    { 253, false, null, null, null, null, "Witte esdoorn" },
                    { 254, false, null, null, null, null, "Witte esdoorn ‘Laciniatum Wieri’" },
                    { 255, false, null, null, null, null, "Witte esdoorn ‘Pyramidale’" },
                    { 256, false, null, null, null, null, "Witte moerbei" },
                    { 257, false, null, null, null, null, "Witte paardenkastanje" },
                    { 258, false, null, null, null, null, "Yoshino kers" },
                    { 259, false, null, null, null, null, "Zachte berk" },
                    { 260, false, null, null, null, null, "Zelkova" },
                    { 261, false, null, null, null, null, "Zilverlinde" },
                    { 262, false, null, null, null, null, "Zilverlinde ‘Brabant’" },
                    { 263, false, null, null, null, null, "Zoete kers" },
                    { 264, false, null, null, null, null, "Zoete kers ‘Plena’" },
                    { 265, false, null, null, null, null, "Zomereik" },
                    { 266, false, null, null, null, null, "Zomereik ‘Fastigiate Koster’" },
                    { 267, false, null, null, null, null, "Zomerlinde" },
                    { 268, false, null, null, null, null, "Zuidelijke magnolia" },
                    { 269, false, null, null, null, null, "Zwarte balsempopulier" },
                    { 270, false, null, null, null, null, "Zwarte berk" },
                    { 271, false, null, null, null, null, "Zwarte den" },
                    { 272, false, null, null, null, null, "Zwarte els" },
                    { 273, false, null, null, null, null, "Zwarte els ‘Laciniata’" },
                    { 274, false, null, null, null, null, "Zwarte linde" },
                    { 275, false, null, null, null, null, "Zwarte moerbei" },
                    { 276, false, null, null, null, null, "Zwarte populier" },
                    { 277, false, null, null, null, null, "Zwarte tupeloboom" },
                    { 278, false, null, null, null, null, "Zwarte walnoot" },
                    { 279, false, null, null, null, null, "Zweedse berk" },
                    { 280, false, null, null, null, null, "Zweedse lijsterbes ‘Brouwers’" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Auth0Id", "Email", "FirstName", "IsApproved", "IsDeleted", "LastName", "PhoneNumber", "Role" },
                values: new object[,]
                {
                    { 1, "auth0|68f5f3c8fa9e243c35508427", "admin123@admin.admin", "Admin1", true, false, "Lastname", "0123456789", "Admin" },
                    { 2, "auth0|690db2550eb8c001baeaeb22", "manager123@manager.manager", "Manager1", true, false, "Lastname", "0123456789", "Manager" },
                    { 3, "auth0|68f7f831f5bc833fc99fca15", "operator123@operator.operator", "Operator1", true, false, "Lastname", "0123456789", "Operator" }
                });

            migrationBuilder.InsertData(
                table: "PlantationSiteUser",
                columns: new[] { "PlantationSitesId", "UsersId" },
                values: new object[,]
                {
                    { 1, 3 },
                    { 2, 3 }
                });

            migrationBuilder.InsertData(
                table: "Zone",
                columns: new[] { "Id", "IsDeleted", "Name", "PlantationSiteId", "Size", "TreeId" },
                values: new object[,]
                {
                    { 1, false, "Zone 1A", 1, 127, 70 },
                    { 2, false, "Zone 1B", 1, 411, 131 },
                    { 3, false, "Zone 2C", 1, 266, 184 },
                    { 4, false, "Zone 2A", 1, 485, 99 },
                    { 5, false, "Zone 2B", 1, 356, 29 },
                    { 6, false, "Zone 3C", 1, 186, 8 },
                    { 7, false, "Zone 3A", 1, 505, 90 },
                    { 8, false, "Zone 3B", 1, 361, 191 },
                    { 9, false, "Zone 4C", 1, 344, 79 },
                    { 10, false, "Zone 4A", 1, 381, 197 },
                    { 11, false, "Zone 1A", 2, 120, 265 },
                    { 12, false, "Zone 1B", 2, 244, 45 },
                    { 13, false, "Zone 2C", 2, 152, 223 },
                    { 14, false, "Zone 2A", 2, 212, 222 },
                    { 15, false, "Zone 2B", 2, 461, 230 },
                    { 16, false, "Zone 3C", 2, 388, 156 },
                    { 17, false, "Zone 3A", 2, 85, 196 },
                    { 18, false, "Zone 3B", 2, 426, 277 },
                    { 19, false, "Zone 4C", 2, 106, 240 },
                    { 20, false, "Zone 4A", 2, 305, 144 },
                    { 21, false, "Zone 1A", 3, 507, 77 },
                    { 22, false, "Zone 1B", 3, 246, 193 },
                    { 23, false, "Zone 2C", 3, 370, 122 },
                    { 24, false, "Zone 2A", 3, 283, 189 },
                    { 25, false, "Zone 2B", 3, 231, 69 },
                    { 26, false, "Zone 3C", 3, 152, 147 },
                    { 27, false, "Zone 3A", 3, 377, 97 },
                    { 28, false, "Zone 3B", 3, 146, 111 },
                    { 29, false, "Zone 4C", 3, 116, 266 },
                    { 30, false, "Zone 4A", 3, 289, 272 },
                    { 31, false, "Zone 1A", 4, 100, 179 },
                    { 32, false, "Zone 1B", 4, 172, 34 },
                    { 33, false, "Zone 2C", 4, 214, 25 },
                    { 34, false, "Zone 2A", 4, 211, 154 },
                    { 35, false, "Zone 2B", 4, 456, 279 },
                    { 36, false, "Zone 3C", 4, 174, 223 },
                    { 37, false, "Zone 3A", 4, 156, 29 },
                    { 38, false, "Zone 3B", 4, 491, 120 },
                    { 39, false, "Zone 4C", 4, 412, 113 },
                    { 40, false, "Zone 4A", 4, 132, 265 },
                    { 41, false, "Zone 1A", 5, 217, 138 },
                    { 42, false, "Zone 1B", 5, 281, 18 },
                    { 43, false, "Zone 2C", 5, 246, 101 },
                    { 44, false, "Zone 2A", 5, 83, 104 },
                    { 45, false, "Zone 2B", 5, 439, 173 },
                    { 46, false, "Zone 3C", 5, 412, 239 },
                    { 47, false, "Zone 3A", 5, 91, 25 },
                    { 48, false, "Zone 3B", 5, 177, 248 },
                    { 49, false, "Zone 4C", 5, 284, 244 },
                    { 50, false, "Zone 4A", 5, 132, 84 },
                    { 51, false, "Zone 1A", 6, 239, 36 },
                    { 52, false, "Zone 1B", 6, 238, 133 },
                    { 53, false, "Zone 2C", 6, 211, 156 },
                    { 54, false, "Zone 2A", 6, 152, 20 },
                    { 55, false, "Zone 2B", 6, 268, 74 },
                    { 56, false, "Zone 3C", 6, 155, 211 },
                    { 57, false, "Zone 3A", 6, 445, 39 },
                    { 58, false, "Zone 3B", 6, 216, 278 },
                    { 59, false, "Zone 4C", 6, 360, 275 },
                    { 60, false, "Zone 4A", 6, 380, 239 },
                    { 61, false, "Zone 1A", 7, 312, 263 },
                    { 62, false, "Zone 1B", 7, 149, 192 },
                    { 63, false, "Zone 2C", 7, 89, 6 },
                    { 64, false, "Zone 2A", 7, 112, 37 },
                    { 65, false, "Zone 2B", 7, 167, 82 },
                    { 66, false, "Zone 3C", 7, 478, 24 },
                    { 67, false, "Zone 3A", 7, 434, 133 },
                    { 68, false, "Zone 3B", 7, 132, 278 },
                    { 69, false, "Zone 4C", 7, 378, 237 },
                    { 70, false, "Zone 4A", 7, 103, 255 },
                    { 71, false, "Zone 1A", 8, 167, 89 },
                    { 72, false, "Zone 1B", 8, 157, 208 },
                    { 73, false, "Zone 2C", 8, 372, 24 },
                    { 74, false, "Zone 2A", 8, 182, 178 },
                    { 75, false, "Zone 2B", 8, 324, 9 },
                    { 76, false, "Zone 3C", 8, 175, 68 },
                    { 77, false, "Zone 3A", 8, 338, 174 },
                    { 78, false, "Zone 3B", 8, 331, 51 },
                    { 79, false, "Zone 4C", 8, 214, 191 },
                    { 80, false, "Zone 4A", 8, 310, 98 },
                    { 81, false, "Zone 1A", 9, 507, 49 },
                    { 82, false, "Zone 1B", 9, 105, 245 },
                    { 83, false, "Zone 2C", 9, 435, 100 },
                    { 84, false, "Zone 2A", 9, 214, 196 },
                    { 85, false, "Zone 2B", 9, 456, 239 },
                    { 86, false, "Zone 3C", 9, 204, 132 },
                    { 87, false, "Zone 3A", 9, 424, 207 },
                    { 88, false, "Zone 3B", 9, 397, 107 },
                    { 89, false, "Zone 4C", 9, 298, 223 },
                    { 90, false, "Zone 4A", 9, 225, 22 },
                    { 91, false, "Zone 1A", 10, 464, 108 },
                    { 92, false, "Zone 1B", 10, 391, 13 },
                    { 93, false, "Zone 2C", 10, 450, 269 },
                    { 94, false, "Zone 2A", 10, 455, 85 },
                    { 95, false, "Zone 2B", 10, 256, 180 },
                    { 96, false, "Zone 3C", 10, 308, 123 },
                    { 97, false, "Zone 3A", 10, 242, 97 },
                    { 98, false, "Zone 3B", 10, 219, 246 },
                    { 99, false, "Zone 4C", 10, 374, 92 },
                    { 100, false, "Zone 4A", 10, 190, 230 }
                });

            migrationBuilder.InsertData(
                table: "TaskList",
                columns: new[] { "Id", "Date", "IsDeleted", "PlantationSiteId", "UserId", "ZoneId" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 11, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 2, 3, 13 },
                    { 2, new DateTime(2025, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1, 3, 2 },
                    { 3, new DateTime(2025, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 2, 3, 15 },
                    { 4, new DateTime(2025, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1, 3, 8 },
                    { 5, new DateTime(2025, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 2, 3, 17 },
                    { 6, new DateTime(2025, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1, 3, 5 },
                    { 7, new DateTime(2025, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 2, 3, 14 },
                    { 8, new DateTime(2025, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1, 3, 10 },
                    { 9, new DateTime(2025, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 2, 3, 12 },
                    { 10, new DateTime(2025, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1, 3, 7 },
                    { 11, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 2, 3, 11 },
                    { 12, new DateTime(2025, 12, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1, 3, 3 },
                    { 13, new DateTime(2025, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 2, 3, 14 },
                    { 14, new DateTime(2025, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1, 3, 10 },
                    { 15, new DateTime(2025, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 2, 3, 17 },
                    { 16, new DateTime(2025, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1, 3, 7 },
                    { 17, new DateTime(2025, 12, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 2, 3, 13 },
                    { 18, new DateTime(2025, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1, 3, 7 },
                    { 19, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 2, 3, 18 },
                    { 20, new DateTime(2025, 12, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1, 3, 8 },
                    { 21, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 2, 3, 20 },
                    { 22, new DateTime(2025, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1, 3, 1 },
                    { 23, new DateTime(2025, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 2, 3, 12 },
                    { 24, new DateTime(2025, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1, 3, 4 },
                    { 25, new DateTime(2025, 12, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 2, 3, 18 },
                    { 26, new DateTime(2025, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1, 3, 2 },
                    { 27, new DateTime(2025, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 2, 3, 18 },
                    { 28, new DateTime(2025, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1, 3, 4 },
                    { 29, new DateTime(2025, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 2, 3, 19 },
                    { 30, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1, 3, 9 },
                    { 31, new DateTime(2025, 12, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 2, 3, 16 },
                    { 32, new DateTime(2025, 12, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1, 3, 8 },
                    { 33, new DateTime(2025, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 2, 3, 17 },
                    { 34, new DateTime(2025, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1, 3, 1 },
                    { 35, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 2, 3, 20 },
                    { 36, new DateTime(2026, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1, 3, 9 },
                    { 37, new DateTime(2026, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 2, 3, 19 },
                    { 38, new DateTime(2026, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1, 3, 1 },
                    { 39, new DateTime(2026, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 2, 3, 16 },
                    { 40, new DateTime(2026, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1, 3, 6 },
                    { 41, new DateTime(2026, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 2, 3, 13 },
                    { 42, new DateTime(2026, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1, 3, 10 },
                    { 43, new DateTime(2026, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 2, 3, 17 },
                    { 44, new DateTime(2026, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1, 3, 4 },
                    { 45, new DateTime(2026, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 2, 3, 15 },
                    { 46, new DateTime(2026, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1, 3, 7 },
                    { 47, new DateTime(2026, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 2, 3, 17 },
                    { 48, new DateTime(2026, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1, 3, 5 },
                    { 49, new DateTime(2026, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 2, 3, 13 },
                    { 50, new DateTime(2026, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1, 3, 4 },
                    { 51, new DateTime(2026, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 2, 3, 16 },
                    { 52, new DateTime(2026, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1, 3, 2 },
                    { 53, new DateTime(2026, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 2, 3, 14 },
                    { 54, new DateTime(2026, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1, 3, 7 },
                    { 55, new DateTime(2026, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 2, 3, 14 },
                    { 56, new DateTime(2026, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1, 3, 2 },
                    { 57, new DateTime(2026, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 2, 3, 20 },
                    { 58, new DateTime(2026, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1, 3, 1 },
                    { 59, new DateTime(2026, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 2, 3, 20 },
                    { 60, new DateTime(2026, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1, 3, 5 },
                    { 61, new DateTime(2026, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 2, 3, 17 },
                    { 62, new DateTime(2026, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1, 3, 1 },
                    { 63, new DateTime(2026, 1, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 2, 3, 12 },
                    { 64, new DateTime(2026, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1, 3, 3 },
                    { 65, new DateTime(2026, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 2, 3, 11 },
                    { 66, new DateTime(2026, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1, 3, 4 },
                    { 67, new DateTime(2026, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 2, 3, 16 },
                    { 68, new DateTime(2026, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1, 3, 4 },
                    { 69, new DateTime(2026, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 2, 3, 20 },
                    { 70, new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1, 3, 9 },
                    { 71, new DateTime(2026, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 2, 3, 18 },
                    { 72, new DateTime(2026, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1, 3, 3 },
                    { 73, new DateTime(2026, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 2, 3, 12 },
                    { 74, new DateTime(2026, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1, 3, 2 },
                    { 75, new DateTime(2026, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 2, 3, 15 },
                    { 76, new DateTime(2026, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1, 3, 10 },
                    { 77, new DateTime(2026, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 2, 3, 15 },
                    { 78, new DateTime(2026, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1, 3, 8 },
                    { 79, new DateTime(2026, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 2, 3, 20 },
                    { 80, new DateTime(2026, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1, 3, 2 },
                    { 81, new DateTime(2026, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 2, 3, 15 },
                    { 82, new DateTime(2026, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1, 3, 4 },
                    { 83, new DateTime(2026, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 2, 3, 11 },
                    { 84, new DateTime(2026, 2, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1, 3, 5 },
                    { 85, new DateTime(2026, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 2, 3, 14 },
                    { 86, new DateTime(2026, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1, 3, 4 },
                    { 87, new DateTime(2026, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 2, 3, 14 },
                    { 88, new DateTime(2026, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1, 3, 1 },
                    { 89, new DateTime(2026, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 2, 3, 17 },
                    { 90, new DateTime(2026, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1, 3, 9 },
                    { 91, new DateTime(2026, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 2, 3, 19 },
                    { 92, new DateTime(2026, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1, 3, 8 },
                    { 93, new DateTime(2026, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 2, 3, 11 },
                    { 94, new DateTime(2026, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1, 3, 1 },
                    { 95, new DateTime(2026, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 2, 3, 19 },
                    { 96, new DateTime(2026, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1, 3, 3 },
                    { 97, new DateTime(2026, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 2, 3, 19 },
                    { 98, new DateTime(2026, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1, 3, 5 },
                    { 99, new DateTime(2026, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 2, 3, 14 },
                    { 100, new DateTime(2026, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1, 3, 2 },
                    { 101, new DateTime(2026, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 2, 3, 12 },
                    { 102, new DateTime(2026, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1, 3, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlantationSiteUser_UsersId",
                table: "PlantationSiteUser",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskItem_TaskListId",
                table: "TaskItem",
                column: "TaskListId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskList_PlantationSiteId",
                table: "TaskList",
                column: "PlantationSiteId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskList_UserId",
                table: "TaskList",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskList_ZoneId",
                table: "TaskList",
                column: "ZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_TreePicture_TreeId",
                table: "TreePicture",
                column: "TreeId");

            migrationBuilder.CreateIndex(
                name: "IX_Zone_PlantationSiteId",
                table: "Zone",
                column: "PlantationSiteId");

            migrationBuilder.CreateIndex(
                name: "IX_Zone_TreeId",
                table: "Zone",
                column: "TreeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlantationSiteUser");

            migrationBuilder.DropTable(
                name: "TaskItem");

            migrationBuilder.DropTable(
                name: "TreePicture");

            migrationBuilder.DropTable(
                name: "TaskList");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Zone");

            migrationBuilder.DropTable(
                name: "PlantationSite");

            migrationBuilder.DropTable(
                name: "Tree");
        }
    }
}
