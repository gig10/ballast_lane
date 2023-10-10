using GameDatabase.Infrastructure.Map;

namespace GameDatabase.Infrastructure.DbEntities
{
    [CustomTable("Users")]
    public class DBAuthentication : DbEntity
    {
        [CustomColumn("Id")]
        public int Id { get; set; }

        [CustomColumn("Email")]
        public string Email { get; set; }

        [CustomColumn("UserName")]
        public string UserName { get; set; }

        [CustomColumn("Password_Hash")]
        public string PasswordHash { get; set; }
    }
}
