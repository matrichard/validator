namespace Validator.Rules
{
    using System;
    using System.Linq.Expressions;

    using Validator.Base;

    public class RequiredStringRule<TEntity> : StringRuleBase<TEntity>
    {
        public RequiredStringRule(Expression<Func<TEntity, string>> p)
            : base(p)
        {
        }

        protected override bool Validate(string value)
        {
            return !string.IsNullOrWhiteSpace(value);
        }
    }
}
