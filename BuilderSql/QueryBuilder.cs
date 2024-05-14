using System.Text;

namespace BuilderSql
{
    public class QueryBuilder
    {
        private readonly StringBuilder _query;

        public QueryBuilder()
        {
            _query = new StringBuilder();
        }

        public QueryBuilder Select(string columns)
        {
            _query.Append($"SELECT {columns}");
            return this;
        }

        public QueryBuilder From(string table)
        {
            _query.Append($" FROM {table}");
            return this;
        }

        public QueryBuilder Where(string condition)
        {
            _query.Append($" WHERE {condition}");
            return this;
        }

        public QueryBuilder And(string condition)
        {
            _query.Append($" AND {condition}");
            return this;
        }

        public QueryBuilder OrderBy(string orderBy)
        {
            _query.Append($" ORDER BY {orderBy}");
            return this;
        }

        public string Build()
        {
            return _query.ToString();
        }
    }
}
