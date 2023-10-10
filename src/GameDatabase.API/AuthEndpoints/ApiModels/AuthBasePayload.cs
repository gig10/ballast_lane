using System.ComponentModel.DataAnnotations;

namespace GameDatabase.API.AuthEndpoints.Payloads
{
    public abstract class AuthBasePayload
    {
        [Required]
        [MaxLength(100)]
        [EmailAddress]
        public string Email { get; set; }
    }
}
