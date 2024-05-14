using System.Linq.Expressions;
using System.Text;

namespace BuilderSql
{
    public class QueryExpressionBuilder<T> where T : class
    {
        private readonly StringBuilder _sb = new();
        private string[] _select;
        private readonly string _from;
        private Expression<Func<T, bool>> _where;
        private readonly List<Expression<Func<T, bool>>> _ands = [];
        private Expression<Func<T, object>> _orderBy;

        public QueryExpressionBuilder()
        {
            _select = ["*"];
            _from = typeof(T).Name;
        }

        public QueryExpressionBuilder<T> Select(params Expression<Func<T, object>>[] select)
        {
            _select = select.Select(GetPropertyName).ToArray();
            return this;
        }

        public QueryExpressionBuilder<T> Where(Expression<Func<T, bool>> where)
        {
            _where = where;
            return this;
        }

        public QueryExpressionBuilder<T> And(Expression<Func<T, bool>> and)
        {
            _ands.Add(and);
            return this;
        }

        public QueryExpressionBuilder<T> OrderBy(Expression<Func<T, object>> orderBy)
        {
            _orderBy = orderBy;
            return this;
        }

        public string Build()
        {
            if (AllColumns())
                _sb.Append($"SELECT {_select[0]} FROM {_from}");
            else
                _sb.Append($"SELECT {string.Join(", ", _select)} FROM {_from}");

            if (_where != null)
                _sb.Append($" WHERE {GetAssertion(_where)}");

            if (_ands.Count > 0)
                foreach (var and in _ands)
                    _sb.Append($" AND {GetAssertion(and)}");

            if (_orderBy != null)
                _sb.Append($" ORDER BY {GetPropertyName(_orderBy)}");

            return _sb.ToString();
        }

        private bool AllColumns() => _select[0] == "*";

        private static string GetPropertyName(Expression<Func<T, object>> expression)
        {
            if (expression.Body is UnaryExpression unaryExpression && unaryExpression.Operand is MemberExpression memberExpression)
                return memberExpression.Member.Name;
            else if (expression.Body is MemberExpression memberExp)
                return memberExp.Member.Name;

            throw new Exception(expression.ToString());
        }

        private static string GetAssertion(Expression<Func<T, bool>> expression)
        {
            if (expression.Body is BinaryExpression binaryExpression)
            {
                var column = binaryExpression.Left.RemoveBraces().RemoveAlias();
                var informedValue = binaryExpression.Right.RemoveBraces().ToLower();
                var operatorType = binaryExpression.GetOperator();

                return string.Join(" ", [column, operatorType, informedValue]);
            }

            throw new ArgumentException("Invalid expression");
        }
    }
}
