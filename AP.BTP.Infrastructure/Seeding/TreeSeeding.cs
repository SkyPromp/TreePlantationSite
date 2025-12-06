using AP.BTP.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AP.BTP.Infrastructure.Seeding
{
    /// <summary>
    /// Provides extension methods to seed <see cref="Tree"/> entities into the database.
    /// </summary>
    public static class TreeSeeding
    {
        /// <summary>
        /// Seeds the <see cref="Tree"/> entity with 50 sample records.
        /// </summary>
        /// <param name="builder">
        /// The <see cref="EntityTypeBuilder{Tree}"/> used to configure the <see cref="Tree"/> entity.
        /// </param>
        /// <remarks>
        /// Each seeded <see cref="Tree"/> entity will have:
        /// <list type="bullet">
        /// <item><description>An <see cref="Tree.Id"/> from 1 to 50.</description></item>
        /// <item><description>A unique <see cref="Tree.Species"/> name, e.g., "Tree 1", "Tree 2", etc.</description></item>
        /// <item><description>Empty strings for all seasonal <see cref="Tree.MaintenancePlan"/> fields (<see cref="Tree.MaintenancePlanSpring"/>, <see cref="Tree.MaintenancePlanSummer"/>, <see cref="Tree.MaintenancePlanAutumn"/>, <see cref="Tree.MaintenancePlanWinter"/>).</description></item>
        /// <item><description><see cref="Tree.IsDeleted"/> set to <c>false</c>.</description></item>
        /// </list>
        /// The method uses <see cref="HasData(IEnumerable{Tree})"/> to insert the data
        /// during database creation or migrations.
        /// </remarks>
        public static void Seed(this EntityTypeBuilder<Tree> builder)
        {
            List<Tree> trees = new List<Tree>();

            trees.Add(new Tree() { Id = 1, Species = "Amerikaans krentenboompje" });
            trees.Add(new Tree() { Id = 2, Species = "Amerikaans krentenboompje ‘Robin Hill’" });
            trees.Add(new Tree() { Id = 3, Species = "Amerikaanse amberboom" });
            trees.Add(new Tree() { Id = 4, Species = "Amerikaanse amberboom ‘Worplesdon’" });
            trees.Add(new Tree() { Id = 5, Species = "Amerikaanse eik" });
            trees.Add(new Tree() { Id = 6, Species = "Amerikaanse es" });
            trees.Add(new Tree() { Id = 7, Species = "Amerikaanse es ‘Skyline’" });
            trees.Add(new Tree() { Id = 8, Species = "Amerikaanse gleditsia" });
            trees.Add(new Tree() { Id = 9, Species = "Amerikaanse gleditsia ‘Elegantissima’" });
            trees.Add(new Tree() { Id = 10, Species = "Amerikaanse gleditsia ‘Skyline’" });
            trees.Add(new Tree() { Id = 11, Species = "Amerikaanse gleditsia ‘Sunburst’" });
            trees.Add(new Tree() { Id = 12, Species = "Amerikaanse gleditsia f. inermis" });
            trees.Add(new Tree() { Id = 13, Species = "Amerikaanse Judasboom" });
            trees.Add(new Tree() { Id = 14, Species = "Amerikaanse linde" });
            trees.Add(new Tree() { Id = 15, Species = "Amerikaanse tulpenboom" });
            trees.Add(new Tree() { Id = 16, Species = "Amerikaanse tulpenboom ‘Fastigiatum’" });
            trees.Add(new Tree() { Id = 17, Species = "Amerikaanse vogelkers" });
            trees.Add(new Tree() { Id = 18, Species = "Amoer-kurkboom" });
            trees.Add(new Tree() { Id = 19, Species = "Anna Paulownaboom" });
            trees.Add(new Tree() { Id = 20, Species = "Antarctische schijnbeuk" });
            trees.Add(new Tree() { Id = 21, Species = "Basterd meidoorn" });
            trees.Add(new Tree() { Id = 22, Species = "Basterd-goudenregen" });
            trees.Add(new Tree() { Id = 23, Species = "Beuk" });
            trees.Add(new Tree() { Id = 24, Species = "Beuk ‘Dawyck’" });
            trees.Add(new Tree() { Id = 25, Species = "Bijenboom" });
            trees.Add(new Tree() { Id = 26, Species = "Biltmoreana es" });
            trees.Add(new Tree() { Id = 27, Species = "Blauwe spar" });
            trees.Add(new Tree() { Id = 28, Species = "Bolprunus" });
            trees.Add(new Tree() { Id = 29, Species = "Boltrompetboom" });
            trees.Add(new Tree() { Id = 30, Species = "Bonte gladde iep" });
            trees.Add(new Tree() { Id = 31, Species = "Boomhazelaar" });
            trees.Add(new Tree() { Id = 32, Species = "Bosmagnolia" });
            trees.Add(new Tree() { Id = 33, Species = "Boswilg" });
            trees.Add(new Tree() { Id = 34, Species = "Breedbladige meelbes" });
            trees.Add(new Tree() { Id = 35, Species = "Bruine beuk" });
            trees.Add(new Tree() { Id = 36, Species = "Bruine treurbeuk" });
            trees.Add(new Tree() { Id = 37, Species = "Californische cipres" });
            trees.Add(new Tree() { Id = 38, Species = "Canada populier ‘Robusta’" });
            trees.Add(new Tree() { Id = 39, Species = "Canadapopulier" });
            trees.Add(new Tree() { Id = 40, Species = "Chinese balsempopulier ‘Fastigiata’" });
            trees.Add(new Tree() { Id = 41, Species = "Chinese treurwilg" });
            trees.Add(new Tree() { Id = 42, Species = "Colchische esdoorn" });
            trees.Add(new Tree() { Id = 43, Species = "Davids esdoorn" });
            trees.Add(new Tree() { Id = 44, Species = "Doodsbeenderenboom" });
            trees.Add(new Tree() { Id = 45, Species = "Douglasspar" });
            trees.Add(new Tree() { Id = 46, Species = "Drietandesdoorn" });
            trees.Add(new Tree() { Id = 47, Species = "Dubbelbloemige paardenkastanje" });
            trees.Add(new Tree() { Id = 48, Species = "Duiveltjesiep" });
            trees.Add(new Tree() { Id = 49, Species = "Eenbladige es" });
            trees.Add(new Tree() { Id = 50, Species = "Eenbladige robinia" });
            trees.Add(new Tree() { Id = 51, Species = "Eenstijlige meidoorn" });
            trees.Add(new Tree() { Id = 52, Species = "Eenstijlige meidoorn ‘Stricta’" });
            trees.Add(new Tree() { Id = 53, Species = "Eetappel" });
            trees.Add(new Tree() { Id = 54, Species = "Eik ‘Columna’" });
            trees.Add(new Tree() { Id = 55, Species = "Es" });
            trees.Add(new Tree() { Id = 56, Species = "Es ‘Altena’" });
            trees.Add(new Tree() { Id = 57, Species = "Es ‘Atlas’" });
            trees.Add(new Tree() { Id = 58, Species = "Es ‘Nana’" });
            trees.Add(new Tree() { Id = 59, Species = "Es ‘Westhof’s Glorie’" });
            trees.Add(new Tree() { Id = 60, Species = "Esdoornbladige plataan" });
            trees.Add(new Tree() { Id = 61, Species = "Esdoornbladige plataan ‘Alphen’s Globe’" });
            trees.Add(new Tree() { Id = 62, Species = "Esdoornbladige plataan ‘Tremonia’" });
            trees.Add(new Tree() { Id = 63, Species = "Europese hopbeuk" });
            trees.Add(new Tree() { Id = 64, Species = "Europese judasboom" });
            trees.Add(new Tree() { Id = 65, Species = "Europese larix" });
            trees.Add(new Tree() { Id = 66, Species = "Europese netelboom" });
            trees.Add(new Tree() { Id = 67, Species = "Fijnspar" });
            trees.Add(new Tree() { Id = 68, Species = "Finse meelbes ‘Gibbsii’" });
            trees.Add(new Tree() { Id = 69, Species = "Fladderiep" });
            trees.Add(new Tree() { Id = 70, Species = "Gedeelde meelbes" });
            trees.Add(new Tree() { Id = 71, Species = "Geelbladige trompetboom" });
            trees.Add(new Tree() { Id = 72, Species = "Gele bergiep" });
            trees.Add(new Tree() { Id = 73, Species = "Gele kornoelje" });
            trees.Add(new Tree() { Id = 74, Species = "Gele pavia" });
            trees.Add(new Tree() { Id = 75, Species = "Gele treurwilg" });
            trees.Add(new Tree() { Id = 76, Species = "Gele zeepboom" });
            trees.Add(new Tree() { Id = 77, Species = "Gele zeepboom ‘Fastigiata’" });
            trees.Add(new Tree() { Id = 78, Species = "Geveerdbladige esdoorn" });
            trees.Add(new Tree() { Id = 79, Species = "Geveerdbladige lijsterbes" });
            trees.Add(new Tree() { Id = 80, Species = "Gewone esdoorn" });
            trees.Add(new Tree() { Id = 81, Species = "Gewone esdoorn ‘Atropurpureum’" });
            trees.Add(new Tree() { Id = 82, Species = "Gewone esdoorn ‘Leopoldii’" });
            trees.Add(new Tree() { Id = 83, Species = "Gewone magnolia" });
            trees.Add(new Tree() { Id = 84, Species = "Gewone vijg" });
            trees.Add(new Tree() { Id = 85, Species = "Gewone vlier" });
            trees.Add(new Tree() { Id = 86, Species = "Gewone vogelkers" });
            trees.Add(new Tree() { Id = 87, Species = "Gewone walnoot" });
            trees.Add(new Tree() { Id = 88, Species = "Ginkgo" });
            trees.Add(new Tree() { Id = 89, Species = "Gladde iep" });
            trees.Add(new Tree() { Id = 90, Species = "Goudberk ‘Blush’" });
            trees.Add(new Tree() { Id = 91, Species = "Goudberk ‘Holland’" });
            trees.Add(new Tree() { Id = 92, Species = "Goudels" });
            trees.Add(new Tree() { Id = 93, Species = "Goudenregen" });
            trees.Add(new Tree() { Id = 94, Species = "Goudes" });
            trees.Add(new Tree() { Id = 95, Species = "Goudiep" });
            trees.Add(new Tree() { Id = 96, Species = "Grauwe abeel" });
            trees.Add(new Tree() { Id = 97, Species = "Grauwe abeel ‘De Moffart’" });
            trees.Add(new Tree() { Id = 98, Species = "Grootbladige els" });
            trees.Add(new Tree() { Id = 99, Species = "Grootbloemige trompetboom" });
            trees.Add(new Tree() { Id = 100, Species = "Grove den" });
            trees.Add(new Tree() { Id = 101, Species = "Haagbeuk" });
            trees.Add(new Tree() { Id = 102, Species = "Haagbeuk ‘Fastigiata’" });
            trees.Add(new Tree() { Id = 103, Species = "Haagbeuk ‘Frans Fontaine’" });
            trees.Add(new Tree() { Id = 104, Species = "Hartbladige els" });
            trees.Add(new Tree() { Id = 105, Species = "Hemelboom" });
            trees.Add(new Tree() { Id = 106, Species = "Himalaya-berk ‘Doorenbos’" });
            trees.Add(new Tree() { Id = 107, Species = "Himalaya-ceder" });
            trees.Add(new Tree() { Id = 108, Species = "Hollandse iep ‘Belgica’" });
            trees.Add(new Tree() { Id = 109, Species = "Hollandse linde" });
            trees.Add(new Tree() { Id = 110, Species = "Hongaarse eik" });
            trees.Add(new Tree() { Id = 111, Species = "Hulst" });
            trees.Add(new Tree() { Id = 112, Species = "Huntingdons iep" });
            trees.Add(new Tree() { Id = 113, Species = "Iep ‘Columella’" });
            trees.Add(new Tree() { Id = 114, Species = "Iep ‘Dodoens’" });
            trees.Add(new Tree() { Id = 115, Species = "Iep ‘Frontier’" });
            trees.Add(new Tree() { Id = 116, Species = "Iep ‘Lobel’" });
            trees.Add(new Tree() { Id = 117, Species = "Iep ‘New Horizon’" });
            trees.Add(new Tree() { Id = 118, Species = "Iep ‘Plantijn’" });
            trees.Add(new Tree() { Id = 119, Species = "Iep ‘Rebona’" });
            trees.Add(new Tree() { Id = 120, Species = "Ierse taxus" });
            trees.Add(new Tree() { Id = 121, Species = "Italiaanse populier" });
            trees.Add(new Tree() { Id = 122, Species = "Japanse esdoorn" });
            trees.Add(new Tree() { Id = 123, Species = "Japanse grootbloemige kornoelje" });
            trees.Add(new Tree() { Id = 124, Species = "Japanse honingboom" });
            trees.Add(new Tree() { Id = 125, Species = "Japanse honingboom ‘Harrie van Haaren’" });
            trees.Add(new Tree() { Id = 126, Species = "Japanse honingboom ‘Pendula’" });
            trees.Add(new Tree() { Id = 127, Species = "Japanse larix" });
            trees.Add(new Tree() { Id = 128, Species = "Japanse sierkers" });
            trees.Add(new Tree() { Id = 129, Species = "Japanse sierkers ‘Amanogawa’" });
            trees.Add(new Tree() { Id = 130, Species = "Japanse sierkers ‘Kanzan’" });
            trees.Add(new Tree() { Id = 131, Species = "Katsuraboom" });
            trees.Add(new Tree() { Id = 132, Species = "Kaukasische els" });
            trees.Add(new Tree() { Id = 133, Species = "Kaukasische vleugelnoot" });
            trees.Add(new Tree() { Id = 134, Species = "Kerspruim ‘Nigra’" });
            trees.Add(new Tree() { Id = 135, Species = "Kleverige robinia" });
            trees.Add(new Tree() { Id = 136, Species = "Kogelrobinia" });
            trees.Add(new Tree() { Id = 137, Species = "Koningslinde" });
            trees.Add(new Tree() { Id = 138, Species = "Krimlinde" });
            trees.Add(new Tree() { Id = 139, Species = "Krulwilg" });
            trees.Add(new Tree() { Id = 140, Species = "Kust sequoia" });
            trees.Add(new Tree() { Id = 141, Species = "Libanonceder" });
            trees.Add(new Tree() { Id = 142, Species = "Libanonceder ‘Glauca’" });
            trees.Add(new Tree() { Id = 143, Species = "Mammoetboom" });
            trees.Add(new Tree() { Id = 144, Species = "Meelbes" });
            trees.Add(new Tree() { Id = 145, Species = "Mispel" });
            trees.Add(new Tree() { Id = 146, Species = "Moerascipres" });
            trees.Add(new Tree() { Id = 147, Species = "Moeraseik" });
            trees.Add(new Tree() { Id = 148, Species = "Moeraseik ‘Green Pillar’" });
            trees.Add(new Tree() { Id = 149, Species = "Mongoolse linde" });
            trees.Add(new Tree() { Id = 150, Species = "Monumentaal-iep" });
            trees.Add(new Tree() { Id = 151, Species = "Moseik" });
            trees.Add(new Tree() { Id = 152, Species = "Noordelijke Japanse magnolia" });
            trees.Add(new Tree() { Id = 153, Species = "Noorse bolesdoorn" });
            trees.Add(new Tree() { Id = 154, Species = "Noorse esdoorn" });
            trees.Add(new Tree() { Id = 155, Species = "Noorse esdoorn ‘Crimson King’" });
            trees.Add(new Tree() { Id = 156, Species = "Noorse esdoorn ‘Drumondii’" });
            trees.Add(new Tree() { Id = 157, Species = "Noorse esdoorn ‘Faassen’s Black’" });
            trees.Add(new Tree() { Id = 158, Species = "Olijf" });
            trees.Add(new Tree() { Id = 159, Species = "Oostelijke hemlockspar" });
            trees.Add(new Tree() { Id = 160, Species = "Oostenrijkse den" });
            trees.Add(new Tree() { Id = 161, Species = "Oostenrijkse eik" });
            trees.Add(new Tree() { Id = 162, Species = "Oosterse plataan" });
            trees.Add(new Tree() { Id = 163, Species = "Oosterse plataan ‘Digitata’" });
            trees.Add(new Tree() { Id = 164, Species = "Papierberk" });
            trees.Add(new Tree() { Id = 165, Species = "Papieresdoorn" });
            trees.Add(new Tree() { Id = 166, Species = "Papiermoerbei" });
            trees.Add(new Tree() { Id = 167, Species = "Peer" });
            trees.Add(new Tree() { Id = 168, Species = "Peer ‘Beech Hill’" });
            trees.Add(new Tree() { Id = 169, Species = "Pennsylvaanse es" });
            trees.Add(new Tree() { Id = 170, Species = "Pennsylvaanse es ‘Zundert’" });
            trees.Add(new Tree() { Id = 171, Species = "Perzisch ijzerhout" });
            trees.Add(new Tree() { Id = 172, Species = "Perzische slaapboom" });
            trees.Add(new Tree() { Id = 173, Species = "Pluim-es" });
            trees.Add(new Tree() { Id = 174, Species = "Pluim-es ‘Mecsek’" });
            trees.Add(new Tree() { Id = 175, Species = "Pluim-iep" });
            trees.Add(new Tree() { Id = 176, Species = "Prieel-iep" });
            trees.Add(new Tree() { Id = 177, Species = "Prieelberk" });
            trees.Add(new Tree() { Id = 178, Species = "Pruimbladige meidoorn ‘Splendens’" });
            trees.Add(new Tree() { Id = 179, Species = "Ratelpopulier" });
            trees.Add(new Tree() { Id = 180, Species = "Reuzenkornoelje" });
            trees.Add(new Tree() { Id = 181, Species = "Reuzenlevensboom" });
            trees.Add(new Tree() { Id = 182, Species = "Reuzenzilverspar" });
            trees.Add(new Tree() { Id = 183, Species = "Robinia" });
            trees.Add(new Tree() { Id = 184, Species = "Robinia ‘Bessoniana’" });
            trees.Add(new Tree() { Id = 185, Species = "Robinia ‘Decaisneana’" });
            trees.Add(new Tree() { Id = 186, Species = "Robinia ‘Frisia’" });
            trees.Add(new Tree() { Id = 187, Species = "Robinia ‘Pink Cascade’" });
            trees.Add(new Tree() { Id = 188, Species = "Robinia ‘Pyramidalis’" });
            trees.Add(new Tree() { Id = 189, Species = "Rode esdoorn" });
            trees.Add(new Tree() { Id = 190, Species = "Rode paardenkastanje" });
            trees.Add(new Tree() { Id = 191, Species = "Rode paardenkastanje ‘Briotii’" });
            trees.Add(new Tree() { Id = 192, Species = "Rode pavia" });
            trees.Add(new Tree() { Id = 193, Species = "Rondbladige beuk" });
            trees.Add(new Tree() { Id = 194, Species = "Ruwe berk" });
            trees.Add(new Tree() { Id = 195, Species = "Ruwe berk ‘Fastigiata’" });
            trees.Add(new Tree() { Id = 196, Species = "Ruwe berk ‘Zwitsers Glorie’" });
            trees.Add(new Tree() { Id = 197, Species = "Ruwe iep" });
            trees.Add(new Tree() { Id = 198, Species = "Ruwvruchtige populier" });
            trees.Add(new Tree() { Id = 199, Species = "Scharlaken eik ‘Splendens’" });
            trees.Add(new Tree() { Id = 200, Species = "Schietwilg" });
            trees.Add(new Tree() { Id = 201, Species = "Schietwilg ‘Chermesina’" });
            trees.Add(new Tree() { Id = 202, Species = "Servische spar" });
            trees.Add(new Tree() { Id = 203, Species = "Siberische balsempopulier" });
            trees.Add(new Tree() { Id = 204, Species = "Sierappel" });
            trees.Add(new Tree() { Id = 205, Species = "Sierappel" });
            trees.Add(new Tree() { Id = 206, Species = "Sierappel" });
            trees.Add(new Tree() { Id = 207, Species = "Sierkers gondouinii ‘Schnee’" });
            trees.Add(new Tree() { Id = 208, Species = "Sierkers sargentii ‘Rancho’" });
            trees.Add(new Tree() { Id = 209, Species = "Sierpeer ‘Chanticleer’" });
            trees.Add(new Tree() { Id = 210, Species = "Sitka spar" });
            trees.Add(new Tree() { Id = 211, Species = "Slangenden" });
            trees.Add(new Tree() { Id = 212, Species = "Sleedoorn" });
            trees.Add(new Tree() { Id = 213, Species = "Smalbladige es" });
            trees.Add(new Tree() { Id = 214, Species = "Smalbladige es ‘Raywood’" });
            trees.Add(new Tree() { Id = 215, Species = "Smalle olijfwilg" });
            trees.Add(new Tree() { Id = 216, Species = "Sneeuwklokjesboom" });
            trees.Add(new Tree() { Id = 217, Species = "Spaanse aak" });
            trees.Add(new Tree() { Id = 218, Species = "Spaanse aak ‘Elsrijk’" });
            trees.Add(new Tree() { Id = 219, Species = "Spaanse eik" });
            trees.Add(new Tree() { Id = 220, Species = "Steeneik" });
            trees.Add(new Tree() { Id = 221, Species = "Suikeresdoorn" });
            trees.Add(new Tree() { Id = 222, Species = "Tamme kastanje" });
            trees.Add(new Tree() { Id = 223, Species = "Tamme kastanje ‘Albomarginata’" });
            trees.Add(new Tree() { Id = 224, Species = "Taxus" });
            trees.Add(new Tree() { Id = 225, Species = "Treurberk" });
            trees.Add(new Tree() { Id = 226, Species = "Treurbeuk" });
            trees.Add(new Tree() { Id = 227, Species = "Treures" });
            trees.Add(new Tree() { Id = 228, Species = "Treuriep" });
            trees.Add(new Tree() { Id = 229, Species = "Trompetboom" });
            trees.Add(new Tree() { Id = 230, Species = "Tweestijlige meidoorn" });
            trees.Add(new Tree() { Id = 231, Species = "Vaantjesboom" });
            trees.Add(new Tree() { Id = 232, Species = "Varenbeuk" });
            trees.Add(new Tree() { Id = 233, Species = "Vederesdoorn" });
            trees.Add(new Tree() { Id = 234, Species = "Vederesdoorn ‘Variegatum’" });
            trees.Add(new Tree() { Id = 235, Species = "Vijvercipres" });
            trees.Add(new Tree() { Id = 236, Species = "Watercipres" });
            trees.Add(new Tree() { Id = 237, Species = "Westelijke hemlockspar" });
            trees.Add(new Tree() { Id = 238, Species = "Westerse levensboom" });
            trees.Add(new Tree() { Id = 239, Species = "Westerse netelboom" });
            trees.Add(new Tree() { Id = 240, Species = "Weymouthden" });
            trees.Add(new Tree() { Id = 241, Species = "Wilde lijsterbes" });
            trees.Add(new Tree() { Id = 242, Species = "Wilde lijsterbes ‘Fastigiata’" });
            trees.Add(new Tree() { Id = 243, Species = "Wilgbladige peer" });
            trees.Add(new Tree() { Id = 244, Species = "Winterbloeiende kers" });
            trees.Add(new Tree() { Id = 245, Species = "Wintereik" });
            trees.Add(new Tree() { Id = 246, Species = "Winterlinde" });
            trees.Add(new Tree() { Id = 247, Species = "Winterlinde ‘Böhlje’" });
            trees.Add(new Tree() { Id = 248, Species = "Winterlinde ‘Greenspire’" });
            trees.Add(new Tree() { Id = 249, Species = "Winterlinde ‘Rancho’" });
            trees.Add(new Tree() { Id = 250, Species = "Witte abeel" });
            trees.Add(new Tree() { Id = 251, Species = "Witte bitternoot" });
            trees.Add(new Tree() { Id = 252, Species = "Witte els" });
            trees.Add(new Tree() { Id = 253, Species = "Witte esdoorn" });
            trees.Add(new Tree() { Id = 254, Species = "Witte esdoorn ‘Laciniatum Wieri’" });
            trees.Add(new Tree() { Id = 255, Species = "Witte esdoorn ‘Pyramidale’" });
            trees.Add(new Tree() { Id = 256, Species = "Witte moerbei" });
            trees.Add(new Tree() { Id = 257, Species = "Witte paardenkastanje" });
            trees.Add(new Tree() { Id = 258, Species = "Yoshino kers" });
            trees.Add(new Tree() { Id = 259, Species = "Zachte berk" });
            trees.Add(new Tree() { Id = 260, Species = "Zelkova" });
            trees.Add(new Tree() { Id = 261, Species = "Zilverlinde" });
            trees.Add(new Tree() { Id = 262, Species = "Zilverlinde ‘Brabant’" });
            trees.Add(new Tree() { Id = 263, Species = "Zoete kers" });
            trees.Add(new Tree() { Id = 264, Species = "Zoete kers ‘Plena’" });
            trees.Add(new Tree() { Id = 265, Species = "Zomereik" });
            trees.Add(new Tree() { Id = 266, Species = "Zomereik ‘Fastigiate Koster’" });
            trees.Add(new Tree() { Id = 267, Species = "Zomerlinde" });
            trees.Add(new Tree() { Id = 268, Species = "Zuidelijke magnolia" });
            trees.Add(new Tree() { Id = 269, Species = "Zwarte balsempopulier" });
            trees.Add(new Tree() { Id = 270, Species = "Zwarte berk" });
            trees.Add(new Tree() { Id = 271, Species = "Zwarte den" });
            trees.Add(new Tree() { Id = 272, Species = "Zwarte els" });
            trees.Add(new Tree() { Id = 273, Species = "Zwarte els ‘Laciniata’" });
            trees.Add(new Tree() { Id = 274, Species = "Zwarte linde" });
            trees.Add(new Tree() { Id = 275, Species = "Zwarte moerbei" });
            trees.Add(new Tree() { Id = 276, Species = "Zwarte populier" });
            trees.Add(new Tree() { Id = 277, Species = "Zwarte tupeloboom" });
            trees.Add(new Tree() { Id = 278, Species = "Zwarte walnoot" });
            trees.Add(new Tree() { Id = 279, Species = "Zweedse berk" });
            trees.Add(new Tree() { Id = 280, Species = "Zweedse lijsterbes ‘Brouwers’" });


            builder.HasData(trees);
        }
    }
}
