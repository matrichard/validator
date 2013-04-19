namespace Validator.Rules
{
    using System;
    using System.Linq.Expressions;

    using Validator.Base;

    public class RequiredInstanceRule<TEntity, TInstance> : InstanceRuleBase<TEntity, TInstance>
        where TInstance : class
    {
        public RequiredInstanceRule(Expression<Func<TEntity, TInstance>> p)
            : base(p)
        {
        }

        protected override bool Validate(TInstance value)
        {
            return value != null;
        }
    }
}
