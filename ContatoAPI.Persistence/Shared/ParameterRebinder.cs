using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ContatoAPI.Persistence.Shared
{
    public class ParameterRebinder : System.Linq.Expressions.ExpressionVisitor
    {

        private readonly Dictionary<ParameterExpression, ParameterExpression> map;

        public ParameterRebinder(Dictionary<ParameterExpression, ParameterExpression> map)
        {
            this.map = map ?? new Dictionary<ParameterExpression, ParameterExpression>();
        }

        public static Expression ReplaceParameters(Dictionary<ParameterExpression, ParameterExpression> map, Expression exp)
        {
            return new ParameterRebinder(map).Visit(exp);
        }

        protected override Expression VisitParameter(ParameterExpression p)
        {
            ParameterExpression replacement;

            if (map.TryGetValue(p, out replacement))
                p = replacement;

            return base.VisitParameter(p);
        }

    }
}