using GameDatabase.Infrastructure.DbEntities;

using Microsoft.Data.SqlClient;

using System.Data;

namespace GameDatabase.Infrastructure
{
    public abstract class BaseQuery<T> : IQuery where T : DbEntity
    {
        protected readonly T Entity;        

        public BaseQuery(T entity)
        {
            Entity = entity;            
        }
        public abstract SqlCommand Build(SqlConnection connection);
    }
}
