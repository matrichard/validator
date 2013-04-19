namespace Validator.Rules
{
    using System;

    using Validator.Base;

    public class Rule<TEntity> : IRuleBase<TEntity>
    {
        protected Func<TEntity, bool> rule;

        public Rule(Func<TEntity, bool> r)
        {
            this.rule = r;
        }

        public bool IsValid(TEntity entity)
        {
            return this.rule(entity);
        }
    }
}
