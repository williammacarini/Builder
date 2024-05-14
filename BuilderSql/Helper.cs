using System.Linq.Expressions;

namespace BuilderSql
{
    public static class Helper
    {
        public static string RemoveBraces(this Expression expression)
            => expression.ToString().Replace("{", "").Replace("}", "");

        public static string RemoveAlias(this string column)
        {
            var position = column.IndexOf('.') + 1;
            return column.Substring(position);
        }

        public static string GetOperator(this BinaryExpression binaryExpression)
        {
            return binaryExpression.NodeType switch
            {
                ExpressionType.Equal => "=",
                ExpressionType.GreaterThanOrEqual => ">=",
                ExpressionType.LessThanOrEqual => "<=",
                ExpressionType.GreaterThan => ">",
                ExpressionType.LessThan => "<",
                _ => throw new ArgumentException("Unsupported operator"),
            };
        }
    }
}
