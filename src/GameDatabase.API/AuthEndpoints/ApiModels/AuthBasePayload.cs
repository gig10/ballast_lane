using System.ComponentModel.DataAnnotations;

namespace GameDatabase.API.AuthEndpoints.Payloads
{
    public abstract class AuthBasePayload
    {
        [Required]
        [MaxLength(100)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(maximumLength: 30, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 4)]
        public string UserName { get; set; }
    }
}
