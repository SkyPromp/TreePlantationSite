using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AP.BTP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class taskitemseeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TaskItem",
                columns: new[] { "Id", "Description", "DurationInMinutes", "EndTime", "IsDeleted", "StartTime", "TaskListId", "Title" },
                values: new object[,]
                {
                    { 1, "Breng organische mest rond de basis van de boom aan.", 90, null, false, null, 1, "Bemesten van bomen" },
                    { 2, "Controleer bomen op ziektes of plagen.", 129, null, false, null, 1, "Controle op ziektes en plagen" },
                    { 3, "Geef water aan pas geplante bomen om de groei te ondersteunen.", 114, null, false, null, 1, "Water geven aan jonge bomen" },
                    { 4, "Geef water aan pas geplante bomen om de groei te ondersteunen.", 114, null, false, null, 2, "Water geven aan jonge bomen" },
                    { 5, "Breng mulch aan rond de boom om vocht vast te houden en onkruid te voorkomen.", 39, null, false, null, 2, "Mulchen rondom bomen" },
                    { 6, "Controleer en herstel boomsteunen of palen indien nodig.", 87, null, false, null, 2, "Controle van boomsteunen" },
                    { 7, "Verwijder invasieve planten of onkruid bij de wortels van de boom.", 32, null, false, null, 2, "Onkruid verwijderen bij wortels" },
                    { 8, "Geef water aan pas geplante bomen om de groei te ondersteunen.", 157, null, false, null, 3, "Water geven aan jonge bomen" },
                    { 9, "Breng mulch aan rond de boom om vocht vast te houden en onkruid te voorkomen.", 117, null, false, null, 3, "Mulchen rondom bomen" },
                    { 10, "Controleer en herstel boomsteunen of palen indien nodig.", 114, null, false, null, 3, "Controle van boomsteunen" },
                    { 11, "Verwijder invasieve planten of onkruid bij de wortels van de boom.", 120, null, false, null, 4, "Onkruid verwijderen bij wortels" },
                    { 12, "Monitor de bodemkwaliteit en pH rondom de bomen.", 120, null, false, null, 4, "Bodemkwaliteit monitoren" },
                    { 13, "Oogst vruchten of zaden van volwassen bomen.", 152, null, false, null, 4, "Oogsten van vruchten of zaden" },
                    { 14, "Breng organische mest rond de basis van de boom aan.", 109, null, false, null, 5, "Bemesten van bomen" },
                    { 15, "Controleer bomen op ziektes of plagen.", 196, null, false, null, 5, "Controle op ziektes en plagen" },
                    { 16, "Monitor de bodemkwaliteit en pH rondom de bomen.", 69, null, false, null, 6, "Bodemkwaliteit monitoren" },
                    { 17, "Oogst vruchten of zaden van volwassen bomen.", 136, null, false, null, 6, "Oogsten van vruchten of zaden" },
                    { 18, "Voer een veiligheidscontrole uit en verwijder gevaarlijke takken.", 144, null, false, null, 6, "Veiligheidstakcontrole" },
                    { 19, "Monitor de bodemkwaliteit en pH rondom de bomen.", 75, null, false, null, 7, "Bodemkwaliteit monitoren" },
                    { 20, "Oogst vruchten of zaden van volwassen bomen.", 30, null, false, null, 7, "Oogsten van vruchten of zaden" },
                    { 21, "Voer een veiligheidscontrole uit en verwijder gevaarlijke takken.", 94, null, false, null, 7, "Veiligheidstakcontrole" },
                    { 22, "Snoei dode of overgroeide takken om de boom gezond te houden.", 82, null, false, null, 7, "Snoeien van takken" },
                    { 23, "Breng organische mest rond de basis van de boom aan.", 85, null, false, null, 7, "Bemesten van bomen" },
                    { 24, "Controleer en herstel boomsteunen of palen indien nodig.", 139, null, false, null, 8, "Controle van boomsteunen" },
                    { 25, "Verwijder invasieve planten of onkruid bij de wortels van de boom.", 87, null, false, null, 8, "Onkruid verwijderen bij wortels" },
                    { 26, "Verwijder invasieve planten of onkruid bij de wortels van de boom.", 44, null, false, null, 9, "Onkruid verwijderen bij wortels" },
                    { 27, "Monitor de bodemkwaliteit en pH rondom de bomen.", 46, null, false, null, 9, "Bodemkwaliteit monitoren" },
                    { 28, "Oogst vruchten of zaden van volwassen bomen.", 54, null, false, null, 9, "Oogsten van vruchten of zaden" },
                    { 29, "Voer een veiligheidscontrole uit en verwijder gevaarlijke takken.", 55, null, false, null, 9, "Veiligheidstakcontrole" },
                    { 30, "Snoei dode of overgroeide takken om de boom gezond te houden.", 47, null, false, null, 9, "Snoeien van takken" },
                    { 31, "Breng organische mest rond de basis van de boom aan.", 39, null, false, null, 9, "Bemesten van bomen" },
                    { 32, "Controleer bomen op ziektes of plagen.", 43, null, false, null, 9, "Controle op ziektes en plagen" },
                    { 33, "Breng organische mest rond de basis van de boom aan.", 52, null, false, null, 10, "Bemesten van bomen" },
                    { 34, "Controleer bomen op ziektes of plagen.", 74, null, false, null, 10, "Controle op ziektes en plagen" },
                    { 35, "Geef water aan pas geplante bomen om de groei te ondersteunen.", 55, null, false, null, 10, "Water geven aan jonge bomen" },
                    { 36, "Breng mulch aan rond de boom om vocht vast te houden en onkruid te voorkomen.", 40, null, false, null, 10, "Mulchen rondom bomen" },
                    { 37, "Controleer en herstel boomsteunen of palen indien nodig.", 91, null, false, null, 10, "Controle van boomsteunen" },
                    { 38, "Voer een veiligheidscontrole uit en verwijder gevaarlijke takken.", 132, null, false, null, 11, "Veiligheidstakcontrole" },
                    { 39, "Snoei dode of overgroeide takken om de boom gezond te houden.", 163, null, false, null, 11, "Snoeien van takken" },
                    { 40, "Breng organische mest rond de basis van de boom aan.", 74, null, false, null, 12, "Bemesten van bomen" },
                    { 41, "Controleer bomen op ziektes of plagen.", 48, null, false, null, 12, "Controle op ziektes en plagen" },
                    { 42, "Controleer en herstel boomsteunen of palen indien nodig.", 69, null, false, null, 13, "Controle van boomsteunen" },
                    { 43, "Verwijder invasieve planten of onkruid bij de wortels van de boom.", 158, null, false, null, 13, "Onkruid verwijderen bij wortels" },
                    { 44, "Monitor de bodemkwaliteit en pH rondom de bomen.", 142, null, false, null, 13, "Bodemkwaliteit monitoren" },
                    { 45, "Controleer bomen op ziektes of plagen.", 34, null, false, null, 14, "Controle op ziektes en plagen" },
                    { 46, "Geef water aan pas geplante bomen om de groei te ondersteunen.", 38, null, false, null, 14, "Water geven aan jonge bomen" },
                    { 47, "Breng mulch aan rond de boom om vocht vast te houden en onkruid te voorkomen.", 51, null, false, null, 14, "Mulchen rondom bomen" },
                    { 48, "Controleer en herstel boomsteunen of palen indien nodig.", 76, null, false, null, 14, "Controle van boomsteunen" },
                    { 49, "Verwijder invasieve planten of onkruid bij de wortels van de boom.", 49, null, false, null, 14, "Onkruid verwijderen bij wortels" },
                    { 50, "Monitor de bodemkwaliteit en pH rondom de bomen.", 67, null, false, null, 14, "Bodemkwaliteit monitoren" },
                    { 51, "Breng organische mest rond de basis van de boom aan.", 48, null, false, null, 15, "Bemesten van bomen" },
                    { 52, "Controleer bomen op ziektes of plagen.", 41, null, false, null, 15, "Controle op ziektes en plagen" },
                    { 53, "Geef water aan pas geplante bomen om de groei te ondersteunen.", 32, null, false, null, 15, "Water geven aan jonge bomen" },
                    { 54, "Breng mulch aan rond de boom om vocht vast te houden en onkruid te voorkomen.", 47, null, false, null, 15, "Mulchen rondom bomen" },
                    { 55, "Controleer en herstel boomsteunen of palen indien nodig.", 43, null, false, null, 15, "Controle van boomsteunen" },
                    { 56, "Verwijder invasieve planten of onkruid bij de wortels van de boom.", 44, null, false, null, 15, "Onkruid verwijderen bij wortels" },
                    { 57, "Monitor de bodemkwaliteit en pH rondom de bomen.", 43, null, false, null, 15, "Bodemkwaliteit monitoren" },
                    { 58, "Verwijder invasieve planten of onkruid bij de wortels van de boom.", 204, null, false, null, 16, "Onkruid verwijderen bij wortels" },
                    { 59, "Monitor de bodemkwaliteit en pH rondom de bomen.", 209, null, false, null, 16, "Bodemkwaliteit monitoren" },
                    { 60, "Snoei dode of overgroeide takken om de boom gezond te houden.", 31, null, false, null, 17, "Snoeien van takken" },
                    { 61, "Breng organische mest rond de basis van de boom aan.", 73, null, false, null, 17, "Bemesten van bomen" },
                    { 62, "Controleer bomen op ziektes of plagen.", 41, null, false, null, 17, "Controle op ziektes en plagen" },
                    { 63, "Geef water aan pas geplante bomen om de groei te ondersteunen.", 72, null, false, null, 17, "Water geven aan jonge bomen" },
                    { 64, "Breng mulch aan rond de boom om vocht vast te houden en onkruid te voorkomen.", 53, null, false, null, 17, "Mulchen rondom bomen" },
                    { 65, "Controleer en herstel boomsteunen of palen indien nodig.", 44, null, false, null, 17, "Controle van boomsteunen" },
                    { 66, "Breng organische mest rond de basis van de boom aan.", 107, null, false, null, 18, "Bemesten van bomen" },
                    { 67, "Controleer bomen op ziektes of plagen.", 129, null, false, null, 18, "Controle op ziektes en plagen" },
                    { 68, "Controleer en herstel boomsteunen of palen indien nodig.", 57, null, false, null, 19, "Controle van boomsteunen" },
                    { 69, "Verwijder invasieve planten of onkruid bij de wortels van de boom.", 36, null, false, null, 19, "Onkruid verwijderen bij wortels" },
                    { 70, "Monitor de bodemkwaliteit en pH rondom de bomen.", 44, null, false, null, 19, "Bodemkwaliteit monitoren" },
                    { 71, "Oogst vruchten of zaden van volwassen bomen.", 53, null, false, null, 19, "Oogsten van vruchten of zaden" },
                    { 72, "Monitor de bodemkwaliteit en pH rondom de bomen.", 45, null, false, null, 20, "Bodemkwaliteit monitoren" },
                    { 73, "Oogst vruchten of zaden van volwassen bomen.", 42, null, false, null, 20, "Oogsten van vruchten of zaden" },
                    { 74, "Voer een veiligheidscontrole uit en verwijder gevaarlijke takken.", 105, null, false, null, 20, "Veiligheidstakcontrole" },
                    { 75, "Snoei dode of overgroeide takken om de boom gezond te houden.", 118, null, false, null, 20, "Snoeien van takken" },
                    { 76, "Voer een veiligheidscontrole uit en verwijder gevaarlijke takken.", 114, null, false, null, 21, "Veiligheidstakcontrole" },
                    { 77, "Snoei dode of overgroeide takken om de boom gezond te houden.", 140, null, false, null, 21, "Snoeien van takken" },
                    { 78, "Breng organische mest rond de basis van de boom aan.", 120, null, false, null, 21, "Bemesten van bomen" },
                    { 79, "Controleer en herstel boomsteunen of palen indien nodig.", 55, null, false, null, 22, "Controle van boomsteunen" },
                    { 80, "Verwijder invasieve planten of onkruid bij de wortels van de boom.", 35, null, false, null, 22, "Onkruid verwijderen bij wortels" },
                    { 81, "Monitor de bodemkwaliteit en pH rondom de bomen.", 30, null, false, null, 22, "Bodemkwaliteit monitoren" },
                    { 82, "Oogst vruchten of zaden van volwassen bomen.", 30, null, false, null, 22, "Oogsten van vruchten of zaden" },
                    { 83, "Voer een veiligheidscontrole uit en verwijder gevaarlijke takken.", 34, null, false, null, 22, "Veiligheidstakcontrole" },
                    { 84, "Snoei dode of overgroeide takken om de boom gezond te houden.", 32, null, false, null, 22, "Snoeien van takken" },
                    { 85, "Breng organische mest rond de basis van de boom aan.", 40, null, false, null, 22, "Bemesten van bomen" },
                    { 86, "Snoei dode of overgroeide takken om de boom gezond te houden.", 149, null, false, null, 23, "Snoeien van takken" },
                    { 87, "Breng organische mest rond de basis van de boom aan.", 91, null, false, null, 23, "Bemesten van bomen" },
                    { 88, "Controleer bomen op ziektes of plagen.", 136, null, false, null, 23, "Controle op ziektes en plagen" },
                    { 89, "Breng organische mest rond de basis van de boom aan.", 61, null, false, null, 24, "Bemesten van bomen" },
                    { 90, "Controleer bomen op ziektes of plagen.", 55, null, false, null, 24, "Controle op ziektes en plagen" },
                    { 91, "Geef water aan pas geplante bomen om de groei te ondersteunen.", 63, null, false, null, 24, "Water geven aan jonge bomen" },
                    { 92, "Breng mulch aan rond de boom om vocht vast te houden en onkruid te voorkomen.", 32, null, false, null, 24, "Mulchen rondom bomen" },
                    { 93, "Controleer en herstel boomsteunen of palen indien nodig.", 41, null, false, null, 24, "Controle van boomsteunen" },
                    { 94, "Verwijder invasieve planten of onkruid bij de wortels van de boom.", 37, null, false, null, 24, "Onkruid verwijderen bij wortels" },
                    { 95, "Monitor de bodemkwaliteit en pH rondom de bomen.", 57, null, false, null, 24, "Bodemkwaliteit monitoren" },
                    { 96, "Snoei dode of overgroeide takken om de boom gezond te houden.", 117, null, false, null, 25, "Snoeien van takken" },
                    { 97, "Breng organische mest rond de basis van de boom aan.", 112, null, false, null, 25, "Bemesten van bomen" },
                    { 98, "Controleer bomen op ziektes of plagen.", 60, null, false, null, 25, "Controle op ziektes en plagen" },
                    { 99, "Controleer en herstel boomsteunen of palen indien nodig.", 80, null, false, null, 26, "Controle van boomsteunen" },
                    { 100, "Verwijder invasieve planten of onkruid bij de wortels van de boom.", 76, null, false, null, 26, "Onkruid verwijderen bij wortels" },
                    { 101, "Verwijder invasieve planten of onkruid bij de wortels van de boom.", 41, null, false, null, 27, "Onkruid verwijderen bij wortels" },
                    { 102, "Monitor de bodemkwaliteit en pH rondom de bomen.", 68, null, false, null, 27, "Bodemkwaliteit monitoren" },
                    { 103, "Oogst vruchten of zaden van volwassen bomen.", 74, null, false, null, 27, "Oogsten van vruchten of zaden" },
                    { 104, "Voer een veiligheidscontrole uit en verwijder gevaarlijke takken.", 50, null, false, null, 27, "Veiligheidstakcontrole" },
                    { 105, "Snoei dode of overgroeide takken om de boom gezond te houden.", 52, null, false, null, 27, "Snoeien van takken" },
                    { 106, "Breng organische mest rond de basis van de boom aan.", 94, null, false, null, 28, "Bemesten van bomen" },
                    { 107, "Controleer bomen op ziektes of plagen.", 86, null, false, null, 28, "Controle op ziektes en plagen" },
                    { 108, "Geef water aan pas geplante bomen om de groei te ondersteunen.", 33, null, false, null, 28, "Water geven aan jonge bomen" },
                    { 109, "Breng mulch aan rond de boom om vocht vast te houden en onkruid te voorkomen.", 53, null, false, null, 28, "Mulchen rondom bomen" },
                    { 110, "Controleer en herstel boomsteunen of palen indien nodig.", 83, null, false, null, 28, "Controle van boomsteunen" },
                    { 111, "Geef water aan pas geplante bomen om de groei te ondersteunen.", 71, null, false, null, 29, "Water geven aan jonge bomen" },
                    { 112, "Breng mulch aan rond de boom om vocht vast te houden en onkruid te voorkomen.", 72, null, false, null, 29, "Mulchen rondom bomen" },
                    { 113, "Controleer en herstel boomsteunen of palen indien nodig.", 53, null, false, null, 29, "Controle van boomsteunen" },
                    { 114, "Verwijder invasieve planten of onkruid bij de wortels van de boom.", 44, null, false, null, 29, "Onkruid verwijderen bij wortels" },
                    { 115, "Monitor de bodemkwaliteit en pH rondom de bomen.", 66, null, false, null, 29, "Bodemkwaliteit monitoren" },
                    { 116, "Oogst vruchten of zaden van volwassen bomen.", 69, null, false, null, 29, "Oogsten van vruchten of zaden" },
                    { 117, "Monitor de bodemkwaliteit en pH rondom de bomen.", 100, null, false, null, 30, "Bodemkwaliteit monitoren" },
                    { 118, "Oogst vruchten of zaden van volwassen bomen.", 75, null, false, null, 30, "Oogsten van vruchten of zaden" },
                    { 119, "Voer een veiligheidscontrole uit en verwijder gevaarlijke takken.", 36, null, false, null, 30, "Veiligheidstakcontrole" },
                    { 120, "Snoei dode of overgroeide takken om de boom gezond te houden.", 60, null, false, null, 30, "Snoeien van takken" },
                    { 121, "Oogst vruchten of zaden van volwassen bomen.", 33, null, false, null, 31, "Oogsten van vruchten of zaden" },
                    { 122, "Voer een veiligheidscontrole uit en verwijder gevaarlijke takken.", 94, null, false, null, 31, "Veiligheidstakcontrole" },
                    { 123, "Snoei dode of overgroeide takken om de boom gezond te houden.", 115, null, false, null, 31, "Snoeien van takken" },
                    { 124, "Breng organische mest rond de basis van de boom aan.", 106, null, false, null, 31, "Bemesten van bomen" },
                    { 125, "Oogst vruchten of zaden van volwassen bomen.", 113, null, false, null, 32, "Oogsten van vruchten of zaden" },
                    { 126, "Voer een veiligheidscontrole uit en verwijder gevaarlijke takken.", 82, null, false, null, 32, "Veiligheidstakcontrole" },
                    { 127, "Snoei dode of overgroeide takken om de boom gezond te houden.", 86, null, false, null, 32, "Snoeien van takken" },
                    { 128, "Geef water aan pas geplante bomen om de groei te ondersteunen.", 54, null, false, null, 33, "Water geven aan jonge bomen" },
                    { 129, "Breng mulch aan rond de boom om vocht vast te houden en onkruid te voorkomen.", 87, null, false, null, 33, "Mulchen rondom bomen" },
                    { 130, "Controleer en herstel boomsteunen of palen indien nodig.", 51, null, false, null, 33, "Controle van boomsteunen" },
                    { 131, "Verwijder invasieve planten of onkruid bij de wortels van de boom.", 51, null, false, null, 33, "Onkruid verwijderen bij wortels" },
                    { 132, "Monitor de bodemkwaliteit en pH rondom de bomen.", 74, null, false, null, 33, "Bodemkwaliteit monitoren" },
                    { 133, "Controleer bomen op ziektes of plagen.", 77, null, false, null, 34, "Controle op ziektes en plagen" },
                    { 134, "Geef water aan pas geplante bomen om de groei te ondersteunen.", 45, null, false, null, 34, "Water geven aan jonge bomen" },
                    { 135, "Breng mulch aan rond de boom om vocht vast te houden en onkruid te voorkomen.", 48, null, false, null, 34, "Mulchen rondom bomen" },
                    { 136, "Controleer en herstel boomsteunen of palen indien nodig.", 37, null, false, null, 34, "Controle van boomsteunen" },
                    { 137, "Verwijder invasieve planten of onkruid bij de wortels van de boom.", 34, null, false, null, 34, "Onkruid verwijderen bij wortels" },
                    { 138, "Monitor de bodemkwaliteit en pH rondom de bomen.", 76, null, false, null, 34, "Bodemkwaliteit monitoren" },
                    { 139, "Oogst vruchten of zaden van volwassen bomen.", 49, null, false, null, 35, "Oogsten van vruchten of zaden" },
                    { 140, "Voer een veiligheidscontrole uit en verwijder gevaarlijke takken.", 69, null, false, null, 35, "Veiligheidstakcontrole" },
                    { 141, "Snoei dode of overgroeide takken om de boom gezond te houden.", 100, null, false, null, 35, "Snoeien van takken" },
                    { 142, "Breng organische mest rond de basis van de boom aan.", 45, null, false, null, 35, "Bemesten van bomen" },
                    { 143, "Snoei dode of overgroeide takken om de boom gezond te houden.", 49, null, false, null, 36, "Snoeien van takken" },
                    { 144, "Breng organische mest rond de basis van de boom aan.", 66, null, false, null, 36, "Bemesten van bomen" },
                    { 145, "Controleer bomen op ziektes of plagen.", 152, null, false, null, 36, "Controle op ziektes en plagen" },
                    { 146, "Snoei dode of overgroeide takken om de boom gezond te houden.", 133, null, false, null, 37, "Snoeien van takken" },
                    { 147, "Breng organische mest rond de basis van de boom aan.", 139, null, false, null, 37, "Bemesten van bomen" },
                    { 148, "Verwijder invasieve planten of onkruid bij de wortels van de boom.", 51, null, false, null, 38, "Onkruid verwijderen bij wortels" },
                    { 149, "Monitor de bodemkwaliteit en pH rondom de bomen.", 51, null, false, null, 38, "Bodemkwaliteit monitoren" },
                    { 150, "Oogst vruchten of zaden van volwassen bomen.", 76, null, false, null, 38, "Oogsten van vruchten of zaden" },
                    { 151, "Voer een veiligheidscontrole uit en verwijder gevaarlijke takken.", 76, null, false, null, 38, "Veiligheidstakcontrole" },
                    { 152, "Snoei dode of overgroeide takken om de boom gezond te houden.", 47, null, false, null, 38, "Snoeien van takken" },
                    { 153, "Breng organische mest rond de basis van de boom aan.", 75, null, false, null, 38, "Bemesten van bomen" },
                    { 154, "Breng mulch aan rond de boom om vocht vast te houden en onkruid te voorkomen.", 53, null, false, null, 39, "Mulchen rondom bomen" },
                    { 155, "Controleer en herstel boomsteunen of palen indien nodig.", 173, null, false, null, 39, "Controle van boomsteunen" },
                    { 156, "Geef water aan pas geplante bomen om de groei te ondersteunen.", 33, null, false, null, 40, "Water geven aan jonge bomen" },
                    { 157, "Breng mulch aan rond de boom om vocht vast te houden en onkruid te voorkomen.", 55, null, false, null, 40, "Mulchen rondom bomen" },
                    { 158, "Controleer en herstel boomsteunen of palen indien nodig.", 73, null, false, null, 40, "Controle van boomsteunen" },
                    { 159, "Verwijder invasieve planten of onkruid bij de wortels van de boom.", 60, null, false, null, 40, "Onkruid verwijderen bij wortels" },
                    { 160, "Monitor de bodemkwaliteit en pH rondom de bomen.", 30, null, false, null, 40, "Bodemkwaliteit monitoren" },
                    { 161, "Oogst vruchten of zaden van volwassen bomen.", 48, null, false, null, 40, "Oogsten van vruchten of zaden" },
                    { 162, "Verwijder invasieve planten of onkruid bij de wortels van de boom.", 48, null, false, null, 41, "Onkruid verwijderen bij wortels" },
                    { 163, "Monitor de bodemkwaliteit en pH rondom de bomen.", 85, null, false, null, 41, "Bodemkwaliteit monitoren" },
                    { 164, "Oogst vruchten of zaden van volwassen bomen.", 53, null, false, null, 41, "Oogsten van vruchten of zaden" },
                    { 165, "Voer een veiligheidscontrole uit en verwijder gevaarlijke takken.", 56, null, false, null, 41, "Veiligheidstakcontrole" },
                    { 166, "Controleer bomen op ziektes of plagen.", 83, null, false, null, 42, "Controle op ziektes en plagen" },
                    { 167, "Geef water aan pas geplante bomen om de groei te ondersteunen.", 63, null, false, null, 42, "Water geven aan jonge bomen" },
                    { 168, "Breng mulch aan rond de boom om vocht vast te houden en onkruid te voorkomen.", 45, null, false, null, 42, "Mulchen rondom bomen" },
                    { 169, "Controleer en herstel boomsteunen of palen indien nodig.", 82, null, false, null, 42, "Controle van boomsteunen" },
                    { 170, "Monitor de bodemkwaliteit en pH rondom de bomen.", 49, null, false, null, 43, "Bodemkwaliteit monitoren" },
                    { 171, "Oogst vruchten of zaden van volwassen bomen.", 114, null, false, null, 43, "Oogsten van vruchten of zaden" },
                    { 172, "Voer een veiligheidscontrole uit en verwijder gevaarlijke takken.", 150, null, false, null, 43, "Veiligheidstakcontrole" },
                    { 173, "Breng organische mest rond de basis van de boom aan.", 30, null, false, null, 44, "Bemesten van bomen" },
                    { 174, "Controleer bomen op ziektes of plagen.", 35, null, false, null, 44, "Controle op ziektes en plagen" },
                    { 175, "Geef water aan pas geplante bomen om de groei te ondersteunen.", 74, null, false, null, 44, "Water geven aan jonge bomen" },
                    { 176, "Breng mulch aan rond de boom om vocht vast te houden en onkruid te voorkomen.", 38, null, false, null, 44, "Mulchen rondom bomen" },
                    { 177, "Controleer en herstel boomsteunen of palen indien nodig.", 31, null, false, null, 44, "Controle van boomsteunen" },
                    { 178, "Verwijder invasieve planten of onkruid bij de wortels van de boom.", 63, null, false, null, 44, "Onkruid verwijderen bij wortels" },
                    { 179, "Breng mulch aan rond de boom om vocht vast te houden en onkruid te voorkomen.", 87, null, false, null, 45, "Mulchen rondom bomen" },
                    { 180, "Controleer en herstel boomsteunen of palen indien nodig.", 37, null, false, null, 45, "Controle van boomsteunen" },
                    { 181, "Verwijder invasieve planten of onkruid bij de wortels van de boom.", 98, null, false, null, 45, "Onkruid verwijderen bij wortels" },
                    { 182, "Monitor de bodemkwaliteit en pH rondom de bomen.", 35, null, false, null, 45, "Bodemkwaliteit monitoren" },
                    { 183, "Snoei dode of overgroeide takken om de boom gezond te houden.", 37, null, false, null, 46, "Snoeien van takken" },
                    { 184, "Breng organische mest rond de basis van de boom aan.", 32, null, false, null, 46, "Bemesten van bomen" },
                    { 185, "Controleer bomen op ziektes of plagen.", 41, null, false, null, 46, "Controle op ziektes en plagen" },
                    { 186, "Geef water aan pas geplante bomen om de groei te ondersteunen.", 60, null, false, null, 46, "Water geven aan jonge bomen" },
                    { 187, "Breng mulch aan rond de boom om vocht vast te houden en onkruid te voorkomen.", 83, null, false, null, 46, "Mulchen rondom bomen" },
                    { 188, "Verwijder invasieve planten of onkruid bij de wortels van de boom.", 108, null, false, null, 47, "Onkruid verwijderen bij wortels" },
                    { 189, "Monitor de bodemkwaliteit en pH rondom de bomen.", 47, null, false, null, 47, "Bodemkwaliteit monitoren" },
                    { 190, "Oogst vruchten of zaden van volwassen bomen.", 71, null, false, null, 47, "Oogsten van vruchten of zaden" },
                    { 191, "Controleer bomen op ziektes of plagen.", 55, null, false, null, 48, "Controle op ziektes en plagen" },
                    { 192, "Geef water aan pas geplante bomen om de groei te ondersteunen.", 47, null, false, null, 48, "Water geven aan jonge bomen" },
                    { 193, "Breng mulch aan rond de boom om vocht vast te houden en onkruid te voorkomen.", 34, null, false, null, 48, "Mulchen rondom bomen" },
                    { 194, "Controleer en herstel boomsteunen of palen indien nodig.", 40, null, false, null, 48, "Controle van boomsteunen" },
                    { 195, "Verwijder invasieve planten of onkruid bij de wortels van de boom.", 49, null, false, null, 48, "Onkruid verwijderen bij wortels" },
                    { 196, "Monitor de bodemkwaliteit en pH rondom de bomen.", 58, null, false, null, 48, "Bodemkwaliteit monitoren" },
                    { 197, "Breng mulch aan rond de boom om vocht vast te houden en onkruid te voorkomen.", 30, null, false, null, 49, "Mulchen rondom bomen" },
                    { 198, "Controleer en herstel boomsteunen of palen indien nodig.", 63, null, false, null, 49, "Controle van boomsteunen" },
                    { 199, "Verwijder invasieve planten of onkruid bij de wortels van de boom.", 105, null, false, null, 49, "Onkruid verwijderen bij wortels" },
                    { 200, "Breng organische mest rond de basis van de boom aan.", 113, null, false, null, 50, "Bemesten van bomen" },
                    { 201, "Controleer bomen op ziektes of plagen.", 99, null, false, null, 50, "Controle op ziektes en plagen" },
                    { 202, "Geef water aan pas geplante bomen om de groei te ondersteunen.", 108, null, false, null, 50, "Water geven aan jonge bomen" },
                    { 203, "Breng mulch aan rond de boom om vocht vast te houden en onkruid te voorkomen.", 90, null, false, null, 50, "Mulchen rondom bomen" },
                    { 204, "Oogst vruchten of zaden van volwassen bomen.", 95, null, false, null, 51, "Oogsten van vruchten of zaden" },
                    { 205, "Voer een veiligheidscontrole uit en verwijder gevaarlijke takken.", 167, null, false, null, 51, "Veiligheidstakcontrole" },
                    { 206, "Controleer bomen op ziektes of plagen.", 91, null, false, null, 52, "Controle op ziektes en plagen" },
                    { 207, "Geef water aan pas geplante bomen om de groei te ondersteunen.", 116, null, false, null, 52, "Water geven aan jonge bomen" },
                    { 208, "Breng mulch aan rond de boom om vocht vast te houden en onkruid te voorkomen.", 47, null, false, null, 52, "Mulchen rondom bomen" },
                    { 209, "Controleer en herstel boomsteunen of palen indien nodig.", 40, null, false, null, 52, "Controle van boomsteunen" },
                    { 210, "Controleer en herstel boomsteunen of palen indien nodig.", 55, null, false, null, 53, "Controle van boomsteunen" },
                    { 211, "Verwijder invasieve planten of onkruid bij de wortels van de boom.", 94, null, false, null, 53, "Onkruid verwijderen bij wortels" },
                    { 212, "Monitor de bodemkwaliteit en pH rondom de bomen.", 67, null, false, null, 53, "Bodemkwaliteit monitoren" },
                    { 213, "Oogst vruchten of zaden van volwassen bomen.", 61, null, false, null, 53, "Oogsten van vruchten of zaden" },
                    { 214, "Voer een veiligheidscontrole uit en verwijder gevaarlijke takken.", 81, null, false, null, 53, "Veiligheidstakcontrole" },
                    { 215, "Breng organische mest rond de basis van de boom aan.", 98, null, false, null, 54, "Bemesten van bomen" },
                    { 216, "Controleer bomen op ziektes of plagen.", 122, null, false, null, 54, "Controle op ziektes en plagen" },
                    { 217, "Breng organische mest rond de basis van de boom aan.", 73, null, false, null, 55, "Bemesten van bomen" },
                    { 218, "Controleer bomen op ziektes of plagen.", 32, null, false, null, 55, "Controle op ziektes en plagen" },
                    { 219, "Geef water aan pas geplante bomen om de groei te ondersteunen.", 34, null, false, null, 55, "Water geven aan jonge bomen" },
                    { 220, "Breng mulch aan rond de boom om vocht vast te houden en onkruid te voorkomen.", 72, null, false, null, 55, "Mulchen rondom bomen" },
                    { 221, "Controleer en herstel boomsteunen of palen indien nodig.", 52, null, false, null, 55, "Controle van boomsteunen" },
                    { 222, "Verwijder invasieve planten of onkruid bij de wortels van de boom.", 63, null, false, null, 55, "Onkruid verwijderen bij wortels" },
                    { 223, "Oogst vruchten of zaden van volwassen bomen.", 81, null, false, null, 56, "Oogsten van vruchten of zaden" },
                    { 224, "Voer een veiligheidscontrole uit en verwijder gevaarlijke takken.", 128, null, false, null, 56, "Veiligheidstakcontrole" },
                    { 225, "Snoei dode of overgroeide takken om de boom gezond te houden.", 149, null, false, null, 56, "Snoeien van takken" },
                    { 226, "Breng mulch aan rond de boom om vocht vast te houden en onkruid te voorkomen.", 43, null, false, null, 57, "Mulchen rondom bomen" },
                    { 227, "Controleer en herstel boomsteunen of palen indien nodig.", 51, null, false, null, 57, "Controle van boomsteunen" },
                    { 228, "Verwijder invasieve planten of onkruid bij de wortels van de boom.", 30, null, false, null, 57, "Onkruid verwijderen bij wortels" },
                    { 229, "Monitor de bodemkwaliteit en pH rondom de bomen.", 35, null, false, null, 57, "Bodemkwaliteit monitoren" },
                    { 230, "Oogst vruchten of zaden van volwassen bomen.", 44, null, false, null, 57, "Oogsten van vruchten of zaden" },
                    { 231, "Voer een veiligheidscontrole uit en verwijder gevaarlijke takken.", 38, null, false, null, 57, "Veiligheidstakcontrole" },
                    { 232, "Snoei dode of overgroeide takken om de boom gezond te houden.", 37, null, false, null, 57, "Snoeien van takken" },
                    { 233, "Verwijder invasieve planten of onkruid bij de wortels van de boom.", 115, null, false, null, 58, "Onkruid verwijderen bij wortels" },
                    { 234, "Monitor de bodemkwaliteit en pH rondom de bomen.", 84, null, false, null, 58, "Bodemkwaliteit monitoren" },
                    { 235, "Oogst vruchten of zaden van volwassen bomen.", 54, null, false, null, 58, "Oogsten van vruchten of zaden" },
                    { 236, "Voer een veiligheidscontrole uit en verwijder gevaarlijke takken.", 30, null, false, null, 58, "Veiligheidstakcontrole" },
                    { 237, "Geef water aan pas geplante bomen om de groei te ondersteunen.", 194, null, false, null, 59, "Water geven aan jonge bomen" },
                    { 238, "Breng mulch aan rond de boom om vocht vast te houden en onkruid te voorkomen.", 164, null, false, null, 59, "Mulchen rondom bomen" },
                    { 239, "Controleer bomen op ziektes of plagen.", 59, null, false, null, 60, "Controle op ziektes en plagen" },
                    { 240, "Geef water aan pas geplante bomen om de groei te ondersteunen.", 71, null, false, null, 60, "Water geven aan jonge bomen" },
                    { 241, "Breng mulch aan rond de boom om vocht vast te houden en onkruid te voorkomen.", 57, null, false, null, 60, "Mulchen rondom bomen" },
                    { 242, "Controleer en herstel boomsteunen of palen indien nodig.", 69, null, false, null, 60, "Controle van boomsteunen" },
                    { 243, "Verwijder invasieve planten of onkruid bij de wortels van de boom.", 56, null, false, null, 60, "Onkruid verwijderen bij wortels" },
                    { 244, "Controleer bomen op ziektes of plagen.", 55, null, false, null, 61, "Controle op ziektes en plagen" },
                    { 245, "Geef water aan pas geplante bomen om de groei te ondersteunen.", 110, null, false, null, 61, "Water geven aan jonge bomen" },
                    { 246, "Breng mulch aan rond de boom om vocht vast te houden en onkruid te voorkomen.", 50, null, false, null, 61, "Mulchen rondom bomen" },
                    { 247, "Controleer en herstel boomsteunen of palen indien nodig.", 43, null, false, null, 61, "Controle van boomsteunen" },
                    { 248, "Breng mulch aan rond de boom om vocht vast te houden en onkruid te voorkomen.", 78, null, false, null, 62, "Mulchen rondom bomen" },
                    { 249, "Controleer en herstel boomsteunen of palen indien nodig.", 34, null, false, null, 62, "Controle van boomsteunen" },
                    { 250, "Verwijder invasieve planten of onkruid bij de wortels van de boom.", 35, null, false, null, 62, "Onkruid verwijderen bij wortels" },
                    { 251, "Monitor de bodemkwaliteit en pH rondom de bomen.", 40, null, false, null, 62, "Bodemkwaliteit monitoren" },
                    { 252, "Oogst vruchten of zaden van volwassen bomen.", 36, null, false, null, 62, "Oogsten van vruchten of zaden" },
                    { 253, "Voer een veiligheidscontrole uit en verwijder gevaarlijke takken.", 78, null, false, null, 62, "Veiligheidstakcontrole" },
                    { 254, "Controleer bomen op ziektes of plagen.", 47, null, false, null, 63, "Controle op ziektes en plagen" },
                    { 255, "Geef water aan pas geplante bomen om de groei te ondersteunen.", 57, null, false, null, 63, "Water geven aan jonge bomen" },
                    { 256, "Breng mulch aan rond de boom om vocht vast te houden en onkruid te voorkomen.", 39, null, false, null, 63, "Mulchen rondom bomen" },
                    { 257, "Controleer en herstel boomsteunen of palen indien nodig.", 33, null, false, null, 63, "Controle van boomsteunen" },
                    { 258, "Verwijder invasieve planten of onkruid bij de wortels van de boom.", 47, null, false, null, 63, "Onkruid verwijderen bij wortels" },
                    { 259, "Monitor de bodemkwaliteit en pH rondom de bomen.", 51, null, false, null, 63, "Bodemkwaliteit monitoren" },
                    { 260, "Oogst vruchten of zaden van volwassen bomen.", 46, null, false, null, 63, "Oogsten van vruchten of zaden" },
                    { 261, "Voer een veiligheidscontrole uit en verwijder gevaarlijke takken.", 34, null, false, null, 64, "Veiligheidstakcontrole" },
                    { 262, "Snoei dode of overgroeide takken om de boom gezond te houden.", 66, null, false, null, 64, "Snoeien van takken" },
                    { 263, "Breng organische mest rond de basis van de boom aan.", 40, null, false, null, 64, "Bemesten van bomen" },
                    { 264, "Controleer bomen op ziektes of plagen.", 63, null, false, null, 64, "Controle op ziektes en plagen" },
                    { 265, "Geef water aan pas geplante bomen om de groei te ondersteunen.", 56, null, false, null, 64, "Water geven aan jonge bomen" },
                    { 266, "Breng mulch aan rond de boom om vocht vast te houden en onkruid te voorkomen.", 72, null, false, null, 64, "Mulchen rondom bomen" },
                    { 267, "Voer een veiligheidscontrole uit en verwijder gevaarlijke takken.", 52, null, false, null, 65, "Veiligheidstakcontrole" },
                    { 268, "Snoei dode of overgroeide takken om de boom gezond te houden.", 59, null, false, null, 65, "Snoeien van takken" },
                    { 269, "Breng organische mest rond de basis van de boom aan.", 35, null, false, null, 65, "Bemesten van bomen" },
                    { 270, "Controleer bomen op ziektes of plagen.", 65, null, false, null, 65, "Controle op ziektes en plagen" },
                    { 271, "Geef water aan pas geplante bomen om de groei te ondersteunen.", 41, null, false, null, 65, "Water geven aan jonge bomen" },
                    { 272, "Breng mulch aan rond de boom om vocht vast te houden en onkruid te voorkomen.", 38, null, false, null, 65, "Mulchen rondom bomen" },
                    { 273, "Controleer en herstel boomsteunen of palen indien nodig.", 47, null, false, null, 65, "Controle van boomsteunen" },
                    { 274, "Breng organische mest rond de basis van de boom aan.", 65, null, false, null, 66, "Bemesten van bomen" },
                    { 275, "Controleer bomen op ziektes of plagen.", 148, null, false, null, 66, "Controle op ziektes en plagen" },
                    { 276, "Geef water aan pas geplante bomen om de groei te ondersteunen.", 144, null, false, null, 66, "Water geven aan jonge bomen" },
                    { 277, "Verwijder invasieve planten of onkruid bij de wortels van de boom.", 167, null, false, null, 67, "Onkruid verwijderen bij wortels" },
                    { 278, "Monitor de bodemkwaliteit en pH rondom de bomen.", 159, null, false, null, 67, "Bodemkwaliteit monitoren" },
                    { 279, "Voer een veiligheidscontrole uit en verwijder gevaarlijke takken.", 217, null, false, null, 68, "Veiligheidstakcontrole" },
                    { 280, "Snoei dode of overgroeide takken om de boom gezond te houden.", 62, null, false, null, 68, "Snoeien van takken" },
                    { 281, "Voer een veiligheidscontrole uit en verwijder gevaarlijke takken.", 79, null, false, null, 69, "Veiligheidstakcontrole" },
                    { 282, "Snoei dode of overgroeide takken om de boom gezond te houden.", 80, null, false, null, 69, "Snoeien van takken" },
                    { 283, "Breng organische mest rond de basis van de boom aan.", 69, null, false, null, 69, "Bemesten van bomen" },
                    { 284, "Controleer bomen op ziektes of plagen.", 94, null, false, null, 69, "Controle op ziektes en plagen" },
                    { 285, "Geef water aan pas geplante bomen om de groei te ondersteunen.", 39, null, false, null, 69, "Water geven aan jonge bomen" },
                    { 286, "Controleer en herstel boomsteunen of palen indien nodig.", 98, null, false, null, 70, "Controle van boomsteunen" },
                    { 287, "Verwijder invasieve planten of onkruid bij de wortels van de boom.", 71, null, false, null, 70, "Onkruid verwijderen bij wortels" },
                    { 288, "Monitor de bodemkwaliteit en pH rondom de bomen.", 49, null, false, null, 70, "Bodemkwaliteit monitoren" },
                    { 289, "Oogst vruchten of zaden van volwassen bomen.", 45, null, false, null, 70, "Oogsten van vruchten of zaden" },
                    { 290, "Controleer en herstel boomsteunen of palen indien nodig.", 55, null, false, null, 71, "Controle van boomsteunen" },
                    { 291, "Verwijder invasieve planten of onkruid bij de wortels van de boom.", 130, null, false, null, 71, "Onkruid verwijderen bij wortels" },
                    { 292, "Monitor de bodemkwaliteit en pH rondom de bomen.", 63, null, false, null, 71, "Bodemkwaliteit monitoren" },
                    { 293, "Controleer en herstel boomsteunen of palen indien nodig.", 196, null, false, null, 72, "Controle van boomsteunen" },
                    { 294, "Verwijder invasieve planten of onkruid bij de wortels van de boom.", 213, null, false, null, 72, "Onkruid verwijderen bij wortels" },
                    { 295, "Geef water aan pas geplante bomen om de groei te ondersteunen.", 98, null, false, null, 73, "Water geven aan jonge bomen" },
                    { 296, "Breng mulch aan rond de boom om vocht vast te houden en onkruid te voorkomen.", 132, null, false, null, 73, "Mulchen rondom bomen" },
                    { 297, "Controleer en herstel boomsteunen of palen indien nodig.", 127, null, false, null, 73, "Controle van boomsteunen" },
                    { 298, "Snoei dode of overgroeide takken om de boom gezond te houden.", 82, null, false, null, 74, "Snoeien van takken" },
                    { 299, "Breng organische mest rond de basis van de boom aan.", 88, null, false, null, 74, "Bemesten van bomen" },
                    { 300, "Controleer bomen op ziektes of plagen.", 77, null, false, null, 74, "Controle op ziektes en plagen" },
                    { 301, "Geef water aan pas geplante bomen om de groei te ondersteunen.", 115, null, false, null, 74, "Water geven aan jonge bomen" },
                    { 302, "Breng mulch aan rond de boom om vocht vast te houden en onkruid te voorkomen.", 63, null, false, null, 75, "Mulchen rondom bomen" },
                    { 303, "Controleer en herstel boomsteunen of palen indien nodig.", 31, null, false, null, 75, "Controle van boomsteunen" },
                    { 304, "Verwijder invasieve planten of onkruid bij de wortels van de boom.", 48, null, false, null, 75, "Onkruid verwijderen bij wortels" },
                    { 305, "Monitor de bodemkwaliteit en pH rondom de bomen.", 47, null, false, null, 75, "Bodemkwaliteit monitoren" },
                    { 306, "Oogst vruchten of zaden van volwassen bomen.", 46, null, false, null, 75, "Oogsten van vruchten of zaden" },
                    { 307, "Voer een veiligheidscontrole uit en verwijder gevaarlijke takken.", 34, null, false, null, 75, "Veiligheidstakcontrole" },
                    { 308, "Verwijder invasieve planten of onkruid bij de wortels van de boom.", 107, null, false, null, 76, "Onkruid verwijderen bij wortels" },
                    { 309, "Monitor de bodemkwaliteit en pH rondom de bomen.", 199, null, false, null, 76, "Bodemkwaliteit monitoren" },
                    { 310, "Monitor de bodemkwaliteit en pH rondom de bomen.", 74, null, false, null, 77, "Bodemkwaliteit monitoren" },
                    { 311, "Oogst vruchten of zaden van volwassen bomen.", 37, null, false, null, 77, "Oogsten van vruchten of zaden" },
                    { 312, "Voer een veiligheidscontrole uit en verwijder gevaarlijke takken.", 52, null, false, null, 77, "Veiligheidstakcontrole" },
                    { 313, "Snoei dode of overgroeide takken om de boom gezond te houden.", 71, null, false, null, 77, "Snoeien van takken" },
                    { 314, "Breng organische mest rond de basis van de boom aan.", 68, null, false, null, 77, "Bemesten van bomen" },
                    { 315, "Controleer bomen op ziektes of plagen.", 71, null, false, null, 77, "Controle op ziektes en plagen" },
                    { 316, "Geef water aan pas geplante bomen om de groei te ondersteunen.", 86, null, false, null, 78, "Water geven aan jonge bomen" },
                    { 317, "Breng mulch aan rond de boom om vocht vast te houden en onkruid te voorkomen.", 83, null, false, null, 78, "Mulchen rondom bomen" },
                    { 318, "Controleer en herstel boomsteunen of palen indien nodig.", 70, null, false, null, 78, "Controle van boomsteunen" },
                    { 319, "Verwijder invasieve planten of onkruid bij de wortels van de boom.", 52, null, false, null, 78, "Onkruid verwijderen bij wortels" },
                    { 320, "Controleer bomen op ziektes of plagen.", 64, null, false, null, 79, "Controle op ziektes en plagen" },
                    { 321, "Geef water aan pas geplante bomen om de groei te ondersteunen.", 44, null, false, null, 79, "Water geven aan jonge bomen" },
                    { 322, "Breng mulch aan rond de boom om vocht vast te houden en onkruid te voorkomen.", 76, null, false, null, 79, "Mulchen rondom bomen" },
                    { 323, "Controleer en herstel boomsteunen of palen indien nodig.", 35, null, false, null, 79, "Controle van boomsteunen" },
                    { 324, "Verwijder invasieve planten of onkruid bij de wortels van de boom.", 75, null, false, null, 79, "Onkruid verwijderen bij wortels" },
                    { 325, "Monitor de bodemkwaliteit en pH rondom de bomen.", 42, null, false, null, 79, "Bodemkwaliteit monitoren" },
                    { 326, "Monitor de bodemkwaliteit en pH rondom de bomen.", 103, null, false, null, 80, "Bodemkwaliteit monitoren" },
                    { 327, "Oogst vruchten of zaden van volwassen bomen.", 45, null, false, null, 80, "Oogsten van vruchten of zaden" },
                    { 328, "Voer een veiligheidscontrole uit en verwijder gevaarlijke takken.", 65, null, false, null, 80, "Veiligheidstakcontrole" },
                    { 329, "Snoei dode of overgroeide takken om de boom gezond te houden.", 110, null, false, null, 80, "Snoeien van takken" },
                    { 330, "Breng mulch aan rond de boom om vocht vast te houden en onkruid te voorkomen.", 65, null, false, null, 81, "Mulchen rondom bomen" },
                    { 331, "Controleer en herstel boomsteunen of palen indien nodig.", 40, null, false, null, 81, "Controle van boomsteunen" },
                    { 332, "Verwijder invasieve planten of onkruid bij de wortels van de boom.", 77, null, false, null, 81, "Onkruid verwijderen bij wortels" },
                    { 333, "Monitor de bodemkwaliteit en pH rondom de bomen.", 54, null, false, null, 81, "Bodemkwaliteit monitoren" },
                    { 334, "Oogst vruchten of zaden van volwassen bomen.", 71, null, false, null, 81, "Oogsten van vruchten of zaden" },
                    { 335, "Voer een veiligheidscontrole uit en verwijder gevaarlijke takken.", 33, null, false, null, 81, "Veiligheidstakcontrole" },
                    { 336, "Controleer bomen op ziektes of plagen.", 53, null, false, null, 82, "Controle op ziektes en plagen" },
                    { 337, "Geef water aan pas geplante bomen om de groei te ondersteunen.", 57, null, false, null, 82, "Water geven aan jonge bomen" },
                    { 338, "Breng mulch aan rond de boom om vocht vast te houden en onkruid te voorkomen.", 62, null, false, null, 82, "Mulchen rondom bomen" },
                    { 339, "Controleer en herstel boomsteunen of palen indien nodig.", 55, null, false, null, 82, "Controle van boomsteunen" },
                    { 340, "Verwijder invasieve planten of onkruid bij de wortels van de boom.", 51, null, false, null, 82, "Onkruid verwijderen bij wortels" },
                    { 341, "Monitor de bodemkwaliteit en pH rondom de bomen.", 46, null, false, null, 82, "Bodemkwaliteit monitoren" },
                    { 342, "Oogst vruchten of zaden van volwassen bomen.", 60, null, false, null, 82, "Oogsten van vruchten of zaden" },
                    { 343, "Controleer en herstel boomsteunen of palen indien nodig.", 55, null, false, null, 83, "Controle van boomsteunen" },
                    { 344, "Verwijder invasieve planten of onkruid bij de wortels van de boom.", 142, null, false, null, 83, "Onkruid verwijderen bij wortels" },
                    { 345, "Geef water aan pas geplante bomen om de groei te ondersteunen.", 191, null, false, null, 84, "Water geven aan jonge bomen" },
                    { 346, "Breng mulch aan rond de boom om vocht vast te houden en onkruid te voorkomen.", 179, null, false, null, 84, "Mulchen rondom bomen" },
                    { 347, "Oogst vruchten of zaden van volwassen bomen.", 86, null, false, null, 85, "Oogsten van vruchten of zaden" },
                    { 348, "Voer een veiligheidscontrole uit en verwijder gevaarlijke takken.", 74, null, false, null, 85, "Veiligheidstakcontrole" },
                    { 349, "Snoei dode of overgroeide takken om de boom gezond te houden.", 45, null, false, null, 85, "Snoeien van takken" },
                    { 350, "Controleer bomen op ziektes of plagen.", 86, null, false, null, 86, "Controle op ziektes en plagen" },
                    { 351, "Geef water aan pas geplante bomen om de groei te ondersteunen.", 142, null, false, null, 86, "Water geven aan jonge bomen" },
                    { 352, "Breng mulch aan rond de boom om vocht vast te houden en onkruid te voorkomen.", 31, null, false, null, 86, "Mulchen rondom bomen" },
                    { 353, "Verwijder invasieve planten of onkruid bij de wortels van de boom.", 45, null, false, null, 87, "Onkruid verwijderen bij wortels" },
                    { 354, "Monitor de bodemkwaliteit en pH rondom de bomen.", 53, null, false, null, 87, "Bodemkwaliteit monitoren" },
                    { 355, "Oogst vruchten of zaden van volwassen bomen.", 65, null, false, null, 87, "Oogsten van vruchten of zaden" },
                    { 356, "Voer een veiligheidscontrole uit en verwijder gevaarlijke takken.", 45, null, false, null, 87, "Veiligheidstakcontrole" },
                    { 357, "Snoei dode of overgroeide takken om de boom gezond te houden.", 57, null, false, null, 87, "Snoeien van takken" },
                    { 358, "Breng organische mest rond de basis van de boom aan.", 44, null, false, null, 87, "Bemesten van bomen" },
                    { 359, "Controleer bomen op ziektes of plagen.", 46, null, false, null, 87, "Controle op ziektes en plagen" },
                    { 360, "Controleer bomen op ziektes of plagen.", 41, null, false, null, 88, "Controle op ziektes en plagen" },
                    { 361, "Geef water aan pas geplante bomen om de groei te ondersteunen.", 41, null, false, null, 88, "Water geven aan jonge bomen" },
                    { 362, "Breng mulch aan rond de boom om vocht vast te houden en onkruid te voorkomen.", 63, null, false, null, 88, "Mulchen rondom bomen" },
                    { 363, "Controleer en herstel boomsteunen of palen indien nodig.", 76, null, false, null, 88, "Controle van boomsteunen" },
                    { 364, "Verwijder invasieve planten of onkruid bij de wortels van de boom.", 77, null, false, null, 88, "Onkruid verwijderen bij wortels" },
                    { 365, "Monitor de bodemkwaliteit en pH rondom de bomen.", 66, null, false, null, 88, "Bodemkwaliteit monitoren" },
                    { 366, "Controleer bomen op ziektes of plagen.", 54, null, false, null, 89, "Controle op ziektes en plagen" },
                    { 367, "Geef water aan pas geplante bomen om de groei te ondersteunen.", 77, null, false, null, 89, "Water geven aan jonge bomen" },
                    { 368, "Breng mulch aan rond de boom om vocht vast te houden en onkruid te voorkomen.", 33, null, false, null, 89, "Mulchen rondom bomen" },
                    { 369, "Controleer en herstel boomsteunen of palen indien nodig.", 91, null, false, null, 89, "Controle van boomsteunen" },
                    { 370, "Verwijder invasieve planten of onkruid bij de wortels van de boom.", 62, null, false, null, 89, "Onkruid verwijderen bij wortels" },
                    { 371, "Verwijder invasieve planten of onkruid bij de wortels van de boom.", 49, null, false, null, 90, "Onkruid verwijderen bij wortels" },
                    { 372, "Monitor de bodemkwaliteit en pH rondom de bomen.", 65, null, false, null, 90, "Bodemkwaliteit monitoren" },
                    { 373, "Oogst vruchten of zaden van volwassen bomen.", 65, null, false, null, 90, "Oogsten van vruchten of zaden" },
                    { 374, "Voer een veiligheidscontrole uit en verwijder gevaarlijke takken.", 76, null, false, null, 90, "Veiligheidstakcontrole" },
                    { 375, "Snoei dode of overgroeide takken om de boom gezond te houden.", 46, null, false, null, 90, "Snoeien van takken" },
                    { 376, "Breng organische mest rond de basis van de boom aan.", 45, null, false, null, 90, "Bemesten van bomen" },
                    { 377, "Verwijder invasieve planten of onkruid bij de wortels van de boom.", 158, null, false, null, 91, "Onkruid verwijderen bij wortels" },
                    { 378, "Monitor de bodemkwaliteit en pH rondom de bomen.", 197, null, false, null, 91, "Bodemkwaliteit monitoren" },
                    { 379, "Breng mulch aan rond de boom om vocht vast te houden en onkruid te voorkomen.", 85, null, false, null, 92, "Mulchen rondom bomen" },
                    { 380, "Controleer en herstel boomsteunen of palen indien nodig.", 93, null, false, null, 92, "Controle van boomsteunen" },
                    { 381, "Verwijder invasieve planten of onkruid bij de wortels van de boom.", 100, null, false, null, 92, "Onkruid verwijderen bij wortels" },
                    { 382, "Monitor de bodemkwaliteit en pH rondom de bomen.", 92, null, false, null, 92, "Bodemkwaliteit monitoren" },
                    { 383, "Breng organische mest rond de basis van de boom aan.", 48, null, false, null, 93, "Bemesten van bomen" },
                    { 384, "Controleer bomen op ziektes of plagen.", 30, null, false, null, 93, "Controle op ziektes en plagen" },
                    { 385, "Geef water aan pas geplante bomen om de groei te ondersteunen.", 54, null, false, null, 93, "Water geven aan jonge bomen" },
                    { 386, "Breng mulch aan rond de boom om vocht vast te houden en onkruid te voorkomen.", 58, null, false, null, 93, "Mulchen rondom bomen" },
                    { 387, "Controleer en herstel boomsteunen of palen indien nodig.", 44, null, false, null, 93, "Controle van boomsteunen" },
                    { 388, "Verwijder invasieve planten of onkruid bij de wortels van de boom.", 35, null, false, null, 93, "Onkruid verwijderen bij wortels" },
                    { 389, "Monitor de bodemkwaliteit en pH rondom de bomen.", 50, null, false, null, 93, "Bodemkwaliteit monitoren" },
                    { 390, "Breng organische mest rond de basis van de boom aan.", 54, null, false, null, 94, "Bemesten van bomen" },
                    { 391, "Controleer bomen op ziektes of plagen.", 43, null, false, null, 94, "Controle op ziektes en plagen" },
                    { 392, "Geef water aan pas geplante bomen om de groei te ondersteunen.", 74, null, false, null, 94, "Water geven aan jonge bomen" },
                    { 393, "Breng mulch aan rond de boom om vocht vast te houden en onkruid te voorkomen.", 63, null, false, null, 94, "Mulchen rondom bomen" },
                    { 394, "Controleer en herstel boomsteunen of palen indien nodig.", 75, null, false, null, 94, "Controle van boomsteunen" },
                    { 395, "Verwijder invasieve planten of onkruid bij de wortels van de boom.", 75, null, false, null, 94, "Onkruid verwijderen bij wortels" },
                    { 396, "Snoei dode of overgroeide takken om de boom gezond te houden.", 31, null, false, null, 95, "Snoeien van takken" },
                    { 397, "Breng organische mest rond de basis van de boom aan.", 117, null, false, null, 95, "Bemesten van bomen" },
                    { 398, "Controleer bomen op ziektes of plagen.", 91, null, false, null, 95, "Controle op ziektes en plagen" },
                    { 399, "Oogst vruchten of zaden van volwassen bomen.", 58, null, false, null, 96, "Oogsten van vruchten of zaden" },
                    { 400, "Voer een veiligheidscontrole uit en verwijder gevaarlijke takken.", 100, null, false, null, 96, "Veiligheidstakcontrole" },
                    { 401, "Snoei dode of overgroeide takken om de boom gezond te houden.", 38, null, false, null, 96, "Snoeien van takken" },
                    { 402, "Controleer en herstel boomsteunen of palen indien nodig.", 94, null, false, null, 97, "Controle van boomsteunen" },
                    { 403, "Verwijder invasieve planten of onkruid bij de wortels van de boom.", 234, null, false, null, 97, "Onkruid verwijderen bij wortels" },
                    { 404, "Controleer en herstel boomsteunen of palen indien nodig.", 31, null, false, null, 98, "Controle van boomsteunen" },
                    { 405, "Verwijder invasieve planten of onkruid bij de wortels van de boom.", 36, null, false, null, 98, "Onkruid verwijderen bij wortels" },
                    { 406, "Monitor de bodemkwaliteit en pH rondom de bomen.", 85, null, false, null, 98, "Bodemkwaliteit monitoren" },
                    { 407, "Oogst vruchten of zaden van volwassen bomen.", 94, null, false, null, 98, "Oogsten van vruchten of zaden" },
                    { 408, "Voer een veiligheidscontrole uit en verwijder gevaarlijke takken.", 75, null, false, null, 98, "Veiligheidstakcontrole" },
                    { 409, "Verwijder invasieve planten of onkruid bij de wortels van de boom.", 42, null, false, null, 99, "Onkruid verwijderen bij wortels" },
                    { 410, "Monitor de bodemkwaliteit en pH rondom de bomen.", 50, null, false, null, 99, "Bodemkwaliteit monitoren" },
                    { 411, "Oogst vruchten of zaden van volwassen bomen.", 44, null, false, null, 99, "Oogsten van vruchten of zaden" },
                    { 412, "Voer een veiligheidscontrole uit en verwijder gevaarlijke takken.", 54, null, false, null, 99, "Veiligheidstakcontrole" },
                    { 413, "Snoei dode of overgroeide takken om de boom gezond te houden.", 35, null, false, null, 99, "Snoeien van takken" },
                    { 414, "Breng organische mest rond de basis van de boom aan.", 49, null, false, null, 99, "Bemesten van bomen" },
                    { 415, "Controleer bomen op ziektes of plagen.", 44, null, false, null, 99, "Controle op ziektes en plagen" },
                    { 416, "Breng organische mest rond de basis van de boom aan.", 52, null, false, null, 100, "Bemesten van bomen" },
                    { 417, "Controleer bomen op ziektes of plagen.", 55, null, false, null, 100, "Controle op ziektes en plagen" },
                    { 418, "Geef water aan pas geplante bomen om de groei te ondersteunen.", 44, null, false, null, 100, "Water geven aan jonge bomen" },
                    { 419, "Breng mulch aan rond de boom om vocht vast te houden en onkruid te voorkomen.", 64, null, false, null, 100, "Mulchen rondom bomen" },
                    { 420, "Controleer en herstel boomsteunen of palen indien nodig.", 68, null, false, null, 100, "Controle van boomsteunen" },
                    { 421, "Verwijder invasieve planten of onkruid bij de wortels van de boom.", 31, null, false, null, 100, "Onkruid verwijderen bij wortels" },
                    { 422, "Monitor de bodemkwaliteit en pH rondom de bomen.", 84, null, false, null, 101, "Bodemkwaliteit monitoren" },
                    { 423, "Oogst vruchten of zaden van volwassen bomen.", 100, null, false, null, 101, "Oogsten van vruchten of zaden" },
                    { 424, "Voer een veiligheidscontrole uit en verwijder gevaarlijke takken.", 39, null, false, null, 101, "Veiligheidstakcontrole" },
                    { 425, "Snoei dode of overgroeide takken om de boom gezond te houden.", 91, null, false, null, 101, "Snoeien van takken" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 120);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 121);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 122);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 123);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 124);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 125);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 126);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 127);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 128);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 129);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 130);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 131);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 132);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 133);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 134);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 135);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 136);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 137);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 138);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 139);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 140);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 141);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 142);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 143);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 144);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 145);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 146);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 147);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 148);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 149);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 150);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 151);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 152);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 153);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 154);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 155);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 156);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 157);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 158);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 159);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 160);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 161);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 162);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 163);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 164);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 165);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 166);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 167);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 168);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 169);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 170);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 171);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 172);

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

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 204);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 205);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 206);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 207);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 208);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 209);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 210);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 211);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 212);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 213);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 214);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 215);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 216);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 217);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 218);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 219);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 220);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 221);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 222);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 223);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 224);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 225);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 226);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 227);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 228);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 229);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 230);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 231);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 232);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 233);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 234);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 235);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 236);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 237);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 238);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 239);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 240);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 241);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 242);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 243);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 244);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 245);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 246);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 247);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 248);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 249);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 250);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 251);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 252);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 253);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 254);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 255);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 256);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 257);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 258);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 259);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 260);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 261);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 262);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 263);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 264);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 265);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 266);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 267);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 268);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 269);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 270);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 271);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 272);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 273);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 274);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 275);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 276);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 277);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 278);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 279);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 280);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 281);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 282);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 283);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 284);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 285);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 286);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 287);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 288);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 289);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 290);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 291);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 292);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 293);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 294);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 295);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 296);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 297);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 298);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 299);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 300);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 301);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 302);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 303);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 304);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 305);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 306);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 307);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 308);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 309);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 310);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 311);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 312);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 313);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 314);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 315);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 316);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 317);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 318);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 319);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 320);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 321);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 322);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 323);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 324);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 325);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 326);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 327);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 328);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 329);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 330);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 331);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 332);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 333);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 334);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 335);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 336);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 337);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 338);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 339);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 340);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 341);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 342);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 343);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 344);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 345);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 346);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 347);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 348);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 349);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 350);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 351);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 352);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 353);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 354);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 355);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 356);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 357);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 358);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 359);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 360);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 361);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 362);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 363);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 364);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 365);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 366);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 367);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 368);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 369);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 370);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 371);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 372);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 373);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 374);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 375);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 376);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 377);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 378);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 379);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 380);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 381);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 382);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 383);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 384);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 385);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 386);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 387);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 388);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 389);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 390);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 391);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 392);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 393);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 394);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 395);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 396);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 397);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 398);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 399);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 400);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 401);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 402);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 403);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 404);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 405);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 406);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 407);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 408);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 409);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 410);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 411);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 412);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 413);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 414);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 415);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 416);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 417);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 418);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 419);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 420);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 421);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 422);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 423);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 424);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 425);
        }
    }
}
