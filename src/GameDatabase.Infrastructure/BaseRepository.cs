using AutoMapper;
using GameDatabase.Infrastructure.BaseQueries;
using GameDatabase.Infrastructure.DbEntities;
using GameDatabase.Infrastructure.Map;

using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;

using System.Reflection;

namespace GameDatabase.Infrastructure
{
    public abstract class BaseRepository<TEntity, TDbEntity> where TDbEntity : DbEntity
    {
        private readonly string _connectionString;
        private readonly IMapper _mapper;

        public BaseRepository(IOptions<DatabaseOptions> options, IMapper mapper)
        {
            _connectionString = options.Value.ConnectionString;
            _mapper = mapper;
        }

        public async Task<int> ExecuteNonQueryAsync(BaseQuery<TDbEntity> query)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            using var cmd = query.Build(connection);
            return await cmd.ExecuteNonQueryAsync();
        }


        public async Task<int> ExecuteScalarAsync(BaseQuery<TDbEntity> query)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            using var cmd = query.Build(connection);
            return Convert.ToInt32(await cmd.ExecuteScalarAsync());
        }

        public async Task<TEntity> ExecuteSelectSingleAsync(BaseQuery<TDbEntity> query)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            using var cmd = query.Build(connection);

            using var reader = cmd.ExecuteReader();

            var propertiesToSelect = typeof(TDbEntity).GetProperties()
                .Where(p => p.GetCustomAttribute(typeof(CustomColumnAttribute)) != null)
                .Select(p =>
                new { PropertyInfo = p , column = ((CustomColumnAttribute)p.GetCustomAttribute(typeof(CustomColumnAttribute))).GetDbProperty() });

            TDbEntity instance = Activator.CreateInstance<TDbEntity>();

            if (reader.Read())
            {
                foreach (var prop in propertiesToSelect)
                {
                    prop.PropertyInfo.SetValue(instance, Convert.ChangeType(reader[prop.column], prop.PropertyInfo.PropertyType));
                }
            }
            else
            {
                return default;
            }

            return MapFromDbEntity(instance);
        }

        public async Task<List<TEntity>> ExecuteListAsync(BaseQuery<TDbEntity> query)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            using var cmd = query.Build(connection);

            using var reader = cmd.ExecuteReader();

            var propertiesToSelect = typeof(TDbEntity).GetProperties()
                .Where(p => p.GetCustomAttribute(typeof(CustomColumnAttribute)) != null)
                .Select(p =>
                new { PropertyInfo = p, column = ((CustomColumnAttribute)p.GetCustomAttribute(typeof(CustomColumnAttribute))).GetDbProperty() });


            List<TDbEntity> _list = new List<TDbEntity>();
            while(reader.Read())
            {
                TDbEntity instance = Activator.CreateInstance<TDbEntity>();
                foreach (var prop in propertiesToSelect)
                {
                    prop.PropertyInfo.SetValue(instance, Convert.ChangeType(reader[prop.column], prop.PropertyInfo.PropertyType));
                }
                _list.Add(instance);
            }

            return _mapper.Map<List<TEntity>>(_list);
        }

        protected TEntity MapFromDbEntity(TDbEntity dbEntity)
        {
            return _mapper.Map<TEntity>(dbEntity);
        }

        protected TDbEntity MapFromEntity(TEntity entity)
        {
            return _mapper.Map<TDbEntity>(entity);
        }
    }
}
