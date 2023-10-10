namespace GameDatabase.API.AuthEndpoints.Payloads
{
    public class AuthResponse : AuthBasePayload
    {
        public int Id { get; set; }
        public string UserName { get; set; }
    }
}
