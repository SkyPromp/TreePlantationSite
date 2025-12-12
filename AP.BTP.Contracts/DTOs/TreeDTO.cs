using System.ComponentModel.DataAnnotations;

namespace AP.BTP.Contracts.DTOs
{
    public record TreeDto
    {
        /// <summary>
        /// The unique identifier of the tree.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The species of the tree.
        /// </summary>
        [Required(ErrorMessage = "Naam is verplicht.")]
        public required string Species { get; set; }

        /// <summary>
        /// The description of the tree.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// An optional spring maintenance plan associated with the tree. Can be <c>null</c> if no plan exists.
        /// </summary>
        public string? MaintenancePlanSpring { get; set; }

        /// <summary>
        /// An optional summer maintenance plan associated with the tree. Can be <c>null</c> if no plan exists.
        /// </summary>
        public string? MaintenancePlanSummer { get; set; }

        /// <summary>
        /// An optional autumn maintenance plan associated with the tree. Can be <c>null</c> if no plan exists.
        /// </summary>
        public string? MaintenancePlanAutumn { get; set; }

        /// <summary>
        /// An optional winter maintenance plan associated with the tree. Can be <c>null</c> if no plan exists.
        /// </summary>
        public string? MaintenancePlanWinter { get; set; }                        
    }
}
