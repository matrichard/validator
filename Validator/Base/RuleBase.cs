namespace Validator.Base
{
    using System;
    using System.Linq.Expressions;

    public abstract class RuleBase<TEntity, T> : IRuleBase<TEntity>
    {
        private readonly Expression<Func<TEntity, T>> projection;

        protected RuleBase(Expression<Func<TEntity, T>> p)
        {
            this.projection = p;
        }

        public bool IsValid(TEntity value)
        {
            return this.Validate(this.projection.Compile()(value));
        }

        protected abstract bool Validate(T instance);
    }
}