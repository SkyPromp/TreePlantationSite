using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AP.BTP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class followTaskItemRestrictionsBugfix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 173);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 174);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 175);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 176);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 177);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 178);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 179);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 180);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 181);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 182);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 183);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 184);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 185);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 186);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 187);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 188);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 189);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 190);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 191);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 192);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 193);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 194);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 195);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 196);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 197);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 198);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 199);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 200);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 201);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 202);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 203);

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Monitor de bodemkwaliteit en pH rondom de bomen.", 65, 7, "Bodemkwaliteit monitoren" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Oogst vruchten of zaden van volwassen bomen.", 195, 7, "Oogsten van vruchten of zaden" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Oogst vruchten of zaden van volwassen bomen.", 215, 8, "Oogsten van vruchten of zaden" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Voer een veiligheidscontrole uit en verwijder gevaarlijke takken.", 146, 8, "Veiligheidstakcontrole" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Verwijder invasieve planten of onkruid bij de wortels van de boom.", 31, 9, "Onkruid verwijderen bij wortels" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Monitor de bodemkwaliteit en pH rondom de bomen.", 157, 9, "Bodemkwaliteit monitoren" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Oogst vruchten of zaden van volwassen bomen.", 134, 9, "Oogsten van vruchten of zaden" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "DurationInMinutes", "TaskListId" },
                values: new object[] { 75, 10 });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "DurationInMinutes", "TaskListId" },
                values: new object[] { 76, 10 });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "DurationInMinutes", "TaskListId" },
                values: new object[] { 54, 10 });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Geef water aan pas geplante bomen om de groei te ondersteunen.", 118, 10, "Water geven aan jonge bomen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Geef water aan pas geplante bomen om de groei te ondersteunen.", 86, 11, "Water geven aan jonge bomen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Breng mulch aan rond de boom om vocht vast te houden en onkruid te voorkomen.", 117, 11, "Mulchen rondom bomen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "Description", "DurationInMinutes", "Title" },
                values: new object[] { "Controleer en herstel boomsteunen of palen indien nodig.", 117, "Controle van boomsteunen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Geef water aan pas geplante bomen om de groei te ondersteunen.", 340, 14, "Water geven aan jonge bomen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Breng organische mest rond de basis van de boom aan.", 228, 15, "Bemesten van bomen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Controleer bomen op ziektes of plagen.", 47, 15, "Controle op ziektes en plagen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "DurationInMinutes", "TaskListId" },
                values: new object[] { 86, 16 });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "DurationInMinutes", "TaskListId" },
                values: new object[] { 34, 16 });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Verwijder invasieve planten of onkruid bij de wortels van de boom.", 40, 16, "Onkruid verwijderen bij wortels" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Monitor de bodemkwaliteit en pH rondom de bomen.", 49, 16, "Bodemkwaliteit monitoren" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Geef water aan pas geplante bomen om de groei te ondersteunen.", 276, 17, "Water geven aan jonge bomen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Voer een veiligheidscontrole uit en verwijder gevaarlijke takken.", 213, 18, "Veiligheidstakcontrole" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Snoei dode of overgroeide takken om de boom gezond te houden.", 196, 18, "Snoeien van takken" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Breng mulch aan rond de boom om vocht vast te houden en onkruid te voorkomen.", 98, 21, "Mulchen rondom bomen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Controleer en herstel boomsteunen of palen indien nodig.", 114, 21, "Controle van boomsteunen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Verwijder invasieve planten of onkruid bij de wortels van de boom.", 40, 21, "Onkruid verwijderen bij wortels" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Monitor de bodemkwaliteit en pH rondom de bomen.", 73, 21, "Bodemkwaliteit monitoren" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "DurationInMinutes", "TaskListId" },
                values: new object[] { 128, 22 });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Breng organische mest rond de basis van de boom aan.", 105, 22, "Bemesten van bomen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Geef water aan pas geplante bomen om de groei te ondersteunen.", 31, 23, "Water geven aan jonge bomen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Breng mulch aan rond de boom om vocht vast te houden en onkruid te voorkomen.", 159, 23, "Mulchen rondom bomen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Oogst vruchten of zaden van volwassen bomen.", 98, 24, "Oogsten van vruchten of zaden" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Voer een veiligheidscontrole uit en verwijder gevaarlijke takken.", 37, 24, "Veiligheidstakcontrole" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Snoei dode of overgroeide takken om de boom gezond te houden.", 32, 24, "Snoeien van takken" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Breng organische mest rond de basis van de boom aan.", 108, 24, "Bemesten van bomen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "DurationInMinutes", "TaskListId" },
                values: new object[] { 243, 25 });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Geef water aan pas geplante bomen om de groei te ondersteunen.", 146, 28, "Water geven aan jonge bomen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Breng mulch aan rond de boom om vocht vast te houden en onkruid te voorkomen.", 93, 28, "Mulchen rondom bomen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Breng organische mest rond de basis van de boom aan.", 147, 29, "Bemesten van bomen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "DurationInMinutes", "TaskListId" },
                values: new object[] { 66, 30 });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Oogst vruchten of zaden van volwassen bomen.", 58, 30, "Oogsten van vruchten of zaden" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Voer een veiligheidscontrole uit en verwijder gevaarlijke takken.", 58, 31, "Veiligheidstakcontrole" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Snoei dode of overgroeide takken om de boom gezond te houden.", 117, 31, "Snoeien van takken" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Breng organische mest rond de basis van de boom aan.", 87, 31, "Bemesten van bomen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Controleer bomen op ziektes of plagen.", 106, 31, "Controle op ziektes en plagen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "DurationInMinutes", "TaskListId" },
                values: new object[] { 99, 32 });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "DurationInMinutes", "TaskListId" },
                values: new object[] { 118, 32 });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Breng organische mest rond de basis van de boom aan.", 50, 32, "Bemesten van bomen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 61,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Controleer bomen op ziektes of plagen.", 47, 35, "Controle op ziektes en plagen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Geef water aan pas geplante bomen om de groei te ondersteunen.", 223, 35, "Water geven aan jonge bomen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Oogst vruchten of zaden van volwassen bomen.", 238, 36, "Oogsten van vruchten of zaden" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Voer een veiligheidscontrole uit en verwijder gevaarlijke takken.", 55, 36, "Veiligheidstakcontrole" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Verwijder invasieve planten of onkruid bij de wortels van de boom.", 111, 37, "Onkruid verwijderen bij wortels" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Monitor de bodemkwaliteit en pH rondom de bomen.", 34, 37, "Bodemkwaliteit monitoren" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 67,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Oogst vruchten of zaden van volwassen bomen.", 58, 37, "Oogsten van vruchten of zaden" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 68,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Voer een veiligheidscontrole uit en verwijder gevaarlijke takken.", 48, 37, "Veiligheidstakcontrole" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 69,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Breng organische mest rond de basis van de boom aan.", 40, 38, "Bemesten van bomen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Controleer bomen op ziektes of plagen.", 117, 38, "Controle op ziektes en plagen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 71,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Geef water aan pas geplante bomen om de groei te ondersteunen.", 112, 38, "Water geven aan jonge bomen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Snoei dode of overgroeide takken om de boom gezond te houden.", 285, 39, "Snoeien van takken" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 73,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Controleer en herstel boomsteunen of palen indien nodig.", 336, 42, "Controle van boomsteunen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 74,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Geef water aan pas geplante bomen om de groei te ondersteunen.", 141, 43, "Water geven aan jonge bomen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 75,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Breng mulch aan rond de boom om vocht vast te houden en onkruid te voorkomen.", 66, 43, "Mulchen rondom bomen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 76,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Oogst vruchten of zaden van volwassen bomen.", 35, 44, "Oogsten van vruchten of zaden" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 77,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Voer een veiligheidscontrole uit en verwijder gevaarlijke takken.", 61, 44, "Veiligheidstakcontrole" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 78,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Snoei dode of overgroeide takken om de boom gezond te houden.", 103, 44, "Snoeien van takken" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 79,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Breng organische mest rond de basis van de boom aan.", 92, 44, "Bemesten van bomen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 80,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Oogst vruchten of zaden van volwassen bomen.", 212, 45, "Oogsten van vruchten of zaden" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 81,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Voer een veiligheidscontrole uit en verwijder gevaarlijke takken.", 128, 45, "Veiligheidstakcontrole" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 82,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Monitor de bodemkwaliteit en pH rondom de bomen.", 197, 46, "Bodemkwaliteit monitoren" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 83,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Oogst vruchten of zaden van volwassen bomen.", 109, 46, "Oogsten van vruchten of zaden" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 84,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Geef water aan pas geplante bomen om de groei te ondersteunen.", 216, 49, "Water geven aan jonge bomen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 85,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Breng mulch aan rond de boom om vocht vast te houden en onkruid te voorkomen.", 39, 49, "Mulchen rondom bomen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 86,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Voer een veiligheidscontrole uit en verwijder gevaarlijke takken.", 141, 50, "Veiligheidstakcontrole" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 87,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Snoei dode of overgroeide takken om de boom gezond te houden.", 69, 50, "Snoeien van takken" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 88,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Breng organische mest rond de basis van de boom aan.", 142, 50, "Bemesten van bomen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 89,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Breng mulch aan rond de boom om vocht vast te houden en onkruid te voorkomen.", 86, 51, "Mulchen rondom bomen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 90,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Controleer en herstel boomsteunen of palen indien nodig.", 98, 51, "Controle van boomsteunen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 91,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Verwijder invasieve planten of onkruid bij de wortels van de boom.", 74, 51, "Onkruid verwijderen bij wortels" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 92,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Oogst vruchten of zaden van volwassen bomen.", 97, 52, "Oogsten van vruchten of zaden" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 93,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Voer een veiligheidscontrole uit en verwijder gevaarlijke takken.", 98, 52, "Veiligheidstakcontrole" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 94,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Oogst vruchten of zaden van volwassen bomen.", 63, 53, "Oogsten van vruchten of zaden" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 95,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Voer een veiligheidscontrole uit en verwijder gevaarlijke takken.", 156, 53, "Veiligheidstakcontrole" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 96,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Snoei dode of overgroeide takken om de boom gezond te houden.", 71, 53, "Snoeien van takken" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 97,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Oogst vruchten of zaden van volwassen bomen.", 76, 56, "Oogsten van vruchten of zaden" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 98,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Voer een veiligheidscontrole uit en verwijder gevaarlijke takken.", 122, 56, "Veiligheidstakcontrole" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 99,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Breng organische mest rond de basis van de boom aan.", 51, 57, "Bemesten van bomen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 100,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Controleer bomen op ziektes of plagen.", 30, 57, "Controle op ziektes en plagen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 101,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Geef water aan pas geplante bomen om de groei te ondersteunen.", 43, 57, "Water geven aan jonge bomen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 102,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Breng mulch aan rond de boom om vocht vast te houden en onkruid te voorkomen.", 55, 57, "Mulchen rondom bomen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 103,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Breng organische mest rond de basis van de boom aan.", 38, 58, "Bemesten van bomen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 104,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Controleer bomen op ziektes of plagen.", 74, 58, "Controle op ziektes en plagen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 105,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Geef water aan pas geplante bomen om de groei te ondersteunen.", 76, 58, "Water geven aan jonge bomen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 106,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Breng mulch aan rond de boom om vocht vast te houden en onkruid te voorkomen.", 103, 58, "Mulchen rondom bomen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 107,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Breng mulch aan rond de boom om vocht vast te houden en onkruid te voorkomen.", 86, 59, "Mulchen rondom bomen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 108,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Controleer en herstel boomsteunen of palen indien nodig.", 151, 59, "Controle van boomsteunen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 109,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Verwijder invasieve planten of onkruid bij de wortels van de boom.", 151, 59, "Onkruid verwijderen bij wortels" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 110,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Voer een veiligheidscontrole uit en verwijder gevaarlijke takken.", 41, 60, "Veiligheidstakcontrole" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 111,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Snoei dode of overgroeide takken om de boom gezond te houden.", 116, 60, "Snoeien van takken" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 112,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Controleer en herstel boomsteunen of palen indien nodig.", 428, 63, "Controle van boomsteunen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 113,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Snoei dode of overgroeide takken om de boom gezond te houden.", 78, 64, "Snoeien van takken" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 114,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Breng organische mest rond de basis van de boom aan.", 92, 64, "Bemesten van bomen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 115,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Controleer bomen op ziektes of plagen.", 114, 64, "Controle op ziektes en plagen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 116,
                columns: new[] { "DurationInMinutes", "TaskListId" },
                values: new object[] { 148, 65 });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 117,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Geef water aan pas geplante bomen om de groei te ondersteunen.", 77, 66, "Water geven aan jonge bomen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 118,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Breng mulch aan rond de boom om vocht vast te houden en onkruid te voorkomen.", 155, 66, "Mulchen rondom bomen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 119,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Breng organische mest rond de basis van de boom aan.", 152, 67, "Bemesten van bomen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 120,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Controleer bomen op ziektes of plagen.", 98, 67, "Controle op ziektes en plagen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 121,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Breng organische mest rond de basis van de boom aan.", 30, 70, "Bemesten van bomen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 122,
                columns: new[] { "DurationInMinutes", "TaskListId" },
                values: new object[] { 45, 70 });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 123,
                columns: new[] { "DurationInMinutes", "TaskListId" },
                values: new object[] { 146, 70 });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 124,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Snoei dode of overgroeide takken om de boom gezond te houden.", 334, 71, "Snoeien van takken" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 125,
                columns: new[] { "DurationInMinutes", "TaskListId" },
                values: new object[] { 166, 72 });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 126,
                columns: new[] { "DurationInMinutes", "TaskListId" },
                values: new object[] { 48, 72 });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 127,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Snoei dode of overgroeide takken om de boom gezond te houden.", 76, 73, "Snoeien van takken" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 128,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Breng organische mest rond de basis van de boom aan.", 37, 73, "Bemesten van bomen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 129,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Controleer bomen op ziektes of plagen.", 40, 73, "Controle op ziektes en plagen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 130,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Geef water aan pas geplante bomen om de groei te ondersteunen.", 33, 73, "Water geven aan jonge bomen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 131,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Breng mulch aan rond de boom om vocht vast te houden en onkruid te voorkomen.", 399, 74, "Mulchen rondom bomen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 132,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Verwijder invasieve planten of onkruid bij de wortels van de boom.", 78, 77, "Onkruid verwijderen bij wortels" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 133,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Monitor de bodemkwaliteit en pH rondom de bomen.", 139, 77, "Bodemkwaliteit monitoren" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 134,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Snoei dode of overgroeide takken om de boom gezond te houden.", 73, 78, "Snoeien van takken" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 135,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Breng organische mest rond de basis van de boom aan.", 114, 78, "Bemesten van bomen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 136,
                columns: new[] { "DurationInMinutes", "TaskListId" },
                values: new object[] { 90, 79 });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 137,
                columns: new[] { "DurationInMinutes", "TaskListId" },
                values: new object[] { 30, 79 });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 138,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Geef water aan pas geplante bomen om de groei te ondersteunen.", 63, 79, "Water geven aan jonge bomen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 139,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Breng mulch aan rond de boom om vocht vast te houden en onkruid te voorkomen.", 52, 80, "Mulchen rondom bomen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 140,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Controleer en herstel boomsteunen of palen indien nodig.", 151, 80, "Controle van boomsteunen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 141,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Verwijder invasieve planten of onkruid bij de wortels van de boom.", 130, 80, "Onkruid verwijderen bij wortels" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 142,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Verwijder invasieve planten of onkruid bij de wortels van de boom.", 42, 81, "Onkruid verwijderen bij wortels" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 143,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Monitor de bodemkwaliteit en pH rondom de bomen.", 103, 81, "Bodemkwaliteit monitoren" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 144,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Oogst vruchten of zaden van volwassen bomen.", 57, 81, "Oogsten van vruchten of zaden" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 145,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Voer een veiligheidscontrole uit en verwijder gevaarlijke takken.", 88, 81, "Veiligheidstakcontrole" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 146,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Breng organische mest rond de basis van de boom aan.", 275, 84, "Bemesten van bomen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 147,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Geef water aan pas geplante bomen om de groei te ondersteunen.", 157, 85, "Water geven aan jonge bomen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 148,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Breng mulch aan rond de boom om vocht vast te houden en onkruid te voorkomen.", 104, 85, "Mulchen rondom bomen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 149,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Controleer en herstel boomsteunen of palen indien nodig.", 92, 85, "Controle van boomsteunen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 150,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Breng organische mest rond de basis van de boom aan.", 41, 86, "Bemesten van bomen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 151,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Controleer bomen op ziektes of plagen.", 59, 86, "Controle op ziektes en plagen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 152,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Geef water aan pas geplante bomen om de groei te ondersteunen.", 69, 86, "Water geven aan jonge bomen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 153,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Breng mulch aan rond de boom om vocht vast te houden en onkruid te voorkomen.", 90, 86, "Mulchen rondom bomen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 154,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Oogst vruchten of zaden van volwassen bomen.", 52, 87, "Oogsten van vruchten of zaden" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 155,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Oogst vruchten of zaden van volwassen bomen.", 235, 88, "Oogsten van vruchten of zaden" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 156,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Voer een veiligheidscontrole uit en verwijder gevaarlijke takken.", 118, 91, "Veiligheidstakcontrole" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 157,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Snoei dode of overgroeide takken om de boom gezond te houden.", 73, 91, "Snoeien van takken" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 158,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Breng organische mest rond de basis van de boom aan.", 62, 91, "Bemesten van bomen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 159,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Controleer bomen op ziektes of plagen.", 81, 91, "Controle op ziektes en plagen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 160,
                columns: new[] { "DurationInMinutes", "TaskListId" },
                values: new object[] { 206, 92 });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 161,
                columns: new[] { "DurationInMinutes", "TaskListId" },
                values: new object[] { 236, 93 });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 162,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Voer een veiligheidscontrole uit en verwijder gevaarlijke takken.", 108, 94, "Veiligheidstakcontrole" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 163,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Snoei dode of overgroeide takken om de boom gezond te houden.", 64, 94, "Snoeien van takken" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 164,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Breng organische mest rond de basis van de boom aan.", 30, 94, "Bemesten van bomen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 165,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Geef water aan pas geplante bomen om de groei te ondersteunen.", 384, 95, "Water geven aan jonge bomen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 166,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Breng mulch aan rond de boom om vocht vast te houden en onkruid te voorkomen.", 108, 98, "Mulchen rondom bomen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 167,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Controleer en herstel boomsteunen of palen indien nodig.", 83, 98, "Controle van boomsteunen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 168,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Verwijder invasieve planten of onkruid bij de wortels van de boom.", 75, 98, "Onkruid verwijderen bij wortels" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 169,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Controleer bomen op ziektes of plagen.", 434, 99, "Controle op ziektes en plagen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 170,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Breng organische mest rond de basis van de boom aan.", 366, 100, "Bemesten van bomen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 171,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Voer een veiligheidscontrole uit en verwijder gevaarlijke takken.", 47, 101, "Veiligheidstakcontrole" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 172,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Snoei dode of overgroeide takken om de boom gezond te houden.", 54, 101, "Snoeien van takken" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Voer een veiligheidscontrole uit en verwijder gevaarlijke takken.", 42, 5, "Veiligheidstakcontrole" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Snoei dode of overgroeide takken om de boom gezond te houden.", 50, 5, "Snoeien van takken" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Breng organische mest rond de basis van de boom aan.", 79, 5, "Bemesten van bomen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Geef water aan pas geplante bomen om de groei te ondersteunen.", 103, 7, "Water geven aan jonge bomen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Breng mulch aan rond de boom om vocht vast te houden en onkruid te voorkomen.", 108, 7, "Mulchen rondom bomen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Controleer en herstel boomsteunen of palen indien nodig.", 79, 7, "Controle van boomsteunen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Verwijder invasieve planten of onkruid bij de wortels van de boom.", 93, 7, "Onkruid verwijderen bij wortels" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "DurationInMinutes", "TaskListId" },
                values: new object[] { 157, 8 });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "DurationInMinutes", "TaskListId" },
                values: new object[] { 134, 8 });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "DurationInMinutes", "TaskListId" },
                values: new object[] { 140, 8 });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Controleer en herstel boomsteunen of palen indien nodig.", 265, 9, "Controle van boomsteunen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Voer een veiligheidscontrole uit en verwijder gevaarlijke takken.", 174, 10, "Veiligheidstakcontrole" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Snoei dode of overgroeide takken om de boom gezond te houden.", 110, 10, "Snoeien van takken" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "Description", "DurationInMinutes", "Title" },
                values: new object[] { "Verwijder invasieve planten of onkruid bij de wortels van de boom.", 171, "Onkruid verwijderen bij wortels" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Monitor de bodemkwaliteit en pH rondom de bomen.", 128, 11, "Bodemkwaliteit monitoren" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Geef water aan pas geplante bomen om de groei te ondersteunen.", 266, 12, "Water geven aan jonge bomen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Geef water aan pas geplante bomen om de groei te ondersteunen.", 50, 14, "Water geven aan jonge bomen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "DurationInMinutes", "TaskListId" },
                values: new object[] { 152, 14 });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "DurationInMinutes", "TaskListId" },
                values: new object[] { 40, 14 });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Breng mulch aan rond de boom om vocht vast te houden en onkruid te voorkomen.", 86, 15, "Mulchen rondom bomen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Controleer en herstel boomsteunen of palen indien nodig.", 34, 15, "Controle van boomsteunen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Verwijder invasieve planten of onkruid bij de wortels van de boom.", 40, 15, "Onkruid verwijderen bij wortels" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Monitor de bodemkwaliteit en pH rondom de bomen.", 49, 15, "Bodemkwaliteit monitoren" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Geef water aan pas geplante bomen om de groei te ondersteunen.", 276, 16, "Water geven aan jonge bomen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Voer een veiligheidscontrole uit en verwijder gevaarlijke takken.", 213, 17, "Veiligheidstakcontrole" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Snoei dode of overgroeide takken om de boom gezond te houden.", 196, 17, "Snoeien van takken" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Breng organische mest rond de basis van de boom aan.", 110, 18, "Bemesten van bomen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Voer een veiligheidscontrole uit en verwijder gevaarlijke takken.", 114, 19, "Veiligheidstakcontrole" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "DurationInMinutes", "TaskListId" },
                values: new object[] { 191, 19 });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Geef water aan pas geplante bomen om de groei te ondersteunen.", 43, 21, "Water geven aan jonge bomen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Breng mulch aan rond de boom om vocht vast te houden en onkruid te voorkomen.", 128, 21, "Mulchen rondom bomen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Geef water aan pas geplante bomen om de groei te ondersteunen.", 107, 22, "Water geven aan jonge bomen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Breng mulch aan rond de boom om vocht vast te houden en onkruid te voorkomen.", 31, 22, "Mulchen rondom bomen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Oogst vruchten of zaden van volwassen bomen.", 140, 23, "Oogsten van vruchten of zaden" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Voer een veiligheidscontrole uit en verwijder gevaarlijke takken.", 129, 23, "Veiligheidstakcontrole" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Snoei dode of overgroeide takken om de boom gezond te houden.", 41, 23, "Snoeien van takken" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "DurationInMinutes", "TaskListId" },
                values: new object[] { 131, 24 });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Breng mulch aan rond de boom om vocht vast te houden en onkruid te voorkomen.", 56, 25, "Mulchen rondom bomen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Controleer en herstel boomsteunen of palen indien nodig.", 40, 25, "Controle van boomsteunen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Verwijder invasieve planten of onkruid bij de wortels van de boom.", 41, 25, "Onkruid verwijderen bij wortels" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "DurationInMinutes", "TaskListId" },
                values: new object[] { 63, 25 });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Geef water aan pas geplante bomen om de groei te ondersteunen.", 146, 26, "Water geven aan jonge bomen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Breng mulch aan rond de boom om vocht vast te houden en onkruid te voorkomen.", 93, 26, "Mulchen rondom bomen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Breng mulch aan rond de boom om vocht vast te houden en onkruid te voorkomen.", 187, 28, "Mulchen rondom bomen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Controleer en herstel boomsteunen of palen indien nodig.", 66, 28, "Controle van boomsteunen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Oogst vruchten of zaden van volwassen bomen.", 477, 29, "Oogsten van vruchten of zaden" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "DurationInMinutes", "TaskListId" },
                values: new object[] { 166, 30 });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "DurationInMinutes", "TaskListId" },
                values: new object[] { 208, 30 });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Voer een veiligheidscontrole uit en verwijder gevaarlijke takken.", 99, 31, "Veiligheidstakcontrole" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 61,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Snoei dode of overgroeide takken om de boom gezond te houden.", 118, 31, "Snoeien van takken" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Breng organische mest rond de basis van de boom aan.", 50, 31, "Bemesten van bomen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Snoei dode of overgroeide takken om de boom gezond te houden.", 88, 32, "Snoeien van takken" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Controleer bomen op ziektes of plagen.", 121, 33, "Controle op ziektes en plagen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Oogst vruchten of zaden van volwassen bomen.", 238, 35, "Oogsten van vruchten of zaden" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Voer een veiligheidscontrole uit en verwijder gevaarlijke takken.", 55, 35, "Veiligheidstakcontrole" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 67,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Verwijder invasieve planten of onkruid bij de wortels van de boom.", 111, 36, "Onkruid verwijderen bij wortels" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 68,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Monitor de bodemkwaliteit en pH rondom de bomen.", 34, 36, "Bodemkwaliteit monitoren" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 69,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Oogst vruchten of zaden van volwassen bomen.", 58, 36, "Oogsten van vruchten of zaden" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Voer een veiligheidscontrole uit en verwijder gevaarlijke takken.", 48, 36, "Veiligheidstakcontrole" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 71,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Breng organische mest rond de basis van de boom aan.", 40, 37, "Bemesten van bomen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Controleer bomen op ziektes of plagen.", 117, 37, "Controle op ziektes en plagen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 73,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Geef water aan pas geplante bomen om de groei te ondersteunen.", 112, 37, "Water geven aan jonge bomen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 74,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Snoei dode of overgroeide takken om de boom gezond te houden.", 285, 38, "Snoeien van takken" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 75,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Controleer bomen op ziektes of plagen.", 309, 39, "Controle op ziektes en plagen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 76,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Breng organische mest rond de basis van de boom aan.", 105, 40, "Bemesten van bomen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 77,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Controleer bomen op ziektes of plagen.", 118, 40, "Controle op ziektes en plagen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 78,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Geef water aan pas geplante bomen om de groei te ondersteunen.", 70, 40, "Water geven aan jonge bomen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 79,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Voer een veiligheidscontrole uit en verwijder gevaarlijke takken.", 422, 42, "Veiligheidstakcontrole" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 80,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Geef water aan pas geplante bomen om de groei te ondersteunen.", 401, 43, "Water geven aan jonge bomen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 81,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Geef water aan pas geplante bomen om de groei te ondersteunen.", 140, 44, "Water geven aan jonge bomen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 82,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Breng mulch aan rond de boom om vocht vast te houden en onkruid te voorkomen.", 142, 44, "Mulchen rondom bomen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 83,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Controleer en herstel boomsteunen of palen indien nodig.", 90, 44, "Controle van boomsteunen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 84,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Monitor de bodemkwaliteit en pH rondom de bomen.", 197, 45, "Bodemkwaliteit monitoren" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 85,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Oogst vruchten of zaden van volwassen bomen.", 109, 45, "Oogsten van vruchten of zaden" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 86,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Monitor de bodemkwaliteit en pH rondom de bomen.", 95, 46, "Bodemkwaliteit monitoren" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 87,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Oogst vruchten of zaden van volwassen bomen.", 40, 46, "Oogsten van vruchten of zaden" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 88,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Voer een veiligheidscontrole uit en verwijder gevaarlijke takken.", 73, 46, "Veiligheidstakcontrole" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 89,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Oogst vruchten of zaden van volwassen bomen.", 39, 47, "Oogsten van vruchten of zaden" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 90,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Voer een veiligheidscontrole uit en verwijder gevaarlijke takken.", 181, 47, "Veiligheidstakcontrole" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 91,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Oogst vruchten of zaden van volwassen bomen.", 164, 49, "Oogsten van vruchten of zaden" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 92,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Voer een veiligheidscontrole uit en verwijder gevaarlijke takken.", 115, 49, "Veiligheidstakcontrole" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 93,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Controleer en herstel boomsteunen of palen indien nodig.", 102, 50, "Controle van boomsteunen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 94,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Verwijder invasieve planten of onkruid bij de wortels van de boom.", 108, 50, "Onkruid verwijderen bij wortels" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 95,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Geef water aan pas geplante bomen om de groei te ondersteunen.", 59, 51, "Water geven aan jonge bomen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 96,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Breng mulch aan rond de boom om vocht vast te houden en onkruid te voorkomen.", 90, 51, "Mulchen rondom bomen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 97,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Controleer en herstel boomsteunen of palen indien nodig.", 103, 51, "Controle van boomsteunen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 98,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Verwijder invasieve planten of onkruid bij de wortels van de boom.", 52, 51, "Onkruid verwijderen bij wortels" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 99,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Geef water aan pas geplante bomen om de groei te ondersteunen.", 64, 52, "Water geven aan jonge bomen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 100,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Breng mulch aan rond de boom om vocht vast te houden en onkruid te voorkomen.", 43, 52, "Mulchen rondom bomen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 101,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Controleer en herstel boomsteunen of palen indien nodig.", 38, 52, "Controle van boomsteunen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 102,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Verwijder invasieve planten of onkruid bij de wortels van de boom.", 114, 52, "Onkruid verwijderen bij wortels" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 103,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Oogst vruchten of zaden van volwassen bomen.", 76, 53, "Oogsten van vruchten of zaden" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 104,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Voer een veiligheidscontrole uit en verwijder gevaarlijke takken.", 122, 53, "Veiligheidstakcontrole" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 105,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Breng organische mest rond de basis van de boom aan.", 51, 54, "Bemesten van bomen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 106,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Controleer bomen op ziektes of plagen.", 30, 54, "Controle op ziektes en plagen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 107,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Geef water aan pas geplante bomen om de groei te ondersteunen.", 43, 54, "Water geven aan jonge bomen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 108,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Breng mulch aan rond de boom om vocht vast te houden en onkruid te voorkomen.", 55, 54, "Mulchen rondom bomen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 109,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Breng mulch aan rond de boom om vocht vast te houden en onkruid te voorkomen.", 264, 56, "Mulchen rondom bomen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 110,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Verwijder invasieve planten of onkruid bij de wortels van de boom.", 69, 57, "Onkruid verwijderen bij wortels" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 111,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Monitor de bodemkwaliteit en pH rondom de bomen.", 68, 57, "Bodemkwaliteit monitoren" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 112,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Oogst vruchten of zaden van volwassen bomen.", 113, 57, "Oogsten van vruchten of zaden" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 113,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Voer een veiligheidscontrole uit en verwijder gevaarlijke takken.", 114, 57, "Veiligheidstakcontrole" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 114,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Voer een veiligheidscontrole uit en verwijder gevaarlijke takken.", 41, 58, "Veiligheidstakcontrole" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 115,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Snoei dode of overgroeide takken om de boom gezond te houden.", 116, 58, "Snoeien van takken" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 116,
                columns: new[] { "DurationInMinutes", "TaskListId" },
                values: new object[] { 398, 59 });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 117,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Snoei dode of overgroeide takken om de boom gezond te houden.", 136, 60, "Snoeien van takken" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 118,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Breng organische mest rond de basis van de boom aan.", 215, 60, "Bemesten van bomen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 119,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Snoei dode of overgroeide takken om de boom gezond te houden.", 78, 61, "Snoeien van takken" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 120,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Breng organische mest rond de basis van de boom aan.", 92, 61, "Bemesten van bomen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 121,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Controleer bomen op ziektes of plagen.", 114, 61, "Controle op ziektes en plagen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 122,
                columns: new[] { "DurationInMinutes", "TaskListId" },
                values: new object[] { 99, 63 });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 123,
                columns: new[] { "DurationInMinutes", "TaskListId" },
                values: new object[] { 77, 63 });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 124,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Geef water aan pas geplante bomen om de groei te ondersteunen.", 52, 64, "Water geven aan jonge bomen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 125,
                columns: new[] { "DurationInMinutes", "TaskListId" },
                values: new object[] { 105, 64 });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 126,
                columns: new[] { "DurationInMinutes", "TaskListId" },
                values: new object[] { 72, 64 });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 127,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Breng organische mest rond de basis van de boom aan.", 114, 65, "Bemesten van bomen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 128,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Controleer bomen op ziektes of plagen.", 150, 65, "Controle op ziektes en plagen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 129,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Geef water aan pas geplante bomen om de groei te ondersteunen.", 122, 65, "Water geven aan jonge bomen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 130,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Snoei dode of overgroeide takken om de boom gezond te houden.", 84, 66, "Snoeien van takken" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 131,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Breng organische mest rond de basis van de boom aan.", 32, 67, "Bemesten van bomen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 132,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Controleer bomen op ziektes of plagen.", 90, 67, "Controle op ziektes en plagen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 133,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Geef water aan pas geplante bomen om de groei te ondersteunen.", 73, 67, "Water geven aan jonge bomen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 134,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Breng mulch aan rond de boom om vocht vast te houden en onkruid te voorkomen.", 66, 67, "Mulchen rondom bomen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 135,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Snoei dode of overgroeide takken om de boom gezond te houden.", 129, 68, "Snoeien van takken" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 136,
                columns: new[] { "DurationInMinutes", "TaskListId" },
                values: new object[] { 37, 68 });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 137,
                columns: new[] { "DurationInMinutes", "TaskListId" },
                values: new object[] { 97, 68 });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 138,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Breng organische mest rond de basis van de boom aan.", 238, 70, "Bemesten van bomen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 139,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Breng organische mest rond de basis van de boom aan.", 87, 71, "Bemesten van bomen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 140,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Controleer bomen op ziektes of plagen.", 84, 71, "Controle op ziektes en plagen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 141,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Geef water aan pas geplante bomen om de groei te ondersteunen.", 41, 71, "Water geven aan jonge bomen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 142,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Breng mulch aan rond de boom om vocht vast te houden en onkruid te voorkomen.", 58, 71, "Mulchen rondom bomen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 143,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Controleer bomen op ziektes of plagen.", 97, 72, "Controle op ziektes en plagen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 144,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Geef water aan pas geplante bomen om de groei te ondersteunen.", 76, 72, "Water geven aan jonge bomen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 145,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Breng mulch aan rond de boom om vocht vast te houden en onkruid te voorkomen.", 41, 72, "Mulchen rondom bomen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 146,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Breng mulch aan rond de boom om vocht vast te houden en onkruid te voorkomen.", 287, 73, "Mulchen rondom bomen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 147,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Breng mulch aan rond de boom om vocht vast te houden en onkruid te voorkomen.", 31, 74, "Mulchen rondom bomen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 148,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Controleer en herstel boomsteunen of palen indien nodig.", 132, 75, "Controle van boomsteunen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 149,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Verwijder invasieve planten of onkruid bij de wortels van de boom.", 66, 75, "Onkruid verwijderen bij wortels" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 150,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Verwijder invasieve planten of onkruid bij de wortels van de boom.", 42, 77, "Onkruid verwijderen bij wortels" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 151,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Monitor de bodemkwaliteit en pH rondom de bomen.", 103, 77, "Bodemkwaliteit monitoren" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 152,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Oogst vruchten of zaden van volwassen bomen.", 57, 77, "Oogsten van vruchten of zaden" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 153,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Voer een veiligheidscontrole uit en verwijder gevaarlijke takken.", 88, 77, "Veiligheidstakcontrole" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 154,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Controleer bomen op ziektes of plagen.", 175, 78, "Controle op ziektes en plagen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 155,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Geef water aan pas geplante bomen om de groei te ondersteunen.", 233, 78, "Water geven aan jonge bomen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 156,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Breng organische mest rond de basis van de boom aan.", 275, 79, "Bemesten van bomen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 157,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Geef water aan pas geplante bomen om de groei te ondersteunen.", 157, 80, "Water geven aan jonge bomen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 158,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Breng mulch aan rond de boom om vocht vast te houden en onkruid te voorkomen.", 104, 80, "Mulchen rondom bomen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 159,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Controleer en herstel boomsteunen of palen indien nodig.", 92, 80, "Controle van boomsteunen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 160,
                columns: new[] { "DurationInMinutes", "TaskListId" },
                values: new object[] { 41, 81 });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 161,
                columns: new[] { "DurationInMinutes", "TaskListId" },
                values: new object[] { 59, 81 });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 162,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Geef water aan pas geplante bomen om de groei te ondersteunen.", 69, 81, "Water geven aan jonge bomen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 163,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Breng mulch aan rond de boom om vocht vast te houden en onkruid te voorkomen.", 90, 81, "Mulchen rondom bomen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 164,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Oogst vruchten of zaden van volwassen bomen.", 52, 82, "Oogsten van vruchten of zaden" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 165,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Verwijder invasieve planten of onkruid bij de wortels van de boom.", 90, 84, "Onkruid verwijderen bij wortels" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 166,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Monitor de bodemkwaliteit en pH rondom de bomen.", 214, 84, "Bodemkwaliteit monitoren" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 167,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Monitor de bodemkwaliteit en pH rondom de bomen.", 224, 85, "Bodemkwaliteit monitoren" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 168,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Oogst vruchten of zaden van volwassen bomen.", 237, 85, "Oogsten van vruchten of zaden" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 169,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Geef water aan pas geplante bomen om de groei te ondersteunen.", 150, 86, "Water geven aan jonge bomen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 170,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Breng mulch aan rond de boom om vocht vast te houden en onkruid te voorkomen.", 35, 86, "Mulchen rondom bomen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 171,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Geef water aan pas geplante bomen om de groei te ondersteunen.", 135, 87, "Water geven aan jonge bomen" });

            migrationBuilder.UpdateData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 172,
                columns: new[] { "Description", "DurationInMinutes", "TaskListId", "Title" },
                values: new object[] { "Breng mulch aan rond de boom om vocht vast te houden en onkruid te voorkomen.", 309, 88, "Mulchen rondom bomen" });

            migrationBuilder.InsertData(
                table: "TaskItem",
                columns: new[] { "Id", "Description", "DurationInMinutes", "EndTime", "IsDeleted", "StartTime", "TaskListId", "Title" },
                values: new object[,]
                {
                    { 173, "Verwijder invasieve planten of onkruid bij de wortels van de boom.", 54, null, false, null, 89, "Onkruid verwijderen bij wortels" },
                    { 174, "Monitor de bodemkwaliteit en pH rondom de bomen.", 30, null, false, null, 89, "Bodemkwaliteit monitoren" },
                    { 175, "Oogst vruchten of zaden van volwassen bomen.", 30, null, false, null, 89, "Oogsten van vruchten of zaden" },
                    { 176, "Voer een veiligheidscontrole uit en verwijder gevaarlijke takken.", 63, null, false, null, 89, "Veiligheidstakcontrole" },
                    { 177, "Controleer bomen op ziektes of plagen.", 89, null, false, null, 91, "Controle op ziektes en plagen" },
                    { 178, "Geef water aan pas geplante bomen om de groei te ondersteunen.", 111, null, false, null, 91, "Water geven aan jonge bomen" },
                    { 179, "Breng mulch aan rond de boom om vocht vast te houden en onkruid te voorkomen.", 84, null, false, null, 91, "Mulchen rondom bomen" },
                    { 180, "Breng mulch aan rond de boom om vocht vast te houden en onkruid te voorkomen.", 75, null, false, null, 92, "Mulchen rondom bomen" },
                    { 181, "Controleer en herstel boomsteunen of palen indien nodig.", 60, null, false, null, 92, "Controle van boomsteunen" },
                    { 182, "Verwijder invasieve planten of onkruid bij de wortels van de boom.", 66, null, false, null, 92, "Onkruid verwijderen bij wortels" },
                    { 183, "Controleer bomen op ziektes of plagen.", 43, null, false, null, 93, "Controle op ziektes en plagen" },
                    { 184, "Geef water aan pas geplante bomen om de groei te ondersteunen.", 96, null, false, null, 93, "Water geven aan jonge bomen" },
                    { 185, "Breng mulch aan rond de boom om vocht vast te houden en onkruid te voorkomen.", 71, null, false, null, 93, "Mulchen rondom bomen" },
                    { 186, "Controleer en herstel boomsteunen of palen indien nodig.", 118, null, false, null, 93, "Controle van boomsteunen" },
                    { 187, "Breng organische mest rond de basis van de boom aan.", 127, null, false, null, 94, "Bemesten van bomen" },
                    { 188, "Voer een veiligheidscontrole uit en verwijder gevaarlijke takken.", 449, null, false, null, 95, "Veiligheidstakcontrole" },
                    { 189, "Breng mulch aan rond de boom om vocht vast te houden en onkruid te voorkomen.", 360, null, false, null, 96, "Mulchen rondom bomen" },
                    { 190, "Controleer en herstel boomsteunen of palen indien nodig.", 124, null, false, null, 98, "Controle van boomsteunen" },
                    { 191, "Verwijder invasieve planten of onkruid bij de wortels van de boom.", 172, null, false, null, 98, "Onkruid verwijderen bij wortels" },
                    { 192, "Snoei dode of overgroeide takken om de boom gezond te houden.", 96, null, false, null, 99, "Snoeien van takken" },
                    { 193, "Breng organische mest rond de basis van de boom aan.", 48, null, false, null, 99, "Bemesten van bomen" },
                    { 194, "Controleer bomen op ziektes of plagen.", 91, null, false, null, 99, "Controle op ziektes en plagen" },
                    { 195, "Geef water aan pas geplante bomen om de groei te ondersteunen.", 77, null, false, null, 99, "Water geven aan jonge bomen" },
                    { 196, "Voer een veiligheidscontrole uit en verwijder gevaarlijke takken.", 116, null, false, null, 100, "Veiligheidstakcontrole" },
                    { 197, "Snoei dode of overgroeide takken om de boom gezond te houden.", 84, null, false, null, 100, "Snoeien van takken" },
                    { 198, "Breng organische mest rond de basis van de boom aan.", 100, null, false, null, 100, "Bemesten van bomen" },
                    { 199, "Controleer bomen op ziektes of plagen.", 43, null, false, null, 100, "Controle op ziektes en plagen" },
                    { 200, "Geef water aan pas geplante bomen om de groei te ondersteunen.", 50, null, false, null, 101, "Water geven aan jonge bomen" },
                    { 201, "Breng mulch aan rond de boom om vocht vast te houden en onkruid te voorkomen.", 72, null, false, null, 101, "Mulchen rondom bomen" },
                    { 202, "Controleer en herstel boomsteunen of palen indien nodig.", 48, null, false, null, 101, "Controle van boomsteunen" },
                    { 203, "Verwijder invasieve planten of onkruid bij de wortels van de boom.", 42, null, false, null, 101, "Onkruid verwijderen bij wortels" }
                });
        }
    }
}
