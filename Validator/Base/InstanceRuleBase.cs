namespace Validator.Base
{
    using System;
    using System.Linq.Expressions;

    public abstract class InstanceRuleBase<TEntity, TInstance> : RuleBase<TEntity, TInstance>
        where TInstance : class
    {
        protected InstanceRuleBase(Expression<Func<TEntity, TInstance>> p)
            : base(p)
        {
        }
    }
}