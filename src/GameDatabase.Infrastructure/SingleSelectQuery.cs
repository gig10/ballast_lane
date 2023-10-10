using GameDatabase.Infrastructure.DbEntities;

using Microsoft.Data.SqlClient;

namespace GameDatabase.Infrastructure
{
    public abstract class SingleSelectQuery<T>  where T : DbEntity
    {
        public SingleSelectQuery()
        {

        }
        public abstract SqlCommand Build(SqlConnection connection);
    }
}
