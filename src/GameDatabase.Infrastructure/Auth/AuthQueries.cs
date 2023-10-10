namespace GameDatabase.Infrastructure.Auth
{
    public class AuthQueries
    {
        public static string CreateUserAuth => @"Insert into [Users] ([Email], [Password_Hash], [UserName]) Values (@email, @password, @username)";
        public static string GetUserAuth => @"Select [Id], [Email], [Password_Hash], [UserName] from [Users] Where [Email] = @email";
    }
}
