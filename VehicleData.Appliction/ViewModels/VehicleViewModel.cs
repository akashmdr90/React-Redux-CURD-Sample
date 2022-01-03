using System.ComponentModel.DataAnnotations;

namespace VehicleData.Application.ViewModels
{
    /// <summary>
    /// The Vehicle View Model
    /// </summary>
    public class VehicleViewModel
    {
        /// <summary>
        /// The vehicle Id
        /// </summary>
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// The vehicle manufacture year
        /// </summary>
        [Required(ErrorMessage = "Year is required.")]
        [RegularExpression(@"^19[5-9]\d|20[0-4]\d|2050$", ErrorMessage = "Please enter a valid year between 1950 and 2050.")]
        public int Year { get; set; }

        /// <summary>
        /// The vehicle make
        /// </summary>
        [Required(ErrorMessage = "Make is required.")]
        public string Make { get; set; }

        /// <summary>
        /// The vehicle model
        /// </summary>
        [Required(ErrorMessage = "Model is required.")]
        public string Model { get; set; }
    }
}
