namespace GameDatabase.API.AuthEndpoints.Payloads
{
    public class AuthResponse
    {
        public string Token { get; set; }
        public AuthResponse(string token)
        {
            Token = token;
        }
    }
}
