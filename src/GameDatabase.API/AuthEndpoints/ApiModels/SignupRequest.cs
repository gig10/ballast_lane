using System.ComponentModel.DataAnnotations;

namespace GameDatabase.API.AuthEndpoints.Payloads
{
    public class SignupRequest : AuthBasePayload
    {
        [Required]
        [StringLength(maximumLength: 30, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Required]
        [StringLength(maximumLength: 30, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 4)]
        public string UserName { get; set; }
    }
}
