using AP.BTP.Domain.Interfaces;
using System.Text.Json.Serialization;

namespace AP.BTP.Domain
{
    /// <summary>
    /// Represents a plantation site with associated details such as address, size, and related zones and users.
    /// Implements <see cref="IDeletable"/> to support soft deletion.
    /// </summary>
    public class PlantationSite: IDeletable
    {
        /// <summary>
        /// Gets or sets the unique identifier of the plantation site.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the plantation site.
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// Gets or sets the street of the plantation site's address.
        /// </summary>
        public required string Street { get; set; }

        /// <summary>
        /// Gets or sets the house number of the plantation site's address.
        /// </summary>
        public required string HouseNumber { get; set; }

        /// <summary>
        /// Gets or sets the city of the plantation site's address.
        /// </summary>
        public required string City { get; set; }

        /// <summary>
        /// Gets or sets the postal code of the plantation site's address.
        /// </summary>
        public int PostalCode { get; set; }

        /// <summary>
        /// Gets or sets the country of the plantation site.
        /// </summary>
        public required string Country { get; set; }

        /// <summary>
        /// Gets or sets the size of the plantation site in appropriate units (e.g., hectares).
        /// </summary>
        public double Size { get; set; }

        /// <summary>
        /// Gets or sets the ground plan of the plantation site.
        /// </summary>
        public required string GroundPlan { get; set; }

        /// <summary>
        /// Gets or sets the zones associated with the plantation site.
        /// This property is ignored during JSON serialization.
        /// </summary>
        [JsonIgnore] public ICollection<Zone> Zones { get; set; } = new List<Zone>();

        /// <summary>
        /// Gets or sets the users associated with the plantation site.
        /// This property is ignored during JSON serialization.
        /// </summary>
        [JsonIgnore] public IEnumerable<User>? Users { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the plantation site is considered deleted (soft deletion).
        /// </summary>
        public bool IsDeleted { get; set; } = false;
    }
}