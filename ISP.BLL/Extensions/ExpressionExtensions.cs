using System.Linq.Expressions;

namespace ISP.BLL.Extensions;

public static class ExpressionExtensions
{
    public static Expression<Func<T, bool>> And<T>(
        this Expression<Func<T, bool>> left,
        Expression<Func<T, bool>> right)
    {
        var parameter = Expression.Parameter(typeof(T));
            
        var leftVisitor = new ReplaceExpressionVisitor(left.Parameters[0], parameter);
        var leftExpression = leftVisitor.Visit(left.Body);
            
        var rightVisitor = new ReplaceExpressionVisitor(right.Parameters[0], parameter);
        var rightExpression = rightVisitor.Visit(right.Body);
            
        var andExpression = Expression.AndAlso(leftExpression, rightExpression);
            
        return Expression.Lambda<Func<T, bool>>(andExpression, parameter);
    }
        
    public static Expression<Func<T, bool>> Or<T>(
        this Expression<Func<T, bool>> left,
        Expression<Func<T, bool>> right)
    {
        var parameter = Expression.Parameter(typeof(T));
            
        var leftVisitor = new ReplaceExpressionVisitor(left.Parameters[0], parameter);
        var leftExpression = leftVisitor.Visit(left.Body);
            
        var rightVisitor = new ReplaceExpressionVisitor(right.Parameters[0], parameter);
        var rightExpression = rightVisitor.Visit(right.Body);
            
        var orExpression = Expression.OrElse(leftExpression, rightExpression);
            
        return Expression.Lambda<Func<T, bool>>(orExpression, parameter);
    }
        
    private class ReplaceExpressionVisitor(Expression oldValue, Expression newValue) : ExpressionVisitor
    {
        public override Expression Visit(Expression? node)
        {
            ArgumentNullException.ThrowIfNull(node);
            return node == oldValue ? newValue : base.Visit(node);
        }
    }
}