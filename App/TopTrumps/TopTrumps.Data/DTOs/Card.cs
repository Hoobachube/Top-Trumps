
namespace TopTrumps.Data.DTOs
{
    using System.ComponentModel.DataAnnotations;

    public class Card
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        [Range(0, 100, ErrorMessage = "Age must be between 0 and 100.")]
        public decimal ABV { get; set; }

        [Required]
        public int Accessibility { get; set; }

        [Required]
        public int Reputation { get; set; }

        [Required]
        public int Popularity { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
