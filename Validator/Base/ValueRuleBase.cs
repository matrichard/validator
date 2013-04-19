namespace Validator.Base
{
    using System;
    using System.Linq.Expressions;

    public abstract class ValueRuleBase<TEntity, TValue> : RuleBase<TEntity, TValue>
        where TValue : struct
    {
        protected ValueRuleBase(Expression<Func<TEntity, TValue>> p)
            : base(p)
        {
        }
    }
}