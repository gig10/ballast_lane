using System.ComponentModel.DataAnnotations;

namespace GameDatabase.API.GamesEndpoints.ApiModels
{
    public class GameCreateRequest
    {
        [Required]
        [MaxLength(120)]
        public string Title { get; set; }

        [MaxLength(1500)]
        public string Description { get; set; }

        [Required]
        [MaxLength(255)]
        public string ImageUrl { get; set; }
    }
}
