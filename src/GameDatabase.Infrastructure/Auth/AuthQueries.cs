namespace GameDatabase.Infrastructure.Auth
{
    public class AuthQueries
    {
        public static string CreateUserAuth => @"Insert into [Users] ([Email], [PasswordHash], [UserName]) Values (@email, @password, @username)";
        public static string GetUserAuth => @"Select [Email], [Password], [UserName] from [Users] Where [Email] = @email";
    }
}
