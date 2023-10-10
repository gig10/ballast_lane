using GameDatabase.Infrastructure.Map;

namespace GameDatabase.Infrastructure.DbEntities
{
    [CustomTable("Games")]
    public class DbGame: DbEntity
    {
        [CustomColumn("Id")]
        public int Id { get; set; }

        [CustomColumn("Title")]
        public string Title { get; set; }

        [CustomColumn("Description")]
        public string Description { get; set; }

        [CustomColumn("ImageUrl")]
        public string ImageUrl { get; set; }
    }
}
