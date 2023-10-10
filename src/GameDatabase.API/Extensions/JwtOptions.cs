namespace GameDatabase.API.Extensions
{
    public class JwtOptions
    {
        public const string JWT = "Jwt";
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Key { get; set; }
    }
}