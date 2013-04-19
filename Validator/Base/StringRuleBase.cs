namespace Validator.Base
{
    using System;
    using System.Linq.Expressions;

    public abstract class StringRuleBase<TEntity> : InstanceRuleBase<TEntity, string>
    {
        protected StringRuleBase(Expression<Func<TEntity, string>> p)
            : base(p)
        {
        }
    }
}
