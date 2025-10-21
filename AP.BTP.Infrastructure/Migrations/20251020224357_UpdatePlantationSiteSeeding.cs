using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AP.BTP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePlantationSiteSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: -11);

            migrationBuilder.DeleteData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: -10);

            migrationBuilder.DeleteData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: -9);

            migrationBuilder.DeleteData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: -8);

            migrationBuilder.DeleteData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: -7);

            migrationBuilder.DeleteData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: -6);

            migrationBuilder.DeleteData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: -5);

            migrationBuilder.DeleteData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: -4);

            migrationBuilder.DeleteData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: -1);

            migrationBuilder.InsertData(
                table: "PlantationSite",
                columns: new[] { "Id", "City", "Country", "GroundPlan", "HouseNumber", "Name", "PostalCode", "Street" },
                values: new object[,]
                {
                    { 1, "City Site1", "Belgium", "Groundplan Site1", 1, "Site1", 1001, "Street Site1" },
                    { 2, "City Site2", "Belgium", "Groundplan Site2", 2, "Site2", 1002, "Street Site2" },
                    { 3, "City Site3", "Belgium", "Groundplan Site3", 3, "Site3", 1003, "Street Site3" },
                    { 4, "City Site4", "Belgium", "Groundplan Site4", 4, "Site4", 1004, "Street Site4" },
                    { 5, "City Site5", "Belgium", "Groundplan Site5", 5, "Site5", 1005, "Street Site5" },
                    { 6, "City Site6", "Belgium", "Groundplan Site6", 6, "Site6", 1006, "Street Site6" },
                    { 7, "City Site7", "Belgium", "Groundplan Site7", 7, "Site7", 1007, "Street Site7" },
                    { 8, "City Site8", "Belgium", "Groundplan Site8", 8, "Site8", 1008, "Street Site8" },
                    { 9, "City Site9", "Belgium", "Groundplan Site9", 9, "Site9", 1009, "Street Site9" },
                    { 10, "City Site10", "Belgium", "Groundplan Site10", 10, "Site10", 1010, "Street Site10" },
                    { 11, "City Site11", "Belgium", "Groundplan Site11", 11, "Site11", 1011, "Street Site11" },
                    { 12, "City Site12", "Belgium", "Groundplan Site12", 12, "Site12", 1012, "Street Site12" },
                    { 13, "City Site13", "Belgium", "Groundplan Site13", 13, "Site13", 1013, "Street Site13" },
                    { 14, "City Site14", "Belgium", "Groundplan Site14", 14, "Site14", 1014, "Street Site14" },
                    { 15, "City Site15", "Belgium", "Groundplan Site15", 15, "Site15", 1015, "Street Site15" },
                    { 16, "City Site16", "Belgium", "Groundplan Site16", 16, "Site16", 1016, "Street Site16" },
                    { 17, "City Site17", "Belgium", "Groundplan Site17", 17, "Site17", 1017, "Street Site17" },
                    { 18, "City Site18", "Belgium", "Groundplan Site18", 18, "Site18", 1018, "Street Site18" },
                    { 19, "City Site19", "Belgium", "Groundplan Site19", 19, "Site19", 1019, "Street Site19" },
                    { 20, "City Site20", "Belgium", "Groundplan Site20", 20, "Site20", 1020, "Street Site20" },
                    { 21, "City Site21", "Belgium", "Groundplan Site21", 21, "Site21", 1021, "Street Site21" },
                    { 22, "City Site22", "Belgium", "Groundplan Site22", 22, "Site22", 1022, "Street Site22" },
                    { 23, "City Site23", "Belgium", "Groundplan Site23", 23, "Site23", 1023, "Street Site23" },
                    { 24, "City Site24", "Belgium", "Groundplan Site24", 24, "Site24", 1024, "Street Site24" },
                    { 25, "City Site25", "Belgium", "Groundplan Site25", 25, "Site25", 1025, "Street Site25" },
                    { 26, "City Site26", "Belgium", "Groundplan Site26", 26, "Site26", 1026, "Street Site26" },
                    { 27, "City Site27", "Belgium", "Groundplan Site27", 27, "Site27", 1027, "Street Site27" },
                    { 28, "City Site28", "Belgium", "Groundplan Site28", 28, "Site28", 1028, "Street Site28" },
                    { 29, "City Site29", "Belgium", "Groundplan Site29", 29, "Site29", 1029, "Street Site29" },
                    { 30, "City Site30", "Belgium", "Groundplan Site30", 30, "Site30", 1030, "Street Site30" },
                    { 31, "City Site31", "Belgium", "Groundplan Site31", 31, "Site31", 1031, "Street Site31" },
                    { 32, "City Site32", "Belgium", "Groundplan Site32", 32, "Site32", 1032, "Street Site32" },
                    { 33, "City Site33", "Belgium", "Groundplan Site33", 33, "Site33", 1033, "Street Site33" },
                    { 34, "City Site34", "Belgium", "Groundplan Site34", 34, "Site34", 1034, "Street Site34" },
                    { 35, "City Site35", "Belgium", "Groundplan Site35", 35, "Site35", 1035, "Street Site35" },
                    { 36, "City Site36", "Belgium", "Groundplan Site36", 36, "Site36", 1036, "Street Site36" },
                    { 37, "City Site37", "Belgium", "Groundplan Site37", 37, "Site37", 1037, "Street Site37" },
                    { 38, "City Site38", "Belgium", "Groundplan Site38", 38, "Site38", 1038, "Street Site38" },
                    { 39, "City Site39", "Belgium", "Groundplan Site39", 39, "Site39", 1039, "Street Site39" },
                    { 40, "City Site40", "Belgium", "Groundplan Site40", 40, "Site40", 1040, "Street Site40" },
                    { 41, "City Site41", "Belgium", "Groundplan Site41", 41, "Site41", 1041, "Street Site41" },
                    { 42, "City Site42", "Belgium", "Groundplan Site42", 42, "Site42", 1042, "Street Site42" },
                    { 43, "City Site43", "Belgium", "Groundplan Site43", 43, "Site43", 1043, "Street Site43" },
                    { 44, "City Site44", "Belgium", "Groundplan Site44", 44, "Site44", 1044, "Street Site44" },
                    { 45, "City Site45", "Belgium", "Groundplan Site45", 45, "Site45", 1045, "Street Site45" },
                    { 46, "City Site46", "Belgium", "Groundplan Site46", 46, "Site46", 1046, "Street Site46" },
                    { 47, "City Site47", "Belgium", "Groundplan Site47", 47, "Site47", 1047, "Street Site47" },
                    { 48, "City Site48", "Belgium", "Groundplan Site48", 48, "Site48", 1048, "Street Site48" },
                    { 49, "City Site49", "Belgium", "Groundplan Site49", 49, "Site49", 1049, "Street Site49" },
                    { 50, "City Site50", "Belgium", "Groundplan Site50", 50, "Site50", 1050, "Street Site50" },
                    { 51, "City Site51", "Belgium", "Groundplan Site51", 51, "Site51", 1051, "Street Site51" },
                    { 52, "City Site52", "Belgium", "Groundplan Site52", 52, "Site52", 1052, "Street Site52" },
                    { 53, "City Site53", "Belgium", "Groundplan Site53", 53, "Site53", 1053, "Street Site53" },
                    { 54, "City Site54", "Belgium", "Groundplan Site54", 54, "Site54", 1054, "Street Site54" },
                    { 55, "City Site55", "Belgium", "Groundplan Site55", 55, "Site55", 1055, "Street Site55" },
                    { 56, "City Site56", "Belgium", "Groundplan Site56", 56, "Site56", 1056, "Street Site56" },
                    { 57, "City Site57", "Belgium", "Groundplan Site57", 57, "Site57", 1057, "Street Site57" },
                    { 58, "City Site58", "Belgium", "Groundplan Site58", 58, "Site58", 1058, "Street Site58" },
                    { 59, "City Site59", "Belgium", "Groundplan Site59", 59, "Site59", 1059, "Street Site59" },
                    { 60, "City Site60", "Belgium", "Groundplan Site60", 60, "Site60", 1060, "Street Site60" },
                    { 61, "City Site61", "Belgium", "Groundplan Site61", 61, "Site61", 1061, "Street Site61" },
                    { 62, "City Site62", "Belgium", "Groundplan Site62", 62, "Site62", 1062, "Street Site62" },
                    { 63, "City Site63", "Belgium", "Groundplan Site63", 63, "Site63", 1063, "Street Site63" },
                    { 64, "City Site64", "Belgium", "Groundplan Site64", 64, "Site64", 1064, "Street Site64" },
                    { 65, "City Site65", "Belgium", "Groundplan Site65", 65, "Site65", 1065, "Street Site65" },
                    { 66, "City Site66", "Belgium", "Groundplan Site66", 66, "Site66", 1066, "Street Site66" },
                    { 67, "City Site67", "Belgium", "Groundplan Site67", 67, "Site67", 1067, "Street Site67" },
                    { 68, "City Site68", "Belgium", "Groundplan Site68", 68, "Site68", 1068, "Street Site68" },
                    { 69, "City Site69", "Belgium", "Groundplan Site69", 69, "Site69", 1069, "Street Site69" },
                    { 70, "City Site70", "Belgium", "Groundplan Site70", 70, "Site70", 1070, "Street Site70" },
                    { 71, "City Site71", "Belgium", "Groundplan Site71", 71, "Site71", 1071, "Street Site71" },
                    { 72, "City Site72", "Belgium", "Groundplan Site72", 72, "Site72", 1072, "Street Site72" },
                    { 73, "City Site73", "Belgium", "Groundplan Site73", 73, "Site73", 1073, "Street Site73" },
                    { 74, "City Site74", "Belgium", "Groundplan Site74", 74, "Site74", 1074, "Street Site74" },
                    { 75, "City Site75", "Belgium", "Groundplan Site75", 75, "Site75", 1075, "Street Site75" },
                    { 76, "City Site76", "Belgium", "Groundplan Site76", 76, "Site76", 1076, "Street Site76" },
                    { 77, "City Site77", "Belgium", "Groundplan Site77", 77, "Site77", 1077, "Street Site77" },
                    { 78, "City Site78", "Belgium", "Groundplan Site78", 78, "Site78", 1078, "Street Site78" },
                    { 79, "City Site79", "Belgium", "Groundplan Site79", 79, "Site79", 1079, "Street Site79" },
                    { 80, "City Site80", "Belgium", "Groundplan Site80", 80, "Site80", 1080, "Street Site80" },
                    { 81, "City Site81", "Belgium", "Groundplan Site81", 81, "Site81", 1081, "Street Site81" },
                    { 82, "City Site82", "Belgium", "Groundplan Site82", 82, "Site82", 1082, "Street Site82" },
                    { 83, "City Site83", "Belgium", "Groundplan Site83", 83, "Site83", 1083, "Street Site83" },
                    { 84, "City Site84", "Belgium", "Groundplan Site84", 84, "Site84", 1084, "Street Site84" },
                    { 85, "City Site85", "Belgium", "Groundplan Site85", 85, "Site85", 1085, "Street Site85" },
                    { 86, "City Site86", "Belgium", "Groundplan Site86", 86, "Site86", 1086, "Street Site86" },
                    { 87, "City Site87", "Belgium", "Groundplan Site87", 87, "Site87", 1087, "Street Site87" },
                    { 88, "City Site88", "Belgium", "Groundplan Site88", 88, "Site88", 1088, "Street Site88" },
                    { 89, "City Site89", "Belgium", "Groundplan Site89", 89, "Site89", 1089, "Street Site89" },
                    { 90, "City Site90", "Belgium", "Groundplan Site90", 90, "Site90", 1090, "Street Site90" },
                    { 91, "City Site91", "Belgium", "Groundplan Site91", 91, "Site91", 1091, "Street Site91" },
                    { 92, "City Site92", "Belgium", "Groundplan Site92", 92, "Site92", 1092, "Street Site92" },
                    { 93, "City Site93", "Belgium", "Groundplan Site93", 93, "Site93", 1093, "Street Site93" },
                    { 94, "City Site94", "Belgium", "Groundplan Site94", 94, "Site94", 1094, "Street Site94" },
                    { 95, "City Site95", "Belgium", "Groundplan Site95", 95, "Site95", 1095, "Street Site95" },
                    { 96, "City Site96", "Belgium", "Groundplan Site96", 96, "Site96", 1096, "Street Site96" },
                    { 97, "City Site97", "Belgium", "Groundplan Site97", 97, "Site97", 1097, "Street Site97" },
                    { 98, "City Site98", "Belgium", "Groundplan Site98", 98, "Site98", 1098, "Street Site98" },
                    { 99, "City Site99", "Belgium", "Groundplan Site99", 99, "Site99", 1099, "Street Site99" },
                    { 100, "City Site100", "Belgium", "Groundplan Site100", 100, "Site100", 1100, "Street Site100" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.InsertData(
                table: "PlantationSite",
                columns: new[] { "Id", "City", "Country", "GroundPlan", "HouseNumber", "Name", "PostalCode", "Street" },
                values: new object[,]
                {
                    { -11, "City Site 10", "Belgium", "Groundplan Site 10", 10, "Site 10", 1010, "Street Site 10" },
                    { -10, "City Site 9", "Belgium", "Groundplan Site 9", 9, "Site 9", 1009, "Street Site 9" },
                    { -9, "City Site 8", "Belgium", "Groundplan Site 8", 8, "Site 8", 1008, "Street Site 8" },
                    { -8, "City Site 7", "Belgium", "Groundplan Site 7", 7, "Site 7", 1007, "Street Site 7" },
                    { -7, "City Site 6", "Belgium", "Groundplan Site 6", 6, "Site 6", 1006, "Street Site 6" },
                    { -6, "City Site 5", "Belgium", "Groundplan Site 5", 5, "Site 5", 1005, "Street Site 5" },
                    { -5, "City Site 4", "Belgium", "Groundplan Site 4", 4, "Site 4", 1004, "Street Site 4" },
                    { -4, "City Site 3", "Belgium", "Groundplan Site 3", 3, "Site 3", 1003, "Street Site 3" },
                    { -3, "City Site 2", "Belgium", "Groundplan Site 2", 2, "Site 2", 1002, "Street Site 2" },
                    { -2, "City Site 1", "Belgium", "Groundplan Site 1", 1, "Site 1", 1001, "Street Site 1" },
                    { -1, "City Site 0", "Belgium", "Groundplan Site 0", 0, "Site 0", 1000, "Street Site 0" }
                });
        }
    }
}
