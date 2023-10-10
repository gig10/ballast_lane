using Microsoft.Data.SqlClient;

namespace GameDatabase.Infrastructure.BaseQueries
{
    internal interface IQuery
    {
        SqlCommand Build(SqlConnection connection);
    }
}
