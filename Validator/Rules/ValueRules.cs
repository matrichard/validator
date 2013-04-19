namespace Validator.Rules
{
    using System;
    using System.Linq.Expressions;

    using Validator.Base;

    public class RequiredIntRule<TEntity> : ValueRuleBase<TEntity, int>
    {
        public RequiredIntRule(Expression<Func<TEntity, int>> p)
            : base(p)
        {
        }

        protected override bool Validate(int value)
        {
            return value > 0;
        }
    }
}
