namespace GameDatabase.Infrastructure.Map
{
    [AttributeUsage(AttributeTargets.Property)]
    internal class CustomColumnAttribute : Attribute
    {
        private readonly string _dbproperty;
        public CustomColumnAttribute(string dbproperty)
        {
            _dbproperty = dbproperty;
        }

        public string GetDbProperty() => _dbproperty;
    }
}
