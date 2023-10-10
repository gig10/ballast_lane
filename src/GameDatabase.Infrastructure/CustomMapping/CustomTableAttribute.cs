namespace GameDatabase.Infrastructure.Map
{
    [AttributeUsage(AttributeTargets.Class)]
    internal class CustomTableAttribute : Attribute
    {
        private readonly string _tableName;
        public CustomTableAttribute(string table)
        {
            _tableName = table;
        }

        public string GetTableName() => _tableName;
    }
}
