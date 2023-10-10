using Microsoft.Data.SqlClient;

namespace GameDatabase.Infrastructure
{
    internal interface IQuery
    {
        SqlCommand Build(SqlConnection connection);
    }
}
